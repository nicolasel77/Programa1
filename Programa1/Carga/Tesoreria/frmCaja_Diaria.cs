﻿
namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCaja_Diaria : Form
    {
        private enum t_Repetir : int
            {
              Ninguno = 0,
              Caja = 1,
              Tipo = 2,
              SubTipo = 3,
              Detalle = 4
            }
        private t_Repetir o_Repetir;


        #region " Columnas Entradas "
        private Byte e_Id;
        private Byte e_Fecha;
        private Byte e_Caja;
        private Byte e_Tipo;
        private Byte e_Subtipo;
        private Byte e_Descripcion;
        private Byte e_Importe;
        private Byte e_Grupo;
        private Byte e_Es_Entrega;
        private Byte e_Tabla;

        #endregion
        #region " Columnas Salidas "
        private Byte s_Id;
        private Byte s_Fecha;
        private Byte s_Caja;
        private Byte s_Tipo;
        private Byte s_SubTipo;
        private Byte s_Detalle;
        private Byte s_Descripcion;
        private Byte s_Importe;
        private Byte s_Autorizado;
        private Byte s_Fecha_Autorizado;
        private Byte s_Grupo;

        #endregion

        private Caja_Diaria CD = new Caja_Diaria();

        /// <summary>
        /// Caja Diaria Entradas
        /// </summary>
        private Entradas cEntradas = new Entradas();
        /// <summary>
        /// Caja Diaria Gastos
        /// </summary>
        private Gastos cGastos = new Gastos();

        private Detalle_Gastos dg = new Detalle_Gastos();

        public frmCaja_Diaria()
        {
            InitializeComponent();
        }

        #region " FORM "
        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            mntFecha.SetDate(CD.Fecha);
            mntFecha.MaxDate = CD.Fecha;

            Cargar_Datos();

            //*****************************
            //*********Entradas************
            //*****************************
            e_Id = Convert.ToByte(grdEntradas.get_ColIndex("Id"));
            e_Fecha = Convert.ToByte(grdEntradas.get_ColIndex("Fecha"));
            e_Caja = Convert.ToByte(grdEntradas.get_ColIndex("IDC"));
            e_Tipo = Convert.ToByte(grdEntradas.get_ColIndex("ID_TipoEntrada"));
            e_Subtipo = Convert.ToByte(grdEntradas.get_ColIndex("ID_SubTipoEntrada"));
            e_Descripcion = Convert.ToByte(grdEntradas.get_ColIndex("Descripcion"));
            e_Importe = Convert.ToByte(grdEntradas.get_ColIndex("Importe"));
            e_Grupo = Convert.ToByte(grdEntradas.get_ColIndex("Grupo"));
            e_Es_Entrega = Convert.ToByte(grdEntradas.get_ColIndex("Es_Entrega"));
            e_Tabla = Convert.ToByte(grdEntradas.get_ColIndex("Tabla"));

            //13: Enter
            //43: +
            //45: -
            //46: Delete
            //112: F1
            grdEntradas.TeclasManejadas = new int[] { 13, 43, 45, 46, 112 };

            grdEntradas.AgregarTeclas(Convert.ToInt32(Keys.Add), e_Tipo, e_Importe);
            grdEntradas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), e_Subtipo, e_Importe);

            Formato_Entradas();
            C1.Win.C1FlexGrid.CellStyle style;
            style = grdEntradas.Styles.Fixed;
            style.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterBottom;
            grdEntradas.set_AlineamientoCelda(0, e_Importe, style);

            //*****************************
            //*********Gastos**************
            //*****************************
            s_Id = Convert.ToByte(grdSalidas.get_ColIndex("Id"));
            s_Fecha = Convert.ToByte(grdSalidas.get_ColIndex("Fecha"));
            s_Caja = Convert.ToByte(grdSalidas.get_ColIndex("IDC"));
            s_Tipo = Convert.ToByte(grdSalidas.get_ColIndex("ID_TipoGastos"));
            s_SubTipo = Convert.ToByte(grdSalidas.get_ColIndex("ID_SubTipoGastos"));
            s_Detalle = Convert.ToByte(grdSalidas.get_ColIndex("ID_DetalleGastos"));
            s_Descripcion = Convert.ToByte(grdSalidas.get_ColIndex("Descripcion"));
            s_Importe = Convert.ToByte(grdSalidas.get_ColIndex("Importe"));
            s_Autorizado = Convert.ToByte(grdSalidas.get_ColIndex("Autorizado"));
            s_Fecha_Autorizado = Convert.ToByte(grdSalidas.get_ColIndex("Fecha_Autorizado"));
            s_Grupo = Convert.ToByte(grdSalidas.get_ColIndex("Grupo"));


            // 13: Enter
            // 43: +
            // 45: -
            // 46: Delete
            //112: F1
            grdSalidas.TeclasManejadas = new int[] { 13, 43, 45, 46, 112, 120 };

            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Add), s_Caja, s_Tipo, s_SubTipo, s_Detalle, s_Importe);
            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), s_Caja, s_Tipo, s_SubTipo, s_Detalle, s_Importe);

            Formato_Salidas();

            style = grdSalidas.Styles.Fixed;
            style.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterBottom;
            grdSalidas.set_AlineamientoCelda(0, s_Importe, style);
            Totales();
        }

        #endregion

        #region " VARIOS "
        private void mntFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cargar_Datos();
        }

        private void frmCaja_Diaria_Resize(object sender, EventArgs e)
        {
            if (splPrincipal.Width != 0 & splPrincipal.Width > 212) { splPrincipal.SplitterDistance = (splPrincipal.Width - 212); }
        }

        private void splPrincipal_Panel2_Resize(object sender, EventArgs e)
        {
            mnuEntradas.Left = (splPrincipal.Panel2.Width - mnuEntradas.Width) / 2;
            mnuEntradas.Top = 26;
        }

        private void cmdCerrar_Fecha_Click(object sender, EventArgs e)
        {
            frmNuevaFecha fr = new frmNuevaFecha();
            fr.ShowDialog();
            if (fr.Aceptado == true)
            {
                CD.Fecha = fr.mntFecha.SelectionStart.Date;
                CD.Actualizar();
                mntFecha.MaxDate = CD.Fecha;
                mntFecha.SetDate(fr.mntFecha.SelectionStart.Date);
                Cargar_Datos();
            }
        }

        private void rdNinguno_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCaja.Checked) { o_Repetir = t_Repetir.Caja; }
            if (rdTipo.Checked) { o_Repetir = t_Repetir.Tipo; }
            if (rdSubtipo.Checked) { o_Repetir = t_Repetir.SubTipo; }
            if (rdDetalle.Checked) { o_Repetir = t_Repetir.Detalle; }
            if (rdNinguno.Checked) { o_Repetir = t_Repetir.Ninguno; }
        }

        private void cmdTransferencia_Click(object sender, EventArgs e)
        {
            frmTransferencia fr = new frmTransferencia();
            fr.ShowDialog();
        }
        #endregion

        #region " SUBS "
        private void Cargar_Datos()
        {
            this.Cursor = Cursors.WaitCursor;

            grdEntradas.MostrarDatos(cEntradas.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            grdEntradas.ActivarCelda(grdEntradas.Rows - 1, e_Caja);
            Formato_Entradas();

            grdSalidas.MostrarDatos(cGastos.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            Formato_Salidas();


            Totales();

            grdCajas.MostrarDatos(CD.Saldos(mntFecha.SelectionStart.Date), true, 2);
            grdCajas.Columnas[2].Style.Format = "N1";
            grdCajas.AutosizeAll();

            this.Cursor = Cursors.Default;
        }

        private void Formato_Entradas()
        {
            grdEntradas.set_ColW(e_Id, 0);
            grdEntradas.set_ColW(e_Fecha, 0);
            grdEntradas.set_ColW(e_Caja, 30);
            grdEntradas.set_ColW(e_Caja + 1, 60);
            grdEntradas.set_ColW(e_Tipo, 50);
            grdEntradas.set_ColW(e_Tipo + 1, 90);
            grdEntradas.set_ColW(e_Subtipo, 50);
            grdEntradas.set_ColW(e_Descripcion, 120);
            grdEntradas.set_ColW(e_Importe, 90);
            grdEntradas.set_ColW(e_Grupo, 0);
            grdEntradas.set_ColW(e_Es_Entrega, 0);
            grdEntradas.set_ColW(e_Tabla, 0);

            grdEntradas.set_Texto(0, e_Tipo, "Tipo");
            grdEntradas.set_Texto(0, e_Subtipo, "SubTipo");

            grdEntradas.Columnas[e_Importe].Style.Format = "N2";
        }
        private void Formato_Salidas()
        {
            grdSalidas.set_ColW(s_Id, 0);
            grdSalidas.set_ColW(s_Fecha, 0);
            grdSalidas.set_ColW(s_Caja, 40);
            grdSalidas.set_ColW(s_Caja + 1, 80);
            grdSalidas.set_ColW(s_Tipo, 50);
            grdSalidas.set_ColW(s_Tipo + 1, 90);
            grdSalidas.set_ColW(s_SubTipo, 50);
            grdSalidas.set_ColW(s_SubTipo + 1, 90);
            grdSalidas.set_ColW(s_Detalle, 50);
            grdSalidas.set_ColW(s_Descripcion, 200);
            grdSalidas.set_ColW(s_Importe, 90);
            grdSalidas.set_ColW(s_Autorizado, 50);
            grdSalidas.set_ColW(s_Fecha_Autorizado, 90);
            grdSalidas.set_ColW(s_Grupo, 0);

            grdSalidas.set_Texto(0, s_Tipo, "Tipo");
            grdSalidas.set_Texto(0, s_SubTipo, "SubTipo");
            grdSalidas.set_Texto(0, s_Detalle, "Detalle");
            grdSalidas.set_Texto(0, s_Autorizado, "Aut");
            grdSalidas.set_Texto(0, s_Fecha_Autorizado, "Aut_Fe");

            grdSalidas.Columnas[s_Importe].Style.Format = "N2";
            grdSalidas.Columnas[s_Fecha_Autorizado].Style.Format = "dd/MM/yy HH:mm";
        }

        /// <summary>
        /// Se calculan los labels tanto de las grillas como de la barra lateral.
        /// </summary>
        private void Totales()
        {
            Double t = grdEntradas.SumarCol(e_Importe, false);
            lblTotalGrillaEntrada.Text = "Total Entradas: " + t.ToString("C1");
            lblTotalEntradas.Text = t.ToString("C1");

            double Se = cEntradas.Total_AFecha(mntFecha.SelectionStart.AddDays(-1));
            double Sg = cGastos.Total_AFecha(mntFecha.SelectionStart.AddDays(-1));

            lblSaldoAnterior.Text = (Se - Sg).ToString("C1");

            Double eSaldo = t + (Se - Sg);
            lblSTotalEntradas.Text = eSaldo.ToString("C1");

            Double g = 0;
            for (int i = 1; i <= grdSalidas.Rows - 1; i++)
            {
                if (Convert.ToBoolean(grdSalidas.get_Texto(i, s_Autorizado)) == true)
                {
                    g += Convert.ToDouble(grdSalidas.get_Texto(i, s_Importe));
                }
            }
            lblTotalGrillaGastos.Text = "Total Gastos: " + g.ToString("C1");
            lblGastos.Text = g.ToString("C1");

            lblTotal.Text = (eSaldo - g).ToString("C1");
        }

        #endregion

        #region " Grilla Entradas "
        private void grdEntradas_Editado(short f, short c, object a)
        {
            if (mntFecha.SelectionStart.Date >= CD.Fecha)
            {
                cEntradas.ID = Convert.ToInt32(grdEntradas.get_Texto(f, e_Id));
                cEntradas.Fecha = mntFecha.SelectionStart.Date;

                switch (c)
                {
                    case 2: // Caja
                        cEntradas.caja.Id = Convert.ToInt32(a);
                        if (cEntradas.caja.Existe() == true)
                        {
                            grdEntradas.set_Texto(f, c, a);
                            grdEntradas.set_Texto(f, c + 1, cEntradas.caja.Nombre);
                            grdEntradas.ActivarCelda(f, e_Tipo);

                        }
                        break;
                    case 4: //Tipo
                        cEntradas.TE.Id_Tipo = Convert.ToInt32(a);
                        if (cEntradas.TE.Existe() == true)
                        {
                            grdEntradas.set_Texto(f, c, a);
                            grdEntradas.set_Texto(f, c + 1, cEntradas.TE.Nombre);
                            grdEntradas.ActivarCelda(f, e_Subtipo);

                        }
                        break;

                    case 6: // SubTipo - Suc - Cliente
                        cEntradas.TE.Id_Tipo = Convert.ToInt32(grdEntradas.get_Texto(f, e_Tipo));

                        if (cEntradas.TE.Existe() == true)
                        {
                            cEntradas.Id_SubTipoEntrada = Convert.ToInt32(a);
                            string s = cEntradas.Nombre_SubTipo();
                            if (s.Length > 0)
                            {
                                cEntradas.Descripcion = s;
                                grdEntradas.set_Texto(f, e_Subtipo, a);
                                grdEntradas.set_Texto(f, e_Descripcion, s);

                                // Es Entrega? Mostrar el form
                                if (cEntradas.TE.Es_Entrega == true)
                                {
                                    // Si es nuevo habrá que agregar el registro
                                    if (cEntradas.ID == 0) { cEntradas.Agregar(); }

                                    frmCargarEntregas fr = new frmCargarEntregas();
                                    fr.lblSuc.Text = s;
                                    fr.Detalle_Entregas.ID_Entradas = cEntradas.ID;
                                    fr.Cargar();
                                    fr.ShowDialog();
                                    grdEntradas.Focus();
                                    cEntradas.Importe = fr.Detalle_Entregas.Total_IDEntradas(cEntradas.ID);
                                    cEntradas.Actualizar();

                                    grdEntradas.set_Texto(f, e_Importe, cEntradas.Importe);

                                    if (grdEntradas.EsUltimaFila() == true) { grdEntradas.AgregarFila(); }

                                    grdEntradas.set_Texto(f + 1, e_Id, cEntradas.ID);
                                    grdEntradas.set_Texto(f + 1, e_Caja, cEntradas.caja.Id);
                                    grdEntradas.set_Texto(f + 1, e_Caja + 1, cEntradas.caja.Nombre);
                                    grdEntradas.set_Texto(f + 1, e_Fecha, cEntradas.Fecha);
                                    grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                                    grdEntradas.set_Texto(f + 1, e_Tipo + 1, grdEntradas.get_Texto(f, e_Tipo + 1));

                                    grdEntradas.ActivarCelda(f + 1, e_Subtipo);
                                }
                                else
                                {
                                    grdEntradas.ActivarCelda(f, e_Importe);
                                    if (cEntradas.ID != 0) { cEntradas.Actualizar(); }
                                }
                            }
                        }
                        break;
                    case 7: // Descripcion
                        if (cEntradas.TE.Id_Tipo != 0 & cEntradas.Id_SubTipoEntrada != 0)
                        {
                            cEntradas.Descripcion = a.ToString();
                            grdEntradas.set_Texto(f, e_Descripcion, a);
                            grdEntradas.ActivarCelda(f, e_Importe);

                            if (cEntradas.ID != 0) { cEntradas.Actualizar(); }
                        }
                        break;
                    case 8: // Importe
                        if (cEntradas.TE.Id_Tipo != 0 & cEntradas.Id_SubTipoEntrada != 0)
                        {
                            cEntradas.Fecha = mntFecha.SelectionStart.Date;

                            cEntradas.Importe = Convert.ToDouble(a);
                            grdEntradas.set_Texto(f, e_Importe, a);
                            if (grdEntradas.EsUltimaFila() == true)
                            {

                                cEntradas.Agregar();
                                grdEntradas.set_Texto(f, e_Id, Convert.ToInt32(cEntradas.ID));
                                grdEntradas.set_Texto(f, e_Fecha, Convert.ToDateTime(cEntradas.Fecha));

                                grdEntradas.AgregarFila();

                                grdEntradas.set_Texto(f + 1, e_Caja, cEntradas.caja.Id);
                                grdEntradas.set_Texto(f + 1, e_Caja + 1, cEntradas.caja.Nombre);
                                grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                                grdEntradas.set_Texto(f + 1, e_Tipo + 1, cEntradas.TE.Nombre);
                            }
                            else
                            {
                                cEntradas.Actualizar();
                            }

                            Totales();

                            grdEntradas.ActivarCelda(f + 1, e_Caja);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("La fecha se encuentra cerrada.", "Error");
            }
        }

        private void grdEntradas_CambioFila(short Fila)
        {
            Cargar_Fila(Fila);
        }

        private void Cargar_Fila(short Fila)
        {
            cEntradas.ID = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Id));
            cEntradas.Fecha = Convert.ToDateTime(grdEntradas.get_Texto(Fila, e_Fecha));
            cEntradas.caja.Id = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Caja));
            cEntradas.TE.Id_Tipo = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Tipo));
            cEntradas.Descripcion = grdEntradas.get_Texto(Fila, e_Descripcion).ToString();
        }

        private void grdEntradas_KeyUp(object sender, short e)
        {

            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (mntFecha.SelectionStart.Date >= CD.Fecha)
                {
                    if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        cEntradas.Borrar();
                        if (grdEntradas.EsUltimaFila() == true)
                        {
                            grdEntradas.Rows = 1;
                            grdEntradas.Rows = 2;
                        }
                        else
                        {
                            grdEntradas.BorrarFila();
                        }
                        Totales();
                    }
                }
                else
                {
                    MessageBox.Show("La fecha se encuentra cerrada.", "Error");
                }
            }
            else
            {
                if (e == Convert.ToInt32(Keys.F1))
                {
                    if (grdEntradas.Col < grdEntradas.get_ColIndex("Importe"))
                    {
                        frmAyuda_Entradas fayuda = new frmAyuda_Entradas();
                        Herramientas.Herramientas h = new Herramientas.Herramientas();

                        if (grdEntradas.Col == e_Caja) { fayuda.Cargar_Cajas(); }
                        if (grdEntradas.Col == e_Tipo) { fayuda.Cargar_TiposEntradas(cEntradas.TE.Id_Tipo); }
                        if (grdEntradas.Col == e_Subtipo) { fayuda.Cargar_SubTiposEntradas(cEntradas.TE.Id_Tipo); }

                        fayuda.ShowDialog();

                        if (fayuda.Valor != "")
                        {
                            grdEntradas_Editado(Convert.ToInt16(grdEntradas.Row), Convert.ToInt16(grdEntradas.Col), h.Codigo_Seleccionado(fayuda.Valor));
                        }
                        else { grdEntradas_Editado(Convert.ToInt16(grdEntradas.Row), Convert.ToInt16(grdEntradas.Col), 0); }
                    }
                }
            }

        }

        private void grdEntradas_DobleClick(object sender, EventArgs e)
        {
            if (cEntradas.ID > 0)
            {
                SendKeys.Send("{ESC}");
                Application.DoEvents();
                cEntradas.Cargar();
                frmCargarEntregas fr = new frmCargarEntregas();
                fr.Detalle_Entregas.ID_Entradas = cEntradas.ID;
                fr.lblSuc.Text = cEntradas.Descripcion;
                fr.Cargar();
                fr.ShowDialog();
                cEntradas.Importe = fr.Detalle_Entregas.Total_IDEntradas(cEntradas.ID);
                cEntradas.Actualizar();

                grdEntradas.set_Texto(grdEntradas.Row, e_Importe, cEntradas.Importe);
                this.Focus();
                grdEntradas.Focus();
            }
        }

        #endregion

        #region " Grilla Salidas "
        private void grdSalidas_Editado(short f, short c, object a)
        {
            if (mntFecha.SelectionStart.Date >= CD.Fecha)
            {
                cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(f, s_Id));
                cGastos.Fecha = mntFecha.SelectionStart.Date;

                switch (c)
                {
                    case 2: // Caja
                        cGastos.caja.Id = Convert.ToInt32(a);
                        if (cGastos.caja.Existe() == true)
                        {
                            grdSalidas.set_Texto(f, c, a);
                            grdSalidas.set_Texto(f, c + 1, cGastos.caja.Nombre);
                            grdSalidas.ActivarCelda(f, e_Tipo);

                        }
                        break;
                    case 4: //Tipo
                        cGastos.TG.Id_Tipo = Convert.ToInt32(a);
                        if (cGastos.TG.Existe() == true)
                        {
                            grdSalidas.set_Texto(f, c, a);
                            grdSalidas.set_Texto(f, c + 1, cGastos.TG.Nombre);
                            grdSalidas.ActivarCelda(f, s_SubTipo);

                        }
                        break;

                    case 6: //SubTipo - Buscar Tabla
                        cGastos.TG.Id_Tipo = Convert.ToInt32(grdSalidas.get_Texto(f, s_Tipo));

                        if (cGastos.TG.Existe() == true)
                        {
                            cGastos.Id_SubTipoGastos = Convert.ToInt32(a);
                            string s = cGastos.Nombre_SubTipo();

                            if (s.Length > 0)
                            {
                                cGastos.Desc_SubTipo = s;
                                grdSalidas.set_Texto(f, s_SubTipo, a);
                                grdSalidas.set_Texto(f, s_SubTipo + 1, s);

                                grdSalidas.ActivarCelda(f, s_Detalle);
                                if (cGastos.ID != 0) { cGastos.Actualizar(); }

                            }
                        }
                        break;
                    case 7: // Desc_SubTipo
                        if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                        {
                            cGastos.Desc_SubTipo = a.ToString();
                            grdSalidas.set_Texto(f, s_SubTipo + 1, a);
                            grdSalidas.ActivarCelda(f, s_Importe);

                            if (cGastos.ID != 0) { cGastos.Actualizar(); }
                        }
                        break;
                    case 8: //ID_Detalle
                        dg.Id_Tipo = cGastos.TG.Id_Tipo;
                        dg.ID_Detalle = Convert.ToInt32(a);

                        if (dg.Existe() == true)
                        {
                            cGastos.Id_DetalleGastos = Convert.ToInt32(a);

                            if (dg.Nombre.Length > 0)
                            {
                                cGastos.Descripcion = dg.Nombre;
                                grdSalidas.set_Texto(f, s_Detalle, a);
                                grdSalidas.set_Texto(f, s_Descripcion, dg.Nombre);

                                grdSalidas.ActivarCelda(f, c + 1);
                                if (cGastos.ID != 0) { cGastos.Actualizar(); }

                            }
                        }
                        break;
                    case 9: // Descripcion
                        if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                        {
                            cGastos.Descripcion = a.ToString();
                            grdSalidas.set_Texto(f, s_Descripcion, a);
                            grdSalidas.ActivarCelda(f, s_Importe);

                            if (cGastos.ID != 0) { cGastos.Actualizar(); }
                        }
                        break;
                    case 10: // Importe
                        if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                        {
                            cGastos.Fecha = mntFecha.SelectionStart.Date;
                            cGastos.Desc_SubTipo = grdSalidas.get_Texto(f, s_SubTipo + 1).ToString();
                            cGastos.Descripcion = grdSalidas.get_Texto(f, s_Descripcion).ToString();
                            cGastos.Importe = Convert.ToDouble(a);
                            grdSalidas.set_Texto(f, s_Importe, a);

                            if (grdSalidas.EsUltimaFila() == true)
                            {
                                cGastos.Agregar();
                                grdSalidas.set_Texto(f, s_Id, Convert.ToInt32(cGastos.ID));
                                grdSalidas.set_Texto(f, s_Fecha, Convert.ToDateTime(cGastos.Fecha));

                                grdSalidas.AgregarFila();
                                                                
                                switch (o_Repetir)
                                {
                                    case t_Repetir.Caja:
                                        grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.Id);
                                        grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                                        grdSalidas.ActivarCelda(f + 1, s_Tipo);
                                        break;
                                    case t_Repetir.Tipo:
                                        grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.Id);
                                        grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                                        grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                                        grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                                        grdSalidas.ActivarCelda(f + 1, s_SubTipo);
                                        break;
                                    case t_Repetir.SubTipo:
                                        grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.Id);
                                        grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                                        grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                                        grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                                        grdSalidas.set_Texto(f + 1, s_SubTipo, cGastos.Id_SubTipoGastos);
                                        grdSalidas.set_Texto(f + 1, s_SubTipo + 1, cGastos.Desc_SubTipo);
                                        grdSalidas.ActivarCelda(f + 1, s_Detalle);
                                        break;
                                    case t_Repetir.Detalle:
                                        grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.Id);
                                        grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                                        grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                                        grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                                        grdSalidas.set_Texto(f + 1, s_SubTipo, cGastos.Id_SubTipoGastos);
                                        grdSalidas.set_Texto(f + 1, s_SubTipo + 1, cGastos.Desc_SubTipo);
                                        grdSalidas.set_Texto(f + 1, s_Detalle, cGastos.Id_DetalleGastos);
                                        grdSalidas.set_Texto(f + 1, s_Detalle + 1, cGastos.Desc_Detalle);
                                        grdSalidas.ActivarCelda(f + 1, s_Descripcion);
                                        break;
                                    default:
                                        grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.Id);
                                        grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                                        grdSalidas.ActivarCelda(f + 1, s_Tipo);
                                        break;

                                }
                            }
                            else
                            {
                                cGastos.Actualizar();
                            }

                            Totales();

                        }
                        break;
                    case 11: // Autorizacion
                        if (cGastos.ID != 0)
                        {
                            cGastos.Autorizado = Convert.ToBoolean(a);
                            cGastos.Fecha_Autorizado = DateTime.Now;
                            cGastos.Actualizar();

                            grdSalidas.set_Texto(f, s_Autorizado, a);
                            grdSalidas.set_Texto(f, s_Autorizado + 1, DateTime.Now);

                            Totales();

                            grdSalidas.ActivarCelda(f + 1, c);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("La fecha se encuentra cerrada.", "Error");
            }
            lblUltimo.Text = "";
        }

        private void grdSalidas_CambioFila(short Fila)
        {
            cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Id));
            cGastos.Fecha = Convert.ToDateTime(grdSalidas.get_Texto(Fila, s_Fecha));
            cGastos.caja.Id = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Caja));
            cGastos.TG.Id_Tipo = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Tipo));
            cGastos.Id_SubTipoGastos = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_SubTipo));
            cGastos.Desc_SubTipo = Convert.ToString(grdSalidas.get_Texto(Fila, s_SubTipo + 1));
            cGastos.Id_DetalleGastos = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Detalle));
            cGastos.Descripcion = Convert.ToString(grdSalidas.get_Texto(Fila, s_Descripcion));
            cGastos.Importe = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Importe));
        }

        private void grdSalidas_KeyUp(object sender, short e)
        {
            int fila = grdSalidas.Row;

            if (e == Convert.ToInt32(Keys.F9))
            {
                DataTable dt = cGastos.Ultimo_Valor();
                if (dt != null & dt.Rows.Count > 0)
                {
                    lblUltimo.Text = $"F: {dt.Rows[0][0]:dd/MM/yyy} Imp: {dt.Rows[0][1]:N1}";
                }
                else
                {
                    lblUltimo.Text = "No encontrado.";
                }
            }
            if (e == Convert.ToInt32(Keys.Enter))
            {
                if (grdSalidas.Col == s_Importe) { grdSalidas.ActivarCelda(fila + 1, s_Tipo); }
                else
                {
                    if (grdSalidas.Col == s_Detalle) { grdSalidas.ActivarCelda(fila, s_Detalle + 1); }
                    if (grdSalidas.Col == s_Detalle + 1) { grdSalidas.ActivarCelda(fila, s_Importe); }
                    if (grdSalidas.Col == s_Detalle) { grdSalidas.ActivarCelda(fila, s_Importe); }
                    if (grdSalidas.Col == s_SubTipo) { grdSalidas.ActivarCelda(fila, s_Detalle); }
                    if (grdSalidas.Col == s_Tipo) { grdSalidas.ActivarCelda(fila, s_SubTipo); }
                    if (grdSalidas.Col == s_Caja) { grdSalidas.ActivarCelda(fila, s_Tipo); }
                }
            }
            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (mntFecha.SelectionStart.Date >= CD.Fecha)
                {
                    if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        cGastos.Borrar();
                        if (grdSalidas.EsUltimaFila() == true)
                        {
                            grdSalidas.Rows = 1;
                            grdSalidas.Rows = 2;
                        }
                        else
                        {
                            grdSalidas.BorrarFila();
                        }
                        Totales();
                    }
                }
                else
                {
                    MessageBox.Show("La fecha se encuentra cerrada.", "Error");
                }
            }
            if (e == Convert.ToInt32(Keys.F1))
            {
                frmAyuda_Gastos fayuda = new frmAyuda_Gastos();
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (grdSalidas.Col == s_Caja) { fayuda.Cargar_Cajas(); }
                if (grdSalidas.Col == s_Tipo) { fayuda.Cargar_TiposGastos(cGastos.TG.Id_Tipo); }
                if (grdSalidas.Col == s_SubTipo) { fayuda.Cargar_SubTiposGastos(cGastos.TG.Id_Tipo); }
                if (grdSalidas.Col == s_Detalle) { fayuda.Cargar_Detalles(cGastos.TG.Id_Tipo); }

                fayuda.ShowDialog();

                if (fayuda.Valor != "")
                {
                    if (grdSalidas.Col == s_Caja)
                    {
                        cGastos.caja.Id = h.Codigo_Seleccionado(fayuda.Valor);
                        if (cGastos.caja.Existe() == true)
                        {
                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Caja, cGastos.caja.Id);
                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Caja + 1, cGastos.caja.Nombre);
                            grdSalidas.ActivarCelda(grdSalidas.Row, s_Tipo);
                        }
                    }
                    else
                    {
                        if (grdSalidas.Col == s_Tipo)
                        {
                            cGastos.TG.Id_Tipo = h.Codigo_Seleccionado(fayuda.Valor);
                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Tipo, cGastos.TG.Id_Tipo);
                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Tipo + 1, cGastos.TG.Nombre);
                            grdSalidas.ActivarCelda(grdSalidas.Row, s_SubTipo);
                        }
                        else
                        {
                            if (grdSalidas.Col == s_SubTipo)
                            {
                                cGastos.Id_SubTipoGastos = h.Codigo_Seleccionado(fayuda.Valor);
                                grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_SubTipo, cGastos.Id_SubTipoGastos);
                                grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_SubTipo + 1, h.Nombre_Seleccionado(fayuda.Valor));
                                grdSalidas.ActivarCelda(grdSalidas.Row, s_Detalle);
                            }
                            else
                            {
                                if (grdSalidas.Col == s_Detalle)
                                {
                                    cGastos.Id_DetalleGastos = h.Codigo_Seleccionado(fayuda.Valor);
                                    grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Detalle, cGastos.Id_DetalleGastos);
                                    grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Descripcion, h.Nombre_Seleccionado(fayuda.Valor));
                                    grdSalidas.ActivarCelda(grdSalidas.Row, s_Descripcion);
                                }
                            }
                        }
                    }
                }
            }
        }


        #endregion

        #region " Menu contextual Entradas "
        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdEntradas_KeyUp(null, Convert.ToInt16(Keys.Delete));
        }

        private void cambiarFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaFecha fr = new frmNuevaFecha();
            fr.ShowDialog();
            if (fr.Aceptado == true)
            {
                int fIni = grdEntradas.Selection.r1;
                int fFin = grdEntradas.Selection.r2;
                for (int i = fIni; i <= fFin; i++)
                {
                    Cargar_Fila(Convert.ToInt16(i));
                    cEntradas.Fecha = fr.mntFecha.SelectionStart.Date;
                    cEntradas.Actualizar();
                }
                Cargar_Datos();
            }
        }


        #endregion

       
    }
}
