namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;


    public partial class frmCargarEntregas : Form
    {
        private Detalle_Entregas detalle_Entregas = new Detalle_Entregas();
        #region " Columnas Entradas "
        private Byte d_Id;
        private Byte d_IDE;
        private Byte d_Fecha;
        private Byte d_Importe;


        #endregion
        public frmCargarEntregas()
        {
            InitializeComponent();
        }

        internal Detalle_Entregas Detalle_Entregas { get => detalle_Entregas; set => detalle_Entregas = value; }

        private void frmCargarEntregas_Load(object sender, EventArgs e)
        {
            grdEntregas.TeclasManejadas = new int[] { 13, 46 };
        }

        internal void Cargar()
        {
            grdEntregas.MostrarDatos(detalle_Entregas.Datos("ID_Entradas=" + detalle_Entregas.ID_Entradas), true);

            grdEntregas.set_Texto(grdEntregas.Rows - 1, d_IDE, detalle_Entregas.ID_Entradas);

            d_Id = Convert.ToByte(grdEntregas.get_ColIndex("ID"));
            d_IDE = Convert.ToByte(grdEntregas.get_ColIndex("ID_Entradas"));
            d_Fecha = Convert.ToByte(grdEntregas.get_ColIndex("Fecha"));
            d_Importe = Convert.ToByte(grdEntregas.get_ColIndex("Importe"));

            grdEntregas.set_ColW(d_Id, 0);
            grdEntregas.set_ColW(d_IDE, 0);

            grdEntregas.Columnas[d_Importe].Style.Format = "N1";

            grdEntregas.ActivarCelda(grdEntregas.Rows - 1, d_Fecha);

            Double t = grdEntregas.SumarCol(d_Importe, false);
            lblTotal.Text = "Total: " + t.ToString("C1");
        }

        private void grdEntregas_Editado(short f, short c, object a)
        {
            detalle_Entregas.Id = Convert.ToInt32(grdEntregas.get_Texto(f, d_Id));

            if (c == d_Fecha)
            {
                detalle_Entregas.Fecha = Convert.ToDateTime(a);
                if (detalle_Entregas.Id > 0) { detalle_Entregas.Actualizar(); }

                grdEntregas.set_Texto(f, d_Fecha, a);
                grdEntregas.ActivarCelda(f, d_Importe);
            }
            else
            {
                detalle_Entregas.Importe = Convert.ToDouble(a);

                grdEntregas.set_Texto(f, c, a);

                if (detalle_Entregas.Id > 0)
                {
                    detalle_Entregas.Actualizar();
                }
                else
                {
                    detalle_Entregas.Agregar();
                    grdEntregas.set_Texto(f, d_Id, detalle_Entregas.Id);
                    grdEntregas.set_Texto(f, d_IDE, detalle_Entregas.ID_Entradas);

                    grdEntregas.AgregarFila();
                    grdEntregas.set_Texto(f + 1, d_IDE, detalle_Entregas.ID_Entradas);
                    grdEntregas.set_Texto(f + 1, d_Fecha, detalle_Entregas.Fecha.AddDays(1));
                }

                grdEntregas.ActivarCelda(f + 1, d_Importe);
            }
            Double t = grdEntregas.SumarCol(d_Importe, false);
            lblTotal.Text = "Total: " + t.ToString("C1");
        }

        private void grdEntregas_CambioFila(short Fila)
        {
            detalle_Entregas.Id = Convert.ToInt32(grdEntregas.get_Texto(grdEntregas.Row, d_Id));
            detalle_Entregas.ID_Entradas = Convert.ToInt32(grdEntregas.get_Texto(grdEntregas.Row, d_IDE));
            detalle_Entregas.Fecha = Convert.ToDateTime(grdEntregas.get_Texto(grdEntregas.Row, d_Fecha));
            detalle_Entregas.Importe = Convert.ToDouble(grdEntregas.get_Texto(grdEntregas.Row, d_Importe));
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdEntregas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Enter))
            {
                object importe = grdEntregas.get_Texto(grdEntregas.Row, d_Importe);

                if (importe == "") { importe = "0"; }

                if (Convert.ToDouble(importe) == 0)
                {
                    this.Close();
                }
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Delete))
                {
                    if (MessageBox.Show("¿Esta seguro de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        detalle_Entregas.Borrar();
                        if (grdEntregas.EsUltimaFila() == true)
                        {
                            grdEntregas.set_Texto(grdEntregas.Row, d_Importe, 0);
                            grdEntregas.set_Texto(grdEntregas.Row, d_Id, 0);
                        }
                        else
                        {
                            grdEntregas.BorrarFila();
                        }
                    }
                }
            }
        }

        private void frmCargarEntregas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(43))
            {
                SendKeys.Send("000");
                SendKeys.Send("{ENTER}");
            }
        }
    }
}
