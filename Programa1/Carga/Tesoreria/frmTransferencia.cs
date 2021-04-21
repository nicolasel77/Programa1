namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmTransferencia : Form
    {
        public frmTransferencia()
        {
            InitializeComponent();
        }

        public bool OK = false;
        private bool noEval = false;
        private Cajas cajas = new Cajas();
        private Detalle_Gastos dg = new Detalle_Gastos();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            DataTable dt = cajas.Datos();
            h.Llenar_List(lstDesde, dt);
            h.Llenar_List(lstHacia, dt);

            //HORRIBLE.
            h.Llenar_List(lstARendir, dg.Datos_SinTipo("ID_Tipo=100"));
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmdAcpetar_Click(object sender, EventArgs e)
        {
            if (lstDesde.SelectedIndex > -1)
            {
                if (lstHacia.SelectedIndex > -1)
                {
                    double importe;
                    if (double.TryParse(txtImporte.Text, out importe) == true)
                    {
                        OK = true;
                        this.Hide();
                    }
                }
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            //FORMATEAR TEXTO A NÚMERO MIENTRAS SE EDITA
            if (noEval == false)
            {
                //El noEval (no evaluar) es porque cuando modifico el texto mas abajo, entra y borra demás
                noEval = true;
                string f = "";
                if (txtImporte.Text.EndsWith(".") | txtImporte.Text.EndsWith(".")) { f = ","; }
                int vlen = txtImporte.TextLength;
                if (vlen != 0)
                {
                    int sel = txtImporte.SelectionStart;
                    txtImporte.Text = Convert.ToDouble(txtImporte.Text).ToString("#,###.##");
                    txtImporte.Text = txtImporte.Text + f;
                    txtImporte.SelectionStart = sel + (txtImporte.TextLength - vlen);
                }
                noEval = false;
            }
            //Maravillosa Jugada
        }

        private void lstHacia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //HORRIBLE. No se escribe código fuerte/fijo
            //Arreglar cuando Dios mande....
            if (lstHacia.Text.StartsWith("12."))
            {
                lstARendir.Enabled = true;
                lstARendir.BackColor = Color.White;
            }
            else
            {
                lstARendir.Enabled = false;
                lstARendir.BackColor = Color.WhiteSmoke;
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
                cmdAcpetar.cmd.PerformClick();
            }
        }
    }
}
