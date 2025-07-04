﻿namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class frmGenerarNuevaBoleta : Form
    {

        #region Columnas Nueva grd
        const int cBoleta = 0;
        const int cFecha = 1;
        const int cNombre = 2;
        const int cCab = 3;
        const int cDescr = 4;
        const int cImporte = 5;
        const int cImporteOriginal = 6;
        const int cEfectivo = 7;
        const int cMolleda = 8;
        const int cEMeat = 9;
        const int cLhomar = 10;
        const int cID = 11;
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

        private C1.Win.C1FlexGrid.CellStyle vEstilo;
        public DataTable dt = null;


        public frmGenerarNuevaBoleta()
        {
            InitializeComponent();
            dtFecha.Value = DateTime.Today;
        }
        public void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            dt.Columns.Add("Boleta", typeof(bool));
            grdOriginal.MostrarDatos(dt, true, false);
            grdOriginal.AutosizeAll();

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo")].Style.Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Style.Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Pago")].Style.Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Dif")].Style.Format = "N2";
            grdOriginal.Columnas[cSaldo].Style.Format = "N2";


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
            dt.Columns.Add("ImporteOriginal", typeof(double));
            dt.Columns.Add("Efectivo", typeof(double));
            dt.Columns.Add("Echeq Molleda", typeof(double));
            dt.Columns.Add("Echeq Meat", typeof(double));
            dt.Columns.Add("Echeq Lhomar", typeof(double));
            dt.Columns.Add("Id", typeof(int));

            grdNB.MostrarDatos(dt, true, false);
            grdNB.AgregarFila();
            

            grdNB.Columnas[cImporte].Style.Format = "N2";
            grdNB.Columnas[cEfectivo].Style.Format = "N2";
            grdNB.Columnas[cMolleda].Style.Format = "N2";
            grdNB.Columnas[cEMeat].Style.Format = "N2";
            grdNB.Columnas[cLhomar].Style.Format = "N2";

            grdNB.Columnas[cEfectivo].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdNB.Columnas[cMolleda].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdNB.Columnas[cEMeat].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdNB.Columnas[cLhomar].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdNB.set_Texto(0, cImporte, "Saldo A Pagar");

            //grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, "Total:");
            //Compras_P2();
            this.Cursor = Cursors.Default;


            grdNB.set_ColW(cBoleta, 60);
            grdNB.set_ColW(cFecha, 70);
            grdNB.set_ColW(cNombre, 120);
            grdNB.set_ColW(cCab, 40);
            grdNB.set_ColW(cDescr, 60);
            grdNB.set_ColW(cImporte, 120);
            grdNB.set_ColW(cImporte + 1, 0);
            grdNB.set_ColW(cImporte + 2, 120);
            grdNB.set_ColW(cImporte + 3, 120);
            grdNB.set_ColW(cImporte + 4, 120);
            grdNB.set_ColW(cImporte + 5, 120);

            grdNB.Columnas[cID].Visible = false;
            grdNB.Columnas[cImporte + 1].Visible = false;

            grdNB.FixCols = cImporte + 1;

            splitContainer1.SplitterDistance = 750;

            vEstilo = grdNB.Styles.Add("Total");
            vEstilo.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

        }

        private void grdOriginal_Editado(short f, short c, object a)
        {
            if (c == grdOriginal.get_ColIndex("Boleta"))
            {
                if (Convert.ToInt32(a) == 1)
                {
                    grdNB.BorrarFila(grdNB.Rows - 1);
                    grdNB.AgregarFila();
                    int f1 = grdNB.Rows - 1;
                    grdNB.set_Texto(f1, cBoleta, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    grdNB.set_Texto(f1, cFecha, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Fecha")));
                    grdNB.set_Texto(f1, cNombre, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Nombre")));
                    grdNB.set_Texto(f1, cCab, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Cab")));
                    grdNB.set_Texto(f1, cDescr, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Descr")));
                    grdNB.set_Texto(f1, cImporte, Convert.ToDouble(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Saldo"))));
                    grdNB.set_Texto(f1, cImporteOriginal, Convert.ToDouble(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Saldo"))));
                    grdNB.set_Texto(f1, cID, Convert.ToInt32(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Id_Comprafrigo"))));
                    grdNB.Ordenar(cFecha);
                    grdNB.Ordenar(cNombre);


                    grdNB.AgregarFila();
                    grdNB.set_Texto(grdNB.Rows - 1, cDescr, "Total: ");

                    double tImporte = grdNB.SumarCol("Importe");
                    grdNB.set_Texto(grdNB.Rows - 1, cImporte, tImporte);

                    grdNB.Filas[grdNB.Rows - 1].Style = vEstilo;

                    if (txtPresupuesto.TextLength != 0)
                    {
                        tImporte = Convert.ToDouble(txtPresupuesto.Text) - tImporte;
                        lblDif.Text = tImporte.ToString("C1");
                    }
                }
                else
                {
                    int idOriginal;
                    for (int io = grdOriginal.Row; io <= grdOriginal.Selection.r2; io++)
                    {
                        idOriginal = Convert.ToInt32(grdOriginal.get_Texto(io, grdOriginal.get_ColIndex("Id_Comprafrigo")));
                        for (int i = 1; i <= grdNB.Rows - 2; i++)
                        {
                            if (Convert.ToInt32(grdNB.get_Texto(i, cID)) == idOriginal)
                            {
                                grdNB.BorrarFila(i);
                            }
                        }
                    }

                    double tImporte = grdNB.SumarCol("Importe");
                    grdNB.set_Texto(grdNB.Rows - 1, cImporte, tImporte);

                    grdNB.Filas[grdNB.Rows - 1].Style = vEstilo;

                    if (txtPresupuesto.TextLength != 0)
                    {
                        tImporte = Convert.ToDouble(txtPresupuesto.Text) - tImporte;
                        lblDif.Text = tImporte.ToString("C1");
                    }
                }

            }
            grdNB.AutosizeAll();
            grdNB.set_ColW(cImporte + 2, 120);
            grdNB.set_ColW(cImporte + 3, 120);
            grdNB.set_ColW(cImporte + 4, 120);
            grdNB.set_ColW(cImporte + 5, 120);

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
            if (c >= cImporte)
            {
                grdNB.set_Texto(f, c, a);

                double impOriginal = Convert.ToDouble(grdNB.get_Texto(f, cImporteOriginal));
                double efectivo = Convert.ToDouble(grdNB.get_Texto(f, cEfectivo));
                double molleda = Convert.ToDouble(grdNB.get_Texto(f, cMolleda));
                double meatg = Convert.ToDouble(grdNB.get_Texto(f, cEMeat));
                double lhomar = Convert.ToDouble(grdNB.get_Texto(f, cLhomar));

                grdNB.set_Texto(f, cImporte, impOriginal + efectivo + molleda + meatg + lhomar);

                grdNB.set_Texto(grdNB.Rows - 1, c, 0);

                grdNB.SumarCol(c, true);

                double tImporte = grdNB.SumarCol(cImporte, true);

                if (txtPresupuesto.TextLength != 0)
                {
                    lblDif.Text = (Convert.ToDouble(txtPresupuesto.Text) - tImporte).ToString("N2");
                }
                grdNB.AutosizeAll();
                grdNB.set_ColW(cImporte + 2, 120);
                grdNB.set_ColW(cImporte + 3, 120);
                grdNB.set_ColW(cImporte + 4, 120);
                grdNB.set_ColW(cImporte + 5, 120);
                
            }
        }

        private void cmbImprimir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            nvaBoleta nbol = new nvaBoleta();
            nbol.Limpiar_Tabla();

            for (int i = 1; i <= grdNB.Rows - 1; i++)
            {
                if (Convert.ToInt32(grdNB.get_Texto(i, cID)) > 0)
                {
                    nbol.Boleta = Convert.ToInt32(grdNB.get_Texto(i, cBoleta));
                    nbol.Fecha = Convert.ToDateTime(grdNB.get_Texto(i, cFecha));
                    nbol.Nombre = grdNB.get_Texto(i, cNombre).ToString();
                    nbol.Cab = Convert.ToInt32(grdNB.get_Texto(i, cCab));
                    nbol.Descr = grdNB.get_Texto(i, cDescr).ToString();
                    nbol.Importe = Convert.ToDouble(grdNB.get_Texto(i, cImporte));

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

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            ////Se guarda en gastos como Usuario Lorena por ahora
            //for (int i = 1; i <= grdnvaBoleta.Rows - 1; i++)
            //{
            //    double n = Convert.ToDouble(grdnvaBoleta.get_Texto(i, cBoleta));

            //    if (n != 0)
            //    {
            //        Saldos_Consignatarios saldos = new Saldos_Consignatarios();
            //        int idD = Convert.ToInt32(grdnvaBoleta.get_Texto(i, cID));
            //        string t = Convert.ToDouble(grdnvaBoleta.get_Texto(i, cDif)) == 0 ? "Total" : "Parcial";
            //        string s = string.Format("{0}: {1} {2}  - {3}", grdnvaBoleta.get_Texto(i, cBoleta), grdnvaBoleta.get_Texto(i, cCab), grdnvaBoleta.get_Texto(i, cDescr), t);

            //        saldos.gastos.Id_DetalleGastos = idD;
            //        saldos.gastos.Descripcion = s;

            //        if (saldos.gastos.caja.EsCheque == false)
            //        {
            //            saldos.gastos.Importe = n;
            //            saldos.gastos.Agregar();
            //        }
            //        else
            //        {
            //            foreach (Cheques cheque in ch.cheques_seleccionados)
            //            {
            //                saldos.gastos.Cheque = cheque.Numero;
            //                saldos.gastos.Importe = cheque.Importe;
            //                saldos.gastos.Agregar();
            //            }
            //        }
            //        //compraHacienda.NBoleta.ID = Convert.ToInt32(grdnvaBoleta.get_Texto(i, cNB));
            //        compraHacienda.ID = idD;
            //        compraHacienda.Saldo = Convert.ToDouble(grdnvaBoleta.get_Texto(i, cDif));
            //        compraHacienda.Actualizar_Saldo();
            //    }
            //}
        }

        private void txtPresupuesto_Leave(object sender, EventArgs e)
        {
            double n;
            if (double.TryParse(txtPresupuesto.Text, out n) == true)
            {
                txtPresupuesto.Text = n.ToString("N2");
            }
            else
            {
                txtPresupuesto.Text = "";
            }

        }

        private void txtPresupuesto_TextChanged(object sender, EventArgs e)
        {
            double n;

            if (double.TryParse(txtPresupuesto.Text, out n) == true)
            {
                int i = txtPresupuesto.SelectionStart;
                txtPresupuesto.Text = n.ToString("N2");
                txtPresupuesto.SelectionStart = i;
            }
            else
            {
                txtPresupuesto.Text = "";
            }
        }
    }
}
