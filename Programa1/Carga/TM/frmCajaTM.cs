namespace Programa1.Carga.TM
{
    using C1.Util;
    using Programa1.Carga.Varios;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmCajaTM : Form
    {
        DateTime fecha = DateTime.Today;
        clsTM gastosTM = new clsTM();

        int eID = 0;
        int eFecha = 1;
        int eCaja = 2;
        int eTipo = 4;
        int eSTipo = 6;
        int eDescripcion = 7;
        int eImporte = 8;

        int cID = 0;
        int cFecha = 1;
        int cCaja = 2;
        int cTipo = 4;
        int cSTipo = 6;
        int cDetalle = 8;
        int cImporte = 10;
        int cFactura = 11;

        public frmCajaTM()
        {

            InitializeComponent();
            fecha = DateTime.Today;
            mntFecha.SetDate(fecha);
            Cargar_Gastos();
            Cargar_Entradas();
            Cuentas();

            int[] i = { 13, 46, 112 };
            grdEntradas.TeclasManejadas = i;
            grdSalidas.TeclasManejadas = i;

            splitContainer2.Panel1Collapsed = !entradasToolStripMenuItem.Checked;
        }

        private void mntFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (mntFecha.SelectionStart.Date != fecha)
            {
                fecha = mntFecha.SelectionStart;
                Cargar_Gastos();
                Cargar_Entradas();
                Cuentas();
            }
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entradasToolStripMenuItem.Checked = !entradasToolStripMenuItem.Checked;
            splitContainer2.Panel1Collapsed = !entradasToolStripMenuItem.Checked;
        }

        #region " Subs 
        internal void Cargar_Gastos()
        {
            DataTable dt = new DataTable("Datos");
            dt = gastosTM.Gastos(fecha);

            grdSalidas.MostrarDatos(dt, true, true);

            cID = grdSalidas.get_ColIndex("ID");
            cFecha = grdSalidas.get_ColIndex("Fecha");
            cCaja = grdSalidas.get_ColIndex("IDC");
            cTipo = grdSalidas.get_ColIndex("Id_TipoGastos");
            cSTipo = grdSalidas.get_ColIndex("ID_SubTipoGastos");
            cDetalle = grdSalidas.get_ColIndex("ID_DetalleGastos");
            cImporte = grdSalidas.get_ColIndex("Importe");
            cFactura = grdSalidas.get_ColIndex("ID_Factura");

            grdSalidas.set_ColW(cID, 0);
            grdSalidas.set_ColW(cFecha, 0);
            grdSalidas.set_Texto(0, cCaja, "C");
            grdSalidas.set_ColW(cCaja, 30);
            grdSalidas.set_ColW(cCaja + 1, 100);
            grdSalidas.set_Texto(0, cTipo, "T");
            grdSalidas.set_Texto(0, cTipo + 1, "Tipo");
            grdSalidas.set_ColW(cTipo, 30);
            grdSalidas.set_ColW(cTipo + 1, 100);
            grdSalidas.set_Texto(0, cSTipo, "ST");
            grdSalidas.set_Texto(0, cSTipo + 1, "Sub Tipo");
            grdSalidas.set_ColW(cSTipo, 30);
            grdSalidas.set_ColW(cSTipo + 1, 100);
            grdSalidas.set_Texto(0, cDetalle, "D");
            grdSalidas.set_Texto(0, cDetalle + 1, "Detalle");
            grdSalidas.set_ColW(cDetalle, 30);
            grdSalidas.set_ColW(cDetalle + 1, 250);
            grdSalidas.set_ColW(cImporte, 150);
            for (int c = cImporte + 1; c < grdSalidas.Cols; c++)
            {
                grdSalidas.set_ColW(c, 0);
            }

            grdSalidas.Columnas[cImporte].Style.Format = "N2";
            C1.Win.C1FlexGrid.CellStyle cs = grdSalidas.Styles.Add("titulo");
            cs.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            grdSalidas.Filas[0].Style = cs;

        }
        internal void Cargar_Entradas()
        {
            DataTable dt = new DataTable("Datos");
            dt = gastosTM.Entradas(fecha);

            grdEntradas.MostrarDatos(dt, true, true);

            eID = grdEntradas.get_ColIndex("ID");
            eFecha = grdEntradas.get_ColIndex("Fecha");
            eCaja = grdEntradas.get_ColIndex("IDC");
            eTipo = grdEntradas.get_ColIndex("ID_TipoEntrada");
            eSTipo = grdEntradas.get_ColIndex("ID_SubTipoEntrada");
            eDescripcion = grdEntradas.get_ColIndex("Descripcion");
            eImporte = grdEntradas.get_ColIndex("Importe");


            grdEntradas.set_ColW(eID, 0);
            grdEntradas.set_ColW(eFecha, 0);
            grdEntradas.set_Texto(0, eCaja, "C");
            grdEntradas.set_ColW(eCaja, 30);
            grdEntradas.set_ColW(eCaja + 1, 100);
            grdEntradas.set_Texto(0, eTipo, "T");
            grdEntradas.set_Texto(0, eTipo + 1, "Tipo");
            grdEntradas.set_ColW(eTipo, 30);
            grdEntradas.set_ColW(eTipo + 1, 100);
            grdEntradas.set_Texto(0, eSTipo, "ST");
            grdEntradas.set_Texto(0, eSTipo + 1, "Sub Tipo");
            grdEntradas.set_ColW(eSTipo, 30);
            grdEntradas.set_ColW(eSTipo + 1, 100);
            grdEntradas.set_ColW(eImporte, 150);

            for (int c = eImporte + 1; c < grdEntradas.Cols; c++)
            {
                grdEntradas.set_ColW(c, 0);
            }

            grdEntradas.Columnas[eImporte].Style.Format = "N2";
            C1.Win.C1FlexGrid.CellStyle cs = grdEntradas.Styles.Add("titulo");
            cs.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            grdEntradas.Filas[0].Style = cs;
        }

        private void Cuentas()
        {
            Total_Gastos();
            cargar_Cajas();
        }

        private void Total_Gastos()
        {
            decimal total = 0;
            for (short f = 1; f < grdSalidas.Rows; f++)
            {
                total += Convert.ToDecimal(grdSalidas.get_Texto(f, cImporte));
            }
            lblTotalGrillaGastos.Text = "Total Gastos: " + total.ToString("N2");
        }

        private void Total_Entradas()
        {
            decimal total = 0;
            for (short f = 1; f < grdEntradas.Rows; f++)
            {
                total += Convert.ToDecimal(grdEntradas.get_Texto(f, eImporte));
            }
            lblTotalGrillaEntrada.Text = "Total Entradas: " + total.ToString("N2");
        }

        private void cargar_Cajas()
        {
            DataTable dt = new DataTable();
            dt = gastosTM.Resumen_Cajas(fecha);
            grdCajas.MostrarDatos(dt, true, false);
            grdCajas.Columnas[grdCajas.get_ColIndex("Saldo")].Style.Format = "N2";
            grdCajas.AutosizeAll();
        }

        #endregion

        #region " Gastos 
        private void grdSalidas_Editado(short f, short c, object a)
        {
            if (gastosTM.fecha_Cerrada(fecha))
            {
                MessageBox.Show("La fecha está cerrada. No se pueden realizar modificaciones.");
                return;
            }
            
            int id = (int)grdSalidas.get_Texto(f, 0);

            if (c == cCaja)
            {
                string s = gastosTM.Nombre_Caja((int)a);
                if (s.Length > 0)
                {
                    grdSalidas.set_Texto(f, c, a);
                    grdSalidas.set_Texto(f, c + 1, s);
                    grdSalidas.ActivarCelda(f, cTipo);
                }
                else
                {
                    grdSalidas.ErrorEnTxt();
                    return;
                }
            }

            if (c == cTipo)
            {
                string s = gastosTM.Nombre_Tipo((int)a);
                if (s.Length > 0)
                {
                    grdSalidas.set_Texto(f, c, a);
                    grdSalidas.set_Texto(f, c + 1, s);
                    grdSalidas.ActivarCelda(f, cSTipo);
                }
                else
                {
                    grdSalidas.ErrorEnTxt();
                    return;
                }
            }

            if (c == cSTipo)
            {
                int tp = (int)grdSalidas.get_Texto(f, cTipo);
                string s = gastosTM.Nombre_SubTipo(tp, (int)a);
                if (s.Length > 0)
                {
                    grdSalidas.set_Texto(f, c, a);
                    grdSalidas.set_Texto(f, c + 1, s);
                    grdSalidas.ActivarCelda(f, cDetalle);
                }
                else
                {
                    grdSalidas.ErrorEnTxt();
                    return;
                }
            }

            if (c == cDetalle)
            {
                int tp = (int)grdSalidas.get_Texto(f, cTipo);
                string s = gastosTM.Nombre_Detalle(tp, (int)a);
                if (s.Length > 0)
                {
                    grdSalidas.set_Texto(f, c, a);
                    grdSalidas.set_Texto(f, c + 1, s);
                    grdSalidas.ActivarCelda(f, cImporte);
                }
                else
                {
                    grdSalidas.ErrorEnTxt();
                    return;
                }
            }

            int idc = (int)grdSalidas.get_Texto(f, cCaja);
            int t = (int)grdSalidas.get_Texto(f, cTipo);
            int st = (int)grdSalidas.get_Texto(f, cSTipo);
            string dst = grdSalidas.get_Texto(f, cSTipo + 1).ToString();
            int d = (int)grdSalidas.get_Texto(f, cDetalle);
            string sd = grdSalidas.get_Texto(f, cDetalle + 1).ToString();
            decimal importe = Convert.ToDecimal(grdSalidas.get_Texto(f, cImporte));
            int fc = (int)grdSalidas.get_Texto(f, cFactura);

            if (c == cDetalle + 1)
            {
                if (a.ToString().Length > 0)
                {
                    grdSalidas.set_Texto(f, c, a);
                    if (id != 0)
                    {
                        gastosTM.Modifcar_Gasto(id, fecha, idc, t, st, dst, d, a.ToString(), importe, fc);
                    }
                    grdSalidas.ActivarCelda(f, cImporte);
                }
                else
                {
                    grdSalidas.ErrorEnTxt();
                    return;
                }
            }

            if (c == cImporte)
            {
                grdSalidas.set_Texto(f, c, a);
                Total_Gastos();
                if (id == 0)
                {
                    importe = Convert.ToDecimal(a);
                    gastosTM.Nuevo_Gasto(fecha, idc, t, st, dst, d, sd, importe, fc);
                    id = gastosTM.Ultimo_ID();
                    grdSalidas.set_Texto(f, cID, id);

                    grdSalidas.AgregarFila();

                    int colCaja = cCaja;
                    grdSalidas.set_Texto(f + 1, colCaja, idc);
                    grdSalidas.set_Texto(f + 1, colCaja + 1, grdSalidas.get_Texto(f, colCaja + 1));
                    grdSalidas.ActivarCelda(f + 1, cTipo);
                }
                else
                {
                    gastosTM.Modifcar_Gasto(id, fecha, idc, t, st, dst, d, sd, importe, fc);
                    grdSalidas.ActivarCelda(f + 1, cImporte);
                }
                Total_Gastos();
                cargar_Cajas();
            }

        }

        private void grdSalidas_KeyUp(object sender, short e)
        {
            // Enter
            if (e == 13)
            {
                // Repetir segun corresponda
                int f = grdSalidas.Row;
                int c = grdSalidas.Col;
                if (f == grdSalidas.Rows - 1)
                {
                    if (c == cCaja || c == cTipo || c == cSTipo || c == cDetalle)
                    {
                        grdSalidas_Editado((short)f, (short)c, grdSalidas.get_Texto(f - 1, c));
                    }
                }
                else
                {
                    if (c == cImporte)
                    {
                        grdSalidas.ActivarCelda(f + 1, cCaja);
                    }
                    else
                    {
                        grdSalidas.ActivarCelda(f, c + 1);
                    }
                }
            }
            // Borrado
            if (e == 46)
            {
                short f = Convert.ToInt16(grdSalidas.Row);
                short c = Convert.ToInt16(grdSalidas.Col);
                int id = (int)grdSalidas.get_Texto(f, 0);
                if (id != 0)
                {
                    DialogResult dr = MessageBox.Show("Confirma el borrado del gasto seleccionado?", "Borrar Gasto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        gastosTM.Borrar_Gasto(id);
                        grdSalidas.BorrarFila(f);
                        grdSalidas.ActivarCelda(f, c);
                        Total_Gastos();
                        cargar_Cajas();
                    }
                }
                return;
            }
            // Ayuda
            if (e == 112)
            {
                short f = Convert.ToInt16(grdSalidas.Row);
                short c = Convert.ToInt16(grdSalidas.Col);
                frmAyuda frmAyuda = new frmAyuda();
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (c == 2 || c == 3)
                {
                    c = 2;
                    frmAyuda.Campo_ID = "ID";
                    frmAyuda.Tabla = "Cajas";
                }
                if (c == 4 || c == 5)
                {
                    c = 4;
                    frmAyuda.Campo_ID = "ID_tipo";
                    frmAyuda.Tabla = "Tipos_Salidas";
                }
                if (c == 6 || c == 7)
                {
                    c = 6;
                    int tp = (int)grdSalidas.get_Texto(f, 4);
                    string tabla = gastosTM.Tabla_SubTipo(tp);
                    if (tabla == "SubTipos_Gastos")
                    {
                        frmAyuda.Campo_ID = "ID_SubTipo";
                        frmAyuda.Filtro = "ID_Tipo=" + grdSalidas.get_Texto(f, 4).ToString();
                    }
                    else
                    {
                        frmAyuda.Filtro = "";
                        frmAyuda.Campo_ID = "ID";

                    }
                    frmAyuda.Tabla = tabla;
                }

                if (c == 8 || c == 9)
                {
                    c = 8;
                    int tp = (int)grdSalidas.get_Texto(f, 4);
                    frmAyuda.Campo_ID = "ID_Detalle";
                    frmAyuda.Filtro = "ID_Tipo=" + grdSalidas.get_Texto(f, 4).ToString();
                    frmAyuda.Tabla = "Detalles_Gastos";

                }

                frmAyuda.ShowDialog();
                if (frmAyuda.ID_Seleccionado != 0)
                {
                    grdSalidas.set_Texto(f, c, frmAyuda.ID_Seleccionado);
                    grdSalidas.set_Texto(f, c + 1, frmAyuda.Nombre_Seleccionado);
                    grdSalidas.ActivarCelda(f, c + 2);
                }
                return;
            }

        }

        private void cmdPagoHacienda_Click(object sender, EventArgs e)
        {
            int f = grdSalidas.Row;
            if (f < 1) { return; }
            int t = (int)grdSalidas.get_Texto(f, 4);
            int consig = (int)grdSalidas.get_Texto(f, 6);

            if (t == 0 && consig == 0) { return; }
            if (t != 12) { return; }

            frmPagarHacienda fr = new frmPagarHacienda();
            fr.Cargar_Facturas(consig);
            fr.ShowDialog();
            if (fr.importe != 0)
            {
                grdSalidas.set_Texto(f, cFactura, fr.id_factura);
                grdSalidas.set_Texto(f, 8, 1);
                grdSalidas.set_Texto(f, 9, fr.detalle);
                grdSalidas_Editado(Convert.ToInt16(f), 10, fr.importe);

            }
            fr.Dispose();
        }

        #endregion

        #region " Entradas "

        private void grdEntradas_Editado(short f, short c, object a)
        {
            int id = (int)grdEntradas.get_Texto(f, eID);

            if (c == eCaja)
            {
                string s = gastosTM.Nombre_Caja((int)a);
                if (s.Length > 0)
                {
                    grdEntradas.set_Texto(f, c, a);
                    grdEntradas.set_Texto(f, c + 1, s);
                    grdEntradas.ActivarCelda(f, eTipo);
                }
                else
                {
                    grdEntradas.ErrorEnTxt();
                    return;
                }
            }

            if (c == eTipo)
            {
                string s = gastosTM.Nombre_TipoEntrada((int)a);
                if (s.Length > 0)
                {
                    grdEntradas.set_Texto(f, c, a);
                    grdEntradas.set_Texto(f, c + 1, s);
                    grdEntradas.ActivarCelda(f, eSTipo);
                }
                else
                {
                    grdEntradas.ErrorEnTxt();
                    return;
                }
            }

            if (c == eSTipo)
            {
                int tp = (int)grdEntradas.get_Texto(f, cTipo);
                string s = gastosTM.Nombre_SubTipoEntrada(tp, (int)a);
                if (s.Length > 0)
                {
                    grdEntradas.set_Texto(f, c, a);
                    grdEntradas.set_Texto(f, c + 1, s);
                    grdEntradas.ActivarCelda(f, eImporte);
                }
                else
                {
                    grdEntradas.ErrorEnTxt();
                    return;
                }
            }

            int idc = (int)grdEntradas.get_Texto(f, eCaja);
            int t = (int)grdEntradas.get_Texto(f, eTipo);
            int st = (int)grdEntradas.get_Texto(f, eSTipo);
            string dsc = grdEntradas.get_Texto(f, eSTipo + 1).ToString();
            decimal importe = Convert.ToDecimal(grdEntradas.get_Texto(f, eImporte));

            if (c == eDescripcion)
            {
                if (a.ToString().Length > 0)
                {
                    grdEntradas.set_Texto(f, c, a);
                    if (id != 0)
                    {
                        gastosTM.Modifcar_Entrada(id, fecha, idc, t, st, a.ToString(), importe);
                    }
                    grdEntradas.ActivarCelda(f, eImporte);
                }
                else
                {
                    grdEntradas.ErrorEnTxt();
                    return;
                }
            }

            if (c == eImporte)
            {
                grdEntradas.set_Texto(f, c, a);
                importe = Convert.ToDecimal(a);
                Total_Entradas();
                if (id == 0)
                {

                    int idViejo = gastosTM.Ultimo_ID("CD_Entradas");

                    gastosTM.Nueva_Entrada(fecha, idc, t, st, dsc, importe);
                    id = gastosTM.Ultimo_ID("CD_Entradas");

                    if (id != 0 && id != idViejo)
                    {
                        grdEntradas.set_Texto(f, eID, id);

                        grdEntradas.AgregarFila();

                        int colCaja = eCaja;
                        grdEntradas.set_Texto(f + 1, colCaja, idc);
                        grdEntradas.set_Texto(f + 1, colCaja + 1, grdEntradas.get_Texto(f, colCaja + 1));
                        grdEntradas.ActivarCelda(f + 1, eTipo);
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al ingresar el dato nuevo.");
                    }
                }
                else
                {
                    gastosTM.Modifcar_Entrada(id, fecha, idc, t, st, dsc, importe);
                    grdEntradas.ActivarCelda(f + 1, eImporte);
                }
                Total_Entradas();
                cargar_Cajas();
            }
        }


        #endregion

        private void grdEntradas_KeyUp(object sender, short e)
        {
            // Enter
            if (e == 13)
            {
                // Repetir segun corresponda
                int f = grdEntradas.Row;
                int c = grdEntradas.Col;
                if (f == grdEntradas.Rows - 1)
                {
                    if (c == eCaja || c == eTipo || c == eSTipo)
                    {
                        grdEntradas_Editado((short)f, (short)c, grdEntradas.get_Texto(f - 1, c));
                    }
                }
                else
                {
                    if (c == eImporte)
                    {
                        grdEntradas.ActivarCelda(f + 1, eCaja);
                    }
                    else
                    {
                        grdEntradas.ActivarCelda(f, c + 1);
                    }
                }
            }
            // Borrado
            if (e == 46)
            {
                short f = Convert.ToInt16(grdEntradas.Row);
                short c = Convert.ToInt16(grdEntradas.Col);
                int id = (int)grdEntradas.get_Texto(f, 0);
                if (id != 0)
                {
                    DialogResult dr = MessageBox.Show("Confirma el borrado de la entrada seleccionada?", "Borrar Entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        gastosTM.Borrar_Entrada(id);
                        grdEntradas.BorrarFila(f);
                        grdEntradas.ActivarCelda(f, c);
                        Total_Entradas();
                        cargar_Cajas();
                    }
                }
                return;
            }
            // Ayuda
            if (e == 112)
            {
                short f = Convert.ToInt16(grdEntradas.Row);
                short c = Convert.ToInt16(grdEntradas.Col);
                frmAyuda frmAyuda = new frmAyuda();
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (c == eCaja || c == eCaja + 1)
                {
                    c = (short)eCaja;
                    frmAyuda.Campo_ID = "ID";
                    frmAyuda.Tabla = "Cajas";
                }
                if (c == eTipo || c == eTipo + 1)
                {
                    c = (short)eTipo;
                    frmAyuda.Campo_ID = "ID_tipo";
                    frmAyuda.Tabla = "Tipos_Entradas";
                }
                if (c == eSTipo || c == eSTipo + 1)
                {
                    c = (short)eSTipo;
                    int tp = (int)grdEntradas.get_Texto(f, eTipo);
                    string tabla = gastosTM.Tabla_SubTipo(tp, false);
                    
                    frmAyuda.Filtro = "";
                    frmAyuda.Campo_ID = "ID";

                    frmAyuda.Tabla = tabla;
                }               

                frmAyuda.ShowDialog();
                if (frmAyuda.ID_Seleccionado != 0)
                {
                    grdEntradas.set_Texto(f, c, frmAyuda.ID_Seleccionado);
                    grdEntradas.set_Texto(f, c + 1, frmAyuda.Nombre_Seleccionado);
                    grdEntradas.ActivarCelda(f, c + 2);
                }
                return;
            }
        }

        private void cmdCheques_Click(object sender, EventArgs e)
        {
            // Abrir formulario de cheques
            frmChequesTM fr = new frmChequesTM();
            fr.ShowDialog();
        }
    }
}
