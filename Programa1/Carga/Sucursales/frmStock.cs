﻿namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmStock : Form
    {
        private Stock stock;


        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Costo;
        private Byte c_Kilos;
        private Byte c_Total;
        #endregion
        public frmStock()
        {
            InitializeComponent();

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
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Kilos);

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
            grdStock.set_ColW(c_IdSuc + 1, 100);
            grdStock.set_ColW(c_IdProd, 30);
            grdStock.set_ColW(c_Descripcion, 150);
            grdStock.set_ColW(c_Costo, 60);
            grdStock.set_ColW(c_Kilos, 60);
            grdStock.set_ColW(c_Total, 80);
            grdStock.set_ColW(c_Total + 1, 0);

            grdStock.Columnas[c_Costo].Format = "C2";
            grdStock.Columnas[c_Kilos].Format = "N2";
            grdStock.Columnas[c_Total].Format = "C2";

            grdStock.Columnas[c_IdSuc + 1].Style.ForeColor = Color.DimGray;
            grdStock.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

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
                        if (df >= cFecha.fecha_Actual)
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
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
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

                            grdStock.set_Texto(f + 1, c_Fecha, stock.Fecha);
                            grdStock.set_Texto(f + 1, c_IdSuc, stock.Sucursal.ID);
                            grdStock.set_Texto(f + 1, c_IdSuc + 1, stock.Sucursal.Nombre);

                            stock.Producto.Siguiente();
                            stock.precios.Producto = stock.Producto;

                            stock.Descripcion = stock.Producto.Nombre;

                            grdStock.set_Texto(f + 1, c_IdProd, stock.Producto.ID);
                            grdStock.set_Texto(f + 1, c_Descripcion, stock.Descripcion);

                            stock.Costo = stock.precios.Buscar();
                            grdStock.set_Texto(f + 1, c_Costo, stock.Costo);
                            grdStock.set_Texto(f + 1, c_Total, 0);

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
            else
            {
                Mensaje("La fecha esta cerrada.");
            }
        }

        private void GrdStock_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdStock.get_Texto(Fila, c_Id).ToString());
            stock.Cargar_Fila(i);
            stock.precios.Fecha = stock.Fecha;
            stock.precios.Sucursal = stock.Sucursal;
            stock.precios.Producto = stock.Producto;
        }

        private void GrdStock_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (stock.ID == 0)
                {

                    if (grdStock.Col == c_Kilos)
                    {
                        stock.Producto.Siguiente();
                        stock.precios.Producto = stock.Producto;

                        stock.Descripcion = stock.Producto.Nombre;

                        grdStock.set_Texto(grdStock.Row, c_IdProd, stock.Producto.ID);
                        grdStock.set_Texto(grdStock.Row, c_Descripcion, stock.Descripcion);

                        stock.Costo = stock.precios.Buscar();
                        grdStock.set_Texto(grdStock.Row, c_Costo, stock.Costo);
                        grdStock.set_Texto(grdStock.Row, c_Total, 0);
                    }
                }
            }
        }

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
    }
}
