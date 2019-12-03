namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
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
        #endregion
        public frmComprasFaena()
        {
            InitializeComponent();
            
            grdBoletas.MostrarDatos(hc.nBoletas.Datos(), true, false);
            grdBoletas.AutosizeAll();

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

            grdAgregados.Columnas[A_Impporte].Format = "C2";
        }

        private void GrdBoletas_CambioFila(short Fila)
        {
            hc.nBoletas.NBoleta = Convert.ToInt32( grdBoletas.get_Texto(Fila, 0));
            grdCompras.MostrarDatos(hc.compra.Datos("NBoleta=" + hc.nBoletas.NBoleta), false);
            grdCompras.set_Texto(0, c_IdProd, "Prod");
            grdCompras.set_Texto(0, c_IdProd + 1, "Desc");

            grdAgregados.MostrarDatos(hc.Agregados.Datos("NBoleta=" + hc.nBoletas.NBoleta), false);            

            Totales();
        }
        private void Totales()
        {
            double t = grdCompras.SumarCol(c_Total, false);
            double k = grdCompras.SumarCol(c_Kilos, false);
            double c = grdCompras.SumarCol(c_Cab, false);
            lblCCant.Text = $"Registros: {c:N0}";
            lblCKilos.Text = $"Kilos: {k:N2}";
            lblCTotal.Text = $"Total: {t:C2}";
            
            double ta = grdAgregados.SumarCol(A_Impporte, false);
            lblATotal.Text = $"Total: {ta:C2}";

            if (k != 0)
            {
                lblCInt.Text = $"Integración: {(t + ta) / k:C3}";
            }
            else
            {
                lblCInt.Text = "";
            }
        }
    }
}
