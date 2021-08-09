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
            int[] n = { 46, 123 };
            grdEmpleados.TeclasManejadas = n;
            Cargar();
        }

        private void Cargar()
        {
            grdEmpleados.MostrarDatos(empleados.Datos(cSuc.Cadena("Id_Sucursales")), true);
            int i = empleados.Max_ID();
            grdEmpleados.set_Texto(grdEmpleados.Rows - 1, 0, i + 1);

            grdEmpleados.set_ColW(0, 40);
            grdEmpleados.set_ColW(1, 150);
            grdEmpleados.set_ColW(2, 70);
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
            grdEmpleados.FixCols = 1;
            grdEmpleados.Columnas[2].Format = "N0";
            lblCant.Text = $"Empleados: {grdEmpleados.Rows - 2}";
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

        private void grdEmpleados_Editado(short f, short c, object a)
        {
            empleados.ID = Convert.ToInt32(grdEmpleados.get_Texto(f, 0)); ;
            bool esiste = empleados.Existe();

            switch (c)
            {
                case 1: // Nombre
                    empleados.Nombre = a.ToString();
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 2);

                    break;
                case 2: // DNI
                    empleados.DNI = int.Parse(a.ToString());
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 3);

                    break;
                case 3: // Fecha_Nacimiento
                    empleados.Fecha_Nacimiento = DateTime.Parse(a.ToString());
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 4);

                    break;
                case 4: // Domicilio
                    empleados.Domicilio = a.ToString();
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 5);

                    break;
                case 5: // Telefono
                    empleados.Telefono = a.ToString();
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 6);

                    break;
                case 6: // Alta
                    empleados.Alta = DateTime.Parse(a.ToString());
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 7);

                    break;
                case 7: // Baja
                    empleados.Baja = DateTime.Parse(a.ToString());
                    grdEmpleados.set_Texto(f, c, a);
                    if (esiste) empleados.Actualizar();
                    grdEmpleados.ActivarCelda(f, 8);

                    break;
                case 8: // Localidad
                    empleados.Localidad.Id = Convert.ToInt32(a);
                    if (empleados.Localidad.Existe() == true)
                    {
                        grdEmpleados.set_Texto(f, c, a);
                        grdEmpleados.set_Texto(f, c + 1, empleados.Localidad.Nombre);
                        if (esiste) empleados.Actualizar();
                        grdEmpleados.ActivarCelda(f, 10);
                    }
                    else
                    {
                        Mensaje($"No se encontro la Localidad '{a.ToString()}'.");
                        grdEmpleados.ErrorEnTxt();
                    }

                    break;
                case 10: // Tipo
                    empleados.Tipo.ID = Convert.ToInt32(a);
                    if (empleados.Tipo.Existe() == true)
                    {
                        grdEmpleados.set_Texto(f, c, a);
                        grdEmpleados.set_Texto(f, c + 1, empleados.Tipo.Nombre);
                        if (esiste) empleados.Actualizar();
                        grdEmpleados.ActivarCelda(f, 12);
                    }
                    else
                    {
                        Mensaje($"No se encontro el tipo '{a.ToString()}'.");
                        grdEmpleados.ErrorEnTxt();
                    }

                    break;
                case 12: // Sucursal
                    empleados.Sucursal.ID = Convert.ToInt32(a);
                    if (empleados.Sucursal.Existe() == true)
                    {
                        grdEmpleados.set_Texto(f, c, a);
                        grdEmpleados.set_Texto(f, c + 1, empleados.Sucursal.Nombre);
                        if (esiste)
                        {
                            empleados.Actualizar();
                            grdEmpleados.ActivarCelda(f + 1, 1);
                        }
                        else
                        {
                            if (empleados.Tipo.Existe())
                            {
                                empleados.Agregar();
                                grdEmpleados.AgregarFila();
                                int i = empleados.Max_ID();
                                grdEmpleados.set_Texto(f + 1, 0, i + 1);
                                grdEmpleados.ActivarCelda(f + 1, 1);
                            }
                            else
                            {
                                Mensaje($"Debe ingresar el tipo.");
                                grdEmpleados.ActivarCelda(f, 10);
                            }
                        }
                    }
                    else
                    {
                        Mensaje($"No se encontro la sucursal '{a.ToString()}'.");
                        grdEmpleados.ErrorEnTxt();
                    }

                    break;
            }
        }

        private void grdEmpleados_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el empleado '{grdEmpleados.get_Texto(grdEmpleados.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdEmpleados.get_Texto(grdEmpleados.Row, 0)) != 0)
                    {
                        empleados.ID = Convert.ToInt32(grdEmpleados.get_Texto(grdEmpleados.Row, 0));
                        empleados.Borrar();
                        grdEmpleados.BorrarFila(grdEmpleados.Row);
                    }

                }
            }
        }

        private void grdEmpleados_CambioFila(short Fila)
        {
            // 0 int Id 
            // 1 string Nombre 
            // 2 int DNI
            // 3 Datetime Fecha_Nacimiento
            // 4 string Domicilio
            // 5 string Telefono
            // 6 Datetime Alta
            // 7 Datetime Baja
            // 8 int Localidad
            // 9 string Nombre
            // 10 int Tipo
            // 11 string Nombre
            // 12 int Sucursal
            empleados.ID = Convert.ToInt32(grdEmpleados.get_Texto(Fila, 0));
            empleados.Nombre = grdEmpleados.get_Texto(Fila, 1).ToString();
            empleados.DNI = Convert.ToInt32(grdEmpleados.get_Texto(Fila, 2));
            empleados.Fecha_Nacimiento = Convert.ToDateTime(grdEmpleados.get_Texto(Fila, 3));
            if (empleados.Fecha_Nacimiento.Year < 2000) empleados.Fecha_Nacimiento= new DateTime(1900,1,1);
            empleados.Domicilio = grdEmpleados.get_Texto(Fila, 4).ToString();
            empleados.Telefono = grdEmpleados.get_Texto(Fila, 5).ToString();
            empleados.Alta = Convert.ToDateTime(grdEmpleados.get_Texto(Fila, 6));
            if (empleados.Alta.Year < 2000) empleados.Alta = new DateTime(1900, 1, 1);
            empleados.Baja = Convert.ToDateTime(grdEmpleados.get_Texto(Fila, 7));
            if (empleados.Baja.Year < 2000) empleados.Baja = new DateTime(1900, 1, 1);
            empleados.Localidad.Id = Convert.ToInt32(grdEmpleados.get_Texto(Fila, 8));
            empleados.Tipo.ID = Convert.ToInt32(grdEmpleados.get_Texto(Fila, 10));
            empleados.Sucursal.ID = Convert.ToInt32(grdEmpleados.get_Texto(Fila, 12));
        }

        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }
        private void TiMensaje_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }

        #endregion

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdEmpleados.MostrarDatos(empleados.Datos($"Nombre like '%{i}%' OR Id={i} OR DNI={i}"));
                }
                else
                {
                    grdEmpleados.MostrarDatos(empleados.Datos($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdEmpleados.MostrarDatos(empleados.Datos());
            }
            lblCant.Text = $"Empleados: {grdEmpleados.Rows - 2}";
        }
    }
}
