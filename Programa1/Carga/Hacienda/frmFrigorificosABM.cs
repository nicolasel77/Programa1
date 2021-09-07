namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmFriorificosABM : Form
    {
        private Frigorificos frigorificos = new Frigorificos();
        private Consignatarios cons = new Consignatarios();
        private DataTable dt;

        public frmFriorificosABM()
        {
            InitializeComponent();
            cons.Mostrar_Ocultos = true;
            //Tipo proveedor
            //Datos
            dt = frigorificos.Datos();
            grdfrigorificos.MostrarDatos(dt, true);
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdfrigorificos.TeclasManejadas = n;

            //Formato
            grdfrigorificos.set_ColW(0, 40);
            grdfrigorificos.set_ColW(1, 200);
            //Consignatarios
            //Datos
            dt = cons.Datos();
            grdConsignatarios.MostrarDatos(dt, true);
            //Formato
            grdConsignatarios.set_ColW(0, 40);
            grdConsignatarios.set_ColW(1, 200);
            grdConsignatarios.set_ColW(2, 70);
            grdConsignatarios.TeclasManejadas = n;
        }
      

        #region " Tipo Consignatarios "
        private void grdfrigorificos_Editado_1(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdfrigorificos.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        frigorificos.ID = Convert.ToInt32(a);
                        if (frigorificos.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdfrigorificos.ErrorEnTxt();
                        }
                        else
                        {
                            grdfrigorificos.set_Texto(f, c, a);
                            frigorificos.Agregar();
                            grdfrigorificos.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdfrigorificos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        frigorificos.ID = i;
                        frigorificos.Nombre = a.ToString();
                        grdfrigorificos.set_Texto(f, c, a);
                        frigorificos.Actualizar();
                        if (grdfrigorificos.EsUltimaFila()) { grdfrigorificos.AgregarFila(); }
                        grdfrigorificos.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }
        private void grdfrigorificos_CambioFila_1(short Fila)
        {
        frigorificos.ID = Convert.ToInt32(grdfrigorificos.get_Texto(Fila, 0));
            frigorificos.Nombre = grdfrigorificos.get_Texto(Fila, 1).ToString();
        }

        private void grdfrigorificos_KeyPress_1(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdfrigorificos.Row;
                if (f == grdfrigorificos.Rows - 1)
                {
                    grdfrigorificos.ActivarCelda(1, grdfrigorificos.Col);
                }
                else
                {
                    grdfrigorificos.ActivarCelda(f + 1, grdfrigorificos.Col);
                }
            }
        }

        #endregion

        #region " Consignatarios 
        private void grdConsignatarios_Editado_1(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdConsignatarios.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        cons.Id = Convert.ToInt32(a);
                        if (cons.Existe() == true)
                        {
                            Mensaje($"El proveedor '{a.ToString()}' ya existe.");
                            grdConsignatarios.ErrorEnTxt();
                        }
                        else
                        {
                            grdConsignatarios.set_Texto(f, c, a);
                            cons.Agregar();
                            grdConsignatarios.AgregarFila();
                            grdConsignatarios.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdConsignatarios.ActivarCelda(f, 0);
                    }
                    else
                    {
                        cons.Id = i;
                        cons.Nombre = a.ToString();
                        grdConsignatarios.set_Texto(f, c, a);
                        cons.Actualizar();
                        grdConsignatarios.ActivarCelda(f, 3);
                    }
                    break;

                case 2: // Id_Frigorifico
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdConsignatarios.ActivarCelda(f, 0);
                    }
                    else
                    {
                        cons.ID = i;
                        cons.Id_Frigorifico = Convert.ToInt32(a);
                        grdConsignatarios.set_Texto(f, c, a);
                        cons.Actualizar();
                        grdConsignatarios.ActivarCelda(f+1, 0);
                    }
                    break;
            }
        }

        private void grdConsignatarios_CambioFila_1(short Fila)
        {
            // 0 int Id 
            // 1 string Nombre 
            // 2 int ID_Frigorifico

            cons.Id = Convert.ToInt32(grdConsignatarios.get_Texto(Fila, 0));
            cons.Nombre = grdConsignatarios.get_Texto(Fila, 1).ToString();
            cons.Id_Frigorifico = Convert.ToInt32(grdConsignatarios.get_Texto(Fila, 2));
        }
        #endregion 

        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }

        private void tiMensaje_Tick_1(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }
        #endregion

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdConsignatarios.MostrarDatos(cons.Datos($"Nombre like '%{i}%' OR Id={i}"));
                }
                else
                {
                    grdConsignatarios.MostrarDatos(cons.Datos($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdConsignatarios.MostrarDatos(cons.Datos());
            }
        }
    }
}
