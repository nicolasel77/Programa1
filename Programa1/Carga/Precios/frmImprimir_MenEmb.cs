using Programa1.DB;
using System;
using System.Data;
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
                                // Se agrega el pollo (Tipo 6) porque sino no entra en la seleccion
                                if (Tipo == 4) { xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, 6, false, false, nuCant.Value); }
                                xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, Tipo, false, true, nuCant.Value);
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                            {
                                pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                                // Se agrega el pollo (Tipo 6) porque sino no entra en la seleccion
                                if (Tipo == 4) { xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, 6, false, false, nuCant.Value); }
                                xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, Tipo, false, true, nuCant.Value);
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
                        pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(suc));
                        // Se agrega el pollo (Tipo 6) porque sino no entra en la seleccion
                        if (Tipo == 4) { xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, 6, false, false, nuCant.Value); }
                        xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, Tipo, true, true, nuCant.Value);
                    }
                }
                else
                {
                    for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                    {
                        pr.Sucursal.ID = Convert.ToInt32(h.Codigo_Seleccionado(lstSucursales.Items[i].ToString()));
                        // Se agrega el pollo (Tipo 6) porque sino no entra en la seleccion
                        if (Tipo == 4) { xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, 6, false, false, nuCant.Value); }
                        xlApp.Run("Imprimir", pr.Sucursal.ID, pr.Fecha, Tipo, true, true, nuCant.Value);
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

        private void lblTodas_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
            {
                lstSucursales.SetSelected(i, true);
            }
        }

        private void lblNinguna_Click(object sender, EventArgs e)
        {
            lstSucursales.SelectedIndex = -1;
        }
    }
}
