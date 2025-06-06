﻿namespace Programa1.Carga.Tesoreria
{
    using Newtonsoft.Json.Linq;
    using Programa1.Clases;
    using Programa1.Controles;
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    using static System.ComponentModel.Design.ObjectSelectorEditor;

    public partial class frmImportar_Excel : Form
    {
        public frmImportar_Excel()
        {
            InitializeComponent();

            grdSalida.TeclasManejadas = new int[] { 13, 42, 43, 45, 46, 47, 106, 111, 112, 120 };

        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionar_archivo = new OpenFileDialog();
            seleccionar_archivo.Filter = "Todos los archivos (*.*)|*.*|All files (*.*)|*.*";
            seleccionar_archivo.Title = "Seleccionar el archivo";

            if (seleccionar_archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = seleccionar_archivo.FileName;
                cmdSeleccionar.Text = fileName;
                if (fileName.ToLower().Contains("molleda") == true)
                {
                    cmbTipo.SelectedIndex = 0;
                }
                if (fileName.ToLower().Contains("alonso") == true)
                {
                    cmbTipo.SelectedIndex = 2;
                }
            }
        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Cargar_Datos()
        {
            if (cmdSeleccionar.Text != "Seleccionar archivo")
            {
                grd.Rows = 0;
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                try
                {
                    if (File.Exists(cmdSeleccionar.Text) == true)
                    {
                        switch (cmbTipo.SelectedIndex)
                        {
                            case 0:
                                if (cmdSeleccionar.Text.EndsWith(".csv") == true)
                                {

                                    Cargar_CSVMolleda(cmdSeleccionar.Text);
                                }
                                else
                                {
                                    Molleda_Galicia();
                                }
                                break;
                            case 1:
                                Molleda_Provincia();
                                break;
                            case 2:
                                Alonso_BBVA();
                                break;
                            case 3:
                                Cargar_txtMeat(cmdSeleccionar.Text);
                                break;
                        }
                    }
                }
                catch (Exception er)
                {
                    lblContador.Text = "Hubo un error en la lectura de datos.";
                }
                this.Enabled = true;
                this.Cursor = Cursors.Default;

            }
        }

        #region " Molleda Provincia "
        private void Molleda_Provincia()
        {
            //Abrir el archivo excel
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(cmdSeleccionar.Text, false, true);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            xlApp.DisplayAlerts = false;

            //Cargar los datos
            int rowCount = xlRange.Rows.Count;
            int colCount = 5;

            grd.Rows = 1;
            grd.Cols = colCount;

            grd.FixRows = 1;
            int colOffset = 0;

            grd.set_Texto(0, 0, "Fecha");
            grd.set_Texto(0, 1, "Concepto");
            grd.set_Texto(0, 2, "Debe");
            grd.set_Texto(0, 3, "Haber");
            grd.set_Texto(0, 4, "Saldo");

            grd.Columnas[0].DataType = typeof(DateTime);
            grd.Columnas[2].DataType = typeof(double);
            grd.Columnas[3].DataType = typeof(double);
            grd.Columnas[4].DataType = typeof(double);

            grd.Columnas[0].Style.Format = "dd/MM/yy";
            grd.Columnas[2].Style.Format = "N2";
            grd.Columnas[3].Style.Format = "N2";
            grd.Columnas[4].Style.Format = "N2";

            for (int i = 8; i <= rowCount; i++)
            {
                grd.Rows++;
                int fila = i - 7;
                //Fecha
                var nn = xlRange.Cells[i, 1 + colOffset].value;
                if (nn != null)
                {
                    DateTime f;

                    string s = $"{nn}";

                    if (DateTime.TryParse(s, out f) == false)
                    {
                        break;
                    }
                    grd.set_Texto(fila, 0, f);
                }
                //Concepto
                grd.set_Texto(fila, 1, xlRange.Cells[i, 2 + colOffset].Value2);

                Double vimporte = Convert.ToDouble(xlRange.Cells[i, 3 + colOffset].Value2);
                if (vimporte > 0)
                {
                    //Credito                    
                    grd.set_Texto(fila, 3, vimporte);
                }
                else
                {
                    //Debito
                    grd.set_Texto(fila, 2, vimporte * -1);
                }

                //Saldo
                grd.set_Texto(fila, 4, xlRange.Cells[i, 4 + colOffset].Value2);

                lblContador.Text = $"Cargando {i - 1} de {rowCount} filas.";
                Application.DoEvents();

            }
            grd.AutosizeAll();

            lblContador.Text = $"{rowCount} filas leídas.";

            Generar_Creditos_Provincia();
            Generar_Debitos_Provincia();

            lblContador.Text = $"{rowCount} filas cargadas.";

            xlWorkbook.Close();
            xlApp.Quit();

            //Liberar
            GC.Collect();
        }
        private void Generar_Creditos_Provincia()
        {
            if (chCreditos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 0;

                lblContador.Text = $"{lblContador.Text} Generando Creditos...";
                Application.DoEvents();

                //Primero los Créditos
                for (int i = 1; i < grd.Rows; i++)
                {
                    try
                    {
                        double importe = Convert.ToDouble(grd.get_Texto(i, 3));
                        if (importe != 0)
                        {
                            nop = ++nop;
                            DateTime fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                            string descripcion = grd.get_Texto(i, 1).ToString();
                            int cfin = descripcion.IndexOf("CDNI");
                            if (cfin != -1) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion.Substring(0, cfin + 4)}', {importe.ToString().Replace(",", ".")})"); }
                            else
                            {
                                cfin = descripcion.IndexOf("VISA");
                                if (cfin != -1) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion.Substring(0, cfin + 4)}', {importe.ToString().Replace(",", ".")})"); }

                                else
                                {
                                    cfin = descripcion.IndexOf("MASTERCARD");
                                    if (cfin != -1) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion.Substring(0, cfin + 10)}', {importe.ToString().Replace(",", ".")})"); }

                                    else
                                    {
                                        cfin = 10;
                                        if (cfin != -1) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion.Substring(0, cfin)}', {importe.ToString().Replace(",", ".")})"); }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        lblContador.Text = er.Message;
                    }

                }
                grdSalida.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, 19 IDC, 'Molleda - B. Provincia' Caja, 13 Tipo, 'Entradas Provincia' Nombre, 203 SubTipo, Descripcion, SUM(Credito) Importe" +
                    " FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 7);

                grdSalida.Columnas[7].Format = "N2";

                grdSalida.AutosizeAll();
            }

        }
        private void Generar_Debitos_Provincia()
        {
            if (chDebitos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 100000;
                DateTime fecha = DateTime.Today;
                string descripcion = "";
                double importe = 0;

                lblContador.Text = $"{lblContador.Text} Generando Debitos...";
                Application.DoEvents();


                for (int i = 1; i < grd.Rows; i++)
                {
                    importe = Convert.ToDouble(grd.get_Texto(i, 2));
                    if (grd.get_Texto(i, 1) != null)
                    {
                        descripcion = grd.get_Texto(i, 1).ToString();
                    }

                    bool nono = false;

                    if (Convert.ToDouble(grd.get_Texto(i, 3)) > 0)
                    {
                        if (nop > 0) { nop = nop * -1; }
                    }

                    if (importe != 0)
                    {
                        if (nop < 0) { nop = nop * -1; }

                        nop = ++nop;
                        fecha = Convert.ToDateTime(grd.get_Texto(i, 0));
                    }
                    else
                    {
                        if (nop > 0)
                        {
                            _Base.Ejecutar_Comando($"UPDATE Temp_n SET Descripcion=CONVERT(VARCHAR, (SELECT Top 1 Descripcion FROM Temp_n WHERE ID={nop})) + ' {descripcion}'  WHERE ID={nop}");
                            nono = true;
                        }
                    }

                    if (nop > 0 && nono == false) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Debito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})"); }

                }

                grdDebitos.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Debito) Importe FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 2);
                grdDebitos.Columnas[2].Format = "N2";
                grdDebitos.AutosizeAll();

            }
        }

        #endregion

        #region " Provincia Meat "

        private void Cargar_txtMeat(string seleccionar_archivo)
        {
            //Leer un archivo txt
            string[] lines = File.ReadAllLines(seleccionar_archivo);

            grd.Rows = lines.Count();
            grd.FixRows = 0;

            grd.Cols = 16;

            //Fecha
            grd.Columnas[4].DataType = typeof(DateTime);
            grd.Columnas[6].DataType = typeof(DateTime);
            //importe
            grd.Columnas[5].DataType = typeof(double);
            //Saldo
            grd.Columnas[7].DataType = typeof(double);

            grd.Columnas[4].Style.Format = "dd/MM/yy";
            grd.Columnas[6].Style.Format = "dd/MM/yy";
            grd.Columnas[5].Style.Format = "N2";
            grd.Columnas[7].Style.Format = "N2";



            int f = 0;
            foreach (string linea in lines)
            {
                lblContador.Text = $"Cargando {f + 1} de {lines.Count()} filas.";
                Application.DoEvents();

                int c = 0;
                int n = linea.IndexOf(";");
                string nlinea = linea;

                do
                {
                    string nTexto = nlinea.Substring(0, n);
                    grd.set_Texto(f, c, nTexto);

                    nlinea = nlinea.Remove(0, n + 1);
                    n = nlinea.IndexOf(";");

                    c++;
                } while (n != -1);

                f++;
            }
            grd.AutosizeAll();

            lblContador.Text = $"{lines.Count()} filas leídas.";
            Application.DoEvents();

            Generar_Creditos_Meat();
            Generar_Debitos_Meat();

        }

        private void Generar_Debitos_Meat()
        {
            if (chDebitos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                DateTime fecha = DateTime.Today;
                string descripcion = "";
                double importe = 0;

                lblContador.Text = $"{lblContador.Text} Generando Debitos...";
                Application.DoEvents();


                for (int i = 0; i <= grd.Rows; i++)
                {
                    importe = Convert.ToDouble(grd.get_Texto(i, 5));
                    if (importe < 0)
                    {
                        if (grd.get_Texto(i, 9) != null)
                        {
                            descripcion = grd.get_Texto(i, 9).ToString();
                        }

                        _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Debito) VALUES('{fecha:MM/dd/yyy}', 0, '{descripcion}', {importe.ToString().Replace(",", ".")})");
                    }
                }

                grdDebitos.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Debito) Importe FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 2);
                grdDebitos.Columnas[2].Format = "N2";
                grdDebitos.AutosizeAll();

            }
            lblContador.Text = "Listo.";
        }


        private void Generar_Creditos_Meat()
        {
            if (chCreditos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 0;

                lblContador.Text = $"{lblContador.Text} Generando Creditos...";
                Application.DoEvents();

                //Primero los Créditos
                for (int i = 0; i <= grd.Rows; i++)
                {
                    try
                    {
                        double importe = Convert.ToDouble(grd.get_Texto(i, 5));
                        if (importe > 0)
                        {
                            nop = ++nop;
                            DateTime fecha = Convert.ToDateTime(grd.get_Texto(i, 4));
                            string descripcion = grd.get_Texto(i, 9).ToString();

                            _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})");
                        }
                    }
                    catch (Exception er)
                    {
                        lblContador.Text = er.Message;
                    }

                }

                grdSalida.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Credito) Importe" +
                    ", 17 IDC, 'Meat Provincia' Caja, 14 Tipo, '' Nombre, 0 SubTipo, '' Desc_ST " +
                    "FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion, IDC, Caja, Tipo, Nombre, SubTipo, Desc_ST"), true, 2);
                grdSalida.Columnas[2].Format = "N2";


                grdSalida.AutosizeAll();
            }

        }



        #endregion

        #region  " Molleda Galicia "
        private void Cargar_CSVMolleda(string seleccionar_archivo)
        {
            //Leer un archivo CSV
            string[] lines = File.ReadAllLines(seleccionar_archivo);

            grd.Rows = lines.Count();
            grd.FixRows = 1;

            grd.Cols = 16;

            grd.Columnas[0].DataType = typeof(DateTime);
            grd.Columnas[3].DataType = typeof(double);
            grd.Columnas[4].DataType = typeof(double);
            grd.Columnas[5].DataType = typeof(double);

            grd.Columnas[0].Style.Format = "dd/MM/yy";
            grd.Columnas[3].Style.Format = "N2";
            grd.Columnas[4].Style.Format = "N2";
            grd.Columnas[5].Style.Format = "N2";


            int f = 0;
            foreach (string linea in lines)
            {
                lblContador.Text = $"Cargando {f + 1} de {lines.Count()} filas.";
                Application.DoEvents();

                int c = 0;
                int n = linea.IndexOf(";");
                string nlinea = linea;

                do
                {
                    string nTexto = nlinea.Substring(0, n);
                    grd.set_Texto(f, c, nTexto);

                    nlinea = nlinea.Remove(0, n + 1);
                    n = nlinea.IndexOf(";");

                    c++;
                } while (n != -1);

                if (f > 0)
                {
                    if (Convert.ToDateTime(grd.get_Texto(f, 0)).Year < 2020)
                    {
                        grd.set_Texto(f, 0, null);
                    }
                }

                f++;
            }
            grd.AutosizeAll();

            lblContador.Text = $"{lines.Count()} filas leídas.";
            Application.DoEvents();

            Generar_Creditos();
            Generar_Debitos();

        }
        private void Molleda_Galicia()
        {
            //Abrir el archivo excel            
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(cmdSeleccionar.Text, false, true);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            xlApp.DisplayAlerts = false;

            //Cargar los datos
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            grd.Rows = 0;
            grd.Rows = rowCount;
            grd.Cols = colCount;

            grd.FixRows = 1;
            for (int j = 1; j <= colCount; j++)
            {
                grd.set_Texto(0, j - 1, Convert.ToString(xlRange.Cells[1, j].Value2));
                grd.Columnas[j - 1].Name = Convert.ToString(xlRange.Cells[1, j].Value2);
            }

            try
            {
                grd.Columnas[0].DataType = typeof(DateTime);
                grd.Columnas[3].DataType = typeof(double);
                grd.Columnas[4].DataType = typeof(double);
                grd.Columnas[5].DataType = typeof(double);

                grd.Columnas[0].Style.Format = "dd/MM/yy";
                grd.Columnas[3].Style.Format = "N2";
                grd.Columnas[4].Style.Format = "N2";
                grd.Columnas[5].Style.Format = "N2";

                for (int i = 2; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        if (j > 1)
                        {
                            grd.set_Texto(i - 1, j - 1, xlRange.Cells[i, j].Value2);
                        }
                        else
                        {
                            string nn = Convert.ToString(xlRange.Cells[i, j].Value2);
                            if (nn != null)
                            {
                                DateTime f;

                                if (nn.All(char.IsNumber) == true)
                                {
                                    f = DateTime.FromOADate(xlRange.Cells[i, j].Value2);
                                }
                                else
                                {
                                    f = DateTime.Parse(nn);
                                }
                                grd.set_Texto(i - 1, j - 1, f);
                            }
                        }

                        lblContador.Text = $"Cargando {i - 1} de {rowCount} filas.";
                        Application.DoEvents();
                    }
                }
                grd.AutosizeAll();

                lblContador.Text = $"{rowCount} filas leídas.";
                Application.DoEvents();

                Generar_Creditos();
                Generar_Debitos();
            }
            catch (Exception er)
            {
                lblContador.Text = er.Message;
            }
            finally
            {
                xlWorkbook.Close();
                xlApp.Quit();

                //Liberar
                GC.Collect();
            }
        }

        private void Generar_Creditos()
        {
            if (chCreditos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nOperacion = 0;
                DateTime fecha = DateTime.Today;
                string descripcion = "";
                double importe = 0;

                lblContador.Text = $"{lblContador.Text} Generando Creditos...";
                Application.DoEvents();

                //Primero los Créditos
                for (int i = 1; i < grd.Rows; i++)
                {
                    try
                    {
                        //si hay importe en credito
                        importe = Convert.ToDouble(grd.get_Texto(i, 4));

                        descripcion = String.Format(txtFormato.Text, grd.get_Texto(i, 1).ToString(), grd.get_Texto(i, 2).ToString(), grd.get_Texto(i, 3).ToString(), grd.get_Texto(i, 4).ToString(), grd.get_Texto(i, 5).ToString(), grd.get_Texto(i, 6).ToString(), grd.get_Texto(i, 7).ToString(), grd.get_Texto(i, 8).ToString(), grd.get_Texto(i, 9).ToString(), grd.get_Texto(i, 10).ToString());

                        //descripcion = String.Format(txtFormato.Text, grd.get_Texto(i, 1).ToString());
                        if (grd.get_Texto(i, 1) != null)
                        {
                            if (descripcion.ToLower().StartsWith("transferencia pei"))
                            {
                                descripcion = "Transferencia QR";
                            }
                        }

                        if (importe != 0)
                        {
                            ++nOperacion;
                            fecha = Convert.ToDateTime(grd.get_Texto(i, 0));
                            _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nOperacion}, '{descripcion}', {importe.ToString().Replace(",", ".")})");
                        }

                    }
                    catch (Exception er)
                    {
                        lblContador.Text = er.Message;
                    }

                }

                grdSalida.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Credito) Importe" +
                    ", 4 IDC, 'CCte Molleda' Caja, 14 Tipo, '' Nombre, 0 SubTipo, '' Desc_ST " +
                    "FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion, IDC, Caja, Tipo, Nombre, SubTipo, Desc_ST"), true, 2);
                grdSalida.Columnas[2].Format = "N2";

                string buscar = "est.:";
                for (int i = 1; i < grdSalida.Rows - 1; i++)
                {
                    string entrada = "";
                    if (grdSalida.get_Texto(i, 1) != null) { entrada = grdSalida.get_Texto(i, 1).ToString(); }
                    int indess = entrada.ToLower().IndexOf(buscar);

                    if (indess > -1)
                    {
                        //Leemos el establecimiento
                        int esst = Convert.ToInt32(entrada.Substring(indess + buscar.Length));

                        //Buscamos que sucursal es
                        int codSuc = Convert.ToInt32(_Base.Dato_Generico($"SELECT TOP 1 ISNULL(Suc, 1000) FROM dbGastos.dbo.Suc_Cuentas WHERE N_Cuenta = {esst} ORDER BY Suc"));

                        //Ahora buscamos que tipo de tarjeta es (visa, master, etc)
                        string tipo_Tarjeta = Convert.ToString(_Base.Dato_Generico($"SELECT TOP 1 ISNULL(Nombre, 'Tarjeta') FROM dbGastos.dbo.Tipo_Cuentas WHERE ID = " +
                            $"(SELECT TOP 1 ISNULL(Tipo, 0) FROM dbGastos.dbo.Suc_Cuentas WHERE N_Cuenta = {esst} ORDER BY Suc)"));

                        object nomSuc = _Base.Dato_Generico($"SELECT ISNULL(Nombre, 'Empresa') FROM Sucursales WHERE ID ={codSuc}");

                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("Desc_ST"), $"{nomSuc} {tipo_Tarjeta.Trim()} EST: {esst}");

                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("SubTipo"), codSuc);
                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("Nombre"), "Acreditacion Prisma");
                    }
                }
                grdSalida.AutosizeAll();
            }
        }

        private void Generar_Debitos()
        {
            if (chDebitos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 100000;
                DateTime fecha = DateTime.Today;
                string descripcion = "";
                double importe = 0;

                lblContador.Text = $"{lblContador.Text} Generando Debitos...";
                Application.DoEvents();


                for (int i = 1; i < grd.Rows; i++)
                {
                    importe = Convert.ToDouble(grd.get_Texto(i, 3));
                    if (grd.get_Texto(i, 1) != null)
                    {
                        descripcion = grd.get_Texto(i, 1).ToString();
                    }

                    bool nono = false;

                    if (Convert.ToDouble(grd.get_Texto(i, 4)) > 0)
                    {
                        if (nop > 0) { nop = nop * -1; }
                    }

                    if (importe != 0)
                    {
                        if (nop < 0) { nop = nop * -1; }

                        nop = ++nop;
                        fecha = Convert.ToDateTime(grd.get_Texto(i, 0));
                    }
                    else
                    {
                        if (nop > 0)
                        {
                            _Base.Ejecutar_Comando($"UPDATE Temp_n SET Descripcion=CONVERT(VARCHAR, (SELECT Top 1 Descripcion FROM Temp_n WHERE ID={nop})) + ' {descripcion}'  WHERE ID={nop}");
                            nono = true;
                        }
                    }

                    if (nop > 0 && nono == false) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Debito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})"); }

                }

                grdDebitos.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Debito) Importe FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 2);
                grdDebitos.Columnas[2].Format = "N2";
                grdDebitos.AutosizeAll();

            }
            lblContador.Text = "Listo.";
        }
        #endregion

        #region  " Alonso BBVA "
        private void Alonso_BBVA()
        {
            //Abrir el archivo excel
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(cmdSeleccionar.Text, false, true);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            xlApp.DisplayAlerts = false;

            //Cargar los datos
            int rowCount = xlRange.Rows.Count;
            int colCount = 6;

            grd.Rows = 0;
            grd.Rows = rowCount - 2;
            grd.Cols = colCount;

            grd.FixRows = 1;

            grd.set_Texto(0, 0, "Fecha");
            grd.set_Texto(0, 1, "Concepto");
            grd.set_Texto(0, 2, "Suc");
            grd.set_Texto(0, 3, "Debe");
            grd.set_Texto(0, 4, "Haber");
            grd.set_Texto(0, 5, "Saldo");

            grd.Columnas[0].DataType = typeof(DateTime);
            grd.Columnas[3].DataType = typeof(double);
            grd.Columnas[4].DataType = typeof(double);
            grd.Columnas[5].DataType = typeof(double);

            grd.Columnas[0].Style.Format = "dd/MM/yy";
            grd.Columnas[3].Style.Format = "N2";
            grd.Columnas[4].Style.Format = "N2";
            grd.Columnas[5].Style.Format = "N2";

            for (int i = 4; i <= rowCount; i++)
            {
                //Fecha
                var nn = xlRange.Cells[i, 1].Value2;
                if (nn != null)
                {
                    DateTime f = DateTime.Parse(nn);
                    grd.set_Texto(i - 3, 0, f);
                }
                //Concepto/Suc
                grd.set_Texto(i - 3, 1, xlRange.Cells[i, 2].Value2);
                grd.set_Texto(i - 3, 2, xlRange.Cells[i, 3].Value2);

                Double vimporte = Convert.ToDouble(xlRange.Cells[i, 4].Value2);
                if (vimporte > 0)
                {
                    //Credito                    
                    grd.set_Texto(i - 3, 4, vimporte);
                }
                else
                {
                    //Debito
                    grd.set_Texto(i - 3, 3, vimporte * -1);
                }

                //Saldo
                grd.set_Texto(i - 3, 5, xlRange.Cells[i, 5].Value2);

                lblContador.Text = $"Cargando {i - 1} de {rowCount} filas.";
                Application.DoEvents();

            }
            grd.AutosizeAll();

            lblContador.Text = $"{rowCount} filas leídas.";

            Generar_Creditos_ABBVA();
            Generar_Debitos_ABBVA();


            xlWorkbook.Close();
            xlApp.Quit();

            //Liberar
            GC.Collect();
        }

        private void Generar_Creditos_ABBVA()
        {
            if (chCreditos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 0;

                lblContador.Text = $"{lblContador.Text} Generando Creditos...";
                Application.DoEvents();

                //Primero los Créditos
                for (int i = 1; i < grd.Rows; i++)
                {
                    try
                    {
                        double importe = Convert.ToDouble(grd.get_Texto(i, 4));
                        if (importe != 0)
                        {
                            nop = ++nop;
                            DateTime fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                            string descripcion = grd.get_Texto(i, 1).ToString();

                            //Variable para ver si esta el texto ese del toor o no
                            int vhayNro = descripcion.IndexOf(" Nro");

                            if (vhayNro > 0)
                            {
                                descripcion = descripcion.Substring(0, vhayNro);
                            }

                            _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})");
                        }
                    }
                    catch (Exception er)
                    {
                        lblContador.Text = er.Message;
                    }

                }

                grdSalida.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Credito) Importe" +
                    ", 5 IDC, 'CCte Alonso' Caja, 14 Tipo, '' Nombre, 0 SubTipo, '' Desc_ST " +
                    "FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion, IDC, Caja, Tipo, Nombre, SubTipo, Desc_ST"), true, 2);
                grdSalida.Columnas[2].Format = "N2";

                string buscar = "prisma ";
                for (int i = 1; i < grdSalida.Rows - 1; i++)
                {
                    string entrada = "";
                    if (grdSalida.get_Texto(i, 1) != null) { entrada = grdSalida.get_Texto(i, 1).ToString(); }
                    int indess = entrada.ToLower().IndexOf(buscar);

                    if (indess > -1)
                    {
                        //Leemos el establecimiento
                        int esst = Convert.ToInt32(entrada.Substring(indess + buscar.Length));

                        //Buscamos que sucursal es
                        int codSuc = Convert.ToInt32(_Base.Dato_Generico($"SELECT TOP 1 ISNULL(Suc, 1000) FROM dbGastos.dbo.Suc_Cuentas WHERE N_Cuenta = {esst} ORDER BY Suc"));

                        //Ahora buscamos que tipo de tarjeta es (visa, master, etc)
                        string tipo_Tarjeta = Convert.ToString(_Base.Dato_Generico($"SELECT TOP 1 ISNULL(Nombre, 'Tarjeta') FROM dbGastos.dbo.Tipo_Cuentas WHERE ID = " +
                            $"(SELECT TOP 1 ISNULL(Tipo, 0) FROM dbGastos.dbo.Suc_Cuentas WHERE N_Cuenta = {esst} ORDER BY Suc)"));

                        object nomSuc = _Base.Dato_Generico($"SELECT ISNULL(Nombre, 'Empresa') FROM Sucursales WHERE ID ={codSuc}");

                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("Desc_ST"), $"{nomSuc} {tipo_Tarjeta.Trim()} EST: {esst}");

                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("SubTipo"), codSuc);
                        grdSalida.set_Texto(i, grdSalida.get_ColIndex("Nombre"), "Acreditacion Prisma");
                    }
                }

                grdSalida.AutosizeAll();
            }

        }

        private void Generar_Debitos_ABBVA()
        {
            if (chDebitos.Checked == true)
            {
                c_Base _Base = new c_Base();

                _Base.Ejecutar_Comando("DELETE FROM Temp_n");

                int nop = 0;
                DateTime fecha = DateTime.Today;
                string descripcion = "";
                double importe = 0;

                lblContador.Text = $"{lblContador.Text} Generando Debitos...";
                Application.DoEvents();


                for (int i = 1; i < grd.Rows; i++)
                {
                    importe = Convert.ToDouble(grd.get_Texto(i, 3));
                    if (importe != 0)
                    {
                        nop = ++nop;
                        fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                        descripcion = grd.get_Texto(i, 1).ToString();
                        _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Debito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})");
                    }
                }

                grdDebitos.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Debito) Importe FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 2);
                grdDebitos.Columnas[2].Format = "N2";
                grdDebitos.AutosizeAll();

            }
            lblContador.Text = "Listo.";
        }
        #endregion

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void chDebitos_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !chDebitos.Checked;
        }
        private void chCreditos_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !chCreditos.Checked;
        }
        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !materialCheckBox1.Checked;
        }

        private void grdSalida_Editado(short f, short c, object a)
        {
            grdSalida.set_Texto(f, c, a);
        }

        private void grdSalida_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (grdSalida.Row < grdSalida.Rows - 1) { grdSalida.Filas.Remove(grdSalida.Row); }
            }
        }
        private void cmdGuardar_Creditos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            Entradas en = new Entradas();

            for (int f = 1; f <= grdSalida.Rows - 1; f++)
            {
                double importe = 0;
                if (grdSalida.get_Texto(f, grdSalida.get_ColIndex("Importe")) != null)
                {
                    if (double.TryParse(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Importe")).ToString(), out importe) == true)
                    {
                        en.Fecha = Convert.ToDateTime(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Fecha")));
                        en.caja.ID = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("IDC")));
                        en.TE.Id_Tipo = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Tipo")));
                        en.Id_SubTipoEntrada = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("SubTipo")));
                        en.Descripcion = Convert.ToString(grdSalida.get_Texto(f, grdSalida.get_ColIndex("SubTipo") + 1));
                        en.Importe = importe;
                        en.Agregar();
                    }
                }
            }
            //SELECT Id, Nombre, Suc, 
//            ISNULL((SELECT TOP 1 dispositivo FROM Registros_Asistencias WHERE Fecha = '4/19/2025' AND Empleado = Id ORDER BY Hora), 
//ISNULL((SELECT TOP 1 dispositivo FROM Registros_Asistencias WHERE Fecha = '4/20/2025' AND Empleado = Id ORDER BY Hora), Suc)) Fichado
//FROM Empleados WHERE ISNULL(Baja, '1/1/2032') > '4/21/2025' AND Alta< '4/21/2025' AND Suc BETWEEN 1 AND 503 ORDER BY Fichado
            grd.Rows = 0;
            grdSalida.Rows = 0;

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void cmdGuardar_Debitos_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //this.Enabled = false;
            //Entradas en = new Entradas();

            //for (int f = 1; f < grdSalida.Rows - 1; f++)
            //{
            //    double importe = 0;
            //    if (grdSalida.get_Texto(f, grdSalida.get_ColIndex("Importe")) != null)
            //    {
            //        if (double.TryParse(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Importe")).ToString(), out importe) == true)
            //        {
            //            en.Fecha = Convert.ToDateTime(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Fecha")));
            //            en.caja.ID = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("IDC")));
            //            en.TE.Id_Tipo = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("Tipo")));
            //            en.Id_SubTipoEntrada = Convert.ToInt32(grdSalida.get_Texto(f, grdSalida.get_ColIndex("SubTipo")));
            //            en.Descripcion = Convert.ToString(grdSalida.get_Texto(f, grdSalida.get_ColIndex("SubTipo") + 1));
            //            en.Importe = importe;

            //            en.Agregar();

            //        }
            //    }

            //}

            //this.Cursor = Cursors.Default;
            //this.Enabled = true;
        }

        private void frmImportar_Excel_Load(object sender, EventArgs e)
        {
            Leer_Tarjetas leer = new Leer_Tarjetas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(cmbTitulares, leer.titulares());
            cmbTitulares.SelectedIndex = 0;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_Base _Base = new c_Base();
            string s;
            s = _Base.Dato_Generico($"SELECT TOP 1 ISNULL(Valor, '') FROM Configuraciones WHERE Dato like 'formato_{cmbTipo.Text}'").ToString();
            txtFormato.Text = s;

        }

        private async void cmdCargar_prueba_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Leer_Tarjetas leer = new Leer_Tarjetas();
            DataTable dt = new DataTable();

            c_Base _Base = new c_Base();
            dt = _Base.Datos_Genericos("SELECT TOP 0 Fecha, ID_TipoEntrada, ID_SubTipoEntrada, Descripcion, Importe, Importe as Neto, ID_Caja FROM CD_Entradas ");

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            Cursor = Cursors.WaitCursor;

            int caja = leer.caja_titular(h.Codigo_Seleccionado(cmbTitulares.Text));

            using (HttpClient client = new HttpClient())
            {
                string AccessToken = leer.Bearer(h.Codigo_Seleccionado(cmbTitulares.Text));

                dt.Rows.Clear();
                string beginDate = dtFecha.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string endDate = dtMaxima.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                int offset = 0;
                int total = 0;

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

                            //var poi = venta["point_of_interaction"];
                            //var device = poi["device"];

                            nrow["Fecha"] = Convert.ToDateTime(venta["money_release_date"]?.ToString().Substring(0, 10));
                            nrow["Importe"] = Convert.ToSingle(venta["transaction_amount"]?.ToString().Replace(".", ","));
                            var details = venta["transaction_details"];
                            nrow["Neto"] = Convert.ToSingle(details["net_received_amount"]?.ToString().Replace(".", ","));

                            nrow["Descripcion"] = "Suc Varias";
                            nrow["ID_TipoEntrada"] = 23;
                            nrow["ID_SubTipoEntrada"] = 203;
                            nrow["ID_Caja"] = caja;

                            //if (device == null)
                            //{ nrow["Suc"] = 0; }
                            //else { nrow["Suc"] = leer.suc_cuentas.buscar_suc(Convert.ToInt32(device["serial_number"]?.ToString().Substring(8) ?? "N/A")); }

                            dt.Rows.Add(nrow);
                        }
                    }
                    else { i += -1; continue; }
                }
                grd.MostrarDatos(dt, true, false);
                grd.AutosizeAll();

                double tb = grd.SumarCol(grd.get_ColIndex("Importe"), false);
                double tn = grd.SumarCol(grd.get_ColIndex("Neto"), false);

                var groupedData = dt.AsEnumerable().GroupBy(row => row.Field<DateTime>("Fecha")).Select(group => new { Fecha = group.Key, TotalImporte = group.Sum(row => row.Field<Double>("Importe")), TotalNeto = group.Sum(row => row.Field<Double>("Neto")) });

                // Crear un nuevo DataTable con los datos agrupados
                DataTable resultTable = _Base.Datos_Genericos("SELECT TOP 0 Fecha, ID_Caja as IDC, ID_TipoEntrada As Tipo, ID_SubTipoEntrada As SubTipo, Descripcion, Importe FROM CD_Entradas ");
                DataTable resultTable_desc = _Base.Datos_Genericos("SELECT TOP 0 Fecha, Descripcion, Importe FROM CD_Entradas ");

                foreach (var group in groupedData)
                {
                    DataRow nrow = resultTable.NewRow();
                    DataRow nrow_desc = resultTable_desc.NewRow();

                    nrow["Fecha"] = group.Fecha;
                    nrow["IDC"] = caja;
                    nrow["Tipo"] = 23;
                    nrow["SubTipo"] = 203;
                    nrow["Descripcion"] = "Suc Varias";
                    nrow["Importe"] = group.TotalImporte;

                    nrow_desc["Fecha"] = group.Fecha;
                    nrow_desc["Descripcion"] = "Descuentos MP y Banco";
                    nrow_desc["Importe"] = group.TotalImporte - group.TotalNeto;

                    resultTable.Rows.Add(nrow);
                    resultTable_desc.Rows.Add(nrow_desc);
                }

                grdSalida.MostrarDatos(resultTable, true, false);
                grdSalida.Columnas[grdSalida.get_ColIndex("Importe")].Style.Format = "N2";
                grdSalida.AutosizeAll();

                grdDebitos.MostrarDatos(resultTable_desc, true, false);
                grdDebitos.Columnas[grdDebitos.get_ColIndex("Importe")].Style.Format = "N2";
                grdDebitos.AutosizeAll();

                Application.DoEvents();

                Cursor = Cursors.Default;

                //if (grdDatos.Rows > 0)
                //{ Guardar(); }
            }
        }
    }
}