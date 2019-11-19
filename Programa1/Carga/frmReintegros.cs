

namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmReintegros : Form
    {
        private Reintegros Reintegros = new Reintegros();

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
            formato_Grilla();

            //El intercambio de columnas para estas teclas
            grdReintegros.AgregarTeclas(Convert.ToInt32(Keys.Subtract), grdReintegros.get_ColIndex("Id_Tipo"), grdReintegros.get_ColIndex("Importe"));
            grdReintegros.AgregarTeclas(Convert.ToInt32(Keys.Add), grdReintegros.get_ColIndex("Id_Sucursales"), grdReintegros.get_ColIndex("Importe"));

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
            grdReintegros.ActivarCelda(grdReintegros.Rows - 1, grdReintegros.get_ColIndex("Fecha"));
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
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Id"), 0);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Fecha"), 60);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Id_Sucursales"), 30);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Nombre"), 100);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Id_Tipo"), 30);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Descripcion"), 100);
            grdReintegros.set_ColW(grdReintegros.get_ColIndex("Importe"), 60);

            grdReintegros.Columnas[grdReintegros.get_ColIndex("Importe")].Format = "N2";

            grdReintegros.Columnas[grdReintegros.get_ColIndex("Importe")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdReintegros.set_Texto(0, grdReintegros.get_ColIndex("Id_Sucursales"), "Suc");
            grdReintegros.set_Texto(0, grdReintegros.get_ColIndex("Id_Tipo"), "Prod");
        }

        private void Totales()
        {
            double k = grdReintegros.SumarCol(grdReintegros.get_ColIndex("Importe"), false);
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
            int id = Convert.ToInt32(grdReintegros.get_Texto(f, grdReintegros.get_ColIndex("Id")));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    Reintegros.Fecha = Convert.ToDateTime(a);

                    if (id != 0) { Reintegros.Actualizar(); }

                    grdReintegros.set_Texto(f, c, a);
                    grdReintegros.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //ID_Sucursales
                    Reintegros.Sucursal.Id = Convert.ToInt32(a);
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
                    Reintegros.Tipo.Id = Convert.ToInt32(a);
                    if (Reintegros.Tipo.Existe() == true)
                    {
                        Reintegros.Descripcion = Reintegros.Tipo.Nombre;

                        grdReintegros.set_Texto(f, c, a);
                        grdReintegros.set_Texto(f, c + 1, Reintegros.Tipo.Nombre);

                        if (id != 0) { Reintegros.Actualizar(); }

                        grdReintegros.ActivarCelda(f, grdReintegros.get_ColIndex("Importe"));
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
                    grdReintegros.set_Texto(f, c, a);

                    if (grdReintegros.Row == grdReintegros.Rows - 1)
                    {
                        Reintegros.Agregar();
                        grdReintegros.set_Texto(f, grdReintegros.get_ColIndex("Id"), Reintegros.Id);
                        grdReintegros.AgregarFila();
                        //Rellenar nueva fila

                        grdReintegros.set_Texto(f + 1, grdReintegros.get_ColIndex("Fecha"), Reintegros.Fecha);
                        grdReintegros.set_Texto(f + 1, grdReintegros.get_ColIndex("Id_Sucursales"), Reintegros.Sucursal.Id);
                        grdReintegros.set_Texto(f + 1, grdReintegros.get_ColIndex("Nombre"), Reintegros.Sucursal.Nombre);

                        Reintegros.Descripcion = Reintegros.Tipo.Nombre;

                        grdReintegros.set_Texto(f + 1, grdReintegros.get_ColIndex("Id_Tipo"), Reintegros.Tipo.Id);
                        grdReintegros.set_Texto(f + 1, grdReintegros.get_ColIndex("Descripcion"), Reintegros.Descripcion);


                        Reintegros.Importe = 0;
                    }
                    else
                    {
                        Reintegros.Actualizar();
                    }
                    grdReintegros.ActivarCelda(f + 1, c);

                    Totales();
                    break;
            }

        }

        private void GrdReintegros_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdReintegros.get_Texto(Fila, grdReintegros.get_ColIndex("Id")).ToString());
            Reintegros.Cargar_Fila(i);
        }


        private void GrdReintegros_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grdReintegros.get_Texto(grdReintegros.Row, 0)) != 0)
                        {
                            Reintegros.Id = Convert.ToInt32(grdReintegros.get_Texto(grdReintegros.Row, 0));
                            Reintegros.Borrar();
                            grdReintegros.BorrarFila(grdReintegros.Row);
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


        private void LblTotal_Click(object sender, EventArgs e)
        {
            string s = lblTotal.Text.Substring(6);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void CmdCambioMasivo_Click(object sender, EventArgs e)
        {
            if (grdReintegros.Rows > 2)
            {
                //frmCMReintegros cm = new frmCMReintegros();
                //List<int> n = new List<int>();

                //int d = grdReintegros.Selection.r1;
                //int h = grdReintegros.Selection.r2;
                //if (d == -1)
                //{
                //    d = 1;
                //    h = grdReintegros.Rows - 2;
                //}
                //for (int i = d; i <= h; i++)
                //{
                //    n.Add(Convert.ToInt32(grdReintegros.get_Texto(i, grdReintegros.get_ColIndex("Id"))));
                //}
                //cm.Ids = n;
                //cm.ShowDialog();
                //cmdMostrar.PerformClick();
            }
        }
    }
}
