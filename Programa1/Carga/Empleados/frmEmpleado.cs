namespace Programa1.Carga.Empleados
{
    using DB;
    using System;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmEmpleado : Form
    {
        private Empleados empleado;
        public frmEmpleado()
        {
            InitializeComponent();

            Localidades lc = new Localidades();
            grdLocalidades.MostrarDatos(lc.Datos(), true, false);
            grdLocalidades.AutosizeAll();
            grdLocalidades.set_ColW(1, 0);

            TipoEmpleados tp = new TipoEmpleados();
            grdTipo.MostrarDatos(tp.Datos(), true, false);
            grdTipo.AutosizeAll();
        }

        public void Cargar(Empleados Empleado)
        {
            Empleado.Existe();
            empleado = Empleado;
            lblNombre.Text = Empleado.Nombre;

            DataTable dt = Empleado.Datos("Id=" + Empleado.ID);
            grdEmpleado.Rows = dt.Columns.Count;

            for (int c = 0; c < dt.Columns.Count; c++)
            {
                grdEmpleado.set_Texto(c, 0, dt.Columns[c].ColumnName);
                grdEmpleado.set_Texto(c, 1, dt.Rows[0][c]);
            }
            grdEmpleado.Columnas[1].DataType = Type.GetType("System.String");
            grdEmpleado.AutosizeAll();
        }

        private void GrdEmpleado_Editado(short f, short c, object a)
        {
            //Id = id;
            //Nombre = nombre;
            //DNI = dni;
            //Fecha_Nacimiento = fecha;
            //Domicilio = domicilio;
            //Telefono = telefono;
            //Alta = alta;
            //Baja = baja;
            //Localidad = localidad;
            //Tipo = tipo;
            //Sucursal = sucursal;

            switch (grdEmpleado.get_Texto(f, 0))
            {
                case "Nombre":
                    empleado.Nombre = a.ToString();
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "DNI":
                    empleado.DNI = Convert.ToInt32(a);
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Fecha_Nacimiento":
                    empleado.Fecha_Nacimiento = Convert.ToDateTime(a);
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Domicilio":
                    empleado.Domicilio = a.ToString();
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Telefono":
                    empleado.Telefono = a.ToString();
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Alta":
                    empleado.Alta = Convert.ToDateTime(a);
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Baja":
                    empleado.Baja = Convert.ToDateTime(a);
                    empleado.Actualizar();
                    grdEmpleado.set_Texto(f, c, a);
                    grdEmpleado.ActivarCelda(f + 1, c);
                    break;
                case "Id_Localidades":
                    empleado.Localidad.Id = Convert.ToInt32(a);
                    if (!empleado.Localidad.Existe())
                    {
                        grdEmpleado.ErrorEnTxt();
                    }
                    else
                    {
                        grdEmpleado.set_Texto(f + 1, 1, empleado.Localidad.Nombre);
                        empleado.Actualizar();
                        grdEmpleado.set_Texto(f, c, a);
                        grdEmpleado.ActivarCelda(f + 2, c);
                    }
                    break;
                case "Id_Tipo":
                    empleado.Tipo.ID = Convert.ToInt32(a);
                    if (!empleado.Tipo.Existe())
                    {
                        grdEmpleado.ErrorEnTxt();
                    }
                    else
                    {
                        grdEmpleado.set_Texto(f + 1, 1, empleado.Tipo.Nombre);
                        empleado.Actualizar();
                        grdEmpleado.set_Texto(f, c, a);
                        grdEmpleado.ActivarCelda(f + 2, c);
                    }
                    break;
                case "Id_Sucursales":
                    empleado.Sucursal.ID = Convert.ToInt32(a);
                    if (!empleado.Sucursal.Existe())
                    {
                        grdEmpleado.ErrorEnTxt();
                    }
                    else
                    {
                        grdEmpleado.set_Texto(f + 1, 1, empleado.Sucursal.Nombre);
                        empleado.Actualizar();
                        grdEmpleado.set_Texto(f, c, a);
                    }

                    break;
            }
        }
    }
}
