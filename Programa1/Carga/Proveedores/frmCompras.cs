﻿namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmCompras : Form
    {
        private Compras Compras;

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

        public frmCompras()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdCompras.TeclasManejadas = n;

            Compras = new Compras();
            grdCompras.MostrarDatos(Compras.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdCompras.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdCompras.get_ColIndex("Fecha"));
            c_IdProv = Convert.ToByte(grdCompras.get_ColIndex("Id_Proveedores"));
            c_IdProd = Convert.ToByte(grdCompras.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdCompras.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grdCompras.get_ColIndex("Costo"));
            c_Kilos = Convert.ToByte(grdCompras.get_ColIndex("Kilos"));
            c_Total = Convert.ToByte(grdCompras.get_ColIndex("Total"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdCompras.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdCompras.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

            Totales();
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

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdCompras.set_ColW(c_Id, 0);
            grdCompras.set_ColW(c_Fecha, 60);
            grdCompras.set_ColW(c_IdProv, 30);
            grdCompras.set_ColW(c_IdProv + 1, 100);
            grdCompras.set_ColW(c_IdProd, 30);
            grdCompras.set_ColW(c_Descripcion, 150);
            grdCompras.set_ColW(c_Costo, 60);
            grdCompras.set_ColW(c_Kilos, 60);
            grdCompras.set_ColW(c_Total, 80);

            grdCompras.Columnas[c_Costo].Format = "C2";
            grdCompras.Columnas[c_Kilos].Format = "N2";
            grdCompras.Columnas[c_Total].Format = "C2";

            grdCompras.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdCompras.set_Texto(0, c_IdProv, "Suc");
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
            int id = Convert.ToInt32(grdCompras.get_Texto(f, c_Id));
            switch (c)
            {
                case 1:
                    //Fecha
                    DateTime df = Convert.ToDateTime(a);
                    if (df >= cFecha.fecha_Actual)
                    {
                        Compras.Fecha = df;
                        Compras.precios.Fecha = Compras.Fecha;

                        if (id != 0) { Compras.Actualizar(); }

                        grdCompras.set_Texto(f, c, a);
                        grdCompras.ActivarCelda(f, c + 1);
                    }
                    else
                    {
                        Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                        grdCompras.ErrorEnTxt();
                    }
                    break;
                case 2:
                    //ID_Proveedores
                    Compras.Proveedor.Id = Convert.ToInt32(a);
                    if (Compras.Proveedor.Existe() == true)
                    {
                        Compras.precios.Proveedor = Compras.Proveedor;

                        if (id != 0) { Compras.Actualizar(); }

                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c + 1, Compras.Proveedor.Nombre);

                        grdCompras.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la Proveedor " + a.ToString());
                        grdCompras.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //ID_Productos
                    Compras.Producto.Id = Convert.ToInt32(a);
                    if (Compras.Producto.Existe() == true)
                    {
                        Compras.precios.Producto = Compras.Producto;

                        Compras.Descripcion = Compras.Producto.Nombre;

                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c + 1, Compras.Producto.Nombre);

                        Compras.Costo = Compras.precios.Buscar();
                        grdCompras.set_Texto(f, c_Costo, Compras.Costo);
                        grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);

                        if (id != 0) { Compras.Actualizar(); }

                        grdCompras.ActivarCelda(f, c_Kilos);
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdCompras.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    Compras.Descripcion = a.ToString();
                    grdCompras.set_Texto(f, c, a);

                    if (id != 0) { Compras.Actualizar(); }

                    grdCompras.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo
                    Compras.Costo = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);
                    grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);

                    if (id != 0) { Compras.Actualizar(); }

                    grdCompras.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 7:
                    //Kilos
                    Compras.Kilos = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);
                    grdCompras.set_Texto(f, c_Total, Compras.Costo * Compras.Kilos);

                    if (grdCompras.Row == grdCompras.Rows - 1)
                    {
                        Compras.Agregar();
                        grdCompras.set_Texto(f, c_Id, Compras.Id);
                        grdCompras.AgregarFila();
                        //Rellenar nueva fila

                        grdCompras.set_Texto(f + 1, c_Fecha, Compras.Fecha);
                        grdCompras.set_Texto(f + 1, c_IdProv, Compras.Proveedor.Id);
                        grdCompras.set_Texto(f + 1, grdCompras.get_ColIndex("Nombre"), Compras.Proveedor.Nombre);

                        Compras.Producto.Siguiente();
                        Compras.precios.Producto = Compras.Producto;

                        Compras.Descripcion = Compras.Producto.Nombre;

                        grdCompras.set_Texto(f + 1, c_IdProd, Compras.Producto.Id);
                        grdCompras.set_Texto(f + 1, c_Descripcion, Compras.Descripcion);

                        Compras.Costo = Compras.precios.Buscar();
                        grdCompras.set_Texto(f + 1, c_Costo, Compras.Costo);
                        grdCompras.set_Texto(f + 1, c_Total, 0);

                        Compras.Kilos = 0;
                    }
                    else
                    {
                        Compras.Actualizar();
                    }
                    grdCompras.ActivarCelda(f + 1, c);

                    Totales();
                    break;
            }

        }

        private void GrdCompras_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdCompras.get_Texto(Fila, c_Id).ToString());
            Compras.Cargar_Fila(i);
            Compras.precios.Fecha = Compras.Fecha;
            Compras.precios.Proveedor = Compras.Proveedor;
            Compras.precios.Producto = Compras.Producto;
        }

        private void GrdCompras_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Compras.Id == 0)
                {

                    if (grdCompras.Col == c_Kilos)
                    {
                        Compras.Producto.Siguiente();
                        Compras.precios.Producto = Compras.Producto;

                        Compras.Descripcion = Compras.Producto.Nombre;

                        grdCompras.set_Texto(grdCompras.Row, c_IdProd, Compras.Producto.Id);
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
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdCompras.get_Texto(grdCompras.Row, 0)) != 0)
                        {
                            Compras.Id = Convert.ToInt32(grdCompras.get_Texto(grdCompras.Row, 0));
                            Compras.Borrar();
                            grdCompras.BorrarFila(grdCompras.Row);
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
    }
}