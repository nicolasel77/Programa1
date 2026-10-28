namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using Programa1.DB.Tesoreria;
    using System;
    using Herramientas;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class Entregas_Sucursales : c_Base
    {
        public Entregas_Sucursales()
        {
            ID_Automatico = true;
            Tabla = "dbGastos.dbo.Entregas_Sucursales";
            Vista = "dbGastos.dbo.vw_Entregas_Sucursales";
        }

        public string Fecha { get; set; } = "";
        public string Sucs { get; set; }
        public string Tipos { get; set; }
        public Single Importe { get; set; }

        public bool Agrupar { get; set; }
        public bool aSucs { get; set; }
        public bool aFecha { get; set; }
        public bool aTipo { get; set; }
        public bool OrdenxSuc { get; set; }


        private Sucursales sucursales = new Sucursales();

        public Tipos_Tarjeta tipos_Tarjeta = new Tipos_Tarjeta();


        public new DataTable Datos(string filtro = "")
        {
            return Datos(filtro);
        }


        public DataTable sucdatos()
        {
            return sucursales.Datos("Ver = 1 AND Propio = 1");
        }

        public DataTable Datos_Vista(string filtro = "")
        {
            return Datos_Vista(filtro, "Id, CAST(Fecha AS DATE), Tipo, Nombre, Importe, Lote, Tarjeta, Comprobante", "CAST(Fecha AS DATE), Tipo");
        }

        public DataTable Datos_Resumen()
        {
            if (Fecha.Length > 0)
            {
                string s;
                string campos;
                string OrderBy = "";
                Herramientas h = new Herramientas();
                s = h.Unir(Fecha, Sucs);

                if (Tipos.Length > 0) { s = h.Unir(s, $"Tipo IN{Tipos}"); }
                campos = "CAST(Fecha AS DATE) AS Fecha, Suc, Nombre, Tipo, Descripcion, Importe";
                if (Agrupar == true)
                {
                    campos = "";
                    if (aFecha == true) { campos = h.Unir(campos, "CAST(Fecha AS DATE) AS Fecha", ","); }
                    if (aSucs == true) { campos = h.Unir(campos, "Suc, Nombre", ","); }
                    if (aTipo == true) { campos = h.Unir(campos, "Tipo, Descripcion", ","); }
                    s = s + " GROUP BY " + campos.Replace("CAST(Fecha AS DATE) AS ", "");
                    if (OrdenxSuc == false) { OrderBy = campos; } else { if (campos.IndexOf(", Suc") > -1) { OrderBy = "Suc ," + campos.Replace(", Suc, Nombre", ", Nombre"); } }
                    OrderBy = OrderBy.Replace("CAST(Fecha AS DATE) AS ", "");
                    campos = h.Unir(campos, " SUM(Importe) as Importe ", ",");
                }
                else
                {
                    campos = "Id," + campos;
                    OrderBy = OrdenxSuc == false ? "Fecha, Suc" : "suc, Fecha";
                }
                return Datos_Vista(s, campos, OrderBy);
            }
            return null;
        }

        public DataTable Datos_Resumen_modi_tar(string f = "")
        {
            if (f.Length > 0)
            {
                string campos;
                campos = "Fecha, SUM(Importe) as Importe";
                return Datos_Vista(f + " GROUP BY Fecha ", campos, "Fecha");
            }
            return null;
        }



    }
}
