namespace Programa1.Datos
{
    using Programa1.DB;
    using Programa1.DB.Proveedores;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmProveedores : Form
    {
        private TipoProveedores tipoProveedores = new TipoProveedores();
        private Proveedores provs = new Proveedores();
        private DataTable dt;

        public frmProveedores()
        {
            InitializeComponent();
            provs.Mostrar_Ocultos = true;
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            //Tipo proveedor
            //Datos
            dt = tipoProveedores.Datos();
            grdTipo.MostrarDatos(dt, true);
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdTipo.TeclasManejadas = n;

            //Formato
            grdTipo.set_ColW(0, 40);
            grdTipo.set_ColW(1, 200);
            //Proveedores
            //Datos
            dt = provs.Datos();
            grdProveedores.MostrarDatos(dt, true);
            //Formato
            grdProveedores.set_ColW(0, 40);
            grdProveedores.set_ColW(1, 40);
            grdProveedores.set_ColW(2, 200);
            grdProveedores.TeclasManejadas = n;
        }


        #region " Tipo Proveedores "

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
                        tipoProveedores.ID = Convert.ToInt32(a);
                        if (tipoProveedores.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdTipo.ErrorEnTxt();
                        }
                        else
                        {
                            grdTipo.set_Texto(f, c, a);
                            tipoProveedores.Agregar();
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
                        tipoProveedores.ID = i;
                        tipoProveedores.Nombre = a.ToString();
                        grdTipo.set_Texto(f, c, a);
                        tipoProveedores.Actualizar();
                        if (grdTipo.EsUltimaFila()) { grdTipo.AgregarFila(); }
                        grdTipo.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void GrdTipo_CambioFila(short Fila)
        {
            tipoProveedores.ID = Convert.ToInt32(grdTipo.get_Texto(Fila, 0));
            tipoProveedores.Nombre = grdTipo.get_Texto(Fila, 1).ToString();
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
                        tipoProveedores.ID = Convert.ToInt32(grdTipo.get_Texto(grdTipo.Row, 0));
                        tipoProveedores.Borrar();
                        grdTipo.BorrarFila(grdTipo.Row);
                    }

                }
            }
        }

        #endregion


        #region " Proveedores 

        private void GrdProveedores_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdProveedores.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        provs.Id = Convert.ToInt32(a);
                        if (provs.Existe() == true)
                        {
                            Mensaje($"El proveedor '{a.ToString()}' ya existe.");
                            grdProveedores.ErrorEnTxt();
                        }
                        else
                        {
                            grdProveedores.set_Texto(f, c, a);
                            provs.Agregar();
                            grdProveedores.AgregarFila();
                            grdProveedores.ActivarCelda(f, 1);
                        }
                    }
                    break;
                case 1: // Tipo
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProveedores.ActivarCelda(f, 0);
                    }
                    else
                    {
                        provs.Id = i;
                        provs.Tipo.ID = Convert.ToInt32(a);
                        if (provs.Tipo.Existe()  == true)
                        {
                            grdProveedores.set_Texto(f, c, a);
                            provs.Actualizar();
                            grdProveedores.ActivarCelda(f, 2);
                        }
                        else
                        {
                            Mensaje($"No se encontro el tipo '{a.ToString()}'.");
                            grdProveedores.ErrorEnTxt();
                        }
                        
                    }
                    break;
                case 2: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProveedores.ActivarCelda(f, 0);
                    }
                    else
                    {
                        provs.Id = i;
                        provs.Nombre = a.ToString();
                        grdProveedores.set_Texto(f, c, a);
                        provs.Actualizar();
                        grdProveedores.ActivarCelda(f, 3);
                    }
                    break;
                case 3: // Ver
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProveedores.ActivarCelda(f, 0);
                    }
                    else
                    {
                        provs.Id = i;
                        provs.Ver = bool.Parse(a.ToString());
                        grdProveedores.set_Texto(f, c, a);
                        provs.Actualizar();
                        grdProveedores.ActivarCelda(f + 1, 0);
                    }
                    break;
                
            }
        }

        private void GrdProveedores_KeyPress(object sender, short e)
        {

        }

        private void GrdProveedores_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el proveedor '{grdProveedores.get_Texto(grdProveedores.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdProveedores.get_Texto(grdProveedores.Row, 0)) != 0)
                    {
                        provs.Id = Convert.ToInt32(grdProveedores.get_Texto(grdProveedores.Row, 0));
                        provs.Borrar();
                        grdProveedores.BorrarFila(grdProveedores.Row);
                    }

                }
            }
        }

        private void GrdProveedores_CambioFila(short Fila)
        {
            // 0 int Id 
            // 1 int Tipo 
            // 2 string Nombre 
            // 3 bool Ver
            
            provs.Id = Convert.ToInt32(grdProveedores.get_Texto(Fila, 0));
            provs.Tipo.ID = Convert.ToInt32(grdProveedores.get_Texto(Fila, 1));
            provs.Nombre = grdProveedores.get_Texto(Fila, 2).ToString();
            provs.Ver = bool.Parse(grdProveedores.get_Texto(Fila, 3).ToString());
            
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdProveedores.MostrarDatos(provs.Datos($"Nombre like '%{i}%' OR Id={i}"));
                }
                else
                {
                    grdProveedores.MostrarDatos(provs.Datos($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdProveedores.MostrarDatos(provs.Datos());
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
