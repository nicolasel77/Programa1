using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Proveedores
{
    public partial class frmPrecios_Proveedores : Form
    {
        readonly Precios_Proveedores Precios = new Precios_Proveedores();
        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmPrecios_Proveedores()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grd.TeclasManejadas = n;
            Cargar();
            grd.AgregarTeclas(Convert.ToInt32(Keys.Subtract), grd.get_ColIndex("ID_Productos"), grd.get_ColIndex("Precio"));
            grd.AgregarTeclas(Convert.ToInt32(Keys.Add), grd.get_ColIndex("ID_Proveedores"), grd.get_ColIndex("Precio"));

        }


        private void Cargar()
        {
            grd.Rows = 1;
            if (lstFechas.SelectedIndex >= 0)
            {
                string f = $"Fecha='{Convert.ToDateTime(lstFechas.Text):MM/dd/yy}'";
                f = h.Unir(f, cProveedores1.Cadena("ID_Proveedores"));
                grd.MostrarDatos(Precios.Datos(f), true, true);
            }
            else
            {
                grd.MostrarDatos(Precios.Datos("Fecha='1/1/1900'"), true, true);
                grd.Rows = 2;
            }
            grd.AutosizeAll();
            grd.set_ColW(0, 0);
            grd.set_ColW(grd.get_ColIndex("ID_Tipo"), 0);

        }

        private void cProveedores1_Cambio_Seleccion(object sender, EventArgs e)
        {
            lstFechas.Items.Clear();
            Precios.Proveedor.Id = cProveedores1.Valor_Actual;
            DataTable dt = Precios.Fechas();
            foreach (DataRow dr in dt.Rows)
            {
                lstFechas.Items.Add(dr[0]);
            }
            Cargar();

        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c == grd.get_ColIndex("Fecha"))
            {
                grd.set_Texto(f, c, a);
                Precios.Fecha = Convert.ToDateTime(a);
                if (f < grd.Rows - 1)
                {
                    Precios.Actualizar();
                }
                grd.ActivarCelda(f, grd.get_ColIndex("ID_Proveedores"));
            }
            else
            {
                if (c == grd.get_ColIndex("ID_Proveedores"))
                {
                    Precios.Proveedor.Id = Convert.ToInt32(a);
                    if (Precios.Proveedor.Existe() == true)
                    {
                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, c + 1, Precios.Proveedor.Nombre);
                        if (f < grd.Rows - 1)
                        {
                            Precios.Actualizar();
                        }
                        grd.ActivarCelda(f, grd.get_ColIndex("ID_Productos"));
                    }
                }
                else
                {
                    if (c == grd.get_ColIndex("ID_Productos"))
                    {
                        Precios.Producto.ID = Convert.ToInt32(a);
                        if (Precios.Producto.Existe() == true)
                        {
                            grd.set_Texto(f, c, a);
                            grd.set_Texto(f, c + 1, Precios.Producto.Nombre);
                            if (f < grd.Rows - 1)
                            {
                                Precios.Actualizar();
                            }
                            grd.ActivarCelda(f, grd.get_ColIndex("Precio"));
                        }
                    }
                    else
                    {
                        if (c == grd.get_ColIndex("Precio"))
                        {
                            grd.set_Texto(f, c, a);
                            Precios.Precio = Convert.ToSingle(a);
                            if (f == grd.Rows - 1)
                            {
                                Precios.Agregar();

                                grd.set_Texto(f, grd.get_ColIndex("ID"), Precios.Id);

                                grd.AgregarFila();

                                Precios.Producto.Siguiente();

                                grd.set_Texto(f + 1, grd.get_ColIndex("Fecha"), Precios.Fecha);
                                grd.set_Texto(f + 1, grd.get_ColIndex("ID_Proveedores"), Precios.Proveedor.Id);
                                grd.set_Texto(f + 1, grd.get_ColIndex("ID_Proveedores") + 1, Precios.Proveedor.Nombre);
                                grd.set_Texto(f + 1, grd.get_ColIndex("ID_Productos"), Precios.Producto.ID);
                                grd.set_Texto(f + 1, grd.get_ColIndex("ID_Productos") + 1, Precios.Producto.Nombre);

                            }
                            else
                            {
                                Precios.Actualizar();
                            } 
                        }

                        grd.ActivarCelda(f + 1, c);

                    }
                }
            }


        }

        private void grd_CambioFila(short Fila)
        {
            Precios.Id = Convert.ToInt32(grd.get_Texto(Fila, grd.get_ColIndex("ID")));
            Precios.Fecha = Convert.ToDateTime(grd.get_Texto(Fila, grd.get_ColIndex("Fecha")));
            Precios.Proveedor.Id = Convert.ToInt32(grd.get_Texto(Fila, grd.get_ColIndex("ID_Proveedores")));
            Precios.Producto.ID = Convert.ToInt32(grd.get_Texto(Fila, grd.get_ColIndex("ID_Productos")));
            Precios.Precio = Convert.ToSingle(grd.get_Texto(Fila, grd.get_ColIndex("Precio")));

        }
    }
}
