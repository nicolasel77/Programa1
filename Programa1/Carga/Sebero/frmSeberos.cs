namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmSeberos : Form
    {
        private Seberos sebero = new Seberos();
        private DataTable dt;

        public frmSeberos()
        {
            InitializeComponent();

        }

        private void FrmSeberos_Load(object sender, EventArgs e)
        {
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };


            //Seberos
            //Datos
            dt = sebero.Datos();
            grdSeberos.MostrarDatos(dt, true);
            //Formato
            grdSeberos.set_ColW(0, 40);
            grdSeberos.set_ColW(1, 200);
            grdSeberos.TeclasManejadas = n;
        }


        #region " Seberos 

        private void GrdSeberos_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdSeberos.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        sebero.Id = Convert.ToInt32(a);
                        if (sebero.Existe() == true)
                        {
                            Mensaje($"El proveedor '{a.ToString()}' ya existe.");
                            grdSeberos.ErrorEnTxt();
                        }
                        else
                        {
                            grdSeberos.set_Texto(f, c, a);
                            sebero.Agregar();
                            grdSeberos.AgregarFila();
                            grdSeberos.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdSeberos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        sebero.Id = i;
                        sebero.Nombre = a.ToString();
                        grdSeberos.set_Texto(f, c, a);
                        sebero.Actualizar();
                        grdSeberos.ActivarCelda(f + 1, 1);
                    }
                    break;
            }
        }

                    
        private void GrdSeberos_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el proveedor '{grdSeberos.get_Texto(grdSeberos.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdSeberos.get_Texto(grdSeberos.Row, 0)) != 0)
                    {
                        sebero.Id = Convert.ToInt32(grdSeberos.get_Texto(grdSeberos.Row, 0));
                        sebero.Borrar();
                        grdSeberos.BorrarFila(grdSeberos.Row);
                    }

                }
            }
        }

        private void GrdSeberos_CambioFila(short Fila)
        {
            // 0 int Id 
            // 1 string Nombre 

            sebero.Id = Convert.ToInt32(grdSeberos.get_Texto(Fila, 0));
            sebero.Nombre = grdSeberos.get_Texto(Fila, 2).ToString();

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
