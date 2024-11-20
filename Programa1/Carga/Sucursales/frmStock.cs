namespace Programa1.Carga
{
    using Programa1.DB;
    using Programa1.DB.Varios;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmStock : Form
    {
        private readonly Stock stock;
        public Usuarios n_usuario;

        #region " Columnas "
        private readonly Byte c_Id;
        private readonly Byte c_Fecha;
        private readonly Byte c_IdSuc;
        private readonly Byte c_IdProd;
        private readonly Byte c_Descripcion;
        private readonly Byte c_Costo;
        private readonly Byte c_Kilos;
        private readonly Byte c_Total;
        #endregion
        public frmStock(Usuarios usuario)
        {
            InitializeComponent();

            n_usuario = usuario;

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;

            stock = new Stock();
            grdStock.MostrarDatos(stock.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdStock.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdStock.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdStock.get_ColIndex("Id_Sucursales"));
            c_IdProd = Convert.ToByte(grdStock.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdStock.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grdStock.get_ColIndex("Costo"));
            c_Kilos = Convert.ToByte(grdStock.get_ColIndex("Kilos"));
            c_Total = Convert.ToByte(grdStock.get_ColIndex("Total"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Kilos);

            Totales();
        }

        int vi = 4;

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
            if (s.Length == 0) { s = "Id=-1"; }
            grdStock.MostrarDatos(stock.Datos(s), true);
            formato_Grilla();
            Totales();
            grdStock.ActivarCelda(grdStock.Rows - 1, c_Fecha);
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
            grdStock.set_ColW(c_Id, 0);
            grdStock.set_ColW(c_Fecha, 60);
            grdStock.set_ColW(c_IdSuc, 30);
            grdStock.set_ColW(c_IdSuc + 1, 200);
            grdStock.set_ColW(c_IdProd, 30);
            grdStock.set_ColW(c_Descripcion, 250);
            grdStock.set_ColW(c_Kilos, 60);
            grdStock.set_ColW(c_Total + 1, 0);
            grdStock.set_ColW(c_Total + 2, 0);
            
                        
            if (n_usuario.Permiso == Usuarios.e_Permiso.Supervisor)
            {
                grdStock.set_ColW(c_Costo, 0);
                grdStock.set_ColW(c_Total, 0);
                lblTotal.Visible = false;
                cmdCambio.Enabled = false;
            }
            else
            {
                grdStock.set_ColW(c_Costo, 60);
                grdStock.set_ColW(c_Total, 80);
            }

            grdStock.Columnas[c_Costo].Format = "C2";
            grdStock.Columnas[c_Kilos].Format = "N2";
            grdStock.Columnas[c_Total].Format = "C2";

            grdStock.Columnas[c_IdSuc + 1].Style.ForeColor = Color.DimGray;
            grdStock.Columnas[c_IdSuc].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdStock.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdStock.set_Texto(0, c_IdSuc, "Suc");
            grdStock.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double t = grdStock.SumarCol(c_Total, false);
            double k = grdStock.SumarCol(c_Kilos, false);
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
            string vFecha = cFecha.Cadena();
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Stock WHERE {vFecha})";
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Stock WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdStock_Editado(short f, short c, object a)
        {
            if (stock.Fecha_Cerrada(stock.Fecha) == false)
            {
                int id = Convert.ToInt32(grdStock.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (cFecha.Fecha_En_Rango(df))
                        {
                            if (stock.Fecha_Cerrada(df) == false)
                            {
                                stock.Fecha = df;
                                stock.precios.Fecha = stock.Fecha;

                                if (id != 0) { stock.Actualizar(); }

                                grdStock.set_Texto(f, c, a);
                                grdStock.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe estar dentro del rango fecha seleccionado.");
                            grdStock.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //ID_Sucursales
                        stock.Sucursal.ID = Convert.ToInt32(a);
                        if (stock.Sucursal.Existe() == true)
                        {
                            stock.precios.Sucursal = stock.Sucursal;

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
                        stock.Producto.ID = Convert.ToInt32(a);
                        if (stock.Producto.Existe() == true)
                        {
                            stock.precios.Producto = stock.Producto;

                            stock.Descripcion = stock.Producto.Nombre;

                            grdStock.set_Texto(f, c, a);
                            grdStock.set_Texto(f, c + 1, stock.Producto.Nombre);

                            stock.Costo = stock.precios.Buscar();
                            grdStock.set_Texto(f, c_Costo, stock.Costo);
                            grdStock.set_Texto(f, c_Total, stock.Costo * stock.Kilos);

                            if (id != 0) { stock.Actualizar(); }

                            grdStock.ActivarCelda(f, c_Kilos);
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
                        grdStock.set_Texto(f, c_Total, stock.Costo * stock.Kilos);

                        if (id != 0) { stock.Actualizar(); }

                        grdStock.ActivarCelda(f + 1, c);
                        Totales();
                        break;
                    case 7:
                        //Kilos
                        stock.Kilos = Convert.ToSingle(a);
                        grdStock.set_Texto(f, c, a);
                        grdStock.set_Texto(f, c_Total, stock.Costo * stock.Kilos);

                        if (grdStock.Row == grdStock.Rows - 1)
                        {
                            stock.Agregar();
                            grdStock.set_Texto(f, c_Id, stock.ID);
                            grdStock.AgregarFila();
                            //Rellenar nueva fila
                            Rellenar_nueva_Fila(f);
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
            else
            {
                Mensaje("La fecha esta cerrada.");
            }
        }

        private void GrdStock_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdStock.get_Texto(Fila, c_Id).ToString());
            stock.ID = i;
            if (grdStock.EsUltimaFila() == false)
            {
                stock.Cargar_Fila(i);
                stock.precios.Fecha = stock.Fecha;
                stock.precios.Sucursal = stock.Sucursal;
                stock.precios.Producto = stock.Producto;
            }
            else
            {
                stock.ID = 0;
                stock.Fecha = Convert.ToDateTime(grdStock.get_Texto(Fila, c_Fecha));
                stock.Producto.ID = Convert.ToInt32(grdStock.get_Texto(Fila, c_IdProd));
                stock.Descripcion = grdStock.get_Texto(Fila, c_Descripcion).ToString();
                stock.Sucursal.ID = Convert.ToInt32(grdStock.get_Texto(Fila, c_IdSuc));
                stock.Costo = Convert.ToSingle(grdStock.get_Texto(Fila, c_Costo));
                stock.Kilos = Convert.ToSingle(grdStock.get_Texto(Fila, c_Kilos));

                stock.precios.Fecha = stock.Fecha;
                stock.precios.Sucursal = stock.Sucursal;
                stock.precios.Producto = stock.Producto;
            }

        }
        private void Rellenar_nueva_Fila(short Fila)
        {
            switch (vi)
            {
                //Fecha
                case 1:
                    stock.Fecha = stock.Fecha.AddDays(1);
                    stock.precios.Fecha = stock.Fecha;
                    stock.Costo = stock.precios.Buscar();
                    break;
                //Suc
                case 2:
                    stock.Sucursal.Siguiente();
                    stock.precios.Sucursal = stock.Sucursal;
                    stock.Costo = stock.precios.Buscar();
                    break;
                //Producto
                case 4:
                    stock.Producto.Siguiente(" ver = 1");
                    stock.precios.Producto = stock.Producto;
                    stock.Descripcion = stock.Producto.Nombre;
                    stock.Costo = stock.precios.Buscar();
                    break;
            }
            grdStock.set_Texto(Fila + 1, c_Fecha, stock.Fecha);
            grdStock.set_Texto(Fila + 1, c_IdSuc, stock.Sucursal.ID);
            grdStock.set_Texto(Fila + 1, c_IdSuc + 1, stock.Sucursal.Nombre);
            grdStock.set_Texto(Fila + 1, c_IdProd, stock.Producto.ID);
            grdStock.set_Texto(Fila + 1, c_Descripcion, stock.Descripcion);
            grdStock.set_Texto(Fila + 1, c_Costo, stock.Costo);
            grdStock.set_Texto(Fila + 1, c_Total, 0);
        }

        private void GrdStock_KeyPress(object sender, short e)
        {
            if (e == 13)
            {

                if (stock.ID == 0)
                {

                    if (grdStock.Col == c_Kilos)
                    {
                        switch (vi)
                        {
                            //Fecha
                            case 1:
                                stock.Fecha = stock.Fecha.AddDays(1);
                                stock.precios.Fecha = stock.Fecha;

                                grdStock.set_Texto(grdStock.Row, c_Fecha, stock.Fecha);

                                stock.Costo = stock.precios.Buscar();
                                grdStock.set_Texto(grdStock.Row, c_Costo, stock.Costo);
                                grdStock.set_Texto(grdStock.Row, c_Total, 0);
                                break;
                            //Suc
                            case 2:
                                stock.Sucursal.Siguiente();

                                grdStock.set_Texto(grdStock.Row, c_IdSuc, stock.Sucursal.ID);
                                grdStock.set_Texto(grdStock.Row, c_IdSuc + 1, stock.Sucursal.Nombre);

                                stock.precios.Sucursal = stock.Sucursal;
                                stock.Costo = stock.precios.Buscar();
                                grdStock.set_Texto(grdStock.Row, c_Costo, stock.Costo);
                                grdStock.set_Texto(grdStock.Row, c_Total, 0);
                                break;
                            //Nada
                            case 3:

                                break;
                            //Producto
                            case 4:
                                stock.Producto.Siguiente();
                                stock.precios.Producto = stock.Producto;

                                stock.Descripcion = stock.Producto.Nombre;

                                grdStock.set_Texto(grdStock.Row, c_IdProd, stock.Producto.ID);
                                grdStock.set_Texto(grdStock.Row, c_Descripcion, stock.Descripcion);

                                stock.Costo = stock.precios.Buscar();
                                grdStock.set_Texto(grdStock.Row, c_Costo, stock.Costo);
                                grdStock.set_Texto(grdStock.Row, c_Total, 0);
                                break;
                        }
                    }
                }
            }
        }
        //{
        //    if (e == 13)
        //    {
        //        if (stock.ID == 0)
        //        {

        //            if (grdStock.Col == c_Kilos)
        //            {
        //                stock.Producto.Siguiente();
        //                stock.precios.Producto = stock.Producto;

        //                stock.Descripcion = stock.Producto.Nombre;

        //                grdStock.set_Texto(grdStock.Row, c_IdProd, stock.Producto.ID);
        //                grdStock.set_Texto(grdStock.Row, c_Descripcion, stock.Descripcion);

        //                stock.Costo = stock.precios.Buscar();
        //                grdStock.set_Texto(grdStock.Row, c_Costo, stock.Costo);
        //                grdStock.set_Texto(grdStock.Row, c_Total, 0);
        //            }
        //        }
        //    }
        //}

        private void GrdStock_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdStock.get_Texto(grdStock.Row, 0)) != 0)
                    {
                        if (stock.Fecha_Cerrada(stock.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                stock.ID = Convert.ToInt32(grdStock.get_Texto(grdStock.Row, 0));
                                stock.Borrar();
                                grdStock.BorrarFila(grdStock.Row);
                                GrdStock_CambioFila(Convert.ToByte(grdStock.Row));
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
                    n.Add(Convert.ToInt32(grdStock.get_Texto(i, c_Id)));
                }
                cm.Ids = n;
                cm.ShowDialog();
                cmdMostrar.PerformClick();
            }
        }

        private void cmdHerramientas_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void grdStock_Click()
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

        private void grdStock_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float k = 0, t = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    k += Convert.ToSingle(grdStock.get_Texto(i, c_Kilos));
                    t += Convert.ToSingle(grdStock.get_Texto(i, c_Total));
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";
                lblKilos.Text = $"Kilos: {k:N2}";
                lblTotal.Text = $"Total Salida: {t:C2}";
            }
        }
    }
}
