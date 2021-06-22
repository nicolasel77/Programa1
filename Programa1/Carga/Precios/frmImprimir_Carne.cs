using Programa1.DB;
using Programa1.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Programa1.Carga.Precios
{
    public partial class frmImprimir_Carne : Form
    {
        public frmImprimir_Carne()
        {
            InitializeComponent();
        }

        Precios_Sucursales pr = new Precios_Sucursales();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmImprimir_Carne_Load(object sender, EventArgs e)
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
            if (lstListas.SelectedIndex != -1)
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
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSucursales.SelectedIndex = -1;

            Single integ = 0; DateTime fecha = DateTime.Today;
            if (lstListas.SelectedIndex != -1)
            {
                foreach (string s in lstListas.SelectedItems)
                {
                    fecha = Convert.ToDateTime(s.Substring(0, 8));
                    integ = Convert.ToSingle(s.Substring(10));
                    Seleccionar(integ, fecha);
                }
            }

        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppContext.BaseDirectory + "\\Imprimir_Precios.xlsm");
            // Ejecutar la macro
            // Imprimir_Carne(ByVal Suc As Integer, ByVal Fecha As Date, ByVal Imp_Integracion As Boolean)
            
            if (!chUltima.Checked)
            {
                if (lstListas.SelectedIndex > -1)
                {
                    foreach (string s in lstListas.SelectedItems)
                    {
                        pr.Fecha = Convert.ToDateTime(s.Substring(0, 8));
                        if (lstSucursales.SelectedIndex != -1)
                        {
                            foreach (string suc in lstSucursales.SelectedItems)
                            {
                                pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                                xlApp.Run("Imprimir_Carne", pr.Sucursal.ID, pr.Fecha, chIntegracion.Checked, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                            {
                                pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                                xlApp.Run("Imprimir_Carne", pr.Sucursal.ID, pr.Fecha, chIntegracion.Checked, false);
                            }
                        }
                    }
                }
            }
            else
            {
                pr.Fecha =mntFecha.SelectionStart.Date;

                if (lstSucursales.SelectedIndex != -1)
                {
                    foreach (string suc in lstSucursales.SelectedItems)
                    {
                        pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                        xlApp.Run("Imprimir_Carne", pr.Sucursal.ID, pr.Fecha, chIntegracion.Checked, true);
                    }
                }
                else
                {
                    for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                    {
                        pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                        xlApp.Run("Imprimir_Carne", pr.Sucursal.ID, pr.Fecha, chIntegracion.Checked, true);
                    }
                }
            }
            xlApp.Run("Fin");
            xlWorkbook.Close(false);
            xlApp = null;
            this.Close();

        }

        private void chUltima_CheckedChanged(object sender, EventArgs e)
        {
            mntFecha.Enabled = chUltima.Checked;
        }
    }
}
