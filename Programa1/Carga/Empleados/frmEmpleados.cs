namespace Programa1.Carga.Empleados
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmEmpleados : Form
    {
        private Empleados empleados = new Empleados();
        public frmEmpleados()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            grdEmpleados.MostrarDatos(empleados.Datos(cSuc.Cadena("Id_Sucursales")), true);

            grdEmpleados.set_ColW(0, 40);
            grdEmpleados.set_ColW(1, 150);
            grdEmpleados.set_ColW(2, 40);
            grdEmpleados.set_ColW(3, 60);
            grdEmpleados.set_ColW(4, 150);
            grdEmpleados.set_ColW(5, 80);
            grdEmpleados.set_ColW(6, 60);
            grdEmpleados.set_ColW(7, 60);
            grdEmpleados.set_ColW(8, 30);
            grdEmpleados.set_ColW(9, 80);
            grdEmpleados.set_ColW(10, 30);
            grdEmpleados.set_ColW(11, 80);
            grdEmpleados.set_ColW(12, 30);
            grdEmpleados.set_ColW(13, 80);
        }

        private void ChMostrarBajas_CheckedChanged(object sender, EventArgs e)
        {
            empleados.Mostrar_Bajas = chMostrarBajas.Checked;
            Cargar();
        }

        private void CSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
