namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmPartidos : Form
    {
        Partidos partidos = new Partidos();
        public frmPartidos()
        {
            InitializeComponent();

            grd.MostrarDatos(partidos.Datos(), true);
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c == 0)
            {
                partidos.ID = Convert.ToInt32(a);
                partidos.Agregar();
                // activar celda
                // si es nuevo agrego fila

            }
            else
            {
                partidos.Nombre = a.ToString();
                partidos.Actualizar("NBoleta", 12);
                // actualizar
            }
        }
    }
}
