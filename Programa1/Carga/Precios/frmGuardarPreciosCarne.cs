using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmGuardarPreciosCarne : Form
    {
        public frmGuardarPreciosCarne()
        {
            InitializeComponent();
        }
        Precios_Sucursales pr = new Precios_Sucursales();
        Herramientas.Herramientas h = new Herramientas.Herramientas();
        public bool Guardar = false;
       

        public void Cargar()
        {
            h.Llenar_List(lstSucursales, pr.Sucursal.Datos("Propio=1 AND Ver=1"));
            DataTable dt = pr.Integraciones_Sucursales(true);

            if (dt != null)
            {
                lstListas.Items.Add("...Todas...");
                foreach (DataRow dr in dt.Rows)
                {
                    lstListas.Items.Add($"{dr[0]:dd/MM/yy}   {dr[1]:N3}");

                }
            }
        }

        public void Seleccionar(Single integracion, DateTime fecha)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lstListas.SelectedIndex == 0)
            {
                lstSucursales.SelectedIndex = -1;
            }
            else
            {
                pr.Fecha = fecha;
                pr.Producto.ID = 1;
                for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                {
                    string suc = lstSucursales.Items[i].ToString();
                    pr.Sucursal.ID = h.Codigo_Seleccionado(suc);
                    Single precio = pr.Buscar();
                    if (Math.Round(precio, 3) == Math.Round(integracion, 3))
                    {
                        lstSucursales.SetSelected(i, true);
                    }
                    else
                    {
                        lstSucursales.SetSelected(i, false);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Single integ = 0; DateTime fecha = DateTime.Today;
            if (lstListas.SelectedIndex != 0)
            {
                fecha = Convert.ToDateTime(lstListas.Text.Substring(0, 8));
                integ = Convert.ToSingle(lstListas.Text.Substring(10));
            }
            Seleccionar(integ, fecha);
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar = true;
            if (lstSucursales.SelectedIndex == -1 )
            {
                for (int i = 0; i <= lstSucursales.Items.Count-1; i++)
                {
                    lstSucursales.SetSelected(i, true);
                }
            }
            this.Hide();
        }
    }
}
