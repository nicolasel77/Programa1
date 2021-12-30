namespace Programa1.Carga.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmImportar_Excel : Form
    {
        public frmImportar_Excel()
        {
            InitializeComponent();

            cmdSeleccionar.Text = "F:\\Descargas\\MOLLEDA - MOVIMIENTOS GALICIA 15-12 Y 16-12.xlsx";
            cmbTipo.SelectedIndex = 0;
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionar_archivo = new OpenFileDialog();
            seleccionar_archivo.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm;*.csv";
            seleccionar_archivo.Title = "Select a Excel File";

            if (seleccionar_archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                cmdSeleccionar.Text = seleccionar_archivo.FileName;
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cargar_Datos()
        {
            if (cmdSeleccionar.Text != "Seleccionar archivo")
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;
                if (File.Exists(cmdSeleccionar.Text) == true)
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

                    grd.Rows = rowCount;
                    grd.Cols = colCount;

                    grd.FixRows = 1;
                    for (int j = 1; j <= colCount; j++)
                    {
                        grd.set_Texto(0, j - 1, Convert.ToString(xlRange.Cells[1, j].Value2));
                        grd.Columnas[j - 1].Name = Convert.ToString(xlRange.Cells[1, j].Value2);
                    }

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
                                var nn = xlRange.Cells[i, j].Value2;
                                if (nn != null)
                                {
                                    grd.set_Texto(i - 1, j - 1, DateTime.FromOADate(xlRange.Cells[i, j].Value2));
                                }
                            }

                            lblContador.Text = $"Cargando {i - 1} de {rowCount} filas.";
                            Application.DoEvents();
                        }
                    }
                    grd.AutosizeAll();

                    lblContador.Text = $"{rowCount} filas leídas.";

                    Generar_Creditos();
                    Generar_Debitos();


                    xlWorkbook.Close();
                    xlApp.Quit();

                    //Liberar
                    GC.Collect();
                }
                this.Enabled = true;
                this.Cursor = Cursors.Default;

            }
        }

        private void Generar_Creditos()
        {
            //Creamos la tabla temporal
            c_Base _Base = new c_Base();
            //_Base.Ejecutar_Comando("CREATE TABLE Temp_n(Fecha date, ID int, Descripcion varchar(100), Debito float, Credito float)");

            _Base.Ejecutar_Comando("DELETE FROM Temp_n");

            int nop = 0;
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
                    importe = Convert.ToDouble(grd.get_Texto(i, 4));
                    if (grd.get_Texto(i, grd.get_ColIndex("Descripción")) != null)
                    {
                        descripcion = grd.get_Texto(i, grd.get_ColIndex("Descripción")).ToString(); 
                    }

                    bool nono = false;

                    if (Convert.ToDouble(grd.get_Texto(i, 3)) > 0)
                    {
                        if (nop > 0) { nop = nop * -1; }
                    }

                    if (importe != 0)
                    {
                        nop = nop * -1;
                        nop = ++nop;
                        fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                    }
                    else
                    {
                        if (nop > 0)
                        {
                            _Base.Ejecutar_Comando($"UPDATE Temp_n SET Descripcion=CONVERT(VARCHAR, (SELECT Top 1 Descripcion FROM Temp_n WHERE ID={nop})) + ' {descripcion}'  WHERE ID={nop}");
                            nono = true;
                        }
                    }

                    if (nop > 0 && nono == false) { _Base.Ejecutar_Comando($"INSERT INTO Temp_n(Fecha, ID, Descripcion, Credito) VALUES('{fecha:MM/dd/yyy}', {nop}, '{descripcion}', {importe.ToString().Replace(",", ".")})"); }
                }
                catch (Exception er)
                {
                    lblContador.Text = er.Message;
                }

            }

            grdSalida.MostrarDatos(_Base.Datos_Genericos("SELECT Fecha, Descripcion, SUM(Credito) Importe FROM Temp_n GROUP BY Fecha, Descripcion ORDER BY Fecha, Descripcion"), true, 2);
            grdSalida.Columnas[2].Format = "N2";
            grdSalida.AutosizeAll();
            //_Base.Ejecutar_Comando("DROP TABLE Temp_n");

        }

        private void Generar_Debitos()
        {
            //Creamos la tabla temporal
            c_Base _Base = new c_Base();
            //_Base.Ejecutar_Comando("CREATE TABLE Temp_n(Fecha date, ID int, Descripcion varchar(100), Debito float, Credito float)");

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
                if (grd.get_Texto(i, grd.get_ColIndex("Descripción")) != null)
                {
                    descripcion = grd.get_Texto(i, grd.get_ColIndex("Descripción")).ToString();
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
                    fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
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
            //_Base.Ejecutar_Comando("DROP TABLE Temp_n");

            lblContador.Text = "Listo.";
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}
