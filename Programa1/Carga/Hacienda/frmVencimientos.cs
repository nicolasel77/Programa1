namespace Programa1.Carga.Hacienda
{
    using Formatear_Excel;
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;

    public partial class frmVencimientos : Form
    {
        public Saldos_Consignatarios saldos = new Saldos_Consignatarios();

        C1.Win.C1FlexGrid.CellStyle estP1Azul;
        C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        C1.Win.C1FlexGrid.CellStyle estP2Azul;
        C1.Win.C1FlexGrid.CellStyle estP2Rojo;

        C1.Win.C1FlexGrid.CellStyle estDefault;

        #region Columnas P1
        const int cID = 0;
        const int cKilos = 9;
        const int cCosto = 10;
        const int cTotal = 11;
        const int cPago = 12;
        const int cDif = 13;
        const int cSaldo = 14;
        const int cEstado = 15;
        const int cIDMat = 16;
        const int cMatricula = 17;
        #endregion

        #region Columnas P2
        //Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula
        const int aID = 0;
        const int aImporte = 6;
        const int aPago = 7;
        const int aDif = 8;
        const int aSaldo = 9;
        const int aEstado = 10;
        const int aIDMat = 11;
        const int aMatricula = 12;
        #endregion

        int FilaanteriorP1 = -1;
        int FilaanteriorP2 = -1;

        bool c_cancel = false;

        public frmVencimientos()
        {
            InitializeComponent();

            grd.TeclasManejadas = new int[] { 32 };
            grdAgr.TeclasManejadas = new int[] { 32 };

            estP1Azul = grd.Styles.Add("");
            estP1Rojo = grd.Styles.Add("");
            estP1Azul.BackColor = Color.LightCyan;
            estP1Rojo.BackColor = Color.LightCoral;

            estP2Azul = grd.Styles.Add("");
            estP2Rojo = grd.Styles.Add("");
            estDefault = grd.Styles.Add("");

            estP2Azul.BackColor = Color.LightCyan;
            estP2Rojo.BackColor = Color.LightCoral;
            estDefault.BackColor = Color.LightBlue;

            Cargar();
        }
        public void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lst_Cons, saldos.consignatarios(armarCadena_id_cons()));
            Compras_P1();
            Compras_P2();
            this.Cursor = Cursors.Default;
        }

        private void Compras_P1()
        {
            grd.MostrarDatos(saldos.Vencimientos(armarCadena()), true);
            grd.AgregarFila();
            grd.SumarCol(cDif);
            grd.SumarCol(cTotal);

            double valor = 0;
            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                if (valor == Convert.ToDouble(grd.get_Texto(i, cSaldo)))
                {
                    grd.set_Texto(i, cSaldo, 0);
                }
                else
                {
                    valor = Convert.ToDouble(grd.get_Texto(i, cSaldo));
                }
                grd.set_ColorLetraCelda(i, cDif, (Convert.ToDouble(grd.get_Texto(i, cDif)) < -1) ? Color.Red : (Convert.ToDouble(grd.get_Texto(i, cSaldo)) > 1) ? Color.Blue : Color.Black);
                grd.set_ColorLetraCelda(i, cSaldo, (Convert.ToDouble(grd.get_Texto(i, cSaldo)) < -1) ? Color.Red : (Convert.ToDouble(grd.get_Texto(i, cSaldo)) > 1) ? Color.Blue : Color.Black);
                if (Convert.ToInt16(grd.get_Texto(i, cEstado)) == 1)
                {
                    grd.Filas[i].Style = estP1Azul;
                }
                else
                {
                    if (Convert.ToInt16(grd.get_Texto(i, cEstado)) == 2)
                    {
                        grd.Filas[i].Style = estP1Rojo;
                    }
                }
            }

            grd.Columnas[cKilos].Style.Format = "N1";
            grd.Columnas[cCosto].Style.Format = "N1";
            grd.Columnas[cTotal].Style.Format = "N1";
            grd.Columnas[cTotal].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grd.Columnas[cPago].Style.Format = "N1";
            grd.Columnas[cDif].Style.Format = "N1";
            grd.Columnas[cSaldo].Style.Format = "N1";

            grd.AutosizeAll();
            grd.set_ColW(cID, 0);
            grd.set_ColW(cTotal, 80);
            grd.set_ColW(cPago, 80);
            grd.set_ColW(cDif, 90);
            grd.set_ColW(cSaldo, 0);
            grd.set_ColW(cEstado, 0);
            grd.set_ColW(cIDMat, 0);
            grd.set_ColW(cMatricula, 30);

            grd.ActivarCelda(1, 0);
        }
        private void Compras_P2()
        {
            grdAgr.MostrarDatos(saldos.Vencimientos_Agr(armarCadena()), true);
            grdAgr.AgregarFila();
            grdAgr.SumarCol(aDif);
            grdAgr.SumarCol(aImporte);

            double valor = 0;
            for (int i = 1; i <= grdAgr.Rows - 1; i++)
            {
                if (valor == Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)))
                {
                    grdAgr.set_Texto(i, aSaldo, 0);
                }
                else
                {
                    valor = Convert.ToDouble(grdAgr.get_Texto(i, aSaldo));
                }
                grdAgr.set_ColorLetraCelda(i, aDif, (Convert.ToDouble(grdAgr.get_Texto(i, aDif)) < -1) ? Color.Red : (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) > 1) ? Color.Blue : Color.Black);
                grdAgr.set_ColorLetraCelda(i, aSaldo, (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) < -1) ? Color.Red : (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) > 1) ? Color.Blue : Color.Black);
                if (Convert.ToInt16(grdAgr.get_Texto(i, aEstado)) == 1)
                {
                    grdAgr.Filas[i].Style = estP2Azul;
                }
                else
                {
                    if (Convert.ToInt16(grdAgr.get_Texto(i, aEstado)) == 2)
                    {
                        grdAgr.Filas[i].Style = estP2Rojo;
                    }
                }
            }
            grdAgr.Columnas[aImporte].Style.Format = "N1";
            grdAgr.Columnas[aImporte].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdAgr.Columnas[aPago].Style.Format = "N1";
            grdAgr.Columnas[aDif].Style.Format = "N1";
            grdAgr.Columnas[aSaldo].Style.Format = "N1";

            grdAgr.AutosizeAll();
            grdAgr.set_ColW(aID, 0);
            grdAgr.set_ColW(aImporte, 80);
            grdAgr.set_ColW(aPago, 80);
            grdAgr.set_ColW(aDif, 90);
            grdAgr.set_ColW(aSaldo, 0);
            grdAgr.set_ColW(aEstado, 0);
            grdAgr.set_ColW(aIDMat, 0);
            grdAgr.set_ColW(aMatricula, 30);

            grdAgr.ActivarCelda(1, grdAgr.Rows - 1);
        }

        private void cmdActualizar_Click(object sender, System.EventArgs e)
        {
            Cargar();
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                int f = grd.Row;
                if (Convert.ToInt16(grd.get_Texto(f, cEstado)) == 0)
                {
                    grd.set_Texto(f, cEstado, 1);
                    grd.Filas[f].Style = estP1Azul;
                }
                else
                {
                    if (Convert.ToInt16(grd.get_Texto(f, cEstado)) == 1)
                    {
                        grd.set_Texto(f, cEstado, 2);
                        grd.Filas[f].Style = estP1Rojo;
                    }
                    else
                    {
                        grd.set_Texto(f, cEstado, 0);
                        grd.Filas[f].Style = null;
                    }
                }
                saldos.Ejecutar_Comando($"UPDATE Hacienda_Compras SET Estado={grd.get_Texto(f, cEstado)} WHERE ID_CompraFrigo={grd.get_Texto(f, cID)}");
            }
        }

        private void grdAgr_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                int f = grdAgr.Row;
                if (Convert.ToInt16(grdAgr.get_Texto(f, aEstado)) == 0)
                {
                    grdAgr.set_Texto(f, aEstado, 1);
                    grdAgr.Filas[f].Style = estP2Azul;
                }
                else
                {
                    if (Convert.ToInt16(grdAgr.get_Texto(f, aEstado)) == 1)
                    {
                        grdAgr.set_Texto(f, aEstado, 2);
                        grdAgr.Filas[f].Style = estP2Rojo;
                    }
                    else
                    {
                        grdAgr.set_Texto(f, aEstado, 0);
                        grdAgr.Filas[f].Style = null;
                    }
                }
                saldos.Ejecutar_Comando($"UPDATE Hacienda_Agregados SET Estado={grdAgr.get_Texto(f, aEstado)} WHERE ID_Agregados_Frigo={grdAgr.get_Texto(f, aID)}");
            }
        }

        private void cmbnvaBoleta_Click(object sender, EventArgs e)
        {
            frmGenerarNuevaBoleta fr = new frmGenerarNuevaBoleta();
            fr.dt = saldos.Vencimientos(" (Dif < -1 OR Dif > 1) AND Estado=1");
            fr.Cargar();
            fr.Show();
        }

        private void grd_CambioFila(short Fila)
        {
            if (FilaanteriorP1 > 0)
            {
                if (FilaanteriorP1 <= grd.Rows - 1)
                {
                    if (Convert.ToInt16(grd.get_Texto(FilaanteriorP1, cEstado)) == 0)
                    {
                        grd.Filas[FilaanteriorP1].Style = null;
                    }

                    if (Convert.ToInt16(grd.get_Texto(FilaanteriorP1, cEstado)) == 1)
                    {
                        grd.Filas[FilaanteriorP1].Style = estP1Azul;
                    }
                    else
                    {
                        if (Convert.ToInt16(grd.get_Texto(FilaanteriorP1, cEstado)) == 2)
                        {
                            grd.Filas[FilaanteriorP1].Style = estP1Rojo;
                        }
                    }
                }
            }
            FilaanteriorP1 = grd.Row;
            grd.Filas[FilaanteriorP1].Style = estDefault;
            if (Convert.ToInt32(grd.get_Texto(FilaanteriorP1, cID)) > 0)
            {
                Gastos gastos = new Gastos();
                grdDetalle.MostrarDatos(gastos.Datos_DetalleP($"ID_DetalleGastos = {grd.get_Texto(FilaanteriorP1, cID)} AND ID_TipoGastos = 12"), true, false);
                grdDetalle.AutosizeAll();
                grdDetalle.Columnas[grdDetalle.get_ColIndex("Importe")].Style.Format = "N1";
            }
            else
            {
                grdDetalle.Rows = 1;
            }
        }

        private void grdAgr_CambioFila(short Fila)
        {
            if (FilaanteriorP2 > 0)
            {
                if (FilaanteriorP2 <= grdAgr.Rows - 1)
                {
                    if (Convert.ToInt16(grdAgr.get_Texto(FilaanteriorP2, aEstado)) == 0)
                    {
                        grdAgr.Filas[FilaanteriorP2].Style = null;
                    }

                    if (Convert.ToInt16(grdAgr.get_Texto(FilaanteriorP2, aEstado)) == 1)
                    {
                        grdAgr.Filas[FilaanteriorP2].Style = estP2Azul;
                    }
                    else
                    {
                        if (Convert.ToInt16(grdAgr.get_Texto(FilaanteriorP2, aEstado)) == 2)
                        {
                            grdAgr.Filas[FilaanteriorP2].Style = estP2Rojo;
                        }
                    }
                }
            }
            FilaanteriorP2 = grdAgr.Row;
            grdAgr.Filas[FilaanteriorP2].Style = estDefault;
            if (Convert.ToInt32(grdAgr.get_Texto(FilaanteriorP2, aID)) > 0)
            {
                Gastos gastos = new Gastos();
                grdDetalle.MostrarDatos(gastos.Datos_DetalleP($"ID_DetalleGastos = {grdAgr.get_Texto(FilaanteriorP2, aID)} AND ID_TipoGastos = 22"), true, false);
                grdDetalle.AutosizeAll();
                grdDetalle.Columnas[grdDetalle.get_ColIndex("Importe")].Style.Format = "N1";
            }
            else
            {
                grdDetalle.Rows = 1;
            }
        }
        private void lst_Cons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_cancel == false)
            {
                Compras_P1();
                Compras_P2();
            }
        }
        private void chConSaldo_CheckedChanged(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lst_Cons, saldos.consignatarios(armarCadena_id_cons()));
            Compras_P1();
            Compras_P2();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lst_Cons, saldos.consignatarios(armarCadena_id_cons()));
            Compras_P1();
            Compras_P2();
        }
        string armarCadena()
        {
            string s = "";
            string f = "";
            if (chFecha.Checked == true) { f = cFecha.Cadena(); }
            if (chConSaldo.Checked == true) { s = "Saldo<-10"; }
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            s = h.Unir(s, f);
            f = h.Codigos_Seleccionados(lst_Cons, "Id_Consignatarios IN ({0})");
            s = h.Unir(s, f);
            return s;
        }

        string armarCadena_id_cons()
        {
            string s = "";
            string f = "";
            if (chFecha.Checked == true) { f = cFecha.Cadena(); }
            if (chConSaldo.Checked == true) { s = "Saldo<-10"; }
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            s = h.Unir(s, f);
            s = h.Unir(s, f);
            return s;
        }

        private void chFecha_CheckedChanged(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lst_Cons, saldos.consignatarios(armarCadena_id_cons()));
            Compras_P1();
            Compras_P2();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            //Crear un excel para imprimir
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add();
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Agregar los datos
            for (int i = 0; i <= grd.Rows - 1; i++)
            {
                for (int j = 0; j <= grd.Cols - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = grd.get_Texto(i, j);
                }
            }

            Formatear fm = new Formatear();
            fm.Hoja = xlWorkSheet;
            fm.Vencimientos_P1();
            xlWorkSheet = fm.Hoja;

            //Mostrar los datos
            xlApp.Visible = true;

            //Imprimir            
            xlWorkBook.PrintPreview();


            //Liberar
            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();
            //fm.Hoja = null;

            System.Data.DataTable dt = saldos.Vencimientos_Agr(armarCadena());
            dt.Columns.RemoveAt(0);
            dt.Columns.Remove("Saldo");

            fm.Formato_Automatico(dt);
        }

        private void lst_Cons_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    lst_Cons.SelectedIndex = -1;
                    break;

                case MouseButtons.Right:
                    c_cancel = true; 
                    for (int i = 0; i < lst_Cons.Items.Count; i++)
                    {
                        lst_Cons.SetSelected(i, !lst_Cons.GetSelected(i));
                    }
                    c_cancel = false;
                    Compras_P1();
                    Compras_P2();
                    break;
            }
        }
    }
}