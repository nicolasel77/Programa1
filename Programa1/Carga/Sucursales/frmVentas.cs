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
        private const Byte c_Kilos = 11;
        private const Byte c_TotalCompra = 12;
        private const Byte c_TotalVenta = 13;
        #endregion

        public frmVentas()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdVenta.TeclasManejadas = n;

            Venta = new Ventas();
            grdVenta.MostrarDatos(Venta.Datos("Id=0"), true);

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Kilos);
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdProv, c_Kilos);

            Totales();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            
            h.Llenar_List(lstCamiones, Venta.Camion.Datos());                        
            h.Llenar_List(cmbListas, Listas.Lista.Datos());

            cmbListas.Items.Insert(0, "Ninguna...");
            cmbListas.Items.Insert(1, "Editar...");
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
            grdVenta.MostrarDatos(Venta.Datos(s), true);
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
            grdVenta.set_ColW(c_IdProv + 1, 40);
            grdVenta.set_ColW(c_IdSuc, 35);
            grdVenta.set_ColW(c_IdSuc + 1, 40);
            grdVenta.set_ColW(c_IdProd, 30);
            grdVenta.set_ColW(c_Descripcion, 120);
            grdVenta.set_ColW(c_CostoVenta, 60);
            grdVenta.set_ColW(c_CostoCompra, 60);
            grdVenta.set_ColW(c_Kilos, 60);
            grdVenta.set_ColW(c_TotalCompra, 80);
            grdVenta.set_ColW(c_TotalVenta, 80);

            grdVenta.Columnas[c_CostoVenta].Format = "C2";
            grdVenta.Columnas[c_CostoCompra].Format = "C2";
            grdVenta.Columnas[c_Kilos].Format = "N2";
            grdVenta.Columnas[c_TotalCompra].Format = "C2";
            grdVenta.Columnas[c_TotalVenta].Format = "C2";

            grdVenta.Columnas[c_IdProv + 1].Style.ForeColor = Color.DimGray;
            grdVenta.Columnas[c_IdSuc + 1].Style.ForeColor = Color.DimGray;
            grdVenta.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdVenta.set_Texto(0, c_IdSuc, "Suc");
            grdVenta.set_Texto(0, c_IdProv, "Prov");
            grdVenta.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double tSalida = grdVenta.SumarCol(c_TotalVenta, false);
            double tEntrada = grdVenta.SumarCol(c_TotalCompra, false);
            double k = grdVenta.SumarCol(c_Kilos, false);
            int c = grdVenta.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Venta: {tSalida:C2}";
            lblTotalE.Text = $"Total Compra: {tEntrada:C2}";
            lblDiferencia.Text = $"Diferencia: {(tSalida - tEntrada):C2}";

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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Ventas WHERE {vFecha})";
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Ventas WHERE {vFecha})";
            cProveedores.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Ventas WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdVenta_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdVenta.get_Texto(f, c_Id));
            switch (c)
            {
                case c_Fecha:
                    DateTime df = Convert.ToDateTime(a);
                    if (df >= cFecha.fecha_Actual)
                    {
                        Venta.Fecha = df;
                        Venta.precios.Fecha = Venta.Fecha;
                        Venta.precios_Proveedores.Fecha = Venta.Fecha;

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.ActivarCelda(f, c + 1);
                    }
                    else
                    {
                        Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case c_IdCamion:
                    Venta.Camion.ID = Convert.ToInt32(a);

                    if (Venta.Camion.Existe() == true)
                    {
                        grdVenta.set_Texto(f, c, a);

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.ActivarCelda(f, c + 1);
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

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, Venta.Proveedor.Nombre);

                        grdVenta.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró el proveedor " + a.ToString());
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case c_IdSuc:
                    Venta.Sucursal.Id = Convert.ToInt32(a);
                    if (Venta.Sucursal.Existe() == true)
                    {
                        Venta.precios.Sucursal = Venta.Sucursal;

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, Venta.Sucursal.Nombre);

                        grdVenta.ActivarCelda(f, c + 2);
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

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.ActivarCelda(f, c_Kilos);
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

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    break;
                case c_CostoCompra:
                    Venta.CostoCompra = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, c_TotalCompra, Venta.CostoCompra * Venta.Kilos);

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case c_CostoVenta:
                    Venta.CostoVenta = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, c_TotalVenta, Venta.CostoVenta * Venta.Kilos);

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    Totales();
                    break;

                case c_Kilos:
                    Venta.Kilos = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, c_TotalVenta, Venta.CostoVenta * Venta.Kilos);
                    grdVenta.set_Texto(f, c_TotalCompra, Venta.CostoCompra * Venta.Kilos);

                    if (grdVenta.Row == grdVenta.Rows - 1)
                    {
                        Venta.Agregar();
                        grdVenta.set_Texto(f, c_Id, Venta.Id);
                        grdVenta.AgregarFila();

                        //Rellenar nueva fila

                        grdVenta.set_Texto(f + 1, c_Fecha, Venta.Fecha);
                        grdVenta.set_Texto(f + 1, c_IdProv, Venta.Proveedor.Id);
                        grdVenta.set_Texto(f + 1, c_IdProv + 1, Venta.Sucursal.Nombre);
                        grdVenta.set_Texto(f + 1, c_IdSuc, Venta.Sucursal.Id);
                        grdVenta.set_Texto(f + 1, c_IdSuc + 1, Venta.Sucursal.Nombre);

                        Venta.Producto.ID = Listas.Producto_Siguiente();

                        Venta.precios.Producto = Venta.Producto;
                        Venta.precios_Proveedores.Producto = Venta.Producto;

                        Venta.Descripcion = Venta.Producto.Nombre;

                        grdVenta.set_Texto(f + 1, c_IdProd, Venta.Producto.ID);
                        grdVenta.set_Texto(f + 1, c_Descripcion, Venta.Descripcion);


                        Venta.CostoVenta = Venta.precios.Buscar();
                        grdVenta.set_Texto(f + 1, c_CostoVenta, Venta.CostoVenta);
                        grdVenta.set_Texto(f + 1, c_TotalVenta, 0);

                        Venta.CostoCompra = Venta.precios_Proveedores.Buscar();
                        grdVenta.set_Texto(f + 1, c_CostoCompra, Venta.CostoCompra);
                        grdVenta.set_Texto(f + 1, c_TotalCompra, 0);

                        Venta.Kilos = 0;
                        grdVenta.ActivarCelda(f + 1, c_Kilos);
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

        private void GrdVenta_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdVenta.get_Texto(Fila, c_Id).ToString());
            Venta.Cargar_Fila(i);
            Venta.precios.Fecha = Venta.Fecha;
            Venta.precios.Sucursal = Venta.Sucursal;
            Venta.precios.Producto = Venta.Producto;

            Venta.precios_Proveedores.Fecha = Venta.Fecha;
            Venta.precios_Proveedores.Proveedor = Venta.Proveedor;
            Venta.precios_Proveedores.Producto = Venta.Producto;

        }

        private void GrdVenta_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Venta.Id == 0)
                {

                    if (grdVenta.Col == c_Kilos)
                    {
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
                            Venta.Id = Convert.ToInt32(grdVenta.get_Texto(grdVenta.Row, 0));
                            Venta.Borrar();
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
                cmdMostrar.PerformClick();
            }
        }


        private void CmdACompras_Click(object sender, EventArgs e)
        {
            frmCopiarVentaACompra cp = new frmCopiarVentaACompra();
            string f = Armar_Cadena();

            if (f != "")
            {
                DataTable dt = Venta.Resumen_Compra(f);

                cp.Cargar(dt);
                cp.grd.Columnas[cp.grd.get_ColIndex("Costo")].Format = "C2";
                cp.grd.Columnas[cp.grd.get_ColIndex("Kilos")].Format = "N2";
                cp.grd.Columnas[cp.grd.get_ColIndex("Total")].Format = "C2";
                cp.ShowDialog();

                if (cp.Aceptado == true)
                {
                    Compras compras = new Compras();
                    foreach (DataRow dr in dt.Rows)
                    {
                        compras.Fecha = Convert.ToDateTime(dr["Fecha"]);
                        compras.Proveedor.Id = Convert.ToInt16(dr["Id_Proveedores"]);
                        compras.Producto.ID = Convert.ToInt16(dr["Id_Productos"]);
                        compras.Descripcion = dr["Descripcion"].ToString();
                        compras.Costo = Convert.ToSingle(dr["Costo"]);
                        compras.Kilos = Convert.ToSingle(dr["Kilos"]);
                        compras.Agregar();
                    }
                }
            }
        }

        private void CmdATraslados_Click(object sender, EventArgs e)
        {
            frmCopiarVentaACompra cp = new frmCopiarVentaACompra();
            string f = Armar_Cadena();

            DataTable dt = Venta.Resumen_ATraslados(f);

            cp.Text = "Copiar a Traslados";

            cp.Cargar(dt);
            cp.grd.Columnas[cp.grd.get_ColIndex("Costo_Entrada")].Format = "C2";
            cp.grd.Columnas[cp.grd.get_ColIndex("Costo_Salida")].Format = "C2";
            cp.grd.Columnas[cp.grd.get_ColIndex("Kilos")].Format = "N2";
            cp.grd.Columnas[cp.grd.get_ColIndex("Total_Entrada")].Format = "C2";
            cp.grd.Columnas[cp.grd.get_ColIndex("Total_Salida")].Format = "C2";

            cp.ShowDialog();

            if (cp.Aceptado == true)
            {
                Traslados traslados = new Traslados();
                foreach (DataRow dr in dt.Rows)
                {
                    traslados.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    traslados.sucS.Id = 50;
                    traslados.sucE.Id = Convert.ToInt16(dr["Suc_Entrada"]); ;
                    traslados.Producto.ID = Convert.ToInt16(dr["Id_Productos"]);
                    traslados.Descripcion = dr["Descripcion"].ToString();
                    traslados.CostoS = Convert.ToSingle(dr["Costo_Salida"]);
                    traslados.CostoE = Convert.ToSingle(dr["Costo_Entrada"]);
                    traslados.Kilos = Convert.ToSingle(dr["Kilos"]);
                    traslados.Agregar();
                }
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

        private void cmbListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListas.Text == "Editar...")
            {
                frmListas_Carga fr = new frmListas_Carga();
                fr.ShowDialog();
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
                    Listas.Producto= Venta.Producto;
                }
            }
        }
    }
}
