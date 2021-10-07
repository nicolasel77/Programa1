namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmCantidad_Clientes : Form
    {
        private Cantidad_Clientes Cantidad_Clientes;


        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_Cantidad;
        #endregion
        public frmCantidad_Clientes()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdCantidad_Clientes.TeclasManejadas = n;

            Cantidad_Clientes = new Cantidad_Clientes();
            grdCantidad_Clientes.MostrarDatos(Cantidad_Clientes.Datos_Vista("Id=0"), true);

            c_Id = Convert.ToByte(grdCantidad_Clientes.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdCantidad_Clientes.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdCantidad_Clientes.get_ColIndex("Id_Sucursales"));
            c_Cantidad = Convert.ToByte(grdCantidad_Clientes.get_ColIndex("Cantidad"));


            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdCantidad_Clientes.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Cantidad);

            Totales();
        }

        private void FrmCantidad_Clientes_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucs.Siguiente();
                    }
                    break;
                case Keys.Subtract:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucs.Anterior();
                    }
                    break;
            }
        }

        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }
        private void TiMensaje_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }

        #endregion

        private void CmdMostrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string s = Armar_Cadena();
            grdCantidad_Clientes.MostrarDatos(Cantidad_Clientes.Datos_Vista(s), true);
            formato_Grilla();
            Totales();
            grdCantidad_Clientes.ActivarCelda(grdCantidad_Clientes.Rows - 1, c_Fecha);
            grdCantidad_Clientes.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);

            return s;
        }

        private void formato_Grilla()
        {
            grdCantidad_Clientes.set_ColW(c_Id, 0);
            grdCantidad_Clientes.set_ColW(c_Fecha, 60);
            grdCantidad_Clientes.set_ColW(c_IdSuc, 30);
            grdCantidad_Clientes.set_ColW(c_IdSuc + 1, 100);
            grdCantidad_Clientes.set_ColW(c_Cantidad, 60);

            grdCantidad_Clientes.Columnas[c_Cantidad].Format = "N0";

            grdCantidad_Clientes.Columnas[c_Cantidad].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdCantidad_Clientes.set_Texto(0, c_IdSuc, "Suc");
        }

        private void Totales()
        {
            double k = grdCantidad_Clientes.SumarCol(c_Cantidad, false);
            int c = grdCantidad_Clientes.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblTotal.Text = $"Cantidad: {k:N0}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdCantidad_Clientes.Rows = 1;
            grdCantidad_Clientes.Rows = 2;
            Totales();
        }


        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            string vFecha = cFecha.Cadena();
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Cantidad_Clientes WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdCantidad_Clientes_Editado(short f, short c, object a)
        {
            if (Cantidad_Clientes.Fecha_Cerrada(Cantidad_Clientes.Fecha) == false)
            {
                int id = Convert.ToInt32(grdCantidad_Clientes.get_Texto(f, c_Id));
                if (id != 0) { Cantidad_Clientes.ID = id; }
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (Cantidad_Clientes.Fecha_Cerrada(df) == false)
                            {
                                if (Cantidad_Clientes.Sucursal.ID == 0 || Cantidad_Clientes.Dato($"Fecha = '{df.ToString("MM/dd/yyy")}' AND Id_Sucursales = {Cantidad_Clientes.Sucursal.ID}") == null)
                                {
                                    Cantidad_Clientes.Fecha = df;

                                    if (id != 0) { Cantidad_Clientes.Actualizar(); }

                                    grdCantidad_Clientes.set_Texto(f, c, a);
                                    grdCantidad_Clientes.ActivarCelda(f, c + 1);
                                }
                                else
                                {
                                    Mensaje("La fecha ingresada ya está cargada.");
                                    grdCantidad_Clientes.ErrorEnTxt();
                                }
                            }
                            else
                            {
                                Mensaje("La fecha ingresada se encuentra cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                            grdCantidad_Clientes.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //ID_Sucursales
                        Cantidad_Clientes.Sucursal.ID = Convert.ToInt32(a);
                        if (Cantidad_Clientes.Sucursal.Existe() == true)
                        {
                            if (Cantidad_Clientes.Sucursal.ID == 0 || Cantidad_Clientes.Dato($"Fecha = '{Cantidad_Clientes.Fecha.ToString("MM/dd/yyy")}' AND Id_Sucursales = {Cantidad_Clientes.Sucursal.ID}") == null)
                            {
                                if (id != 0) { Cantidad_Clientes.Actualizar(); }

                            grdCantidad_Clientes.set_Texto(f, c, a);
                            grdCantidad_Clientes.set_Texto(f, c + 1, Cantidad_Clientes.Sucursal.Nombre);

                            grdCantidad_Clientes.ActivarCelda(f, c + 2);
                            }
                            else
                            {
                                Mensaje("La fecha ingresada ya está cargada.");
                                grdCantidad_Clientes.set_Texto(f, c, a);
                                grdCantidad_Clientes.set_Texto(f, c + 1, Cantidad_Clientes.Sucursal.Nombre);

                                grdCantidad_Clientes.ActivarCelda(f, c_Fecha);
                                grdCantidad_Clientes.ErrorEnTxt();
                            }
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdCantidad_Clientes.ErrorEnTxt();
                        }
                        break;

                    case 4:
                        //Cantidad
                        Cantidad_Clientes.Cantidad = Convert.ToInt32(a);
                        grdCantidad_Clientes.set_Texto(f, c, a);

                        if (grdCantidad_Clientes.Row == grdCantidad_Clientes.Rows - 1)
                        {
                            Cantidad_Clientes.Agregar();
                            grdCantidad_Clientes.set_Texto(f, c_Id, Cantidad_Clientes.ID);
                            grdCantidad_Clientes.AgregarFila();
                            //Rellenar nueva fila

                            Cantidad_Clientes.Fecha = Cantidad_Clientes.Fecha.AddDays(1);

                            grdCantidad_Clientes.set_Texto(f + 1, c_Fecha, Cantidad_Clientes.Fecha);
                            grdCantidad_Clientes.set_Texto(f + 1, c_IdSuc, Cantidad_Clientes.Sucursal.ID);
                            grdCantidad_Clientes.set_Texto(f + 1, c_IdSuc + 1, Cantidad_Clientes.Sucursal.Nombre);

                            Cantidad_Clientes.Cantidad = 0;
                        }
                        else
                        {
                            Cantidad_Clientes.Actualizar();
                        }
                        grdCantidad_Clientes.ActivarCelda(f + 1, c_Cantidad);

                        Totales();
                        break;
                }
            }
            else
            {
                Mensaje("La fecha ingresada se encuentra cerrada.");
            }
        }

        private void GrdCantidad_Clientes_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdCantidad_Clientes.get_Texto(Fila, c_Id));
            if (i > 0)
            { 
            Cantidad_Clientes.Cargar_Fila(i);
            }
            else
            {
                Cantidad_Clientes.ID = 0;
                Cantidad_Clientes.Fecha = Convert.ToDateTime(grdCantidad_Clientes.get_Texto(Fila,c_Fecha));
                Cantidad_Clientes.Sucursal.ID = Convert.ToInt32(grdCantidad_Clientes.get_Texto(Fila, c_IdSuc));
                Cantidad_Clientes.Cantidad = Convert.ToInt32(grdCantidad_Clientes.get_Texto(Fila, c_Cantidad));
            }
        }

        private void GrdCantidad_Clientes_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Cantidad_Clientes.ID == 0)
                {

                    if (grdCantidad_Clientes.Col == c_Cantidad)
                    {
                        DateTime f = Convert.ToDateTime(grdCantidad_Clientes.get_Texto(grdCantidad_Clientes.Row, c_Fecha));
                        Cantidad_Clientes.Fecha = Cantidad_Clientes.Fecha.AddDays(1);
                        grdCantidad_Clientes.set_Texto(grdCantidad_Clientes.Row, c_Fecha, Cantidad_Clientes.Fecha);

                    }
                }
            }
        }

        private void GrdCantidad_Clientes_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdCantidad_Clientes.get_Texto(grdCantidad_Clientes.Row, 0)) != 0)
                    {
                        if (Cantidad_Clientes.Fecha_Cerrada(Cantidad_Clientes.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Cantidad_Clientes.ID = Convert.ToInt32(grdCantidad_Clientes.get_Texto(grdCantidad_Clientes.Row, 0));
                                Cantidad_Clientes.Borrar();
                                grdCantidad_Clientes.BorrarFila(grdCantidad_Clientes.Row);
                                GrdCantidad_Clientes_CambioFila(Convert.ToByte(grdCantidad_Clientes.Row));
                                Totales();
                            } 
                        }
                        else
                        {
                            Mensaje("La fecha ingresada se encuentra cerrada.");
                        }
                    }
                    break;
            }
        }


        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }


        private void CmdCambioMasivo_Click(object sender, EventArgs e)
        {
            if (grdCantidad_Clientes.Rows > 2)
            {
                //frmCMCantidad_Clientes cm = new frmCMCantidad_Clientes();
                //List<int> n = new List<int>();

                //int d = grdCantidad_Clientes.Selection.r1;
                //int h = grdCantidad_Clientes.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdCantidad_Clientes.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdCantidad_Clientes.get_Texto(i, c_Id)));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }

        private void grdCantidad_Clientes_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float t = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    t += Convert.ToSingle(grdCantidad_Clientes.get_Texto(i, c_Cantidad));
                    
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";                
                lblTotal.Text = $"Total: {t:C2}";
            }
        }
    }
}
