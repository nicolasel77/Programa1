
namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmCaja_Diaria : Form
    {
        #region " Columnas Entradas "
        private Byte e_Id;
        private Byte e_Fecha;
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
        private Byte s_Tipo;
        private Byte s_SubTipo;
        private Byte s_Detalle;
        private Byte s_Descripcion;
        private Byte s_Importe;
        private Byte s_Autorizado;
        private Byte s_Fecha_Autorizado;

        #endregion

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

        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            Cargar_Datos();

            //*****************************
            //*********Entradas************
            //*****************************
            e_Id = Convert.ToByte(grdEntradas.get_ColIndex("Id"));
            e_Fecha = Convert.ToByte(grdEntradas.get_ColIndex("Fecha"));
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
            s_Tipo = Convert.ToByte(grdSalidas.get_ColIndex("ID_TipoGastos"));
            s_SubTipo = Convert.ToByte(grdSalidas.get_ColIndex("ID_SubTipoGastos"));
            s_Detalle = Convert.ToByte(grdSalidas.get_ColIndex("ID_DetalleGastos"));
            s_Descripcion = Convert.ToByte(grdSalidas.get_ColIndex("Descripcion"));
            s_Importe = Convert.ToByte(grdSalidas.get_ColIndex("Importe"));
            s_Autorizado = Convert.ToByte(grdSalidas.get_ColIndex("Autorizado"));
            s_Fecha_Autorizado = Convert.ToByte(grdSalidas.get_ColIndex("Fecha_Autorizado"));


            // 13: Enter
            // 43: +
            // 45: -
            // 46: Delete
            //112: F1
            grdSalidas.TeclasManejadas = new int[] { 13, 43, 45, 46, 112 };

            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Add), e_Tipo, e_Importe);
            grdSalidas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), e_Subtipo, e_Importe);

            Formato_Salidas();

            style = grdSalidas.Styles.Fixed;
            style.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterBottom;
            grdSalidas.set_AlineamientoCelda(0, s_Importe, style);
            Totales();
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


        private void Cargar_Datos()
        {
            this.Cursor = Cursors.WaitCursor;

            grdEntradas.MostrarDatos(cEntradas.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            Formato_Entradas();

            grdSalidas.MostrarDatos(cGastos.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            Formato_Salidas();


            Totales();

            this.Cursor = Cursors.Default;
        }

        private void Formato_Entradas()
        {
            grdEntradas.set_ColW(e_Id, 0);
            grdEntradas.set_ColW(e_Fecha, 0);
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
            grdSalidas.set_ColW(s_Tipo, 50);
            grdSalidas.set_ColW(s_Tipo + 1, 90);
            grdSalidas.set_ColW(s_SubTipo, 50);
            grdSalidas.set_ColW(s_SubTipo + 1, 90);
            grdSalidas.set_ColW(s_Detalle, 50);
            grdSalidas.set_ColW(s_Descripcion, 200);
            grdSalidas.set_ColW(s_Importe, 90);
            grdSalidas.set_ColW(s_Autorizado, 50);
            grdSalidas.set_ColW(s_Fecha_Autorizado, 70);

            grdSalidas.set_Texto(0, s_Tipo, "Tipo");
            grdSalidas.set_Texto(0, s_SubTipo, "SubTipo");
            grdSalidas.set_Texto(0, s_Detalle, "Detalle");
            grdSalidas.set_Texto(0, s_Autorizado, "Aut");
            grdSalidas.set_Texto(0, s_Fecha_Autorizado, "Aut_Fe");

            grdSalidas.Columnas[s_Importe].Style.Format = "N2";

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

            Double g = grdSalidas.SumarCol(s_Importe, false);
            lblTotalGrillaGastos.Text = "Total Gastos: " + g.ToString("C1");
            lblGastos.Text = g.ToString("C1");

            lblTotal.Text = (eSaldo - g).ToString("C1");
        }

        private void mntFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cargar_Datos();
        }

        #region " Grilla Entradas "
        private void grdEntradas_Editado(short f, short c, object a)
        {
            cEntradas.ID = Convert.ToInt32(grdEntradas.get_Texto(f, e_Id));
            cEntradas.Fecha = mntFecha.SelectionStart.Date;

            switch (c)
            {
                case 2: //Tipo
                    cEntradas.TE.Id_Tipo = Convert.ToInt32(a);
                    if (cEntradas.TE.Existe() == true)
                    {
                        grdEntradas.set_Texto(f, c, a);
                        grdEntradas.set_Texto(f, c + 1, cEntradas.TE.Nombre);
                        grdEntradas.ActivarCelda(f, e_Subtipo);

                    }
                    break;

                case 4: //SubTipo - Suc - Cliente
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
                                cEntradas.Importe = fr.Detalle_Entregas.Total_IDEntradas(cEntradas.ID);
                                cEntradas.Actualizar();

                                grdEntradas.set_Texto(f, e_Importe, cEntradas.Importe);

                                grdEntradas.set_Texto(f + 1, e_Fecha, cEntradas.Fecha);
                                grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                                grdEntradas.set_Texto(f + 1, e_Tipo + 1, grdEntradas.get_Texto(f, e_Tipo + 1));

                                if (grdEntradas.EsUltimaFila() == true) grdEntradas.AgregarFila();
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
                case 5: // Descripcion
                    if (cEntradas.TE.Id_Tipo != 0 & cEntradas.Id_SubTipoEntrada != 0)
                    {
                        cEntradas.Descripcion = a.ToString();
                        grdEntradas.set_Texto(f, e_Descripcion, a);
                        grdEntradas.ActivarCelda(f, e_Importe);

                        if (cEntradas.ID != 0) { cEntradas.Actualizar(); }
                    }
                    break;
                case 6: // Importe
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

                            grdEntradas.set_Texto(f + 1, e_Tipo, cEntradas.TE.Id_Tipo);
                            grdEntradas.set_Texto(f + 1, e_Tipo + 1, cEntradas.TE.Nombre);
                        }
                        else
                        {
                            cEntradas.Actualizar();
                        }

                        Totales();

                        grdEntradas.ActivarCelda(f + 1, e_Subtipo);
                    }
                    break;
            }
        }

        private void grdEntradas_CambioFila(short Fila)
        {
            cEntradas.ID = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Id));
            cEntradas.Fecha = Convert.ToDateTime(grdEntradas.get_Texto(Fila, e_Fecha));
            cEntradas.TE.Id_Tipo = Convert.ToInt32(grdEntradas.get_Texto(Fila, e_Tipo));
        }

        private void grdEntradas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
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
                if (e == Convert.ToInt32(Keys.F1))
                {
                    frmAyuda_Entradas fayuda = new frmAyuda_Entradas();
                    Herramientas.Herramientas h = new Herramientas.Herramientas();

                    if (grdEntradas.Col == e_Tipo) { fayuda.Cargar_TiposEntradas(cEntradas.TE.Id_Tipo); }
                    if (grdEntradas.Col == e_Subtipo) { fayuda.Cargar_SubTiposEntradas(cEntradas.TE.Id_Tipo); }

                    fayuda.ShowDialog();

                    if (fayuda.Valor != "")
                    {
                        if (grdEntradas.Col == e_Tipo)
                        {
                            cEntradas.TE.Id_Tipo = h.Codigo_Seleccionado(fayuda.Valor);
                            grdEntradas.set_Texto(Convert.ToInt16(grdEntradas.Row), e_Tipo, cEntradas.TE.Id_Tipo);
                            grdEntradas.set_Texto(Convert.ToInt16(grdEntradas.Row), e_Tipo + 1, cEntradas.TE.Nombre);
                            grdEntradas.ActivarCelda(grdEntradas.Row, e_Subtipo);
                        }
                        else
                        {
                            cEntradas.Id_SubTipoEntrada = h.Codigo_Seleccionado(fayuda.Valor);
                            grdEntradas.set_Texto(Convert.ToInt16(grdEntradas.Row), e_Subtipo, cEntradas.Id_SubTipoEntrada);
                            grdEntradas.set_Texto(Convert.ToInt16(grdEntradas.Row), e_Subtipo + 1, h.Nombre_Seleccionado(fayuda.Valor));
                            grdEntradas.ActivarCelda(grdEntradas.Row, s_Detalle);
                        }
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
            cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(f, s_Id));
            cGastos.Fecha = mntFecha.SelectionStart.Date;

            switch (c)
            {
                case 2: //Tipo
                    cGastos.TG.Id_Tipo = Convert.ToInt32(a);
                    if (cGastos.TG.Existe() == true)
                    {
                        grdSalidas.set_Texto(f, c, a);
                        grdSalidas.set_Texto(f, c + 1, cGastos.TG.Nombre);
                        grdSalidas.ActivarCelda(f, s_SubTipo);

                    }
                    break;

                case 4: //SubTipo - Buscar Tabla
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
                case 5: // Desc_SubTipo
                    if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                    {
                        cGastos.Desc_SubTipo = a.ToString();
                        grdSalidas.set_Texto(f, s_SubTipo + 1, a);
                        grdSalidas.ActivarCelda(f, s_Importe);

                        if (cGastos.ID != 0) { cGastos.Actualizar(); }
                    }
                    break;
                case 6: //ID_Detalle
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

                            grdSalidas.ActivarCelda(f, s_Importe);
                            if (cGastos.ID != 0) { cGastos.Actualizar(); }

                        }
                    }
                    break;
                case 7: // Descripcion
                    if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                    {
                        cGastos.Descripcion = a.ToString();
                        grdSalidas.set_Texto(f, s_Descripcion, a);
                        grdSalidas.ActivarCelda(f, s_Importe);

                        if (cGastos.ID != 0) { cGastos.Actualizar(); }
                    }
                    break;
                case 8: // Importe
                    if (cGastos.TG.Id_Tipo != 0 & cGastos.Id_SubTipoGastos != 0)
                    {
                        cGastos.Fecha = mntFecha.SelectionStart.Date;

                        cGastos.Importe = Convert.ToDouble(a);
                        grdSalidas.set_Texto(f, s_Importe, a);

                        if (grdSalidas.EsUltimaFila() == true)
                        {

                            cGastos.Agregar();
                            grdSalidas.set_Texto(f, s_Id, Convert.ToInt32(cGastos.ID));
                            grdSalidas.set_Texto(f, s_Fecha, Convert.ToDateTime(cGastos.Fecha));

                            grdSalidas.AgregarFila();

                            grdSalidas.set_Texto(f + 1, s_Tipo, cGastos.TG.Id_Tipo);
                            grdSalidas.set_Texto(f + 1, s_Tipo + 1, cGastos.TG.Nombre);
                        }
                        else
                        {
                            cGastos.Actualizar();
                        }

                        Totales();

                        grdSalidas.ActivarCelda(f + 1, s_Tipo);
                    }
                    break;
            }
        }

        private void grdSalidas_CambioFila(short Fila)
        {
            cGastos.ID = Convert.ToInt32(grdSalidas.get_Texto(Fila, s_Id));
            cGastos.Fecha = Convert.ToDateTime(grdSalidas.get_Texto(Fila, s_Fecha));
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

            if (e == Convert.ToInt32(Keys.Enter))
            {
                if (grdSalidas.Col == s_Importe) { grdSalidas.ActivarCelda(fila + 1, s_Tipo); }
                else
                {
                    if (grdSalidas.Col == s_Detalle) { grdSalidas.ActivarCelda(fila, s_Importe); }
                    if (grdSalidas.Col == s_SubTipo) { grdSalidas.ActivarCelda(fila, s_Detalle); }
                    if (grdSalidas.Col == s_Tipo) { grdSalidas.ActivarCelda(fila, s_SubTipo); }
                }
            }
            if (e == Convert.ToInt32(Keys.Delete))
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
            if (e == Convert.ToInt32(Keys.F1))
            {
                frmAyuda_Gastos fayuda = new frmAyuda_Gastos();
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (grdSalidas.Col == s_Tipo) { fayuda.Cargar_TiposGastos(cGastos.TG.Id_Tipo); }
                if (grdSalidas.Col == s_SubTipo) { fayuda.Cargar_SubTiposGastos(cGastos.TG.Id_Tipo); }
                if (grdSalidas.Col == s_Detalle) { fayuda.Cargar_Detalles(cGastos.TG.Id_Tipo); }

                fayuda.ShowDialog();

                if (fayuda.Valor != "")
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
                                grdSalidas.ActivarCelda(grdSalidas.Row, s_Importe);
                            }
                        }
                    }
                }
            }
        }

        #endregion


    }
}
