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
            int c_Id = grdTarjetas.get_ColIndex("Id");
            if (c_Id == -1) { return; } // Agrupado: no se edita

            int id = Convert.ToInt32(grdTarjetas.get_Texto(f, c_Id));
            if (id == 0) { return; }
            entregas.ID = id;

            if (c == grdTarjetas.get_ColIndex("Fecha"))
            {
                DateTime df;
                if (a == null || !DateTime.TryParse(a.ToString(), out df))
                {
                    MessageBox.Show("La fecha no es válida.", "Entregas");
                    return;
                }
                entregas.Actualizar("Fecha", df.Date);
                grdTarjetas.set_Texto(f, c, df.Date);
            }
            else if (c == grdTarjetas.get_ColIndex("Suc"))
            {
                int suc = Convert.ToInt32(a);
                Programa1.DB.Sucursales.Sucursales suc_db = new Programa1.DB.Sucursales.Sucursales();
                if (suc_db.Existe(suc))
                {
                    entregas.Actualizar("Suc", suc);
                    grdTarjetas.set_Texto(f, c, suc);
                    grdTarjetas.set_Texto(f, grdTarjetas.get_ColIndex("Nombre"), suc_db.Nombre);
                }
                else
                {
                    MessageBox.Show($"No se encontró la sucursal {a}.", "Entregas");
                    grdTarjetas.ErrorEnTxt();
                }
            }
            else if (c == grdTarjetas.get_ColIndex("Tipo"))
            {
                int tipo = Convert.ToInt32(a);
                if (t_entregas.Existe(tipo))
                {
                    entregas.Actualizar("Tipo", tipo);
                    grdTarjetas.set_Texto(f, c, tipo);
                    grdTarjetas.set_Texto(f, grdTarjetas.get_ColIndex("Descripcion"), entregas.Descripcion_Tipo(id));
                }
                else
                {
                    MessageBox.Show($"No se encontró el tipo {a}.", "Entregas");
                    grdTarjetas.ErrorEnTxt();
                }
            }
            else if (c == grdTarjetas.get_ColIndex("Importe"))
            {
                double imp = Convert.ToDouble(a);
                entregas.Actualizar("Importe", imp);
                grdTarjetas.set_Texto(f, c, imp);
                lblTotal.Text = grdTarjetas.SumarCol(c, false).ToString("C1");
            }
        }

        private void grdTarjetas_KeyUp(object sender, short e)
        {
            if (Convert.ToInt32(e) != 46) { return; } // Delete

            int c_Id = grdTarjetas.get_ColIndex("Id");
            if (c_Id == -1 || grdTarjetas.Row < 1) { return; }

            int id = Convert.ToInt32(grdTarjetas.get_Texto(grdTarjetas.Row, c_Id));
            if (id == 0) { return; }

            if (MessageBox.Show("¿Esta segura/o de borrar la entrega?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                entregas.ID = id;
                entregas.Borrar();
                grdTarjetas.BorrarFila(grdTarjetas.Row);
                int c_imp = grdTarjetas.get_ColIndex("Importe");
                if (c_imp > 0) { lblTotal.Text = grdTarjetas.SumarCol(c_imp, false).ToString("C1"); }
            }
        }
    }
}
