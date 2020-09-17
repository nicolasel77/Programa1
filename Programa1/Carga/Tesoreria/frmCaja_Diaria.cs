
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

        /// <summary>
        /// Caja Diaria Entradas
        /// </summary>
        private Entradas cEntradas = new Entradas();

        public frmCaja_Diaria()
        {
            InitializeComponent();
        }

        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
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
            grdEntradas.TeclasManejadas = new int[] { 13, 43, 45, 46 };

            grdEntradas.AgregarTeclas(Convert.ToInt32(Keys.Add), e_Tipo, e_Importe);
            grdEntradas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), e_Subtipo, e_Importe);

            Fromato_Entradas();
            Totales();
        }

        private void frmCaja_Diaria_Resize(object sender, EventArgs e)
        {
            if (splPrincipal.Width != 0) { splPrincipal.SplitterDistance = (splPrincipal.Width - 212); }
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
            Fromato_Entradas();

            Totales();

            this.Cursor = Cursors.Default;
        }

        private void Fromato_Entradas()
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

            grdEntradas.Columnas[e_Importe].Style.Format = "N1";
        }

        /// <summary>
        /// Se calculan los labels tanto de las grillas como de la barra lateral.
        /// </summary>
        private void Totales()
        {
            Double t = grdEntradas.SumarCol(e_Importe, false);
            lblTEntrada.Text = "Total Entradas: " + t.ToString("C1");
            lblSEntradas.Text = t.ToString("C1");

            double Sa = cEntradas.Total_AFecha(mntFecha.SelectionStart.AddDays(-1));

            lblSSantEntradas.Text = Sa.ToString("C1");

            Double eSaldo = Sa + t;
            lblSTotalEntradas.Text = eSaldo.ToString("C1");
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

                case 4: //SubTipo - Buscar Tabla
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
                        if (grdEntradas.EsUltimaFila() == true)                        {
                            
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
                        grdEntradas.set_Texto(grdEntradas.Row, e_Importe, 0);
                        grdEntradas.set_Texto(grdEntradas.Row, e_Subtipo, 0);
                        grdEntradas.set_Texto(grdEntradas.Row, e_Descripcion, "");
                        grdEntradas.set_Texto(grdEntradas.Row, e_Id, 0);
                    }
                    else
                    {
                        grdEntradas.BorrarFila();
                    }
                    Totales();
                }
            }
        }

        #endregion
    }
}
