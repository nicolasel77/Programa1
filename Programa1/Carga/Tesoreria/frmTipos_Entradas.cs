namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmTipos_Entradas : Form
    {
        private Tipos_Entradas tipos_e = new Tipos_Entradas();
        private Grupos_Entradas grupo_e = new Grupos_Entradas();
        private Cajas cajas = new Cajas();

        public frmTipos_Entradas()
        {
            InitializeComponent();
        }

        private void FrmTipos_Entradas_Load(object sender, EventArgs e)
        {
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };

            //Cajas
            //Datos
            grdCajas.MostrarDatos(cajas.Datos(), true);

            //Formato
            grdCajas.set_ColW(0, 40);
            grdCajas.set_ColW(1, 120);
            grdCajas.TeclasManejadas = n;
            //**********************************

            //Grupo
            //Datos
            grdGrupo.MostrarDatos(grupo_e.Datos(), true);

            //Formato
            grdGrupo.set_ColW(0, 40);
            grdGrupo.set_ColW(1, 120);
            grdGrupo.TeclasManejadas = n;
            //**********************************

            //Tipos_Entradas
            //Datos
            grdTipos_Entradas.MostrarDatos(tipos_e.Datos(), true);
            //Formato
            grdTipos_Entradas.set_ColW(0, 50);
            grdTipos_Entradas.set_ColW(1, 150);
            grdTipos_Entradas.TeclasManejadas = n;
        }


        #region " Grupos_Entradas "

        private void Grdcajasditado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdCajas.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        cajas.ID = Convert.ToInt32(a);
                        if (cajas.Existe() == true)
                        {
                            Mensaje($"El id '{a}' ya existe.");
                            grdCajas.ErrorEnTxt();
                        }
                        else
                        {
                            grdCajas.set_Texto(f, c, a);
                            cajas.Agregar();
                            grdCajas.ActivarCelda(f, 1);
                            if (grdCajas.EsUltimaFila() == true) { grdCajas.AgregarFila(); }
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdCajas.ActivarCelda(f, 0);
                    }
                    else
                    {
                        cajas.ID = i;
                        cajas.Nombre = a.ToString();
                        grdCajas.set_Texto(f, c, a);
                        cajas.Actualizar();
                        if (grdCajas.EsUltimaFila() == true) { grdCajas.AgregarFila(); }
                        grdCajas.ActivarCelda(f + 1, 0);
                    }
                    break;
            }
        }

        private void GrdCajas_CambioFila(short Fila)
        {
            cajas.ID = Convert.ToInt32(grdCajas.get_Texto(Fila, 0));
            cajas.Nombre = grdCajas.get_Texto(Fila, 1).ToString();

        }

        private void GrdCajas_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdCajas.Row;
                if (f == grdCajas.Rows - 1)
                {
                    grdCajas.ActivarCelda(1, grdCajas.Col);
                }
                else
                {
                    grdCajas.ActivarCelda(f + 1, grdCajas.Col);
                }
            }
        }

        private void GrdCajas_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdCajas.get_Texto(grdCajas.Row, 1)}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdCajas.get_Texto(grdCajas.Row, 0)) != 0)
                    {
                        cajas.ID = Convert.ToInt32(grdCajas.get_Texto(grdCajas.Row, 0));
                        cajas.Borrar();
                        grdCajas.BorrarFila(grdCajas.Row);
                    }

                }
            }
        }

        #endregion

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
                        grupo_e.Id = Convert.ToInt32(a);
                        if (grupo_e.Existe() == true)
                        {
                            Mensaje($"El Grupo '{a}' ya existe.");
                            grdGrupo.ErrorEnTxt();
                        }
                        else
                        {
                            grdGrupo.set_Texto(f, c, a);
                            grupo_e.Agregar();
                            grdGrupo.ActivarCelda(f, 1);
                            if (grdGrupo.EsUltimaFila() == true) { grdGrupo.AgregarFila(); }
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
                        grupo_e.Id = i;
                        grupo_e.Nombre = a.ToString();
                        grdGrupo.set_Texto(f, c, a);
                        grupo_e.Actualizar();
                        grdGrupo.ActivarCelda(f, 2);
                    }
                    break;
                case 2: // Tabla
                    Grupo_eAyuda();
                    break;
                case 3: // Tabla
                    Grupo_eAyuda();
                    break;
                case 4: // Tabla
                    Grupo_eAyuda();

                    //    if (i == 0)
                    //    {
                    //        Mensaje("Debe ingresar el Id primero");
                    //        grdGrupo.ActivarCelda(f, 0);
                    //    }
                    //    else
                    //    {
                    //        grupo_e.Tabla = a.ToString();
                    //        grdGrupo.set_Texto(f, c, a);
                    //        grupo_e.Actualizar();
                    //        if (grdGrupo.EsUltimaFila() == true) { grdGrupo.AgregarFila(); }
                    //        grdGrupo.ActivarCelda(f, 3);
                    //    }
                    //    break;
                    //case 3: // Campo Id
                    //    if (i == 0)
                    //    {
                    //        Mensaje("Debe ingresar el Id primero");
                    //        grdGrupo.ActivarCelda(f, 0);
                    //    }
                    //    else
                    //    {
                    //        grupo_e.Id = i;
                    //        grupo_e.Campo_Id = a.ToString();
                    //        grdGrupo.set_Texto(f, c, a);
                    //        grupo_e.Actualizar();
                    //        grdGrupo.ActivarCelda(f, 4);
                    //    }
                    //    break;
                    //case 4: // Campo Nombre
                    //    if (i == 0)
                    //    {
                    //        Mensaje("Debe ingresar el Id primero");
                    //        grdGrupo.ActivarCelda(f, 0);
                    //    }
                    //    else
                    //    {
                    //        grupo_e.Id = i;
                    //        grupo_e.Campo_Nombre = a.ToString();
                    //        grdGrupo.set_Texto(f, c, a);
                    //        grupo_e.Actualizar();
                    //        grdGrupo.ActivarCelda(f + 1, 0);
                    //    }
                    break;
            }
        }

        private void GrdGrupo_CambioFila(short Fila)
        {
            grupo_e.Id = Convert.ToInt32(grdGrupo.get_Texto(Fila, 0));
            grupo_e.Nombre = grdGrupo.get_Texto(Fila, 1).ToString();
            grupo_e.Tabla = grdGrupo.get_Texto(Fila, 2).ToString();

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
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdGrupo.get_Texto(grdGrupo.Row, 1)}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, 0)) != 0)
                    {
                        grupo_e.Id = Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, 0));
                        grupo_e.Borrar();
                        grdGrupo.BorrarFila(grdGrupo.Row);
                    }
                }
            }
            if (e == 112)
            {
                if (grdGrupo.Col > grdGrupo.get_ColIndex("Nombre"))
                {
                    Grupo_eAyuda();
                }
            }
        }

        private void Grupo_eAyuda()
        {
            frmAyudaGrupos_E fayuda = new frmAyudaGrupos_E();
            fayuda.ShowDialog();

            if (fayuda.tabla != "")
            {
                string tabla = fayuda.tabla;
                string campo_ID = fayuda.campo_ID;
                string campo_Nombre = fayuda.campo_Nombre;
                grdGrupo.set_Texto(grdGrupo.Row, grdGrupo.get_ColIndex("Tabla"), tabla);
                grdGrupo.set_Texto(grdGrupo.Row, grdGrupo.get_ColIndex("campo_ID"), campo_ID);
                grdGrupo.set_Texto(grdGrupo.Row, grdGrupo.get_ColIndex("campo_Nombre"), campo_Nombre);
                grupo_e.Id = Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, grdGrupo.get_ColIndex("Id")));
                grupo_e.Tabla = tabla;
                grupo_e.Campo_Id = campo_ID;
                grupo_e.Campo_Nombre = campo_Nombre;
                if (Convert.ToInt32(grdGrupo.get_Texto(grdGrupo.Row, grdGrupo.get_ColIndex("Id"))) != 0)
                {
                    grupo_e.Actualizar();
                }
                else
                {
                    grupo_e.Agregar();
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
                            Mensaje($"El producto '{a}' ya existe.");
                            grdTipos_Entradas.ErrorEnTxt();
                        }
                        else
                        {
                            grdTipos_Entradas.set_Texto(f, c, a);
                            tipos_e.Agregar();
                            if (grdTipos_Entradas.EsUltimaFila() == true) { grdTipos_Entradas.AgregarFila(); }
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
                        tipos_e.Grupo = Convert.ToInt32(a);
                        grupo_e.Id = tipos_e.Grupo;

                        if (grupo_e.Existe() == true)
                        {
                            grdTipos_Entradas.set_Texto(f, c, a);
                            grdTipos_Entradas.set_Texto(f, c + 1, grupo_e.Nombre);
                            tipos_e.Actualizar();
                            grdTipos_Entradas.ActivarCelda(f, 3);
                        }
                        else
                        {
                            Mensaje($"No se encontro el grupo '{a}'.");
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
                        if (grdTipos_Entradas.EsUltimaFila() == true) { grdTipos_Entradas.AgregarFila(); }
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
                if (MessageBox.Show($"¿Esta segura/o de borrar el producto '{grdTipos_Entradas.get_Texto(grdTipos_Entradas.Row, 1)}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
            // 2 int    SubTipo
            // 3 bool   Es_Entrega

            tipos_e.Id_Tipo = Convert.ToInt32(grdTipos_Entradas.get_Texto(Fila, 0));
            tipos_e.Nombre = grdTipos_Entradas.get_Texto(Fila, 1).ToString();
            tipos_e.Grupo = Convert.ToInt32(grdTipos_Entradas.get_Texto(Fila, 2));
            tipos_e.Es_Entrega = Convert.ToBoolean(grdTipos_Entradas.get_Texto(Fila, 3));
            tipos_e.Efect

            grupo_e.Id = tipos_e.Grupo;
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
