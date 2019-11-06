using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa1.DB;

namespace Programa1.Controles
{
    public partial class cFechas : UserControl
    {
        private Semanas semanas;

        public cFechas()
        {
            InitializeComponent();

            Cargar();
        }

        private void Cargar()
        {
            semanas = new Semanas();

            DataTable dt = semanas.Datos();

            lstSemanas.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                DateTime d = Convert.ToDateTime( dr["Semana"]);
                lstSemanas.Items.Add(d.ToString("dd/MM/yyy"));
            }

            dt = semanas.Años();
            lstMesAño.Items.Clear();
            lstAños.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstMesAño.Items.Add(dr["Años"]);
                lstAños.Items.Add(dr["Años"]);
            }
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
                        s = $"{campo} BETWEEN ('{s}' AND DATEADD(DAY, 6, '{s}'))";
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
                        s = $"{campo} BETWEEN ('{s}' AND DATEADD(DAY, -1, DATEADD(MONTH, 1, '{s}')))";
                    }
                    break;
                case 3:
                    if (lstAños.SelectedIndex > -1)
                    {
                        s = $"DATEPART(YEAR, {campo}) = {lstAños.Text}";
                    }
                    break;
                case 4:
                    if (dtHasta.Value>dtDesde.Value)
                    {
                        s = $"{campo} BETWEEN '{dtDesde.Value.ToString("MM/dd/yyy")}' AND '{dtHasta.Value.ToString("MM/dd/yyy")}'";
                    }                    
                    break;
            }
            return s;
        }
    }
}
