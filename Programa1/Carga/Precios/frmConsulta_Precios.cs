namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class frmConsulta_Precios : Form
    {
        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmConsulta_Precios()
        {
            InitializeComponent();

            //Cargar Listado de Tipos de Productos
            TipoProductos tipoProductos = new TipoProductos();

            h.Llenar_List(lstTipos, tipoProductos.Datos());
        }

        private void lstTipos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Precios_Sucursales pr = new Precios_Sucursales();
            SqlParameter sqlP = new SqlParameter("Tipo", h.Codigo_Seleccionado(lstTipos.Text));
            DataTable dt = pr.sp_Datos("sp_ConsultaPrecios", sqlP);

            DataColumn dc_DifCosto = new DataColumn("Dif", typeof(float));
            dc_DifCosto.Expression = "Costo-Nuevo_Costo";
            dt.Columns.Add(dc_DifCosto);
            dc_DifCosto.SetOrdinal(6);

            grd.MostrarDatos(dt, true, true);
        }
    }
}
