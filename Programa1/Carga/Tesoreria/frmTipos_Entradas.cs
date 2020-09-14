namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmTipos_Entradas : Form
    {
        private Tipos_Entradas tipos_e = new Tipos_Entradas();

        private DataTable dt;

        public frmTipos_Entradas()
        {
            InitializeComponent();
        }

        private void FrmTipos_Entradas_Load(object sender, EventArgs e)
        {
            //Grupo
            //Datos
            dt = tipos_e.SubTipo.Datos();
            grdGrupo.MostrarDatos(dt, true);
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdGrupo.TeclasManejadas = n;

            //Formato
            grdGrupo.set_ColW(0, 40);

            //Tipos_Entradas
            //Datos
            dt = tipos_e.Datos();
            grdTipos_Entradas.MostrarDatos(dt, true);
            //Formato
            grdTipos_Entradas.set_ColW(0, 50);
            grdTipos_Entradas.set_ColW(1, 150);
            grdTipos_Entradas.TeclasManejadas = n;
        }


        #region " Grupos_Entradas "

        private void GrdGrupo_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdGrupo.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        tipos_e.SubTipo.Id = Convert.ToInt32(a);
                        if (tipos_e.SubTipo.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdGrupo.ErrorEnTxt();
                        }
                        else
                        {
                            grdGrupo.set_Texto(f, c, a);
                            tipos_e.SubTipo.Agregar();
                            grdGrupo.ActivarCelda(f, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdGrupo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipos_e.SubTipo.Id = i;
                        tipos_e.SubTipo.Nombre = a.ToString();
                        grdGrupo.set_Texto(f, c, a);
                        tipos_e.SubTipo.Actualizar();
                        grdGrupo.ActivarCelda(f, 2);
                    }
                    break;
                case 2: // Tabla
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdGrupo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipos_e.SubTipo.Tabla = a.ToString();
                        grdGrupo.set_Texto(f, c, a);
                        tipos_e.SubTipo.Actualizar();
                        if (grdGrupo.EsUltimaF() == true) { grdGrupo.AgregarFila(); }
                        grdGrupo.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void GrdGrupo_CambioFila(short Fila)
        {
            tipos_e.SubTipo.Id = Convert.ToInt32(grdGrupo.get_Texto(Fila, 0));
            tipos_e.SubTipo.Nombre = grdGrupo.get_Texto(Fila, 1).ToString();
        }

        private void GrdGrupo_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdGrupo.Row;
                if (f == grdGrupo.Rows - 1)
                {
                    grdGrupo.ActivarCelda(1, grdGrupo.Col);
                }
                else
                {
                    grdGrupo.ActivarCelda(f + 1, grdGrupo.Col);
                }
            }
        }

        private void GrdGrupo_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdGrupo.get_Texto(grdGrupo.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, 0)) != 0)
                    {
                        tipos_e.SubTipo.Id = Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, 0));
                        tipos_e.SubTipo.Borrar();
                        grdGrupo.BorrarFila(grdGrupo.Row);
                    }

                }
            }
        }

        #endregion


        #region " Tipos_Entradas "

        private void GrdTipos_Entradas_Editado(short f, short c, object a)
        {
            // 0 int    Id_Tipo 
            // 1 string Nombre 
            // 2 int    Grupo 
            // 3 bool   Es_Entrega

            int i = Convert.ToInt32(grdTipos_Entradas.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        tipos_e.Id_Tipo = Convert.ToInt32(a);
                        if (tipos_e.Existe() == true)
                        {
                            Mensaje($"El producto '{a.ToString()}' ya existe.");
                            grdTipos_Entradas.ErrorEnTxt();
                        }
                        else
                        {
                            grdTipos_Entradas.set_Texto(f, c, a);
                            tipos_e.Agregar();
                            if (grdTipos_Entradas.EsUltimaF() == true) { grdTipos_Entradas.AgregarFila(); }
                            grdTipos_Entradas.ActivarCelda(f, 1);
                        }
                    }
                    break;
                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipos_Entradas.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipos_e.Id_Tipo = i;
                        tipos_e.Nombre = a.ToString();
                        grdTipos_Entradas.set_Texto(f, c, a);
                        tipos_e.Actualizar();
                        grdTipos_Entradas.ActivarCelda(f, 2);
                    }
                    break;
                case 2: // Grupo
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipos_Entradas.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipos_e.Id_Tipo = i;
                        tipos_e.SubTipo.Id = Convert.ToInt32(a);
                        if (tipos_e.SubTipo.Existe() == true)
                        {
                            grdTipos_Entradas.set_Texto(f, c, a);
                            grdTipos_Entradas.set_Texto(f, c + 1, tipos_e.SubTipo.Nombre);
                            tipos_e.Actualizar();
                            grdTipos_Entradas.ActivarCelda(f, 3);
                        }
                        else
                        {
                            Mensaje($"No se encontro el grupo '{a.ToString()}'.");
                            grdTipos_Entradas.ErrorEnTxt();
                        }
                    }
                    break;
                case 3: // Es_Entrega
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipos_Entradas.ActivarCelda(f, 0);
                    }
                    else
                    {
                        tipos_e.Id_Tipo = i;
                        tipos_e.Es_Entrega = bool.Parse(a.ToString());
                        grdTipos_Entradas.set_Texto(f, c, a);
                        tipos_e.Actualizar();
                        if (grdTipos_Entradas.EsUltimaF() == true) { grdTipos_Entradas.AgregarFila(); }
                        grdTipos_Entradas.ActivarCelda(f + 1, 0);
                    }
                    break;

            }
        }

        private void GrdTipos_Entradas_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el producto '{grdTipos_Entradas.get_Texto(grdTipos_Entradas.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdTipos_Entradas.get_Texto(grdTipos_Entradas.Row, 0)) != 0)
                    {
                        tipos_e.Id_Tipo = Convert.ToInt32(grdTipos_Entradas.get_Texto(grdTipos_Entradas.Row, 0));
                        tipos_e.Borrar();
                        grdTipos_Entradas.BorrarFila(grdTipos_Entradas.Row);
                    }

                }
            }
        }

        private void GrdTipos_Entradas_CambioFila(short Fila)
        {
            // 0 int    Id_Tipo 
            // 1 string Nombre 
            // 2 int    Grupo 
            // 3 bool   Es_Entrega

            tipos_e.Id_Tipo = Convert.ToInt32(grdTipos_Entradas.get_Texto(Fila, 0));
            tipos_e.Nombre = grdTipos_Entradas.get_Texto(Fila, 1).ToString();
            tipos_e.SubTipo.Id = Convert.ToInt32(grdTipos_Entradas.get_Texto(Fila, 2));
            tipos_e.Es_Entrega = Convert.ToBoolean(grdTipos_Entradas.get_Texto(Fila, 3));

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdTipos_Entradas.MostrarDatos(tipos_e.Datos($"Nombre like '%{i}%' OR Id={i}"));
                }
                else
                {
                    grdTipos_Entradas.MostrarDatos(tipos_e.Datos($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdTipos_Entradas.MostrarDatos(tipos_e.Datos());
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
