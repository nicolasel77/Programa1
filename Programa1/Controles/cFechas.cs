namespace Programa1.Controles
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class cFechas : UserControl
    {
        private Semanas semanas;
        private bool cCambio = false;
        private DateTime fecha_Actual;
        public event EventHandler Cambio_Seleccion;

        public cFechas()
        {
            InitializeComponent();

            Cargar();
        }

        private void Cargar()
        {
            cCambio = true;
            semanas = new Semanas();

            DataTable dt = semanas.Datos();

            lstSemanas.Items.Clear();
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

            dt = semanas.Años();
            lstMesAño.Items.Clear();
            lstAños.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstMesAño.Items.Add(dr["Años"]);
                lstAños.Items.Add(dr["Años"]);
            }
            cCambio = false;
        }

        public string Cadena(string campo = "Fecha")
        {
            string s = "";
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (lstSemanas.SelectedIndex > -1)
                    {
                        s = Convert.ToDateTime(lstSemanas.Text).ToString("MM/dd/yyy");
                        s = $"({campo} BETWEEN '{s}' AND DATEADD(DAY, 6, '{s}'))";
                    }
                    break;
                case 1:
                    s = mntDias.SelectionRange.Start.ToString("MM/dd/yyy");
                    s = $"{campo}='{s}'";
                    break;
                case 2:
                    if (lstMes.SelectedIndex > -1)
                    {
                        string a = DateTime.Today.Year.ToString();
                        if (lstMesAño.SelectedIndex > -1)
                        {
                            a = lstMesAño.Text;
                        }
                        s = Convert.ToDateTime($"1/{(lstMes.SelectedIndex + 1).ToString()}/{a}").ToString("MM/dd/yyy");
                        s = $"({campo} BETWEEN '{s}' AND DATEADD(DAY, -1, DATEADD(MONTH, 1, '{s}')))";
                    }
                    break;
                case 3:
                    if (lstAños.SelectedIndex > -1)
                    {
                        s = $"DATEPART(YEAR, {campo}) = {lstAños.Text}";
                    }
                    break;
                case 4:
                    if (dtHasta.Value > dtDesde.Value)
                    {
                        s = $"({campo} BETWEEN '{dtDesde.Value.ToString("MM/dd/yyy")}' AND '{dtHasta.Value.ToString("MM/dd/yyy")}')";
                    }
                    break;
            }
            return s;
        }

        private void LstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSemanas.Text == "Mas...")
            {
                string s = lstSemanas.Items[lstSemanas.SelectedIndex - 1].ToString();

                DataTable dt = semanas.Datos($"Semana<'{Convert.ToDateTime(s).ToString("MM/dd/yy")}'");

                int i = lstSemanas.SelectedIndex;
                foreach (DataRow dr in dt.Rows)
                {
                    DateTime d = Convert.ToDateTime(dr["Semana"]);
                    lstSemanas.Items.Insert(i, d.ToString("dd/MM/yyy"));
                    i++;
                }
                
            }
            else
            {
                if (cCambio == false)
                {
                    Cambio_Seleccion(null, null);
                }
            }
        }

        private void MntDias_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (cCambio == false)
            {
                if (mntDias.SelectionStart.Date != fecha_Actual)
                {
                    fecha_Actual = mntDias.SelectionStart.Date;
                    Cambio_Seleccion(null, null);
                }                
            }
        }
    }
}
