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

            this.Cursor = Cursors.WaitCursor;
            recu.Frigorifico.ID = h.Codigo_Seleccionado(lstFrigorificos.Text);
            
            grd.MostrarDatos(recu.Resumen((int)nuCant.Value), true, false);
            grd.Columnas["Kilos"].Format = "N1";
            grd.Columnas["Recupero"].Format = "N1";
            grd.Columnas["Pago_Nuestro"].Format = "N1";
            grd.Columnas["Pago_Frigo"].Format = "N1";
            grd.Columnas["Ajustes"].Format = "N1";
            grd.Columnas["Diferencia"].Format = "N1";
            grd.Columnas["Saldo"].Format = "N1";

            int r = grd.Rows - 1;

            DateTime f = (DateTime)grd.get_Texto(r, grd.get_ColIndex("Semana"));

            double t = recu.Saldo(f);
            grd.set_Texto(r, grd.get_ColIndex("Saldo"), t);

            for (int i = r - 1; i > 1; i--)
            {

                double rp = Convert.ToDouble(grd.get_Texto(i, grd.get_ColIndex("Recupero")));
                double pg = Convert.ToDouble(grd.get_Texto(i - 1, grd.get_ColIndex("Pago_Frigo")));
                double pn = Convert.ToDouble(grd.get_Texto(i - 1, grd.get_ColIndex("Pago_Nuestro")));
                double aj = Convert.ToDouble(grd.get_Texto(i - 1, grd.get_ColIndex("Ajustes")));

                t = t + rp - pg - pn - aj;

                grd.set_Texto(i, grd.get_ColIndex("Diferencia"), pg - rp + aj);

                grd.set_Texto(i, grd.get_ColIndex("Saldo"), -t);
            }

            grd.AutosizeAll();
                        

            this.Cursor = Cursors.Default;


        }
    }
}
