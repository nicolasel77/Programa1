namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using System;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class frmLeer_Tarjetas : Form
    {
        private Leer_Tarjetas leer;
        private Herramientas.Herramientas h = new Herramientas.Herramientas();
        string fcarpeta = @"E:\Tarjetas";
        DataTable dt = null;
        public frmLeer_Tarjetas()
        {
            InitializeComponent();
            leer = new Leer_Tarjetas();
            dt = leer.Datos();
        }

        private void frmLeer_Tarjetas_Load(object sender, EventArgs e)
        {
            string s = leer.Carpeta_guardada();
            if (s.Length == 0)
            { leer.actualizar_carpeta(fcarpeta); }
            else
            { fcarpeta = s; }

            cmdCarpeta.Text = "Carpeta: " + fcarpeta;

            grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, false);
            grdCuentas.AutosizeAll();
            h.Llenar_List(lstTipo, leer.tipos_tarjeta.Datos_Vista());

            dt = leer.Datos_Vista("Id = 0");
            grdDatos.MostrarDatos(dt, true, false);
            grdDatos.AutosizeAll();
            grdDatos.set_ColW(0, 0);

            grdCuentas.TeclasManejadas = new int[] { 13, 32, 42, 43, 45, 46, 47, 112, 123 };

            dtFecha.Value = DateTime.Today.AddDays(( ((int)DateTime.Today.DayOfWeek) + 6) * -1);
            dtMaxima.Value = dtFecha.Value.AddDays(6);
        }

        private void chAuto_CheckedChanged(object sender, EventArgs e)
        {
            tiAuto.Enabled = chAuto.Checked;
        }

        private void cmdCargar_archivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();

            f.InitialDirectory = fcarpeta;
            f.ShowDialog();
            string s = f.FileName;

            if (s.Length > 0)
            {
                lblArchivo.Text = s;
                string n = s.Substring(s.LastIndexOf(@"\") + 1);
                leer.Sucursal.ID = Convert.ToInt32(n.Substring(0, n.LastIndexOf(" ")));
                lblSucursal.Text = leer.Sucursal.Nombre;

                if (lstTipo.SelectedIndex > -1)
                { cmdEscribir.PerformClick(); }
            }
        }

        private void Mover_Archivo()
        {
            String s = lblArchivo.Text;
            String n = s.Substring(s.LastIndexOf(@"\") + 1);
            int i = 1;
            n = fcarpeta + @"\Back\" + n;

            if (n.LastIndexOf(".") > -1)
            {
                String ex = n.Substring(n.LastIndexOf("."));
                while (File.Exists(n))
                {
                    n = n.Substring(0, n.LastIndexOf("."));
                    n += i + ex;
                    i += 1;
                }
                cmdGuardar.Text = "Guardado: " + n;
                lblArchivo.Text = "";

                if (File.Exists(s)) { }
                File.Move(s, n);
            }
        }

        private void cmdEscribir_Click(object sender, EventArgs e)
        {
            Escribir();
        }

        private void Escribir(string Tipo = "")
        {
            Cursor = Cursors.WaitCursor;

            lblTotal.Text = "";
            if (lblArchivo.Text.Length > 0)
            {
                if (lstTipo.SelectedIndex > -1 || Tipo.Length > 0)
                {
                    String s = lblArchivo.Text;
                    String Suc = s.Substring(s.LastIndexOf(@"\") + 1);
                    Suc = Suc.Substring(0, Suc.LastIndexOf(" "));

                    Excel.Application xApp = new Excel.Application();
                    Excel.Workbook xLibros = xApp.Workbooks.Open(s);
                    Excel.Workbook xLibro = xApp.ActiveWorkbook;

                    xApp.Workbooks.Open(s);
                    xApp.Worksheets.Item[1].activate();

                    leer.vtipo = h.Codigo_Seleccionado(lstTipo.Text);
                    if (Tipo.Length > 0) { leer.vtipo = Convert.ToInt32(Tipo); }

                    dt.Rows.Clear();
                    for (int i = 2; i <= 500000; i++)
                    {
                        string nn = xApp.Range["A" + i].Text;

                        if (nn == "") { break; }

                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        leer.vlote = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        leer.vpago = Convert.ToDateTime(nn.Substring(0, nn.IndexOf(";")));
                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        nn = nn.Substring(nn.IndexOf(";") + 1);


                        leer.vFecha = Convert.ToDateTime(nn.Substring(0, nn.IndexOf(";")));
                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        leer.vcomprobante = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        leer.vtarjeta = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        nn = nn.Substring(nn.IndexOf(";") + 1);

                        leer.vimporte = Convert.ToSingle(nn.Replace(".", ","));

                        if (leer.vtarjeta > 0)
                        {
                            DataRow nrow = dt.NewRow();
                            nrow["Fecha"] = leer.vFecha;
                            nrow["Lote"] = leer.vlote;
                            nrow["Fecha_Pago"] = leer.vpago;
                            nrow["Importe"] = leer.vimporte;
                            nrow["Comprobante"] = leer.vcomprobante;
                            nrow["Tarjeta"] = leer.vtarjeta;
                            nrow["Id_Tipo"] = leer.vtipo;
                            nrow["Suc"] = leer.Sucursal.ID;
                            nrow["Acreditado"] = true;
                            dt.Rows.Add(nrow);
                        }
                    }
                    grdDatos.MostrarDatos(dt, true, false);
                    grdDatos.AutosizeAll();
                    grdDatos.set_ColW(0, 0);
                    double t = grdDatos.SumarCol(grdDatos.get_ColIndex("Importe"), false);
                    lblTotal.Text = "Total: " + t.ToString("C1");

                    xApp.Quit();
                    xLibro = null;
                    xLibros = null;
                    xApp = null;

                    //Application.DoEvents()
                    if (chAuto.Checked == true)
                    { cmdGuardar.PerformClick(); }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de tarjeta.");
                }
            }
            Cursor = Cursors.Default;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= grdDatos.Rows - 1; i++)
            {
                leer.vFecha = Convert.ToDateTime(grdDatos.get_Texto(i, 1));
                leer.vtipo = Convert.ToInt32(grdDatos.get_Texto(i, 2));
                leer.vimporte = Convert.ToSingle(grdDatos.get_Texto(i, 3));
                leer.Sucursal.ID = Convert.ToInt32(grdDatos.get_Texto(i, 5));
                leer.vpago = Convert.ToDateTime(grdDatos.get_Texto(i, 6));
                leer.vlote = Convert.ToInt32(grdDatos.get_Texto(i, 7));
                leer.vcomprobante = Convert.ToInt32(grdDatos.get_Texto(i, 8));
                leer.vtarjeta = Convert.ToInt32(grdDatos.get_Texto(i, 9));
                leer.actualizar_Registros();
            }
            grdDatos.Rows = 1;

            lblSucursal.Text = $"{ grdDatos.get_Texto(1, grdDatos.get_ColIndex("Suc"))}  -  { grdDatos.get_Texto(1, grdDatos.get_ColIndex("Id_Tipo"))}";
            lblTotal.Text = "";
            Mover_Archivo();

            Cursor = Cursors.Default;
        }

        private void tiAuto_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(fcarpeta))
            {
                foreach (string s in Directory.GetFiles(fcarpeta, "*.csv", SearchOption.TopDirectoryOnly))
                {
                    lblArchivo.Text = s;
                    String n = s.Substring(s.LastIndexOf(@"\") + 1);
                    String t = s.Substring(s.LastIndexOf(" ") + 1);
                    t = t.Substring(0, t.IndexOf("."));

                    leer.Sucursal.ID = Convert.ToInt32(n.Substring(0, n.LastIndexOf(" ")));
                    lblSucursal.Text = leer.Sucursal.Nombre;
                    Escribir(t);
                }
            }
        }

        private void cmdCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fc = new FolderBrowserDialog();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                fcarpeta = fc.SelectedPath;
                cmdCarpeta.Text = "Carpeta: " + fcarpeta;
                leer.actualizar_carpeta(fcarpeta);
            }
        }

        private void grdCuentas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
            {grdCuentas.BorrarFila(grdCuentas.Row);}
        }

        private void grdCuentas_Editado(short f, short c, object a)
        {
            if (Convert.ToBoolean(grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Carga"))) == true)
            {grdCuentas.BorrarFila(grdCuentas.Row);}
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, false);
            grdCuentas.AutosizeAll();
        }
    }
}
