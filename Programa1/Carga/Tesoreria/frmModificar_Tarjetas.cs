namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmModificar_Tarjetas : Form
    {
        private Tarjetas tarjetas;
        private Herramientas.Herramientas h;
        private Usuarios usuario;

        public frmModificar_Tarjetas(Usuarios user)
        {
            usuario = user;

            InitializeComponent();
            tarjetas = new Tarjetas();
            h = new Herramientas.Herramientas();
        }

        private void frmModificar_Tarjetas_Load(object sender, EventArgs e)
        {
            h.Llenar_List(cmbSucO, tarjetas.sucdatos());
            h.Llenar_List(cmbSucD, tarjetas.sucdatos());
            h.Llenar_List(lstTipos_t, tarjetas.tipos_Tarjeta.Datos());
        }

        private void cmbSucO_SelectedIndexChanged(object sender, EventArgs e)
        {
            tarjetas.sucO = h.Codigo_Seleccionado(cmbSucO.Text);
            Cargar_grillas();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_grillas();
        }
        private void Cargar_grillas()
        {
            h.Llenar_List(lstLotes, tarjetas.datos_lotes(cFecha.Cadena()));
            string f = h.Unir(cFecha.Cadena(), $"Suc= {tarjetas.sucO}");
            if (lstTipos_t.SelectedIndex >= 0)
            {
                f = h.Unir(f, "Id_Tipo IN " + h.Codigos_Seleccionados(lstTipos_t));
            }
            DataTable dt = tarjetas.Datos_Vista(f);
            dt.Columns.Add("Cambio", typeof(bool));
            grdOrigen.MostrarDatos(dt, true, false);
            grdResumenOri.MostrarDatos(tarjetas.Datos_Resumen_modi_tar(f), true, false); 

            f = h.Unir(cFecha.Cadena(), $"Suc= {tarjetas.sucD}");
            if (lstTipos_t.SelectedIndex >= 0)
            { f = h.Unir(f, "Id_Tipo IN " + h.Codigos_Seleccionados(lstTipos_t)); }
            grd_Destino.MostrarDatos(tarjetas.Datos_Vista(f), true, false);
            
            grdResumenDest.MostrarDatos(tarjetas.Datos_Resumen_modi_tar(f), true, false);
            Formato_Grilla();
        }

        private void Formato_Grilla()
        {

            grdOrigen.AutosizeAll();
            grdOrigen.set_ColW(0, 0);
            if (grdOrigen.Rows > 1)
            {
                grdOrigen.Columnas[grdOrigen.get_ColIndex("Importe")].Style.Format = "#,###.#";
                grdOrigen.Columnas[grdOrigen.get_ColIndex("Importe")].Style.Font = new Font(grdOrigen.Font, FontStyle.Bold);
            }
            grdResumenOri.AutosizeAll();
            if (grdResumenOri.Rows > 1)
            {
                grdResumenOri.Columnas[grdResumenOri.get_ColIndex("Importe")].Style.Format = "#,###.#";
                grdResumenOri.Columnas[grdResumenOri.get_ColIndex("Importe")].Style.Font = new Font(grdResumenOri.Font, FontStyle.Bold);
            }

            grd_Destino.AutosizeAll();
            grd_Destino.set_ColW(0, 0);
            if (grd_Destino.Rows > 1)
            {
                grd_Destino.Columnas[grd_Destino.get_ColIndex("Importe")].Style.Format = "#,###.#";
                grd_Destino.Columnas[grd_Destino.get_ColIndex("Importe")].Style.Font = new Font(grd_Destino.Font, FontStyle.Bold);
            }
            grdResumenDest.AutosizeAll();
            if (grdResumenDest.Rows > 1)
            {
                grdResumenDest.Columnas[grdResumenDest.get_ColIndex("Importe")].Style.Format = "#,###.#";
                grdResumenDest.Columnas[grdResumenDest.get_ColIndex("Importe")].Style.Font = new Font(grdResumenDest.Font, FontStyle.Bold);
            }
        }

        private void lstTipos_t_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_grillas();
        }

        private void lstLotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_cambio = grdOrigen.get_ColIndex("Cambio");
            int c_Lote = grdOrigen.get_ColIndex("Lote");
            int lote;

            for (int i = 1; i <= grdOrigen.Rows - 1; i++)
            { grdOrigen.set_Texto(i, c_cambio, 0); }

            foreach (string item in lstLotes.SelectedItems)
            {
                lote = Convert.ToInt32(item);
                for (int i = 1; i <= grdOrigen.Rows - 1; i++)
                {
                    if (Convert.ToInt32(grdOrigen.get_Texto(i, c_Lote)) == lote)
                    { grdOrigen.set_Texto(i, c_cambio, 1); }
                }
            }
        }

        private void cmbSucD_SelectedIndexChanged(object sender, EventArgs e)
        {
            tarjetas.sucD = h.Codigo_Seleccionado(cmbSucD.Text);
            Cargar_grillas();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (tarjetas.sucD > 0)
            {
                int c_cambio = grdOrigen.get_ColIndex("Cambio");
                string cambios = "";
                for (int i = 1; i <= grdOrigen.Rows - 1; i++)
                {
                    if (Convert.ToBoolean(grdOrigen.get_Texto(i, c_cambio)) == true)
                    {
                        tarjetas.ID = Convert.ToInt32(grdOrigen.get_Texto(i, 0));
                        cambios = $"{cambios} {tarjetas.ID},";
                        tarjetas.Actualizar();
                    }
                }
                //cambios = cambios.Substring(0, cambios.Length - 1);
                //tarjetas.Backup_cambios(cambios, usuario.ID);
                Cargar_grillas();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sucursal de Destino para modificar los registros", "Seleccione una Sucursal");
            }
        }

        private void txtvalor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }
        }

        private void txtvalor_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (txtvalor.Text.Length > 0))
            {
                int c_cambio = grdOrigen.get_ColIndex("Cambio");
                int c_importe = grdOrigen.get_ColIndex("Importe");
                double importe = Convert.ToDouble (txtvalor.Text);
                int fo = grdOrigen.Row;
                if (fo == grdOrigen.Rows || fo == -1) { fo = 0; }
                for (int f = fo + 1; f != fo; f++)
                {
                    if (Convert.ToDouble(grdOrigen.get_Texto(f, c_importe)) == importe && Convert.ToBoolean(grdOrigen.get_Texto(f, c_cambio)) == false)
                    {
                        grdOrigen.set_Texto(f, c_cambio, 1);
                        grdOrigen.ActivarCelda(f, c_cambio);
                        txtvalor.Text = "";
                        f = fo-1;
                    }
                    else if (f >= grdOrigen.Rows - 1)
                    { 
                        f = 0;
                        if (fo == 0) { f = -1; }
                    }
                    //else if (f == fo - 1)
                    //{ txtvalor.Text = ""; }
                }
            }
        }

        private void lstTipos_t_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lstTipos_t.SelectedIndexChanged -= lstTipos_t_SelectedIndexChanged;

                for (int i = 0; i < lstTipos_t.Items.Count; i++)
                {
                    if (lstTipos_t.GetSelected(i) == true)
                    { lstTipos_t.SetSelected(i, false); }
                    else { lstTipos_t.SetSelected(i, true); }
                    if (i == lstTipos_t.Items.Count - 2)
                    { lstTipos_t.SelectedIndexChanged += lstTipos_t_SelectedIndexChanged; }
                }

            }
            else if (e.Button == MouseButtons.Middle)
            {
                lstTipos_t.SelectedIndexChanged -= lstTipos_t_SelectedIndexChanged;
               
                for (int i = 0; i < lstTipos_t.Items.Count; i++)
                {
                    lstTipos_t.SetSelected(i, false);
                    if (i == lstTipos_t.Items.Count - 2)
                    { lstTipos_t.SelectedIndexChanged += lstTipos_t_SelectedIndexChanged; }
                }
            }
        }

        private void cmdInvertir_Click(object sender, EventArgs e)
        {
            string suc_1 = cmbSucO.Text;
            string suc_2 = cmbSucD.Text;

            cmbSucO.Text = suc_2;
            cmbSucD.Text = suc_1;

            if (h.Codigo_Seleccionado(suc_1) == 0)
            { tarjetas.sucD = 0; }
            else if (h.Codigo_Seleccionado(suc_2) == 0)
            { tarjetas.sucO = 0; }

            Cargar_grillas();
        }

        private void cmdRevertir_Click(object sender, EventArgs e)
        {
            tarjetas.Revertir_cambios(usuario.ID);
            Cargar_grillas();
        }
    }
}