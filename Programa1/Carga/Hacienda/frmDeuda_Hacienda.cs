namespace Programa1.Carga.Hacienda
{
    using DB.Hacienda;
    using System;
    using System.Windows.Forms;
    public partial class frmDeuda_Hacienda : Form
    {
        public frmDeuda_Hacienda()
        {
            InitializeComponent();
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Hacienda h = new Hacienda();
            this.Cursor = Cursors.WaitCursor;
            grd.MostrarDatos(h.Deuda_Hacienda(cFechas1.fecha_Fin), true, true);
            for (int i = 1; i < grd.Cols - 1; i++)
            {
                grd.SumarCol(i, true);
                grd.Columnas[i].Format = "N1";
            }
            grd.Columnas[grd.Cols - 1].Format = "N1";
            grd.AutosizeAll();
            this.Cursor = Cursors.Default;
        }
    }
}
