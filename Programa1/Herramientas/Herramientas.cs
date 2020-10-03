﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Herramientas
{
    class Herramientas
    {

        public int Codigo_Seleccionado(string s)
        {

            if (s.IndexOf(".") > -1)
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

        public void Llenar_List(ListBox ls, DataTable dt, string formato = "")
        {
            ls.Items.Clear();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Columns.Count > 1)
                    {
                        ls.Items.Add($"{dr[0]}. {dr[1]}");
                    }
                    else
                    {
                        if (formato.Length > 0)
                        {
                            if (dt.Columns[0].DataType == typeof(DateTime))
                            {
                                DateTime d = Convert.ToDateTime(dr[0]);
                                ls.Items.Add(d.ToString(formato));
                            }
                            else
                            {
                                ls.Items.Add($"{dr[0]}");
                            }

                        }
                        else
                        {
                            ls.Items.Add($"{dr[0]}");
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Vos pasale una formula con parentesis y todo y el capo te la saca de una.
        /// </summary>
        /// <param name="cadena">Acordate de usar , en vez de .</param>
        /// <returns></returns>
        public Double Calcular_Texto(string f)
        {
            Double d = 0;

            //Resolver los parentesis:
            if (f.IndexOf("(") > -1) { f = Calcular_Parentesis(f); }

            //Resolver el resto:
            if (f.IndexOf("*") > -1) { f = Calcular_Multiplicacion(f); }
            if (f.IndexOf("/") > -1) { f = Calcular_Division(f); }

            d = Calcular(f);

            return d;
        }

        private double Calcular(string t)
        {
            Double a = 0, s2 = 0;
            String s = "", c = "";
            int vOp = 1;

            //'Por las dudas, permite cualquier formato
            t = t.Replace(".", ",");

            for (int i = 0; i <= t.Length - 1; i++)
            {
                c = t.Substring(i, 1);
                if (c == "+")
                {
                    if (double.TryParse(s, out s2)) { a = a + (s2 * vOp); }
                    vOp = 1;
                    s = "";
                }
                else
                {
                    if (c == "-")
                    {
                        if (double.TryParse(s, out s2)) { a = a + (s2 * vOp); }
                        vOp = -1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
            }
            if (double.TryParse(s, out s2)) { a = a + (s2 * vOp); }

            return a;
        }
        private string Calcular_Parentesis(string f)
        {
            int i = 0;
            int n = 0;
            string st = "";
            Double d = 0;

            //*****Mini rutina para calcular los parentesis*****
            //Averiguo el fin de cualquiera de ellos

            i = f.IndexOf(")");

            while (i > -1)
            {
                //    El inicio del parentesis averiguado
                n = f.LastIndexOf("(", i);

                st = f.Substring(n + 1, i - n - 1);

                //    Calculo el parentesis y reemplazo el texto original
                d = Calcular_Texto(st);
                f = f.Replace($"({st})", d.ToString());

                //    Sigo hasta que no halla mas para calcular
                i = f.IndexOf(")");
            }

            return f;
        }
        private string Calcular_Multiplicacion(string t)
        {
            int i = t.IndexOf("*");

            //Por las dudas, permite cualquier formato
            t = t.Replace(".", ",");

            string vNum = "0123456789,";

            while (i > -1)
            {
                //    Hay una multiplicacion, buscar ambos valores y calcularlos
                //    Ej: 1 + 2 * 3 + 4
                //        0 1 2 3 4 5 6
                //
                Double a = 0; int n; string s, c;
                int ini;
                //    Averiguo A
                s = "";
                for (n = i - 1; n >= 0; n--)
                {
                    c = t.Substring(n, 1);
                    if (vNum.IndexOf(c) > -1)
                    {
                        //Armar el valor
                        s = c + s;
                    }
                    else { break; }
                }

                if (s.Length > 0) { a = Convert.ToDouble(s); }
                ini = n + 1;
                //    Averiguo B
                s = "";
                for (n = i + 1; n <= t.Length - 1; n++)
                {
                    c = t.Substring(n, 1);
                    if (vNum.IndexOf(c) > -1)
                    {
                        // Armar el valor
                        s += c;
                    }
                    else { break; }

                }
                Double s2 = 0;
                if (Double.TryParse(s, out s2) == true) { a = s2 * a; }
                //    'Reeeeeeemplazo t con el valor calculado
                t = String.Format("{0}{1}{2}", t.Substring(0, ini), a.ToString(), t.Substring(n));
                i = t.IndexOf("*");

            }
            return t;
        }
        private string Calcular_Division(string t)
        {
            int i = t.IndexOf("/");
            //'Por las dudas, permite cualquier formato
            t = t.Replace(".", ",");

            string vNum = "0123456789,";

            while (i > -1)
            {
                //    'Hay una division, buscar ambos valores y calcularlos
                //    'Ej: 1 + 2 / 3 + 4
                //    '    0 1 2 3 4 5 6
                //
                //    Dim a As Double, n As Integer, s, c As String
                double a = 0; int n = 0; string s = "", c = "";
                int ini = 0;

                //    'Averiguo A
                s = "";
                for (n = i - 1; n >= 0; n--)
                {
                    c = t.Substring(n, 1);
                    if (vNum.IndexOf(c) > -1)
                    {

                        //            'Armar el valor
                        s = c + s;
                    }
                    else
                    {
                        break;
                    }
                }
                if (s.Length > 0) { a = Convert.ToDouble(s); }

                ini = n + 1;
                //    'Averiguo B
                s = "";
                for (n = i + 1; n <= t.Length - 1; n++)
                {
                    c = t.Substring(n, 1);
                    if (vNum.IndexOf(c) > -1)
                    {
                        //            'Armar el valor
                        s += c;
                    }
                    else { break; }                    
                }
                Double b = 0;
                if (double.TryParse(s, out b)) 
                {
                    if (b > 0) { a = a / b; }
                }
                else { a = 0; }
                //    'Reeeeeeemplazo t con el valor calculado
                t = String.Format("{0}{1}{2}", t.Substring(0, ini), a.ToString(), t.Substring(n));
                i = t.IndexOf("/");
            }
            return t;
        }
    }


}
