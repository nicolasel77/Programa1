namespace Programa1.Carga.Varios
{
    using Programa1.DB;
    using Programa1.DB.Varios;
    using System;
    using System.Windows.Forms;

    public partial class frmGuardar_Semana : Form
    {
        readonly Estadisticas estadisticas = new Estadisticas();
        public frmGuardar_Semana()
        {
            InitializeComponent();

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, estadisticas.semanas.Fechas(50), "dd/MM/yyy");
        }

        private void cmdGuardar_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            for (int i = lstSemanas.Items.Count - 1; i > -1; i--)
            {

                if (lstSemanas.GetSelected(i) == true)
                {
                    string n = lstSemanas.Items[i].ToString();

                    cmdGuardar.Text = $"Guardando {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chSemana.Checked == true) { estadisticas.Guardar(DateTime.Parse(n)); }
                    cmdGuardar.Text = $"Venta por productos {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chVentaPorProducto.Checked == true) { estadisticas.Venta_PorProductos(DateTime.Parse(n)); }
                    cmdGuardar.Text = $"Bloqueando {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chBloquear.Checked == true) { estadisticas.semanas.Bloquear(DateTime.Parse(n)); }
                }
            }
            Close();
            this.Cursor = Cursors.Default;

        }

        private void lstSemanas_DoubleClick(object sender, EventArgs e)
        {
            cmdGuardar.PerformClick();
        }

        private void cmdDesbloquear_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            for (int i = lstSemanas.Items.Count - 1; i > -1; i--)
            {

                if (lstSemanas.GetSelected(i) == true)
                {
                    string n = lstSemanas.Items[i].ToString();

                    cmdGuardar.Text = $"Desbloqueando {n:dd/MM/yy}";
                    Application.DoEvents();
                  
                    estadisticas.semanas.Bloquear(DateTime.Parse(n), false); 
                    Application.DoEvents();
                }
            }
            Close();
            this.Cursor = Cursors.Default;
        }
    }
}
