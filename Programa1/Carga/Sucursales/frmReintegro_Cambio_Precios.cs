namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmReintegro_Cambio_Precios : Form
    {
        Reintegro_Cambio_Precios rcp = new Reintegro_Cambio_Precios();
        DateTime fecha = DateTime.Today;

        public frmReintegro_Cambio_Precios()
        {
            InitializeComponent();

            DataTable dt = rcp.Datos(fecha, 99);
            grd.MostrarDatos(dt, true, false);
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                grd.Columnas[i].Format = "N1";
            }
            grd.Columnas[3].Format = "N0";
            grd.AutosizeAll();
        }

        private void mFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (fecha != mFecha.SelectionStart.Date)
            {
                fecha = mFecha.SelectionStart.Date;
                Cargar();
            }
        }

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            int prod = Productos.Valor_Actual;

            if (prod > 0)
            {
                float np = 0;
                if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    float.TryParse(txtPrecio.Text, out np);
                }

                DataTable dt = rcp.Datos(fecha, prod, np);
                grd.MostrarDatos(dt, true, false);
                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    grd.Columnas[i].Format = "N1";
                }
                grd.Columnas[3].Format = "N0";
                grd.AutosizeAll();
            }
            else
            {
                grd.Rows = 1;
            }
            Cursor = Cursors.Default;

        }

        private void Productos_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DB.Reintegros reintegros = new DB.Reintegros();

            for (int i = 1; i < grd.Rows; i++)
            {
                reintegros.Importe = Convert.ToDouble(grd.get_Texto(i, grd.get_ColIndex("Reintegro")));

                if (reintegros.Importe != 0)
                {
                    reintegros.Fecha = fecha;
                    reintegros.Sucursal.ID = Convert.ToInt32(grd.get_Texto(i, 0));
                    reintegros.Tipo.ID = 4;
                    reintegros.Descripcion = txtDescripcion.Text;

                    reintegros.Agregar();
                }
            }
            MessageBox.Show("Listo!");
            Cursor = Cursors.Default;
        }

        private void nuSemanas_ValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void grd_Editado(short f, short c, object a)
        {
            grd.set_Texto(f, c, a);
            Calcular_Fila(f);
        }

        private void Calcular_Fila(short f)
        {
            this.Cursor = Cursors.WaitCursor;
            double a;
            //"((Venta+Traslados_E-Traslados_S+Stock)-(Venta_Promedio / 8 * Dias)) * (Precio_Nuevo-Precio_Ant)"
            double venta = Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Venta")));
            venta += Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Traslados_E")));
            venta -= Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Traslados_S")));
            venta += Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Stock")));

            double venta_prom = Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Venta_Promedio")));
            venta_prom = venta_prom / 8 * (int)grd.get_Texto(f, grd.get_ColIndex("Dias"));

            double dif_precio = Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Precio_Nuevo")));
            dif_precio -= Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Precio_Ant")));

            a = (venta - venta_prom) * dif_precio;

            grd.set_Texto(f, grd.get_ColIndex("Reintegro"), a);
            this.Cursor = Cursors.Default;

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            tiCarga.Stop();
            tiCarga.Start();            
        }

        private void tiCarga_Tick(object sender, EventArgs e)
        {
            tiCarga.Stop();
            Cargar();
        }
    }
}
