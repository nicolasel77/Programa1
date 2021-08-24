namespace Programa1.Carga.Tesoreria
{
    using Herramientas;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;
    public partial class frmTarjetas : Form
    {
        public Tarjetas tarjetas = new Tarjetas();
        public Tipos_Tarjeta t_tarjetas = new Tipos_Tarjeta();

        public frmTarjetas()
        {
            InitializeComponent();
        }

        private void frmTarjetas_Load(object sender, EventArgs e)
        {
            Herramientas h = new Herramientas();
            h.Llenar_List(lstTipos, t_tarjetas.Datos());

            //Esto es para que la primera vez que se filtre no tire filas vacias
            chTipo.Checked = true;
        }

        private void Cargar()
        {
            grdTarjetas.MostrarDatos(tarjetas.Datos_Resumen(), true, false);
            if (grdTarjetas.Rows > 0)
            {
                int c_imp = grdTarjetas.get_ColIndex("Importe");
                if (c_imp > 0)
                {
                    if (grdTarjetas.Cols > 0) { grdTarjetas.Columnas[c_imp].Style.Format = "N2"; }
                    grdTarjetas.AgregarFila();
                    grdTarjetas.set_Texto(grdTarjetas.Rows - 1, grdTarjetas.get_ColIndex("Importe") - 1, "Total:");
                    lblTotal.Text = grdTarjetas.SumarCol(grdTarjetas.get_ColIndex("Importe")).ToString("C1");
                    grdTarjetas.AutosizeAll();
                }
            }
        }
        private void cargarfiltros()
        {
            Herramientas h = new Herramientas();
            tarjetas.Fecha = cFecha.Cadena();
            tarjetas.sucs = cSuc.Cadena("Suc");
            tarjetas.Tipos = h.Codigos_Seleccionados(lstTipos);
            tarjetas.Agrupar = Convert.ToBoolean(chAgrupar.CheckState);
            tarjetas.aSucs = Convert.ToBoolean(chSuc.CheckState);
            tarjetas.aFecha = Convert.ToBoolean(chFecha.CheckState);
            tarjetas.aTipo = Convert.ToBoolean(chTipo.CheckState);
            tarjetas.aAcreditados = Convert.ToBoolean(chAcreditados.CheckState);
            tarjetas.OrdenxSuc = rdOrdenPorSuc.Checked;
            Cargar();
        }

        private void chAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            if (chAgrupar.Checked == false)
            {
                chFecha.Enabled = false;
                chSuc.Enabled = false;
                chTipo.Enabled = false;
            }
            else
            {
                chFecha.Enabled = true;
                chSuc.Enabled = true;
                chTipo.Enabled = true;
            }
            cargarfiltros();
        }

        private void chSuc_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chFecha_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chTipo_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void cSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chAcreditados_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void rdOrdenPorSuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOrdenPorSuc.Checked == true) { rdOrdenxFecha.Checked = false; }
            cargarfiltros();
        }

        private void lstTipos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) { lstTipos.SelectedIndex = -1; }
        }

        private void rdOrdenxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOrdenxFecha.Checked == true) { rdOrdenPorSuc.Checked = false; }
        }

        private void grdTarjetas_Load(object sender, EventArgs e)
        {
            grdTarjetas.BorrarFila();
        }
    }
}
