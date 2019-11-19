namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmOfertas : Form
    {
        private Ofertas Ofertas;
        private Precios_Sucursales precios;

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_CostoOriginal;
        private Byte c_CostoOferta;
        private Byte c_Kilos;
        private Byte c_Reintegro;
        #endregion
        public frmOfertas()
        {
            InitializeComponent();

            precios = new Precios_Sucursales();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdOfertas.TeclasManejadas = n;

            Ofertas = new Ofertas();
            grdOfertas.MostrarDatos(Ofertas.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdOfertas.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdOfertas.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdOfertas.get_ColIndex("Id_Sucursales"));
            c_IdProd = Convert.ToByte(grdOfertas.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdOfertas.get_ColIndex("Descripcion"));
            c_CostoOriginal = Convert.ToByte(grdOfertas.get_ColIndex("Costo_Original"));
            c_CostoOferta = Convert.ToByte(grdOfertas.get_ColIndex("Costo_Oferta"));
            c_Kilos = Convert.ToByte(grdOfertas.get_ColIndex("Kilos"));
            c_Reintegro = Convert.ToByte(grdOfertas.get_ColIndex("Reintegro"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdOfertas.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdOfertas.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Kilos);

            Totales();
        }

        private void FrmOfertas_KeyUp(object sender, KeyEventArgs e)
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
            grdOfertas.MostrarDatos(Ofertas.Datos(s), true);
            formato_Grilla();
            Totales();
            grdOfertas.ActivarCelda(grdOfertas.Rows - 1, c_Fecha);
            grdOfertas.Focus();

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
            grdOfertas.set_ColW(c_Id, 0);
            grdOfertas.set_ColW(c_Fecha, 60);
            grdOfertas.set_ColW(c_IdSuc, 30);
            grdOfertas.set_ColW(c_IdSuc + 1, 100);
            grdOfertas.set_ColW(c_IdProd, 30);
            grdOfertas.set_ColW(c_Descripcion, 150);
            grdOfertas.set_ColW(c_CostoOriginal, 60);
            grdOfertas.set_ColW(c_CostoOferta, 60);
            grdOfertas.set_ColW(c_Kilos, 60);
            grdOfertas.set_ColW(c_Reintegro, 80);

            grdOfertas.Columnas[c_CostoOriginal].Format = "C2";
            grdOfertas.Columnas[c_CostoOferta].Format = "C2";
            grdOfertas.Columnas[c_Kilos].Format = "N2";
            grdOfertas.Columnas[c_Reintegro].Format = "C2";

            grdOfertas.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOfertas.set_Texto(0, c_IdSuc, "Suc");
            grdOfertas.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double t = grdOfertas.SumarCol(c_Reintegro, false);
            double k = grdOfertas.SumarCol(c_Kilos, false);
            int c = grdOfertas.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotal.Text = $"Reintegro: {t:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdOfertas.Rows = 1;
            grdOfertas.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Ofertas WHERE {vFecha})";
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Ofertas WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdOfertas_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdOfertas.get_Texto(f, c_Id));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    Ofertas.Fecha = Convert.ToDateTime(a);
                    precios.Fecha = Ofertas.Fecha;

                    if (id != 0) { Ofertas.Actualizar(); }

                    grdOfertas.set_Texto(f, c, a);
                    grdOfertas.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //ID_Sucursales
                    Ofertas.Sucursal.Id = Convert.ToInt32(a);
                    if (Ofertas.Sucursal.Existe() == true)
                    {
                        precios.Sucursal = Ofertas.Sucursal;

                        if (id != 0) { Ofertas.Actualizar(); }

                        grdOfertas.set_Texto(f, c, a);
                        grdOfertas.set_Texto(f, c + 1, Ofertas.Sucursal.Nombre);

                        grdOfertas.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la sucursal " + a.ToString());
                        grdOfertas.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //TODO: Costo_Oferta
                    //ID_Productos
                    Ofertas.Producto.Id = Convert.ToInt32(a);
                    if (Ofertas.Producto.Existe() == true)
                    {
                        precios.Producto = Ofertas.Producto;

                        Ofertas.Descripcion = Ofertas.Producto.Nombre;

                        grdOfertas.set_Texto(f, c, a);
                        grdOfertas.set_Texto(f, c + 1, Ofertas.Producto.Nombre);

                        Ofertas.Costo_Original = precios.Buscar();
                        grdOfertas.set_Texto(f, c_CostoOriginal, Ofertas.Costo_Original);
                        grdOfertas.set_Texto(f, c_Reintegro, Ofertas.Costo_Original * Ofertas.Kilos);

                        if (id != 0) { Ofertas.Actualizar(); }

                        grdOfertas.ActivarCelda(f, c_Kilos);
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdOfertas.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    Ofertas.Descripcion = a.ToString();
                    grdOfertas.set_Texto(f, c, a);

                    if (id != 0) { Ofertas.Actualizar(); }

                    grdOfertas.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo_Original
                    Ofertas.Costo_Original = Convert.ToSingle(a);
                    grdOfertas.set_Texto(f, c, a);
                    grdOfertas.set_Texto(f, c_Reintegro, Ofertas.Costo_Original * Ofertas.Kilos);

                    if (id != 0) { Ofertas.Actualizar(); }

                    grdOfertas.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 7:
                    //Costo_Oferta
                    Ofertas.Costo_Original = Convert.ToSingle(a);
                    grdOfertas.set_Texto(f, c, a);
                    grdOfertas.set_Texto(f, c_Reintegro, Ofertas.Costo_Original * Ofertas.Kilos);

                    if (id != 0) { Ofertas.Actualizar(); }

                    grdOfertas.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 8:
                    //Kilos
                    Ofertas.Kilos = Convert.ToSingle(a);
                    grdOfertas.set_Texto(f, c, a);
                    grdOfertas.set_Texto(f, c_Reintegro, Ofertas.Costo_Original * Ofertas.Kilos);

                    if (grdOfertas.Row == grdOfertas.Rows - 1)
                    {
                        Ofertas.Agregar();
                        grdOfertas.set_Texto(f, c_Id, Ofertas.Id);
                        grdOfertas.AgregarFila();
                        //Rellenar nueva fila

                        grdOfertas.set_Texto(f + 1, c_Fecha, Ofertas.Fecha);
                        grdOfertas.set_Texto(f + 1, c_IdSuc, Ofertas.Sucursal.Id);
                        grdOfertas.set_Texto(f + 1, c_IdSuc + 1, Ofertas.Sucursal.Nombre);

                        Ofertas.Producto.Siguiente();
                        precios.Producto = Ofertas.Producto;

                        Ofertas.Descripcion = Ofertas.Producto.Nombre;

                        grdOfertas.set_Texto(f + 1, c_IdProd, Ofertas.Producto.Id);
                        grdOfertas.set_Texto(f + 1, c_Descripcion, Ofertas.Descripcion);

                        Ofertas.Costo_Original = precios.Buscar();
                        grdOfertas.set_Texto(f + 1, c_CostoOriginal, Ofertas.Costo_Original);
                        grdOfertas.set_Texto(f + 1, c_Reintegro, 0);

                        Ofertas.Kilos = 0;
                    }
                    else
                    {
                        Ofertas.Actualizar();
                    }
                    grdOfertas.ActivarCelda(f + 1, c);

                    Totales();
                    break;
            }

        }

        private void GrdOfertas_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdOfertas.get_Texto(Fila, c_Id).ToString());
            Ofertas.Cargar_Fila(i);
            precios.Fecha = Ofertas.Fecha;
            precios.Sucursal = Ofertas.Sucursal;
            precios.Producto = Ofertas.Producto;
        }

        private void GrdOfertas_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Ofertas.Id == 0)
                {

                    if (grdOfertas.Col == c_Kilos)
                    {
                        Ofertas.Producto.Siguiente();
                        precios.Producto = Ofertas.Producto;

                        Ofertas.Descripcion = Ofertas.Producto.Nombre;

                        grdOfertas.set_Texto(grdOfertas.Row, c_IdProd, Ofertas.Producto.Id);
                        grdOfertas.set_Texto(grdOfertas.Row, c_Descripcion, Ofertas.Descripcion);

                        Ofertas.Costo_Original = precios.Buscar();
                        grdOfertas.set_Texto(grdOfertas.Row, c_CostoOriginal, Ofertas.Costo_Original);
                        grdOfertas.set_Texto(grdOfertas.Row, c_Reintegro, 0);
                    }
                }
            }
        }

        private void GrdOfertas_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdOfertas.get_Texto(grdOfertas.Row, 0)) != 0)
                        {
                            Ofertas.Id = Convert.ToInt32(grdOfertas.get_Texto(grdOfertas.Row, 0));
                            Ofertas.Borrar();
                            grdOfertas.BorrarFila(grdOfertas.Row);
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
            if (grdOfertas.Rows > 2)
            {
                //frmCMOfertas cm = new frmCMOfertas();
                //List<int> n = new List<int>();

                //int d = grdOfertas.Selection.r1;
                //int h = grdOfertas.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdOfertas.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdOfertas.get_Texto(i, c_Id)));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }

        private void CmdPrecios_Click(object sender, EventArgs e)
        {
            frmPreciosOfertas frmPrecios = new frmPreciosOfertas();

            frmPrecios.ShowDialog();

        }
    }
}
