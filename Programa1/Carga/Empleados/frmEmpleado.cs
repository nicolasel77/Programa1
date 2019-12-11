namespace Programa1.Carga.Empleados
{
    using DB;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        public void Cargar(Empleados Empleado)
        {
            Empleado.Existe();
            lblNombre.Text = Empleado.Nombre;

            DataTable dt = Empleado.Datos("Id=" + Empleado.Id);
            grdEmpleado.Rows = dt.Columns.Count-1;
            
            for (int c = 0; c < dt.Columns.Count - 1; c++)
            {
                grdEmpleado.set_Texto(c, 0, dt.Columns[c].ColumnName);
                grdEmpleado.set_Texto(c, 1, dt.Rows[0][c]);
            }
            grdEmpleado.AutosizeAll();
        }
    }
}
