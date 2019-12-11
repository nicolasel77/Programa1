namespace Programa1.Carga.Empleados
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmRetiros_Detalle : Form
    {
        public Retiros retiros;

        public frmRetiros_Detalle()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdDetalle.TeclasManejadas = n;

        }

        public void Cargar()
        {
            retiros.Empleado.Existe();
            lblNombre.Text = retiros.Empleado.Nombre;
            lblFecha.Text = retiros.Fecha.ToString("dd/MM/yyy");
            if (retiros.Tipo.Id == 1)
            {
                grdDetalle.MostrarDatos(retiros.Detalle_Adelantos(), true, true);
            }
            else
            {
                grdDetalle.MostrarDatos(retiros.Detalle_Resto(), true, true);
            }
            
            grdDetalle.set_ColW(0, 0);
            grdDetalle.set_ColW(1, 60);
            grdDetalle.set_ColW(2, 0);
            grdDetalle.set_ColW(3, 0);
            grdDetalle.set_ColW(4, 40);
            grdDetalle.set_ColW(5, 0);
            grdDetalle.set_ColW(6, 0);
            grdDetalle.set_ColW(7, 80);
            grdDetalle.set_Texto(0, 4, "Suc");
            grdDetalle.Columnas[7].Format = "N1";
            grdDetalle.ActivarCelda(grdDetalle.Rows - 1, 1);
        }

    }
}
