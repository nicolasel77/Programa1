namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmHacienda_Salidas : Form
    {
        private Hacienda_Salidas Salidas = new Hacienda_Salidas();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_Tropa;
        private Byte c_Categoria;
        private Byte c_Prod;
        private Byte c_Boleta;
        private Byte c_CostoCarne;
        private Byte c_CostoSalida;
        private Byte c_Media;
        private Byte c_Original;
        private Byte c_TotalCompra;
        private Byte c_TotalSalida;
        #endregion

        public frmHacienda_Salidas()
        {
            InitializeComponent();

            cFecha.Fecha_Maxima = Salidas.Max_Fecha();

            DataTable dt = Salidas.Tropas_Salidas("YEAR(Fecha)=" + DateTime.Now.Year);

            foreach (DataRow dr in dt.Rows)
            {
                lstTropas.Items.Add(dr[0].ToString());
            }
            dt = Salidas.Boletas_Salidas("YEAR(Fecha)=" + DateTime.Now.Year);

            foreach (DataRow dr in dt.Rows)
            {
                lstBoletas.Items.Add(dr[0].ToString());
            }

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdSalida.TeclasManejadas = n;

            grdSalida.MostrarDatos(Salidas.Datos_Salidas("Id=0"), true);

            c_Id = Convert.ToByte(grdSalida.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdSalida.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdSalida.get_ColIndex("Id_Sucursales"));
            c_Tropa = Convert.ToByte(grdSalida.get_ColIndex("Tropa"));
            c_Categoria = Convert.ToByte(grdSalida.get_ColIndex("Nombre_Categoria"));
            c_Prod = Convert.ToByte(grdSalida.get_ColIndex("Nombre_Producto"));
            c_Boleta = Convert.ToByte(grdSalida.get_ColIndex("NBoleta"));
            c_CostoCarne = Convert.ToByte(grdSalida.get_ColIndex("Costo_Carne"));
            c_CostoSalida = Convert.ToByte(grdSalida.get_ColIndex("Costo_Salida"));
            c_Media = Convert.ToByte(grdSalida.get_ColIndex("Media"));
            c_TotalCompra = Convert.ToByte(grdSalida.get_ColIndex("Total_Compra"));
            c_TotalSalida = Convert.ToByte(grdSalida.get_ColIndex("Total_Salida"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdSalida.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_Prod, c_Media);
            grdSalida.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Media);

            Totales();
        }

        private void FrmSalida_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucursal.Siguiente();
                    }

                    break;
                case Keys.Subtract:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucursal.Anterior();
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

            if (s.Length > 0)
            {
                grdSalida.MostrarDatos(Salidas.Datos_Salidas(s), true);
                grdResumen.MostrarDatos(Salidas.Resumen_Salidas(s), true);
                formato_Grilla();
                Totales();
                grdSalida.ActivarCelda(grdSalida.Rows - 1, c_Fecha);
                grdSalida.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string s = cSucursal.Cadena("Id_Sucursales");
            string p = cProds.Cadena("Id_Productos");
            string f = cFecha.Cadena();
            
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (lstBoletas.SelectedIndex > -1) f = h.Unir("NBoleta=" + lstBoletas.Text, f);
            if (lstTropas.SelectedIndex > -1) f = h.Unir("Tropa=" + lstTropas.Text, f);

            s = h.Unir(s, f);
            s = h.Unir(s, p);
            return s;
        }

        private void formato_Grilla()
        {
            grdSalida.set_ColW(c_Id, 0);
            grdSalida.set_ColW(c_Fecha, 60);
            grdSalida.set_ColW(c_IdSuc, 35);
            grdSalida.set_ColW(c_IdSuc + 1, 40);
            grdSalida.set_ColW(c_Prod, 30);
            grdSalida.set_ColW(c_CostoSalida, 60);
            grdSalida.set_ColW(c_CostoCarne, 60);
            grdSalida.set_ColW(c_Media, 60);
            grdSalida.set_ColW(c_TotalCompra, 80);
            grdSalida.set_ColW(c_TotalSalida, 80);

            grdSalida.Columnas[c_CostoSalida].Format = "C2";
            grdSalida.Columnas[c_CostoCarne].Format = "C2";
            grdSalida.Columnas[c_Media].Format = "N2";
            grdSalida.Columnas[c_TotalCompra].Format = "C2";
            grdSalida.Columnas[c_TotalSalida].Format = "C2";

            grdSalida.Columnas[c_Media].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdSalida.set_Texto(0, c_IdSuc, "Suc");
            grdSalida.set_Texto(0, c_Prod, "Prod");

            grdResumen.set_ColW(0, 40);
            grdResumen.set_ColW(1, 60);
            grdResumen.set_ColW(2, 40);

            grdResumen.Columnas[1].Format = "N0";

        }

        private void Totales()
        {
            double tSalida = grdSalida.SumarCol(c_TotalSalida, false);
            double tEntrada = grdSalida.SumarCol(c_TotalCompra, false);
            double k = grdSalida.SumarCol(c_Media, false);
            int c = grdSalida.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Salida: {tSalida:C2}";
            lblTotalE.Text = $"Total Compra: {tEntrada:C2}";
            lblDiferencia.Text = $"Diferencia: {(tSalida - tEntrada):C2}";

            grdResumen.SumarCol(1, true);
            grdResumen.SumarCol(2, true);
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdSalida.Rows = 1;
            grdSalida.Rows = 2;
            Totales();
        }


        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void Csuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            string vFecha = cFecha.Cadena();
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Hacienda_Salidas WHERE {vFecha})";
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM vw_Hacienda_Salidas WHERE {vFecha})";


            cmdMostrar.PerformClick();
        }


        private void GrdSalida_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdSalida.get_Texto(Fila, c_Id).ToString());
            Salidas.Cargar_Fila(i);
            Salidas.precios.Fecha = Salidas.Fecha;
            Salidas.precios.Sucursal = Salidas.Sucursal;
        }

        private void GrdSalida_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdSalida.get_Texto(grdSalida.Row, 0)) != 0)
                        {
                            Salidas.Id = Convert.ToInt32(grdSalida.get_Texto(grdSalida.Row, 0));
                            Salidas.Borrar();
                            grdSalida.BorrarFila(grdSalida.Row);
                            Totales();
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

        private void LstBoletas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void LstBoletas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) lstBoletas.SelectedIndex = -1;
        }
    }
}
