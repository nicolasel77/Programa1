namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Varios;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmSeleccionar_PagosAutorizados : Form
    {
        public bool Aceptado = false;
        C1.Win.C1FlexGrid.CellStyle vEstilo;

        public Pagos_Autorizados pagos = new Pagos_Autorizados();
        public frmSeleccionar_PagosAutorizados()
        {

            InitializeComponent();
            vEstilo = grd.Styles.Add("n");
            vEstilo.BackColor = Color.MistyRose;

            grd.TeclasManejadas = new int[] { Convert.ToInt32(Keys.Escape), 13 };
        }

        public void Cargar(int Proveedor)
        {
            grd.MostrarDatos(pagos.Autorizados_Proveedor(Proveedor), true, false);
            grd.ActivarCelda(1, 0);
            grd.Columnas[grd.get_ColIndex("Total")].Style.Format = "N1";
            grd.Columnas[grd.get_ColIndex("Pagos")].Style.Format = "N1";
            grd.Columnas[grd.get_ColIndex("Saldo")].Style.Format = "N1";
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c == 0)
            {
                if (Convert.ToBoolean(a) == true)
                {
                    grd.Filas[f].Style = vEstilo;
                }
                else
                {
                    grd.Filas[f].Style = null;
                }
                double t = 0;
                for (int i = 1; i < grd.Rows; i++)
                {
                    if (Convert.ToBoolean(grd.get_Texto(i, c)) == true)
                    {
                        t += Convert.ToDouble(grd.get_Texto(i, grd.get_ColIndex("Saldo"))) * -1;
                    }
                }
                lblTotal.Text = $"Total: {t:N1}";
            }
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                Aceptado = true;
                this.Hide();
            }
            else
            {
                if (e == 27)
                {
                    this.Hide();
                }
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptado = true;
            this.Hide();
        }
    }
}
