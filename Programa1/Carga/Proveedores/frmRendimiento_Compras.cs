namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;


    public partial class frmRendimiento_Compras : Form
    {
        private Rendimiento_Compras Rendimiento_Compras;
        private C1.Win.C1FlexGrid.CellStyle cellStyle;
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmRendimiento_Compras()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdRendimiento_Compras.TeclasManejadas = n;

            Rendimiento_Compras = new Rendimiento_Compras();
            grdRendimiento_Compras.MostrarDatos(Rendimiento_Compras.Datos("Id=0"), true);

            grdRendimiento_Compras.set_ColW(0, 30);
            grdRendimiento_Compras.set_ColW(1, 150);
            for (int i = 2; i < grdRendimiento_Compras.Cols; i++)
            {
                grdRendimiento_Compras.set_ColW(i, 80);
                grdRendimiento_Compras.Columnas[i].Format = "N1";
            }

            cellStyle = grdRendimiento_Compras.Styles.Add("Rojo");
            cellStyle.BackColor = Color.MistyRose;
            
            Ventas v = new Ventas();
            h.Llenar_List(lstCamiones, v.Camion.Datos());
        }

        private void FrmRendimiento_Compras_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Siguiente();
                    }
                    else
                    {
                        if (e.Shift)
                        {
                            e.Handled = true;
                            cProds.Siguiente();
                        }
                    }
                    break;
                case Keys.Subtract:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Anterior();
                    }
                    else
                    {
                        if (e.Shift)
                        {
                            e.Handled = true;
                            cProds.Anterior();
                        }
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

            string p = cProds.Cadena("Id");
            string s = cProvs.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();
            string camiones = h.Codigos_Seleccionados(lstCamiones);

            grdRendimiento_Compras.MostrarDatos(Rendimiento_Compras.Datos(f, chOcultar.Checked, s, p, camiones), false, true);

            Totales();

            this.Cursor = Cursors.Default;
        }



        private void Totales()
        {
            double kcomp = grdRendimiento_Compras.SumarCol(2, true);
            double kven = grdRendimiento_Compras.SumarCol(3, true);
            double tcomp = grdRendimiento_Compras.SumarCol(4, true);
            double tven = grdRendimiento_Compras.SumarCol(5, true);
            grdRendimiento_Compras.SumarCol(6, true);
            grdRendimiento_Compras.SumarCol(8, true);
            int c = grdRendimiento_Compras.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilosC.Text = $"Kilos Compra: {kcomp:N2}";
            lblTotalC.Text = $"Total Compra: {tcomp:C2}";
            lblKilosV.Text = $"Kilos Venta: {kven:N2}";
            lblTotalV.Text = $"Total Venta: {tven:C2}";

            for (int i = 1; i < grdRendimiento_Compras.Rows - 1; i++)
            {
                if (Convert.ToSingle(grdRendimiento_Compras.get_Texto(i, 6)) < 0)
                {
                    grdRendimiento_Compras.Filas[i].Style = cellStyle;
                }
            }
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdRendimiento_Compras.Rows = 1;
            grdRendimiento_Compras.Rows = 2;
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
            cmdMostrar.PerformClick();
        }

        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void ChOcultar_CheckedChanged(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }
    }
}
