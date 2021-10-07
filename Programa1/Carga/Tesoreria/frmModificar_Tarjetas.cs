namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmModificar_Tarjetas : Form
    {
        private Tarjetas tarjetas;
        private Herramientas.Herramientas h;

        public frmModificar_Tarjetas()
        {
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
            Cargar_grdori();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_grdori();
            Cargar_grdD();
        }

        private void Cargar_grdori()
        {
            if (cFecha.fecha_Fin > Convert.ToDateTime("1/1/1910"))
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
                if (cmbSucO.Text.Length > 0)
                { grdResumenOri.MostrarDatos(tarjetas.Datos_Resumen_modi_tar(f), true, false); }
                Formato_Grilla();
            }
        }

        private void Cargar_grdD()
        {
            if (cFecha.fecha_Fin > Convert.ToDateTime("1/1/1910"))
            {
                string f = h.Unir(cFecha.Cadena(), $"Suc= {tarjetas.sucD}");
                if (lstTipos_t.SelectedIndex >= 0)
                { f = h.Unir(f, "Id_Tipo IN " + h.Codigos_Seleccionados(lstTipos_t)); }
                grd_Destino.MostrarDatos(tarjetas.Datos_Vista(f), true, false);
                if (cmbSucD.Text.Length > 0)
                { grdResumenDest.MostrarDatos(tarjetas.Datos_Resumen_modi_tar(f), true, false); }
                Formato_Grilla();
            }
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
            Cargar_grdori();
            Cargar_grdD();
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
            Cargar_grdD();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (tarjetas.sucD > 0)
            {
                int c_cambio = grdOrigen.get_ColIndex("Cambio");
                for (int i = 1; i <= grdOrigen.Rows - 1; i++)
                {
                    if (Convert.ToBoolean(grdOrigen.get_Texto(i, c_cambio)) == true)
                    {
                        tarjetas.ID = Convert.ToInt32(grdOrigen.get_Texto(i, 0));
                        tarjetas.Actualizar();
                    }
                }
                Cargar_grdori();
                Cargar_grdD();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Sucursal de Destino para modificar los registros", "Seleccione una Sucursal");
            }
        }
    }
}
