namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using Decidir;
    using Decidir.Constants;
    using Decidir.Model;
    using OfficeOpenXml;
    using System;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using ClosedXML.Excel;

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

        /// <summary>
        /// Lee el archivo Excel seleccionado según el tipo de tarjeta/proveedor,
        /// extrae las transacciones dentro del rango de fechas y sucursal filtradas,
        /// y las carga en la grilla para su posterior guardado.
        /// </summary>
        /// <param name="Tipo">Identificador opcional del tipo de tarjeta a procesar.</param>
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

                    Excel.Application xApp = null;
                    Excel.Workbook xLibro = null;
                    Excel.Worksheet xHoja = null;

                    try
                    {
                        // Inicialización y apertura del archivo Excel
                        xApp = new Excel.Application();
                        xLibro = xApp.Workbooks.Open(s);
                        xHoja = (Excel.Worksheet)xLibro.Worksheets[1];
                        xHoja.Activate();

                        leer.vtipo = h.Codigo_Seleccionado(lstTipo.Text);
                        if (Tipo.Length > 0) { leer.vtipo = Convert.ToInt32(Tipo); }

                        lblpb.Text = "Cargando:";

                        // Obtener la última fila con datos
                        int max = xHoja.Range["A10000"].End[Excel.XlDirection.xlUp].Row;
                        max = xHoja.Range["A10000"].SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                        pbLeer.Maximum = max;

                        dt.Rows.Clear();

                        if (leer.vtipo != 9)
                        {
                            if (leer.vtipo == 16)
                            {
                                // --- Payway DÉBITO ---
                                for (int i = 2; i <= max; i++)
                                {
                                    try
                                    {
                                        leer.vFecha = Convert.ToDateTime(xHoja.Range["B" + i].Text);
                                        suc = leer.suc_cuentas.buscar_suc(xHoja.Cells[i, 9].Text);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc) & xHoja.Cells[i, 6].Text == "ACREDITADO")
                                    {
                                        DataRow nrow = dt.NewRow();

                                        nrow["Fecha"] = leer.vFecha;
                                        nrow["Fecha_Pago"] = leer.vFecha;
                                        nrow["Comprobante"] = 0; //xHoja.Cells[i, 5].Text;
                                        nrow["Suc"] = suc;
                                        //nrow["Tarjeta"] = Convert.ToInt32(xHoja.Cells[i, 6].Text);
                                        nrow["Importe"] = Convert.ToSingle(xHoja.Cells[i, 12].Text);
                                        //nrow["Lote"] = Convert.ToInt32(xHoja.Cells[i, 4].Text);
                                        nrow["Id_Tipo"] = leer.vtipo;
                                        nrow["Acreditado"] = true;

                                        dt.Rows.Add(nrow);
                                        pbLeer.Value = i;
                                        Application.DoEvents();
                                    }
                                }
                            }
                            else if (leer.vtipo == 15)
                            {
                                // --- Payway Transferencia ---
                                for (int i = 2; i <= max; i++)
                                {
                                    try
                                    {
                                        leer.vFecha = Convert.ToDateTime(xHoja.Range["B" + i].Text);
                                        suc = leer.suc_cuentas.buscar_suc(xHoja.Cells[i, 9].Text);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc) & xHoja.Cells[i, 6].Text == "ACREDITADO")
                                    {
                                        DataRow nrow = dt.NewRow();
                                        try
                                        {
                                            nrow["Fecha"] = leer.vFecha;
                                            nrow["Fecha_Pago"] = leer.vFecha;
                                            nrow["Comprobante"] = 0; // xHoja.Cells[i, 2].Text;
                                            nrow["Suc"] = suc;
                                            nrow["Importe"] = Convert.ToSingle(xHoja.Cells[i, 12].Text);
                                            //if (!string.IsNullOrEmpty(xHoja.Cells[i, 5].Text))
                                            //{
                                            //    nrow["Lote"] = Convert.ToInt32(xHoja.Cells[i, 5].Text);
                                            //}
                                            nrow["Id_Tipo"] = leer.vtipo;

                                            nrow["Acreditado"] = true;

                                            dt.Rows.Add(nrow);
                                            pbLeer.Value = i;
                                        }
                                        catch (Exception er)
                                        {
                                            Console.WriteLine(er.Message);
                                        }
                                        Application.DoEvents();
                                    }
                                }
                            }
                            else if (leer.vtipo != 12 & leer.vtipo != 13)
                            {
                                // --- Fiserv (Tarjetas tradicionales) ---
                                for (int i = 2; i <= max; i++)
                                {
                                    leer.vFecha = Convert.ToDateTime(xHoja.Range["A" + i].Text);
                                    suc = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xHoja.Cells[i, 5].Text));

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc))
                                    {
                                        DataRow nrow = dt.NewRow();

                                        nrow["Fecha"] = leer.vFecha;
                                        if (xHoja.Cells[i, 3].Text.Length > 0)
                                        { nrow["Fecha_Pago"] = xHoja.Cells[i, 3].Text; }
                                        else
                                        { nrow["Fecha_Pago"] = leer.vFecha; }

                                        nrow["Comprobante"] = 0; // xHoja.Cells[i, 4].Text;
                                        nrow["Suc"] = suc;
                                        nrow["Tarjeta"] = Convert.ToInt32(xHoja.Cells[i, 6].Text);
                                        nrow["Importe"] = Convert.ToSingle(xHoja.Cells[i, 8].Text);
                                        nrow["Lote"] = Convert.ToInt32(xHoja.Cells[i, 14].Text);
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
                                // --- Nave (Banco Galicia) ---
                                string suc_temp = "";
                                for (int i = 24; i <= max - 1; i++)
                                {
                                // Comprobar que la celda tenga una fecha válida antes de convertirla
                                if(!DateTime.TryParse(xHoja.Range["A" + i].Text, out DateTime fecha))
                                {
                                    MessageBox.Show("El valor de fecha no es válido: " + xHoja.Range["A" + i].Text, "Problema al leer", MessageBoxButtons.OK);
                                    continue;
                                }
                                leer.vFecha = fecha;
                                    leer.vFecha = leer.vFecha.AddHours(leer.vFecha.Hour * -1).AddMinutes(leer.vFecha.Minute * -1);

                                    suc_temp = xHoja.Cells[i, 4].Text;
                                    try
                                    {
                                        // Extrae el número de sucursal después del texto "SUC"
                                        suc = Convert.ToInt32(suc_temp.Substring(suc_temp.IndexOf("SUC") + 4));
                                    }
                                    catch
                                    {
                                        MessageBox.Show("No se pudo obtener la sucursal de: " + suc_temp, "Problema al leer", MessageBoxButtons.OK);
                                        break;
                                    }

                                    if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & (f_suc == 0 || f_suc == suc))
                                    {
                                        try
                                        {
                                            DataRow nrow = dt.NewRow();

                                            // Chequear que sea una fecha válida antes de asignarla a la columna "Fecha"
                                            if (!DateTime.TryParse(xHoja.Cells[i, 2].Text, out fecha))
                                            {
                                                MessageBox.Show("El valor de fecha no es válido: " + xHoja.Cells[i, 2].Text, "Problema al leer", MessageBoxButtons.OK);
                                                continue;
                                            }
                                            nrow["Fecha"] = fecha;
                                            if (xHoja.Cells[i, 21].Text == " Por acreditar\n") { nrow["Fecha_Pago"] = fecha.Date.AddDays(1); }
                                            else { nrow["Fecha_Pago"] = fecha; }

                                            nrow["Comprobante"] = 0; // xHoja.Cells[i, 3].Text;
                                            nrow["Suc"] = suc;
                                            nrow["Tarjeta"] = 1;

                                            suc_temp = xHoja.Cells[i, 10].Text;
                                            // Chequear que suc_temp sea un número válido antes de convertirlo a float
                                            if (!float.TryParse(suc_temp, out float importe))
                                            {
                                                MessageBox.Show("El valor de importe no es válido: " + suc_temp, "Problema al leer", MessageBoxButtons.OK);
                                                continue;
                                            }
                                            nrow["Importe"] = importe;
                                            //nrow["Importe"] = Convert.ToSingle(suc_temp.Substring(1, suc_temp.Length - 3));
                                            nrow["Lote"] = 1;
                                            nrow["Id_Tipo"] = leer.vtipo;
                                            nrow["Acreditado"] = true;

                                            dt.Rows.Add(nrow);
                                            pbLeer.Value = i;
                                            Application.DoEvents();
                                        }
                                        catch (Exception er)
                                        {
                                            MessageBox.Show(er.Message);
                                        }
                                    }
                                }
                            }
                            else if (leer.vtipo == 12)
                            {
                                // --- Fiserv CDNI ---
                                DateTime ffin = dtMaxima.Value.AddDays(1);
                                string comprobante_temp;
                                for (int i = 2; i <= max; i++)
                                {
                                    DataRow nrow = dt.NewRow();
                                    leer.vFecha = Convert.ToDateTime(xHoja.Cells[i, 2].Text);
                                    suc = leer.suc_cuentas.buscar_suc(xHoja.Cells[i, 15].Text);

                                    try
                                    {
                                        if (leer.vFecha >= dtFecha.Value & leer.vFecha < ffin & xHoja.Cells[i, 9].Text == "Aprobado" & (f_suc == 0 || f_suc == suc))
                                        {
                                            nrow["Fecha"] = leer.vFecha;
                                            nrow["Fecha_Pago"] = leer.vFecha;
                                            comprobante_temp = xHoja.Cells[i, 1].Text;
                                            nrow["Comprobante"] = comprobante_temp.Substring(comprobante_temp.Length - 8, 8);
                                            nrow["Suc"] = suc;
                                            nrow["Tarjeta"] = 1;
                                            nrow["Importe"] = Convert.ToSingle(xHoja.Cells[i, 12].Text);
                                            if (!string.IsNullOrEmpty(xHoja.Cells[i, 24].Text))
                                            {
                                                nrow["Lote"] = Convert.ToInt32(xHoja.Cells[i, 24].Text);
                                            }
                                            else
                                            {
                                                nrow["Lote"] = 0;
                                            }
                                            nrow["Id_Tipo"] = leer.vtipo;
                                            nrow["Acreditado"] = true;

                                            dt.Rows.Add(nrow);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                    pbLeer.Value = i;
                                    Application.DoEvents();
                                }
                            }
                        }
                        else
                        {
                            // --- QR Fiserv (vtipo == 9) ---
                            for (int i = 2; i <= max; i++)
                            {
                                leer.vFecha = Convert.ToDateTime(xHoja.Range["A" + i].Text);
                                suc = leer.suc_cuentas.buscar_suc(Convert.ToInt32(xHoja.Cells[i, 2].Text));

                                if (leer.vFecha >= dtFecha.Value & leer.vFecha <= dtMaxima.Value & xHoja.Cells[i, 7].Text == "Aprobada" & (f_suc == 0 || f_suc == suc))
                                {
                                    DataRow nrow = dt.NewRow();

                                    nrow["Fecha"] = leer.vFecha;
                                    nrow["Fecha_Pago"] = leer.vFecha;
                                    nrow["Comprobante"] = xHoja.Cells[i, 4].Text.Substring(0, 17);
                                    nrow["Suc"] = suc;
                                    nrow["Importe"] = Convert.ToSingle(xHoja.Cells[i, 3].Text);
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

                        // Mostrar datos en la grilla y calcular totales
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
                        // Liberación explícita de los objetos COM de Excel para evitar procesos huérfanos
                        if (xLibro != null)
                        {
                            xLibro.Close(false);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xLibro);
                            xLibro = null;
                        }
                        if (xHoja != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xHoja);
                            xHoja = null;
                        }
                        if (xApp != null)
                        {
                            xApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xApp);
                            xApp = null;
                        }

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
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
                double total = 0;
                try
                {
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
                        total += leer.vimporte;
                        pbLeer.Value = i;
                    }
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
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
                    var lines = File.ReadAllLines(s, Encoding.UTF8);

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sheet1");

                        for (int i = 0; i < lines.Length; i++)
                        {
                            var values = lines[i].Split(';');
                            for (int j = 0; j < values.Length; j++)
                            {
                                // Si es numero, guardarlo como numero
                                // Primero borrar puntos y reemplazar coma por punto para que lo reconozca como numero
                                if (!string.IsNullOrEmpty(values[j]))
                                {
                                    values[j] = values[j].Replace(".", ",");
                                }

                                if (double.TryParse(values[j], out double number))
                                {
                                    worksheet.Cell(i + 1, j + 1).Value = number;
                                }
                                else
                                {
                                    worksheet.Cell(i + 1, j + 1).Value = values[j];
                                }
                            }
                        }
                        // Autoajustar el ancho de las columnas
                        worksheet.Columns().AdjustToContents();

                        string rutaExcel = Path.ChangeExtension(s, ".xlsx");
                        workbook.SaveAs(rutaExcel);
                    }

                    File.Delete(s);
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
            if (rdCuentas.Checked)
            {
                if (grdCuentas.EsUltimaFila())
                {
                    if (c == grdCuentas.get_ColIndex("Suc"))
                    {
                        leer.Sucursal.ID = Convert.ToInt32(a);
                        leer.Sucursal.Existe();
                        leer.suc_cuentas.suc = Convert.ToInt32(a);
                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                        grdCuentas.ActivarCelda(f, grdCuentas.get_ColIndex("N_Cuenta"));
                    }
                    else if (c == grdCuentas.get_ColIndex("N_Cuenta"))
                    {
                        if (grdCuentas.get_Texto(f, 0).ToString() != "0")
                        {
                            grdCuentas.set_Texto(f, c, a);
                            leer.suc_cuentas.Agregar();
                        }
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
                            leer.suc_cuentas.N_Cuenta = a.ToString();
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
                }
            }
            else
            {
                if (col == "Suc")
                {
                    if (a.ToString() != "0")
                    {
                        leer.Sucursal.ID = Convert.ToInt32(a);
                        leer.Sucursal.Existe();
                        leer.suc_cuentas.suc = Convert.ToInt32(a);
                        leer.suc_cuentas.Titular = h.Nombre_Seleccionado(lstTitulares.Text);
                        leer.suc_cuentas.N_Cuenta = grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Terminal_Ticket")).ToString();

                        if (grdCuentas.get_Texto(f, c).ToString() == "0")
                        { leer.suc_cuentas.Agregar_terminalesMP(grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Id_Terminal"))); }
                        else { leer.suc_cuentas.Actualizar_terminalesMP(a, grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Id_Terminal"))); }


                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                    }
                }
            }
            grdCuentas.ActivarCelda(f + 1, c);
        }

        private void grdCuentas_CambioFila(short Fila)
        {
            if (Fila < grdCuentas.Rows - 1)
            {
                leer.suc_cuentas.suc = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Suc")));
                leer.suc_cuentas.N_Cuenta = grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("N_Cuenta")).ToString();
                leer.suc_cuentas.Tipo = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Tipo")));
                leer.suc_cuentas.Titular = grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Titular")).ToString();
            }
        }

        private async void Cargar_cuentas()
        {
            if (rdCuentas.Checked)
            {
                lblCuentas.Text = "Cuentas";
                grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, true);
                grdCuentas.AutosizeAll();
                for (int i = 1; i <= grdCuentas.Rows - 1; i++)
                {
                    if (leer.suc_cuentas.Cuentas_Compartidas(grdCuentas.get_Texto(i, 2).ToString()) == true)
                    {
                        for (int c = 0; c <= grdCuentas.Cols - 1; c++)
                        { grdCuentas.set_ColorLetraCelda(i, c, Color.Red); }
                    }
                }
            }
            else
            {
                lblCuentas.Text = "Terminales MP de " + lstTitulares.Text.Substring(lstTitulares.Text.IndexOf(".") + 1);
                Cursor = Cursors.WaitCursor;
                using (HttpClient client = new HttpClient())
                {
                    string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));
                    dt = leer.suc_cuentas.Id_TerminalesMP();
                    dt.Rows.Clear();

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                    HttpResponseMessage response;


                    response = await client.GetAsync($"https://api.mercadopago.com/point/integration-api/devices?offset=0&limit=50");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        foreach (var venta in ventas.RootElement.GetProperty("devices").EnumerateArray())
                        {
                            if (venta.GetProperty("pos_id").ToString().Length > 2)
                            {
                                DataRow nrow = dt.NewRow();

                                //nrow["Posnet_id"] = Convert.ToInt32(venta["pos_id"]?.ToString());
                                nrow["Id_Terminal"] = venta.GetProperty("pos_id").ToString();

                                leer.Sucursal.ID = leer.suc_cuentas.buscar_terminalMP(Convert.ToInt32(venta.GetProperty("pos_id").ToString()));

                                nrow["Suc"] = leer.Sucursal.ID;
                                nrow["Nombre"] = leer.suc_cuentas.buscar_nombreterminalMP(leer.Sucursal.ID);

                                nrow["Terminal_Ticket"] = venta.GetProperty("id").ToString().Substring((int)venta.GetProperty("id").ToString().IndexOf("POS") + 3);

                                dt.Rows.Add(nrow);
                            }
                        }
                    }
                    else { MessageBox.Show("No se pudieron cargar las terminales.", default, MessageBoxButtons.OK); }

                    grdCuentas.MostrarDatos(dt, true, false);
                    grdCuentas.AutosizeAll();
                    grdCuentas.Ordenar(0);

                    dt = leer.Datos_Vista("Id = 0");

                    Application.DoEvents();

                    Cursor = Cursors.Default;
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

            if (!rdCuentas.Checked) { Cargar_cuentas(); }
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
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total < Convert.ToInt32(paging.GetProperty("total").ToString())) { total = Convert.ToInt32(paging.GetProperty("total").ToString()); }
                    }
                }

                for (int i = 0; offset < total; i++)
                {
                    offset = i * 50;

                    try
                    {
                        response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total > Convert.ToInt32(paging.GetProperty("total").ToString())) { i += -1; continue; }


                        foreach (var venta in ventas.RootElement.GetProperty("results").EnumerateArray())
                        {
                            DataRow nrow = dt.NewRow();

                            nrow["Comprobante"] = venta.GetProperty("id").ToString();

                            var poi = venta.GetProperty("point_of_interaction");
                            //var device;// = poi.GetProperty("device");
                            // ver si existe la propiedad device antes de intentar acceder a ella

                            // C#
                            JsonElement device = default;
                            bool hasDevice = poi.ValueKind == JsonValueKind.Object && poi.TryGetProperty("device", out device);
                            //bool hasDevice = poi.TryGetProperty("device", out var device);

                            nrow["Fecha"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Fecha_Pago"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Importe"] = Convert.ToSingle(venta.GetProperty("transaction_amount").ToString().Replace(".", ","));

                            if (!hasDevice || device.ValueKind == JsonValueKind.Null)
                            {
                                // Buscar la palabra SMARTPOS en responseData
                                if (responseData.Contains("SMARTPOS"))
                                {
                                    int indexStart = responseData.IndexOf("SMARTPOS");
                                    if (indexStart < 0)
                                    {
                                        nrow["Suc"] = 0;
                                    }
                                    else
                                    {
                                        string sucursal = responseData.Substring(indexStart + 8, 10);
                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(sucursal);
                                    }
                                }
                                else
                                {
                                    nrow["Suc"] = 0;
                                }
                            }
                            else
                            {
                                string termial = device.GetProperty("serial_number").ToString();
                                if (termial.StartsWith("SMART"))
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                                else
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                            }

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

        private void rdTerminalesMP_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_cuentas();
        }

        private async void cmdExcel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (HttpClient client = new HttpClient())
            {
                string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));

                dt.Rows.Clear();
                // Chequear que no este ya agregada al columna
                if (!dt.Columns.Contains("Datos_Adicionales"))
                {
                    // Agregar una columna tipo texto a dt para los datos restantes
                    DataColumn col = new DataColumn();
                    col.ColumnName = "Datos_Adicionales";
                    col.DataType = typeof(string);
                    col.DefaultValue = "";
                    dt.Columns.Add(col);
                }
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
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total < Convert.ToInt32(paging.GetProperty("total"))) { total = Convert.ToInt32(paging.GetProperty("total")); }
                    }
                }

                for (int i = 0; offset < total; i++)
                {
                    offset = i * 50;

                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total > Convert.ToInt32(paging.GetProperty("total"))) { i += -1; continue; }


                        foreach (var venta in ventas.RootElement.GetProperty("results").EnumerateArray())
                        {
                            DataRow nrow = dt.NewRow();

                            nrow["Comprobante"] = venta.GetProperty("id").ToString();

                            var poi = venta.GetProperty("point_of_interaction");
                            var device = poi.GetProperty("device");

                            bool hasDevice = poi.TryGetProperty("device", out device);

                            nrow["Fecha"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Fecha_Pago"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Importe"] = Convert.ToSingle(venta.GetProperty("transaction_amount").ToString().Replace(".", ","));
                            nrow["Datos_Adicionales"] = $"";
                            //nrow["Datos_Adicionales"] = $"Collector Id: {venta["collector_id"]} - Tipo de pago: {venta["payment_type_id"]?.ToString()} - Detalles: {venta["description"]?.ToString()}";

                            if (!hasDevice || device.ValueKind == JsonValueKind.Null)
                            {
                                // Buscar la palabra SMARTPOS en responseData
                                if (responseData.Contains("SMARTPOS"))
                                {
                                    int indexStart = responseData.IndexOf("SMARTPOS");
                                    if (indexStart < 0)
                                    {
                                        nrow["Suc"] = 0;
                                    }
                                    else
                                    {
                                        string sucursal = responseData.Substring(indexStart + 8, 10);
                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(sucursal);
                                    }
                                }
                                else
                                {
                                    nrow["Suc"] = 0;
                                }
                            }
                            else
                            {
                                string termial = device.GetProperty("serial_number").ToString();
                                if (termial.StartsWith("SMART"))
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                                else
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                            }

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string privateApiKey = "019dab64-4dd8-7015-8b69-5bc9a96a8b4b";
            string publicApiKey = "019dab64-4df1-7347-97c5-678060742afd";

            privateApiKey = "92b71cf711ca41f78362a7134f87ff65";
            publicApiKey = "e9cdb99fff374b5f91da4480c8dca741";

            //Para el ambiente de desarrollo
            DecidirConnector decidir = new DecidirConnector(Ambiente.AMBIENTE_SANDBOX, privateApiKey, publicApiKey);

            GetAllPaymentsResponse pagos = decidir.GetAllPayments(null, null, dtFecha.Value, dtMaxima.Value);

            //Mostrar los pagos en la grilla
            foreach (PaymentResponse pago in pagos.results)
            {
                DataRow nrow = dt.NewRow();
                nrow["Comprobante"] = pago.id;
                nrow["Fecha"] = Convert.ToDateTime(pago.date);
                nrow["Importe"] = Convert.ToSingle(pago.amount);
                dt.Rows.Add(nrow);
            }
            grdDatos.MostrarDatos(dt, true, false);
        }
    }
}
