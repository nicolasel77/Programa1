using Programa1.DB;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Programa1.Carga.Precios
{
    public partial class frmImprimir_MenEmb : Form
    {
        public frmImprimir_MenEmb()
        {
            InitializeComponent();
        }
        public int Tipo;
        Precios_Sucursales pr = new Precios_Sucursales();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmImprimir_MenEmb_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        public void Cargar()
        {            
            h.Llenar_List(lstSucursales, pr.Sucursal.Datos("Propio=1 AND Ver=1"));
            DataTable dt = pr.Fechas(Tipo);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstListas.Items.Add($"{dr[0]:dd/MM/yy}");
                }
            }
        }
        
      
        private void cmdImprimir_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppContext.BaseDirectory + "\\Imprimir_MenEmb.xlsm");
            // Ejecutar la macro
            // Imprimir(ByVal Suc As Integer, ByVal Fecha As Date, ByVal Tipo As Integer, ByVal Ultima_Lista As Boolean)

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
                                pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                                xlApp.Run("Imprimir", pr.Sucursal.Id, pr.Fecha, Tipo, false);
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                            {
                                pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                                xlApp.Run("Imprimir", pr.Sucursal.Id, pr.Fecha, Tipo, false);
                            }
                        }
                    }
                }
            }
            else
            {
                pr.Fecha = mntFecha.SelectionStart.Date;

                if (lstSucursales.SelectedIndex != -1)
                {
                    foreach (string suc in lstSucursales.SelectedItems)
                    {
                        pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                        xlApp.Run("Imprimir", pr.Sucursal.Id, pr.Fecha, Tipo, true);
                    }
                }
                else
                {
                    for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                    {
                        pr.Sucursal.Id = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                        xlApp.Run("Imprimir", pr.Sucursal.Id, pr.Fecha, Tipo, true);
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

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            mntFecha.SetDate(Convert.ToDateTime(lstListas.Text));
        }
    }
}
