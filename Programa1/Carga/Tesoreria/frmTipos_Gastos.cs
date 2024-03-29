﻿namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmTipos_Gastos : Form
    {
        public frmTipos_Gastos()
        {
            InitializeComponent();
        }

        Grupo_Gastos gg = new Grupo_Gastos();
        Tipo_Gastos tg = new Tipo_Gastos();
        SubTipo_Gastos stg = new SubTipo_Gastos();
        Detalle_Gastos dtg = new Detalle_Gastos();

        #region " FORM "
        private void frmTipos_Gastos_Load(object sender, EventArgs e)
        {
            DataTable dt = gg.Tablas();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstTablas.Items.Add(Convert.ToString(dr["Tabla"]));
                }
            }

            //46: Delete
            grdGrupo.TeclasManejadas = new int[] { 46 };
            grdGrupo.MostrarDatos(gg.Datos(), true);
            grdGrupo.FixCols = 1;
            grdGrupo.AutosizeAll();
            grdGrupo.set_ColW(grdGrupo.get_ColIndex("Nombre"), 140);
            grdGrupo.set_ColW(grdGrupo.get_ColIndex("Tabla"), 100);


            //46: Delete
            grdTipo.TeclasManejadas = new int[] { 46 };
            grdTipo.MostrarDatos(tg.Datos(), true);
            grdTipo.AutosizeAll();
            grdTipo.set_ColW(grdTipo.get_ColIndex("Nombre"), 150);

            //46: Delete
            grdSubTipo.TeclasManejadas = new int[] { 46 };
            //grdSubTipo.MostrarDatos(stg.Datos(), true);
            //grdSubTipo.AutosizeAll();
            //grdSubTipo.set_ColW(grdSubTipo.get_ColIndex("Nombre"), 150);
            grdSubTipo.Rows = 0;

            //46: Delete
            grdDetalles.TeclasManejadas = new int[] { 46 };
            //grdDetalles.MostrarDatos(dtg.Datos(), true);
            //grdDetalles.AutosizeAll();
            //grdDetalles.set_ColW(grdDetalles.get_ColIndex("Nombre"), 150);
            grdDetalles.Rows = 0;
        }

        #endregion

        #region " GRUPO "
        private void grdGrupo_Editado(short f, short c, object a)
        {
            gg.Id = Convert.ToInt32(grdGrupo.get_Texto(f, 0));

            if (c == Convert.ToInt32(grdGrupo.get_ColIndex("Nombre")))
            {
                grdGrupo.set_Texto(f, c, a);
                gg.Nombre = Convert.ToString(a);

                if (gg.Id != 0) { gg.Actualizar(); }

                grdGrupo.ActivarCelda(f, c + 1);
            }
            if (c == Convert.ToInt32(grdGrupo.get_ColIndex("Tabla")))
            {
                grdGrupo.set_Texto(f, c, a);
                gg.Tabla = Convert.ToString(a);
                gg.Buscar_Tabla();

                grdGrupo.set_Texto(f, grdGrupo.get_ColIndex("Campo_Id"), gg.Campo_Id);
                grdGrupo.set_Texto(f, grdGrupo.get_ColIndex("Campo_Nombre"), gg.Campo_Nombre);
                grdGrupo.set_Texto(f, grdGrupo.get_ColIndex("Campo_Filtro"), gg.Campo_Filtro);

                if (gg.Id != 0)
                {
                    gg.Actualizar();
                }
                else
                {
                    gg.Nombre = Convert.ToString(grdGrupo.get_Texto(f, grdGrupo.get_ColIndex("Nombre")));
                    gg.Agregar();
                    grdGrupo.set_Texto(f, grdGrupo.get_ColIndex("Id"), gg.Id);
                    grdGrupo.AgregarFila();
                }

                grdGrupo.ActivarCelda(f + 1, grdGrupo.get_ColIndex("Nombre"));
            }
        }

        private void grdGrupo_CambioFila(short Fila)
        {
            gg.Id = Convert.ToInt32(grdGrupo.get_Texto(Fila, grdGrupo.get_ColIndex("Id")));
        }

        #endregion

        #region " TIPO "
        private void grdTipo_Editado(short f, short c, object a)
        {
            int vId = Convert.ToInt32(grdTipo.get_Texto(f, grdTipo.get_ColIndex("Id_Tipo")));

            if (c == Convert.ToInt32(grdTipo.get_ColIndex("Id_Tipo")))
            {
                if (vId == 0)
                {
                    grdTipo.set_Texto(f, c, a);
                    tg.Id_Tipo = Convert.ToInt32(a);

                    grdTipo.ActivarCelda(f, c + 1);
                }
                else { MessageBox.Show("No se puede modificar el ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            if (c == Convert.ToInt32(grdTipo.get_ColIndex("Nombre")))
            {
                grdTipo.set_Texto(f, c, a);
                tg.Nombre = Convert.ToString(a);

                if (tg.Id_Tipo != 0) { tg.Actualizar(); }

                grdTipo.ActivarCelda(f, c + 1);
            }
            if (c == Convert.ToInt32(grdTipo.get_ColIndex("Grupo")))
            {
                grdTipo.set_Texto(f, c, a);
                tg.grupoS.Id = Convert.ToInt32(a);

                if (tg.grupoS.Nombre.Length != 0)
                {
                    grdTipo.set_Texto(f, grdTipo.get_ColIndex("Grupo"), tg.grupoS.Id);
                    grdTipo.set_Texto(f, grdTipo.get_ColIndex("Descripcion"), tg.grupoS.Nombre);

                    if (grdTipo.EsUltimaFila() == false)
                    {
                        tg.Actualizar();
                    }
                    else
                    {
                        tg.Agregar();
                        grdTipo.AgregarFila();
                    }

                    grdTipo.ActivarCelda(f + 1, grdTipo.get_ColIndex("Id_Tipo"));
                }
                else
                {
                    MessageBox.Show($"No se pudo encontrar el grupo {a}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdTipo.ErrorEnTxt();
                }
            }
        }

        private void grdTipo_CambioFila(short Fila)
        {
            this.Cursor = Cursors.WaitCursor;
            grdSubTipo.Rows = 1;
            grdDetalles.Rows = 1;

            if (Convert.ToInt32(grdTipo.get_Texto(Fila, grdTipo.get_ColIndex("Id_Tipo"))) != 0)
            {
                tg.Id_Tipo = Convert.ToInt32(grdTipo.get_Texto(Fila, grdTipo.get_ColIndex("Id_Tipo")));
                tg.Nombre = grdTipo.get_Texto(Fila, grdTipo.get_ColIndex("Nombre")).ToString();
                lblST.Text = tg.grupoS.Tabla;

                string sf = "";
                if (tg.Id_Tipo != 0) { sf = $"ID_Tipo={tg.Id_Tipo}"; }

                stg.Id_Tipo = tg.Id_Tipo;
                grdSubTipo.MostrarDatos(stg.Datos(), true);
                grdSubTipo.AutosizeAll();
                grdSubTipo.set_ColW(grdSubTipo.get_ColIndex("Nombre"), 150);

                dtg.Id_Tipo = tg.Id_Tipo;
                grdDetalles.MostrarDatos(dtg.Datos(sf), true);
                grdDetalles.AutosizeAll();
                grdDetalles.set_ColW(grdDetalles.get_ColIndex("ID_Tipo"), 0);
                grdDetalles.set_ColW(grdDetalles.get_ColIndex("Nombre"), 150);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region " SUBTIPO "
        private void grdSubTipo_Editado(short f, short c, object a)
        {
            int vId = tg.Id_Tipo;
            int vSId = Convert.ToInt32(grdSubTipo.get_Texto(f, grdSubTipo.get_ColIndex(tg.grupoS.Campo_Id)));
            if (c == 0 & Convert.ToInt32(grdSubTipo.get_Texto(f, 0)) != 0)
            {
                MessageBox.Show("No se puede modificar el ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (c != Convert.ToInt32(grdSubTipo.get_ColIndex("Nombre")))
                {
                    stg.ID_SubTipo = Convert.ToInt32(a);
                    grdSubTipo.set_Texto(f, c, a);

                    grdSubTipo.ActivarCelda(f, c + 1);
                }
                if (c == Convert.ToInt32(grdSubTipo.get_ColIndex("Nombre")))
                {
                    grdSubTipo.set_Texto(f, c, a);
                    stg.Id_Tipo = vId;
                    stg.ID_SubTipo = vSId;
                    stg.Nombre = Convert.ToString(a);

                    if (grdSubTipo.EsUltimaFila() == false)
                    {
                        stg.Actualizar();
                    }
                    else
                    {
                        stg.Agregar();
                        grdSubTipo.AgregarFila();
                    }

                    grdSubTipo.ActivarCelda(f + 1, c - 1);
                }
            }
        }

        private void grdSubTipo_CambioFila(short Fila)
        {
            stg.Id_Tipo = Convert.ToInt32(grdSubTipo.get_Texto(Fila, grdSubTipo.get_ColIndex("ID_Tipo")));
            stg.ID_SubTipo = Convert.ToInt32(grdSubTipo.get_Texto(Fila, grdSubTipo.get_ColIndex("ID_SubTipo")));
        }

        #endregion

        #region " DETALLES "
        private void grdDetalles_Editado(short f, short c, object a)
        {
            int vId = Convert.ToInt32(grdDetalles.get_Texto(f, grdDetalles.get_ColIndex("Id_Tipo")));
            int vSId = Convert.ToInt32(grdDetalles.get_Texto(f, grdDetalles.get_ColIndex("Id_Detalle")));

            if (tg.Id_Tipo != 0)
            {
                if (c == Convert.ToInt32(grdDetalles.get_ColIndex("Id_Detalle")))
                {
                    if (vSId != 0)
                    { MessageBox.Show("No se puede modificar el ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    else
                    {
                        dtg.ID_Detalle = Convert.ToInt32(a);
                        grdDetalles.set_Texto(f, c, a);
                        grdDetalles.ActivarCelda(f, c + 1);
                    }
                }
                if (c == Convert.ToInt32(grdDetalles.get_ColIndex("Nombre")))
                {
                    grdDetalles.set_Texto(f, c, a);

                    dtg.Id_Tipo = tg.Id_Tipo;
                    dtg.ID_Detalle = vSId;
                    dtg.Nombre = Convert.ToString(a);

                    if (grdDetalles.EsUltimaFila() == false)
                    {
                        dtg.Actualizar();
                    }
                    else
                    {
                        dtg.Agregar();
                        grdDetalles.AgregarFila();
                        grdDetalles.set_Texto(f, grdDetalles.get_ColIndex("Id_Tipo"), vId);
                    }

                    grdDetalles.ActivarCelda(f + 1, grdDetalles.get_ColIndex("Id_Detalle"));
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Tipo.", "Error");
            }
        }

        private void grdDetalles_CambioFila(short Fila)
        {
            dtg.Id_Tipo = Convert.ToInt32(grdDetalles.get_Texto(Fila, grdDetalles.get_ColIndex("ID_Tipo")));
            dtg.ID_Detalle = Convert.ToInt32(grdDetalles.get_Texto(Fila, grdDetalles.get_ColIndex("ID_Detalle")));
        }
        #endregion



    }
}
