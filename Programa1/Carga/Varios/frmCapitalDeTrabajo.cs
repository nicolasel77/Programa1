﻿using Programa1.DB;
using Programa1.DB.Varios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmCapitalDeTrabajo : Form
    {
        Capital_Trabajo ct = new Capital_Trabajo();

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
            grdResultado.MostrarDatos(ct.Resultado(), true, 1);
            grdResultado.set_ColW(0, 200);
            grdResultado.set_ColW(1, 100);
            grdResultado.Columnas[1].Format = "N1";
            
            C1.Win.C1FlexGrid.CellStyle verde = grdResultado.Styles.Add("Verde");
            C1.Win.C1FlexGrid.CellStyle rosa = grdResultado.Styles.Add("Rosa");
            verde.BackColor = Color.LightGreen;
            rosa.BackColor = Color.LightSalmon;

            for (int i = 1; i<grdResultado.Rows-1; i++)
            {
                if (grdResultado.get_Texto(i, 0).ToString() == "Resultado")
                {
                    double t = Convert.ToDouble(grdResultado.get_Texto(i, 1));
                    if (t > 0) { grdResultado.Filas[i].Style = verde; }
                    if (t < 0) { grdResultado.Filas[i].Style = rosa; }
                }
            }
        }
    }
}
