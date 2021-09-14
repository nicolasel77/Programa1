namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmCompras : Form
    {
        private Compras Compras;

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdCamion;
        private Byte c_IdProv;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Costo;
        private Byte c_Cantidad;
        private Byte c_Kilos;
        private Byte c_Total;
        private Byte c_Promedio;
        #endregion

        public frmCompras()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdCompras.TeclasManejadas = n;

            Compras = new Compras();
            grdCompras.MostrarDatos(Compras.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdCompras.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdCompras.get_ColIndex("Fecha"));
            c_IdCamion = Convert.ToByte(grdCompras.get_ColIndex("Id_Camion"));
            c_IdProv = Convert.ToByte(grdCompras.get_ColIndex("Id_Proveedores"));
            c_IdProd = Convert.ToByte(grdCompras.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdCompras.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grdCompras.get_ColIndex("Costo"));
            c_Cantidad = Convert.ToByte(grdCompras.get_ColIndex("Cantidad"));
            c_Kilos = Convert.ToByte(grdCompras.get_ColIndex("Kilos"));
            c_Total = Convert.ToByte(grdCompras.get_ColIndex("Total"));
            c_Promedio = Convert.ToByte(grdCompras.get_ColIndex("Promedio"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdCompras.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdCompras.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdProv, c_Kilos);

            Totales();

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstCamiones, Compras.Camion.Datos());
        }

        private void FrmCompras_KeyUp(object sender, KeyEventArgs e)
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

            string s = Armar_Cadena();
            grdCompras.MostrarDatos(Compras.Datos(s), true);
            formato_Grilla();
            Totales();
            grdCompras.ActivarCelda(grdCompras.Rows - 1, c_Fecha);
            grdCompras.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {

            string p = cProds.Cadena("Id_Productos");
            string s = cProvs.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            string c = h.Codigos_Seleccionados(lstCamiones);
            if (c != "") { c = $"ID_Camion IN {c}"; }

            s = h.Unir(f, s);
            s = h.Unir(s, p);
            s = h.Unir(s, c);

            return s;
        }

        private void formato_Grilla()
        {
            grdCompras.set_ColW(c_Id, 0);
            grdCompras.set_ColW(c_Fecha, 60);
            grdCompras.set_ColW(c_IdCamion, 30);
            grdCompras.set_ColW(c_IdProv, 30);
            grdCompras.set_ColW(c_IdProv + 1, 200);
            grdCompras.set_ColW(c_IdProd, 30);
            grdCompras.set_ColW(c_Descripcion, 350);
            grdCompras.set_ColW(c_Cantidad, 60);
            grdCompras.set_ColW(c_Costo, 70);
            grdCompras.set_ColW(c_Kilos, 80);
            grdCompras.set_ColW(c_Total, 90);
            grdCompras.set_ColW(c_Promedio, 70);

            if (chCantidad.Checked == true)
            {
                grdCompras.Columnas[c_Cantidad].Visible = true;
                grdCompras.Columnas[c_Promedio].Visible = true;
            }
            else
            {
                grdCompras.Columnas[c_Cantidad].Visible = false;
                grdCompras.Columnas[c_Promedio].Visible = false;
            }

            if (chCamiones.Checked == true)
            {
                grdCompras.Columnas[c_IdCamion].Visible = true;
            }
            else
            {
                grdCompras.Columnas[c_IdCamion].Visible = false;
            }

            grdCompras.Columnas[c_Costo].Format = "C2";
            grdCompras.Columnas[c_Kilos].Format = "N2";
            grdCompras.Columnas[c_Total].Format = "C2";
            grdCompras.Columnas[c_Promedio].Format = "N2";

            grdCompras.Columnas[c_IdProv + 1].Style.ForeColor = Color.DimGray;
            grdCompras.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdCompras.set_Texto(0, c_IdProv, "Prov");
            grdCompras.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double t = grdCompras.SumarCol(c_Total, false);
            double k = grdCompras.SumarCol(c_Kilos, false);
            int c = grdCompras.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotal.Text = $"Total: {t:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdCompras.Rows = 1;
            grdCompras.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Compras WHERE {vFecha})";
            cProvs.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Compras WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdCompras_Editado(short f, short c, object a)
        {
            if (Compras.Fecha_Cerrada(Compras.Fecha) == false)
            {
                int id = Convert.ToInt32(grdCompras.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (cFecha.Fecha_En_Rango(df))
                        {
                            if (Compras.Fecha_Cerrada(df) == false)
                            {
                                Compras.Fecha = df;
                                Compras.precios.Fecha = Compras.Fecha;

                                grdCompras.set_Texto(f, c, a);

                                if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                                else
                                {
                                    if (chCamiones.Checked == true) { grdCompras.ActivarCelda(f, c + 1); }
                                    else { grdCompras.ActivarCelda(f, c + 2); }
                                }

                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe estar dentro del rango fecha seleccionado.");
                            grdCompras.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //Camion
                        Compras.Camion.ID = Convert.ToInt32(a);
                        if (Compras.Camion.Existe() == true || Compras.Camion.ID == 0)
                        {
                            grdCompras.set_Texto(f, c, a);

                            if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                            else { grdCompras.ActivarCelda(f, c + 1); }
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro el camión {a}.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case 3:
                        //ID_Proveedores
                        Compras.Proveedor.Id = Convert.ToInt32(a);
                        if (Compras.Proveedor.Existe() == true)
                        {
                            Compras.precios.Proveedor = Compras.Proveedor;

                            grdCompras.set_Texto(f, c, a);
                            grdCompras.set_Texto(f, c + 1, Compras.Proveedor.Nombre);

                            if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                            else { grdCompras.ActivarCelda(f, c + 2); }
                        }
                        else
                        {
                            Mensaje("No se encontró la Proveedor " + a.ToString());
                            grdCompras.ErrorEnTxt();
                        }
                        break;
                    case 5:
                        //ID_Productos
                        Compras.Producto.ID = Convert.ToInt32(a);
                        if (Compras.Producto.Existe() == true)
                        {
                            Compras.precios.Producto = Compras.Producto;

                            Compras.Descripcion = Compras.Producto.Nombre;

                            grdCompras.set_Texto(f, c, a);
                            grdCompras.set_Texto(f, c + 1, Compras.Producto.Nombre);

                            Compras.Costo = Compras.precios.Buscar();
                            grdCompras.set_Texto(f, c_Costo, Compras.Costo);
                            grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);

                            if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                            else
                            {
                                if (chCantidad.Checked == true) { grdCompras.ActivarCelda(f, c_Cantidad); }
                                else { grdCompras.ActivarCelda(f, c_Kilos); }
                            }
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            grdCompras.ErrorEnTxt();
                        }
                        break;
                    case 6:
                        //Descripcion
                        Compras.Descripcion = a.ToString();
                        grdCompras.set_Texto(f, c, a);

                        if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                        else
                        {
                            if (chCantidad.Checked == true) { grdCompras.ActivarCelda(f, c_Cantidad); }
                            else { grdCompras.ActivarCelda(f, c_Kilos); }
                        }
                        break;

                    case 7:
                        //Costo
                        Compras.Costo = Convert.ToSingle(a);
                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);

                        if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                        else { grdCompras.ActivarCelda(f, c + 1); }
                        grdCompras.ActivarCelda(f + 1, c);
                        Totales();
                        break;

                    case 8:
                        //Cantidad
                        Compras.Cantidad = Convert.ToInt32(a);
                        grdCompras.set_Texto(f, c, a);
                        if (Compras.Kilos > 0 & Convert.ToInt32(a) > 0) { grdCompras.set_Texto(f, c_Promedio, Compras.Kilos / Compras.Cantidad); }
                        else { grdCompras.set_Texto(f, c_Promedio, 0); }

                        if (id != 0) { Compras.Actualizar(); grdCompras.ActivarCelda(f + 1, c); }
                        else { grdCompras.ActivarCelda(f, c_Kilos); }
                        Totales();
                        break;

                    case 9:
                        //Kilos
                        Compras.Kilos = Convert.ToSingle(a);
                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);
                        if (Convert.ToSingle(a) > 0 & Compras.Cantidad > 0)
                        { grdCompras.set_Texto(f, c_Promedio, Compras.Kilos / Compras.Cantidad); }
                        else { grdCompras.set_Texto(f, c_Promedio, 0); }

                        if (grdCompras.Row == grdCompras.Rows - 1)
                        {
                            Compras.Agregar();
                            grdCompras.set_Texto(f, c_Id, Compras.ID);
                            grdCompras.AgregarFila();
                            //Rellenar nueva fila

                            grdCompras.set_Texto(f + 1, c_Fecha, Compras.Fecha);
                            grdCompras.set_Texto(f + 1, c_IdCamion, Compras.Camion.ID);
                            grdCompras.set_Texto(f + 1, c_IdProv, Compras.Proveedor.Id);
                            grdCompras.set_Texto(f + 1, grdCompras.get_ColIndex("Nombre"), Compras.Proveedor.Nombre);

                            Compras.Producto.Siguiente();
                            Compras.precios.Producto = Compras.Producto;

                            Compras.Descripcion = Compras.Producto.Nombre;

                            grdCompras.set_Texto(f + 1, c_IdProd, Compras.Producto.ID);
                            grdCompras.set_Texto(f + 1, c_Descripcion, Compras.Descripcion);

                            Compras.Costo = Compras.precios.Buscar();
                            grdCompras.set_Texto(f + 1, c_Costo, Compras.Costo);
                            grdCompras.set_Texto(f + 1, c_Total, 0);

                            Compras.Kilos = 0;

                            if (chCantidad.Checked == true)
                            {
                                grdCompras.ActivarCelda(f + 1, c_Cantidad);
                            }
                            else
                            {
                                grdCompras.ActivarCelda(f + 1, c);
                            }
                        }
                        else
                        {
                            Compras.Actualizar();
                            grdCompras.ActivarCelda(f + 1, c);
                        }

                        Totales();
                        break;
                }
            }
            else
            {
                Mensaje("La fecha esta cerrada.");
            }
        }

        private void GrdCompras_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdCompras.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                Compras.Cargar_Fila(i);
                Compras.precios.Fecha = Compras.Fecha;
                Compras.precios.Proveedor = Compras.Proveedor;
                Compras.precios.Producto = Compras.Producto;
            }
            else
            {
                Compras.ID = 0;
                Compras.Camion.ID = Convert.ToInt32(grdCompras.get_Texto(Fila, c_IdCamion));
                Compras.Fecha = Convert.ToDateTime(grdCompras.get_Texto(Fila, c_Fecha));
                Compras.Producto.ID = Convert.ToInt32(grdCompras.get_Texto(Fila, c_IdProd));
                Compras.Descripcion = grdCompras.get_Texto(Fila, c_Descripcion).ToString();
                Compras.Proveedor.Id = Convert.ToInt32(grdCompras.get_Texto(Fila, c_IdProv));
                Compras.Costo = Convert.ToSingle(grdCompras.get_Texto(Fila, c_Costo));
                Compras.Cantidad = Convert.ToInt32(grdCompras.get_Texto(Fila, c_Cantidad));
                Compras.Kilos = Convert.ToSingle(grdCompras.get_Texto(Fila, c_Kilos));

                Compras.precios.Fecha = Compras.Fecha;
                Compras.precios.Proveedor = Compras.Proveedor;
                Compras.precios.Producto = Compras.Producto;
            }
        }

        private void GrdCompras_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Compras.ID == 0)
                {
                    if (grdCompras.Col == c_IdCamion)
                    {
                        grdCompras.ActivarCelda(grdCompras.Row, grdCompras.Col + 1);
                    }

                    if (grdCompras.Col == c_Kilos)
                    {
                        Compras.Producto.Siguiente();
                        Compras.precios.Producto = Compras.Producto;

                        Compras.Descripcion = Compras.Producto.Nombre;

                        grdCompras.set_Texto(grdCompras.Row, c_IdProd, Compras.Producto.ID);
                        grdCompras.set_Texto(grdCompras.Row, c_Descripcion, Compras.Descripcion);

                        Compras.Costo = Compras.precios.Buscar();
                        grdCompras.set_Texto(grdCompras.Row, c_Costo, Compras.Costo);
                        grdCompras.set_Texto(grdCompras.Row, c_Total, 0);
                    }
                }
            }
        }

        private void GrdCompras_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdCompras.get_Texto(grdCompras.Row, 0)) != 0)
                    {
                        if (Compras.Fecha_Cerrada(Compras.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Compras.ID = Convert.ToInt32(grdCompras.get_Texto(grdCompras.Row, 0));
                                Compras.Borrar();
                                grdCompras.BorrarFila(grdCompras.Row);
                                GrdCompras_CambioFila(Convert.ToByte(grdCompras.Row));
                                Totales();
                            }
                        }
                        else
                        {
                            Mensaje("La fecha esta cerrada.");
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
            if (grdCompras.Rows > 2)
            {
                //frmCMCompras cm = new frmCMCompras();
                //List<int> n = new List<int>();

                //int d = grdCompras.Selection.r1;
                //int h = grdCompras.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdCompras.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdCompras.get_Texto(i, c_Id)));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }

        private void lstCamiones_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) { lstCamiones.SelectedIndex = -1; }
        }

        private void lstCamiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void grdCompras_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float k = 0, tc = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    k += Convert.ToSingle(grdCompras.get_Texto(i, c_Kilos));
                    tc += Convert.ToSingle(grdCompras.get_Texto(i, c_Total));
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";
                lblKilos.Text = $"Kilos: {k:N2}";
                lblTotal.Text = $"Total Venta: {tc:C2}";
            }
        }

        private void chMenudencias_CheckedChanged(object sender, EventArgs e)
        {
            if (chCantidad.Checked == true)
            {
                grdCompras.Columnas[c_Cantidad].Visible = true;
                grdCompras.Columnas[c_Promedio].Visible = true;
            }
            else
            {
                grdCompras.Columnas[c_Cantidad].Visible = false;
                grdCompras.Columnas[c_Promedio].Visible = false;
            }
        }

        private void chCamiones_CheckedChanged(object sender, EventArgs e)
        {
            if (chCamiones.Checked == true)
            {
                grdCompras.Columnas[c_IdCamion].Visible = true;
            }
            else
            {
                grdCompras.Columnas[c_IdCamion].Visible = false;
            }
        }
    }
}
