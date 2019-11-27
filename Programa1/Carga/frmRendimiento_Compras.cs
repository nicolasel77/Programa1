namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmRendimiento_Compras : Form
    {
        private Rendimiento_Compras Rendimiento_Compras;


        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdProv;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Costo;
        private Byte c_Kilos;
        private Byte c_Total;
        #endregion

        public frmRendimiento_Compras()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdRendimiento_Compras.TeclasManejadas = n;

            Rendimiento_Compras = new Rendimiento_Compras();
            grdRendimiento_Compras.MostrarDatos(Rendimiento_Compras.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Fecha"));
            c_IdProv = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Id_Proveedores"));
            c_IdProd = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Costo"));
            c_Kilos = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Kilos"));
            c_Total = Convert.ToByte(grdRendimiento_Compras.get_ColIndex("Total"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdRendimiento_Compras.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdRendimiento_Compras.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

            Totales();
        }

        private void FrmRendimiento_Compras_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucs.Siguiente();
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
                        cSucs.Anterior();
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
            grdRendimiento_Compras.MostrarDatos(Rendimiento_Compras.Datos(s), true);
            formato_Grilla();
            Totales();
            grdRendimiento_Compras.ActivarCelda(grdRendimiento_Compras.Rows - 1, c_Fecha);
            grdRendimiento_Compras.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucs.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdRendimiento_Compras.set_ColW(c_Id, 0);
            grdRendimiento_Compras.set_ColW(c_Fecha, 60);
            grdRendimiento_Compras.set_ColW(c_IdProv, 30);
            grdRendimiento_Compras.set_ColW(c_IdProv + 1, 100);
            grdRendimiento_Compras.set_ColW(c_IdProd, 30);
            grdRendimiento_Compras.set_ColW(c_Descripcion, 150);
            grdRendimiento_Compras.set_ColW(c_Costo, 60);
            grdRendimiento_Compras.set_ColW(c_Kilos, 60);
            grdRendimiento_Compras.set_ColW(c_Total, 80);

            grdRendimiento_Compras.Columnas[c_Costo].Format = "C2";
            grdRendimiento_Compras.Columnas[c_Kilos].Format = "N2";
            grdRendimiento_Compras.Columnas[c_Total].Format = "C2";

            grdRendimiento_Compras.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdRendimiento_Compras.set_Texto(0, c_IdProv, "Suc");
            grdRendimiento_Compras.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double t = grdRendimiento_Compras.SumarCol(c_Total, false);
            double k = grdRendimiento_Compras.SumarCol(c_Kilos, false);
            int c = grdRendimiento_Compras.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotal.Text = $"Total: {t:C2}";
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
            string vFecha = cFecha.Cadena();
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Rendimiento_Compras WHERE {vFecha})";
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Rendimiento_Compras WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdRendimiento_Compras_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdRendimiento_Compras.get_Texto(f, c_Id));
            switch (c)
            {
                case 1:
                    //Fecha
                    DateTime df = Convert.ToDateTime(a);
                    if (df >= cFecha.fecha_Actual)
                    {
                        Rendimiento_Compras.Fecha = df;
                        Rendimiento_Compras.precios.Fecha = Rendimiento_Compras.Fecha;

                        if (id != 0) { Rendimiento_Compras.Actualizar(); }

                        grdRendimiento_Compras.set_Texto(f, c, a);
                        grdRendimiento_Compras.ActivarCelda(f, c + 1);
                    }
                    else
                    {
                        Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                        grdRendimiento_Compras.ErrorEnTxt();
                    }
                    break;
                case 2:
                    //ID_Proveedores
                    Rendimiento_Compras.Proveedor.Id = Convert.ToInt32(a);
                    if (Rendimiento_Compras.Proveedor.Existe() == true)
                    {
                        Rendimiento_Compras.precios.Proveedor = Rendimiento_Compras.Proveedor;

                        if (id != 0) { Rendimiento_Compras.Actualizar(); }

                        grdRendimiento_Compras.set_Texto(f, c, a);
                        grdRendimiento_Compras.set_Texto(f, c + 1, Rendimiento_Compras.Proveedor.Nombre);

                        grdRendimiento_Compras.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la Proveedor " + a.ToString());
                        grdRendimiento_Compras.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //ID_Productos
                    Rendimiento_Compras.Producto.Id = Convert.ToInt32(a);
                    if (Rendimiento_Compras.Producto.Existe() == true)
                    {
                        Rendimiento_Compras.precios.Producto = Rendimiento_Compras.Producto;

                        Rendimiento_Compras.Descripcion = Rendimiento_Compras.Producto.Nombre;

                        grdRendimiento_Compras.set_Texto(f, c, a);
                        grdRendimiento_Compras.set_Texto(f, c + 1, Rendimiento_Compras.Producto.Nombre);

                        Rendimiento_Compras.Costo = Rendimiento_Compras.precios.Buscar();
                        grdRendimiento_Compras.set_Texto(f, c_Costo, Rendimiento_Compras.Costo);
                        grdRendimiento_Compras.set_Texto(f, c_Total, Rendimiento_Compras.Costo * Rendimiento_Compras.Kilos);

                        if (id != 0) { Rendimiento_Compras.Actualizar(); }

                        grdRendimiento_Compras.ActivarCelda(f, c_Kilos);
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdRendimiento_Compras.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    Rendimiento_Compras.Descripcion = a.ToString();
                    grdRendimiento_Compras.set_Texto(f, c, a);

                    if (id != 0) { Rendimiento_Compras.Actualizar(); }

                    grdRendimiento_Compras.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo
                    Rendimiento_Compras.Costo = Convert.ToSingle(a);
                    grdRendimiento_Compras.set_Texto(f, c, a);
                    grdRendimiento_Compras.set_Texto(f, c_Total, Rendimiento_Compras.Costo * Rendimiento_Compras.Kilos);

                    if (id != 0) { Rendimiento_Compras.Actualizar(); }

                    grdRendimiento_Compras.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 7:
                    //Kilos
                    Rendimiento_Compras.Kilos = Convert.ToSingle(a);
                    grdRendimiento_Compras.set_Texto(f, c, a);
                    grdRendimiento_Compras.set_Texto(f, c_Total, Rendimiento_Compras.Costo * Rendimiento_Compras.Kilos);

                    if (grdRendimiento_Compras.Row == grdRendimiento_Compras.Rows - 1)
                    {
                        Rendimiento_Compras.Agregar();
                        grdRendimiento_Compras.set_Texto(f, c_Id, Rendimiento_Compras.Id);
                        grdRendimiento_Compras.AgregarFila();
                        //Rellenar nueva fila

                        grdRendimiento_Compras.set_Texto(f + 1, c_Fecha, Rendimiento_Compras.Fecha);
                        grdRendimiento_Compras.set_Texto(f + 1, c_IdProv, Rendimiento_Compras.Proveedor.Id);
                        grdRendimiento_Compras.set_Texto(f + 1, grdRendimiento_Compras.get_ColIndex("Nombre"), Rendimiento_Compras.Proveedor.Nombre);

                        Rendimiento_Compras.Producto.Siguiente();
                        Rendimiento_Compras.precios.Producto = Rendimiento_Compras.Producto;

                        Rendimiento_Compras.Descripcion = Rendimiento_Compras.Producto.Nombre;

                        grdRendimiento_Compras.set_Texto(f + 1, c_IdProd, Rendimiento_Compras.Producto.Id);
                        grdRendimiento_Compras.set_Texto(f + 1, c_Descripcion, Rendimiento_Compras.Descripcion);

                        Rendimiento_Compras.Costo = Rendimiento_Compras.precios.Buscar();
                        grdRendimiento_Compras.set_Texto(f + 1, c_Costo, Rendimiento_Compras.Costo);
                        grdRendimiento_Compras.set_Texto(f + 1, c_Total, 0);

                        Rendimiento_Compras.Kilos = 0;
                    }
                    else
                    {
                        Rendimiento_Compras.Actualizar();
                    }
                    grdRendimiento_Compras.ActivarCelda(f + 1, c);

                    Totales();
                    break;
            }

        }

        private void GrdRendimiento_Compras_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdRendimiento_Compras.get_Texto(Fila, c_Id).ToString());
            Rendimiento_Compras.Cargar_Fila(i);
            Rendimiento_Compras.precios.Fecha = Rendimiento_Compras.Fecha;
            Rendimiento_Compras.precios.Proveedor = Rendimiento_Compras.Proveedor;
            Rendimiento_Compras.precios.Producto = Rendimiento_Compras.Producto;
        }

        private void GrdRendimiento_Compras_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Rendimiento_Compras.Id == 0)
                {

                    if (grdRendimiento_Compras.Col == c_Kilos)
                    {
                        Rendimiento_Compras.Producto.Siguiente();
                        Rendimiento_Compras.precios.Producto = Rendimiento_Compras.Producto;

                        Rendimiento_Compras.Descripcion = Rendimiento_Compras.Producto.Nombre;

                        grdRendimiento_Compras.set_Texto(grdRendimiento_Compras.Row, c_IdProd, Rendimiento_Compras.Producto.Id);
                        grdRendimiento_Compras.set_Texto(grdRendimiento_Compras.Row, c_Descripcion, Rendimiento_Compras.Descripcion);

                        Rendimiento_Compras.Costo = Rendimiento_Compras.precios.Buscar();
                        grdRendimiento_Compras.set_Texto(grdRendimiento_Compras.Row, c_Costo, Rendimiento_Compras.Costo);
                        grdRendimiento_Compras.set_Texto(grdRendimiento_Compras.Row, c_Total, 0);
                    }
                }
            }
        }

        private void GrdRendimiento_Compras_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdRendimiento_Compras.get_Texto(grdRendimiento_Compras.Row, 0)) != 0)
                        {
                            Rendimiento_Compras.Id = Convert.ToInt32(grdRendimiento_Compras.get_Texto(grdRendimiento_Compras.Row, 0));
                            Rendimiento_Compras.Borrar();
                            grdRendimiento_Compras.BorrarFila(grdRendimiento_Compras.Row);
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


        private void CmdCambioMasivo_Click(object sender, EventArgs e)
        {
            if (grdRendimiento_Compras.Rows > 2)
            {
                //frmCMRendimiento_Compras cm = new frmCMRendimiento_Compras();
                //List<int> n = new List<int>();

                //int d = grdRendimiento_Compras.Selection.r1;
                //int h = grdRendimiento_Compras.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdRendimiento_Compras.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdRendimiento_Compras.get_Texto(i, c_Id)));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }
    }
}
