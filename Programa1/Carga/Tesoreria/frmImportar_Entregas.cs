namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Sucursales;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmImportar_Entregas : Form
    {
        public Entradas entradas = new Entradas();

        public frmImportar_Entregas()
        {
            InitializeComponent();

            DataTable dt = entradas.Entregas_AImportar();
            grd.MostrarDatos(dt, true, false);
            grd.AutosizeAll();
            grd.set_ColW(0, 0);
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            Detalle_Entregas detalle = new Detalle_Entregas();
            Sucursales suc = new Sucursales();

            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                bool sel = Convert.ToBoolean(grd.get_Texto(i, grd.get_ColIndex("Sel")));
                if (sel)
                {
                    if (suc.Existe(Convert.ToInt32(grd.get_Texto(i, grd.get_ColIndex("Suc")))))
                    {
                        entradas.Id_SubTipoEntrada = suc.ID;
                        entradas.Descripcion = suc.Nombre;
                    }

                    detalle.Id = Convert.ToInt32(grd.get_Texto(i, grd.get_ColIndex("ID")));
                    detalle.Fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                    detalle.Importe = Convert.ToDouble(grd.get_Texto(i, grd.get_ColIndex("Importe")));

                    // 1º Agregar la ENTRADA para obetner el ID_Entradas
                    if (detalle.Suc != entradas.Id_SubTipoEntrada)
                    {
                        entradas.Importe = detalle.Importe;
                        entradas.Agregar();
                    }
                    else
                    {
                        //Si no es nuevo, actualizar el importe
                        entradas.Importe += detalle.Importe;
                        entradas.Actualizar("Importe", entradas.Importe);
                    }

                    detalle.Suc = suc.ID;

                    if (detalle.Importe != 0)
                    {
                        //2º Asignamos el ID_Entradas
                        detalle.ID_Entradas = entradas.ID;
                        detalle.Actualizar();
                    }
                }
            }
            this.Hide();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cTodos_Click(object sender, EventArgs e)
        {
            Detalle_Entregas detalle = new Detalle_Entregas();
            Sucursales suc = new Sucursales();

            for (int i = 1; i <= grd.Rows - 1; i++)
            {

                if (suc.Existe(Convert.ToInt32(grd.get_Texto(i, grd.get_ColIndex("Suc")))))
                {
                    entradas.Id_SubTipoEntrada = suc.ID;
                    entradas.Descripcion = suc.Nombre;
                }

                detalle.Id = Convert.ToInt32(grd.get_Texto(i, grd.get_ColIndex("ID")));
                detalle.Fecha = Convert.ToDateTime(grd.get_Texto(i, grd.get_ColIndex("Fecha")));
                detalle.Importe = Convert.ToDouble(grd.get_Texto(i, grd.get_ColIndex("Importe")));

                // 1º Agregar la ENTRADA para obetner el ID_Entradas
                if (detalle.Suc != entradas.Id_SubTipoEntrada)
                {
                    entradas.Importe = detalle.Importe;
                    entradas.Agregar();
                }
                else
                {
                    entradas.Importe += detalle.Importe;
                    entradas.Actualizar("Importe", entradas.Importe);
                }

                detalle.Suc = suc.ID;

                if (detalle.Importe != 0)
                {
                    detalle.ID_Entradas = entradas.ID;
                    detalle.Actualizar();
                }
            }
            this.Hide();
        }
    }
}
