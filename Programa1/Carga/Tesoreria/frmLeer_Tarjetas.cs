namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using Newtonsoft.Json.Linq;
    using OfficeOpenXml;
    using System;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Text;
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
            h.Llenar_List(lstTitulares, leer.titulares());
            h.Llenar_List(cmbSuc, leer.sucdatos());
            lstTitulares.SelectedIndex = 0;
        }

        private void frmLeer_Tarjetas_Load(object sender, EventArgs e)
        {
            string s = leer.Carpeta_guardada();
            if (s.Length == 0)
            { leer.Actualizar_carpeta(fcarpeta); }
            else
            { fcarpeta = s; }

            cmdCarpeta.Text = fcarpeta;

            Cargar_cuentas();

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
            int f_suc = h.Codigo_Seleccionado(cmbSuc.Text);
            int suc = 0;
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
                            if (leer.vtipo != 12 & leer.vtipo != 13)
                            {
                                // Fiserv Tarjetas

                                for (int i = 2; i <= max; i++)
                                {
                                    leer.vFecha = Convert.ToDateTime(xApp.ActiveSheet.Range("A" + i).Text);
                                    suc = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 5].Text));

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc))
                                    {
                                        DataRow nrow = dt.NewRow();

                                        nrow["Fecha"] = leer.vFecha;
                                        if (xApp.Cells[i, 3].Text.Length > 0)
                                        { nrow["Fecha_Pago"] = xApp.Cells[i, 3].Text; }
                                        else
                                        { nrow["Fecha_Pago"] = leer.vFecha; }

                                        nrow["Comprobante"] = xApp.Cells[i, 4].Text;
                                        nrow["Suc"] = suc;
                                        nrow["Tarjeta"] = Convert.ToInt32(xApp.Cells[i, 6].Text);
                                        nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 8].Text);
                                        nrow["Lote"] = Convert.ToInt32(xApp.Cells[i, 14].Text);
                                        nrow["Id_Tipo"] = leer.vtipo;
                                        nrow["Acreditado"] = true;

                                        dt.Rows.Add(nrow);
                                        pbLeer.Value = i;
                                        Application.DoEvents();
                                    }
                                }
                            }
                            else if (leer.vtipo == 13)
                            {
                                // Nave

                                string suc_temp = "";
                                for (int i = 24; i <= max - 3; i++)
                                {
                                    leer.vFecha = Convert.ToDateTime(xApp.ActiveSheet.Range("A" + i).Text);
                                    leer.vFecha = leer.vFecha.AddHours(leer.vFecha.Hour * -1).AddMinutes(leer.vFecha.Minute * -1);
                                    suc_temp = xApp.Cells[i, 4].Text;
                                    suc = Convert.ToInt32(suc_temp.Substring(suc_temp.IndexOf("SUC") + 4));

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc))
                                    {
                                        DataRow nrow = dt.NewRow();

                                        nrow["Fecha"] = leer.vFecha;
                                        if (xApp.Cells[i, 21].Text == " Por acreditar\n") { nrow["Fecha_Pago"] = leer.vFecha.Date.AddDays(1); }
                                        else { nrow["Fecha_Pago"] = xApp.Cells[i, 2].Text; }

                                        nrow["Comprobante"] = xApp.Cells[i, 3].Text;

                                        nrow["Suc"] = suc;

                                        nrow["Tarjeta"] = 1;

                                        suc_temp = xApp.Cells[i, 10].Text;
                                        nrow["Importe"] = Convert.ToSingle(suc_temp);
                                        //nrow["Importe"] = Convert.ToSingle(suc_temp.Substring(1, suc_temp.Length - 3));
                                        nrow["Lote"] = 1;
                                        nrow["Id_Tipo"] = leer.vtipo;
                                        nrow["Acreditado"] = true;

                                        dt.Rows.Add(nrow);
                                        pbLeer.Value = i;
                                        Application.DoEvents();
                                    }
                                }
                            }
                            else if (leer.vtipo == 12)
                            {
                                // Fiserv CDNI

                                for (int i = 2; i <= max; i++)
                                {
                                    DataRow nrow = dt.NewRow();
                                    leer.vFecha = Convert.ToDateTime(xApp.Cells[i, 2].Text);
                                    suc = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 14].Text));

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & xApp.Cells[i, 8].Text == "Aprobado" & (f_suc == 0 || f_suc == suc))
                                    {
                                        nrow["Fecha"] = leer.vFecha;
                                        nrow["Fecha_Pago"] = leer.vFecha;
                                        nrow["Comprobante"] = xApp.Cells[i, 22].text;
                                        nrow["Suc"] = suc;
                                        nrow["Tarjeta"] = 1;
                                        nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 11].Text);
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
                        else
                        {
                            // QR Fiserv

                            for (int i = 2; i <= max; i++)
                            {
                                leer.vFecha = Convert.ToDateTime(xApp.ActiveSheet.Range("A" + i).Text);
                                suc = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xApp.Cells[i, 2].Text));

                                if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & xApp.Cells[i, 7].Text == "Aprobada" & (f_suc == 0 || f_suc == suc))
                                {
                                    DataRow nrow = dt.NewRow();

                                    nrow["Fecha"] = leer.vFecha;
                                    nrow["Fecha_Pago"] = leer.vFecha;
                                    nrow["Comprobante"] = xApp.Cells[i, 4].Text.Substring(0, 17);
                                    nrow["Suc"] = suc;
                                    nrow["Importe"] = Convert.ToSingle(xApp.Cells[i, 3].Text);
                                    nrow["Id_Tipo"] = leer.vtipo;

                                    nrow["Tarjeta"] = 1;
                                    nrow["Lote"] = 1;
                                    nrow["Acreditado"] = true;

                                    dt.Rows.Add(nrow);
                                    pbLeer.Value = i;
                                    Application.DoEvents();
                                }
                            }
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
                    { Guardar(); }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de tarjeta.");
                }
            }
            Cursor = Cursors.Default;
        }

        private void Guardar()
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
                    leer.Actualizar_Registros();
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
                string t_extencion = "*.csv";
                //Convertir .csv a .xlsx
                foreach (string s in Directory.GetFiles(fcarpeta, t_extencion, SearchOption.TopDirectoryOnly))
                {
                    var lines = File.ReadAllLines(s);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("Sheet1");

                        for (int i = 0; i < lines.Length; i++)
                        {
                            var values = lines[i].Split(';');
                            for (int j = 0; j < values.Length; j++)
                            {
                                worksheet.Cells[i + 1, j + 1].Value = values[j];
                            }
                        }

                        FileInfo excelFile = new FileInfo(s.Replace(".csv", ".xlsx"));
                        excel.SaveAs(excelFile);
                        File.Delete(s);
                    }
                }

                t_extencion = "*.xlsx";
                //Leer los excel
                foreach (string s in Directory.GetFiles(fcarpeta, t_extencion, SearchOption.TopDirectoryOnly))
                {
                    lblArchivo.Text = s;
                    String n = s.Substring(s.LastIndexOf(@"\") + 1);
                    n = n.Substring(0, n.IndexOf("."));

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
                leer.Actualizar_carpeta(fcarpeta);
            }
        }

        private void grdCuentas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
            { grdCuentas.BorrarFila(grdCuentas.Row); }
        }

        private void grdCuentas_Editado(short f, short c, object a)
        {
            string col = grdCuentas.get_Texto(0, c).ToString();

            if (grdCuentas.EsUltimaFila())
            {
                if (c == grdCuentas.get_ColIndex("Suc"))
                { grdCuentas.set_Texto(f, c, a); }
                else if (c == grdCuentas.get_ColIndex("N_Cuenta"))
                {

                }
            }
            else
            {
                switch (col)
                {
                    case "Suc":
                        leer.suc_cuentas.Actualizar("Suc", a);

                        leer.Sucursal.ID = Convert.ToInt32(a);
                        leer.Sucursal.Existe();
                        leer.suc_cuentas.suc = Convert.ToInt32(a);
                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                        break;

                    case "N_Cuenta":
                        grdCuentas.set_Texto(f, c, a);

                        leer.suc_cuentas.Actualizar("N_Cuenta", a);
                        leer.suc_cuentas.N_Cuenta = Convert.ToInt32(a);
                        break;

                    case "Tipo":
                        leer.suc_cuentas.Actualizar("Tipo", a);

                        leer.tipos_tarjeta.ID = Convert.ToInt32(a);
                        leer.suc_cuentas.Tipo = Convert.ToInt32(a);
                        leer.tipos_tarjeta.Existe();

                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Descripcion"), leer.tipos_tarjeta.Nombre);
                        break;

                    case "Titular":
                        grdCuentas.set_Texto(f, c, a);

                        leer.suc_cuentas.Actualizar("Titular", a);
                        leer.suc_cuentas.Titular = a.ToString();
                        break;
                }
                grdCuentas.ActivarCelda(f + 1, c);
            }
        }

        private void grdCuentas_CambioFila(short Fila)
        {
            if (Fila < grdCuentas.Rows - 1)
            {
                leer.suc_cuentas.suc = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Suc")));
                leer.suc_cuentas.N_Cuenta = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("N_Cuenta")));
                leer.suc_cuentas.Tipo = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Tipo")));
                leer.suc_cuentas.Titular = grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Titular")).ToString();
            }
        }

        private void Cargar_cuentas()
        {
            grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, false);
            grdCuentas.AutosizeAll();
            for (int i = 1; i <= grdCuentas.Rows - 1; i++)
            {
                if (leer.suc_cuentas.Cuentas_Compartidas(Convert.ToInt32(grdCuentas.get_Texto(i, 2))) == true)
                {
                    for (int c = 0; c <= grdCuentas.Cols - 1; c++)
                    { grdCuentas.set_ColorLetraCelda(i, c, Color.Red); }
                }
            }
        }

        private void grdCuentas_CambioColumna(int col)
        {
            if (col == 1 | col == 4)
            { grdCuentas.EnableEdicion = false; }
            else { grdCuentas.EnableEdicion = true; }
        }

        private void lstTipo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            { lstTipo.SelectedIndex = -1; }
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            Cargar_cuentas();
        }
        private void cmbSuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuc.SelectedIndex > -1) { lstTitulares.SelectedIndexChanged -= lstTitulares_SelectedIndexChanged; lstTitulares.SelectedIndex = leer.titular(h.Codigo_Seleccionado(cmbSuc.Text)) - 1; lstTitulares.SelectedIndexChanged += lstTitulares_SelectedIndexChanged; }
        }
        private void lstTitulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSuc.SelectedIndexChanged -= cmbSuc_SelectedIndexChanged;
            cmbSuc.SelectedIndex = -1;
            cmbSuc.SelectedIndexChanged += cmbSuc_SelectedIndexChanged;
        }

        private async void cmdMP_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (HttpClient client = new HttpClient())
            {
                string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));

                dt.Rows.Clear();
                string beginDate = dtFecha.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string endDate = dtMaxima.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                int offset = 0;
                int total = 0;
                if (cmbSuc.SelectedIndex > -1) { endDate += $"&pos_id={leer.terminalMP(h.Codigo_Seleccionado(cmbSuc.Text))}"; }

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage response;

                //Esto es porque se hace a veces MP solo envía una parte de las ventas

                for (int i = 0; i < 5; i++)
                {
                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JObject ventas = JObject.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas["paging"];
                        if (total < Convert.ToInt32(paging["total"])) { total = Convert.ToInt32(paging["total"]); }
                    }
                }

                for (int i = 0; offset < total; i++)
                {
                    offset = i * 50;

                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JObject ventas = JObject.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas["paging"];
                        if (total > Convert.ToInt32(paging["total"])) { i += -1; continue; }


                        foreach (var venta in ventas["results"])
                        {
                            DataRow nrow = dt.NewRow();

                            nrow["Comprobante"] = venta["id"]?.ToString();

                            var poi = venta["point_of_interaction"];
                            var device = poi["device"];

                            nrow["Fecha"] = Convert.ToDateTime(venta["date_created"]?.ToString());
                            nrow["Fecha_Pago"] = Convert.ToDateTime(venta["date_created"]?.ToString());
                            nrow["Importe"] = Convert.ToSingle(venta["transaction_amount"]?.ToString().Replace(".", ","));

                            if (device == null)
                            { nrow["Suc"] = 0; }
                            else { nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(device["serial_number"]?.ToString().Substring(8) ?? "N/A")); }

                            nrow["id_Tipo"] = 14;
                            nrow["Tarjeta"] = 1;
                            nrow["Lote"] = 1;

                            dt.Rows.Add(nrow);
                        }
                    }
                    else { i += -1; continue; }
                }
                grdDatos.MostrarDatos(dt, true, false);
                grdDatos.AutosizeAll();
                grdDatos.set_ColW(0, 0);
                double t = grdDatos.SumarCol(grdDatos.get_ColIndex("Importe"), false);
                lblTotal.Text = "Total: " + t.ToString("C1");
                pbLeer.Visible = false;
                lblpb.Visible = false;
                Application.DoEvents();

                Cursor = Cursors.Default;

                if (grdDatos.Rows > 0)
                { Guardar(); }
            }
        }
       
    }
}
