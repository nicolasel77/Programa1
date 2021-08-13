namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class Tarjetas : c_Base
    {

        public Tarjetas()
        {
            ID_Automatico = true;
            Tabla = "dbGastos.dbo.vw_EntradasTarjeta";
            Vista = "dbGastos.dbo.vw_EntradasTarjeta";
        }

        public string Fecha { get; set; }
        public string sucs { get; set; }
        public string Tipos { get; set; }
        public Boolean Agrupar { get; set; }
        public Boolean aSucs { get; set; }
        public Boolean aFecha { get; set; }
        public Boolean aTipo { get; set; }
        public Boolean OrdenxSuc { get; set; }
        public bool aAcreditados { get; set; }

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }

        public DataTable Datos_Resumen()
        {
            if (Fecha.Length > 0)
            {
                string s = "";
                string campos = "*";
                string OrderBy = "";
                Herramientas h = new Herramientas();
                s = h.Unir(Fecha, sucs);
                if (aAcreditados == true) { s = h.Unir(s, " Acreditado = 1 "); }
                if (Tipos.Length > 0) { s = h.Unir(s, $"Id_Tipo IN{Tipos}"); }
                campos = "Fecha, Suc, Id_Tipo, Nombre, Importe, Acreditado";
                if (Agrupar == true)
                {
                    campos = "";
                    if (aFecha == true) { campos = h.Unir(campos, "Fecha", ","); } 
                    if (aSucs == true) { campos = h.Unir(campos, "Suc", ","); }
                    if (aTipo == true) { campos = h.Unir(campos, "Id_Tipo, Nombre", ","); }
                    s = s + " GROUP BY " + campos;
                    if (OrdenxSuc == false) { OrderBy = campos; } else { if (campos.IndexOf(", Suc") > -1) { OrderBy = "Suc ," + campos.Replace(", Suc", ""); } }
                    campos = h.Unir(campos , " SUM(Importe) as Importe ", ",");
                }
                else
                {
                OrderBy = OrdenxSuc == false ? "Fecha, Suc" : "suc, Fecha";
                }
                return Datos_Vista(s, campos, OrderBy);
            }
            return null;
        }

        public Double Total_AFecha(DateTime f)
        {
            Double t = 0;
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(ISNULL(Importe, 0)) FROM CD_Tarjetas WHERE Fecha<='{f:MM/dd/yy}'", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();

                t = Convert.ToDouble(d);
            }
            catch (Exception)
            {
                t = 0;
            }
            return t;
        }
    }
}