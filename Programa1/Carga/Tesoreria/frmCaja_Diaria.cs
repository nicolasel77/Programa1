
namespace Programa1.Carga.Tesoreria
{
    using global::Proveedores;
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmCaja_Diaria : Form
    {
        readonly Usuarios usuario;
        private enum t_Repetir : int
        {
            Ninguno = 0,
            Caja = 1,
            Tipo = 2,
            SubTipo = 3,
            Detalle = 4
        }
        private t_Repetir o_Repetir;
        private DateTime fdd;
        /// <summary>
        /// Caja Diaria
        /// </summary>
        private readonly Caja_Diaria CD = new Caja_Diaria();

        #region " Columnas Entradas "
        private const Byte e_Id = 0;
        private const Byte e_Fecha = 1;
        private const Byte e_Caja = 2;
        private const Byte e_Tipo = 4;
        private const Byte e_Subtipo = 6;
        private const Byte e_Descripcion = 7;
        private const Byte e_Importe = 8;
        private const Byte e_Grupo = 9;
        private const Byte e_Es_Entrega = 10;
        private const Byte e_Tabla = 11;
        private const Byte e_Cheque = 12;

        #endregion
        #region " Columnas Salidas "
        private const Byte s_Id = 0;
        private const Byte s_Fecha = 1;
        private const Byte s_Caja = 2;
        private const Byte s_Tipo = 4;
        private const Byte s_SubTipo = 6;
        private const Byte s_IDDetalle = 8;
        private const Byte s_Descripcion = 9;
        private const Byte s_Importe = 10;
        private const Byte s_Cheque = 11;
        private const Byte s_Autorizado = 12;
        private const Byte s_Fecha_Autorizado = 13;
        private const Byte s_Grupo = 14;
        private const Byte s_Usuario = 15;

        #endregion


        /// <summary>
        /// Caja Diaria Entradas
        /// </summary>
        private readonly Entradas cEntradas = new Entradas();
        /// <summary>
        /// Caja Diaria Gastos
        /// </summary>

        private readonly Gastos cGastos = new Gastos();
        private readonly Detalle_Gastos dg = new Detalle_Gastos();


        #region " FORM "

        public frmCaja_Diaria(Usuarios user)
        {
            usuario = user;
            cGastos.Usuario.ID = user.ID;
            InitializeComponent();
        }

        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            CD.Usuario = usuario.ID;
            mntFecha.SetDate(CD.Fecha);
            //mntFecha.MaxDate = CD.Fecha;

            Cargar_Datos();

            //*****************************
            //*********Entradas************
            //*****************************

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

            // 13: Enter
            // 43: +
            // 45: -
            // 46: Delete
            //112: F1
            grdSalidas.TeclasManejadas = new int[] { 13, 42, 43, 45, 46, 47, 106, 111, 112, 120 };

            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Add), s_Caja, s_Tipo, s_SubTipo, s_IDDetalle, s_Importe);
            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), s_Caja, s_Tipo, s_SubTipo, s_IDDetalle, s_Importe);

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
            if (fr.OK == true)
            {
                Herramientas.Herramientas h = new Herramientas.Herramientas();
                int cDesde = h.Codigo_Seleccionado(fr.lstDesde.Text);
                int cHacia = h.Codigo_Seleccionado(fr.lstHacia.Text);
                int cARendir = h.Codigo_Seleccionado(fr.lstARendir.Text);

                cGastos.ID = 0;
                cGastos.Fecha = mntFecha.SelectionStart.Date;
                cGastos.caja.ID = cDesde;
                cGastos.TG.Id_Tipo = 100;
                cGastos.Id_SubTipoGastos = cHacia;
                cGastos.Desc_SubTipo = h.Nombre_Seleccionado(fr.lstHacia.Text);
                cGastos.Importe = Convert.ToDouble(fr.txtImporte.Text);
                if (cHacia == 12)
                {
                    cGastos.Id_DetalleGastos = cARendir;
                    cGastos.Descripcion = h.Nombre_Seleccionado(fr.lstARendir.Text); ;
                }
                else
                {
                    cGastos.Id_DetalleGastos = 0;
                    cGastos.Descripcion = "Transferencia";
                }

                cGastos.Usuario = usuario;
                cGastos.Agregar();

                cEntradas.ID = 0;
                cEntradas.Fecha = mntFecha.SelectionStart.Date;
                cEntradas.caja.ID = cHacia;
                cEntradas.TE.Id_Tipo = 100;
                cEntradas.Id_SubTipoEntrada = cDesde;
                cEntradas.Descripcion = "Desde la caja: " + h.Nombre_Seleccionado(fr.lstDesde.Text);
                cEntradas.Importe = Convert.ToDouble(fr.txtImporte.Text);

                cEntradas.Agregar();

                Cargar_Datos();
            }
        }

        private void rdCajas_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_Cajas();
        }

        private void aRendirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResumenARendir fr = new frmResumenARendir();
            fr.ShowDialog();

        }

        private void cmdCheques_Click(object sender, EventArgs e)
        {
            frmCheques fr = new frmCheques();
            fr.Nuevo_Cheque = true;
            fr.Cargar();
            fr.ShowDialog();
        }
        #endregion

        #region " SUBS "
        private void Cargar_Datos()
        {
            this.Cursor = Cursors.WaitCursor;

            grdEntradas.Visible = false;
            grdEntradas.MostrarDatos(cEntradas.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            grdEntradas.ActivarCelda(grdEntradas.Rows - 1, e_Caja);
            Formato_Entradas();
            grdEntradas.Visible = true;

            grdSalidas.MostrarDatos(cGastos.Datos_Vista($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            grdSalidas.ActivarCelda(grdSalidas.Rows - 1, s_Caja);
            Formato_Salidas();


            Totales();
            Cargar_Cajas();
            this.Cursor = Cursors.Default;
        }

        private void Cargar_Cajas()
        {
            if (rdCajas.Checked == true)
            {
                grdCajas.MostrarDatos(CD.Saldos(mntFecha.SelectionStart.Date), true, 2);
                grdCajas.Columnas[2].Style.Format = "N1";
            }
            else
            {
                grdCajas.MostrarDatos(CD.Saldos_ARendir(mntFecha.SelectionStart.Date), true, 2);
                grdCajas.Columnas[2].Style.Format = "N1";
            }
            grdCajas.AutosizeAll();
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
            grdEntradas.set_ColW(e_Cheque, 0);

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
            grdSalidas.set_ColW(s_IDDetalle, 50);
            grdSalidas.set_ColW(s_Descripcion, 400);
            grdSalidas.set_ColW(s_Importe, 90);
            grdSalidas.set_ColW(s_Autorizado, 50);
            grdSalidas.set_ColW(s_Fecha_Autorizado, 90);
            grdSalidas.set_ColW(s_Grupo, 0);
            grdSalidas.set_ColW(s_Cheque, 0);
            grdSalidas.set_ColW(s_Usuario, 0);

            grdSalidas.set_Texto(0, s_Tipo, "Tipo");
            grdSalidas.set_Texto(0, s_SubTipo, "SubTipo");
            grdSalidas.set_Texto(0, s_IDDetalle, "Detalle");
            grdSalidas.set_Texto(0, s_Autorizado, "Aut");
            grdSalidas.set_Texto(0, s_Fecha_Autorizado, "Aut_Fe");

            grdSalidas.Columnas[s_Importe].Style.Format = "N2";
            grdSalidas.Columnas[s_Fecha_Autorizado].Style.Format = "dd/MM/yy HH:mm";

            C1.Win.C1FlexGrid.CellStyle cellStyle = grdSalidas.Styles.Add("Otro_User");
            cellStyle.BackColor = Color.MistyRose;

            for (int i = 1; i <= grdSalidas.Rows - 2; i++)
            {
                if (Convert.ToInt32(grdSalidas.get_Texto(i, s_Usuario)) != usuario.ID)
                {
                    grdSalidas.Filas[i].Style = cellStyle;
                }
                else
                {
                    grdSalidas.Filas[i].Style = null;
                }
            }
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

                if (cEntradas.Fecha_Cerrada() == false)
                {
                    switch (c)
                    {
                        case e_Caja:
                            cEntradas.caja.ID = Convert.ToInt32(a);
                            if (cEntradas.caja.Existe() == true)
                            {
                                grdEntradas.set_Texto(f, c, a);
                                grdEntradas.set_Texto(f, c + 1, cEntradas.caja.Nombre);
                                grdEntradas.ActivarCelda(f, e_Tipo);
                                if (cEntradas.ID > 0)
                                {
                                    cEntradas.Actualizar();
                                }
                            }
                            break;
                        case e_Tipo:
                            cEntradas.TE.Id_Tipo = Convert.ToInt32(a);
                            if (cEntradas.TE.Existe() == true)
                            {
                                grdEntradas.set_Texto(f, c, a);
                                grdEntradas.set_Texto(f, c + 1, cEntradas.TE.Nombre);
                                grdEntradas.ActivarCelda(f, e_Subtipo);

                            }
                            break;

                        case e_Subtipo: // SubTipo - Suc - Cliente
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
                                        if (fdd > Convert.ToDateTime("1/1/1910")) { fr.fdd = fdd; }
                                        fr.Cargar();
                                        fr.ShowDialog();
                                        grdEntradas.Focus();
                                        if (fr.fdd > Convert.ToDateTime("1/1/1910")) { fdd = fr.fdd; }
                                        cEntradas.Importe = fr.Detalle_Entregas.Total_IDEntradas(cEntradas.ID);
                                        cEntradas.Actualizar();

                                        grdEntradas.set_Texto(f, e_Importe, cEntradas.Importe);
                                        grdEntradas.set_Texto(f, e_Id, cEntradas.ID);

                                        if (grdEntradas.EsUltimaFila() == true) { grdEntradas.AgregarFila(); }


                                        grdEntradas.set_Texto(f + 1, e_Caja, cEntradas.caja.ID);
                                        grdEntradas.set_Texto(f + 1, e_Caja + 1, cEntradas.caja.Nombre);
                                        grdEntradas.set_Texto(f + 1, e_Fecha, cEntradas.Fecha);
                                        grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                                        grdEntradas.set_Texto(f + 1, e_Tipo + 1, grdEntradas.get_Texto(f, e_Tipo + 1));

                                        grdEntradas.ActivarCelda(f + 1, e_Subtipo);
                                        Totales();
                                    }
                                    else
                                    {
                                        if (cEntradas.caja.EsCheque == true)
                                        {
                                            Cheques ch = new Cheques();
                                            ch.Cargar_Nuevo();
                                            if (ch.Numero != 0)
                                            {
                                                cEntradas.Cheque = ch.Numero;
                                                cEntradas.Descripcion = $"{s} CH {ch.Banco.Nombre}  FAc: {ch.Fecha_Acreditacion:dd/MM/yy}";
                                                cEntradas.Importe = ch.Importe;

                                                grdEntradas.Focus();
                                                grdEntradas.set_Texto(f, e_Descripcion, cEntradas.Descripcion);
                                                grdEntradas.set_Texto(f, e_Importe, cEntradas.Importe);
                                                grdEntradas.set_Texto(f, e_Cheque, cEntradas.Cheque);
                                                grdEntradas.set_Texto(f, e_Id, cEntradas.ID);

                                                if (cEntradas.ID == 0) { cEntradas.Agregar(); } else { cEntradas.Actualizar(); }
                                                if (grdEntradas.EsUltimaFila() == true) { grdEntradas.AgregarFila(); }

                                                grdEntradas.set_Texto(f + 1, e_Caja, cEntradas.caja.ID);
                                                grdEntradas.set_Texto(f + 1, e_Caja + 1, cEntradas.caja.Nombre);
                                                grdEntradas.set_Texto(f + 1, e_Fecha, cEntradas.Fecha);
                                                grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                                                grdEntradas.set_Texto(f + 1, e_Tipo + 1, grdEntradas.get_Texto(f, e_Tipo + 1));

                                                grdEntradas.ActivarCelda(f + 1, e_Subtipo);
                                            }

                                        }
                                        else
                                        {
                                            grdEntradas.ActivarCelda(f, e_Importe);
                                            if (cEntradas.ID != 0) { cEntradas.Actualizar(); }
                                        }

                                    }
                                }
                            }
                            break;
                        case e_Descripcion:
                            if (cEntradas.TE.Id_Tipo != 0 & cEntradas.Id_SubTipoEntrada != 0)
                            {
                                cEntradas.Descripcion = a.ToString();
                                grdEntradas.set_Texto(f, e_Descripcion, a);
                                grdEntradas.ActivarCelda(f, e_Importe);

                                if (cEntradas.ID != 0) { cEntradas.Actualizar(); }
                            }
                            break;
                        case e_Importe:
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

                                    grdEntradas.set_Texto(f + 1, e_Caja, cEntradas.caja.ID);
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
            }
            else
            {
                MessageBox.Show("La fecha se encuentra cerrada.", "Error");
            }
        }

        private void grdEntradas_CambioFila(short Fila)
        {
            Cargar_FilaEntradas(Fila);
        }

        private void Cargar_FilaEntradas(short Fila)
        {
            cEntradas.ID = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Id));
            cEntradas.Fecha = Convert.ToDateTime(grdEntradas.get_Texto(Fila, e_Fecha));
            cEntradas.caja.ID = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Caja));
            cEntradas.TE.Id_Tipo = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Tipo));
            cEntradas.Id_SubTipoEntrada = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Subtipo));
            cEntradas.Descripcion = grdEntradas.get_Texto(Fila, e_Descripcion).ToString();
            cEntradas.Importe = Convert.ToDouble(grdEntradas.get_Texto(Fila, e_Importe));
        }

        private void grdEntradas_KeyUp(object sender, short e)
        {

            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (mntFecha.SelectionStart.Date >= CD.Fecha)
                {
                    if (cEntradas.Fecha_Cerrada() == false)
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
                            Cargar_FilaEntradas(Convert.ToByte(grdEntradas.Row));
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
                Totales();
                this.Focus();
                grdEntradas.Focus();
            }
        }

        #endregion

        #region " Grilla Salidas "
        private void grdSalidas_Editado(short f, short c, object a)
        {
            if (cGastos.Usuario.ID == 0 | usuario.ID == cGastos.Usuario.ID | usuario.Permiso == Usuarios.e_Permiso.Administrador)
            {
                if (mntFecha.SelectionStart.Date >= CD.Fecha | usuario.Permiso == Usuarios.e_Permiso.Administrador)
                {
                    cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(f, s_Id));
                    cGastos.Fecha = mntFecha.SelectionStart.Date;
                    if (cGastos.Fecha_Cerrada() == false)
                    {
                        switch (c)
                        {
                            case s_Caja:
                                cGastos.caja.ID = Convert.ToInt32(a);
                                if (cGastos.caja.Existe() == true)
                                {
                                    grdSalidas.set_Texto(f, c, a);
                                    grdSalidas.set_Texto(f, c + 1, cGastos.caja.Nombre);

                                    if (cGastos.caja.EsARendir == true) { cGastos.caja.Seleccionar_Nombre(); }

                                    if (cGastos.ID != 0) { cGastos.Actualizar("ID_Caja", cGastos.caja.ID); Cargar_Cajas(); }

                                    grdSalidas.ActivarCelda(f, e_Tipo);

                                }
                                break;
                            case s_Tipo:
                                cGastos.TG.Id_Tipo = Convert.ToInt32(a);
                                if (cGastos.TG.Existe() == true)
                                {
                                    grdSalidas.set_Texto(f, c, a);
                                    grdSalidas.set_Texto(f, c + 1, cGastos.TG.Nombre);

                                    if (cGastos.ID == 0)
                                    {
                                        grdSalidas.set_Texto(f, s_SubTipo, 0);
                                        grdSalidas.set_Texto(f, s_SubTipo + 1, "");
                                        grdSalidas.set_Texto(f, s_IDDetalle, 0);
                                        grdSalidas.set_Texto(f, s_IDDetalle + 1, "");
                                    }
                                    else
                                    {
                                        cGastos.Actualizar("ID_TipoGastos", a);
                                    }

                                    grdSalidas.ActivarCelda(f, s_SubTipo);

                                }
                                break;

                            case s_SubTipo: //SubTipo - Buscar Tabla
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

                                        if (cGastos.TG.EsHacienda == true)
                                        {
                                            Seleccionar_Pago_Hacienda();
                                        }
                                        else
                                        {
                                            if (cGastos.TG.EsAgregados == true)
                                            {
                                                Seleccionar_Pago_Agregados();
                                            }
                                            else
                                            {
                                                grdSalidas.ActivarCelda(f, s_IDDetalle);
                                                if (cGastos.ID != 0) { cGastos.Actualizar(); }
                                                // ESTO LO TILDO PARA VER MAS ADELANTE SI LO QUIEREN ASÍ O SOLO CON F1
                                                //if (cGastos.TG.EsPagoProveedor == true)
                                                //{
                                                //    Seleccionar_Pago_Proveedor();
                                                //}
                                                //else
                                                //{
                                                //    grdSalidas.ActivarCelda(f, s_IDDetalle);
                                                //    if (cGastos.ID != 0) { cGastos.Actualizar(); }
                                                //}
                                            }
                                        }

                                    }
                                }
                                break;
                            case s_SubTipo + 1: // Desc_SubTipo
                                if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                                {
                                    cGastos.Desc_SubTipo = a.ToString();
                                    grdSalidas.set_Texto(f, s_SubTipo + 1, a);
                                    grdSalidas.ActivarCelda(f, s_IDDetalle);

                                    if (cGastos.ID != 0) { cGastos.Actualizar("Desc_SubTipo", cGastos.Desc_SubTipo); }
                                }
                                break;
                            case s_IDDetalle:
                                dg.Id_Tipo = cGastos.TG.Id_Tipo;
                                if (cGastos.TG.EsHacienda == false && cGastos.TG.EsAgregados == false)
                                {
                                    dg.ID_Detalle = Convert.ToInt32(a);

                                    if (dg.Existe() == true)
                                    {
                                        cGastos.Id_DetalleGastos = Convert.ToInt32(a);

                                        if (dg.Nombre.Length > 0)
                                        {
                                            cGastos.Descripcion = dg.Nombre;
                                            grdSalidas.set_Texto(f, s_IDDetalle, a);
                                            grdSalidas.set_Texto(f, s_Descripcion, dg.Nombre);

                                            if (cGastos.caja.EsCheque == true)
                                            {
                                                //Chequess
                                                Cheques ch = new Cheques();
                                                ch.Seleccionar_Cheques();
                                                cGastos.Usuario = usuario;
                                                foreach (Cheques cn in ch.cheques_seleccionados)
                                                {
                                                    // Agregar registro por cada cheque.
                                                    cGastos.Importe = cn.Importe;
                                                    cGastos.Cheque = cn.Numero;
                                                    cGastos.Agregar();
                                                }
                                                if (ch.cheques_seleccionados.Count != 0) { Cargar_Datos(); }
                                                grdSalidas.ActivarCelda(grdSalidas.Rows - 1, s_Caja);
                                            }
                                            else
                                            {
                                                grdSalidas.ActivarCelda(f, c + 1);
                                                if (cGastos.ID != 0) { cGastos.Actualizar(); }
                                            }
                                        }
                                    }
                                }
                                break;
                            case s_Descripcion:
                                if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                                {
                                    cGastos.Descripcion = a.ToString();
                                    grdSalidas.set_Texto(f, s_Descripcion, a);
                                    grdSalidas.ActivarCelda(f, s_Importe);

                                    if (cGastos.ID != 0) { cGastos.Actualizar("Descripcion", cGastos.Descripcion); }
                                }
                                break;
                            case s_Importe:
                                if (cGastos.TG.EsHacienda == false && cGastos.TG.EsAgregados == false)
                                {
                                    if (cGastos.TG.Id_Tipo != 0 && cGastos.Id_SubTipoGastos != 0)
                                    {
                                        cGastos.Fecha = mntFecha.SelectionStart.Date;
                                        cGastos.Desc_SubTipo = grdSalidas.get_Texto(f, s_SubTipo + 1).ToString();
                                        cGastos.Descripcion = grdSalidas.get_Texto(f, s_Descripcion).ToString();
                                        cGastos.Importe = Convert.ToDouble(a);
                                        grdSalidas.set_Texto(f, s_Importe, a);

                                        if (grdSalidas.EsUltimaFila() == true)
                                        {
                                            cGastos.Usuario = usuario;
                                            cGastos.Agregar();
                                            grdSalidas.set_Texto(f, s_Id, Convert.ToInt32(cGastos.ID));
                                            grdSalidas.set_Texto(f, s_Fecha, Convert.ToDateTime(cGastos.Fecha));

                                            grdSalidas.AgregarFila();
                                            Repetir_FilaG();
                                        }
                                        else
                                        {
                                            cGastos.Actualizar("Importe", cGastos.Importe);
                                            if (cGastos.TG.EsHacienda == true)
                                            {
                                                Compra_Hacienda ch = new Compra_Hacienda();
                                                ch.Consignatario.ID = cGastos.Id_SubTipoGastos;
                                                int n = Convert.ToInt32(ch.Dato("ID_CompraFrigo=" + cGastos.Id_DetalleGastos, "NBoleta", ""));
                                                ch.NBoleta.ID = n;
                                                ch.Calcular_Saldo();
                                            }
                                            if (cGastos.TG.EsAgregados == true)
                                            {
                                                Agregados_Hacienda ah = new Agregados_Hacienda();
                                                ah.Consignatario.ID = cGastos.Id_SubTipoGastos;
                                                int n = Convert.ToInt32(ah.Dato("ID_Agregados_Frigo=" + cGastos.Id_DetalleGastos, "NBoleta", ""));
                                                ah.nb.ID = n;

                                                ah.Calcular_Saldo();
                                            }
                                        }

                                        Totales();

                                    }
                                }
                                else
                                {
                                    grdSalidas.ActivarCelda(f, s_Tipo);
                                }
                                break;
                            case s_Autorizado:
                                if (cGastos.ID != 0)
                                {
                                    cGastos.Autorizado = Convert.ToBoolean(a);
                                    cGastos.Fecha_Autorizado = DateTime.Now;

                                    cGastos.Actualizar("Autorizado", cGastos.Autorizado);
                                    cGastos.Actualizar("Fecha_Autorizado", DateTime.Now);
                                    cGastos.Actualizar("Usuario", cGastos.Usuario.ID);

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
                }
                else
                {
                    MessageBox.Show("La fecha se encuentra cerrada.", "Error");
                } 
            }
            else
            {
                MessageBox.Show("No se puede modificar un registro de otro usuario.", "Error");
            }
            lblUltimo.Text = "";
        }

        private void grdSalidas_CambioFila(short Fila)
        {
            Cargar_FilaSalida(Fila);
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
            if (e == Convert.ToInt32(Keys.Multiply))
            {
                if (rdNinguno.Checked == true)
                {
                    rdCaja.Checked = true;
                }
                else
                {
                    if (rdCaja.Checked == true)
                    {
                        rdTipo.Checked = true;
                    }
                    else
                    {
                        if (rdTipo.Checked == true)
                        {
                            rdSubtipo.Checked = true;
                        }
                        else
                        {
                            if (rdSubtipo.Checked == true)
                            {
                                rdDetalle.Checked = true;
                            }
                            else
                            {
                                if (rdDetalle.Checked == true) { rdNinguno.Checked = true; }
                            }
                        }
                    }
                }
            }
            if (e == Convert.ToInt32(Keys.Divide))
            {
                if (rdNinguno.Checked == true)
                {
                    rdDetalle.Checked = true;
                }
                else
                {
                    if (rdCaja.Checked == true)
                    {
                        rdNinguno.Checked = true;
                    }
                    else
                    {
                        if (rdTipo.Checked == true)
                        {
                            rdCaja.Checked = true;
                        }
                        else
                        {
                            if (rdSubtipo.Checked == true)
                            {
                                rdTipo.Checked = true;
                            }
                            else
                            {
                                if (rdDetalle.Checked == true) { rdSubtipo.Checked = true; }
                            }
                        }
                    }
                }
            }
            if (e == Convert.ToInt32(Keys.Enter))
            {
                if (grdSalidas.Col == s_Importe) { grdSalidas.ActivarCelda(fila + 1, s_Tipo); }
                else
                {
                    int columna = grdSalidas.Col;
                    if (grdSalidas.Row == grdSalidas.Rows - 1 & grdSalidas.Rows > 2 & columna != s_IDDetalle + 1)
                    {
                        object a;
                                                
                        a = grdSalidas.get_Texto(fila - 1, columna);

                        grdSalidas_Editado(Convert.ToInt16(fila), Convert.ToInt16(columna), a);
                    }
                    else
                    {
                        if (columna == s_Importe) { grdSalidas.ActivarCelda(fila, s_Caja); }
                        if (columna == s_IDDetalle + 1) { grdSalidas.ActivarCelda(fila, s_Importe); }
                        if (columna == s_IDDetalle) { grdSalidas.ActivarCelda(fila, s_IDDetalle + 1); }
                        if (columna == s_SubTipo) { grdSalidas.ActivarCelda(fila, s_IDDetalle); }
                        if (columna == s_Tipo) { grdSalidas.ActivarCelda(fila, s_SubTipo); }
                        if (columna == s_Caja) { grdSalidas.ActivarCelda(fila, s_Tipo); }
                    }
                }
            }
            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (cGastos.Usuario.ID == 0 | usuario.ID == cGastos.Usuario.ID | usuario.Permiso == Usuarios.e_Permiso.Administrador)
                {
                    if (mntFecha.SelectionStart.Date >= CD.Fecha | usuario.Permiso == Usuarios.e_Permiso.Administrador)
                    {
                        if (cGastos.Fecha_Cerrada() == false)
                        {
                            if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                cGastos.Borrar();
                                if (grdSalidas.EsUltimaFila() == true)
                                {
                                    grdSalidas.BorrarFila(grdSalidas.Rows - 1);
                                    grdSalidas.AgregarFila();
                                    grdSalidas.ActivarCelda(grdSalidas.Rows - 1, s_Caja);
                                }
                                else
                                {
                                    grdSalidas.BorrarFila();
                                    grdSalidas.ActivarCelda(fila, s_Caja);
                                    Cargar_FilaSalida(fila);
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
                        MessageBox.Show("La fecha se encuentra cerrada.", "Error");
                    } 
                }
            }
            if (e == Convert.ToInt32(Keys.F1))
            {
                /* Pagos Autorizados */
                if (grdSalidas.Col == s_Importe | grdSalidas.Col == s_Descripcion)
                {
                    frmSeleccionar_PagosAutorizados fr = new frmSeleccionar_PagosAutorizados();
                    fr.Cargar(cGastos.Id_SubTipoGastos);
                    fr.Text = cGastos.Desc_SubTipo;
                    fr.ShowDialog();
                    if (fr.Aceptado == true)
                    {
                        // Recordar la fila para activar la celda luego
                        int n = fila;

                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        for (int i = 1; i < fr.grd.Rows; i++)
                        {
                            if (Convert.ToBoolean(fr.grd.get_Texto(i, 0)) == true)
                            {
                                cGastos.Descripcion = $"Compra:  {Convert.ToDateTime(fr.grd.get_Texto(i, fr.grd.get_ColIndex("Fecha"))):yyyy-MM-dd}";
                                cGastos.Importe = Convert.ToDouble(fr.grd.get_Texto(i, fr.grd.get_ColIndex("Saldo"))) * -1;
                                //cGastos.Fecha_Acreditacion = 

                                // Esto es por si se esta editando un registro existente
                                if (cGastos.ID > 0)
                                {
                                    cGastos.Actualizar();
                                }
                                else
                                {
                                    cGastos.Usuario = usuario;
                                    cGastos.Agregar();
                                }
                                // Luego ya se agregan nuevos registros
                                cGastos.ID = 0;
                                n += 1;
                            }
                        }
                        Cargar_Datos();
                        grdSalidas.ActivarCelda(n + 1, s_Caja);
                        this.Focus();
                    }
                }
                else
                {
                    frmAyuda_Gastos fayuda = new frmAyuda_Gastos();
                    Herramientas.Herramientas h = new Herramientas.Herramientas();

                    if (grdSalidas.Col == s_Caja) { fayuda.Cargar_Cajas(); }
                    if (grdSalidas.Col == s_Tipo) { fayuda.Cargar_TiposGastos(cGastos.TG.Id_Tipo); }
                    if (grdSalidas.Col == s_SubTipo) { fayuda.Cargar_SubTiposGastos(cGastos.TG.Id_Tipo); }
                    if (grdSalidas.Col == s_IDDetalle) { fayuda.Cargar_Detalles(cGastos.TG.Id_Tipo); }

                    if (cGastos.TG.EsEmpleados == true & grdSalidas.Col == s_SubTipo)
                    {
                        Seleccionar_Sueldos();
                    }
                    else
                    {
                        fayuda.ShowDialog();

                        if (fayuda.Valor != "")
                        {
                            if (grdSalidas.Col == s_Caja)
                            {
                                cGastos.caja.ID = h.Codigo_Seleccionado(fayuda.Valor);
                                if (cGastos.caja.Existe() == true)
                                {
                                    grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Caja, cGastos.caja.ID);
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
                                        cGastos.Desc_SubTipo = h.Nombre_Seleccionado(fayuda.Valor);
                                        grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_SubTipo, cGastos.Id_SubTipoGastos);
                                        grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_SubTipo + 1, cGastos.Desc_SubTipo);
                                        //HORRIBLE
                                        if (cGastos.TG.EsHacienda == true)
                                        {
                                            Seleccionar_Pago_Hacienda();
                                        }
                                        else
                                        {
                                            if (cGastos.TG.EsAgregados == true)
                                            {
                                                Seleccionar_Pago_Agregados();
                                            }
                                            else
                                            {
                                                grdSalidas.ActivarCelda(grdSalidas.Row, s_IDDetalle);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (grdSalidas.Col == s_IDDetalle)
                                        {
                                            cGastos.Id_DetalleGastos = h.Codigo_Seleccionado(fayuda.Valor);
                                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_IDDetalle, cGastos.Id_DetalleGastos);
                                            grdSalidas.set_Texto(Convert.ToInt16(grdSalidas.Row), s_Descripcion, h.Nombre_Seleccionado(fayuda.Valor));
                                            grdSalidas.ActivarCelda(grdSalidas.Row, s_Descripcion);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Seleccionar_Pago_Proveedor()
        {
            // Proveedor
            CCtes_Proveedores sld = new CCtes_Proveedores();
            sld.gastos = cGastos;
            sld.Cargar_Pago();
            if (sld.Aceptado == true)
            {
                Cargar_Datos();
                Repetir_FilaG();
            }
            grdSalidas.Focus();
        }
        private void Seleccionar_Sueldos()
        {
            // Sueldos
            frmCargar_Sueldos fr = new frmCargar_Sueldos();
            fr.gastos = cGastos;
            fr.ShowDialog();
            if (fr.Aceptado == true)
            {
                Cargar_Datos();
                Repetir_FilaG();
            }
            grdSalidas.Focus();
        }
        private void Seleccionar_Pago_Hacienda()
        {
            // HACIENDA
            Saldos_Consignatarios sld = new Saldos_Consignatarios();
            sld.gastos = cGastos;
            sld.Cargar_Pago();
            if (sld.Aceptado == true)
            {
                Cargar_Datos();
                Repetir_FilaG();
            }
            grdSalidas.Focus();
        }
        private void Seleccionar_Pago_Agregados()
        {
            // Agregados
            Saldos_Consignatarios sld = new Saldos_Consignatarios();
            sld.gastos = cGastos;
            sld.Cargar_PagoAgregados();
            if (sld.Aceptado == true)
            {
                Cargar_Datos();
                Repetir_FilaG();
            }
            grdSalidas.Focus();
            sld = null;
        }


        private void Cargar_FilaSalida(int Fila)
        {
            cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Id));
            cGastos.Fecha = mntFecha.SelectionStart.Date;
            cGastos.caja.ID = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Caja));
            cGastos.TG.Id_Tipo = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Tipo));
            cGastos.Id_SubTipoGastos = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_SubTipo));
            cGastos.Desc_SubTipo = Convert.ToString(grdSalidas.get_Texto(Fila, s_SubTipo + 1));
            cGastos.Id_DetalleGastos = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_IDDetalle));
            cGastos.Descripcion = Convert.ToString(grdSalidas.get_Texto(Fila, s_Descripcion));
            cGastos.Importe = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Importe));
            cGastos.Usuario.ID = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Usuario));
            cGastos.Autorizado = Convert.ToBoolean(grdSalidas.get_Texto(Fila, s_Autorizado));
            cGastos.Fecha_Autorizado = Convert.ToDateTime(grdSalidas.get_Texto(Fila, s_Fecha_Autorizado));
        }

        private void Repetir_FilaG()
        {
            int f = grdSalidas.Rows - 2;
            Cargar_FilaSalida(f);

            switch (o_Repetir)
            {
                case t_Repetir.Caja:
                    grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.ID);
                    grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                    grdSalidas.ActivarCelda(f + 1, s_Tipo);
                    break;
                case t_Repetir.Tipo:
                    grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.ID);
                    grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                    grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                    grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                    grdSalidas.ActivarCelda(f + 1, s_SubTipo);
                    break;
                case t_Repetir.SubTipo:
                    grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.ID);
                    grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                    grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                    grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                    grdSalidas.set_Texto(f + 1, s_SubTipo, cGastos.Id_SubTipoGastos);
                    grdSalidas.set_Texto(f + 1, s_SubTipo + 1, cGastos.Desc_SubTipo);
                    grdSalidas.ActivarCelda(f + 1, s_IDDetalle);
                    break;
                case t_Repetir.Detalle:
                    grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.ID);
                    grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                    grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                    grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                    grdSalidas.set_Texto(f + 1, s_SubTipo, cGastos.Id_SubTipoGastos);
                    grdSalidas.set_Texto(f + 1, s_SubTipo + 1, cGastos.Desc_SubTipo);
                    grdSalidas.set_Texto(f + 1, s_IDDetalle, cGastos.Id_DetalleGastos);
                    grdSalidas.set_Texto(f + 1, s_IDDetalle + 1, cGastos.Descripcion);
                    grdSalidas.ActivarCelda(f + 1, s_Descripcion);
                    break;
                default:
                    grdSalidas.set_Texto(f + 1, s_Caja, cGastos.caja.ID);
                    grdSalidas.set_Texto(f + 1, s_Caja + 1, cGastos.caja.Nombre);
                    grdSalidas.ActivarCelda(f + 1, s_Tipo);
                    break;

            }
        }
        #endregion

        #region " Menu contextual Entradas "
        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdEntradas_KeyUp(null, Convert.ToInt16(Keys.Delete));
        }

        private void cambiarFechaEntradas(object sender, EventArgs e)
        {
            frmNuevaFecha fr = new frmNuevaFecha();
            fr.ShowDialog();
            if (fr.Aceptado == true)
            {
                int fIni = grdEntradas.Selection.r1;
                int fFin = grdEntradas.Selection.r2;
                for (int i = fIni; i <= fFin; i++)
                {
                    Cargar_FilaEntradas(Convert.ToInt16(i));
                    cEntradas.Fecha = fr.mntFecha.SelectionStart.Date;
                    cEntradas.Actualizar();
                }
                Cargar_Datos();
            }
        }

        #endregion


    }
}
