namespace Programa1.Carga.Empleados
{
    using Programa1.Carga.Varios;
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using System;
    using System.Windows.Forms;

    public partial class frmRetiros : Form
    {
        private Retiros retiros = new Retiros();
        public frmRetiros()
        {
            InitializeComponent();
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdRetiros.TeclasManejadas = n;

            //Cargar las semanas en el listbox lstSemanas
            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            
            //Cargar los tipos de retiro en el listbox lstTipos
            h.Llenar_List(lstTipos, retiros.Tipo.Datos());

            //El intercambio de columnas para estas teclas
            grdRetiros.AgregarTeclas(Convert.ToInt32(Keys.Subtract), 5, 8);
            grdRetiros.AgregarTeclas(Convert.ToInt32(Keys.Add), 2, 3, 5, 8);
        }

        private void lstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
        private void cSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
        private void lstTipos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                // Si se hace click con el boton del medio, se limpia el filtro de tipo
                lstTipos.SelectedIndex = -1;
            }


        }

        private void grdRetiros_Editado(short f, short c, object a)
        {
            // Verificar si es la última fila (registro nuevo)
            bool esRegistroNuevo = (f == grdRetiros.Rows - 1);

            // Obtener los índices de las columnas
            byte c_Fecha = Convert.ToByte(grdRetiros.get_ColIndex("Fecha"));
            byte c_Suc = Convert.ToByte(grdRetiros.get_ColIndex("Suc"));
            byte c_Emp = Convert.ToByte(grdRetiros.get_ColIndex("Emp"));
            byte c_Nombre = Convert.ToByte(grdRetiros.get_ColIndex("Nombre"));
            byte c_Tipo = Convert.ToByte(grdRetiros.get_ColIndex("Tipo"));

            // Si es un registro nuevo y se está editando la fecha
            if (c == c_Fecha)
            {
                try
                {
                    DateTime fechaEditada = Convert.ToDateTime(a);

                    if (!esRegistroNuevo)
                    {
                        // Si no es un registro nuevo, actualizar la fecha de imputación de ese registro
                        retiros.Id = Convert.ToInt32(grdRetiros.get_Texto(f, 0));
                        retiros.Sucursal.ID = c_Suc;
                        retiros.Empleado.ID = c_Emp;
                        retiros.Tipo.ID = c_Tipo;
                        retiros.Importe = Convert.ToSingle(grdRetiros.get_Texto(f, grdRetiros.get_ColIndex("Importe")));
                        retiros.Fecha = fechaEditada;
                        retiros.Fecha_Imputacion = fechaEditada;
                        retiros.Actualizar();
                    }

                    // Escribir el texto en la grilla
                    grdRetiros.set_Texto(f, c, a);

                    if (esRegistroNuevo)
                    {
                        // Activar la celda de la columna Suc en la fila actual
                        grdRetiros.ActivarCelda(f, c_Suc);
                    }
                    else
                    {
                        // Activar la celda de la columna Suc en la fila actual
                        grdRetiros.ActivarCelda(f + 1, c);

                    }
                }
                catch (Exception)
                {
                    // Manejar error de conversión de fecha
                    MessageBox.Show("Formato de fecha inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdRetiros.ErrorEnTxt();
                }
            }
            // Si la columna editada es Suc
            else if (c == c_Suc)
            {
                try
                {
                    int sucId = Convert.ToInt32(a);
                    if (sucId < 1000)
                    {

                        Sucursales sucursal = new Sucursales();
                        sucursal.ID = sucId;

                        if (sucursal.Existe())
                        {
                            // Escribir el valor en la grilla
                            grdRetiros.set_Texto(f, c, a);

                            // Activar la celda de la columna Emp
                            grdRetiros.ActivarCelda(f, c_Emp);

                            if (esRegistroNuevo)
                            {
                                // Si es un registro nuevo, buscar el primer empleado en la tabla dbEmpleados.dbo.Registro_Asistencias que tenga la sucursal seleccionada
                                Fichador fichador = new Fichador();
                                int empId = fichador.Fichadas_EnSuc(Convert.ToDateTime(grdRetiros.get_Texto(f, c_Fecha)), sucId);

                                // si se encontró un empleado, escribir su ID en la columna Emp
                                if (empId > 0)
                                {
                                    grdRetiros.set_Texto(f, c_Emp, empId);
                                    // Cargar los datos del empleado para obtener el nombre
                                    Empleados empleado = new Empleados();
                                    empleado.ID = empId;

                                    if (empleado.Existe())
                                    {
                                        // Escribir el nombre en la columna Nombre
                                        grdRetiros.set_Texto(f, c_Nombre, empleado.Nombre);
                                        // Activar la celda de la columna Tipo
                                        grdRetiros.ActivarCelda(f, c_Tipo);
                                        Mostrar_Sueldo();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"No se encontraron empleados para la sucursal {sucId} en la fecha {grdRetiros.get_Texto(f, c_Fecha)}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    grdRetiros.ErrorEnTxt();
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se encontró la sucursal {sucId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdRetiros.ErrorEnTxt();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Formato de sucursal inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdRetiros.ErrorEnTxt();
                }
            }
            // Si la columna editada es Emp
            else if (c == c_Emp)
            {
                try
                {
                    int empId = Convert.ToInt32(a);
                    Empleados empleado = new Empleados();
                    empleado.ID = empId;

                    if (empleado.Existe())
                    {
                        // Cargar los datos del empleado para obtener el nombre
                        empleado.Mostrar_Bajas = true;
                        var dtEmpleado = empleado.Datos($"Id={empId}");
                        if (dtEmpleado.Rows.Count > 0)
                        {
                            string nombreEmpleado = dtEmpleado.Rows[0]["Nombre"].ToString();

                            // Escribir el valor del empleado en la grilla
                            grdRetiros.set_Texto(f, c, a);

                            // Escribir el nombre en la columna Nombre
                            grdRetiros.set_Texto(f, c_Nombre, nombreEmpleado);

                            Mostrar_Sueldo();

                            // Activar la celda de la columna Tipo
                            grdRetiros.ActivarCelda(f, c_Tipo);
                        }

                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el empleado {empId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdRetiros.ErrorEnTxt();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Formato de empleado inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdRetiros.ErrorEnTxt();
                }
            }
            // si la columna es el tipo de retiro
            else if (c == c_Tipo)
            {
                try
                {
                    int tipoId = Convert.ToInt32(a);
                    if (retiros.Tipo.Existe(tipoId))
                    {
                        // Escribir el valor en la grilla
                        grdRetiros.set_Texto(f, c, a);

                        grdRetiros.set_Texto(f, c + 1, retiros.Tipo.Nombre);

                        // Activar la celda de la columna Importe
                        grdRetiros.ActivarCelda(f, Convert.ToByte(grdRetiros.get_ColIndex("Importe")));
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el tipo de retiro {tipoId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdRetiros.ErrorEnTxt();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Formato de tipo de retiro inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdRetiros.ErrorEnTxt();
                }
            }

            // Si se está editando la columna Importe
            else if (c == grdRetiros.get_ColIndex("Importe"))
            {
                try
                {
                    // Convertir el valor a decimal y escribirlo en la grilla
                    float importe = Convert.ToSingle(a);
                    grdRetiros.set_Texto(f, c, importe);

                    int empId = Convert.ToInt32(grdRetiros.get_Texto(f, c_Emp));
                    int sucId = Convert.ToInt32(grdRetiros.get_Texto(f, c_Suc));
                    int tipoId = Convert.ToInt32(grdRetiros.get_Texto(f, c_Tipo));

                    DateTime fecha = Convert.ToDateTime(grdRetiros.get_Texto(f, c_Fecha));

                    // Si es un registro nuevo, agregar una fila repitiendo los valores de fecha y suc
                    // activar la celda de la columna empleado para continuar
                    if (esRegistroNuevo)
                    {
                        // Enviar el dato
                        retiros.Id = 0; // Asignar un ID temporal para el nuevo registro
                        retiros.Fecha = fecha;
                        retiros.Fecha_Imputacion = fecha;
                        retiros.Sucursal.ID = sucId;
                        retiros.Empleado.ID = empId;
                        retiros.Tipo.ID = tipoId;
                        retiros.Importe = importe;
                        retiros.Actualizar();

                        grdRetiros.set_Texto(f, 0, retiros.Id);

                        grdRetiros.AgregarFila();
                        grdRetiros.set_Texto(f + 1, c_Fecha, grdRetiros.get_Texto(f, c_Fecha));
                        grdRetiros.set_Texto(f + 1, c_Suc, grdRetiros.get_Texto(f, c_Suc));

                        // buscar el proximo empleado en la sucursal
                        Fichador fichador = new Fichador();
                        empId = fichador.Fichadas_EnSuc(fecha, sucId, empId);
                        if (empId > 0)
                        {
                            grdRetiros.set_Texto(f + 1, c_Emp, empId);
                            // Cargar los datos del empleado para obtener el nombre
                            Empleados empleado = new Empleados();
                            empleado.ID = empId;

                            if (empleado.Existe())
                            {
                                grdRetiros.set_Texto(f + 1, c_Nombre, empleado.Nombre);
                                grdRetiros.set_Texto(f + 1, c_Tipo, tipoId);
                                grdRetiros.set_Texto(f + 1, c_Tipo + 1, grdRetiros.get_Texto(f, c_Tipo + 1));
                                grdRetiros.ActivarCelda(f + 1, c); // Activar la celda de Importe
                            }
                        }
                        else
                        {
                            grdRetiros.ActivarCelda(f + 1, c_Emp);
                        }
                        total();
                    }
                    else
                    {
                        retiros.Id = (Convert.ToInt32(grdRetiros.get_Texto(f, 0)));
                        retiros.Fecha = fecha;
                        retiros.Fecha_Imputacion = fecha;
                        retiros.Sucursal.ID = sucId;
                        retiros.Empleado.ID = empId;
                        retiros.Tipo.ID = tipoId;
                        retiros.Importe = importe;
                        retiros.Actualizar();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Formato de importe inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdRetiros.ErrorEnTxt();
                }
            }
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            grdRetiros.Rows = 1;
            grdRetiros.Rows = 2;
            total();
        }

        private void grdRetiros_KeyUp(object sender, short e)
        {
            bool esRegistroNuevo = (grdRetiros.Row == grdRetiros.Rows - 1);
            // Si se presiona F1 y es un registro nuevo, mostrar el buscador de empleados
            if (esRegistroNuevo)
            {
                if (e == 112)
                {
                    // Mostrar el buscador con empleados                            
                    frmAyuda_Generico frmAyuda = new frmAyuda_Generico {
                        Tabla = "dbEmpleados2.dbo.Empleados",
                        Vista = "dbEmpleados2.dbo.Empleados",
                        Filtro = "ISNULL(Baja, 0) = '1/1/1900'",
                    };
                    frmAyuda.ShowDialog();


                    // Obtener el ID del empleado seleccionado
                    int empId = frmAyuda.ID_Seleccionado;
                    int col_Actual = grdRetiros.Col;

                    if (empId > 0)
                    {
                        grdRetiros_Editado(Convert.ToInt16(grdRetiros.Row), Convert.ToInt16(grdRetiros.get_ColIndex("Emp")), empId);
                    }
                    grdRetiros.ActivarCelda(grdRetiros.Row, col_Actual);
                }
            }
            else
            {
                if (e == 46)
                {
                    int id = Convert.ToInt32(grdRetiros.get_Texto(grdRetiros.Row, 0));
                    if (id > 0)
                    {
                        if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            retiros.Id = id;
                            retiros.Borrar();
                            grdRetiros.BorrarFila(grdRetiros.Row);
                            grdRetiros.ActivarCelda();
                            total();
                            lblSueldo.Text = "";
                        }
                    }
                }
            }
        }

        private void grdRetiros_KeyPress(object sender, short e)
        {
            int f = grdRetiros.Row;
            bool esRegistroNuevo = (f == grdRetiros.Rows - 1);

            // si la tecla presionada es Enter y la celda activa es la última fila
            if (e == 13)
            {
                if (grdRetiros.Col == 5 || grdRetiros.Col == 8)
                {
                    SendKeys.Send("{ESC}"); // Simula el escape para salir de la celda activa
                    if (esRegistroNuevo)
                    {
                        int sucId = Convert.ToInt32(grdRetiros.get_Texto(f, grdRetiros.get_ColIndex("Suc")));
                        int empId = Convert.ToInt32(grdRetiros.get_Texto(f, grdRetiros.get_ColIndex("Emp")));

                        // Si es un registro nuevo, buscar el primer empleado en la tabla dbEmpleados.dbo.Registro_Asistencias que tenga la sucursal seleccionada
                        Fichador fichador = new Fichador();
                        empId = fichador.Fichadas_EnSuc(Convert.ToDateTime(grdRetiros.get_Texto(f, 1)), sucId, empId);

                        // si se encontró un empleado, escribir su ID en la columna Emp
                        if (empId > 0)
                        {
                            grdRetiros.set_Texto(f, 3, empId);
                            // Cargar los datos del empleado para obtener el nombre
                            Empleados empleado = new Empleados();
                            empleado.ID = empId;
                            var dtEmpleado = empleado.Datos($"Id={empId}");
                            if (dtEmpleado.Rows.Count > 0)
                            {
                                string nombreEmpleado = dtEmpleado.Rows[0]["Nombre"].ToString();
                                // Escribir el nombre en la columna Nombre
                                grdRetiros.set_Texto(f, 4, nombreEmpleado);
                                Mostrar_Sueldo();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se encontraron empleados para la sucursal {sucId} en la fecha {grdRetiros.get_Texto(f, 1)}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdRetiros.ErrorEnTxt();
                        }
                    }
                }
            }
            // tecla espacio
            else
            {
                if (e == 32)
                {
                    if (esRegistroNuevo)
                    {
                        int suc = Convert.ToInt32(grdRetiros.get_Texto(f, grdRetiros.get_ColIndex("Suc")));
                        Sucursales sucursal = new Sucursales();
                        sucursal.ID = suc;
                        sucursal.Siguiente();
                        suc = sucursal.ID;

                        grdRetiros.set_Texto(f, grdRetiros.get_ColIndex("Suc"), sucursal.ID);
                        grdRetiros.set_Texto(f, grdRetiros.get_ColIndex("Suc") + 1, sucursal.Nombre);

                        SendKeys.Send("{ENTER}"); // Simula el Enter para buscar el empleado siguiente
                    }
                }
            }
        }

        private void Cargar_Datos()
        {
            Cursor = Cursors.WaitCursor;
            

            int tipo = 0;
            if (lstTipos.SelectedIndex != -1)
            {
                Herramientas.Herramientas h = new Herramientas.Herramientas();
                tipo = h.Codigo_Seleccionado(lstTipos.Text);
            }

            string sucursal = cSuc.Cadena("Suc");

            grdRetiros.MostrarDatos(retiros.Datos_Semana(cFecha.Cadena("CAST(Semana AS DATE)"), sucursal, tipo), true, true);
            grdRetiros.AutosizeAll();
            grdRetiros.set_ColW(0, 0);
            grdRetiros.set_ColW(1, 60);
            grdRetiros.set_ColW(4, 200);
            grdRetiros.set_ColW(7, 200);
            grdRetiros.set_ColW(8, 100);

            // Darle formato numero a la columna Importe y que sea negrita
            grdRetiros.Columnas[grdRetiros.get_ColIndex("Fecha")].Format = "dd/MM/yy";
            grdRetiros.Columnas[grdRetiros.get_ColIndex("Importe")].Format = "N2";
            grdRetiros.Columnas[grdRetiros.get_ColIndex("Importe")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            total();

            grdRetiros.ActivarCelda(grdRetiros.Rows - 1, Convert.ToByte(grdRetiros.get_ColIndex("Fecha")));

            Cursor = Cursors.Default;
        }

        private void total()
        {
            double total = 0;
            total = grdRetiros.SumarCol(8, false);
            lblTotal.Text = $"Total: {total:N2}";
        }

        private void Mostrar_Sueldo()
        {
            int empId = Convert.ToInt32(grdRetiros.get_Texto(grdRetiros.Row, grdRetiros.get_ColIndex("Emp")));
            if (empId > 0)
            {
                Sueldos sueldos = new Sueldos {
                    Empleado = new Empleados { ID = empId },
                    Fecha = Convert.ToDateTime(grdRetiros.get_Texto(grdRetiros.Row, grdRetiros.get_ColIndex("Fecha")))                    
                };
                sueldos.Tipo.ID = Convert.ToInt32(grdRetiros.get_Texto(grdRetiros.Row, grdRetiros.get_ColIndex("Tipo")));
                if (sueldos.Tipo.ID == 0)
                {
                    sueldos.Tipo.ID = 1; // Por defecto, si no se selecciona un tipo, se usa el tipo 1
                }
                sueldos.Buscar();

                lblSueldo.Text = ""; // Limpiar el label antes de mostrar el nuevo sueldo
                if (sueldos.Sueldo > 0)
                {
                    lblSueldo.Text = $"{grdRetiros.get_Texto(grdRetiros.Row, grdRetiros.get_ColIndex("Nombre"))} - Sueldo Mes: {sueldos.Sueldo:N2} - Sueldo Semana: {sueldos.Sueldo / 30 * 7:N2}";
                } 
            }
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}
