namespace Programa1.Carga.Varios
{
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
            //string[] nn = lstSemanas.SelectedItems;
            //foreach(string n in lstSemanas.SelectedItems.Reverse<string>())
            //{

            //}
            for (int i = lstSemanas.Items.Count - 1; i > -1; i--)
            {

                if (lstSemanas.GetSelected(i) == true)
                {
                    string n = lstSemanas.Items[i].ToString();

                    cmdGuardar.Texto = $"Guardando {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chSemana.Checked == true) { estadisticas.Guardar(DateTime.Parse(n)); }
                    cmdGuardar.Texto = $"Venta por productos {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chVentaPorProducto.Checked == true) { estadisticas.Venta_PorProductos(DateTime.Parse(n)); }
                    cmdGuardar.Texto = $"Bloqueando {n:dd/MM/yy}";
                    Application.DoEvents();
                    if (chBloquear.Checked == true) { estadisticas.semanas.Bloquear(DateTime.Parse(n)); }
                }
            }
            Close();
        }
    }
}
