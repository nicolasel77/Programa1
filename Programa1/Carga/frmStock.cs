namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmStock : Form
    {
        private Stock stock;
        private Precios_Sucursales precios;

        public frmStock()
        {
            InitializeComponent();

            precios = new Precios_Sucursales();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;

            stock = new Stock();
            grdStock.MostrarDatos(stock.Datos("Id=0"), true);
            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Subtract), grdStock.get_ColIndex("Id_Productos"), grdStock.get_ColIndex("Kilos"));
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Add), grdStock.get_ColIndex("Id_Sucursales"), grdStock.get_ColIndex("Kilos"));

            Totales();
        }

        private void FrmStock_KeyUp(object sender, KeyEventArgs e)
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
            grdStock.MostrarDatos(stock.Datos(s), true);
            formato_Grilla();
            Totales();
            grdStock.ActivarCelda(grdStock.Rows - 1, grdStock.get_ColIndex("Fecha"));
            grdStock.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdStock.set_ColW(grdStock.get_ColIndex("Id"), 0);
            grdStock.set_ColW(grdStock.get_ColIndex("Fecha"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Id_Sucursales"), 30);
            grdStock.set_ColW(grdStock.get_ColIndex("Nombre"), 100);
            grdStock.set_ColW(grdStock.get_ColIndex("Id_Productos"), 30);
            grdStock.set_ColW(grdStock.get_ColIndex("Descripcion"), 100);
            grdStock.set_ColW(grdStock.get_ColIndex("Costo"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Kilos"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Total"), 80);

            grdStock.Columnas[grdStock.get_ColIndex("Costo")].Format = "C2";
            grdStock.Columnas[grdStock.get_ColIndex("Kilos")].Format = "N2";
            grdStock.Columnas[grdStock.get_ColIndex("Total")].Format = "C2";

            grdStock.Columnas[grdStock.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdStock.set_Texto(0, grdStock.get_ColIndex("Id_Sucursales"), "Suc");
            grdStock.set_Texto(0, grdStock.get_ColIndex("Id_Productos"), "Prod");            
        }

        private void Totales()
        {
            double t = grdStock.SumarCol(grdStock.get_ColIndex("Total"), false);
            double k = grdStock.SumarCol(grdStock.get_ColIndex("Kilos"), false);
            int c = grdStock.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotal.Text = $"Total: {t:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdStock.Rows = 1;
            grdStock.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Stock WHERE {cFecha.Cadena()})";
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Stock WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }


        private void GrdStock_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdStock.get_Texto(f, grdStock.get_ColIndex("Id")));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    stock.Fecha = Convert.ToDateTime(a);
                    precios.Fecha = stock.Fecha;

                    if (id != 0) { stock.Actualizar(); }

                    grdStock.set_Texto(f, c, a);
                    grdStock.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //ID_Sucursales
                    stock.Sucursal.Id = Convert.ToInt32(a);
                    if (stock.Sucursal.Existe() == true)
                    {
                        precios.Sucursal = stock.Sucursal;

                        if (id != 0) { stock.Actualizar(); }

                        grdStock.set_Texto(f, c, a);
                        grdStock.set_Texto(f, c + 1, stock.Sucursal.Nombre);

                        grdStock.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la sucursal " + a.ToString());
                        grdStock.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //ID_Productos
                    stock.Producto.Id = Convert.ToInt32(a);
                    if (stock.Producto.Existe() == true)
                    {
                        precios.Producto = stock.Producto;

                        stock.Descripcion = stock.Producto.Nombre;

                        grdStock.set_Texto(f, c, a);
                        grdStock.set_Texto(f, c + 1, stock.Producto.Nombre);

                        stock.Costo = precios.Buscar();
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Costo"), stock.Costo);
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo * stock.Kilos);

                        if (id != 0) { stock.Actualizar(); }

                        grdStock.ActivarCelda(f, grdStock.get_ColIndex("Kilos"));
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdStock.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    stock.Descripcion = a.ToString();
                    grdStock.set_Texto(f, c, a);

                    if (id != 0) { stock.Actualizar(); }

                    grdStock.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo
                    stock.Costo = Convert.ToSingle(a);
                    grdStock.set_Texto(f, c, a);
                    grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo * stock.Kilos);

                    if (id != 0) { stock.Actualizar(); }

                    grdStock.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 7:
                    //Kilos
                    stock.Kilos = Convert.ToSingle(a);
                    grdStock.set_Texto(f, c, a);
                    grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo * stock.Kilos);

                    if (grdStock.Row == grdStock.Rows - 1)
                    {
                        stock.Agregar();
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Id"), stock.Id);
                        grdStock.AgregarFila();
                        //Rellenar nueva fila

                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Fecha"), stock.Fecha);
                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Id_Sucursales"), stock.Sucursal.Id);
                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Nombre"), stock.Sucursal.Nombre);

                        stock.Producto.Siguiente();
                        precios.Producto = stock.Producto;

                        stock.Descripcion = stock.Producto.Nombre;

                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Id_Productos"), stock.Producto.Id);
                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Descripcion"), stock.Descripcion);

                        stock.Costo = precios.Buscar();
                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Costo"), stock.Costo);
                        grdStock.set_Texto(f + 1, grdStock.get_ColIndex("Total"), 0);

                        stock.Kilos = 0;
                    }
                    else
                    {
                        stock.Actualizar();
                    }
                    grdStock.ActivarCelda(f + 1, c);

                    Totales();
                    break;
            }

        }

        private void GrdStock_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdStock.get_Texto(Fila, grdStock.get_ColIndex("Id")).ToString());
            stock.Cargar_Fila(i);
            precios.Fecha = stock.Fecha;
            precios.Sucursal = stock.Sucursal;
            precios.Producto = stock.Producto;
        }

        private void GrdStock_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (stock.Id == 0)
                {

                    if (grdStock.Col == grdStock.get_ColIndex("Kilos"))
                    {
                        stock.Producto.Siguiente();
                        precios.Producto = stock.Producto;

                        stock.Descripcion = stock.Producto.Nombre;

                        grdStock.set_Texto(grdStock.Row, grdStock.get_ColIndex("Id_Productos"), stock.Producto.Id);
                        grdStock.set_Texto(grdStock.Row, grdStock.get_ColIndex("Descripcion"), stock.Descripcion);

                        stock.Costo = precios.Buscar();
                        grdStock.set_Texto(grdStock.Row, grdStock.get_ColIndex("Costo"), stock.Costo);
                        grdStock.set_Texto(grdStock.Row, grdStock.get_ColIndex("Total"), 0);
                    }
                }
            }
        }

        private void GrdStock_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdStock.get_Texto(grdStock.Row, 0)) != 0)
                        {
                            stock.Id = Convert.ToInt32(grdStock.get_Texto(grdStock.Row, 0));
                            stock.Borrar();
                            grdStock.BorrarFila(grdStock.Row);
                            Totales();
                        }
                    }
                    break;
            }
        }


        private void LblCant_Click(object sender, EventArgs e)
        {
            string s = lblCant.Text.Substring(10);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void LblKilos_Click(object sender, EventArgs e)
        {
            string s = lblKilos.Text.Substring(6);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {
            string s = lblTotal.Text.Substring(6);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void CmdCambioMasivo_Click(object sender, EventArgs e)
        {
            if (grdStock.Rows > 2)
            {
                frmCMStock cm = new frmCMStock();
                List<int> n = new List<int>();

                int d = grdStock.Selection.r1;
                int h = grdStock.Selection.r2;
                if (d == -1)
                {
                    d = 1;
                    h = grdStock.Rows - 2;
                }
                for (int i = d; i <= h; i++)
                {
                    n.Add(Convert.ToInt32(grdStock.get_Texto(i, grdStock.get_ColIndex("Id"))));
                }
                cm.Ids = n;
                cm.ShowDialog();
                cmdMostrar.PerformClick();
            }
        }
    }
}
