using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Proveedores
{
    public partial class frmPrecios_Proveedores : Form
    {
        Precios_Proveedores Precios = new Precios_Proveedores();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmPrecios_Proveedores()
        {
            InitializeComponent();
        }

       
        private void Cargar()
        {
            grd.Rows = 1;
            if (lstFechas.SelectedIndex >= 0)
            {
                string f = $"Fecha='{Convert.ToDateTime(lstFechas.Text):MM/dd/yy}'";
                f = h.Unir(f, cProveedores1.Cadena("ID_Proveedores"));
                grd.MostrarDatos(Precios.Datos(f), true, true);
            }
            else
            {
                grd.Rows = 2;
            }
            grd.AutosizeAll();
            grd.set_ColW(0, 0);
            grd.set_ColW(grd.get_ColIndex("ID_Tipo"), 0);
            
        }

        private void cProveedores1_Cambio_Seleccion(object sender, EventArgs e)
        {
            lstFechas.Items.Clear();
            Precios.Proveedor.Id = cProveedores1.Valor_Actual;
            DataTable dt = Precios.Fechas();
            foreach(DataRow dr in dt.Rows)
            {
                lstFechas.Items.Add(dr[0]);
            }
            Cargar();
            
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
