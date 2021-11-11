namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System.Windows.Forms;

    public partial class frmPrestamos : Form
    {
        public frmPrestamos()
        {
            InitializeComponent();            
        }

        private void Cargar()
        {
            Prestamos pr = new Prestamos();
            string fecha = cFecha.Cadena();
            double t = 0;

            grdEntrada.MostrarDatos(pr.Entradas(fecha), true);
            grdEntrada.Columnas["Importe"].Format = "N";
            t = grdEntrada.SumarCol(grdEntrada.get_ColIndex("Importe"), true);

            grdEntrada.AutosizeAll();

            grdPagos.MostrarDatos(pr.Pagos(fecha), true);
            grdPagos.Columnas["Importe"].Format = "N";
            t -= grdPagos.SumarCol(grdPagos.get_ColIndex("Importe"), true);

            grdPagos.AutosizeAll();

            lblDiferencia.Text = $"Diferencia: {t:C}";
        }

        private void cFecha_Cambio_Seleccion(object sender, System.EventArgs e)
        {
            Cargar();
        }
    }
}
