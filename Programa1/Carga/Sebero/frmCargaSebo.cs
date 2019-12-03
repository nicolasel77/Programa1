namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmCargaSebo : Form
    {
        private CargaSebo cargaSebo = new CargaSebo();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSebero;
        private Byte c_IdSuc;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Costo;
        private Byte c_Kilos;
        private Byte c_Total;
        #endregion

        public frmCargaSebo()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdVenta.TeclasManejadas = n;

            grdVenta.MostrarDatos(cargaSebo.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdVenta.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdVenta.get_ColIndex("Fecha"));
            c_IdSebero = Convert.ToByte(grdVenta.get_ColIndex("Id_Seberos"));
            c_IdSuc = Convert.ToByte(grdVenta.get_ColIndex("Id_Sucursales"));
            c_IdProd = Convert.ToByte(grdVenta.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdVenta.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grdVenta.get_ColIndex("Costo"));
            c_Kilos = Convert.ToByte(grdVenta.get_ColIndex("Kilos"));
            c_Total = Convert.ToByte(grdVenta.get_ColIndex("Total"));
            
            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSebero, c_Kilos);

            Totales();
        }

        private void FrmVenta_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucursal.Siguiente();
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
                        cSucursal.Anterior();
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
            grdVenta.MostrarDatos(cargaSebo.Datos(s), true);
            formato_Grilla();
            Totales();
            grdVenta.ActivarCelda(grdVenta.Rows - 1, c_Fecha);
            grdVenta.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucursal.Cadena("Id_Sucursales");
            string e = cSeberos.Cadena("Id_Seberos");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(s, e);
            s = h.Unir(s, f);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdVenta.set_ColW(c_Id, 0);
            grdVenta.set_ColW(c_Fecha, 60);
            grdVenta.set_ColW(c_IdSebero, 35);
            grdVenta.set_ColW(c_IdSebero + 1, 100);
            grdVenta.set_ColW(c_IdSuc, 35);
            grdVenta.set_ColW(c_IdSuc + 1, 100);
            grdVenta.set_ColW(c_IdProd, 30);
            grdVenta.set_ColW(c_Descripcion, 120);
            grdVenta.set_ColW(c_Costo, 60);
            grdVenta.set_ColW(c_Kilos, 60);
            grdVenta.set_ColW(c_Total, 80);

            grdVenta.Columnas[c_Costo].Format = "C2";
            grdVenta.Columnas[c_Kilos].Format = "N2";
            grdVenta.Columnas[c_Total].Format = "C2";

            grdVenta.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdVenta.set_Texto(0, c_IdSuc, "Suc");
            grdVenta.set_Texto(0, c_IdSebero, "Sebero");
            grdVenta.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double tEntrada = grdVenta.SumarCol(c_Total, false);
            double k = grdVenta.SumarCol(c_Kilos, false);
            int c = grdVenta.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalE.Text = $"Total: {tEntrada:C2}";

        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdVenta.Rows = 1;
            grdVenta.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM CargaSebo WHERE {vFecha})";
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM CargaSebo WHERE {vFecha})";
            //cSeberos.Filtro_In = $" (SELECT DISTINCT Id_Seberos FROM Ventas WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdVenta_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdVenta.get_Texto(f, c_Id));
            switch (c)
            {
                case 1:
                    //Fecha
                    DateTime df = Convert.ToDateTime(a);
                    if (df >= cFecha.fecha_Actual)
                    {
                        cargaSebo.Fecha = df;
                        cargaSebo.precios_Seberos.Fecha = cargaSebo.Fecha;

                        if (id != 0) { cargaSebo.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.ActivarCelda(f, c + 1);
                    }
                    else
                    {
                        Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case 2:
                    //Id_Seberos
                    cargaSebo.Sebero.Id = Convert.ToInt32(a);
                    if (cargaSebo.Sebero.Existe() == true)
                    {
                        cargaSebo.precios_Seberos.Proveedor.Id = cargaSebo.Sebero.Id;

                        if (id != 0) { cargaSebo.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, cargaSebo.Sebero.Nombre);

                        grdVenta.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró el Sebero " + a.ToString());
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //Id_Sucursales
                    cargaSebo.Sucursal.Id = Convert.ToInt32(a);
                    if (cargaSebo.Sucursal.Existe() == true)
                    {
                        if (id != 0) { cargaSebo.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, cargaSebo.Sucursal.Nombre);

                        grdVenta.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la sucursal " + a.ToString());
                        grdVenta.ErrorEnTxt();
                    }
                    break;

                case 6:
                    //ID_Productos
                    cargaSebo.Producto.Id = Convert.ToInt32(a);
                    if (cargaSebo.Producto.Existe() == true)
                    {
                        cargaSebo.precios_Seberos.Producto = cargaSebo.Producto;

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, cargaSebo.Producto.Nombre);

                        cargaSebo.precios_Seberos.Proveedor.Id = cargaSebo.Sebero.Id;
                        grdVenta.set_Texto(f, c_Costo, cargaSebo.Costo);
                        grdVenta.set_Texto(f, c_Total, cargaSebo.Kilos * cargaSebo.Costo);

                        if (id != 0) { cargaSebo.Actualizar(); }

                        grdVenta.ActivarCelda(f, c_Kilos);
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case 7:
                    //Descripcion
                    Mensaje("No se puede cambiar la descripción.");
                    break;
                case 8:
                    //Costo
                    cargaSebo.Costo = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, c_Total, cargaSebo.Costo * cargaSebo.Kilos);

                    if (id != 0) { cargaSebo.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    Totales();
                    break;

                case 10:
                    //Kilos
                    cargaSebo.Kilos = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, c_Total, cargaSebo.Costo * cargaSebo.Kilos);

                    if (grdVenta.Row == grdVenta.Rows - 1)
                    {
                        cargaSebo.Agregar();
                        grdVenta.set_Texto(f, c_Id, cargaSebo.Id);
                        grdVenta.AgregarFila();

                        //Rellenar nueva fila

                        grdVenta.set_Texto(f + 1, c_Fecha, cargaSebo.Fecha);
                        grdVenta.set_Texto(f + 1, c_IdSebero, cargaSebo.Sebero.Id);
                        grdVenta.set_Texto(f + 1, c_IdSebero + 1, cargaSebo.Sucursal.Nombre);
                        grdVenta.set_Texto(f + 1, c_IdSuc, cargaSebo.Sucursal.Id);
                        grdVenta.set_Texto(f + 1, c_IdSuc + 1, cargaSebo.Sucursal.Nombre);

                        cargaSebo.Producto.Siguiente();
                        cargaSebo.precios_Seberos.Producto = cargaSebo.Producto;

                        grdVenta.set_Texto(f + 1, c_IdProd, cargaSebo.Producto.Id);
                        grdVenta.set_Texto(f + 1, c_Descripcion, cargaSebo.Producto.Nombre);

                        cargaSebo.Costo = cargaSebo.precios_Seberos.Buscar();
                        grdVenta.set_Texto(f + 1, c_Costo, cargaSebo.Costo);
                        grdVenta.set_Texto(f + 1, c_Total, 0);

                        cargaSebo.Kilos = 0;
                        grdVenta.ActivarCelda(f + 1, c_Kilos);
                    }
                    else
                    {
                        cargaSebo.Actualizar();
                        grdVenta.ActivarCelda(f + 1, c);
                    }

                    Totales();
                    break;
            }

        }

        private void GrdVenta_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdVenta.get_Texto(Fila, c_Id).ToString());
            cargaSebo.Cargar_Fila(i);

            cargaSebo.precios_Seberos.Fecha = cargaSebo.Fecha;
            cargaSebo.precios_Seberos.Proveedor.Id = cargaSebo.Sebero.Id;
            cargaSebo.precios_Seberos.Producto = cargaSebo.Producto;

        }

        private void GrdVenta_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (cargaSebo.Id == 0)
                {

                    if (grdVenta.Col == c_Kilos)
                    {
                        cargaSebo.Producto.Siguiente();

                        grdVenta.set_Texto(grdVenta.Row, c_IdProd, cargaSebo.Producto.Id);
                        grdVenta.set_Texto(grdVenta.Row, c_Descripcion, cargaSebo.Producto.Nombre);

                        cargaSebo.precios_Seberos.Proveedor.Id = cargaSebo.Sebero.Id;
                        cargaSebo.Costo = cargaSebo.precios_Seberos.Buscar();
                        grdVenta.set_Texto(grdVenta.Row, c_Costo, cargaSebo.Costo);
                        grdVenta.set_Texto(grdVenta.Row, c_Total, 0);
                    }
                }
            }
        }

        private void GrdVenta_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdVenta.get_Texto(grdVenta.Row, 0)) != 0)
                        {
                            cargaSebo.Id = Convert.ToInt32(grdVenta.get_Texto(grdVenta.Row, 0));
                            cargaSebo.Borrar();
                            grdVenta.BorrarFila(grdVenta.Row);
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


    }
}
