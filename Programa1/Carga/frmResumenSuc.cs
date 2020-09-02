namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmResumenSuc : Form
    {
        public frmResumenSuc()
        {
            InitializeComponent();

            Semanas sem = new Semanas();
            DataTable dt = sem.Datos();

            int salir = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (salir == 100)
                {
                    lstSemanas.Items.Add("Mas...");
                    break;
                }
                DateTime d = Convert.ToDateTime(dr["Semana"]);
                lstSemanas.Items.Add(d.ToString("dd/MM/yyy"));
                salir++;
            }
        }

        private void LstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSemanas.Text == "Mas...")
            {

            }
            else
            {
                Cargar();
            }
        }

        private void Cargar()
        {

        }
    }
}
