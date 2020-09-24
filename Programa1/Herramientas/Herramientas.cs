using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Herramientas
{
    class Herramientas
    {
        public int Codigo_Seleccionado(string s)
        {
            int r = 0;
            string n = s.Substring(0, s.IndexOf("."));

            if (int.TryParse(n, out r) == true)
            {
                return r;
            }
            else
            {
                return 0;
            }

        }

        public string Unir(string a, string b, string c = " AND ")
        {
            if (a == null)
            {
                a = "";
            }
            if (a.Length > 0)
            {
                if (b.Length > 0)
                {
                    a = $"{a} {c} {b}";
                }
            }
            else
            {
                if (b.Length > 0)
                {
                    a = b;
                }
            }
            return a;
        }
       
        public void Llenar_List(ListBox ls, DataTable dt)
        {
            ls.Items.Clear();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ls.Items.Add($"{dr[0]}. {dr[1]}");
                }
            }
        }
    }
}
