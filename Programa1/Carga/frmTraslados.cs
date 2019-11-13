
namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmTraslados : Form
    {
        private Traslados Traslados;
        private Precios_Sucursales precios;

        public frmTraslados()
        {
            InitializeComponent();

            precios = new Precios_Sucursales();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdTraslados.TeclasManejadas = n;

            Traslados = new Traslados();
            grdTraslados.MostrarDatos(Traslados.Datos("Id=0"), true);
            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdTraslados.AgregarTeclas(Convert.ToInt32(Keys.Subtract), grdTraslados.get_ColIndex("Id_Productos"), grdTraslados.get_ColIndex("Kilos"));
            grdTraslados.AgregarTeclas(Convert.ToInt32(Keys.Add), grdTraslados.get_ColIndex("Suc_Salida"), grdTraslados.get_ColIndex("Kilos"));

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
            grdTraslados.MostrarDatos(Traslados.Datos(s), true);
            formato_Grilla();
            Totales();
            grdTraslados.ActivarCelda(grdTraslados.Rows - 1, grdTraslados.get_ColIndex("Fecha"));
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
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Id"), 0);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Fecha"), 60);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Suc_Salida"), 35);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Nombre_Salida"), 100);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Suc_Entrada"), 35);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Nombre_Entrada"), 100);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Id_Productos"), 30);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Descripcion"), 100);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Costo_Salida"), 60);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Costo_Entrada"), 60);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Kilos"), 60);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Total_Salida"), 80);
            grdTraslados.set_ColW(grdTraslados.get_ColIndex("Total_Entrada"), 80);

            grdTraslados.Columnas[grdTraslados.get_ColIndex("Costo_Salida")].Format = "C2";
            grdTraslados.Columnas[grdTraslados.get_ColIndex("Costo_Entrada")].Format = "C2";
            grdTraslados.Columnas[grdTraslados.get_ColIndex("Kilos")].Format = "N2";
            grdTraslados.Columnas[grdTraslados.get_ColIndex("Total_Salida")].Format = "C2";
            grdTraslados.Columnas[grdTraslados.get_ColIndex("Total_Entrada")].Format = "C2";

            grdTraslados.Columnas[grdTraslados.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdTraslados.set_Texto(0, grdTraslados.get_ColIndex("Suc_Salida"), "Suc S");
            grdTraslados.set_Texto(0, grdTraslados.get_ColIndex("Suc_Entrada"), "Suc E");
            grdTraslados.set_Texto(0, grdTraslados.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double tSalida = grdTraslados.SumarCol(grdTraslados.get_ColIndex("Total_Salida"), false);
            double tEntrada = grdTraslados.SumarCol(grdTraslados.get_ColIndex("Total_Entrada"), false);
            double k = grdTraslados.SumarCol(grdTraslados.get_ColIndex("Kilos"), false);
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
            cProds.Filtro_In = $" (SELECT DISTINCT Id_Productos FROM Traslados WHERE {cFecha.Cadena()})";
            cSucSalida.Filtro_In = $" (SELECT DISTINCT Suc_Salida FROM Traslados WHERE {cFecha.Cadena()})";
            cSucEntrada.Filtro_In = $" (SELECT DISTINCT Suc_Entrada FROM Traslados WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }


        private void GrdTraslados_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdTraslados.get_Texto(f, grdTraslados.get_ColIndex("Id")));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    Traslados.Fecha = Convert.ToDateTime(a);
                    precios.Fecha = Traslados.Fecha;

                    if (id != 0) { Traslados.Actualizar(); }

                    grdTraslados.set_Texto(f, c, a);
                    grdTraslados.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //Suc_Salida
                    Traslados.sucS.Id = Convert.ToInt32(a);
                    if (Traslados.sucS.Existe() == true)
                    {
                        precios.suc = Traslados.sucS;

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
                    Traslados.sucE.Id = Convert.ToInt32(a);
                    if (Traslados.sucE.Existe() == true)
                    {
                        precios.suc = Traslados.sucE;

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
                    Traslados.producto.Id = Convert.ToInt32(a);
                    if (Traslados.producto.Existe() == true)
                    {
                        precios.producto = Traslados.producto;

                        Traslados.Descripcion = Traslados.producto.Nombre;

                        grdTraslados.set_Texto(f, c, a);
                        grdTraslados.set_Texto(f, c + 1, Traslados.producto.Nombre);

                        precios.suc = Traslados.sucS;
                        Traslados.CostoS = precios.Buscar();
                        grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Costo_Salida"), Traslados.CostoS);
                        grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Salida"), Traslados.Kilos*Traslados.CostoS);

                        precios.suc = Traslados.sucE;
                        Traslados.CostoE = precios.Buscar();
                        grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Costo_Entrada"), Traslados.CostoE);
                        grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Entrada"), Traslados.Kilos * Traslados.CostoE);

                        if (id != 0) { Traslados.Actualizar(); }

                        grdTraslados.ActivarCelda(f, grdTraslados.get_ColIndex("Kilos"));
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
                    grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Salida"), Traslados.CostoS * Traslados.Kilos);

                    if (id != 0) { Traslados.Actualizar(); }

                    grdTraslados.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 9:
                    //Costo_Entrada
                    Traslados.CostoE = Convert.ToSingle(a);
                    grdTraslados.set_Texto(f, c, a);
                    grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Entrada"), Traslados.CostoE * Traslados.Kilos);

                    if (id != 0) { Traslados.Actualizar(); }

                    grdTraslados.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 10:
                    //Kilos
                    Traslados.Kilos = Convert.ToSingle(a);
                    grdTraslados.set_Texto(f, c, a);
                    grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Salida"), Traslados.CostoS * Traslados.Kilos);
                    grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Total_Entrada"), Traslados.CostoE * Traslados.Kilos);

                    if (grdTraslados.Row == grdTraslados.Rows - 1)
                    {
                        Traslados.Agregar();
                        grdTraslados.set_Texto(f, grdTraslados.get_ColIndex("Id"), Traslados.Id);
                        grdTraslados.AgregarFila();
                        //Rellenar nueva fila

                        grdTraslados.set_Texto(f + 1, grdTraslados.get_ColIndex("Fecha"), Traslados.Fecha);
                        
                        Traslados.Kilos = 0;
                        grdTraslados.ActivarCelda(f + 1, grdTraslados.get_ColIndex("Suc_Entrada"));
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

        private void GrdTraslados_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdTraslados.get_Texto(Fila, grdTraslados.get_ColIndex("Id")).ToString());
            Traslados.Cargar_Fila(i);
            precios.Fecha = Traslados.Fecha;
            precios.suc = Traslados.sucS;
            precios.producto = Traslados.producto;
        }

        private void GrdTraslados_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Traslados.Id == 0)
                {

                    if (grdTraslados.Col == grdTraslados.get_ColIndex("Kilos"))
                    {
                        Traslados.producto.Siguiente();
                        precios.producto = Traslados.producto;

                        Traslados.Descripcion = Traslados.producto.Nombre;

                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Id_Productos"), Traslados.producto.Id);
                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Descripcion"), Traslados.Descripcion);

                        precios.suc = Traslados.sucS;
                        Traslados.CostoS = precios.Buscar();
                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Costo_Salida"), Traslados.CostoS);
                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Total_Salida"), 0);

                        precios.suc = Traslados.sucE;
                        Traslados.CostoE = precios.Buscar();
                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Costo_Entrada"), Traslados.CostoE);
                        grdTraslados.set_Texto(grdTraslados.Row, grdTraslados.get_ColIndex("Total_Entrada"), 0);
                    }
                }
            }
        }

        private void GrdTraslados_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdTraslados.get_Texto(grdTraslados.Row, 0)) != 0)
                        {
                            Traslados.Id = Convert.ToInt32(grdTraslados.get_Texto(grdTraslados.Row, 0));
                            Traslados.Borrar();
                            grdTraslados.BorrarFila(grdTraslados.Row);
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
                    n.Add(Convert.ToInt32(grdTraslados.get_Texto(i, grdTraslados.get_ColIndex("Id"))));
                }
                cm.Ids = n;
                cm.ShowDialog();
                cmdMostrar.PerformClick();
            }
        }


    }
}
