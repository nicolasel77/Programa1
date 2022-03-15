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
        readonly Retiros retiros = new Retiros();
        public bool Aceptado = false;
        public string fecha;

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

                float importe  = 0;
                if (txtImporte.Text.Length > 0)
                {
                    float.TryParse(txtImporte.Text, out importe);
                    txtImporte.Text = importe.ToString("N1");
                }

                string s = h.Codigos_Seleccionados(lstSucs, "Suc IN({0})");

                int tamaño_array = 0;

                if (rdVacaciones.Checked == true)
                {
                    s = s + $" AND Tipo = 5 AND Semana = {fecha}";
                }
                else
                {
                    tamaño_array = Convert.ToInt16(empleados.Dato_Generico($"SELECT COUNT(Empleado) FROM dbEmpleados.dbo.Retiros WHERE Tipo = 5 AND {s} AND" +
                $"{fecha} BETWEEN Semana AND DATEADD(DAY, Dias - 1, Semana)"));
                }

                if (chBajas.Checked)
                {
                    s = s + " AND LEFT(Nombre, 4) NOT LIKE 'baja'";
                }


                int[] emp_de_vacas = new int[tamaño_array];

                int emp = 0;
                for (int i = 0; i < emp_de_vacas.Length; i++)
                {
                    emp = Convert.ToInt16(empleados.Dato_Generico($"SELECT TOP 1 Empleado FROM dbEmpleados.dbo.Retiros WHERE Tipo = 5 AND {h.Codigos_Seleccionados(lstSucs, "Suc IN({0})")} AND Empleado > {emp} AND " +
                $"{fecha} BETWEEN Semana AND DATEADD(DAY, Dias - 1, Semana) ORDER BY Empleado"));
                    emp_de_vacas.SetValue(emp, i);
                }


                if (rdNinguno.Checked == false)
                {
                    if (rdAdelanto.Checked == true)
                    {
                        //grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, dbEmpleados.dbo.f_Adelanto(ID, DATEADD(MONTH, 1, DATEADD(DAY, DAY(GETDATE()) * -1, GETDATE()))) AS Adelanto, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                        grd.MostrarDatos(empleados.Datos_Vista(s, $"Suc, ID, Nombre" +
                                    $", ISNULL((SELECT SUM(ISNULL(Importe, 0)) FROM dbEmpleados.dbo.Retiros WHERE Semana='{gastos.Fecha:MM/dd/yy}' AND Empleado=vw_Empleados.ID AND Tipo=1), 0) AS Adelanto" +
                                    $", CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);

                    }
                    else
                    {
                        if (rdAguinaldo.Checked == true)
                        {
                            grd.MostrarDatos(empleados.Datos_Vista(s, $"Suc, ID, Nombre, dbEmpleados.dbo.f_SaldoAguinaldo(DATEADD(MONTH, 1, DATEADD(DAY, DAY(GETDATE()) * -1, GETDATE())), ID)/{nuDivisor.Value} AS Aguinaldo, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                        }
                        else
                        {
                            if (rdVacaciones.Checked == true)
                            {
                                grd.MostrarDatos(retiros.Datos_Vista(s, "suc, Empleado as Id, Nombre, Importe, CONVERT(BIT, 1) Sel", "Suc, Empleado"), true, true);
                            }
                            else
                            {
                                //Resto
                                // devuelve el primer día del mes anterior                        
                                //grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, dbEmpleados.dbo.f_Saldo(ID, DATEADD(MONTH, -1, DATEADD(DAY, DAY(GETDATE()) * -1 + 1, GETDATE())), '1/1/1900', '1/1/1900') AS Saldo, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                                //grd.MostrarDatos(empleados.Datos_Vista(s, "Suc, ID, Nombre, dbEmpleados.dbo.f_Saldo(ID, DATEADD(MONTH, -1, DATEADD(DAY, DAY(GETDATE()) * -1 + 1, GETDATE())), '1/1/1900', '1/1/1900') AS Saldo, CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                                grd.MostrarDatos(empleados.Datos_Vista(s, $"Suc, ID, Nombre" +
                                    $", ISNULL((SELECT SUM(ISNULL(Importe, 0)) FROM dbEmpleados.dbo.Retiros WHERE Semana='{gastos.Fecha:MM/dd/yy}' AND Empleado=vw_Empleados.ID AND Tipo=1), 0) AS Resto" +
                                    $", CONVERT(BIT, 1) Sel", "Suc, ID"), true, true);
                            }
                        }
                    }
                }
                else
                {
                    string stimporte = importe.ToString();
                    stimporte = stimporte.Replace(",", ".");
                    grd.MostrarDatos(empleados.Datos_Vista(s, $"Suc, ID, Nombre, {stimporte} AS Importe, CONVERT(BIT, 1) Sel"), true, true);
                }

                for (int i = 0; i < emp_de_vacas.Length; i++)
                {
                    emp = (int)emp_de_vacas.GetValue(i);
                    for (int f = 1; f < grd.Rows - 1; f++)
                    {
                        if (Convert.ToInt16(grd.get_Texto(f, 1)) == emp)
                        {
                            grd.set_ColorLetraCelda(f, 0, System.Drawing.Color.Red);
                            grd.set_ColorLetraCelda(f, 1, System.Drawing.Color.Red);
                            grd.set_ColorLetraCelda(f, 2, System.Drawing.Color.Red);
                            grd.set_ColorLetraCelda(f, 3, System.Drawing.Color.Red);
                            grd.set_Texto(f, 4, false);
                        }
                    }
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
            if (rdResto.Checked == true) { Cargar_Datos(); txtDescripcion.Text = "Resto sueldo"; txtCodigo.Text = "1"; }
        }

        private void rdAdelanto_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdAdelanto.Checked == true) { Cargar_Datos(); txtDescripcion.Text = "Adelanto sueldo"; txtCodigo.Text = "1"; }
        }

        private void rdVacaciones_CheckedChanged(object sender, EventArgs e)
        {
            if (rdVacaciones.Checked == true) { Cargar_Datos(); txtDescripcion.Text = "Vacaciones"; txtCodigo.Text = "5"; }
        }

        private void rdAguinaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAguinaldo.Checked == true) { Cargar_Datos(); txtDescripcion.Text = "Aguinaldo"; txtCodigo.Text = "4"; }
        }

        private void rdNinguno_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdNinguno.Checked == true) { Cargar_Datos(); txtDescripcion.Text = "Descripcion"; }
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
            if (String.IsNullOrWhiteSpace(txtDescripcion.Text) == false)
            {
                Aceptado = true;

                int codigo = 1;
                if(txtCodigo.Text.Length > 0)
                {
                    int.TryParse(txtCodigo.Text, out codigo);
                }

                gastos.Id_DetalleGastos = codigo;
                gastos.Descripcion = txtDescripcion.Text;

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
            else
            {
                MessageBox.Show("Debe ingresar una descripción.");
                txtDescripcion.Focus();
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void chBajas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNinguno.Checked == true) { Cargar_Datos(); }
        }

        private void nuDivisor_ValueChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}
