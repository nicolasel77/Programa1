
namespace Programa1.Datos
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmSucursales : Form
    {
        private TipoSucursales tipoSucursales = new TipoSucursales();
        private Sucursales Sucs = new Sucursales();
        private Partidos Partidos = new Partidos();
        private Localidades Localidades = new Localidades();

        
        public frmSucursales()
        {
            InitializeComponent();

        }

        private void FrmSucursales_Load(object sender, EventArgs e)
        {
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };

            grdTipo.TeclasManejadas = n;
            grdPartidos.TeclasManejadas = n;
            grdLocalidades.TeclasManejadas = n;
            grdSucursales.TeclasManejadas = n;


            
            //Datos
            grdTipo.MostrarDatos(tipoSucursales.Datos(), true);
                        
            grdPartidos.MostrarDatos(Partidos.Datos(), true);

            grdLocalidades.MostrarDatos(Localidades.Datos(), true);

            grdSucursales.MostrarDatos(Sucs.Datos(), true);

            //Formato
            grdTipo.set_ColW(0, 40);

            grdPartidos.set_ColW(0, 40);

            grdLocalidades.set_ColW(0, 40);

            grdSucursales.set_ColW(0, 40);
            
        }


        #region " Tipo Sucursales "

        private void GrdTipo_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdTipo.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        tipoSucursales.Id = Convert.ToInt32(a);
                        if (tipoSucursales.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdTipo.ErrorEnTxt();
                        }
                        else
                        {
                            grdTipo.set_Texto(f, c, a);
                            tipoSucursales.Agregar();
                            grdTipo.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipoSucursales.Id = i;
                        tipoSucursales.Nombre = a.ToString();
                        grdTipo.set_Texto(f, c, a);
                        tipoSucursales.Actualizar();
                        grdTipo.AgregarFila();
                        grdTipo.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void GrdTipo_CambioFila(short Fila)
        {
            tipoSucursales.Id = Convert.ToInt32(grdTipo.get_Texto(Fila, 0));
            tipoSucursales.Nombre = grdTipo.get_Texto(Fila, 1).ToString();
        }

        private void GrdTipo_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdTipo.Row;
                if (f == grdTipo.Rows - 1)
                {
                    grdTipo.ActivarCelda(1, grdTipo.Col);
                }
                else
                {
                    grdTipo.ActivarCelda(f + 1, grdTipo.Col);
                }
            }
        }

        private void GrdTipo_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdTipo.get_Texto(grdTipo.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdTipo.get_Texto(grdTipo.Row, 0)) != 0)
                    {
                        tipoSucursales.Id = Convert.ToInt32(grdTipo.get_Texto(grdTipo.Row, 0));
                        tipoSucursales.Borrar();
                        grdTipo.BorrarFila(grdTipo.Row);
                    }

                }
            }
        }

        #endregion

        #region " Partidos "

        private void grdPartidos_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdPartidos.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        Partidos.Id = Convert.ToInt32(a);
                        if (Partidos.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdPartidos.ErrorEnTxt();
                        }
                        else
                        {
                            grdPartidos.set_Texto(f, c, a);
                            Partidos.Agregar();
                            grdPartidos.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdPartidos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Partidos.Id = i;
                        Partidos.Nombre = a.ToString();
                        grdPartidos.set_Texto(f, c, a);
                        Partidos.Actualizar();
                        grdPartidos.AgregarFila();
                        grdPartidos.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void grdPartidos_CambioFila(short Fila)
        {
            Partidos.Id = Convert.ToInt32(grdPartidos.get_Texto(Fila, 0));
            Partidos.Nombre = grdPartidos.get_Texto(Fila, 1).ToString();
        }

        private void grdPartidos_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdPartidos.Row;
                if (f == grdPartidos.Rows - 1)
                {
                    grdPartidos.ActivarCelda(1, grdPartidos.Col);
                }
                else
                {
                    grdPartidos.ActivarCelda(f + 1, grdPartidos.Col);
                }
            }
        }

        private void grdPartidos_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdPartidos.get_Texto(grdPartidos.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdPartidos.get_Texto(grdPartidos.Row, 0)) != 0)
                    {
                        Partidos.Id = Convert.ToInt32(grdPartidos.get_Texto(grdPartidos.Row, 0));
                        Partidos.Borrar();
                        grdPartidos.BorrarFila(grdPartidos.Row);
                    }

                }
            }
        }

        #endregion

        #region " Localidades "

        private void grdLocalidades_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdLocalidades.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        Localidades.Id = Convert.ToInt32(a);
                        if (Localidades.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdLocalidades.ErrorEnTxt();
                        }
                        else
                        {
                            grdLocalidades.set_Texto(f, c, a);
                            Localidades.Agregar();
                            grdLocalidades.ActivarCelda(f, 1);
                        }
                    }
                    break;
                case 1: // Id_Partido
                    Localidades.Partido.Id = Convert.ToInt32(a);
                    if (Partidos.Existe(Convert.ToInt32(a)) != true)
                    {
                        Mensaje($"No se encontró el Partido '{a.ToString()}'.");
                        grdLocalidades.ErrorEnTxt();
                    }
                    else
                    {
                        grdLocalidades.set_Texto(f, c, a);
                        Localidades.Actualizar();
                        grdLocalidades.ActivarCelda(f, 2);
                    }
                    
                    break;
                case 2: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdLocalidades.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Localidades.Id = i;
                        Localidades.Nombre = a.ToString();
                        grdLocalidades.set_Texto(f, c, a);
                        Localidades.Actualizar();
                        grdLocalidades.AgregarFila();
                        grdLocalidades.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void grdLocalidades_CambioFila(short Fila)
        {
            Localidades.Id = Convert.ToInt32(grdLocalidades.get_Texto(Fila, 0));
            Localidades.Nombre = grdLocalidades.get_Texto(Fila, 1).ToString();
        }

        private void grdLocalidades_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdLocalidades.Row;
                if (f == grdLocalidades.Rows - 1)
                {
                    grdLocalidades.ActivarCelda(1, grdLocalidades.Col);
                }
                else
                {
                    grdLocalidades.ActivarCelda(f + 1, grdLocalidades.Col);
                }
            }
        }

        private void grdLocalidades_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdLocalidades.get_Texto(grdLocalidades.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdLocalidades.get_Texto(grdLocalidades.Row, 0)) != 0)
                    {
                        Localidades.Id = Convert.ToInt32(grdLocalidades.get_Texto(grdLocalidades.Row, 0));
                        Localidades.Borrar();
                        grdLocalidades.BorrarFila(grdLocalidades.Row);
                    }

                }
            }
        }

        #endregion

        #region " Sucursales 

        private void GrdSucursales_Editado(short f, short c, object a)
        {
            // 0 int Id 
            // 1 string Nombre 
            // 2 int Tipo 
            // 3 bool Ver
            // 4 bool Propio
            // 5 string Titular
            // 6 string Direccion
            // 7 string Alias
            // 8 int Id_Localidad
            // 9 string Balanza
            // 10 string CUIT
            int i = Convert.ToInt32(grdSucursales.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de una sucursal existente.");
                    }
                    else
                    {
                        Sucs.Id = Convert.ToInt32(a);
                        if (Sucs.Existe() == true)
                        {
                            Mensaje($"El Sucursal '{a.ToString()}' ya existe.");
                            grdSucursales.ErrorEnTxt();
                        }
                        else
                        {
                            grdSucursales.set_Texto(f, c, a);
                            Sucs.Agregar();
                            grdSucursales.AgregarFila();
                            grdSucursales.ActivarCelda(f, 1);
                        }
                    }
                    break;
                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        Sucs.Nombre = a.ToString();
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 2);
                    }
                    break;
                case 2: // Tipo
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        Sucs.Tipo.Id = Convert.ToInt32(a);
                        if (Sucs.Tipo.Existe() == true)
                        {
                            grdSucursales.set_Texto(f, c, a);
                            Sucs.Actualizar();
                            grdSucursales.ActivarCelda(f, 3);
                        }
                        else
                        {
                            Mensaje($"No se encontro el tipo '{a.ToString()}'.");
                            grdSucursales.ErrorEnTxt();
                        }
                    }
                    break;
                
                case 3: // Ver
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        Sucs.Ver = bool.Parse(a.ToString());
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 4);
                    }
                    break;
                case 4: // Propio
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        Sucs.Propio = bool.Parse(a.ToString());
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 5);
                    }
                    break;
                case 5: // Titular
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Titular = a.ToString();
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 6);
                    }
                    break;
                case 6: // Direccion
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Direccion = a.ToString();
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f , 7);
                    }
                    break;
                case 7: // Alias
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Alias = a.ToString();
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 8);
                    }
                    break;
                case 8: // Id_Localidad
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Localidad.Id = Convert.ToInt32(a);
                        if (Sucs.Localidad.Existe() == true)
                        {
                            Sucs.Actualizar();
                            grdSucursales.ActivarCelda(f, 9);
                        }
                        else
                        {
                            Mensaje($"No se encontro la localidad '{a.ToString()}'.");
                            grdSucursales.ErrorEnTxt();
                        }
                    }
                    break;
                case 9: // Balanza
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.Balanza = a.ToString();
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f, 10);
                    }
                    break;

                case 10: // CUIT
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSucursales.ActivarCelda(f, 0);
                    }
                    else
                    {
                        Sucs.Id = i;
                        grdSucursales.set_Texto(f, c, a);
                        Sucs.CUIT = a.ToString();
                        Sucs.Actualizar();
                        grdSucursales.ActivarCelda(f + 1, 0);
                    }
                    break;

            }
        }

        private void GrdSucursales_KeyPress(object sender, short e)
        {

        }

        private void GrdSucursales_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el Sucursal '{grdSucursales.get_Texto(grdSucursales.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdSucursales.get_Texto(grdSucursales.Row, 0)) != 0)
                    {
                        Sucs.Id = Convert.ToInt32(grdSucursales.get_Texto(grdSucursales.Row, 0));
                        Sucs.Borrar();
                        grdSucursales.BorrarFila(grdSucursales.Row);
                    }

                }
            }
        }

        private void GrdSucursales_CambioFila(short Fila)
        {
            // 0 int Id 
            // 1 string Nombre 
            // 2 int Tipo 
            // 3 bool Ver
            // 4 bool Propio
            // 5 string Titular
            // 6 string Direccion
            // 7 string Alias
            // 8 int Id_Localidad
            // 9 string Balanza
            // 10 string CUIT
            Sucs.Id = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
            Sucs.Nombre = grdSucursales.get_Texto(Fila, 1).ToString();
            Sucs.Tipo.Id = Convert.ToInt32(grdSucursales.get_Texto(Fila, 2));
            Sucs.Ver = bool.Parse(grdSucursales.get_Texto(Fila, 3).ToString());
            Sucs.Propio = bool.Parse(grdSucursales.get_Texto(Fila, 4).ToString());
            Sucs.Titular = grdSucursales.get_Texto(Fila, 5).ToString();
            Sucs.Direccion = grdSucursales.get_Texto(Fila, 6).ToString();
            Sucs.Alias = grdSucursales.get_Texto(Fila, 7).ToString();
            Sucs.Localidad.Id = Convert.ToInt32(grdSucursales.get_Texto(Fila, 8));
            Sucs.Balanza = grdSucursales.get_Texto(Fila, 9).ToString();
            Sucs.CUIT = grdSucursales.get_Texto(Fila, 10).ToString();

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdSucursales.MostrarDatos(Sucs.Datos($"Nombre like '%{i}%' OR Id={i}"));
                }
                else
                {
                    grdSucursales.MostrarDatos(Sucs.Datos($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdSucursales.MostrarDatos(Sucs.Datos());
            }

        }

        #endregion 


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


    }
}
