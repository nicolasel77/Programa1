namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Ver y editar el Stock Carne y Stock Pollo (kilos) que cargan las sucursales en Sistema-Web.
    /// </summary>
    public partial class frmStock_Diario : Form
    {
        private Stock_Diario Stock;

        private const string Orden = "Fecha, Id_Sucursales";

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_Carne;
        private Byte c_Pollo;
        private Byte c_Modificado;
        #endregion

        public frmStock_Diario()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;

            Stock = new Stock_Diario();
            grdStock.MostrarDatos(Stock.Datos_Vista("Id=0", "*", Orden), true);

            c_Id = Convert.ToByte(grdStock.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdStock.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdStock.get_ColIndex("Id_Sucursales"));
            c_Carne = Convert.ToByte(grdStock.get_ColIndex("Carne"));
            c_Pollo = Convert.ToByte(grdStock.get_ColIndex("Pollo"));
            c_Modificado = Convert.ToByte(grdStock.get_ColIndex("Modificado"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Carne);

            Totales();
        }

        private void FrmStock_Diario_KeyUp(object sender, KeyEventArgs e)
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
            grdStock.MostrarDatos(Stock.Datos_Vista(s, "*", Orden), true);
            formato_Grilla();
            Totales();
            grdStock.ActivarCelda(grdStock.Rows - 1, c_Fecha);
            grdStock.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            return h.Unir(f, s);
        }

        private void formato_Grilla()
        {
            grdStock.set_ColW(c_Id, 0);
            grdStock.set_ColW(c_Fecha, 70);
            grdStock.set_ColW(c_IdSuc, 30);
            grdStock.set_ColW(c_IdSuc + 1, 120);
            grdStock.set_ColW(c_Carne, 80);
            grdStock.set_ColW(c_Pollo, 80);
            grdStock.set_ColW(c_Modificado, 110);

            grdStock.Columnas[c_Carne].Format = "N2";
            grdStock.Columnas[c_Pollo].Format = "N2";
            grdStock.Columnas[c_Modificado].Format = "dd/MM/yy HH:mm";

            grdStock.Columnas[c_Carne].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            grdStock.Columnas[c_Pollo].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdStock.set_Texto(0, c_IdSuc, "Suc");
            grdStock.set_Texto(0, c_IdSuc + 1, "Sucursal");
            grdStock.set_Texto(0, c_Carne, "Carne (kg)");
            grdStock.set_Texto(0, c_Pollo, "Pollo (kg)");
        }

        private void Totales()
        {
            double k = grdStock.SumarCol(c_Carne, false);
            double p = grdStock.SumarCol(c_Pollo, false);
            int c = grdStock.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblTotal.Text = $"Carne: {k:N2}";
            lblPollo.Text = $"Pollo: {p:N2}";
        }

        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdStock.Rows = 1;
            grdStock.Rows = 2;
            Totales();
        }

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            string vFecha = cFecha.Cadena();
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Stock_Diario WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }

        private bool Leer_Kilos(object a, out decimal kilos)
        {
            if (decimal.TryParse(Convert.ToString(a), out kilos) && kilos >= 0)
            {
                return true;
            }
            Mensaje("Ingrese un número de kilos válido (mayor o igual a 0).");
            grdStock.ErrorEnTxt();
            return false;
        }

        private void GrdStock_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdStock.get_Texto(f, c_Id));
            Stock.ID = id;

            if (Stock.Fecha_Cerrada(Stock.Fecha))
            {
                Mensaje("La fecha ingresada se encuentra cerrada.");
                return;
            }

            if (c == c_Fecha)
            {
                DateTime df = Convert.ToDateTime(a);
                if (df < cFecha.fecha_Actual)
                {
                    Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                    grdStock.ErrorEnTxt();
                }
                else if (Stock.Fecha_Cerrada(df))
                {
                    Mensaje("La fecha ingresada se encuentra cerrada.");
                }
                else
                {
                    DateTime anterior = Stock.Fecha;
                    Stock.Fecha = df;
                    if (id != 0 && Stock.Existe_Dato())
                    {
                        Stock.Fecha = anterior;
                        Mensaje("La fecha y sucursal ya se han cargado.");
                        grdStock.ErrorEnTxt();
                    }
                    else
                    {
                        if (id != 0) { Stock.Actualizar(); }
                        grdStock.set_Texto(f, c, a);
                        grdStock.ActivarCelda(f, c + 1);
                    }
                }
            }
            else if (c == c_IdSuc)
            {
                int anterior = Stock.Sucursal.ID;
                Stock.Sucursal.ID = Convert.ToInt32(a);
                if (Stock.Sucursal.Existe() == false)
                {
                    Stock.Sucursal.ID = anterior;
                    Mensaje("No se encontró la sucursal " + a.ToString());
                    grdStock.ErrorEnTxt();
                }
                else if (id != 0 && Stock.Existe_Dato())
                {
                    Stock.Sucursal.ID = anterior;
                    Mensaje("La fecha y sucursal ya se han cargado.");
                    grdStock.ErrorEnTxt();
                }
                else
                {
                    if (id != 0) { Stock.Actualizar(); }
                    grdStock.set_Texto(f, c, a);
                    grdStock.set_Texto(f, c + 1, Stock.Sucursal.Nombre);
                    grdStock.ActivarCelda(f, c_Carne);
                }
            }
            else if (c == c_Carne)
            {
                if (Leer_Kilos(a, out decimal kilos))
                {
                    Stock.Carne = kilos;
                    grdStock.set_Texto(f, c, kilos);
                    if (id != 0)
                    {
                        Stock.Actualizar();
                        grdStock.set_Texto(f, c_Modificado, DateTime.Now);
                    }
                    grdStock.ActivarCelda(f, c_Pollo);
                    Totales();
                }
            }
            else if (c == c_Pollo)
            {
                if (Leer_Kilos(a, out decimal kilos))
                {
                    Stock.Pollo = kilos;

                    if (id == 0 && f == grdStock.Rows - 1)
                    {
                        // Fila nueva: se graba al completar Pollo
                        if (Stock.Existe_Dato())
                        {
                            Mensaje("La fecha y sucursal ya se han cargado.");
                            grdStock.ActivarCelda(f, c_Fecha);
                            return;
                        }

                        Stock.Agregar();
                        if (Stock.ID == 0) { return; }

                        grdStock.set_Texto(f, c, kilos);
                        grdStock.set_Texto(f, c_Id, Stock.ID);
                        grdStock.AgregarFila();

                        //Rellenar nueva fila con el día siguiente y la misma sucursal
                        Stock.ID = 0;
                        Stock.Fecha = Stock.Fecha.AddDays(1);
                        Stock.Carne = 0;
                        Stock.Pollo = 0;

                        grdStock.set_Texto(f + 1, c_Fecha, Stock.Fecha);
                        grdStock.set_Texto(f + 1, c_IdSuc, Stock.Sucursal.ID);
                        grdStock.set_Texto(f + 1, c_IdSuc + 1, Stock.Sucursal.Nombre);

                        grdStock.ActivarCelda(f + 1, c_Carne);
                    }
                    else
                    {
                        grdStock.set_Texto(f, c, kilos);
                        if (id != 0)
                        {
                            Stock.Actualizar();
                            grdStock.set_Texto(f, c_Modificado, DateTime.Now);
                        }
                        grdStock.ActivarCelda(f + 1, c_Carne);
                    }
                    Totales();
                }
            }
        }

        private void GrdStock_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdStock.get_Texto(Fila, c_Id));
            if (i > 0)
            {
                Stock.Cargar_Fila(i);
            }
            else
            {
                Stock.ID = 0;
                Stock.Fecha = Convert.ToDateTime(grdStock.get_Texto(Fila, c_Fecha));
                Stock.Sucursal.ID = Convert.ToInt32(grdStock.get_Texto(Fila, c_IdSuc));
                Stock.Carne = Convert.ToDecimal(grdStock.get_Texto(Fila, c_Carne));
                Stock.Pollo = Convert.ToDecimal(grdStock.get_Texto(Fila, c_Pollo));
            }
        }

        private void GrdStock_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdStock.get_Texto(grdStock.Row, c_Id)) != 0)
                    {
                        if (Stock.Fecha_Cerrada(Stock.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Stock.ID = Convert.ToInt32(grdStock.get_Texto(grdStock.Row, c_Id));
                                Stock.Borrar();
                                grdStock.BorrarFila(grdStock.Row);
                                GrdStock_CambioFila(Convert.ToByte(grdStock.Row));
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
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1).Trim();

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void grdStock_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                double k = 0;
                double p = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    k += Convert.ToDouble(grdStock.get_Texto(i, c_Carne));
                    p += Convert.ToDouble(grdStock.get_Texto(i, c_Pollo));
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";
                lblTotal.Text = $"Carne: {k:N2}";
                lblPollo.Text = $"Pollo: {p:N2}";
            }
        }
    }
}
