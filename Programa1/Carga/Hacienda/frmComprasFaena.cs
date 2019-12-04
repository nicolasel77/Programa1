namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmComprasFaena : Form
    {
        Hacienda hc = new Hacienda();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_NB;
        private Byte c_Fecha;
        private Byte c_Directo;
        private Byte c_Reparto;
        private Byte c_Consig;
        private Byte c_IdProd;
        private Byte c_Cab;
        private Byte c_Kilos;
        private Byte c_Costo;
        private Byte c_SubT;
        private Byte c_IVA;
        private Byte c_Total;
        private Byte c_Plazo;

        private Byte A_Id;
        private Byte A_NB;
        private Byte A_Consig;
        private Byte A_Tipo;
        private Byte A_Impporte;
        private Byte A_Plazo;

        private Byte F_Id;
        private Byte F_NBoleta;
        private Byte F_Fecha;
        private Byte F_Cat;
        private Byte F_NRomaneo;
        private Byte F_Tropa;
        private Byte F_Prod;
        private Byte F_Frigo;
        private Byte F_Recu;
        private Byte F_Kilos;
        #endregion
        public frmComprasFaena()
        {
            InitializeComponent();

            grdBoletas.MostrarDatos(hc.nBoletas.Datos(), true, false);
            grdBoletas.AutosizeAll();
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Costo")].Format = "C3";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Costo_Faena")].Format = "C3";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Kilos_Compra")].Format = "N0";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Kilos_Faena")].Format = "N0";

            grdCompras.MostrarDatos(hc.compra.Datos("NBoleta=0"), true);

            c_Id = Convert.ToByte(grdCompras.get_ColIndex("Id"));
            c_NB = Convert.ToByte(grdCompras.get_ColIndex("NBoleta"));
            c_Fecha = Convert.ToByte(grdCompras.get_ColIndex("Fecha"));
            c_Reparto = Convert.ToByte(grdCompras.get_ColIndex("Reparto"));
            c_Directo = Convert.ToByte(grdCompras.get_ColIndex("Directo"));
            c_Consig = Convert.ToByte(grdCompras.get_ColIndex("Id_Consignatarios"));
            c_IdProd = Convert.ToByte(grdCompras.get_ColIndex("Id_Productos"));
            c_Cab = Convert.ToByte(grdCompras.get_ColIndex("Cabezas"));
            c_Kilos = Convert.ToByte(grdCompras.get_ColIndex("Kilos"));
            c_Costo = Convert.ToByte(grdCompras.get_ColIndex("Costo"));
            c_SubT = Convert.ToByte(grdCompras.get_ColIndex("Sub_Total"));
            c_IVA = Convert.ToByte(grdCompras.get_ColIndex("IVA"));
            c_Total = Convert.ToByte(grdCompras.get_ColIndex("Total"));
            c_Plazo = Convert.ToByte(grdCompras.get_ColIndex("Plazo"));

            grdCompras.set_Texto(0, c_IdProd, "Prod");
            grdCompras.set_Texto(0, c_IdProd + 1, "Desc");

            grdCompras.set_ColW(c_Id, 0);
            grdCompras.set_ColW(c_NB, 0);
            grdCompras.set_ColW(c_Fecha, 0);
            grdCompras.set_ColW(c_Reparto, 0);
            grdCompras.set_ColW(c_Directo, 0);
            grdCompras.set_ColW(c_Consig, 40);
            grdCompras.set_ColW(c_Consig + 1, 100);
            grdCompras.set_ColW(c_IdProd, 40);
            grdCompras.set_ColW(c_IdProd + 1, 60);
            grdCompras.set_ColW(c_Cab, 30);
            grdCompras.set_ColW(c_Kilos, 80);
            grdCompras.set_ColW(c_Costo, 60);
            grdCompras.set_ColW(c_SubT, 100);
            grdCompras.set_ColW(c_IVA, 100);
            grdCompras.set_ColW(c_Total, 100);
            grdCompras.set_ColW(c_Plazo, 40);

            grdCompras.Columnas[c_Kilos].Format = "N2";
            grdCompras.Columnas[c_Costo].Format = "C2";
            grdCompras.Columnas[c_SubT].Format = "C2";
            grdCompras.Columnas[c_IVA].Format = "C2";
            grdCompras.Columnas[c_Total].Format = "C2";

            grdAgregados.MostrarDatos(hc.Agregados.Datos("NBoleta=0"), true);

            A_Id = Convert.ToByte(grdAgregados.get_ColIndex("Id"));
            A_NB = Convert.ToByte(grdAgregados.get_ColIndex("NBoleta"));
            A_Consig = Convert.ToByte(grdAgregados.get_ColIndex("Id_Consignatarios"));
            A_Tipo = Convert.ToByte(grdAgregados.get_ColIndex("Id_TipoAgregados"));
            A_Impporte = Convert.ToByte(grdAgregados.get_ColIndex("Importe"));
            A_Plazo = Convert.ToByte(grdAgregados.get_ColIndex("Plazo"));

            grdAgregados.set_ColW(A_Id, 0);
            grdAgregados.set_ColW(A_NB, 0);
            grdAgregados.set_ColW(A_Consig, 40);
            grdAgregados.set_ColW(A_Consig + 1, 100);
            grdAgregados.set_ColW(A_Tipo, 40);
            grdAgregados.set_ColW(A_Tipo + 1, 100);
            grdAgregados.set_ColW(A_Impporte, 100);
            grdAgregados.set_ColW(A_Plazo, 40);

            grdAgregados.Columnas[A_Impporte].Format = "C2";


            grdFaena.MostrarDatos(hc.Faena.Datos(), true, true);

            F_Id = Convert.ToByte(grdFaena.get_ColIndex("Id"));
            F_NBoleta = Convert.ToByte(grdFaena.get_ColIndex("NBoleta"));
            F_Fecha = Convert.ToByte(grdFaena.get_ColIndex("Fecha"));
            F_Cat = Convert.ToByte(grdFaena.get_ColIndex("Id_Categorias"));
            F_NRomaneo = Convert.ToByte(grdFaena.get_ColIndex("NRomaneo"));
            F_Tropa = Convert.ToByte(grdFaena.get_ColIndex("Tropa"));
            F_Prod = Convert.ToByte(grdFaena.get_ColIndex("Id_Productos"));
            F_Frigo = Convert.ToByte(grdFaena.get_ColIndex("Id_Frigorificos"));
            F_Recu = Convert.ToByte(grdFaena.get_ColIndex("Recupero"));
            F_Kilos = Convert.ToByte(grdFaena.get_ColIndex("Kilos"));

            grdFaena.set_Texto(0, F_Prod, "Prod");
            grdFaena.set_Texto(0, F_Prod + 1, "Desc");

            grdFaena.set_ColW(F_Id, 0);
            grdFaena.set_ColW(F_NBoleta, 0);
            grdFaena.set_ColW(F_Fecha, 60);
            grdFaena.set_ColW(F_Cat, 40);
            grdFaena.set_ColW(F_Cat + 1, 50);
            grdFaena.set_ColW(F_NRomaneo, 70);
            grdFaena.set_ColW(F_Tropa, 60);
            grdFaena.set_ColW(F_Prod, 40);
            grdFaena.set_ColW(F_Prod + 1, 50);
            grdFaena.set_ColW(F_Frigo, 40);
            grdFaena.set_ColW(F_Frigo + 1, 50);
            grdFaena.set_ColW(F_Recu, 50);
            grdFaena.set_ColW(F_Kilos, 80);

            grdFaena.Columnas[F_Kilos].Format = "N2";
            grdFaena.Columnas[F_NRomaneo].Format = "N0";
            grdFaena.Columnas[F_Recu].Format = "C2";
        }

        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            System.Media.SystemSounds.Beep.Play();
        }

        private void GrdBoletas_CambioFila(short Fila)
        {
            hc.nBoletas.NBoleta = Convert.ToInt32(grdBoletas.get_Texto(Fila, 0));
            grdCompras.MostrarDatos(hc.compra.Datos("NBoleta=" + hc.nBoletas.NBoleta), false);
            grdCompras.set_Texto(0, c_IdProd, "Prod");
            grdCompras.set_Texto(0, c_IdProd + 1, "Desc");

            grdAgregados.MostrarDatos(hc.Agregados.Datos("NBoleta=" + hc.nBoletas.NBoleta), false);

            hc.Faena.nBoleta = hc.nBoletas;
            grdFaena.MostrarDatos(hc.Faena.Datos(), false);

            grdRomaneos.MostrarDatos(hc.Faena.Romaneos(), true, true);
            grdRomaneos.SumarCol(2, true);

            grdRomaneos.Columnas[0].Format = "N0";
            grdRomaneos.Columnas[2].Format = "N1";

            grdRomaneos.set_ColW(0, 80);
            grdRomaneos.set_ColW(1, 40);
            grdRomaneos.set_ColW(2, 70);

            Totales();
        }
        private void Totales()
        {
            double tCompra = grdCompras.SumarCol(c_Total, false);
            double kCompra = grdCompras.SumarCol(c_Kilos, false);
            double cabezas = grdCompras.SumarCol(c_Cab, false);
            lblCCant.Text = $"Registros: {cabezas:N0}";
            lblCKilos.Text = $"Kilos: {kCompra:N2}";
            lblCTotal.Text = $"Total: {tCompra:C2}";

            double tAgregados = grdAgregados.SumarCol(A_Impporte, false);
            lblATotal.Text = $"Total: {tAgregados:C2}";

            tCompra = (tCompra + tAgregados);
            if (kCompra != 0)
            {
                lblCInt.Text = $"Integración: {tCompra / kCompra:C3}";
            }
            else
            {
                lblCInt.Text = "";
            }

            double tRecupero = 0;
            double kFaena = 0;
            double cFaena = 0;

            for (int i = 1; i < grdFaena.Rows - 1; i++)
            {
                tRecupero += Convert.ToSingle(grdFaena.get_Texto(i, F_Recu)) * Convert.ToSingle(grdFaena.get_Texto(i, F_Kilos));
                kFaena += Convert.ToSingle(grdFaena.get_Texto(i, F_Kilos));
                cFaena++;
            }
            lblCant.Text = $"Cantidad: {cFaena:N0}";
            lblKilos.Text = $"Kilos: {kFaena:N2}";
            lblTotal.Text = $"Recupero: {tRecupero:C2}";
            lblCostoCarne.Text = $"Costo Carne: {(tCompra / kFaena) - (tRecupero/kFaena):C3}";

            if (kCompra != 0)
            {
                lblRendimiento.Text = $"Rendimiento: {(kFaena / kCompra * 100):N2}";
            }
            else
            {
                lblRendimiento.Text = "";
            }
            if (cabezas != 0 & cFaena != (cabezas*2))
            {
                lblCant.BackColor = Color.Red;                
            }
            else
            {
                lblCant.BackColor = System.Drawing.SystemColors.Control;                
            }
        }
    }
}
