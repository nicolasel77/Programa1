namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;
    public partial class frmPagar_Hacienda : Form
    {
        public Saldos_Consignatarios saldos = new Saldos_Consignatarios();

        const int cID = 0;
        const int cFecha = 1;
        const int cPlazo = 2;
        const int cVenc = 3;
        const int cDias = 4;
        const int cNBoleta = 5;
        const int cCab = 6;
        const int cDescripcion = 7;
        const int cKilos = 8;
        const int cCosto = 9;
        const int cTotal = 10;
        const int cPago = 11;
        const int cSaldo = 12;
        const int cNuevo = 13;

        //Id, Fecha, Plazo, Venc, NBoleta, Cabezas, Descripcion, Kilos, Costo, Total, Pago, Saldo, 0.0 AS Nuevo
        public frmPagar_Hacienda()
        {
            InitializeComponent();
        }
        public void Cargar()
        {
            lblConsignatario.Text = saldos.gastos.Desc_SubTipo;

            grd.TeclasManejadas = new int[] { 43 };

            grd.MostrarDatos(saldos.Datos(), true, false);

            grd.Columnas[cKilos].Style.Format = "N1";
            grd.Columnas[cCosto].Style.Format = "N1";
            grd.Columnas[cTotal].Style.Format = "N1";
            grd.Columnas[cPago].Style.Format = "N1";
            grd.Columnas[cSaldo].Style.Format = "N1";
            grd.Columnas[cNuevo].Style.Format = "N1";

            grd.AutosizeAll();
            grd.set_ColW(cID, 0);
            grd.set_ColW(cTotal, 80);
            grd.set_ColW(cPago, 80);
            grd.set_ColW(cSaldo, 80);
            grd.set_ColW(cNuevo, 80);

            grd.ActivarCelda(1, cNuevo);
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c== cNuevo)
            {
                grd.set_Texto(f, c, a);
                a = Convert.ToDouble( grd.get_Texto(f, cSaldo))  + Convert.ToDouble(a);
                grd.set_Texto(f, cSaldo, a);
            }
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 43)
            {
                int r = grd.Row;
                grd.set_Texto(r, cNuevo, Convert.ToDouble(grd.get_Texto(r, cSaldo)) * -1);
                grd.set_Texto(r, cSaldo, 0);
                if (r< grd.Rows - 1) { grd.ActivarCelda(r + 1, cNuevo); }
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
