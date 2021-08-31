namespace Programa1.Carga.Hacienda
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Programa1.DB.Tesoreria;
    using Excel = Microsoft.Office.Interop.Excel;

    public partial class frmGenerarnvaBoleta : Form
    {
        //C1.Win.C1FlexGrid.CellStyle estP1Azul;
        //C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        //C1.Win.C1FlexGrid.CellStyle estP2Azul;
        //C1.Win.C1FlexGrid.CellStyle estP2Rojo;


        #region Columnas Nueva grd
        const int cID = 0;
        const int cFecha = 1;
        const int cNombre = 2;
        const int cImporte = 3;
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
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Pago")].Style.Format = "N1";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Dif")].Style.Format = "N1";
            grdOriginal.Columnas[cSaldo].Style.Format = "N1";

            grdOriginal.AutosizeAll();
            grdOriginal.set_ColW(cID, 0);
            grdOriginal.set_ColW(cTotal, 80);
            grdOriginal.set_ColW(cPago, 80);
            grdOriginal.set_ColW(cDif, 90);
            grdOriginal.set_ColW(cSaldo, 0);
            grdOriginal.set_ColW(cEstado, 0);
            grdOriginal.set_ColW(cIDMat, 0);
            grdOriginal.set_ColW(cMatricula, 30);




            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Importe", typeof(double));

            grdnvaBoleta.MostrarDatos(dt,true,false);
            grdnvaBoleta.AgregarFila();
            grdnvaBoleta.AgregarFila();

            grdnvaBoleta.Columnas[grdnvaBoleta.get_ColIndex("Importe")].Style.Format = "N1";

            grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, "Total:");
            //Compras_P2();
            this.Cursor = Cursors.Default;


            grdnvaBoleta.set_ColW(cID, 70);
            grdnvaBoleta.set_ColW(cFecha, 70);
            grdnvaBoleta.set_ColW(cNombre, 120);
            grdnvaBoleta.set_ColW(cImporte, 120);

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
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cID, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cFecha, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Fecha")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Nombre")));
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, Convert.ToDouble(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Saldo"))) * -1);

                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.AgregarFila();
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, "Total: ");
                    grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cImporte, grdnvaBoleta.SumarCol("Importe"));
                }
                else
                {
                    int idOriginal = Convert.ToInt32(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    for (int i = 1; i == grdnvaBoleta.Rows-2; i++)
                    {
                        if (Convert.ToInt32(grdOriginal.get_Texto(i, 0)) == idOriginal)
                        { grdnvaBoleta.BorrarFila(i); }
                    }
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
            
            // Ejecutar la macro

            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Importe", typeof(double));

            for (int i = 1; i <= grdnvaBoleta.Rows - 1; i++)
            {
                DataRow r = dt.NewRow();
                r["Id"] = grdnvaBoleta.get_Texto(i, cID);
                r["Fecha"] = grdnvaBoleta.get_Texto(i, cFecha);
                r["Nombre"] = grdnvaBoleta.get_Texto(i, cNombre);
                r["Importe"] = grdnvaBoleta.get_Texto(i, cImporte);
                dt.Rows.Add(r);
            }

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppContext.BaseDirectory + "\\nvaBoleta.xlsm");
            xlApp.Run("Cargar", dt);
            xlApp.Visible = true;
            
            //xlWorkbook.Close(false);
            //xlApp = null;
            //this.Close();
            this.Cursor = Cursors.Default;
        }
    }
}
