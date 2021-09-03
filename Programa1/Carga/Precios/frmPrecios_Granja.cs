using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmPrecios_Granja : Form
    {

        Precios_Sucursales precios;
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmPrecios_Granja()
        {
            InitializeComponent();
            precios = new Precios_Sucursales();
        }

        private void FrmPrecios_Granja_Load(object sender, EventArgs e)
        {
            Cargar_Lista();

            foreach (DataRow dr in precios.Fechas_Granja().Rows)
            {
                lstFechas.Items.Add($"{dr[0]:dd/MM/yy}  {dr[1]:N0}");
            }
        }

        private void Cargar_Lista()
        {
            DataTable dt = precios.Tabla_Precios("Id_Tipo IN (4,6)");


            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(0, 60);
            grd.set_ColW(1, 300);
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void Cargar_Precios()
        {
            this.Cursor = Cursors.WaitCursor;
            if (lstFechas.SelectedIndex > -1)
            {
                precios.Fecha = Convert.ToDateTime(lstFechas.Text.Substring(0, 8));
            }
            else
            {
                //precios.Fecha = null;
            }

            precios.Sucursal.ID = Suc.Valor_Actual;


            DataTable dt = precios.Precios("Id_Tipo IN (4,6)");


            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(0, 60);
            grd.set_ColW(1, 300);
            grd.Columnas[2].Format = "N3";
            this.Cursor = Cursors.Default;
        }

        private void Suc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            int suc = Suc.Valor_Actual;
            string fecha = lstFechas.Text.Substring(0, 8);
            DateTime f;

            if (suc != 0 & DateTime.TryParse(fecha, out f) == true)
            {

                if (MessageBox.Show("¿Esta seguro de borrar la lista?"
                        , "Borrar lista"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    precios.Fecha = f;
                    precios.Sucursal.ID = suc;
                    precios.Borrar_Lista(4);
                    precios.Borrar_Lista(6);
                    foreach (DataRow dr in precios.Fechas_Granja().Rows)
                    {
                        lstFechas.Items.Add($"{dr[0]:dd/MM/yy}  {dr[1]:N0}");
                    }
                    Cargar_Precios();
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir_MenEmb fr = new frmImprimir_MenEmb();
            fr.Tipo = 4;
            fr.ShowDialog();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            frmGuardar_Varios fr = new frmGuardar_Varios();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Guardar == true)
            {
                Cursor = Cursors.WaitCursor;

                precios.Fecha = fr.mntFecha.SelectionStart.Date;

                foreach (string suc in fr.lstSucursales.SelectedItems)
                {
                    //Guardar todo por cada Sucursal                    
                    Guardar(suc);
                }
                
                lstFechas.Items.Clear();
                foreach (DataRow dr in precios.Fechas_Granja().Rows)
                {
                    lstFechas.Items.Add($"{dr[0]:dd/MM/yy}  {dr[1]:N0}");
                }
                Cursor = Cursors.Default;
            }
        }

        private void Guardar(string suc)
        {
            precios.Sucursal.ID = h.Codigo_Seleccionado(suc);

            //Guardar la Lista
            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                int prod = Convert.ToInt32(grd.get_Texto(i, grd.get_ColIndex("Id")));

                if (prod != 0)
                {
                    precios.Producto.ID = prod;
                    precios.Precio = Convert.ToSingle(grd.get_Texto(i, grd.get_ColIndex("Precio")));
                    if (precios.Precio != 0 | chValoresCero.Checked == true)
                    {
                        precios.Agregar(); 
                    }
                }
            }
        }

        private void grd_Editado(short f, short c, object a)
        {
            int cPr = grd.get_ColIndex("Precio");
            if (c == cPr)
            {
                grd.set_Texto(f, c, Convert.ToSingle(a));
                grd.ActivarCelda(f + 1, c);
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            Cargar_Lista();
        }
    }
}
