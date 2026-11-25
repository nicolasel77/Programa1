namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Ver y corregir los kilos por producto del Stock Carne/Pollo (productos con PedirStock = 1)
    /// que cargan las sucursales en Sistema-Web. Las filas las crea la sucursal; acá solo se
    /// modifican los kilos o se borra un registro. Los totales de Stock_Diario se recalculan solos.
    /// </summary>
    public partial class frmStock_Diario_Productos : Form
    {
        private Stock_Diario_Productos Stock;

        private const string Orden = "Fecha, Id_Sucursales, Id_Productos";

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdProd;
        private Byte c_Kilos;
        private Byte c_Modificado;
        #endregion

        public frmStock_Diario_Productos()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;

            Stock = new Stock_Diario_Productos();
            grdStock.MostrarDatos(Stock.Datos_Vista("Id=0", "*", Orden), true);

            c_Id = Convert.ToByte(grdStock.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdStock.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdStock.get_ColIndex("Id_Sucursales"));
            c_IdProd = Convert.ToByte(grdStock.get_ColIndex("Id_Productos"));
            c_Kilos = Convert.ToByte(grdStock.get_ColIndex("Kilos"));
            c_Modificado = Convert.ToByte(grdStock.get_ColIndex("Modificado"));

            formato_Grilla();
            Totales();
        }

        private void FrmStock_Diario_Productos_KeyUp(object sender, KeyEventArgs e)
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
            grdStock.ActivarCelda(1, c_Kilos);
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
            grdStock.set_ColW(c_IdProd, 40);
            grdStock.set_ColW(c_IdProd + 1, 160);
            grdStock.set_ColW(c_Kilos, 80);
            grdStock.set_ColW(c_Modificado, 110);

            grdStock.Columnas[c_Kilos].Format = "N2";
            grdStock.Columnas[c_Modificado].Format = "dd/MM/yy HH:mm";
            grdStock.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdStock.set_Texto(0, c_IdSuc, "Suc");
            grdStock.set_Texto(0, c_IdSuc + 1, "Sucursal");
            grdStock.set_Texto(0, c_IdProd, "Prod");
            grdStock.set_Texto(0, c_IdProd + 1, "Producto");
            grdStock.set_Texto(0, c_Kilos, "Kilos");
        }

        // Lee un número de la grilla (0 si la celda está vacía, como en la última fila)
        private static int Entero(object o)
        {
            int.TryParse(Convert.ToString(o), out int n);
            return n;
        }

        // Pollo = productos 300 a 399, igual que los totales de Stock_Diario
        private static bool Es_Pollo(int idProducto)
        {
            return idProducto >= 300 && idProducto <= 399;
        }

        private void Sumar(int filaInicio, int filaFin)
        {
            double k = 0;
            double p = 0;
            int c = 0;
            for (int i = filaInicio; i <= filaFin; i++)
            {
                if (Entero(grdStock.get_Texto(i, c_Id)) == 0) continue;
                double.TryParse(Convert.ToString(grdStock.get_Texto(i, c_Kilos)), out double kilos);
                if (Es_Pollo(Entero(grdStock.get_Texto(i, c_IdProd)))) p += kilos; else k += kilos;
                c++;
            }
            lblCant.Text = $"Registros: {c:N0}";
            lblTotal.Text = $"Carne: {k:N2}";
            lblPollo.Text = $"Pollo: {p:N2}";
        }

        private void Totales()
        {
            Sumar(1, grdStock.Rows - 1);
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
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Stock_Diario_Productos WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }

        private void GrdStock_Editado(short f, short c, object a)
        {
            int id = Entero(grdStock.get_Texto(f, c_Id));

            if (c != c_Kilos || id == 0)
            {
                Mensaje("Solo se pueden corregir los kilos. Los productos los carga la sucursal en Sistema Web.");
                grdStock.ErrorEnTxt();
                return;
            }

            if (Stock.Fecha_Cerrada(Stock.Fecha_Registro(id)))
            {
                Mensaje("La fecha ingresada se encuentra cerrada.");
                return;
            }

            if (!decimal.TryParse(Convert.ToString(a), out decimal kilos) || kilos < 0)
            {
                Mensaje("Ingrese un número de kilos válido (mayor o igual a 0).");
                grdStock.ErrorEnTxt();
                return;
            }

            if (Stock.Actualizar_Kilos(id, kilos))
            {
                grdStock.set_Texto(f, c, kilos);
                grdStock.set_Texto(f, c_Modificado, DateTime.Now);
                if (f < grdStock.Rows - 1) grdStock.ActivarCelda(f + 1, c_Kilos);
                Totales();
            }
        }

        private void GrdStock_CambioFila(short Fila)
        {
            Stock.ID = Entero(grdStock.get_Texto(Fila, c_Id));
        }

        private void GrdStock_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    int id = Entero(grdStock.get_Texto(grdStock.Row, c_Id));
                    if (id != 0)
                    {
                        if (Stock.Fecha_Cerrada(Stock.Fecha_Registro(id)) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                if (Stock.Borrar_Registro(id))
                                {
                                    grdStock.BorrarFila(grdStock.Row);
                                    Totales();
                                }
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
            ToolStripStatusLabel lbl = sender as ToolStripStatusLabel;
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
                Sumar(FilaInicio, FilaFin);
            }
        }
    }
}
