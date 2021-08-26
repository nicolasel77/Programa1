namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmDevoluciones : Form
    {
        private Devoluciones devoluciones;

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdProv;
        private Byte c_IdSuc;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_CostoCompra;
        private Byte c_CostoVenta;
        private Byte c_Kilos;
        private Byte c_TotalCompra;
        private Byte c_TotalVenta;
        #endregion

        public frmDevoluciones()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            GrdDevoluciones.TeclasManejadas = n;

            devoluciones = new Devoluciones();
            GrdDevoluciones.MostrarDatos(devoluciones.Datos("Id=0"), true);

            c_Id = Convert.ToByte(GrdDevoluciones.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(GrdDevoluciones.get_ColIndex("Fecha"));
            c_IdProv = Convert.ToByte(GrdDevoluciones.get_ColIndex("Id_Proveedores"));
            c_IdSuc = Convert.ToByte(GrdDevoluciones.get_ColIndex("Id_Sucursales"));
            c_IdProd = Convert.ToByte(GrdDevoluciones.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(GrdDevoluciones.get_ColIndex("Descripcion"));
            c_CostoCompra = Convert.ToByte(GrdDevoluciones.get_ColIndex("Costo_Compra"));
            c_CostoVenta = Convert.ToByte(GrdDevoluciones.get_ColIndex("Costo_Venta"));
            c_Kilos = Convert.ToByte(GrdDevoluciones.get_ColIndex("Kilos"));
            c_TotalCompra = Convert.ToByte(GrdDevoluciones.get_ColIndex("Total_Compra"));
            c_TotalVenta = Convert.ToByte(GrdDevoluciones.get_ColIndex("Total_Venta"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            GrdDevoluciones.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            GrdDevoluciones.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Kilos);
            GrdDevoluciones.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

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
            GrdDevoluciones.MostrarDatos(devoluciones.Datos(s), true);
            formato_Grilla();
            Totales();
            GrdDevoluciones.ActivarCelda(GrdDevoluciones.Rows - 1, c_Fecha);
            GrdDevoluciones.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucursal.Cadena("Id_Sucursales");
            string e = cProveedores.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(s, e);
            s = h.Unir(s, f);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            GrdDevoluciones.set_ColW(c_Id, 0);
            GrdDevoluciones.set_ColW(c_Fecha, 60);
            GrdDevoluciones.set_ColW(c_IdProv, 35);
            GrdDevoluciones.set_ColW(c_IdProv + 1, 40);
            GrdDevoluciones.set_ColW(c_IdSuc, 35);
            GrdDevoluciones.set_ColW(c_IdSuc + 1, 40);
            GrdDevoluciones.set_ColW(c_IdProd, 30);
            GrdDevoluciones.set_ColW(c_Descripcion, 120);
            GrdDevoluciones.set_ColW(c_CostoVenta, 60);
            GrdDevoluciones.set_ColW(c_CostoCompra, 60);
            GrdDevoluciones.set_ColW(c_Kilos, 60);
            GrdDevoluciones.set_ColW(c_TotalCompra, 80);
            GrdDevoluciones.set_ColW(c_TotalVenta, 80);

            GrdDevoluciones.Columnas[c_CostoVenta].Format = "C2";
            GrdDevoluciones.Columnas[c_CostoCompra].Format = "C2";
            GrdDevoluciones.Columnas[c_Kilos].Format = "N2";
            GrdDevoluciones.Columnas[c_TotalCompra].Format = "C2";
            GrdDevoluciones.Columnas[c_TotalVenta].Format = "C2";

            GrdDevoluciones.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            GrdDevoluciones.set_Texto(0, c_IdSuc, "Suc");
            GrdDevoluciones.set_Texto(0, c_IdProv, "Prov");
            GrdDevoluciones.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double tSalida = GrdDevoluciones.SumarCol(c_TotalVenta, false);
            double tEntrada = GrdDevoluciones.SumarCol(c_TotalCompra, false);
            double k = GrdDevoluciones.SumarCol(c_Kilos, false);
            int c = GrdDevoluciones.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Venta: {tSalida:C2}";
            lblTotalE.Text = $"Total Compra: {tEntrada:C2}";
            lblDiferencia.Text = $"Diferencia: {(tSalida - tEntrada):C2}";

        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            GrdDevoluciones.Rows = 1;
            GrdDevoluciones.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Devoluciones WHERE {vFecha})";
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Devoluciones WHERE {vFecha})";
            cProveedores.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Devoluciones WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdDevoluciones_Editado(short f, short c, object a)
        {
            if (devoluciones.Fecha_Cerrada(devoluciones.Fecha) == false)
            {
                int id = Convert.ToInt32(GrdDevoluciones.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (devoluciones.Fecha_Cerrada(df) == false)
                            {
                                devoluciones.Fecha = df;
                                devoluciones.precios.Fecha = devoluciones.Fecha;
                                devoluciones.precios_Proveedores.Fecha = devoluciones.Fecha;

                                if (id != 0) { devoluciones.Actualizar(); }

                                GrdDevoluciones.set_Texto(f, c, a);
                                GrdDevoluciones.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                            GrdDevoluciones.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //Id_Proveedores
                        devoluciones.Proveedor.Id = Convert.ToInt32(a);
                        if (devoluciones.Proveedor.Existe() == true)
                        {
                            devoluciones.precios_Proveedores.Proveedor = devoluciones.Proveedor;

                            if (id != 0) { devoluciones.Actualizar(); }

                            GrdDevoluciones.set_Texto(f, c, a);
                            GrdDevoluciones.set_Texto(f, c + 1, devoluciones.Proveedor.Nombre);

                            GrdDevoluciones.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró el proveedor " + a.ToString());
                            GrdDevoluciones.ErrorEnTxt();
                        }
                        break;
                    case 4:
                        //Id_Sucursales
                        devoluciones.Sucursal.ID = Convert.ToInt32(a);
                        if (devoluciones.Sucursal.Existe() == true)
                        {
                            devoluciones.precios.Sucursal = devoluciones.Sucursal;

                            if (id != 0) { devoluciones.Actualizar(); }

                            GrdDevoluciones.set_Texto(f, c, a);
                            GrdDevoluciones.set_Texto(f, c + 1, devoluciones.Sucursal.Nombre);

                            GrdDevoluciones.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            GrdDevoluciones.ErrorEnTxt();
                        }
                        break;

                    case 6:
                        //ID_Productos
                        devoluciones.Producto.ID = Convert.ToInt32(a);
                        if (devoluciones.Producto.Existe() == true)
                        {
                            devoluciones.precios.Producto = devoluciones.Producto;
                            devoluciones.precios_Proveedores.Producto = devoluciones.Producto;

                            devoluciones.Descripcion = devoluciones.Producto.Nombre;

                            GrdDevoluciones.set_Texto(f, c, a);
                            GrdDevoluciones.set_Texto(f, c + 1, devoluciones.Producto.Nombre);

                            devoluciones.precios.Sucursal = devoluciones.Sucursal;
                            devoluciones.CostoVenta = devoluciones.precios.Buscar();
                            GrdDevoluciones.set_Texto(f, c_CostoVenta, devoluciones.CostoVenta);
                            GrdDevoluciones.set_Texto(f, c_TotalVenta, devoluciones.Kilos * devoluciones.CostoVenta);

                            devoluciones.precios_Proveedores.Proveedor = devoluciones.Proveedor;
                            devoluciones.CostoCompra = devoluciones.precios_Proveedores.Buscar();
                            GrdDevoluciones.set_Texto(f, c_CostoCompra, devoluciones.CostoCompra);
                            GrdDevoluciones.set_Texto(f, c_TotalCompra, devoluciones.Kilos * devoluciones.CostoCompra);

                            if (id != 0) { devoluciones.Actualizar(); }

                            GrdDevoluciones.ActivarCelda(f, c_Kilos);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            GrdDevoluciones.ErrorEnTxt();
                        }
                        break;
                    case 7:
                        //Descripcion
                        devoluciones.Descripcion = a.ToString();
                        GrdDevoluciones.set_Texto(f, c, a);

                        if (id != 0) { devoluciones.Actualizar(); }

                        GrdDevoluciones.ActivarCelda(f + 1, c);
                        break;
                    case 8:
                        //Costo_Compra
                        devoluciones.CostoCompra = Convert.ToSingle(a);
                        GrdDevoluciones.set_Texto(f, c, a);
                        GrdDevoluciones.set_Texto(f, c_TotalCompra, devoluciones.CostoCompra * devoluciones.Kilos);

                        if (id != 0) { devoluciones.Actualizar(); }

                        GrdDevoluciones.ActivarCelda(f + 1, c);
                        Totales();
                        break;
                    case 9:
                        //Costo_Venta
                        devoluciones.CostoVenta = Convert.ToSingle(a);
                        GrdDevoluciones.set_Texto(f, c, a);
                        GrdDevoluciones.set_Texto(f, c_TotalVenta, devoluciones.CostoVenta * devoluciones.Kilos);

                        if (id != 0) { devoluciones.Actualizar(); }

                        GrdDevoluciones.ActivarCelda(f + 1, c);
                        Totales();
                        break;

                    case 10:
                        //Kilos
                        devoluciones.Kilos = Convert.ToSingle(a);
                        GrdDevoluciones.set_Texto(f, c, a);
                        GrdDevoluciones.set_Texto(f, c_TotalVenta, devoluciones.CostoVenta * devoluciones.Kilos);
                        GrdDevoluciones.set_Texto(f, c_TotalCompra, devoluciones.CostoCompra * devoluciones.Kilos);

                        if (GrdDevoluciones.Row == GrdDevoluciones.Rows - 1)
                        {
                            devoluciones.Agregar();
                            GrdDevoluciones.set_Texto(f, c_Id, devoluciones.ID);
                            GrdDevoluciones.AgregarFila();

                            //Rellenar nueva fila

                            GrdDevoluciones.set_Texto(f + 1, c_Fecha, devoluciones.Fecha);
                            GrdDevoluciones.set_Texto(f + 1, c_IdProv, devoluciones.Proveedor.Id);
                            GrdDevoluciones.set_Texto(f + 1, c_IdProv + 1, devoluciones.Proveedor.Nombre);
                            GrdDevoluciones.set_Texto(f + 1, c_IdSuc, devoluciones.Sucursal.ID);
                            GrdDevoluciones.set_Texto(f + 1, c_IdSuc + 1, devoluciones.Sucursal.Nombre);

                            devoluciones.Producto.Siguiente();
                            devoluciones.precios.Producto = devoluciones.Producto;
                            devoluciones.precios_Proveedores.Producto = devoluciones.Producto;

                            devoluciones.Descripcion = devoluciones.Producto.Nombre;

                            GrdDevoluciones.set_Texto(f + 1, c_IdProd, devoluciones.Producto.ID);
                            GrdDevoluciones.set_Texto(f + 1, c_Descripcion, devoluciones.Descripcion);


                            devoluciones.CostoVenta = devoluciones.precios.Buscar();
                            GrdDevoluciones.set_Texto(f + 1, c_CostoVenta, devoluciones.CostoVenta);
                            GrdDevoluciones.set_Texto(f + 1, c_TotalVenta, 0);

                            devoluciones.CostoCompra = devoluciones.precios_Proveedores.Buscar();
                            GrdDevoluciones.set_Texto(f + 1, c_CostoCompra, devoluciones.CostoCompra);
                            GrdDevoluciones.set_Texto(f + 1, c_TotalCompra, 0);

                            devoluciones.Kilos = 0;
                            GrdDevoluciones.ActivarCelda(f + 1, c_Kilos);
                        }
                        else
                        {
                            devoluciones.Actualizar();
                            GrdDevoluciones.ActivarCelda(f + 1, c);
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

        private void GrdDevoluciones_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(GrdDevoluciones.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                devoluciones.Cargar_Fila(i);
                devoluciones.precios.Fecha = devoluciones.Fecha;
                devoluciones.precios.Sucursal = devoluciones.Sucursal;
                devoluciones.precios.Producto = devoluciones.Producto;

                devoluciones.precios_Proveedores.Fecha = devoluciones.Fecha;
                devoluciones.precios_Proveedores.Proveedor = devoluciones.Proveedor;
                devoluciones.precios_Proveedores.Producto = devoluciones.Producto;
            }
            else
            {
                devoluciones.ID = 0;
                devoluciones.Fecha = Convert.ToDateTime(GrdDevoluciones.get_Texto(Fila, c_Fecha));
                devoluciones.Producto.ID = Convert.ToInt32(GrdDevoluciones.get_Texto(Fila, c_IdProd));
                devoluciones.Descripcion = GrdDevoluciones.get_Texto(Fila, c_Descripcion).ToString();
                devoluciones.Sucursal.ID = Convert.ToInt32(GrdDevoluciones.get_Texto(Fila, c_IdSuc));
                devoluciones.Proveedor.Id = Convert.ToInt32(GrdDevoluciones.get_Texto(Fila, c_IdProv));
                devoluciones.CostoVenta = Convert.ToSingle(GrdDevoluciones.get_Texto(Fila, c_CostoVenta));
                devoluciones.CostoCompra = Convert.ToSingle(GrdDevoluciones.get_Texto(Fila, c_CostoCompra));
                devoluciones.Kilos = Convert.ToSingle(GrdDevoluciones.get_Texto(Fila, c_Kilos));

                devoluciones.precios.Fecha = devoluciones.Fecha;
                devoluciones.precios.Sucursal = devoluciones.Sucursal;
                devoluciones.precios.Producto = devoluciones.Producto;

                devoluciones.precios_Proveedores.Fecha = devoluciones.Fecha;
                devoluciones.precios_Proveedores.Proveedor = devoluciones.Proveedor;
                devoluciones.precios_Proveedores.Producto = devoluciones.Producto;
            }

        }

        private void GrdDevoluciones_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (devoluciones.ID == 0)
                {

                    if (GrdDevoluciones.Col == c_Kilos)
                    {
                        devoluciones.Producto.Siguiente();
                        devoluciones.precios.Producto = devoluciones.Producto;
                        devoluciones.precios_Proveedores.Producto = devoluciones.Producto;

                        devoluciones.Descripcion = devoluciones.Producto.Nombre;

                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_IdProd, devoluciones.Producto.ID);
                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_Descripcion, devoluciones.Descripcion);

                        devoluciones.precios.Sucursal = devoluciones.Sucursal;
                        devoluciones.CostoVenta = devoluciones.precios.Buscar();
                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_CostoVenta, devoluciones.CostoVenta);
                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_TotalVenta, 0);

                        devoluciones.precios_Proveedores.Proveedor = devoluciones.Proveedor;
                        devoluciones.CostoCompra = devoluciones.precios_Proveedores.Buscar();
                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_CostoCompra, devoluciones.CostoCompra);
                        GrdDevoluciones.set_Texto(GrdDevoluciones.Row, c_TotalCompra, 0);
                    }
                }
            }
        }

        private void GrdDevoluciones_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(GrdDevoluciones.get_Texto(GrdDevoluciones.Row, 0)) != 0)
                    {
                        if (devoluciones.Fecha_Cerrada(devoluciones.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                devoluciones.ID = Convert.ToInt32(GrdDevoluciones.get_Texto(GrdDevoluciones.Row, 0));
                                devoluciones.Borrar();
                                GrdDevoluciones.BorrarFila(GrdDevoluciones.Row);
                                GrdDevoluciones_CambioFila(Convert.ToByte(GrdDevoluciones.Row));
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


    }
}
