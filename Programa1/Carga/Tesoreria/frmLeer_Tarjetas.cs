namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using System;
    using System.Data;
    using System.Drawing;
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
            //dt = leer.Datos();
        }

        private void frmLeer_Tarjetas_Load(object sender, EventArgs e)
        {
            string s = leer.Carpeta_guardada();
            if (s.Length == 0)
            { leer.actualizar_carpeta(fcarpeta); }
            else
            { fcarpeta = s; }

            cmdCarpeta.Text = fcarpeta;

            cargar_cuentas();

            h.Llenar_List(lstTipo, leer.tipos_tarjeta.Datos_Vista());

            dt = leer.Datos_Vista("Id = 0");
            grdDatos.MostrarDatos(dt, true, false);
            grdDatos.AutosizeAll();
            grdDatos.set_ColW(0, 0);

            grdCuentas.TeclasManejadas = new int[] { 13, 32, 42, 43, 45, 46, 47, 112, 123 };

            dtFecha.Value = DateTime.Today.AddDays((((int)DateTime.Today.DayOfWeek) + 6) * -1);
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
                leer.Sucursal.ID = Convert.ToInt32(n.Substring(0, n.LastIndexOf(".")));
                //leer.Sucursal.ID = Convert.ToInt32(n);
                if (leer.Sucursal.Existe() == true)
                {
                    lblSucursal.Text = leer.Sucursal.Nombre;

                    if (lstTipo.SelectedIndex > -1)
                    { cmdEscribir.PerformClick(); }
                }
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
                cmdRuta.Text = "Guardado: " + n;
                lblArchivo.Text = "";

                if (File.Exists(s)) { }
                try
                {

                    File.Move(s, n);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        private void cmdEscribir_Click(object sender, EventArgs e)
        {
            Escribir();
        }

        private void Escribir(string Tipo = "")
        {
            Cursor = Cursors.WaitCursor;
            tiAuto.Stop();
            lblTotal.Text = "";
            if (lblArchivo.Text.Length > 0)
            {
                if (lstTipo.SelectedIndex > -1 || Tipo.Length > 0)
                {
                    pbLeer.Visible = true;
                    lblpb.Visible = true;

                    String s = lblArchivo.Text;
                    String Suc = s.Substring(s.LastIndexOf(@"\") + 1);

                    Excel.Application xApp = new Excel.Application();
                    Excel.Workbook xLibros = xApp.Workbooks.Open(s);
                    Excel.Workbook xLibro = xApp.ActiveWorkbook;
                    try
                    {

                        xApp.Workbooks.Open(s);
                        xApp.Worksheets.Item[1].activate();

                        leer.vtipo = h.Codigo_Seleccionado(lstTipo.Text);
                        if (Tipo.Length > 0) { leer.vtipo = Convert.ToInt32(Tipo); }

                        lblpb.Text = "Cargando:";

                        int max = xApp.ActiveSheet.Range("A10000").End(Excel.XlDirection.xlUp).Row;
                        pbLeer.Maximum = max;

                        dt.Rows.Clear();
                        if (leer.vtipo != 9)
                        {
                            if (!chclover.Checked)
                            {
                                for (int i = 3; i <= max; i++)
                                {
                                    string nn = xApp.Range["A" + i].Text;

                                    if (nn == "") { break; }

                                    leer.vFecha = Convert.ToDateTime(nn.Substring(0, nn.IndexOf(";")));
                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                    {
                                        DataRow nrow = dt.NewRow();
                                        nrow["Fecha"] = leer.vFecha;


                                        nn = nn.Substring(nn.IndexOf(";") + 1);
                                        nn = nn.Substring(nn.IndexOf(";") + 1);
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Lote"] = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Comprobante"] = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(nn.Substring(0, nn.IndexOf(";"))));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Fecha_Pago"] = Convert.ToDateTime(nn.Substring(0, nn.IndexOf(";")));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Importe"] = Convert.ToSingle(nn.Substring(0, nn.IndexOf(";")).Replace(".", ","));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nn = nn.Substring(nn.LastIndexOf("*") + 1);

                                        nrow["Tarjeta"] = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));

                                        nrow["Id_Tipo"] = leer.vtipo;
                                        nrow["Acreditado"] = true;

                                        dt.Rows.Add(nrow);
                                    }
                                    pbLeer.Value = i;
                                    Application.DoEvents();
                                }
                            }
                            else
                            {
                                if (leer.vtipo != 12)
                                {
                                    for (int i = 2; i <= max; i++)
                                    {
                                        leer.vFecha = Convert.ToDateTime(xApp.ActiveSheet.Range("A" + i).Text);

                                        if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                        {
                                            DataRow nrow = dt.NewRow();
                                            leer.vFecha = Convert.ToDateTime(xApp.Cells[i, 1].Text);

                                            if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                            {
                                                nrow["Fecha"] = leer.vFecha;
                                                nrow["Fecha_Pago"] = xApp.Cells[i, 3].Text;
                                                nrow["Comprobante"] = xApp.Cells[i, 4].Text;
                                                nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 5].Text));
                                                nrow["Tarjeta"] = Convert.ToInt32(xApp.Cells[i, 6].Text);
                                                nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 8].Text);
                                                nrow["Lote"] = Convert.ToInt32(xApp.Cells[i, 14].Text);
                                                nrow["Id_Tipo"] = leer.vtipo;
                                                nrow["Acreditado"] = true;

                                                dt.Rows.Add(nrow);
                                            }
                                            pbLeer.Value = i;
                                            Application.DoEvents();
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 2; i <= max; i++)
                                    {
                                        DataRow nrow = dt.NewRow();
                                        leer.vFecha = Convert.ToDateTime(xApp.Cells[i, 1].Text);

                                        if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & xApp.Cells[i, 7].Text == "Aprobada")
                                        {
                                            nrow["Fecha"] = leer.vFecha;
                                            nrow["Fecha_Pago"] = leer.vFecha;
                                            nrow["Comprobante"] = xApp.Cells[i, 4].Text.Substring(0,17);
                                            nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 2].Text));
                                            nrow["Tarjeta"] = 1;
                                            nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 3].Text);
                                            nrow["Lote"] = 1;
                                            nrow["Id_Tipo"] = leer.vtipo;
                                            nrow["Acreditado"] = true;

                                            dt.Rows.Add(nrow);
                                        }
                                        pbLeer.Value = i;
                                        Application.DoEvents();
                                    }
                                }
                            }
                        }
                        else
                        {
                            //  QR

                            if (chclover.Checked)
                            {
                                for (int i = 2; i <= max; i++)
                                {
                                    leer.vFecha = Convert.ToDateTime(xApp.ActiveSheet.Range("A" + i).Text);

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                    {
                                        DataRow nrow = dt.NewRow();
                                        leer.vFecha = Convert.ToDateTime(xApp.Cells[i, 1].Text);

                                        if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & xApp.Cells[i, 7].Text == "Aprobada")
                                        {
                                            nrow["Fecha"] = leer.vFecha;
                                            nrow["Fecha_Pago"] = leer.vFecha;
                                            nrow["Comprobante"] = xApp.Cells[i, 4].Text.Substring(0, 17);
                                            nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 2].Text));
                                            nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 3].Text);
                                            nrow["Id_Tipo"] = leer.vtipo;

                                            nrow["Tarjeta"] = 1;
                                            nrow["Lote"] = 1;
                                            nrow["Acreditado"] = true;

                                            dt.Rows.Add(nrow);
                                        }
                                        pbLeer.Value = i;
                                        Application.DoEvents();
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 3; i <= max; i++)
                                {
                                    string nn = xApp.Range["A" + i].Text;

                                    if (nn == "") { break; }

                                    leer.vFecha = Convert.ToDateTime(nn.Substring(0, nn.IndexOf(";")));
                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                    {
                                        DataRow nrow = dt.NewRow();

                                        nrow["Fecha"] = leer.vFecha;
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Comprobante"] = Convert.ToInt32(nn.Substring(0, nn.IndexOf(";")));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(nn.Substring(0, nn.IndexOf(";"))));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Importe"] = Convert.ToSingle(nn.Substring(0, nn.IndexOf(";")).Replace(".", ","));
                                        nn = nn.Substring(nn.IndexOf(";") + 1);

                                        nrow["Lote"] = 1;

                                        nrow["Fecha_Pago"] = leer.vFecha;

                                        nrow["Tarjeta"] = 1;

                                        nrow["Id_Tipo"] = leer.vtipo;
                                        nrow["Acreditado"] = true;

                                        dt.Rows.Add(nrow);
                                    }
                                    pbLeer.Value = i;
                                    Application.DoEvents();
                                }

                                //max = xApp.ActiveSheet.Range("D10000").End(Excel.XlDirection.xlUp).Row;

                                //pbLeer.Maximum = max;

                                //Suc = Suc.Substring(0, Suc.LastIndexOf("."));

                                //int ini = xApp.ActiveSheet.Range("G1").End(Excel.XlDirection.xlDown).Row;
                                //ini++;

                                //for (int i = ini; i <= max; i++)
                                //{
                                //    pbLeer.Value = i;
                                //    Application.DoEvents();

                                //    DataRow nrow = dt.NewRow();

                                //    if (xApp.Cells[i, 1].Text == "Total")
                                //    {
                                //        i = max;
                                //        break;
                                //    }
                                //    else
                                //    {
                                //        leer.vFecha = Convert.ToDateTime(xApp.Cells[i, 1].Text);

                                //        if (xApp.Cells[i, 8].Text == "Confirmado")
                                //        {
                                //            if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value)
                                //            {
                                //                nrow["Fecha"] = leer.vFecha;
                                //                nrow["Fecha_Pago"] = leer.vFecha;
                                //                nrow["Comprobante"] = xApp.Cells[i, 3].Text;
                                //                nrow["Suc"] = Convert.ToInt32(Suc);
                                //                string n = xApp.Cells[i, 7].Text;
                                //                long nt = 0;
                                //                long.TryParse(n, out nt);

                                //                nrow["Tarjeta"] = nt;

                                //                n = xApp.Cells[i, 4].Text;
                                //                n = n.Replace("$", "");
                                //                nrow["Importe"] = Convert.ToSingle(n);
                                //                nrow["Lote"] = 0;
                                //                nrow["Id_Tipo"] = 9;
                                //                nrow["Acreditado"] = true;

                                //                dt.Rows.Add(nrow);
                                //            }
                                //        }
                                //    }
                                //}
                            }

                            // Solución para saber Cual es el Último registro de la semana anterior:
                            // 1: Buscar si hay más de un número de lote
                            // 2: Buscar si uno de esos Números es 1
                            // 3: Siempre sería el Último a no ser que el otro Número sea 2 (en ese caso tomar desde el 2)
                            // Aclaración: Esto Podría fallar únicamente en caso de que el Número de lote sea 2 y ese mismo día se resetee el Número de lote (Toda caso distinto a ese estaría bien)
                            //if (chSeparar.Checked == true)
                            //{
                            //    DataTable dtcc = leer.suc_cuentas.nccc(leer.Sucursal.ID);
                            //    int[] succcc = new int[leer.suc_cuentas.N_Cuentas_Compartidas(leer.Sucursal.ID)];
                            //    for (int i = 0; i < succcc.Length; i++)
                            //    {
                            //        succcc[i] = Convert.ToInt32(dtcc.Rows[i][0]);
                            //    }

                            //    for (int j = 0; j < succcc.Length; j ++)
                            //    {
                            //        if (succcc[j] != leer.Sucursal.ID)
                            //        {
                            //            DateTime fecha_us = dtFecha.Value.AddDays(-1);
                            //            int Lote_us
                            //            int Comprobante_us

                            //            for (int i = 1; i < dt.Rows.Count; i++)
                            //            {
                            //                if (dt.Rows[i][lote])
                            //                {

                            //                    dt.Rows[i]["suc"] = succcc[j]
                            //                }
                            //            }
                            //        }
                            //    }
                        }

                        grdDatos.MostrarDatos(dt, true, false);
                        grdDatos.AutosizeAll();
                        grdDatos.set_ColW(0, 0);
                        double t = grdDatos.SumarCol(grdDatos.get_ColIndex("Importe"), false);
                        lblTotal.Text = "Total: " + t.ToString("C1");
                        pbLeer.Visible = false;
                        lblpb.Visible = false;
                    }
                    catch (Exception er)
                    {
                        lblTotal.Text = er.Message;
                    }
                    finally
                    {
                        xApp.Quit();
                        xLibro = null;
                        xLibros = null;
                        xApp = null;

                        GC.Collect();
                    }

                    Application.DoEvents();
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
            if (leer.Fecha_Cerrada(dtFecha.Value) == false & leer.Fecha_Cerrada(dtMaxima.Value) == false)
            {
                lblpb.Visible = true;
                pbLeer.Visible = true;

                lblpb.Text = "Guardando";
                pbLeer.Maximum = grdDatos.Rows - 1;

                for (int i = 1; i <= grdDatos.Rows - 1; i++)
                {
                    leer.vFecha = Convert.ToDateTime(grdDatos.get_Texto(i, 1));
                    leer.vtipo = Convert.ToInt32(grdDatos.get_Texto(i, 2));
                    leer.vimporte = Convert.ToSingle(grdDatos.get_Texto(i, 3));
                    leer.Sucursal.ID = Convert.ToInt32(grdDatos.get_Texto(i, 5));
                    leer.vpago = Convert.ToDateTime(grdDatos.get_Texto(i, 6));
                    leer.vlote = Convert.ToInt32(grdDatos.get_Texto(i, 7));
                    leer.vcomprobante = Convert.ToInt64(grdDatos.get_Texto(i, 8));
                    leer.vtarjeta = Convert.ToInt64(grdDatos.get_Texto(i, 9));
                    leer.actualizar_Registros();
                    pbLeer.Value = i;
                }
                grdDatos.Rows = 1;

                lblpb.Visible = false;
                pbLeer.Visible = false;

                lblSucursal.Text = $"{grdDatos.get_Texto(1, grdDatos.get_ColIndex("Suc"))}  -  {grdDatos.get_Texto(1, grdDatos.get_ColIndex("Id_Tipo"))}";
                lblTotal.Text = "";
                Mover_Archivo();
                if (chAuto.Checked == true)
                {
                    tiAuto.Start();
                }
                Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("La fecha se encuentra cerrada", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tiAuto_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(fcarpeta))
            {
                string t_extencion;
                if (chclover.Checked)
                { t_extencion = "*.xlsx"; }
                else { t_extencion = "*.csv"; }

                foreach (string s in Directory.GetFiles(fcarpeta, t_extencion, SearchOption.TopDirectoryOnly))
                {
                    lblArchivo.Text = s;
                    String n = s.Substring(s.LastIndexOf(@"\") + 1);
                    n = n.Substring(0, n.IndexOf("."));

                    //leer.Sucursal.ID = Convert.ToInt32(n.Substring(0, n.LastIndexOf(" ")));
                    //lblSucursal.Text = leer.Sucursal.Nombre;
                    Escribir(n);
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
            { grdCuentas.BorrarFila(grdCuentas.Row); }
        }

        private void grdCuentas_Editado(short f, short c, object a)
        {
            if (Convert.ToBoolean(grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Carga"))) == true)
            { grdCuentas.BorrarFila(grdCuentas.Row); }
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            cargar_cuentas();
        }

        private void cargar_cuentas()
        {
            grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, false);
            grdCuentas.AutosizeAll();
            for (int i = 1; i <= grdCuentas.Rows - 1; i++)
            {
                if (leer.suc_cuentas.Cuentas_Compartidas(Convert.ToInt32(grdCuentas.get_Texto(i, 1))) == true)
                {
                    for (int c = 0; c <= grdCuentas.Cols - 1; c++)
                    { grdCuentas.set_ColorLetraCelda(i, c, Color.Red); }
                }
            }
        }

        private void lstTipo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            { lstTipo.SelectedIndex = -1; }
        }
    }
}
