namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Control por sucursal y día: lo que carga la sucursal en Sistema-Web (efectivo y tarjetas)
    /// contra lo que entró a la caja y lo que informan los procesadores de tarjetas.
    /// Las cuentas (Balance, Resumen) usan lo de la sucursal desde la fecha de corte; esto es el control.
    /// </summary>
    public partial class frmControl_Declarado : Form
    {
        private Control_Declarado Control_D;

        private const string Orden = "Fecha, Suc, Id_Tipo";

        #region " Columnas "
        private Byte c_Fecha;
        private Byte c_Suc;
        private Byte c_IdTipo;
        private Byte c_Concepto;
        private Byte c_Sucursal;
        private Byte c_Control;
        private Byte c_Diferencia;
        #endregion

        public frmControl_Declarado()
        {
            InitializeComponent();

            Control_D = new Control_Declarado();
            grdControl.MostrarDatos(Control_D.Datos_Vista("1=0", "*", Orden), true, false);
            Columnas();
            formato_Grilla();
            Totales();
        }

        private void Columnas()
        {
            c_Fecha = Convert.ToByte(grdControl.get_ColIndex("Fecha"));
            c_Suc = Convert.ToByte(grdControl.get_ColIndex("Suc"));
            c_IdTipo = Convert.ToByte(grdControl.get_ColIndex("Id_Tipo"));
            c_Concepto = Convert.ToByte(grdControl.get_ColIndex("Concepto"));
            c_Sucursal = Convert.ToByte(grdControl.get_ColIndex("Sucursal"));
            c_Control = Convert.ToByte(grdControl.get_ColIndex("Control"));
            c_Diferencia = Convert.ToByte(grdControl.get_ColIndex("Diferencia"));
        }

        private void FrmControl_Declarado_KeyUp(object sender, KeyEventArgs e)
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
            string f = cFecha.Cadena();
            if (f.Length == 0)
            {
                Mensaje("Seleccione una semana o fecha.");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            grdControl.MostrarDatos(Control_D.Datos_Vista(Armar_Cadena(), "*", Orden), true, false);
            Columnas();
            formato_Grilla();
            Totales();
            grdControl.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string s = cSucs.Cadena("Suc");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            string r = h.Unir(f, s);

            // Diferencias de menos de $1 se consideran redondeo
            if (chkSoloDif.Checked) { r = h.Unir(r, "ABS(Diferencia) >= 1"); }

            return r;
        }

        private void formato_Grilla()
        {
            grdControl.set_ColW(c_Fecha, 70);
            grdControl.set_ColW(c_Suc, 30);
            grdControl.set_ColW(c_Suc + 1, 120);
            grdControl.set_ColW(c_IdTipo, 0);
            grdControl.set_ColW(c_Concepto, 140);
            grdControl.set_ColW(c_Sucursal, 100);
            grdControl.set_ColW(c_Control, 100);
            grdControl.set_ColW(c_Diferencia, 100);

            grdControl.Columnas[c_Fecha].Format = "dd/MM/yy";
            grdControl.Columnas[c_Sucursal].Format = "N0";
            grdControl.Columnas[c_Control].Format = "N0";
            grdControl.Columnas[c_Diferencia].Format = "N0";

            grdControl.Columnas[c_Diferencia].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdControl.set_Texto(0, c_Suc, "Suc");
            grdControl.set_Texto(0, c_Suc + 1, "Nombre");
            grdControl.set_Texto(0, c_Sucursal, "Cargó Sucursal");
            grdControl.set_Texto(0, c_Control, "Caja / Procesador");

            // Diferencias en rojo
            for (int i = 1; i < grdControl.Rows; i++)
            {
                double d = 0;
                double.TryParse(Convert.ToString(grdControl.get_Texto(i, c_Diferencia)), out d);
                if (Math.Abs(d) >= 1)
                {
                    grdControl.set_ColorLetraCelda(i, c_Diferencia, System.Drawing.Color.Red);
                }
            }
        }

        private void Totales()
        {
            double s = grdControl.SumarCol(c_Sucursal, false);
            double c = grdControl.SumarCol(c_Control, false);
            int n = grdControl.Rows - 1;
            lblCant.Text = $"Registros: {n:N0}";
            lblTotal.Text = $"Sucursal: {s:N0}";
            lblControl.Text = $"Caja/Procesador: {c:N0}";
            lblDif.Text = $"Diferencia: {s - c:N0}";
        }

        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdControl.Rows = 1;
            Totales();
        }

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void ChkSoloDif_CheckedChanged(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel lbl = sender as ToolStripStatusLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1).Trim();

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void grdControl_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                double s = 0;
                double c = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    s += Convert.ToDouble(grdControl.get_Texto(i, c_Sucursal));
                    c += Convert.ToDouble(grdControl.get_Texto(i, c_Control));
                }

                int n = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {n:N0}";
                lblTotal.Text = $"Sucursal: {s:N0}";
                lblControl.Text = $"Caja/Procesador: {c:N0}";
                lblDif.Text = $"Diferencia: {s - c:N0}";
            }
        }
    }
}
