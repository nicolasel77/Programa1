
namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmTraslados : Form
    {
        private Traslados Traslados;


        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSucS;
        private Byte c_IdSucE;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_CostoS;
        private Byte c_CostoE;
        private Byte c_Kilos;
        private Byte c_TotalS;
        private Byte c_TotalE;
        #endregion

        public frmTraslados()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdTraslados.TeclasManejadas = n;

            Traslados = new Traslados();
            grdTraslados.MostrarDatos(Traslados.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdTraslados.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdTraslados.get_ColIndex("Fecha"));
            c_IdSucS = Convert.ToByte(grdTraslados.get_ColIndex("Suc_Salida"));
            c_IdSucE = Convert.ToByte(grdTraslados.get_ColIndex("Suc_Entrada"));
            c_IdProd = Convert.ToByte(grdTraslados.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdTraslados.get_ColIndex("Descripcion"));
            c_CostoS = Convert.ToByte(grdTraslados.get_ColIndex("Costo_Salida"));
            c_CostoE = Convert.ToByte(grdTraslados.get_ColIndex("Costo_Entrada"));
            c_Kilos = Convert.ToByte(grdTraslados.get_ColIndex("Kilos"));
            c_TotalS = Convert.ToByte(grdTraslados.get_ColIndex("Total_Salida"));
            c_TotalE = Convert.ToByte(grdTraslados.get_ColIndex("Total_Entrada"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdTraslados.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            grdTraslados.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSucS, c_Kilos);
            grdTraslados.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSucE, c_Kilos);
            //cSucEntrada.
            Totales();
        }

        private void FrmTraslados_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cSucEntrada.Siguiente();
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
                        cSucEntrada.Anterior();
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
            grdTraslados.MostrarDatos(Traslados.Datos(s), true);
            formato_Grilla();
            Totales();
            grdTraslados.ActivarCelda(grdTraslados.Rows - 1, c_Fecha);
            grdTraslados.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucSalida.Cadena("Suc_Salida");
            string e = cSucEntrada.Cadena("Suc_Entrada");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(s, e);
            s = h.Unir(s, f);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdTraslados.set_ColW(c_Id, 0);
            grdTraslados.set_ColW(c_Fecha, 60);
            grdTraslados.set_ColW(c_IdSucS, 35);
            grdTraslados.set_ColW(c_IdSucS + 1, 100);
            grdTraslados.set_ColW(c_IdSucE, 35);
            grdTraslados.set_ColW(c_IdSucE + 1, 100);
            grdTraslados.set_ColW(c_IdProd, 30);
            grdTraslados.set_ColW(c_Descripcion, 100);
            grdTraslados.set_ColW(c_CostoS, 60);
            grdTraslados.set_ColW(c_CostoE, 60);
            grdTraslados.set_ColW(c_Kilos, 60);
            grdTraslados.set_ColW(c_TotalS, 80);
            grdTraslados.set_ColW(c_TotalE, 80);
            grdTraslados.set_ColW(c_TotalE + 1, 0);
            grdTraslados.set_ColW(c_TotalE + 2, 0);

            grdTraslados.Columnas[c_CostoS].Format = "C2";
            grdTraslados.Columnas[c_CostoE].Format = "C2";
            grdTraslados.Columnas[c_Kilos].Format = "N2";
            grdTraslados.Columnas[c_TotalS].Format = "C2";
            grdTraslados.Columnas[c_TotalE].Format = "C2";

            grdTraslados.Columnas[c_IdSucS + 1].Style.ForeColor = Color.DimGray;
            grdTraslados.Columnas[c_IdSucE + 1].Style.ForeColor = Color.DimGray;
            grdTraslados.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdTraslados.set_Texto(0, c_IdSucS, "Suc S");
            grdTraslados.set_Texto(0, c_IdSucE, "Suc E");
            grdTraslados.set_Texto(0, c_IdProd, "Prod");
        }

        private void Totales()
        {
            double tSalida = grdTraslados.SumarCol(c_TotalS, false);
            double tEntrada = grdTraslados.SumarCol(c_TotalE, false);
            double k = grdTraslados.SumarCol(c_Kilos, false);
            int c = grdTraslados.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotalS.Text = $"Total Salida: {tSalida:C2}";
            lblTotalE.Text = $"Total Entrada: {tEntrada:C2}";
            lblDiferencia.Text = $"Diferencia: {(tEntrada - tSalida):C2}";

        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdTraslados.Rows = 1;
            grdTraslados.Rows = 2;
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Traslados WHERE {vFecha})";
            cSucSalida.Filtro_In = $" (SELECT DISTINCT Suc_Salida FROM Traslados WHERE {vFecha})";
            cSucEntrada.Filtro_In = $" (SELECT DISTINCT Suc_Entrada FROM Traslados WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdTraslados_Editado(short f, short c, object a)
        {
            if (Traslados.Fecha_Cerrada(Traslados.Fecha) == false)
            {
                int id = Convert.ToInt32(grdTraslados.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (Traslados.Fecha_Cerrada(df) == false)
                            {
                                Traslados.Fecha = df;
                                Traslados.precios.Fecha = Traslados.Fecha;

                                if (id != 0) { Traslados.Actualizar(); }

                                grdTraslados.set_Texto(f, c, a);
                                grdTraslados.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                            grdTraslados.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //Suc_Salida
                        Traslados.sucS.ID = Convert.ToInt32(a);
                        if (Traslados.sucS.Existe() == true)
                        {
                            Traslados.precios.Sucursal = Traslados.sucS;

                            if (id != 0) { Traslados.Actualizar(); }

                            grdTraslados.set_Texto(f, c, a);
                            grdTraslados.set_Texto(f, c + 1, Traslados.sucS.Nombre);

                            grdTraslados.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdTraslados.ErrorEnTxt();
                        }
                        break;
                    case 4:
                        //Suc_Entrada
                        Traslados.sucE.ID = Convert.ToInt32(a);
                        if (Traslados.sucE.Existe() == true)
                        {
                            Traslados.precios.Sucursal = Traslados.sucE;

                            if (id != 0) { Traslados.Actualizar(); }

                            grdTraslados.set_Texto(f, c, a);
                            grdTraslados.set_Texto(f, c + 1, Traslados.sucE.Nombre);

                            grdTraslados.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdTraslados.ErrorEnTxt();
                        }
                        break;
                    case 6:
                        //ID_Productos
                        Traslados.Producto.ID = Convert.ToInt32(a);
                        if (Traslados.Producto.Existe() == true)
                        {
                            Traslados.precios.Producto = Traslados.Producto;

                            Traslados.Descripcion = Traslados.Producto.Nombre;

                            grdTraslados.set_Texto(f, c, a);
                            grdTraslados.set_Texto(f, c + 1, Traslados.Producto.Nombre);

                            Traslados.precios.Sucursal = Traslados.sucS;
                            Traslados.CostoS = Traslados.precios.Buscar();
                            grdTraslados.set_Texto(f, c_CostoS, Traslados.CostoS);
                            grdTraslados.set_Texto(f, c_TotalS, Traslados.Kilos * Traslados.CostoS);

                            Traslados.precios.Sucursal = Traslados.sucE;
                            Traslados.CostoE = Traslados.precios.Buscar();
                            grdTraslados.set_Texto(f, c_CostoE, Traslados.CostoE);
                            grdTraslados.set_Texto(f, c_TotalE, Traslados.Kilos * Traslados.CostoE);

                            if (id != 0) { Traslados.Actualizar(); }

                            grdTraslados.ActivarCelda(f, c_Kilos);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            grdTraslados.ErrorEnTxt();
                        }
                        break;
                    case 7:
                        //Descripcion
                        Traslados.Descripcion = a.ToString();
                        grdTraslados.set_Texto(f, c, a);

                        if (id != 0) { Traslados.Actualizar(); }

                        grdTraslados.ActivarCelda(f + 1, c);
                        break;
                    case 8:
                        //Costo_Salida
                        Traslados.CostoS = Convert.ToSingle(a);
                        grdTraslados.set_Texto(f, c, a);
                        grdTraslados.set_Texto(f, c_TotalS, Traslados.CostoS * Traslados.Kilos);

                        if (id != 0) { Traslados.Actualizar(); }

                        grdTraslados.ActivarCelda(f + 1, c);
                        Totales();
                        break;
                    case 9:
                        //Costo_Entrada
                        Traslados.CostoE = Convert.ToSingle(a);
                        grdTraslados.set_Texto(f, c, a);
                        grdTraslados.set_Texto(f, c_TotalE, Traslados.CostoE * Traslados.Kilos);

                        if (id != 0) { Traslados.Actualizar(); }

                        grdTraslados.ActivarCelda(f + 1, c);
                        Totales();
                        break;
                    case 10:
                        //Kilos
                        Traslados.Kilos = Convert.ToSingle(a);
                        grdTraslados.set_Texto(f, c, a);
                        grdTraslados.set_Texto(f, c_TotalS, Traslados.CostoS * Traslados.Kilos);
                        grdTraslados.set_Texto(f, c_TotalE, Traslados.CostoE * Traslados.Kilos);

                        if (grdTraslados.Row == grdTraslados.Rows - 1)
                        {
                            Traslados.Agregar();
                            grdTraslados.set_Texto(f, c_Id, Traslados.ID);
                            grdTraslados.AgregarFila();
                            //Rellenar nueva fila

                            grdTraslados.set_Texto(f + 1, c_Fecha, Traslados.Fecha);
                            grdTraslados.set_Texto(f + 1, c_IdSucS, Traslados.sucS.ID);
                            grdTraslados.set_Texto(f + 1, c_IdSucS + 1, Traslados.sucS.Nombre);

                            Traslados.Kilos = 0;
                            grdTraslados.ActivarCelda(f + 1, c_IdSucE);
                        }
                        else
                        {
                            Traslados.Actualizar();
                            grdTraslados.ActivarCelda(f + 1, c);
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

        private void GrdTraslados_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdTraslados.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                Traslados.Cargar_Fila(i);
                Traslados.precios.Fecha = Traslados.Fecha;
                Traslados.precios.Sucursal = Traslados.sucS;
                Traslados.precios.Producto = Traslados.Producto;
            }
            else
            {
                Traslados.ID = 0;
                Traslados.Fecha = Convert.ToDateTime(grdTraslados.get_Texto(Fila, c_Fecha));
                Traslados.Producto.ID = Convert.ToInt32(grdTraslados.get_Texto(Fila, c_IdProd));
                Traslados.Descripcion = grdTraslados.get_Texto(Fila, c_Descripcion).ToString();
                Traslados.sucS.ID = Convert.ToInt32(grdTraslados.get_Texto(Fila, c_IdSucS));
                Traslados.sucE.ID = Convert.ToInt32(grdTraslados.get_Texto(Fila, c_IdSucE));
                Traslados.CostoS = Convert.ToSingle(grdTraslados.get_Texto(Fila, c_CostoS));
                Traslados.CostoE = Convert.ToSingle(grdTraslados.get_Texto(Fila, c_CostoE));
                Traslados.Kilos = Convert.ToSingle(grdTraslados.get_Texto(Fila, c_Kilos));
            }

        }

        private void GrdTraslados_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Traslados.ID == 0)
                {

                    if (grdTraslados.Col == c_Kilos)
                    {
                        Traslados.Producto.Siguiente();
                        Traslados.precios.Producto = Traslados.Producto;

                        Traslados.Descripcion = Traslados.Producto.Nombre;

                        grdTraslados.set_Texto(grdTraslados.Row, c_IdProd, Traslados.Producto.ID);
                        grdTraslados.set_Texto(grdTraslados.Row, c_Descripcion, Traslados.Descripcion);

                        Traslados.precios.Sucursal = Traslados.sucS;
                        Traslados.CostoS = Traslados.precios.Buscar();
                        grdTraslados.set_Texto(grdTraslados.Row, c_CostoS, Traslados.CostoS);
                        grdTraslados.set_Texto(grdTraslados.Row, c_TotalS, 0);

                        Traslados.precios.Sucursal = Traslados.sucE;
                        Traslados.CostoE = Traslados.precios.Buscar();
                        grdTraslados.set_Texto(grdTraslados.Row, c_CostoE, Traslados.CostoE);
                        grdTraslados.set_Texto(grdTraslados.Row, c_TotalE, 0);
                    }
                }
            }
        }

        private void GrdTraslados_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdTraslados.get_Texto(grdTraslados.Row, 0)) != 0)
                    {
                        if (Traslados.Fecha_Cerrada(Traslados.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Traslados.ID = Convert.ToInt32(grdTraslados.get_Texto(grdTraslados.Row, 0));
                                Traslados.Borrar();
                                grdTraslados.BorrarFila(grdTraslados.Row);
                                GrdTraslados_CambioFila(Convert.ToByte(grdTraslados.Row));
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
            if (grdTraslados.Rows > 2)
            {
                frmCMTraslados cm = new frmCMTraslados();
                List<int> n = new List<int>();

                int d = grdTraslados.Selection.r1;
                int h = grdTraslados.Selection.r2;
                if (d == -1)
                {
                    d = 1;
                    h = grdTraslados.Rows - 2;
                }
                for (int i = d; i <= h; i++)
                {
                    n.Add(Convert.ToInt32(grdTraslados.get_Texto(i, c_Id)));
                }
                cm.Ids = n;
                cm.ShowDialog();
                cmdMostrar.PerformClick();
            }
        }


    }
}
