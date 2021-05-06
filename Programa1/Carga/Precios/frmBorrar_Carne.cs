using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmBorrar_Carne : Form
    {
        public frmBorrar_Carne()
        {
            InitializeComponent();
        }

        Precios_Sucursales pr = new Precios_Sucursales();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmBorrar_Carne_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {
            h.Llenar_List(lstSucursales, pr.Sucursal.Datos("Propio=1 AND Ver=1"));
            DataTable dt = pr.Integraciones_Sucursales(true);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstListas.Items.Add($"{dr[0]:dd/MM/yy}   {dr[1]:N3}");

                }
            }
        }

        public void Seleccionar(Single integracion, DateTime fecha)
        {
            this.Cursor = Cursors.WaitCursor;
            
            pr.Fecha = fecha;
            pr.Producto.ID = 1;
            for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
            {
                string suc = lstSucursales.Items[i].ToString();
                pr.Sucursal.Id = h.Codigo_Seleccionado(suc);
                Single precio = pr.Buscar();
                if (Math.Round(precio, 3) == Math.Round(integracion, 3))
                {
                    lstSucursales.SetSelected(i, true);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Single integ = 0; DateTime fecha = DateTime.Today;

            if (lstListas.SelectedIndex != -1)
            {
                foreach (string s in lstListas.SelectedItems)
                {
                    fecha = Convert.ToDateTime(s.Substring(0, 8));
                    integ = Convert.ToSingle(s.Substring(10));
                }                
            }
            else
            {
                lstSucursales.SelectedIndex = -1;
            }
            Seleccionar(integ, fecha);
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (lstListas.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;
                pr.Fecha = Convert.ToDateTime(lstListas.Text.Substring(0, 8));

                if (lstSucursales.SelectedIndex != -1)
                {
                    foreach (string suc in lstSucursales.SelectedItems)
                    {
                        pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                        pr.Borrar_Lista(1);
                    }
                }
                else
                {
                    for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                    {
                        pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                        pr.Borrar_Lista(1);
                    }
                }
                this.Close();
            }
        }
    }
}
