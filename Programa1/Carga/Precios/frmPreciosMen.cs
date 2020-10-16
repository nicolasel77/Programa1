
namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmPreciosMen : Form
    {
        Precios_Sucursales precios;
        Herramientas h = new Herramientas();

        private enum TOpcion : byte
            {
                Menudencias = 2,
                Embutidos = 3
            }
        TOpcion Opcion = TOpcion.Menudencias;

        public frmPreciosMen()
        {
            InitializeComponent();
            precios = new Precios_Sucursales();
        }

        private void FrmPreciosMen_Load(object sender, EventArgs e)
        {
            Cargar_Lista();

            h.Llenar_List(lstFechas, precios.Fechas(Convert.ToByte(Opcion)), "dd/MM/yyyy");
        }

        private void Cargar_Lista()
        {
            DataTable dt = precios.Tabla_Precios(Convert.ToInt32(Opcion));


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
                precios.Fecha = Convert.ToDateTime(lstFechas.Text);
            }
            else
            {
                //precios.Fecha = null;
            }

            precios.Sucursal.Id = Suc.Valor_Actual;


            DataTable dt = precios.Precios(Convert.ToByte(Opcion));


            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(0, 60);
            grd.set_ColW(1, 300);
            this.Cursor = Cursors.Default;
        }

        private void Suc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            int suc = Suc.Valor_Actual;
            string fecha = lstFechas.Text;
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
                    precios.Sucursal.Id = suc;
                    precios.Borrar_Lista(2);
                    h.Llenar_List(lstFechas, precios.Fechas(2), "dd/MM/yyyy");
                    Cargar_Precios();
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir_MenEmb fr = new frmImprimir_MenEmb();
            fr.Tipo = Convert.ToInt32(Opcion);
            fr.ShowDialog();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            frmGuardar_Varios fr = new frmGuardar_Varios();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Guardar == true)
            {
                this.Cursor = Cursors.WaitCursor;

                precios.Fecha = fr.mntFecha.SelectionStart.Date;

                foreach (string suc in fr.lstSucursales.SelectedItems)
                {
                    //Guardar todo por cada Sucursal
                    Herramientas h = new Herramientas();

                    precios.Sucursal.Id = h.Codigo_Seleccionado(suc);
                    
                    //Guardar la Lista
                    for (int i = 1; i <= grd.Rows - 1; i++)
                    {
                        int prod = Convert.ToInt32((grd.get_Texto(i, grd.get_ColIndex("Id"))));

                        if (prod != 0)
                        {
                            precios.Producto.Id = prod;
                            precios.Precio = Convert.ToSingle((grd.get_Texto(i, grd.get_ColIndex("Precio"))));
                            precios.Agregar();
                        }
                    }
                }
                h.Llenar_List(lstFechas, precios.Fechas(Convert.ToByte(Opcion)), "dd/MM/yyyy");

                this.Cursor = Cursors.Default;
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

        private void rdMenudencias_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMenudencias.Checked == true)
            {
                Opcion = TOpcion.Menudencias;
            }
            else
            {
                Opcion = TOpcion.Embutidos; 
            }
            if (Suc.Valor_Actual > 0)
            {
                Cargar_Precios();
            }
            else
            {
                Cargar_Lista();
            }
            h.Llenar_List(lstFechas, precios.Fechas(Convert.ToByte(Opcion)), "dd/MM/yyyy");
        }       
       
    }
}
