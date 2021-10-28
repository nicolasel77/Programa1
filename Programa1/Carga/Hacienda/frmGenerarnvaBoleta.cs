namespace Programa1.Carga.Hacienda
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Programa1.DB.Tesoreria;
    using Excel = Microsoft.Office.Interop.Excel;
    using Programa1.DB;
    public partial class frmGenerarnvaBoleta : Form
    {
        //C1.Win.C1FlexGrid.CellStyle estP1Azul;
        //C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        //C1.Win.C1FlexGrid.CellStyle estP2Azul;
        //C1.Win.C1FlexGrid.CellStyle estP2Rojo;


        #region Columnas Nueva grd
        const int cBoleta = 0;
        const int cFecha = 1;
        const int cNombre = 2;
        const int cCab = 3;
        const int cDescr = 4;
        const int cImporte = 5;
        const int  cID = 6;
        #endregion

        #region Columnas grd Ori
        //Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula
        const int cid = 0;
        const int cCosto = 10;
        const int cTotal = 11;
        const int cPago = 12;
        const int cDif = 13;
        const int cSaldo = 14;
        const int cEstado = 15;
        const int cIDMat = 16;
        const int cMatricula = 17;
        #endregion

        public DataTable dt = null;


        public frmGenerarnvaBoleta()
        {
            InitializeComponent();
            //grdOriginal.TeclasManejadas = new int[] { 32 };
            //grdnvaBoleta.TeclasManejadas = new int[] { 32 };

            //estP1Azul = grdOriginal.Styles.Add("");
            //estP1Rojo = grdOriginal.Styles.Add("");
            //estP1Azul.BackColor = Color.LightCyan;
            //estP1Rojo.BackColor = Color.LightCoral;

            //estP2Azul = grdOriginal.Styles.Add("");
            //estP2Rojo = grdOriginal.Styles.Add("");
            //estP2Azul.BackColor = Color.LightCyan;
            //estP2Rojo.BackColor = Color.LightCoral;

        }
        public void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            dt.Columns.Add("Boleta", typeof(bool));
            grdOriginal.MostrarDatos(dt, true, false);
            grdOriginal.AutosizeAll();

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Format = "N1";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo")].Style.Format = "N1";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Style.Format = "N1";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Pago")].Style.Format = "N1";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Dif")].Style.Format = "N1";
            grdOriginal.Columnas[cSaldo].Style.Format = "N1";


            grdOriginal.AutosizeAll();
            grdOriginal.set_ColW(cTotal, 80);
            grdOriginal.set_ColW(cPago, 80);
            grdOriginal.set_ColW(cDif, 90);
            grdOriginal.set_ColW(cSaldo, 0);
            grdOriginal.set_ColW(cEstado, 0);
            grdOriginal.set_ColW(cIDMat, 0);
            grdOriginal.set_ColW(cMatricula, 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_CompraFrigo"), 0);


            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("Boleta", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Cab", typeof(int));
            dt.Columns.Add("Descr", typeof(string));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("Id", typeof(int));

            grdnvaBoleta.MostrarDatos(dt,true,false);
            grdnvaBoleta.AgregarFila();
            grdnvaBoleta.AgregarFila();

            grdnvaBoleta.Columnas[cImporte].Style.Format = "N1";
            grdnvaBoleta.Columnas[cImporte].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, "Total:");
            //Compras_P2();
            this.Cursor = Cursors.Default;

            
            grdnvaBoleta.set_ColW(cBoleta, 60);
            grdnvaBoleta.set_ColW(cFecha, 70);
            grdnvaBoleta.set_ColW(cNombre, 120);
            grdnvaBoleta.set_ColW(cCab, 40);
            grdnvaBoleta.set_ColW(cDescr, 60);
            grdnvaBoleta.set_ColW(cImporte, 120);
            grdnvaBoleta.set_ColW(cID, 0);

        }

        private void grdOriginal_Editado(short f, short c, object a)
        {
            if (c == grdOriginal.get_ColIndex("Boleta"))
            {
                if (Convert.ToInt32(a) == 1)
                {
                    grdnvaBoleta.BorrarFila(grdnvaBoleta.Rows-1);
                    grdnvaBoleta.BorrarFila(grdnvaBoleta.Rows-1);
                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cBoleta, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cFecha, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Fecha")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Nombre")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cCab, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Cab")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cDescr, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Descr")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, Convert.ToDouble(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Saldo"))) * -1);
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cID, Convert.ToInt32(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Id_Comprafrigo"))));
                    grdnvaBoleta.Ordenar(cFecha);
                    grdnvaBoleta.Ordenar(cNombre);

                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cDescr, "Total: ");
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, grdnvaBoleta.SumarCol("Importe"));

                }
                else
                {
                    int idOriginal;
                    for (int io = grdOriginal.Row; io <= grdOriginal.Selection.r2; io++)
                    {
                        idOriginal = Convert.ToInt32(grdOriginal.get_Texto(io, grdOriginal.get_ColIndex("Id_Comprafrigo")));
                        for (int i = 1; i <= grdnvaBoleta.Rows - 2; i++)
                        {
                            if (Convert.ToInt32(grdnvaBoleta.get_Texto(i, cID)) == idOriginal)
                            { grdnvaBoleta.BorrarFila(i); }
                        }
                    }
                    grdnvaBoleta.BorrarFila(grdnvaBoleta.Rows - 1);
                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cDescr, "Total: ");
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, grdnvaBoleta.SumarCol("Importe"));
                }

            }

          

            //if (c == grdOriginal.get_ColIndex("Boleta"))
            //{
            //    foreach (int a in grdnvaBoleta)
            //    {
            //        foreach(int nvac in grdnvaBoleta.Cols )
            //        grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1,)
            //            }
            //}
        }

        private void grdnvaBoleta_Editado(short f, short c, object a)
        {
            grdnvaBoleta.set_Texto(f, c, a);
            grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, 0);
            grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, grdnvaBoleta.SumarCol(cImporte));
        }

        private void cmbImprimir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            nvaBoleta nbol = new nvaBoleta();
            nbol.Limpiar_Tabla();

            for (int i = 1; i <= grdnvaBoleta.Rows - 1; i++)
            {
                if (Convert.ToInt32(grdnvaBoleta.get_Texto(i, cID)) > 0)
                {
                    nbol.Boleta = Convert.ToInt32(grdnvaBoleta.get_Texto(i, cBoleta));
                    nbol.Fecha = Convert.ToDateTime(grdnvaBoleta.get_Texto(i, cFecha));
                    nbol.Nombre = grdnvaBoleta.get_Texto(i, cNombre).ToString();
                    nbol.Cab = Convert.ToInt32(grdnvaBoleta.get_Texto(i, cCab));
                    nbol.Descr = grdnvaBoleta.get_Texto(i, cDescr).ToString();
                    nbol.Importe = Convert.ToDouble(grdnvaBoleta.get_Texto(i, cImporte));

                    nbol.Agregar();
                }
            }

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppContext.BaseDirectory + "\\nvaBoleta.xlsm");
            xlApp.Run("Cargar");
            xlApp.Visible = true;
            //xlApp.showd
            //xlWorkbook.Close(false);
            //xlApp = null;
            //this.Close();
            this.Cursor = Cursors.Default;
        }
    }
}
