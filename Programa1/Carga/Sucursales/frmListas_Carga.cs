using Programa1.DB.Varios;
using System;
using System.Windows.Forms;

namespace Programa1.Carga.Sucursales
{
    public partial class frmListas_Carga : Form
    {
        Listas_Carga listas = new Listas_Carga();
        public frmListas_Carga()
        {
            InitializeComponent();
        }

        private void frmListas_Carga_Load(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstListas, listas.Lista.Datos());
            Cargar();
        }

        private void Cargar()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            string f = "";
            if (lstListas.SelectedIndex > -1) { f = h.Codigo_Seleccionado(lstListas.Text).ToString(); f = h.Unir(" ID=", f); }

            grd.MostrarDatos(listas.Datos_Vista(f, "*", "Orden"), true);
            grd.set_ColW(0, 30);
            grd.set_ColW(1, 90);
            grd.set_ColW(2, 30);
            grd.set_ColW(3, 60);
            grd.set_ColW(4, 100);
        }

        private void grd_Editado(short f, short c, object a)
        {
            // ID_Lista, Nombre, Orden, Producto, Nombre_Producto
            switch (c)
            {
                case 0: //ID_Lista
                    if (listas.Lista.Existe(Convert.ToInt32(a)) == true)
                    {
                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, c + 1, listas.Lista.Nombre);
                        grd.ActivarCelda(f, 2);
                    }
                    break;
                case 2: //Orden
                    listas.Orden = Convert.ToInt32(a);
                    if (listas.ID != 0 & listas.Producto.ID != 0) { listas.Actualizar("Orden", a); }

                    grd.set_Texto(f, c, a);
                    grd.ActivarCelda(f, 3);
                    break;
                case 3: //Producto
                    if (listas.Producto.Existe(Convert.ToInt32(a)) == true)
                    {
                        if (listas.ID != 0 & listas.Producto.ID != 0) 
                        {
                            listas.Actualizar("Producto", a);
                        }
                        else
                        {
                            listas.Agregar_NoID("ID_Lista", a);
                            //listas.Actualizar("Orden", listas.Orden);

                        }

                        grd.set_Texto(f, c, a);
                        grd.ActivarCelda(f, 3);
                    }
                    break;
            }
        }
    }
}
