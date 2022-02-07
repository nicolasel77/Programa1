namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmDiarios : Form
    {
        Diarios diarios = new Diarios();
        public frmDiarios()
        {
            InitializeComponent();

            grd.MostrarDatos(diarios.Datos_Vista(), true, true);
            grd.Columnas["Importe"].Format = "N1";
            grd.AutosizeAll();
        }

        private void frmDiarios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int i = Convert.ToInt32(grd.get_Texto(grd.Row, grd.get_ColIndex("ID")));
                if (i != 0)
                {
                    diarios.ID = i;
                    diarios.Borrar();

                    grd.BorrarFila();
                    grd.ActivarCelda(grd.Row, 0);
                }
            }
        }

        private void grd_Editado(short f, short c, object a)
        {
            diarios.ID = Convert.ToInt32(grd.get_Texto(f, 7));
            
            switch (c)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    grd.set_Texto(f, c, a);

                    if (diarios.ID != 0)
                    {
                        diarios.Caja = Convert.ToInt32(grd.get_Texto(f, 0));
                        diarios.Tipo = Convert.ToInt32(grd.get_Texto(f, 1));
                        diarios.SubTipo = Convert.ToInt32(grd.get_Texto(f, 2));
                        diarios.Desc_SubTipo = Convert.ToString(grd.get_Texto(f, 3));
                        diarios.Detalle = Convert.ToInt32(grd.get_Texto(f, 4));
                        diarios.Descripcion = Convert.ToString(grd.get_Texto(f, 5));
                        diarios.Importe = Convert.ToDouble(grd.get_Texto(f, 6));
                        diarios.Actualizar();
                    }

                    grd.ActivarCelda(f, c + 1);
                    break;
                case 6:
                    grd.set_Texto(f, c, a);

                    diarios.Caja = Convert.ToInt32(grd.get_Texto(f, 0));
                    diarios.Tipo = Convert.ToInt32(grd.get_Texto(f, 1));
                    diarios.SubTipo = Convert.ToInt32(grd.get_Texto(f, 2));
                    diarios.Desc_SubTipo = Convert.ToString(grd.get_Texto(f, 3));
                    diarios.Detalle = Convert.ToInt32(grd.get_Texto(f, 4));
                    diarios.Descripcion = Convert.ToString(grd.get_Texto(f, 5));
                    diarios.Importe = Convert.ToDouble(a);

                    if (diarios.ID == 0)
                    {
                        diarios.Agregar();
                        grd.set_Texto(f, 7, diarios.ID);
                        grd.AgregarFila();
                    }
                    else
                    {
                        diarios.Actualizar();
                    }

                    grd.ActivarCelda(f + 1, 0);
                    break;
            }
        }
    }
}
