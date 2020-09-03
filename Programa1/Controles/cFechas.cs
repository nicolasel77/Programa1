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
        private DateTime uFecha = Convert.ToDateTime("1/1/2000");
        public DateTime fecha_Actual;
        public DateTime fecha_Fin;

        public event EventHandler Cambio_Seleccion;

        public cFechas()
        {
            InitializeComponent();

            Cargar();
        }
        public DateTime Fecha_Maxima { get => mntDias.MaxDate; set { mntDias.MaxDate = value; } }
        public int Mostrar { get => tabControl1.SelectedIndex; set { tabControl1.SelectedIndex = value; } }

        public DateTime Ultima_Fecha
        {
            get { return uFecha; }
            set 
            {
                uFecha = value;
                Cargar();
            }
        }

        private void Cargar()
        {
            cCambio = true;
            semanas = new Semanas();

            string s = "";
            if (uFecha.Year > 2000)
            {
                s = $"Semana<='{uFecha:MM/dd/yy}'";
            }

            DataTable dt = semanas.Datos(s);

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
                    if (fecha_Actual.Year > 2000)
                    {
                        s = mntDias.SelectionRange.Start.ToString("MM/dd/yyy");
                        s = $"{campo}='{s}'";
                    }
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
                fecha_Actual = DateTime.Parse(lstSemanas.Text);
                fecha_Fin = fecha_Actual.AddDays(6);
                if (cCambio == false)
                {
                    try
                    {
                        Cambio_Seleccion(null, null);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void MntDias_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaDia();
        }

        private void fechaDia()
        {
            if (cCambio == false)
            {
                if (mntDias.SelectionStart.Date != fecha_Actual)
                {
                    fecha_Actual = mntDias.SelectionStart.Date;
                    fecha_Fin = fecha_Actual;
                    Cambio_Seleccion(null, null);
                }
            }
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            fecha_Actual = dtDesde.Value;
            fecha_Fin = dtHasta.Value;
            Cambio_Seleccion(null, null);
        }

        private void LstMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechaMes();
        }

        private void LstMesAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechaMes();
        }

        private void fechaMes()
        {
            if (lstMes.SelectedIndex > -1)
            {
                string a = DateTime.Today.Year.ToString();
                if (lstMesAño.SelectedIndex > -1)
                {
                    a = lstMesAño.Text;
                }
                fecha_Actual = Convert.ToDateTime($"1/{(lstMes.SelectedIndex + 1).ToString()}/{a}");
                fecha_Fin = fecha_Actual.AddMonths(1).AddDays(-1);
                Cambio_Seleccion(null, null);
            }
        }

        private void LstAños_SelectedIndexChanged(object sender, EventArgs e)
        {
            fechaAño();
        }
        private void fechaAño()
        {
            if (lstAños.SelectedIndex > -1)
            {
                fecha_Actual = Convert.ToDateTime($"1/1/{lstAños.Text}");
                fecha_Fin = fecha_Actual.AddYears(1).AddDays(-1);
                Cambio_Seleccion(null, null);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    //Semana
                    break;
                case 1:
                    //Mes
                    fechaMes();
                    break;
                case 2:
                    //Año
                    fechaAño();
                    break;
                case 3:
                    //Desde-Hasta
                    fecha_Actual = dtDesde.Value;
                    break;
            }
        }
    }
}
