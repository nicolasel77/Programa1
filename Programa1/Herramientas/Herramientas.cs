using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Herramientas
{
    class Herramientas
    {
        public int Codigo_Seleccionado(string s)
        {

            if (s.IndexOf(".") > - 1)
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
            else
            {
                return 0;
            }

        }
        public string Nombre_Seleccionado(string s)
        {
            string n = "";

            if (s.IndexOf(".") > -1)
            {
                n = s.Substring(s.IndexOf(".") + 2);
            }
            return n;
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

    //Public Sub Siguiente(ByVal s As ListBox)
    //    If s.Items.Count<> 0 Then
    //        Dim i As Integer = s.SelectedIndex
    //        If i = -1 Then
    //            s.SelectedIndex = 0
    //        Else
    //            If i = s.Items.Count - 1 Then
    //                s.SelectedIndex = 0
    //            Else
    //                s.SelectedIndex = i + 1
    //            End If
    //        End If
    //    End If
    //End Sub
}
