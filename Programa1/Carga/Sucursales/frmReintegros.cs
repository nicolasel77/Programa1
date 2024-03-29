﻿namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmReintegros : Form
    {
        private Reintegros Reintegros = new Reintegros();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSuc;
        private Byte c_IdTipo;
        private Byte c_Descripcion;
        private Byte c_Importe;

        #endregion
        public frmReintegros()
        {
            InitializeComponent();

            DataTable dt = Reintegros.Tipo.Datos();

            foreach (DataRow dr in dt.Rows)
            {
                lstTipo.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdReintegros.TeclasManejadas = n;

            Reintegros = new Reintegros();
            grdReintegros.MostrarDatos(Reintegros.Datos("Id=0"), true);

            c_Id = Convert.ToByte(grdReintegros.get_ColIndex("Id"));
            c_Fecha = Convert.ToByte(grdReintegros.get_ColIndex("Fecha"));
            c_IdSuc = Convert.ToByte(grdReintegros.get_ColIndex("Id_Sucursales"));
            c_IdTipo = Convert.ToByte(grdReintegros.get_ColIndex("Id_Tipo"));
            c_Descripcion = Convert.ToByte(grdReintegros.get_ColIndex("Descripcion"));
            c_Importe = Convert.ToByte(grdReintegros.get_ColIndex("Importe"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdReintegros.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdTipo, c_Importe);
            grdReintegros.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdSuc, c_Importe);

            Totales();
        }

        private void FrmReintegros_KeyUp(object sender, KeyEventArgs e)
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
            grdReintegros.MostrarDatos(Reintegros.Datos(s), true);
            formato_Grilla();
            Totales();
            grdReintegros.ActivarCelda(grdReintegros.Rows - 1, c_Fecha);
            grdReintegros.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = "";

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            foreach (string li in lstTipo.SelectedItems)
            {
                p = h.Unir(p, h.Codigo_Seleccionado(li).ToString(), ", ");
            }
            if (p.Length > 0)
            {
                p = $" Id_Tipo IN ({p})";
            }
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdReintegros.set_ColW(c_Id, 0);
            grdReintegros.set_ColW(c_Fecha, 60);
            grdReintegros.set_ColW(c_IdSuc, 30);
            grdReintegros.set_ColW(c_IdSuc + 1, 200);
            grdReintegros.set_ColW(c_IdTipo, 30);
            grdReintegros.set_ColW(c_Descripcion, 200);
            grdReintegros.set_ColW(c_Importe, 60);

            grdReintegros.Columnas[c_Importe].Format = "N2";

            grdReintegros.Columnas[c_Importe].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdReintegros.set_Texto(0, c_IdSuc, "Suc");
            grdReintegros.set_Texto(0, c_IdTipo, "Tipo");
        }

        private void Totales()
        {
            double k = grdReintegros.SumarCol(c_Importe, false);
            int c = grdReintegros.Rows - 2;
            lblCant.Text = $"Registros: {c:N0}";
            lblTotal.Text = $"Total: {k:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdReintegros.Rows = 1;
            grdReintegros.Rows = 2;
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
            cSucs.Filtro_In = $" (SELECT DISTINCT Id_Sucursales FROM Reintegros WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }


        private void GrdReintegros_Editado(short f, short c, object a)
        {
            if (Reintegros.Fecha_Cerrada(Reintegros.Fecha) == false)
            {
                int id = Convert.ToInt32(grdReintegros.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (Reintegros.Fecha_Cerrada(df) == false)
                            {
                                Reintegros.Fecha = df;

                                if (id != 0) { Reintegros.Actualizar(); }

                                grdReintegros.set_Texto(f, c, a);
                                grdReintegros.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
                        }
                        else
                        {
                            Mensaje("La fecha debe ser mayor o igual que la seleccionada en el filtro.");
                            grdReintegros.ErrorEnTxt();
                        }
                        break;
                    case 2:
                        //ID_Sucursales
                        Reintegros.Sucursal.ID = Convert.ToInt32(a);
                        if (Reintegros.Sucursal.Existe() == true)
                        {
                            if (id != 0) { Reintegros.Actualizar(); }

                            grdReintegros.set_Texto(f, c, a);
                            grdReintegros.set_Texto(f, c + 1, Reintegros.Sucursal.Nombre);

                            grdReintegros.ActivarCelda(f, c + 2);
                        }
                        else
                        {
                            Mensaje("No se encontró la sucursal " + a.ToString());
                            grdReintegros.ErrorEnTxt();
                        }
                        break;
                    case 4:
                        //Id_Tipo
                        Reintegros.Tipo.ID = Convert.ToInt32(a);
                        if (Reintegros.Tipo.Existe() == true)
                        {
                            Reintegros.Descripcion = Reintegros.Tipo.Nombre;

                            grdReintegros.set_Texto(f, c, a);
                            grdReintegros.set_Texto(f, c + 1, Reintegros.Tipo.Nombre);

                            if (id != 0) { Reintegros.Actualizar(); }

                            grdReintegros.ActivarCelda(f, c_Importe);
                            Totales();
                        }
                        else
                        {
                            Mensaje("No se encontró el Tipo " + a.ToString());
                            grdReintegros.ErrorEnTxt();
                        }
                        break;
                    case 5:
                        //Descripcion
                        Reintegros.Descripcion = a.ToString();
                        grdReintegros.set_Texto(f, c, a);

                        if (id != 0) { Reintegros.Actualizar(); }

                        grdReintegros.ActivarCelda(f + 1, c);
                        break;
                    case 6:
                        //Importe
                        Reintegros.Importe = Convert.ToSingle(a);

                        if (chNegativo.Checked == true) { Reintegros.Importe = Reintegros.Importe * -1; }

                        grdReintegros.set_Texto(f, c, Reintegros.Importe);

                        if (grdReintegros.Row == grdReintegros.Rows - 1)
                        {
                            Reintegros.Agregar();
                            grdReintegros.set_Texto(f, c_Id, Reintegros.ID);
                            grdReintegros.AgregarFila();
                            //Rellenar nueva fila

                            Reintegros.Sucursal.Siguiente();

                            grdReintegros.set_Texto(f + 1, c_Fecha, Reintegros.Fecha);                                  
                            grdReintegros.set_Texto(f + 1, c_IdSuc, Reintegros.Sucursal.ID);
                            grdReintegros.set_Texto(f + 1, c_IdSuc + 1, Reintegros.Sucursal.Nombre);
                            grdReintegros.set_Texto(f + 1, c_IdTipo, Reintegros.Tipo.ID);
                            grdReintegros.set_Texto(f + 1, c_Descripcion, Reintegros.Tipo.Nombre);

                            Reintegros.Importe = 0;
                            Reintegros.ID = 0;
                            grdReintegros.ActivarCelda(f + 1, c_Importe);
                        }
                        else
                        {
                            Reintegros.Actualizar();
                            grdReintegros.ActivarCelda(f + 1, c);
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

        private void GrdReintegros_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdReintegros.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                Reintegros.Cargar_Fila(i);
            }
            else
            {
                Reintegros.Fecha = Convert.ToDateTime(grdReintegros.get_Texto(Fila, c_Fecha));
                Reintegros.Sucursal.ID = Convert.ToInt32(grdReintegros.get_Texto(Fila, c_IdSuc));
                Reintegros.Tipo.ID = Convert.ToInt32(grdReintegros.get_Texto(Fila, c_IdTipo));
                Reintegros.Descripcion = grdReintegros.get_Texto(Fila, c_Descripcion).ToString();
                Reintegros.Importe = Convert.ToDouble(grdReintegros.get_Texto(Fila, c_Importe));
            }
        }


        private void GrdReintegros_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdReintegros.get_Texto(grdReintegros.Row, 0)) != 0)
                    {
                        if (Reintegros.Fecha_Cerrada(Reintegros.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Reintegros.ID = Convert.ToInt32(grdReintegros.get_Texto(grdReintegros.Row, 0));
                                Reintegros.Borrar();
                                grdReintegros.BorrarFila(grdReintegros.Row);
                                GrdReintegros_CambioFila(Convert.ToByte(grdReintegros.Row));
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

        private void grdReintegros_SeleccionCambio(int FilaInicio, int FilaFin, int ColInicio, int ColFin)
        {
            if (FilaInicio == FilaFin)
            {
                Totales();
            }
            else
            {
                float t = 0;
                for (int i = FilaInicio; i <= FilaFin; i++)
                {
                    t += Convert.ToSingle(grdReintegros.get_Texto(i, c_Importe));
                }

                int c = FilaFin - FilaInicio + 1;
                lblCant.Text = $"Registros: {c:N0}";
                lblTotal.Text = $"Total: {t:C2}";
            }
        }
    }
}
