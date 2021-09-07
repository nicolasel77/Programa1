namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmAPicada : Form
    {
        private APicada APicada;


        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdProd_A;
        private Byte c_Costo_A;
        private Byte c_Kilos_A;
        private Byte c_IdProd_S;
        private Byte c_Costo_S;
        private Byte c_Kilos_S;
        private Byte c_Total_A;
        private Byte c_Total_S;
        private Byte c_Reintegro;
        #endregion
        public frmAPicada()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdAPicada.TeclasManejadas = n;

            APicada = new APicada();
            grdAPicada.MostrarDatos(APicada.Datos_Vista("Id=0"), true);

            c_Id = Convert.ToByte(grdAPicada.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdAPicada.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdAPicada.get_ColIndex("Id_Sucursales"));
            c_IdProd_A = Convert.ToByte(grdAPicada.get_ColIndex("Id_Productos_A"));
            c_Costo_A = Convert.ToByte(grdAPicada.get_ColIndex("Costo_A"));
            c_Kilos_A = Convert.ToByte(grdAPicada.get_ColIndex("Kilos_A"));
            c_Total_A = Convert.ToByte(grdAPicada.get_ColIndex("Total_A"));
            c_IdProd_S = Convert.ToByte(grdAPicada.get_ColIndex("Id_Productos_S"));
            c_Costo_S = Convert.ToByte(grdAPicada.get_ColIndex("Costo_S"));
            c_Kilos_S = Convert.ToByte(grdAPicada.get_ColIndex("Kilos_S"));
            c_Total_S = Convert.ToByte(grdAPicada.get_ColIndex("Total_S"));
            c_Reintegro = Convert.ToByte(grdAPicada.get_ColIndex("Reintegro"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdAPicada.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd_A, c_Kilos_A);
            grdAPicada.AgregarTeclas(Convert.ToInt32(Keys.Multiply), c_IdSuc, c_Kilos_A);

            Totales();
        }

        private void FrmAPicada_KeyUp(object sender, KeyEventArgs e)
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
                            cProdA.Siguiente();
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
                            cProdA.Anterior();
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
            grdAPicada.MostrarDatos(APicada.Datos_Vista(s), true);
            formato_Grilla();
            Totales();
            grdAPicada.ActivarCelda(grdAPicada.Rows - 1, c_Fecha);
            grdAPicada.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProdA.Cadena("Id_Productos_A");
            string pS = cProdS.Cadena("Id_Productos_S");
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);
            s = h.Unir(s, p);
            s = h.Unir(s, pS);

            return s;
        }

        private void formato_Grilla()
        {
            grdAPicada.set_ColW(c_Id, 0);
            grdAPicada.set_ColW(c_Fecha, 60);
            grdAPicada.set_ColW(c_IdSuc, 30);
            grdAPicada.set_ColW(c_IdSuc + 1, 60);
            grdAPicada.set_ColW(c_IdProd_A, 30);
            grdAPicada.set_ColW(c_IdProd_A + 1, 130);
            grdAPicada.set_ColW(c_Costo_A, 60);
            grdAPicada.set_ColW(c_Kilos_A, 60);
            grdAPicada.set_ColW(c_Total_A, 80);
            grdAPicada.set_ColW(c_IdProd_S, 30);
            grdAPicada.set_ColW(c_IdProd_S + 1, 130);
            grdAPicada.set_ColW(c_Costo_S, 60);
            grdAPicada.set_ColW(c_Kilos_S, 60);
            grdAPicada.set_ColW(c_Total_S, 80);
            grdAPicada.set_ColW(c_Reintegro, 80);

            grdAPicada.Columnas[c_Costo_A].Format = "C2";
            grdAPicada.Columnas[c_Kilos_A].Format = "N2";
            grdAPicada.Columnas[c_Total_A].Format = "C2";
            grdAPicada.Columnas[c_Costo_S].Format = "C2";
            grdAPicada.Columnas[c_Kilos_S].Format = "N2";
            grdAPicada.Columnas[c_Total_S].Format = "C2";
            grdAPicada.Columnas[c_Reintegro].Format = "C2";

            grdAPicada.Columnas[c_IdSuc + 1].Style.ForeColor = Color.DimGray;
            grdAPicada.Columnas[c_IdSuc].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdAPicada.Columnas[c_Kilos_A].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdAPicada.Columnas[c_Kilos_S].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdAPicada.Columnas[c_Reintegro].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdAPicada.set_Texto(0, c_IdSuc, "Suc");
            grdAPicada.set_Texto(0, c_IdProd_A, "Prod");
            grdAPicada.set_Texto(0, c_IdProd_S, "Prod");
        }

        private void Totales()
        {
            double t = grdAPicada.SumarCol(c_Total_A, false);
            double k = grdAPicada.SumarCol(c_Kilos_A, false);
            double tS = grdAPicada.SumarCol(c_Total_S, false);
            double kS = grdAPicada.SumarCol(c_Kilos_S, false);
            double r = grdAPicada.SumarCol(c_Reintegro, false);

            int c = grdAPicada.Rows - 2;

            lblCant.Text = $"Registros: {c:N0}";
            lblKilosA.Text = $"Kilos A: {k:N2}";
            lblTotalA.Text = $"Total A: {t:C2}";
            lblKilosS.Text = $"Kilos S: {kS:N2}";
            lblTotalS.Text = $"Total S: {tS:C2}";
            lblReintegro.Text = $"Reintegro: {r:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdAPicada.Rows = 1;
            grdAPicada.Rows = 2;
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
            cProdA.Filtro_In = $" (SELECT DISTINCT Id_Productos_A FROM APicada WHERE {vFecha})";
            cProdS.Filtro_In = $" (SELECT DISTINCT Id_Productos_S FROM APicada WHERE {vFecha})";
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM APicada WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdAPicada_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdAPicada.get_Texto(f, c_Id));
            DateTime df = Convert.ToDateTime(grdAPicada.get_Texto(f, c_Fecha));

            if (APicada.Fecha_Cerrada(df) == false)
            {
                switch (c)
                {
                    case 1:
                        //Fecha
                        df = Convert.ToDateTime(a);
                        if (cFecha.Fecha_En_Rango(df))
                        {
                            if (APicada.Fecha_Cerrada(df) == false)
                            {
                                APicada.Fecha = df;
                                APicada.precios.Fecha = APicada.Fecha;

                                if (id != 0) { APicada.Actualizar(); }

                                grdAPicada.set_Texto(f, c, a);
                                grdAPicada.ActivarCelda(f, c + 1);
                            }
                             else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe estar dentro del rango fecha seleccionado.");
                            grdAPicada.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //ID_Sucursales
                        APicada.Sucursal.ID = Convert.ToInt32(a);
                        if (APicada.Sucursal.Existe() == true)
                        {
                            APicada.precios.Sucursal = APicada.Sucursal;

                            if (id != 0) { APicada.Actualizar(); }

                            grdAPicada.set_Texto(f, c, a);
                            grdAPicada.set_Texto(f, c + 1, APicada.Sucursal.Nombre);

                            grdAPicada.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdAPicada.ErrorEnTxt();
                        }
                        break;
                    case 4:
                        //ID_Productos_A
                        APicada.Producto_A.ID = Convert.ToInt32(a);
                        if (APicada.Producto_A.Existe() == true)
                        {
                            APicada.precios.Producto = APicada.Producto_A;

                            grdAPicada.set_Texto(f, c, a);
                            grdAPicada.set_Texto(f, c + 1, APicada.Producto_A.Nombre);

                            APicada.Costo_A = APicada.precios.Buscar();
                            grdAPicada.set_Texto(f, c_Costo_A, APicada.Costo_A);
                            grdAPicada.set_Texto(f, c_Total_A, APicada.Costo_A * APicada.Kilos_A);
                            grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                            if (id != 0) { APicada.Actualizar(); }

                            grdAPicada.ActivarCelda(f, c_Kilos_A);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            grdAPicada.ErrorEnTxt();
                        }
                        break;


                    case 6:
                        //Kilos_A
                        APicada.Kilos_A = Convert.ToSingle(a);
                        grdAPicada.set_Texto(f, c, a);
                        grdAPicada.set_Texto(f, c_Total_A, APicada.Costo_A * APicada.Kilos_A);
                        grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                        if (id != 0) { APicada.Actualizar(); }

                        grdAPicada.ActivarCelda(f, c_IdProd_S);

                        Totales();
                        break;
                    case 7:
                        //ID_Productos_S
                        APicada.Producto_S.ID = Convert.ToInt32(a);
                        if (APicada.Producto_S.Existe() == true)
                        {
                            APicada.precios.Producto = APicada.Producto_S;

                            grdAPicada.set_Texto(f, c, a);
                            grdAPicada.set_Texto(f, c + 1, APicada.Producto_S.Nombre);

                            APicada.Costo_S = APicada.precios.Buscar();
                            grdAPicada.set_Texto(f, c_Costo_S, APicada.Costo_S);
                            grdAPicada.set_Texto(f, c_Total_S, APicada.Costo_S * APicada.Kilos_S);
                            grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                            if (id != 0) { APicada.Actualizar(); }

                            grdAPicada.ActivarCelda(f, c_Kilos_S);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el producto " + a.ToString());
                            grdAPicada.ErrorEnTxt();
                        }
                        break;


                    case 9:
                        //Kilos_S
                        APicada.Kilos_S = Convert.ToSingle(a);
                        grdAPicada.set_Texto(f, c, a);
                        grdAPicada.set_Texto(f, c_Total_S, APicada.Costo_S * APicada.Kilos_S);
                        grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                        if (grdAPicada.Row == grdAPicada.Rows - 1)
                        {
                            if (APicada.Fecha >= cFecha.fecha_Actual & APicada.Sucursal.ID != 0 & APicada.Producto_A.ID != 0 & APicada.Producto_S.ID != 0)
                            {
                                APicada.Agregar();
                                grdAPicada.set_Texto(f, c_Id, APicada.ID);
                                grdAPicada.AgregarFila();
                                //Rellenar nueva fila

                                grdAPicada.set_Texto(f + 1, c_Fecha, APicada.Fecha);
                                grdAPicada.set_Texto(f + 1, c_IdSuc, APicada.Sucursal.ID);
                                grdAPicada.set_Texto(f + 1, c_IdSuc + 1, APicada.Sucursal.Nombre);

                                grdAPicada.ActivarCelda(f, c_Costo_S);
                            }
                        }
                        else
                        {
                            APicada.Actualizar();
                            grdAPicada.ActivarCelda(f, c_Costo_A);
                        }

                        Totales();
                        break;
                    case 10:
                        //Costo_A
                        APicada.Costo_A = Convert.ToSingle(a);
                        grdAPicada.set_Texto(f, c, a);
                        grdAPicada.set_Texto(f, c_Total_A, APicada.Costo_A * APicada.Kilos_A);
                        grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                        if (id != 0) { APicada.Actualizar(); }

                        grdAPicada.ActivarCelda(f, c_Costo_S);
                        Totales();
                        break;
                    case 11:
                        //Costo_S
                        APicada.Costo_S = Convert.ToSingle(a);
                        grdAPicada.set_Texto(f, c, a);
                        grdAPicada.set_Texto(f, c_Total_S, APicada.Costo_S * APicada.Kilos_S);
                        grdAPicada.set_Texto(f, c_Reintegro, Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_A)) - Convert.ToSingle(grdAPicada.get_Texto(f, c_Total_S)));

                        if (id != 0) { APicada.Actualizar(); }

                        grdAPicada.ActivarCelda(f + 1, c_Costo_S);
                        Totales();
                        break;
                }
            }
            else
            {
                Mensaje("La fecha ingresada se encuentra cerrada.");
            }
        }

        private void GrdAPicada_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdAPicada.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                APicada.Cargar_Fila(i);
                APicada.precios.Fecha = APicada.Fecha;
                APicada.precios.Sucursal = APicada.Sucursal;
                APicada.precios.Producto = APicada.Producto_A;
            }
            else
            {
                APicada.ID = 0;
                APicada.Fecha = Convert.ToDateTime(grdAPicada.get_Texto(Fila, c_Fecha));
                APicada.Sucursal.ID = Convert.ToInt32(grdAPicada.get_Texto(Fila, c_IdSuc));
                APicada.Producto_A.ID = Convert.ToInt32(grdAPicada.get_Texto(Fila, c_IdProd_A));
                APicada.Costo_A = Convert.ToSingle(grdAPicada.get_Texto(Fila, c_Costo_A));
                APicada.Kilos_A = Convert.ToSingle(grdAPicada.get_Texto(Fila, c_Kilos_A));
                APicada.Producto_S.ID = Convert.ToInt32(grdAPicada.get_Texto(Fila, c_IdProd_S));
                APicada.Costo_S = Convert.ToSingle(grdAPicada.get_Texto(Fila, c_Costo_S));
                APicada.Kilos_S = Convert.ToSingle(grdAPicada.get_Texto(Fila, c_Kilos_S));
            }
        }

        private void GrdAPicada_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (APicada.ID == 0)
                {

                    if (grdAPicada.Col == c_Kilos_A)
                    {
                        APicada.Producto_A.Siguiente();
                        APicada.precios.Producto = APicada.Producto_A;

                        grdAPicada.set_Texto(grdAPicada.Row, c_IdProd_A, APicada.Producto_A.ID);
                        grdAPicada.set_Texto(grdAPicada.Row, c_IdProd_A + 1, APicada.Producto_A.Nombre);

                        APicada.Costo_A = APicada.precios.Buscar();
                        grdAPicada.set_Texto(grdAPicada.Row, c_Costo_A, APicada.Costo_A);
                        grdAPicada.set_Texto(grdAPicada.Row, c_Total_A, 0);
                    }
                }
                else
                {
                    if (grdAPicada.Col == c_Costo_S)
                    {
                        if (grdAPicada.Row == grdAPicada.Rows - 2)
                        {
                            grdAPicada.ActivarCelda(grdAPicada.Row + 1, c_IdProd_A);
                        }
                    }
                }
            }
        }

        private void GrdAPicada_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdAPicada.get_Texto(grdAPicada.Row, 0)) != 0)
                    {
                        if (APicada.Fecha_Cerrada(APicada.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                APicada.ID = Convert.ToInt32(grdAPicada.get_Texto(grdAPicada.Row, 0));
                                APicada.Borrar();
                                grdAPicada.BorrarFila(grdAPicada.Row);
                                GrdAPicada_CambioFila(Convert.ToByte(grdAPicada.Row));
                                Totales();
                            }
                        }
                        else
                        {
                            Mensaje("La fecha ingresada se encuentra cerrada.");
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
            if (grdAPicada.Rows > 2)
            {
                frmCMApicada cm = new frmCMApicada();
                List<int> n = new List<int>();

                int d = grdAPicada.Selection.r1;
                int h = grdAPicada.Selection.r2;
                if (d == -1)
                {
                    d = 1;
                    h = grdAPicada.Rows - 2;
                }
                for (int i = d; i <= h; i++)
                {
                    n.Add(Convert.ToInt32(grdAPicada.get_Texto(i, c_Id)));
                }
                cm.Ids = n;
                cm.ShowDialog();
                cmdMostrar.PerformClick();
            }
        }

        private void grdAPicada_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float k = 0, t = 0;
                float kS = 0, tS = 0;
                float r = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    k += Convert.ToSingle(grdAPicada.get_Texto(i, c_Kilos_A));
                    t += Convert.ToSingle(grdAPicada.get_Texto(i, c_Total_A));
                    kS += Convert.ToSingle(grdAPicada.get_Texto(i, c_Kilos_S));
                    tS += Convert.ToSingle(grdAPicada.get_Texto(i, c_Total_S));
                    r += Convert.ToSingle(grdAPicada.get_Texto(i, c_Reintegro));
                }
                                
                lblKilosA.Text = $"Kilos A: {k:N2}";
                lblTotalA.Text = $"Total A: {t:C2}";
                lblKilosS.Text = $"Kilos S: {kS:N2}";
                lblTotalS.Text = $"Total S: {tS:C2}";
                lblReintegro.Text = $"Reintegro: {r:C2}";
            }
        }
    }
}
