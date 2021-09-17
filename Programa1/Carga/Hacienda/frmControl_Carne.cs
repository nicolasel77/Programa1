namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmControl_Carne : Form
    {
        public frmControl_Carne()
        {
            InitializeComponent();
        }

        private void lstOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            NBoletas nb = new NBoletas();
            switch (lstOpcion.SelectedIndex)
            {
                case 0:
                    System.Data.DataTable dt = nb.Control(cFecha.fecha_Actual, cFecha.fecha_Fin, NBoletas.t_Opcion.Compras_Faena);
                    grd.MostrarDatos(dt, true, false);
                    if (dt != null)
                    {
                        grd.Columnas["Compra"].Format = "N1";
                        grd.Columnas["Agregados"].Format = "N1";
                        grd.Columnas["Faena"].Format = "N1";
                        grd.Columnas["Diferencia"].Format = "N1";

                        grd.AutosizeAll(); 
                    }
                    break;

                case 1:
                    dt = nb.Control(cFecha.fecha_Actual, cFecha.fecha_Fin, NBoletas.t_Opcion.Faena_Salidas);
                    grd.MostrarDatos(dt, true, false);
                    if (dt != null)
                    {
                        grd.Columnas["k_Faena"].Format = "N1";
                        grd.Columnas["k_Sal"].Format = "N1";
                        grd.Columnas["t_Faena"].Format = "N1";
                        grd.Columnas["t_Sal"].Format = "N1";
                        grd.Columnas["Dif_Medias"].Format = "N";
                        grd.Columnas["Dif_Kg"].Format = "N1";
                        grd.Columnas["Diferencia"].Format = "N1";

                        grd.AutosizeAll();
                    }
                    break;
                case 2:
                    dt = nb.Control(cFecha.fecha_Actual, cFecha.fecha_Fin, NBoletas.t_Opcion.Compras_Salidas);
                    grd.MostrarDatos(dt, true, false);
                    if (dt != null)
                    {
                        grd.Columnas["Compra"].Format = "N1";
                        grd.Columnas["Agregados"].Format = "N1";
                        grd.Columnas["T_Sal"].Format = "N1";
                        grd.Columnas["Total"].Format = "N1";
                        grd.Columnas["Diferencia"].Format = "N1";

                        grd.AutosizeAll();
                    }
                    break;
            }
            C1.Win.C1FlexGrid.CellStyle error = grd.Styles.Add("error");
            error.BackColor = Color.LightSalmon;
            for(int i = 1; i<= grd.Rows-1; i++)
            {
                float n = Convert.ToSingle(grd.get_Texto(i, grd.get_ColIndex("Diferencia")));
                if (n < -1 | n > 1) { grd.Filas[i].Style = error; }
            }
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            if(lstOpcion.SelectedIndex != -1) { Cargar(); }
        }
    }
}
