namespace Programa1.Carga.Sucursales
{
    using Herramientas;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmEntregas : Form
    {
        public Entregas_Sucursales entregas = new Entregas_Sucursales();
        public Tipos_Tarjeta t_entregas = new Tipos_Tarjeta();
        public Cuentas cuentas = new Cuentas();

        public frmEntregas()
        {
            InitializeComponent();
        }

        private void frmEntregas_Load(object sender, EventArgs e)
        {
            Herramientas h = new Herramientas();
            h.Llenar_List(lstTipos, t_entregas.Datos());
            
            //Esto es para que la primera vez que se filtre no tire filas vacias
            chTipo.Checked = true;
            
        }

        private void Cargar()
        {
            grdTarjetas.MostrarDatos(entregas.Datos_Resumen(), true, false);
            if (grdTarjetas.Rows > 0)
            {
                int c_imp = grdTarjetas.get_ColIndex("Importe");
                if (c_imp > 0)
                {
                    if (grdTarjetas.Cols > 0) { grdTarjetas.Columnas[c_imp].Style.Format = "N2"; }

                    lblTotal.Text = grdTarjetas.SumarCol(grdTarjetas.get_ColIndex("Importe"), false).ToString("C1");
                    grdTarjetas.AutosizeAll();
                }
                if(!chAgrupar.Checked)
                {
                    grdTarjetas.Columnas[grdTarjetas.get_ColIndex("Id")].Visible = false;
                }
            }
        }
        private void cargarfiltros()
        {
            Herramientas h = new Herramientas();
            entregas.Fecha = cFecha.Cadena("CAST(Fecha AS DATE)");
            entregas.Sucs = cSuc.Cadena("Suc");
            entregas.Tipos = h.Codigos_Seleccionados(lstTipos);
            entregas.Agrupar = Convert.ToBoolean(chAgrupar.CheckState);
            entregas.aSucs = Convert.ToBoolean(chSuc.CheckState);
            entregas.aFecha = Convert.ToBoolean(chFecha.CheckState);
            entregas.aTipo = Convert.ToBoolean(chTipo.CheckState);            
            entregas.OrdenxSuc = rdOrdenPorSuc.Checked;
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

        private void grdTarjetas_Editado(short f, short c, object a)
        {
            if (grdTarjetas.get_ColIndex("Id") != -1)
            {
                entregas.ID = Convert.ToInt32(grdTarjetas.get_Texto(f, grdTarjetas.get_ColIndex("Id")));
                switch (c)
                {
                    case 1:
                        // fecha
                        entregas.Actualizar("Fecha", a);
                        grdTarjetas.set_Texto(f, c, a);
                        break;
                } 
            }
        }
    }
}
