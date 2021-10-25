namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Varios;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmSeleccionar_PagosAutorizados : Form
    {
        public bool Aceptado = false;
        readonly C1.Win.C1FlexGrid.CellStyle vEstilo;

        public Pagos_Autorizados pagos = new Pagos_Autorizados();
        public frmSeleccionar_PagosAutorizados()
        {

            InitializeComponent();
            vEstilo = grd.Styles.Add("n");
            vEstilo.BackColor = Color.MistyRose;

            grd.TeclasManejadas = new int[] { 13, Convert.ToInt32(Keys.Escape), 43 };
        }

        public void Cargar(int Proveedor)
        {
            grd.MostrarDatos(pagos.Autorizados_Proveedor(Proveedor), true, false);
            grd.ActivarCelda(1, 0);
            grd.Columnas[grd.get_ColIndex("Total")].Style.Format = "N1";
            grd.Columnas[grd.get_ColIndex("Pagos")].Style.Format = "N1";
            grd.Columnas[grd.get_ColIndex("Saldo")].Style.Format = "N1";
            grd.Columnas[grd.get_ColIndex("Nuevo")].Style.Format = "N1";
            grd.ActivarCelda(1, grd.get_ColIndex("Nuevo"));
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c == grd.get_ColIndex("Nuevo"))
            {
                double npago = Convert.ToDouble(a);
                double vTotal = Convert.ToDouble(grd.get_Texto(grd.Row, grd.get_ColIndex("Total")));
                double vPagos = Convert.ToDouble(grd.get_Texto(grd.Row, grd.get_ColIndex("Pagos")));
                

                grd.set_Texto(f, c, npago);
                grd.set_Texto(f, grd.get_ColIndex("Saldo"), vPagos + npago - vTotal);

                grd.ActivarCelda((f == grd.Rows - 1) ? f + 1 : 1, c);

                double t = grd.SumarCol("Nuevo");

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
                else
                {
                    if (e == 43)
                    {
                        double v = Convert.ToDouble(grd.get_Texto(grd.Row, grd.get_ColIndex("Saldo")));
                        grd_Editado((Int16)grd.Row, (Int16)grd.Col, v * -1);
                    }
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
