using Programa1.DB;
using System;
using System.Windows.Forms;

namespace Programa1.Carga
{
    public partial class frmStock : Form
    {
        private Stock stock;
        private Precios_Sucursales precios;

        public frmStock()
        {
            InitializeComponent();

            precios = new Precios_Sucursales();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;

            stock = new Stock();
            grdStock.MostrarDatos(stock.Datos("Id=0"), true);
            formato_Grilla();
            Totales();
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
            string s = Armar_Cadena();
            grdStock.MostrarDatos(stock.Datos(s), true);
            formato_Grilla();
            Totales();
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            return s;
        }

        private void formato_Grilla()
        {
            grdStock.set_ColW(grdStock.get_ColIndex("Id"), 0);
            grdStock.set_ColW(grdStock.get_ColIndex("Fecha"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Id_Sucursales"), 30);
            grdStock.set_ColW(grdStock.get_ColIndex("Nombre"), 100);
            grdStock.set_ColW(grdStock.get_ColIndex("Id_Productos"), 30);
            grdStock.set_ColW(grdStock.get_ColIndex("Descripcion"), 100);
            grdStock.set_ColW(grdStock.get_ColIndex("Costo"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Kilos"), 60);
            grdStock.set_ColW(grdStock.get_ColIndex("Total"), 80);

            grdStock.set_Texto(0, grdStock.get_ColIndex("Id_Sucursales"), "Suc");
            grdStock.set_Texto(0, grdStock.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdStock.SumarCol(grdStock.get_ColIndex("Total"), false);
            double k = grdStock.SumarCol(grdStock.get_ColIndex("Kilos"), false);
            int c = grdStock.Rows - 2;
            lblCant.Text = $"Registros: {c}";
            lblKilos.Text = $"Kilos: {k:N2}";
            lblTotal.Text = $"Total: {t:C2}";
        }

        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void GrdStock_Editado(short f, short c, object a)
        {
            int id = Convert.ToInt32( grdStock.get_Texto(f, grdStock.get_ColIndex("Id")));
            switch (c)
            {
                case 1:
                    //Fecha
                    //TODO: Validar que la fecha este en el rango del calendario
                    stock.Fecha = Convert.ToDateTime(a);
                    precios.Fecha = stock.Fecha;

                    grdStock.set_Texto(f, c, a);
                    grdStock.ActivarCelda(f, c + 1);
                    break;
                case 2:
                    //ID_Sucursales
                    stock.suc.Id = Convert.ToInt32(a);
                    if (stock.suc.Existe() == true)
                    {
                        precios.suc = stock.suc;

                        grdStock.set_Texto(f, c, a);
                        grdStock.set_Texto(f, c + 1, stock.suc.Nombre);

                        grdStock.ActivarCelda(f, c + 2);
                    }else
                    {
                        Mensaje("No se encontró la sucursal " + a.ToString());
                        grdStock.ErrorEnTxt();
                    }
                    break;
                case 4:
                    //ID_Productos
                    stock.producto.Id = Convert.ToInt32(a);
                    if (stock.producto.Existe() == true)
                    {
                        precios.producto = stock.producto;

                        stock.Descripcion = stock.producto.Nombre;

                        grdStock.set_Texto(f, c, a);
                        grdStock.set_Texto(f, c + 1, stock.producto.Nombre);

                        stock.Costo = precios.Buscar();
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Costo"), stock.Costo);
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo*stock.Kilos);

                        grdStock.ActivarCelda(f, grdStock.get_ColIndex("Kilos"));
                        Totales();
                    }
                    else
                    {
                        Mensaje("No se encontró el producto " + a.ToString());
                        grdStock.ErrorEnTxt();
                    }
                    break;
                case 5:
                    //Descripcion
                    stock.Descripcion = a.ToString();
                    grdStock.set_Texto(f, c, a);

                    grdStock.ActivarCelda(f + 1, c);
                    break;
                case 6:
                    //Costo
                    stock.Costo = Convert.ToSingle(a);
                    grdStock.set_Texto(f, c, a);
                    grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo * stock.Kilos);

                    grdStock.ActivarCelda(f + 1, c);
                    Totales();
                    break;
                case 7:
                    //Kilos
                    stock.Kilos = Convert.ToSingle(a);
                    grdStock.set_Texto(f, c, a);
                    grdStock.set_Texto(f, grdStock.get_ColIndex("Total"), stock.Costo * stock.Kilos);

                    //TODO:
                    //Guardar
                    if (grdStock.Row == grdStock.Rows - 1)
                    {
                        stock.Agregar();
                        grdStock.set_Texto(f, grdStock.get_ColIndex("Id"), stock.Id);
                        grdStock.AgregarFila();
                    }
                    else
                    {
                        stock.Actualizar();
                    }
                    grdStock.ActivarCelda(f + 1, c);
                    //Rellenar nueva fila
                    Totales();
                    break;
            }

        }

        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdStock.Rows = 1;
            grdStock.Rows = 2;
        }

        private void GrdStock_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdStock.get_Texto(Fila, grdStock.get_ColIndex("Id")).ToString());
            stock.Cargar_Fila(i);            
        }

        private void CFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }
    }
}
