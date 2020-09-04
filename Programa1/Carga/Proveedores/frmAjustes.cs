namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;
    
    public partial class frmAjustes : Form
    {
        private Ajustes Ajustes;

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdProv;
        private Byte c_Descripcion;
        private Byte c_Importe;
        #endregion

        public frmAjustes()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdAjustes.TeclasManejadas = n;

            Ajustes = new Ajustes();
            grdAjustes.MostrarDatos(Ajustes.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdAjustes.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdAjustes.get_ColIndex("Fecha"));
            c_IdProv = Convert.ToByte(grdAjustes.get_ColIndex("Id_Proveedores"));
            c_Descripcion = Convert.ToByte(grdAjustes.get_ColIndex("Descripcion"));
            c_Importe = Convert.ToByte(grdAjustes.get_ColIndex("Importe"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdAjustes.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_Fecha, c_Importe);
            grdAjustes.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Importe);

            Importe();
        }

        private void FrmAjustes_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Siguiente();
                    }                   
                    break;
                case Keys.Subtract:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Anterior();
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
            grdAjustes.MostrarDatos(Ajustes.Datos(s), true);
            formato_Grilla();
            Importe();
            grdAjustes.ActivarCelda(grdAjustes.Rows - 1, c_Fecha);
            grdAjustes.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string s = cProvs.Cadena("Id_Proveedores");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);

            return s;
        }

        private void formato_Grilla()
        {
            grdAjustes.set_ColW(c_Id, 0);
            grdAjustes.set_ColW(c_Fecha, 60);
            grdAjustes.set_ColW(c_IdProv, 30);
            grdAjustes.set_ColW(c_IdProv + 1, 100);
            grdAjustes.set_ColW(c_Descripcion, 150);
            grdAjustes.set_ColW(c_Importe, 80);

            grdAjustes.Columnas[c_Importe].Format = "C2";

            grdAjustes.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdAjustes.set_Texto(0, c_IdProv, "Prov");
        }

        private void Importe()
        {
            double t = grdAjustes.SumarCol(c_Importe, false);
            int c = grdAjustes.Rows - 2;
            lblImporte.Text = $"Importe: {t:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdAjustes.Rows = 1;
            grdAjustes.Rows = 2;
            Importe();
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
            cProvs.Filtro_In = $" (SELECT DISTINCT Id_Proveedores FROM Ajustes WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }


        private void GrdAjustes_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdAjustes.get_Texto(f, c_Id));
            switch (c)
            {
                case 1:
                    //Fecha
                    DateTime df = Convert.ToDateTime(a);
                    if (df >= cFecha.fecha_Actual)
                    {
                        Ajustes.Fecha = df;
                        Ajustes.precios.Fecha = Ajustes.Fecha;

                        if (id != 0) { Ajustes.Actualizar(); }

                        grdAjustes.set_Texto(f, c, a);
                        grdAjustes.ActivarCelda(f, c + 1);
                    }
                    else
                    {
                        Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                        grdAjustes.ErrorEnTxt();
                    }
                    break;
                case 2:
                    //ID_Proveedores
                    Ajustes.Proveedor.Id = Convert.ToInt32(a);
                    if (Ajustes.Proveedor.Existe() == true)
                    {
                        Ajustes.precios.Proveedor = Ajustes.Proveedor;

                        if (id != 0) { Ajustes.Actualizar(); }

                        grdAjustes.set_Texto(f, c, a);
                        grdAjustes.set_Texto(f, c + 1, Ajustes.Proveedor.Nombre);

                        grdAjustes.ActivarCelda(f, c + 2);
                    }
                    else
                    {
                        Mensaje("No se encontró la Proveedor " + a.ToString());
                        grdAjustes.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //ID_Productos
                    Ajustes.Producto.Id = Convert.ToInt32(a);
                    if (Ajustes.Producto.Existe() == true)
                    {
                        Ajustes.precios.Producto = Ajustes.Producto;

                        Ajustes.Descripcion = Ajustes.Producto.Nombre;

                        grdAjustes.set_Texto(f, c, a);
                        grdAjustes.set_Texto(f, c + 1, Ajustes.Producto.Nombre);

                        Ajustes.Costo = Ajustes.precios.Buscar();
                        grdAjustes.set_Texto(f, c_Costo, Ajustes.Costo);
                        grdAjustes.set_Texto(f, c_Importe, Ajustes.Costo * Ajustes.Kilos);

                        if (id != 0) { Ajustes.Actualizar(); }

                        grdAjustes.ActivarCelda(f, c_Kilos);
                        Importe();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdAjustes.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    Ajustes.Descripcion = a.ToString();
                    grdAjustes.set_Texto(f, c, a);

                    if (id != 0) { Ajustes.Actualizar(); }

                    grdAjustes.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo
                    Ajustes.Costo = Convert.ToSingle(a);
                    grdAjustes.set_Texto(f, c, a);
                    grdAjustes.set_Texto(f, c_Importe, Ajustes.Costo * Ajustes.Kilos);

                    if (id != 0) { Ajustes.Actualizar(); }

                    grdAjustes.ActivarCelda(f + 1, c);
                    Importe();
                    break;
                case 7:
                    //Kilos
                    Ajustes.Kilos = Convert.ToSingle(a);
                    grdAjustes.set_Texto(f, c, a);
                    grdAjustes.set_Texto(f, c_Importe, Ajustes.Costo * Ajustes.Kilos);

                    if (grdAjustes.Row == grdAjustes.Rows - 1)
                    {
                        Ajustes.Agregar();
                        grdAjustes.set_Texto(f, c_Id, Ajustes.Id);
                        grdAjustes.AgregarFila();
                        //Rellenar nueva fila

                        grdAjustes.set_Texto(f + 1, c_Fecha, Ajustes.Fecha);
                        grdAjustes.set_Texto(f + 1, c_IdProv, Ajustes.Proveedor.Id);
                        grdAjustes.set_Texto(f + 1, grdAjustes.get_ColIndex("Nombre"), Ajustes.Proveedor.Nombre);

                        Ajustes.Producto.Siguiente();
                        Ajustes.precios.Producto = Ajustes.Producto;

                        Ajustes.Descripcion = Ajustes.Producto.Nombre;

                        grdAjustes.set_Texto(f + 1, c_IdProd, Ajustes.Producto.Id);
                        grdAjustes.set_Texto(f + 1, c_Descripcion, Ajustes.Descripcion);

                        Ajustes.Costo = Ajustes.precios.Buscar();
                        grdAjustes.set_Texto(f + 1, c_Costo, Ajustes.Costo);
                        grdAjustes.set_Texto(f + 1, c_Importe, 0);

                        Ajustes.Kilos = 0;
                    }
                    else
                    {
                        Ajustes.Actualizar();
                    }
                    grdAjustes.ActivarCelda(f + 1, c);

                    Importe();
                    break;
            }

        }

        private void GrdAjustes_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdAjustes.get_Texto(Fila, c_Id).ToString());
            Ajustes.Cargar_Fila(i);
            Ajustes.precios.Fecha = Ajustes.Fecha;
            Ajustes.precios.Proveedor = Ajustes.Proveedor;
            Ajustes.precios.Producto = Ajustes.Producto;
        }

        private void GrdAjustes_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Ajustes.Id == 0)
                {

                    if (grdAjustes.Col == c_Kilos)
                    {
                        Ajustes.Producto.Siguiente();
                        Ajustes.precios.Producto = Ajustes.Producto;

                        Ajustes.Descripcion = Ajustes.Producto.Nombre;

                        grdAjustes.set_Texto(grdAjustes.Row, c_IdProd, Ajustes.Producto.Id);
                        grdAjustes.set_Texto(grdAjustes.Row, c_Descripcion, Ajustes.Descripcion);

                        Ajustes.Costo = Ajustes.precios.Buscar();
                        grdAjustes.set_Texto(grdAjustes.Row, c_Costo, Ajustes.Costo);
                        grdAjustes.set_Texto(grdAjustes.Row, c_Importe, 0);
                    }
                }
            }
        }

        private void GrdAjustes_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdAjustes.get_Texto(grdAjustes.Row, 0)) != 0)
                        {
                            Ajustes.Id = Convert.ToInt32(grdAjustes.get_Texto(grdAjustes.Row, 0));
                            Ajustes.Borrar();
                            grdAjustes.BorrarFila(grdAjustes.Row);
                            Importe();
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
            if (grdAjustes.Rows > 2)
            {
                //frmCMAjustes cm = new frmCMAjustes();
                //List<int> n = new List<int>();

                //int d = grdAjustes.Selection.r1;
                //int h = grdAjustes.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdAjustes.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdAjustes.get_Texto(i, c_Id)));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }
    }
}
