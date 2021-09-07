using Programa1.DB;
using Programa1.DB.Varios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmCapitalDeTrabajo : Form
    {
        readonly Capital_Trabajo ct = new Capital_Trabajo();

        public frmCapitalDeTrabajo()
        {
            InitializeComponent();
            split1.SplitterDistance = split1.Width - 100;

            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sem.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ct.Semana = Convert.ToDateTime(lstSemanas.Text);
            Activos();
            Pasivos();
            Resultado();
            this.Cursor = Cursors.Default;

        }

        private void Activos()
        {
            grdActivos.MostrarDatos(ct.Activos(), true, 1);
            grdActivos.set_ColW(0, 200);
            grdActivos.set_ColW(1, 100);
            grdActivos.Columnas[1].Format = "N1";
        }
        private void Pasivos()
        {
            grdPasivos.MostrarDatos(ct.Pasivos(), true, 1);
            grdPasivos.set_ColW(0, 200);
            grdPasivos.set_ColW(1, 100);
            grdPasivos.Columnas[1].Format = "N1";
        }
        private void Resultado()
        {
            grdResultado.MostrarDatos(ct.Resultado(), true, true);
            grdResultado.set_ColW(0, 200);
            grdResultado.set_ColW(1, 100);
            grdResultado.Columnas[1].Format = "N1";

            C1.Win.C1FlexGrid.CellStyle verde = grdResultado.Styles.Add("Verde");
            C1.Win.C1FlexGrid.CellStyle rosa = grdResultado.Styles.Add("Rosa");
            verde.BackColor = Color.LightGreen;
            rosa.BackColor = Color.LightSalmon;

            double tResultado = 0;
            
            for (int i = 1; i < grdResultado.Rows - 1; i++)
            {
                if (tResultado != 0)
                {
                    tResultado -= Convert.ToDouble(grdResultado.get_Texto(i, 1));
                }
                if (grdResultado.get_Texto(i, 0).ToString() == "Resultado")
                {
                    tResultado -= Convert.ToDouble(grdResultado.get_Texto(i, 1));
                    tResultado = tResultado * -1;
                    if (tResultado > 0) { grdResultado.Filas[i].Style = verde; }
                    if (tResultado < 0) { grdResultado.Filas[i].Style = rosa; }
                }
            }

            //tResultado = 0;
            //for (int i = r; i < grdResultado.Rows - 1; i++)
            //{
            //    tResultado -= Convert.ToDouble(grdResultado.get_Texto(i, 1));

            //}

            grdResultado.set_Texto(grdResultado.Rows - 1, 0, "Diferencia");
            grdResultado.set_Texto(grdResultado.Rows - 1, 1, tResultado);

            double tActivos = Convert.ToDouble(grdActivos.get_Texto(grdActivos.Rows - 1, 1));
            double tPasivos = Convert.ToDouble(grdPasivos.get_Texto(grdPasivos.Rows - 1, 1));
            lblTotales.Text = $"Diferencia: {(tActivos - tPasivos):C1}";
        }


    }
}

