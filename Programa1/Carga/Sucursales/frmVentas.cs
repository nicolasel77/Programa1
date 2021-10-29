namespace Programa1.Carga
{
    using Programa1.Carga.Sucursales;
    using Programa1.DB;
    using Programa1.DB.Varios;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmVentas : Form
    {
        private Ventas Venta;
        Listas_Carga Listas = new Listas_Carga();

        #region " Columnas "
        private const Byte c_Id = 0;
        private const Byte c_Fecha = 1;
        private const Byte c_IdCamion = 2;
        private const Byte c_IdProv = 3;
        private const Byte c_IdSuc = 5;
        private const Byte c_IdProd = 7;
        private const Byte c_Descripcion = 8;
        private const Byte c_CostoCompra = 9;
        private const Byte c_CostoVenta = 10;
        private const Byte c_Cantidad = 11;
        private const Byte c_Kilos = 12;
        private const Byte c_TotalCompra = 13;
        private const Byte c_TotalVenta = 14;
        private const Byte c_Promedio = 15;
        #endregion
        int vi = 4;
        public frmVentas()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 113, 123 };
            grdVenta.TeclasManejadas = n;

            Venta = new Ventas();
            grdVenta.MostrarDatos(Venta.Datos("Id=0"), true);

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

            Totales();
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            h.Llenar_List(lstCamiones, Venta.Camion.Datos());
            h.Llenar_List(cmbListas, Listas.Lista.Datos());

            cmbListas.Items.Insert(0, "Ninguna...");
            cmbListas.Items.Insert(1, "Editar...");
            rdProd.Checked = true;
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
                case Keys.F9:
                    cmdCambio.PerformClick();
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
            Cargar_Datos();

            this.Cursor = Cursors.Default;
        }

        private void Cargar_Datos()
        {
            string s = Armar_Cadena();
            grdVenta.MostrarDatos(Venta.Datos(s), true);
            formato_Grilla();
            Totales();
            grdVenta.ActivarCelda(grdVenta.Rows - 1, c_Fecha);
            grdVenta.Focus();
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucursal.Cadena("Id_Sucursales");
            string e = cProveedores.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            string c = h.Codigos_Seleccionados(lstCamiones);
            if (c != "") { c = $"ID_Camion IN {c}"; }

            s = h.Unir(s, e);
            s = h.Unir(s, f);
            s = h.Unir(s, p);
            s = h.Unir(s, c);

            return s;
        }

        private void formato_Grilla()
        {
            grdVenta.set_ColW(c_Id, 0);
            grdVenta.set_ColW(c_Fecha, 60);
            grdVenta.set_ColW(c_IdCamion, 30);
            grdVenta.set_ColW(c_IdProv, 35);
            grdVenta.set_ColW(c_IdProv + 1, 100);
            grdVenta.set_ColW(c_IdSuc, 35);
            grdVenta.set_ColW(c_IdSuc + 1, 100);
            grdVenta.set_ColW(c_Descripcion, 160);
            grdVenta.set_ColW(c_Cantidad, 60);
            grdVenta.set_ColW(c_CostoVenta, 60);
            grdVenta.set_ColW(c_CostoCompra, 60);
            grdVenta.set_ColW(c_Kilos, 60);
            grdVenta.set_ColW(c_TotalCompra, 80);
            grdVenta.set_ColW(c_TotalVenta, 80);
            grdVenta.set_ColW(c_Promedio, 60);

            grdVenta.set_Texto(0, c_IdProd, "Prod");
            grdVenta.AutosizeCol(c_IdProd);

            if (chCantidades.Checked == true)
            {
                grdVenta.Columnas[c_Cantidad].Visible = true;
                grdVenta.Columnas[c_Promedio].Visible = true;
            }
            else
            {
                grdVenta.Columnas[c_Cantidad].Visible = false;
                grdVenta.Columnas[c_Promedio].Visible = false;
            }

            if (chCamiones.Checked == true)
            {
                grdVenta.Columnas[c_IdCamion].Visible = true;
            }
            else
            {
                grdVenta.Columnas[c_IdCamion].Visible = false;
            }

            grdVenta.Columnas[c_CostoVenta].Format = "C2";
            grdVenta.Columnas[c_CostoCompra].Format = "C2";
            grdVenta.Columnas[c_Kilos].Format = "N2";
            grdVenta.Columnas[c_TotalCompra].Format = "C2";
            grdVenta.Columnas[c_TotalVenta].Format = "C2";
            grdVenta.Columnas[c_Promedio].Format = "N2";

            grdVenta.Columnas[c_IdProv + 1].Style.ForeColor = Color.DimGray;
            grdVenta.Columnas[c_IdSuc + 1].Style.ForeColor = Color.DimGray;
            grdVenta.Columnas[c_IdSuc].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdVenta.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdVenta.set_Texto(0, c_IdSuc, "Suc");
            grdVenta.set_Texto(0, c_IdProv, "Prov");
        }

        private void Totales()
        {
            double tVenta = grdVenta.SumarCol(c_TotalVenta, false);
            double tCompra = grdVenta.SumarCol(c_TotalCompra, false);
            double k = grdVenta.SumarCol(c_Kilos, false);
            int c = grdVenta.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Venta: {tVenta:C2}";
            lblTotalE.Text = $"Total Compra: {tCompra:C2}";
            lblDiferencia.Text = $"Diferencia: {(tVenta - tCompra):C2}";
        }

        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdVenta.Rows = 1;
            grdVenta.Rows = 2;
            Totales();
        }

        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void Csuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            string vFecha = cFecha.Cadena();
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Ventas WHERE {vFecha})";
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Ventas WHERE {vFecha})";
            cProveedores.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Ventas WHERE {vFecha})";
            Cargar_Datos();
        }

        private void GrdVenta_Editado(short f, short c, object a)
        {
            if (Venta.Fecha_Cerrada(Venta.Fecha) == false)
            {
                int id = Convert.ToInt32(grdVenta.get_Texto(f, c_Id));
                switch (c)
                {
                    case c_Fecha:
                        DateTime df = Convert.ToDateTime(a);
                        if (cFecha.Fecha_En_Rango(df))
                        {
                            if (Venta.Fecha_Cerrada(df) == false)
                            {
                                Venta.Fecha = df;
                                Venta.precios.Fecha = Venta.Fecha;
                                Venta.precios_Proveedores.Fecha = Venta.Fecha;

                                grdVenta.set_Texto(f, c, a);
                                if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                                else
                                {
                                    if (chCamiones.Checked == true) { grdVenta.ActivarCelda(f, c + 1); }
                                    else { grdVenta.ActivarCelda(f, c + 2); }
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
                            grdVenta.ErrorEnTxt();
                        }
                        break;
                    case c_IdCamion:
                        Venta.Camion.ID = Convert.ToInt32(a);

                        if (Venta.Camion.Existe() == true || Convert.ToInt32(a) == 0)
                        {
                            grdVenta.set_Texto(f, c, a);

                            if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                            else { grdVenta.ActivarCelda(f, c + 1); }
                        }
                        else
                        {
                            MessageBox.Show($"No se encontro el camión {a}.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case c_IdProv:
                        Venta.Proveedor.Id = Convert.ToInt32(a);
                        if (Venta.Proveedor.Existe() == true)
                        {
                            Venta.precios_Proveedores.Proveedor = Venta.Proveedor;

                            grdVenta.set_Texto(f, c, a);
                            grdVenta.set_Texto(f, c + 1, Venta.Proveedor.Nombre);

                            Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                            grdVenta.set_Texto(f, c_CostoCompra, Venta.CostoCompra);
                            grdVenta.set_Texto(f, c_TotalCompra, Venta.Kilos * Venta.CostoCompra);

                            if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                            else { grdVenta.ActivarCelda(f, c + 2); }
                        }
                        else
                        {
                            Mensaje("No se encontró el proveedor " + a.ToString());
                            grdVenta.ErrorEnTxt();
                        }
                        break;
                    case c_IdSuc:
                        Venta.Sucursal.ID = Convert.ToInt32(a);
                        if (Venta.Sucursal.Existe() == true)
                        {
                            Venta.precios.Sucursal = Venta.Sucursal;

                            Venta.CostoVenta = Venta.precios.Buscar();
                            grdVenta.set_Texto(f, c_CostoVenta, Venta.CostoVenta);
                            grdVenta.set_Texto(f, c_TotalVenta, Venta.Kilos * Venta.CostoVenta);

                            grdVenta.set_Texto(f, c, a);
                            grdVenta.set_Texto(f, c + 1, Venta.Sucursal.Nombre);

                            if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                            else { grdVenta.ActivarCelda(f, c + 2); }
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdVenta.ErrorEnTxt();
                        }
                        break;

                    case c_IdProd:
                        Venta.Producto.ID = Convert.ToInt32(a);
                        if (Venta.Producto.Existe() == true)
                        {
                            Venta.precios.Producto = Venta.Producto;
                            Listas.Producto = Venta.Producto;
                            Venta.precios_Proveedores.Producto = Venta.Producto;

                            Venta.Descripcion = Venta.Producto.Nombre;

                            grdVenta.set_Texto(f, c, a);
                            grdVenta.set_Texto(f, c + 1, Venta.Producto.Nombre);

                            Venta.precios.Sucursal = Venta.Sucursal;
                            Venta.CostoVenta = Venta.precios.Buscar();
                            grdVenta.set_Texto(f, c_CostoVenta, Venta.CostoVenta);
                            grdVenta.set_Texto(f, c_TotalVenta, Venta.Kilos * Venta.CostoVenta);

                            Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                            Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                            grdVenta.set_Texto(f, c_CostoCompra, Venta.CostoCompra);
                            grdVenta.set_Texto(f, c_TotalCompra, Venta.Kilos * Venta.CostoCompra);

                            if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                            else
                            {
                                if (chCantidades.Checked == true)
                                {
                                    grdVenta.ActivarCelda(f, c_Cantidad);
                                }
                                else
                                {
                                    grdVenta.ActivarCelda(f, c_Kilos);
                                }
                            }
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            grdVenta.ErrorEnTxt();
                        }
                        break;
                    case c_Descripcion:
                        Venta.Descripcion = a.ToString();
                        grdVenta.set_Texto(f, c, a);

                        if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                        else
                        { grdVenta.ActivarCelda(f, c + 1); }

                        break;

                    case c_Cantidad:
                        Venta.Cantidad = Convert.ToInt32(a);
                        grdVenta.set_Texto(f, c, a);
                        if (Venta.Kilos > 0 & Convert.ToInt32(a) > 0) { grdVenta.set_Texto(f, c_Promedio, Venta.Kilos / Venta.Cantidad); }
                        else { grdVenta.set_Texto(f, c_Promedio, 0); }

                        if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                        else { grdVenta.ActivarCelda(f, c_Kilos); }
                        Totales();
                        break;

                    case c_CostoCompra:
                        Venta.CostoCompra = Convert.ToSingle(a);
                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c_TotalCompra, Venta.CostoCompra * Venta.Kilos);

                        if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                        else { grdVenta.ActivarCelda(f, c + 1); }

                        Totales();
                        break;
                    case c_CostoVenta:
                        Venta.CostoVenta = Convert.ToSingle(a);
                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c_TotalVenta, Venta.CostoVenta * Venta.Kilos);

                        if (id != 0) { Venta.Actualizar(); grdVenta.ActivarCelda(f + 1, c); }
                        else { grdVenta.ActivarCelda(f, c + 1); }

                        Totales();
                        break;

                    case c_Kilos:
                        Venta.Kilos = Convert.ToSingle(a);
                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c_TotalVenta, Venta.CostoVenta * Venta.Kilos);
                        grdVenta.set_Texto(f, c_TotalCompra, Venta.CostoCompra * Venta.Kilos);
                        if (Venta.Cantidad > 0 & Convert.ToSingle(a) > 0) { grdVenta.set_Texto(f, c_Promedio, Venta.Kilos / Venta.Cantidad); }
                        else { grdVenta.set_Texto(f, c_Promedio, 0); }

                        if (grdVenta.Row == grdVenta.Rows - 1)
                        {
                            Venta.Agregar();
                            grdVenta.set_Texto(f, c_Id, Venta.ID);
                            grdVenta.AgregarFila();

                            Rellenar_nueva_Fila(f);
                        }
                        else
                        {
                            Venta.Actualizar();
                            grdVenta.ActivarCelda(f + 1, c);
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

        private void Rellenar_nueva_Fila(short Fila)
        {
            switch (vi)
            {
                //Fecha
                case 1:
                    Venta.Fecha = Venta.Fecha.AddDays(1);

                    Venta.precios.Fecha = Venta.Fecha;
                    Venta.precios_Proveedores.Fecha = Venta.Fecha;

                    Venta.CostoVenta = Venta.precios.Buscar();

                    Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                    break;
                //Suc
                case 2:
                    Venta.Sucursal.Siguiente();

                    Venta.precios.Sucursal = Venta.Sucursal;
                    Venta.CostoVenta = Venta.precios.Buscar();
                    break;
                //Producto
                case 4:
                    Venta.Producto.ID = Listas.Producto_Siguiente();

                    Venta.precios.Producto = Venta.Producto;
                    Venta.precios_Proveedores.Producto = Venta.Producto;

                    Venta.Descripcion = Venta.Producto.Nombre;

                    Venta.precios.Sucursal = Venta.Sucursal;
                    Venta.CostoVenta = Venta.precios.Buscar();

                    Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                    Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                    break;
            }
            grdVenta.set_Texto(Fila + 1, c_Fecha, Venta.Fecha);
            grdVenta.set_Texto(Fila + 1, c_IdCamion, Venta.Camion.ID);
            grdVenta.set_Texto(Fila + 1, c_IdProv, Venta.Proveedor.Id);
            grdVenta.set_Texto(Fila + 1, c_IdProv + 1, Venta.Proveedor.Nombre);
            grdVenta.set_Texto(Fila + 1, c_IdSuc, Venta.Sucursal.ID);
            grdVenta.set_Texto(Fila + 1, c_IdSuc + 1, Venta.Sucursal.Nombre);
            grdVenta.set_Texto(Fila + 1, c_IdProd, Venta.Producto.ID);
            grdVenta.set_Texto(Fila + 1, c_Descripcion, Venta.Descripcion);
            grdVenta.set_Texto(Fila + 1, c_CostoVenta, Venta.CostoVenta);
            grdVenta.set_Texto(Fila + 1, c_TotalVenta, 0);
            grdVenta.set_Texto(Fila + 1, c_CostoCompra, Venta.CostoCompra);
            grdVenta.set_Texto(Fila + 1, c_TotalCompra, 0);

            if (chCantidades.Checked == true)
            {
                grdVenta.ActivarCelda(Fila + 1, c_Cantidad);
            }
            else
            {
                grdVenta.ActivarCelda(Fila + 1, grdVenta.Col);
            }
        }

        private void GrdVenta_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdVenta.get_Texto(Fila, c_Id).ToString());
            Venta.ID = i;
            if (grdVenta.EsUltimaFila() == false)
            {
                Venta.Cargar_Fila(i);
                Venta.precios.Fecha = Venta.Fecha;
                Venta.precios.Sucursal = Venta.Sucursal;
                Venta.precios.Producto = Venta.Producto;

                Venta.precios_Proveedores.Fecha = Venta.Fecha;
                Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                Venta.precios_Proveedores.Producto = Venta.Producto;
            }
            else
            {
                Venta.ID = i;
                Venta.Fecha = Convert.ToDateTime(grdVenta.get_Texto(Fila, c_Fecha));
                Venta.Camion.ID = Convert.ToInt32(grdVenta.get_Texto(Fila, c_IdCamion));
                Venta.Producto.ID = Convert.ToInt32(grdVenta.get_Texto(Fila, c_IdProd));
                Venta.Descripcion = grdVenta.get_Texto(Fila, c_Descripcion).ToString();
                Venta.Sucursal.ID = Convert.ToInt32(grdVenta.get_Texto(Fila, c_IdSuc));
                Venta.Proveedor.Id = Convert.ToInt32(grdVenta.get_Texto(Fila, c_IdProv));
                Venta.Cantidad = Convert.ToInt32(grdVenta.get_Texto(Fila, c_Cantidad));
                Venta.CostoVenta = Convert.ToSingle(grdVenta.get_Texto(Fila, c_CostoVenta));
                Venta.CostoCompra = Convert.ToSingle(grdVenta.get_Texto(Fila, c_CostoCompra));
                Venta.Kilos = Convert.ToSingle(grdVenta.get_Texto(Fila, c_Kilos));

                Venta.precios.Fecha = Venta.Fecha;
                Venta.precios.Sucursal = Venta.Sucursal;
                Venta.precios.Producto = Venta.Producto;

                Venta.precios_Proveedores.Fecha = Venta.Fecha;
                Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                Venta.precios_Proveedores.Producto = Venta.Producto;
            }
        }

        private void GrdVenta_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (grdVenta.Col == c_IdCamion)
                {
                    grdVenta.ActivarCelda(grdVenta.Row, c_IdProv);
                }
                else
                {
                    if (Venta.ID == 0)
                    {

                        if (grdVenta.Col == c_Kilos || grdVenta.Col == c_Cantidad)
                        {
                            switch (vi)
                            {
                                //Fecha
                                case 1:
                                    Venta.Fecha = Venta.Fecha.AddDays(1);

                                    Venta.precios.Fecha = Venta.Fecha;
                                    Venta.precios_Proveedores.Fecha = Venta.Fecha;

                                    grdVenta.set_Texto(grdVenta.Row, c_Fecha, Venta.Fecha);

                                    Venta.CostoVenta = Venta.precios.Buscar();
                                    grdVenta.set_Texto(grdVenta.Row, c_CostoVenta, Venta.CostoVenta);
                                    grdVenta.set_Texto(grdVenta.Row, c_TotalVenta, 0);

                                    Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                                    grdVenta.set_Texto(grdVenta.Row, c_CostoCompra, Venta.CostoCompra);
                                    grdVenta.set_Texto(grdVenta.Row, c_TotalCompra, 0);
                                    break;
                                //Suc
                                case 2:
                                    Venta.Sucursal.Siguiente();

                                    grdVenta.set_Texto(grdVenta.Row, c_IdSuc, Venta.Sucursal.ID);
                                    grdVenta.set_Texto(grdVenta.Row, c_IdSuc + 1, Venta.Sucursal.Nombre);

                                    Venta.precios.Sucursal = Venta.Sucursal;
                                    Venta.CostoVenta = Venta.precios.Buscar();
                                    grdVenta.set_Texto(grdVenta.Row, c_CostoVenta, Venta.CostoVenta);
                                    grdVenta.set_Texto(grdVenta.Row, c_TotalVenta, 0);
                                    break;
                                //Nada
                                case 3:
                                    short f = (short)grdVenta.Row;
                                    short c = (short)grdVenta.Col;
                                    GrdVenta_Editado(f, c, grdVenta.get_Texto(f - 1, c));
                                    break;
                                //Proveedor
                                //case 4:
                                //Venta.Proveedor.siguiente();
                                //Venta.Proveedor.Id = Listas.Producto_Siguiente();

                                //Venta.precios.Producto = Venta.Producto;
                                //Venta.precios_Proveedores.Producto = Venta.Producto;

                                //Venta.Descripcion = Venta.Producto.Nombre;

                                //grdVenta.set_Texto(grdVenta.Row, c_IdProd, Venta.Producto.ID);
                                //grdVenta.set_Texto(grdVenta.Row, c_Descripcion, Venta.Descripcion);

                                //Venta.precios.Sucursal = Venta.Sucursal;
                                //Venta.CostoVenta = Venta.precios.Buscar();
                                //grdVenta.set_Texto(grdVenta.Row, c_CostoVenta, Venta.CostoVenta);
                                //grdVenta.set_Texto(grdVenta.Row, c_TotalVenta, 0);

                                //Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                                //Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                                //grdVenta.set_Texto(grdVenta.Row, c_CostoCompra, Venta.CostoCompra);
                                //grdVenta.set_Texto(grdVenta.Row, c_TotalCompra, 0);
                                //break;

                                //Producto
                                case 4:
                                    Venta.Producto.ID = Listas.Producto_Siguiente();

                                    Venta.precios.Producto = Venta.Producto;
                                    Venta.precios_Proveedores.Producto = Venta.Producto;

                                    Venta.Descripcion = Venta.Producto.Nombre;

                                    grdVenta.set_Texto(grdVenta.Row, c_IdProd, Venta.Producto.ID);
                                    grdVenta.set_Texto(grdVenta.Row, c_Descripcion, Venta.Descripcion);

                                    Venta.precios.Sucursal = Venta.Sucursal;
                                    Venta.CostoVenta = Venta.precios.Buscar();
                                    grdVenta.set_Texto(grdVenta.Row, c_CostoVenta, Venta.CostoVenta);
                                    grdVenta.set_Texto(grdVenta.Row, c_TotalVenta, 0);

                                    Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
                                    Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                                    grdVenta.set_Texto(grdVenta.Row, c_CostoCompra, Venta.CostoCompra);
                                    grdVenta.set_Texto(grdVenta.Row, c_TotalCompra, 0);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void GrdVenta_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdVenta.get_Texto(grdVenta.Row, 0)) != 0)
                    {
                        if (Venta.Fecha_Cerrada(Venta.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Venta.ID = Convert.ToInt32(grdVenta.get_Texto(grdVenta.Row, 0));
                                Venta.Borrar();
                                grdVenta.BorrarFila(grdVenta.Row);
                                GrdVenta_CambioFila(Convert.ToInt16(grdVenta.Row));
                                Totales();
                            }
                        }
                        else
                        {
                            Mensaje("La fecha esta cerrada.");
                        }
                    }
                    break;
                case 113:
                    if (Venta.ID > 0)
                    {
                        frmDetalle_Venta fr = new frmDetalle_Venta();
                        fr.Id_Venta = Venta.ID;
                        fr.cargar_id_Venta();
                        fr.ShowDialog();
                        grdVenta.Focus();
                        grdVenta.ActivarCelda(grdVenta.Row + 1, grdVenta.Col);
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
            if (grdVenta.Rows > 2)
            {
                frmCMVentas cm = new frmCMVentas();
                List<int> n = new List<int>();

                int d = grdVenta.Selection.r1;
                int h = grdVenta.Selection.r2;
                if (d == -1)
                {
                    d = 1;
                    h = grdVenta.Rows - 2;
                }
                for (int i = d; i <= h; i++)
                {
                    n.Add(Convert.ToInt32(grdVenta.get_Texto(i, c_Id)));
                }
                cm.Ids = n;
                cm.ShowDialog();
                Cargar_Datos();
            }
        }


        private void CmdACompras_Click(object sender, EventArgs e)
        {
            string g = "";
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            if (grdVenta.Grd.Selection.r1 != grdVenta.Grd.Selection.r2)
            {
                for (int i = grdVenta.Grd.Selection.r1; i <= grdVenta.Grd.Selection.r2; i++)
                {
                    g = h.Unir(g, grdVenta.get_Texto(i, 0).ToString(), ", ");
                }
                if (g.Length > 0)
                { g = "Id IN (" + g + ")"; }
            }

            frmCopiarVentaACompra cp = new frmCopiarVentaACompra();
            string f = Armar_Cadena();
            f = h.Unir(f, g);
            if (f != "")
            {
                cp.filtro = f;
                cp.cargado = 1;
                cp.Cargarc();
                cp.ShowDialog();

                if (cp.Aceptado == true)
                {
                    Compras compras = new Compras();
                    foreach (DataRow dr in cp.dt.Rows)
                    {
                        compras.Fecha = Convert.ToDateTime(dr["Fecha"]);
                        compras.Proveedor.Id = Convert.ToInt16(dr["Id_Proveedores"]);
                        compras.Producto.ID = Convert.ToInt16(dr["Id_Productos"]);
                        compras.Descripcion = dr["Descripcion"].ToString();
                        compras.Costo = Convert.ToSingle(dr["Costo"]);
                        compras.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        compras.Kilos = Convert.ToSingle(dr["Kilos"]);
                        compras.Agregar();
                    }
                    if (cp.BorrarOri == true)
                    {
                        Venta.Borrar(f);
                        Cargar_Datos();
                    }
                }
            }
        }

        private void CmdATraslados_Click(object sender, EventArgs e)
        {
            string g = "";
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            if (grdVenta.Grd.Selection.r1 != grdVenta.Grd.Selection.r2)
            {
                for (int i = grdVenta.Grd.Selection.r1; i <= grdVenta.Grd.Selection.r2; i++)
                {
                    g = h.Unir(g, grdVenta.get_Texto(i, 0).ToString(), ", ");
                }
                if (g.Length > 0)
                { g = "Id IN (" + g + ")"; }
            }

            frmCopiarVentaACompra cp = new frmCopiarVentaACompra();
            string f = Armar_Cadena();
            f = h.Unir(f, g);
            if (f != "")
            {
                cp.filtro = f;
                cp.cargado = 2;
                cp.cargarT();
                cp.Text = "Copiar a Traslados";
                cp.ShowDialog();

                if (cp.Aceptado == true)
                {
                    Traslados traslados = new Traslados();
                    foreach (DataRow dr in cp.dt.Rows)
                    {
                        traslados.Fecha = Convert.ToDateTime(dr["Fecha"]);
                        traslados.sucS.ID = 50;
                        traslados.sucE.ID = Convert.ToInt16(dr["Suc_Entrada"]); ;
                        traslados.Producto.ID = Convert.ToInt16(dr["Id_Productos"]);
                        traslados.Descripcion = dr["Descripcion"].ToString();
                        traslados.CostoS = Convert.ToSingle(dr["Costo_Salida"]);
                        traslados.CostoE = Convert.ToSingle(dr["Costo_Entrada"]);
                        traslados.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        traslados.Kilos = Convert.ToSingle(dr["Kilos"]);
                        traslados.Agregar();
                    }
                    if (cp.BorrarOri == true)
                    {
                        Venta.Borrar(f);
                        Cargar_Datos();
                    }
                }
            }
        }

        private void lstCamiones_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) { lstCamiones.SelectedIndex = -1; }
        }

        private void lstCamiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void cmbListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListas.Text == "Editar...")
            {
                frmListas_Carga fr = new frmListas_Carga();
                fr.ShowDialog();

                Herramientas.Herramientas h = new Herramientas.Herramientas();
                cmbListas.Items.Clear();
                h.Llenar_List(cmbListas, Listas.Lista.Datos());

                cmbListas.Items.Insert(0, "Ninguna...");
                cmbListas.Items.Insert(1, "Editar...");
            }
            else
            {
                if (cmbListas.Text == "Ninguna...")
                {
                    Listas.Lista.ID = 0;
                }
                else
                {
                    Herramientas.Herramientas h = new Herramientas.Herramientas();
                    Listas.Lista.ID = h.Codigo_Seleccionado(cmbListas.Text);
                    Listas.Producto = Venta.Producto;
                }
            }
        }


        private void grdVenta_Click()
        {
            panel5.Visible = false;
        }

        private void rdFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFecha.Checked == true)
            {
                rdSuc.Checked = false;
                rdNada.Checked = false;
                rdProd.Checked = false;
                vi = 1;
            }
        }

        private void rdSuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSuc.Checked == true)
            {
                rdFecha.Checked = false;
                rdNada.Checked = false;
                rdProd.Checked = false;
                vi = 2;
            }
        }

        private void rdNada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNada.Checked == true)
            {
                rdSuc.Checked = false;
                rdFecha.Checked = false;
                rdProd.Checked = false;
                vi = 3;
            }
        }

        private void rdProd_CheckedChanged(object sender, EventArgs e)
        {
            if (rdProd.Checked == true)
            {
                rdSuc.Checked = false;
                rdFecha.Checked = false;
                rdNada.Checked = false;
                vi = 4;
            }
        }

        private void grdVenta_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float k = 0, tc = 0, tv = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    k += Convert.ToSingle(grdVenta.get_Texto(i, c_Kilos));
                    tc += Convert.ToSingle(grdVenta.get_Texto(i, c_TotalCompra));
                    tv += Convert.ToSingle(grdVenta.get_Texto(i, c_TotalVenta));
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";
                lblKilos.Text = $"Kilos: {k:N2}";
                lblTotalE.Text = $"Total Compra: {tc:C2}";
                lblTotalS.Text = $"Total Venta: {tv:C2}";
            }
        }

        private void cmdHerramientas_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void chMenudencias_CheckedChanged(object sender, EventArgs e)
        {
            if (chCantidades.Checked == true)
            {
                grdVenta.Columnas[c_Cantidad].Visible = true;
                grdVenta.Columnas[c_Promedio].Visible = true;
            }
            else
            {
                grdVenta.Columnas[c_Cantidad].Visible = false;
                grdVenta.Columnas[c_Promedio].Visible = false;
            }
        }

        private void chCamiones_CheckedChanged(object sender, EventArgs e)
        {
            if (chCamiones.Checked == true)
            {
                grdVenta.Columnas[c_IdCamion].Visible = true;
            }
            else
            {
                grdVenta.Columnas[c_IdCamion].Visible = false;
            }
        }
    }
}
