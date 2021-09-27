namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmCargar_Sueldos : Form
    {
        public Gastos gastos;
        readonly Sucursales sucs = new Sucursales();
        readonly Empleados empleados = new Empleados();
        public bool Aceptado = false;

        public frmCargar_Sueldos()
        {
            InitializeComponent();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSucs, sucs.Datos_Vista("ID>4999", "ID, Nombre", "ID"));
            if (DateTime.Today.Day > 12)
            {
                rdAdelanto.Checked = true;
            }
            else
            {
                rdResto.Checked = true;
            }
        }

        private void Cargar_Datos()
        {
            if (lstSucs.SelectedIndex > -1)
            {
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                string s = h.Codigos_Seleccionados(lstSucs, "Suc IN({0})");
                if (rdNinguno.Checked == false)
                {
                    if (rdAdelanto.Checked == true)
                    {
                        grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, dbEmpleados.dbo.f_Adelanto(ID, DATEADD(MONTH, 1, DATEADD(DAY, DAY(GETDATE()) * -1, GETDATE()))) AS Adelanto, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                    }
                    else
                    {
                        // devuelve el primer día del mes anterior                        

                        grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, dbEmpleados.dbo.f_Saldo(ID, DATEADD(MONTH, -1, DATEADD(DAY, DAY(GETDATE()) * -1 + 1, GETDATE())), '1/1/1900', '1/1/1900') AS Saldo, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                    }
                }
                else
                {
                    grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, 0.0 AS Importe, CONVERT(BIT, 1) Sel"), true, true);
                }
                grd.Columnas[3].Format = "N1";
                grd.set_ColW(0, 40);
                grd.set_ColW(1, 40);
                grd.set_ColW(2, 200);
                grd.set_ColW(3, 80);
                grd.set_ColW(4, 30);
                Sumar();
            }

        }

        private void Sumar()
        {
            float t = 0;
            for (int i = 1; i <= grd.Rows - 2; i++)
            {
                if (Convert.ToSingle(grd.get_Texto(i, 3)) <= 0)
                {
                    grd.set_Texto(i, 4, false);
                }
                if (Convert.ToBoolean(grd.get_Texto(i, 4)) == true)
                {
                    t += Convert.ToSingle(grd.get_Texto(i, 3));
                }
            }
            grd.set_Texto(grd.Rows - 1, 3, t);
        }

        private void lstSucs_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Cargar_Datos();
        }


        private void rdResto_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdResto.Checked == true) { Cargar_Datos(); }
        }

        private void rdAdelanto_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdAdelanto.Checked == true) { Cargar_Datos(); }
        }

        private void rdNinguno_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdNinguno.Checked == true) { Cargar_Datos(); }
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c >= 3)
            {
                grd.set_Texto(f, c, a);
                Sumar();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptado = true;

            gastos.Id_DetalleGastos = 1;
            gastos.Descripcion = rdResto.Checked ? "Resto sueldo" : "Adelanto Sueldo";

            for (int i = 1; i <= grd.Rows - 2; i++)
            {
                if (Convert.ToBoolean(grd.get_Texto(i, 4)) == true)
                {
                    gastos.Id_SubTipoGastos = Convert.ToInt32(grd.get_Texto(i, 1));
                    gastos.Desc_SubTipo = Convert.ToString(grd.get_Texto(i, 2));                   
                    gastos.Importe = Convert.ToDouble(grd.get_Texto(i, 3));
                    gastos.Agregar();
                }
            }
            Hide();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
