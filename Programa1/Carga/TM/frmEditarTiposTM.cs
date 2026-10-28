namespace Programa1.Carga.TM
{
    using System;
    using System.Windows.Forms;

    public partial class frmEditarTiposTM : Form
    {
        private clsTM TiposTM = new clsTM();

        public frmEditarTiposTM()
        {
            InitializeComponent();

            grdGrupos.MostrarDatos(TiposTM.Grupos_Gastos(), true, true);
            grdGrupos.AutosizeAll();

            grdTipos.MostrarDatos(TiposTM.Tipos_TM(), true, true);
            grdTipos.AutosizeAll();

            grdCajas.MostrarDatos(TiposTM.Cajas_TM(), true, true);
            grdCajas.AutosizeAll();
        }


        #region " Cajas "
        private void grdCajas_Editado(short f, short c, object a)
        {
            // Col 0 = ID
            // Col 1 = Nombre
            int id = Convert.ToInt32(grdCajas.get_Texto(f, 0));

            if (f == grdCajas.Rows - 1)
            {
                grdCajas.set_Texto(f, c, a);
                if (c == 0)
                {
                    TiposTM.Nueva_Caja((int)a);
                    grdCajas.ActivarCelda(f, 1);

                }
                else
                {
                    TiposTM.Modificar_Caja(id, a.ToString());
                    grdCajas.Rows += 1;
                    grdCajas.ActivarCelda(f + 1, 0);
                }
            }
            else
            {
                if (c == 1)
                {
                    // Modificar Caja
                    TiposTM.Modificar_Caja(id, a.ToString());
                    grdCajas.set_Texto(f, c, a);
                    grdCajas.ActivarCelda(f + 1, 1);

                }
            }

        }

        private void cmdBorrarCaja_Click(object sender, EventArgs e)
        {
            if (grdCajas.Row > 0)
            {
                int id = Convert.ToInt32(grdCajas.get_Texto(grdCajas.Row, 0));
                // Mensaje de confirmación
                if (MessageBox.Show($"¿Está seguro de borrar la caja id: {id}?", "Borrar Caja", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TiposTM.Borrar_Caja(id);
                    grdCajas.BorrarFila(grdCajas.Row);
                }
            }
        }

        #endregion

        #region " Grupos "        
        private void grdGrupos_Editado(short f, short c, object a)
        {
            // Col 0 = ID
            // Col 1 = Nombre
            // Col 2 = Tabla
            // Col 3 = Campo_ID
            // Col 4 = Campo_Nombre
            // Col 5 = Campo_Filtro
            int id = Convert.ToInt32(grdGrupos.get_Texto(f, 0));
            if (f == grdGrupos.Rows - 1)
            {
                if (c == 0)
                {
                    grdGrupos.set_Texto(f, c, a);
                    TiposTM.Nuevo_Grupo((int)a);
                    grdGrupos.ActivarCelda(f, 1);
                }
                else
                {
                    if (id > 0)
                    {
                        string nombre = grdGrupos.get_Texto(f, 1).ToString();
                        string tabla = grdGrupos.get_Texto(f, 2).ToString();
                        string campo_id = grdGrupos.get_Texto(f, 3).ToString();
                        string campo_nombre = grdGrupos.get_Texto(f, 4).ToString();
                        string campo_filtro = grdGrupos.get_Texto(f, 5).ToString();
                        TiposTM.Modificar_Grupo(id, nombre, tabla, campo_id, campo_nombre, campo_filtro);
                        if (c == grdGrupos.Cols - 1)
                        {
                            grdGrupos.ActivarCelda(f + 1, 0);
                        }
                        else
                        {
                            grdGrupos.Rows += 1;
                            grdGrupos.ActivarCelda(f, ++c);
                        }
                    }
                    else
                    {
                        grdGrupos.ActivarCelda(f, 0);
                    }
                }

            }
            else
            {
                if (c > 0)
                {
                    grdGrupos.set_Texto(f, c, a);
                    string nombre = grdGrupos.get_Texto(f, 1).ToString();
                    string tabla = grdGrupos.get_Texto(f, 2).ToString();
                    string campo_id = grdGrupos.get_Texto(f, 3).ToString();
                    string campo_nombre = grdGrupos.get_Texto(f, 4).ToString();
                    string campo_filtro = grdGrupos.get_Texto(f, 5).ToString();
                    TiposTM.Modificar_Grupo(id, nombre, tabla, campo_id, campo_nombre, campo_filtro);
                    grdGrupos.ActivarCelda(f + 1, c);
                }

            }
        }

        private void cmdBorrarGrupo_Click(object sender, EventArgs e)
        {
            if (grdGrupos.Row > 0)
            {
                int id = Convert.ToInt32(grdGrupos.get_Texto(grdGrupos.Row, 0));
                // Mensaje de confirmación
                if (MessageBox.Show($"¿Está seguro de borrar el grupo id: {id}?", "Borrar Grupo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TiposTM.Borrar_Grupo(id);
                    grdGrupos.BorrarFila(grdGrupos.Row);
                }
            }
        }
        #endregion

        #region " Tipos "
        private void grdTipos_CambioFila(short Fila)
        {
            int id = 0;
            grdSubTipos.Rows = 0;
            grdDetalles.Rows = 0;
            if ((int)grdTipos.get_Texto(Fila, 1) != 0)
            {
                id = Convert.ToInt32(grdTipos.get_Texto(Fila, 1));

                lblSTipo.Text = TiposTM.Tabla_SubTipo(Convert.ToInt32(id));

                grdSubTipos.MostrarDatos(TiposTM.SubTipos_TM(id), true, true);
                grdSubTipos.AutosizeAll();

                grdDetalles.MostrarDatos(TiposTM.Detalles_TM(id), true, true);
                grdDetalles.AutosizeAll();
            }
        }

        private void grdTipos_Editado(short f, short c, object a)
        {
            // Col 0 = Grupo
            // Col 1 = ID
            // Col 2 = Nombre
            int gr = Convert.ToInt32(grdTipos.get_Texto(f, 0));
            int id = Convert.ToInt32(grdTipos.get_Texto(f, 1));

            if (f == grdTipos.Rows - 1)
            {
                if (c == 0)
                {
                    grdTipos.set_Texto(f, c, a);
                    grdTipos.ActivarCelda(f, 1);
                }
                else
                {
                    if (c == 1)
                    {
                        if (gr == 0)
                        {
                            MessageBox.Show("Debe seleccionar un grupo antes de asignar un nuevo tipo.");
                            grdTipos.ActivarCelda(f, 0);
                            return;
                        }
                        // Primero chequear que no exista el Grupo + Tipo
                        if (TiposTM.Existe_Tipo_TM(gr, (int)a))
                        {
                            MessageBox.Show("Ya existe un tipo con ese ID en el grupo seleccionado.");
                            grdTipos.ActivarCelda(f, 1);
                            return;
                        }
                        grdTipos.set_Texto(f, c, a);
                        TiposTM.Nuevo_Tipo_TM(gr, (int)a);
                        grdTipos.ActivarCelda(f, 2);
                    }
                    else
                    {
                        grdTipos.set_Texto(f, c, a);
                        TiposTM.Modificar_Tipo_TM(gr, id, a.ToString());
                        grdTipos.Rows += 1;
                        grdTipos.ActivarCelda(f + 1, 0);
                    }
                }
            }
            else
            {
                if (c == 2)
                {
                    grdTipos.set_Texto(f, c, a);
                    // Modificar Tipo
                    TiposTM.Modificar_Tipo_TM(gr, id, a.ToString());
                    grdTipos.set_Texto(f, c, a);
                    grdTipos.ActivarCelda(f + 1, 2);
                }
            }
        }

        private void cmdBorrarTipo_Click(object sender, EventArgs e)
        {
            // Borrar Tipo
            if (grdTipos.Row > 0)
            {
                int gr = Convert.ToInt32(grdTipos.get_Texto(grdTipos.Row, 0));
                int id = Convert.ToInt32(grdTipos.get_Texto(grdTipos.Row, 1));
                // Mensaje de confirmación
                if (MessageBox.Show($"¿Está seguro de borrar el tipo id: {id} del grupo {gr}?", "Borrar Tipo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TiposTM.Borrar_Tipo_TM(gr, id);
                    grdTipos.BorrarFila(grdTipos.Row);
                }
            }
        }

        #endregion

        #region " SubTipos "
        private void grdSubTipos_Editado(short f, short c, object a)
        {
            int idGrupo = (int)grdTipos.get_Texto(grdTipos.Row, 0);
            int idTipo = (int)grdTipos.get_Texto(grdTipos.Row, 1);
            int idSubTipo = (int)grdSubTipos.get_Texto(f, 0);


            if (f == grdSubTipos.Rows - 1)
            {
                if (c == 0)
                {
                    if (TiposTM.Existe_SubTipo_TM(idGrupo, idTipo, (int)a))
                    {
                        MessageBox.Show("Ya existe un dato con ese ID en el Tipo seleccionado.");
                        grdSubTipos.ActivarCelda(f, 0);
                        return;
                    }
                    else
                    {
                        TiposTM.Nuevo_SubTipo(idGrupo, idTipo, (int)a);
                        grdSubTipos.set_Texto(f, c, a);
                        grdSubTipos.ActivarCelda(f, 1);
                        grdSubTipos.Rows += 1;
                    }
                }
            }
            else
            {
                if (c == 1)
                {
                    TiposTM.Modificar_SubTipo_TM(idGrupo, idTipo, idSubTipo, a.ToString());
                    grdSubTipos.set_Texto(f, c, a);
                    grdSubTipos.ActivarCelda(f + 1, 0);
                }                
            }
        }
        #endregion

        #region " Detalles "
        private void grdDetalles_Editado(short f, short c, object a)
        {
            int idTipo = (int)grdTipos.get_Texto(grdTipos.Row, 1);
            int idDetalle = (int)grdDetalles.get_Texto(grdDetalles.Row, 0);

            if (grdDetalles.Row == grdDetalles.Rows - 1)
            {
                if (c == 0)
                {
                    if (TiposTM.Existe_Detalle(idTipo, (int)a))
                    {
                        MessageBox.Show("Ya existe un detalle con ese ID en el Tipo seleccionado.");
                        grdDetalles.ActivarCelda(f, 0);
                        return;
                    }
                    else
                    {
                        TiposTM.Nuevo_Detalle(idTipo, (int)a, "");
                        grdDetalles.set_Texto(f, c, a);
                        grdDetalles.ActivarCelda(f, 1);
                        grdDetalles.Rows += 1;
                    }
                }
            }
            else
            {
                if (c == 0)
                {
                    MessageBox.Show("No se puede modificar el ID.");
                    return;
                }
                else
                {
                    if (idDetalle == 0)
                    {
                        grdDetalles.ActivarCelda(f, 0);
                        return;
                    }
                    else
                    {
                        TiposTM.Modificar_Detalle(idTipo, idDetalle, a.ToString());
                        grdDetalles.set_Texto(f, c, a);
                        grdDetalles.ActivarCelda(f + 1, 0);
                    }
                }
            }
        }

        #endregion
    }
}
