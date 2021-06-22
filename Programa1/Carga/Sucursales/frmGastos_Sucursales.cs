namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmGastos_Sucursales : Form
    {
        private Gastos_Sucursales Gastos_Sucursales = new Gastos_Sucursales();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdTipo;
        private Byte c_Descripcion;
        private Byte c_Importe;

        #endregion
        public frmGastos_Sucursales()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdGastos.TeclasManejadas = n;

            Gastos_Sucursales = new Gastos_Sucursales();
            grdGastos.MostrarDatos(Gastos_Sucursales.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdGastos.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdGastos.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdGastos.get_ColIndex("Id_Sucursales"));
            c_IdTipo = Convert.ToByte(grdGastos.get_ColIndex("Id_Tipo"));
            c_Descripcion = Convert.ToByte(grdGastos.get_ColIndex("Descripcion"));
            c_Importe = Convert.ToByte(grdGastos.get_ColIndex("Importe"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdGastos.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdTipo, c_Importe);
            grdGastos.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdSuc, c_Importe);

            Totales();
        }

        private void frmGastos_Sucursales_KeyUp(object sender, KeyEventArgs e)
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
                            cTipos.Siguiente();
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
                            cTipos.Anterior();
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
            grdGastos.MostrarDatos(Gastos_Sucursales.Datos(s), true);
            formato_Grilla();
            Totales();
            grdGastos.ActivarCelda(grdGastos.Rows - 1, c_Fecha);
            grdGastos.Focus();

            if (grdGastos.Rows == 2)
            {
                cSucs.Filtro_In = "";
                cTipos.Filtro_In = "";
            }
            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = "";

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            string t = cTipos.Cadena("Id_Tipo");
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            s = h.Unir(f, s);
            s = h.Unir(s, t);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdGastos.set_ColW(c_Id, 0);
            grdGastos.set_ColW(c_Fecha, 60);
            grdGastos.set_ColW(c_IdSuc, 30);
            grdGastos.set_ColW(c_IdSuc + 1, 100);
            grdGastos.set_ColW(c_IdTipo, 30);
            grdGastos.set_ColW(c_Descripcion, 350);
            grdGastos.set_ColW(c_Importe, 60);

            grdGastos.Columnas[c_Importe].Format = "N2";

            grdGastos.Columnas[c_Importe].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdGastos.set_Texto(0, c_IdSuc, "Suc");
            grdGastos.set_Texto(0, c_IdTipo, "Tipo");
        }

        private void Totales()
        {
            double k = grdGastos.SumarCol(c_Importe, false);
            int c = grdGastos.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblTotal.Text = $"Total: {k:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdGastos.Rows = 1;
            grdGastos.Rows = 2;
            Totales();
        }


        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Gastos_Sucursales WHERE {cFecha.Cadena()})";
            cTipos.Filtro_In = $" (SELECT DISTINCT Id_Tipo FROM Gastos_Sucursales WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }


        private void grdGastos_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32(grdGastos.get_Texto(f, c_Id));
            if (Gastos_Sucursales.Fecha_Cerrada(Gastos_Sucursales.Fecha) == false)
            {
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (Gastos_Sucursales.Fecha_Cerrada(df) == false)
                            {
                                Gastos_Sucursales.Fecha = df;

                                if (id != 0) { Gastos_Sucursales.Actualizar(); }

                                grdGastos.set_Texto(f, c, a);
                                grdGastos.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha ingresada se encuentra cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                            grdGastos.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //ID_Sucursales
                        Gastos_Sucursales.Sucursal.ID = Convert.ToInt32(a);
                        if (Gastos_Sucursales.Sucursal.Existe() == true)
                        {
                            if (id != 0) { Gastos_Sucursales.Actualizar(); }

                            grdGastos.set_Texto(f, c, a);
                            grdGastos.set_Texto(f, c + 1, Gastos_Sucursales.Sucursal.Nombre);

                            grdGastos.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdGastos.ErrorEnTxt();
                        }
                        break;
                    case 4:
                        //Id_Tipo
                        Gastos_Sucursales.Tipo.ID = Convert.ToInt32(a);
                        if (Gastos_Sucursales.Tipo.Existe() == true)
                        {
                            Gastos_Sucursales.Descripcion = Gastos_Sucursales.Tipo.Nombre;

                            grdGastos.set_Texto(f, c, a);
                            grdGastos.set_Texto(f, c + 1, Gastos_Sucursales.Tipo.Nombre);

                            if (id != 0) { Gastos_Sucursales.Actualizar(); }

                            grdGastos.ActivarCelda(f, c_Importe);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el Tipo " + a.ToString());
                            grdGastos.ErrorEnTxt();
                        }
                        break;
                    case 5:
                        //Descripcion
                        Gastos_Sucursales.Descripcion = a.ToString();
                        grdGastos.set_Texto(f, c, a);

                        if (id != 0) { Gastos_Sucursales.Actualizar(); }

                        grdGastos.ActivarCelda(f + 1, c);
                        break;
                    case 6:
                        //Importe
                        Gastos_Sucursales.Importe = Convert.ToSingle(a);
                        grdGastos.set_Texto(f, c, a);

                        if (grdGastos.Row == grdGastos.Rows - 1)
                        {
                            Gastos_Sucursales.Agregar();
                            grdGastos.set_Texto(f, c_Id, Gastos_Sucursales.ID);
                            grdGastos.AgregarFila();
                            //Rellenar nueva fila

                            grdGastos.set_Texto(f + 1, c_Fecha, Gastos_Sucursales.Fecha);
                            grdGastos.set_Texto(f + 1, c_IdSuc, Gastos_Sucursales.Sucursal.ID);
                            grdGastos.set_Texto(f + 1, c_IdSuc + 1, Gastos_Sucursales.Sucursal.Nombre);

                            Gastos_Sucursales.Importe = 0;
                            Gastos_Sucursales.ID = 0;
                            grdGastos.ActivarCelda(f + 1, c_IdTipo);
                        }
                        else
                        {
                            Gastos_Sucursales.Actualizar();
                            grdGastos.ActivarCelda(f + 1, c);
                        }

                        Totales();
                        break;
                } 
            }
            else
            {
                Mensaje("La fecha ingresada se encuentra cerrada.");
            }

        }

        private void grdGastos_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdGastos.get_Texto(Fila, c_Id));
            Gastos_Sucursales.Cargar_Fila(i);
        }


        private void grdGastos_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete

                    if (Convert.ToInt32(grdGastos.get_Texto(grdGastos.Row, 0)) != 0)
                    {
                        if (Gastos_Sucursales.Fecha_Cerrada(Gastos_Sucursales.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Gastos_Sucursales.ID = Convert.ToInt32(grdGastos.get_Texto(grdGastos.Row, 0));
                                Gastos_Sucursales.Borrar();
                                grdGastos.BorrarFila(grdGastos.Row);
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

    }
}
