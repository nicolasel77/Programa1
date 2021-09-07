namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmResumen_Recupero : Form
    {
        readonly Recupero recu = new Recupero();
        public frmResumen_Recupero()
        {
            InitializeComponent();
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            h.Llenar_List(lstFrigorificos, recu.Frigorifico.Datos());

            recu.Frigorifico.ID = -1;
            recu.Fecha = DateTime.Today;
            grd.MostrarDatos(recu.Resumen((int)nuCant.Value), true, false);
        }

        private void lstFrigorificos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            recu.Frigorifico.ID = h.Codigo_Seleccionado(lstFrigorificos.Text);
            if (lstFechas.SelectedIndex > -1)
            {
                recu.Fecha = DateTime.Parse(lstFechas.Text);
            }
            else
            {
                recu.Fecha = DateTime.Today;
            }
            grd.MostrarDatos(recu.Resumen((int)nuCant.Value), true, false);
            grd.Columnas["Recupero"].Format = "N1";
            grd.Columnas["Pago_Nuestro"].Format = "N1";
            grd.Columnas["Pago_Frigo"].Format = "N1";
            grd.Columnas["Ajustes"].Format = "N1";
            grd.Columnas["Diferencia"].Format = "N1";
            grd.AutosizeAll();

        }
    }
}
