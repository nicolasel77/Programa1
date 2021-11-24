namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class frmConsulta_Precios : Form
    {
        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();
        C1.Win.C1FlexGrid.CellStyle estilo;
        private DataTable dt;

        #region Columnas
        const int cF1 = 0;
        const int cF2 = 1;
        const int cCod = 2;
        const int cProd = 3;
        const int cCosto = 4;
        const int cNCosto = 5;
        const int cDifCompra = 6;
        const int cPorCosto = 7;

        const int cSep1 = 8;

        const int cVenta = 9;
        const int cNVenta = 10;
        const int cDifVenta = 11;
        const int cPorVenta = 12;

        const int cSep2 = 13;

        const int cCantOferta = 14;
        const int cCostoOferta = 15;
        const int cPromOferta = 16;
        const int cDifOferta = 17;
        const int cPorOferta = 18;
        #endregion

        public frmConsulta_Precios()
        {
            InitializeComponent();

            TipoProductos tipoProductos = new TipoProductos();

            h.Llenar_List(lstTipos, tipoProductos.Datos());

            grd.TeclasManejadas = new int[] { 32 };

            grd.AgregarTeclas(Convert.ToInt32(Keys.Add), cNCosto, cNVenta, cCantOferta, cCostoOferta);

        }

        private void lstTipos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Precios_Sucursales pr = new Precios_Sucursales();
            SqlParameter sqlP = new SqlParameter("Tipo", h.Codigo_Seleccionado(lstTipos.Text));
            dt = pr.sp_Datos("sp_ConsultaPrecios", sqlP);

            grd.MostrarDatos(dt, true, false);
            for (int i = 4; i < grd.Cols - 1; i++)
            {
                grd.Columnas[i].Format = "N2";
            }
            grd.Columnas[cCantOferta].Format = "N1";

            grd.Columnas[cNCosto].StyleNew.BackColor = System.Drawing.Color.Cornsilk;
            grd.Columnas[cNVenta].StyleNew.BackColor = System.Drawing.Color.Cornsilk;
            grd.Columnas[cCantOferta].StyleNew.BackColor = System.Drawing.Color.Cornsilk;
            grd.Columnas[cCostoOferta].StyleNew.BackColor = System.Drawing.Color.Cornsilk;
            grd.AutosizeAll();
                        
            grd.set_Texto(0, cSep1, "");
            grd.set_Texto(0, cSep2, "");
            grd.set_ColW(cSep1, 30);
            grd.set_ColW(cSep2, 30);
            grd.Columnas[cSep1].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
            grd.Columnas[cSep2].StyleNew.BackColor = System.Drawing.Color.Gainsboro;
        }

        private void grd_Editado(short f, short c, object a)
        {
            grd.set_Texto(f, c, a);

            float Costo = Convert.ToSingle(grd.get_Texto(f, cCosto));
            float n_Costo = Convert.ToSingle(grd.get_Texto(f, cNCosto));
            float difCosto = n_Costo - Costo;
            float porCosto = difCosto / Costo * 100;
            float n_Venta = Convert.ToSingle(grd.get_Texto(f, cNVenta));
            float difVenta = n_Venta - n_Costo;
            float porVenta = difVenta / n_Costo * 100;
            float cantidad = Convert.ToSingle(grd.get_Texto(f, cCantOferta));
            float oferta = Convert.ToSingle(grd.get_Texto(f, cCostoOferta));

            grd.set_Texto(f, cDifCompra, difCosto);
            grd.set_Texto(f, cPorCosto, porCosto);
            grd.set_Texto(f, cDifVenta, difVenta);
            grd.set_Texto(f, cPorVenta, porVenta);
            grd.set_Texto(f, cPromOferta, Math.Round(oferta / cantidad, 0));
            grd.set_Texto(f, cDifOferta, Math.Round(oferta / cantidad, 0) - n_Costo);
            grd.set_Texto(f, cPorOferta, (Math.Round(oferta / cantidad, 0) - n_Costo) / n_Costo * 100);

            switch (c)
            {
                case cNCosto:
                    grd.ActivarCelda(f, cNVenta);

                    break;
                case cNVenta:
                    grd.ActivarCelda(f, cCantOferta);

                    break;

                case cCantOferta:
                    grd.ActivarCelda(f, cCostoOferta);

                    break;

                case cCostoOferta:
                    grd.ActivarCelda(f + 1, cNCosto);

                    break;
            }
           
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                estilo = grd.Styles.Add("");
                estilo.BackColor = System.Drawing.Color.LightCoral;
                grd.Filas[grd.Row].Style = estilo;
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                //dt.Clear();
                for (int i = 0; i < grd.Rows - 1; i++)
                {
                    for (int c = 4; c < grd.Cols - 1; c++)
                    {
                        dt.Rows[i][c] = grd.get_Texto(i + 1, c);
                    }
                }

                Formatear_Excel.Formatear fm = new Formatear_Excel.Formatear();
                fm.Formato_Automatico(dt);
            }
        }
    }
}
