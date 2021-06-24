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
            c_IdProv = Convert.ToByte(grdAjustes.get_ColIndex("Id_Proveedor"));
            c_Descripcion = Convert.ToByte(grdAjustes.get_ColIndex("Descripcion"));
            c_Importe = Convert.ToByte(grdAjustes.get_ColIndex("Importe"));

            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdAjustes.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_Fecha, c_Importe);
            grdAjustes.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Importe);

            Total();
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

            grdAjustes.Columnas[c_Importe].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdAjustes.set_Texto(0, c_IdProv, "Prov");
        }

        private void Total()
        {
            double t = grdAjustes.SumarCol(c_Importe, false);
            lblTotal.Text = $"Importe: {t:C2}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdAjustes.Rows = 1;
            grdAjustes.Rows = 2;
            Total();
        }

        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void cFecha_Cambio_Seleccion_1(object sender, EventArgs e)
        {
            string vFecha = cFecha.Cadena();
            cProvs.Filtro_In = $" (SELECT DISTINCT Id_Proveedor FROM Ajustes WHERE {vFecha})";
            cmdMostrar.PerformClick();
        }

        private void grdAjustes_Editado_1(short f, short c, object a)
        {
            if (Ajustes.Fecha_Cerrada(Ajustes.Fecha) == false)
            {
                int id = Convert.ToInt32(grdAjustes.get_Texto(f, c_Id));
                switch (c)
                {
                    case 1:
                        //Fecha
                        DateTime df = Convert.ToDateTime(a);
                        if (df >= cFecha.fecha_Actual)
                        {
                            if (Ajustes.Fecha_Cerrada(df) == false)
                            {
                                Ajustes.Fecha = df;

                                if (id != 0) { Ajustes.Actualizar(); }

                                grdAjustes.set_Texto(f, c, a);
                                grdAjustes.ActivarCelda(f, c + 1);
                            }
                            else
                            {
                                Mensaje("La fecha esta cerrada.");
                            }
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
                        //Descripcion
                        Ajustes.Descripcion = a.ToString();
                        grdAjustes.set_Texto(f, c, a);

                        if (id != 0) { Ajustes.Actualizar(); }

                        grdAjustes.ActivarCelda(f, c_Importe);

                        break;

                    case 5:
                        //Importe
                        Ajustes.Importe = Convert.ToDouble(a);
                        grdAjustes.set_Texto(f, c, a);


                        if (grdAjustes.Row == grdAjustes.Rows - 1)
                        {
                            Ajustes.Agregar();
                            grdAjustes.set_Texto(f, c_Id, Ajustes.ID);
                            grdAjustes.AgregarFila();

                            Ajustes.Importe = 0;
                        }
                        else
                        {
                            Ajustes.Actualizar();
                        }
                        grdAjustes.ActivarCelda(f + 1, c);
                        Total();
                        break;
                }
            }
            else
            {
                Mensaje("La fecha esta cerrada.");
            }
        }

        private void grdAjustes_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdAjustes.get_Texto(grdAjustes.Row, 0)) != 0)
                    {
                        if (Ajustes.Fecha_Cerrada(Ajustes.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Ajustes.ID = Convert.ToInt32(grdAjustes.get_Texto(grdAjustes.Row, 0));
                                Ajustes.Borrar();
                                grdAjustes.BorrarFila(grdAjustes.Row);
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

        private void cmdMostrar_Click_1(object sender, EventArgs e)
        {
            grdAjustes.MostrarDatos(Ajustes.Datos(Armar_Cadena()), true);
            formato_Grilla();
            Total();
        }
    }
}
