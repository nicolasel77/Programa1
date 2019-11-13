namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmVenta : Form
    {
        private Ventas Venta;
        private Precios_Sucursales precios;

        public frmVenta()
        {
            InitializeComponent();

            precios = new Precios_Sucursales();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdVenta.TeclasManejadas = n;

            Venta = new Ventas();
            grdVenta.MostrarDatos(Venta.Datos("Id=0"), true);
            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Subtract), grdVenta.get_ColIndex("Id_Productos"), grdVenta.get_ColIndex("Kilos"));
            grdVenta.AgregarTeclas(Convert.ToInt32(Keys.Add), grdVenta.get_ColIndex("Id_Sucursales"), grdVenta.get_ColIndex("Kilos"));

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
                        cProveedores.Siguiente();
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
                        cProveedores.Anterior();
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
            grdVenta.ActivarCelda(grdVenta.Rows - 1, grdVenta.get_ColIndex("Fecha"));
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

            s = h.Unir(s, e);
            s = h.Unir(s, f);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdVenta.set_ColW(grdVenta.get_ColIndex("Id"), 0);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Fecha"), 60);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Id_Sucursales"), 35);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Nombre"), 100);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Id_Proveedores"), 35);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Nombre_Proveedor"), 100);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Id_Productos"), 30);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Descripcion"), 100);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Costo_Venta"), 60);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Costo_Compra"), 60);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Kilos"), 60);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Total_Venta"), 80);
            grdVenta.set_ColW(grdVenta.get_ColIndex("Total_Compra"), 80);

            grdVenta.Columnas[grdVenta.get_ColIndex("Costo_Venta")].Format = "C2";
            grdVenta.Columnas[grdVenta.get_ColIndex("Costo_Compra")].Format = "C2";
            grdVenta.Columnas[grdVenta.get_ColIndex("Kilos")].Format = "N2";
            grdVenta.Columnas[grdVenta.get_ColIndex("Total_Venta")].Format = "C2";
            grdVenta.Columnas[grdVenta.get_ColIndex("Total_Compra")].Format = "C2";

            grdVenta.Columnas[grdVenta.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdVenta.set_Texto(0, grdVenta.get_ColIndex("Id_Sucursales"), "Suc");
            grdVenta.set_Texto(0, grdVenta.get_ColIndex("Id_Proveedores"), "Prov");
            grdVenta.set_Texto(0, grdVenta.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double tSalida = grdVenta.SumarCol(grdVenta.get_ColIndex("Total_Venta"), false);
            double tEntrada = grdVenta.SumarCol(grdVenta.get_ColIndex("Total_Compra"), false);
            double k = grdVenta.SumarCol(grdVenta.get_ColIndex("Kilos"), false);
            int c = grdVenta.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Venta: {tSalida:C2}";
            lblTotalE.Text = $"Total Compra: {tEntrada:C2}";
            lblDiferencia.Text = $"Diferencia: {(tEntrada - tSalida):C2}";

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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Ventas WHERE {cFecha.Cadena()})";
            cSucursal.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Ventas WHERE {cFecha.Cadena()})";
            cProveedores.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Ventas WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }


        private void GrdVenta_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdVenta.get_Texto(f, grdVenta.get_ColIndex("Id")));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    Venta.Fecha = Convert.ToDateTime(a);
                    precios.Fecha = Venta.Fecha;

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.set_Texto(f, c, a);
                    grdVenta.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //Id_Proveedores
                    Venta.Prov.Id = Convert.ToInt32(a);
                    if (Venta.Prov.Existe() == true)
                    {
                        //precios.pr = Venta.Prov;

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, Venta.Prov.Nombre);

                        grdVenta.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la sucursal " + a.ToString());
                        grdVenta.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //Id_Sucursales
                    Venta.suc.Id = Convert.ToInt32(a);
                    if (Venta.suc.Existe() == true)
                    {
                        precios.suc = Venta.suc;

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, Venta.suc.Nombre);

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
                    Venta.producto.Id = Convert.ToInt32(a);
                    if (Venta.producto.Existe() == true)
                    {
                        precios.producto = Venta.producto;

                        Venta.Descripcion = Venta.producto.Nombre;

                        grdVenta.set_Texto(f, c, a);
                        grdVenta.set_Texto(f, c + 1, Venta.producto.Nombre);

                        precios.suc = Venta.suc;
                        Venta.CostoVenta = precios.Buscar();
                        grdVenta.set_Texto(f, grdVenta.get_ColIndex("Costo_Venta"), Venta.CostoVenta);
                        grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Venta"), Venta.Kilos * Venta.CostoVenta);

                        //precios.suc = Venta.Prov;
                        //Venta.CostoE = precios.Buscar();
                        //grdVenta.set_Texto(f, grdVenta.get_ColIndex("Costo_Compra"), Venta.CostoE);
                        //grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Compra"), Venta.Kilos * Venta.CostoE);

                        if (id != 0) { Venta.Actualizar(); }

                        grdVenta.ActivarCelda(f, grdVenta.get_ColIndex("Kilos"));
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
                    Venta.Descripcion = a.ToString();
                    grdVenta.set_Texto(f, c, a);

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    break;
                case 8:
                    //Costo_Venta
                    Venta.CostoVenta = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Venta"), Venta.CostoVenta * Venta.Kilos);

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 9:
                    //Costo_Compra
                    Venta.CostoCompra = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Compra"), Venta.CostoCompra * Venta.Kilos);

                    if (id != 0) { Venta.Actualizar(); }

                    grdVenta.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 10:
                    //Kilos
                    Venta.Kilos = Convert.ToSingle(a);
                    grdVenta.set_Texto(f, c, a);
                    grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Venta"), Venta.CostoVenta * Venta.Kilos);
                    grdVenta.set_Texto(f, grdVenta.get_ColIndex("Total_Compra"), Venta.CostoCompra * Venta.Kilos);

                    if (grdVenta.Row == grdVenta.Rows - 1)
                    {
                        Venta.Agregar();
                        grdVenta.set_Texto(f, grdVenta.get_ColIndex("Id"), Venta.Id);
                        grdVenta.AgregarFila();
                        //Rellenar nueva fila

                        grdVenta.set_Texto(f + 1, grdVenta.get_ColIndex("Fecha"), Venta.Fecha);

                        Venta.Kilos = 0;
                        grdVenta.ActivarCelda(f + 1, grdVenta.get_ColIndex("Id_Proveedores"));
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
            int i = Convert.ToInt32(grdVenta.get_Texto(Fila, grdVenta.get_ColIndex("Id")).ToString());
            Venta.Cargar_Fila(i);
            precios.Fecha = Venta.Fecha;
            precios.suc = Venta.suc;
            precios.producto = Venta.producto;
        }

        private void GrdVenta_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Venta.Id == 0)
                {

                    if (grdVenta.Col == grdVenta.get_ColIndex("Kilos"))
                    {
                        Venta.producto.Siguiente();
                        precios.producto = Venta.producto;

                        Venta.Descripcion = Venta.producto.Nombre;

                        grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Id_Productos"), Venta.producto.Id);
                        grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Descripcion"), Venta.Descripcion);

                        precios.suc = Venta.suc;
                        Venta.CostoVenta = precios.Buscar();
                        grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Costo_Venta"), Venta.CostoVenta);
                        grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Total_Venta"), 0);

                        //precios.suc = Venta.Prov;
                        //Venta.CostoE = precios.Buscar();
                        //grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Costo_Compra"), Venta.CostoE);
                        //grdVenta.set_Texto(grdVenta.Row, grdVenta.get_ColIndex("Total_Compra"), 0);
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
            string s = lblCant.Text.Substring(lblCant.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }
        private void LblKilos_Click(object sender, EventArgs e)
        {
            string s = lblKilos.Text.Substring(lblKilos.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }
        private void LblTotalS_Click(object sender, EventArgs e)
        {
            string s = lblTotalS.Text.Substring(lblTotalS.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }
        private void LblTotalE_Click(object sender, EventArgs e)
        {
            string s = lblTotalE.Text.Substring(lblTotalE.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }
        private void LblDiferencia_Click(object sender, EventArgs e)
        {
            string s = lblDiferencia.Text.Substring(lblDiferencia.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void CmdCambioMasivo_Click(object sender, EventArgs e)
        {
            if (grdVenta.Rows > 2)
            {
                //frmCMVenta cm = new frmCMVenta();
                //List<int> n = new List<int>();

                //int d = grdVenta.Selection.r1;
                //int h = grdVenta.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdVenta.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdVenta.get_Texto(i, grdVenta.get_ColIndex("Id"))));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }


    }
}
