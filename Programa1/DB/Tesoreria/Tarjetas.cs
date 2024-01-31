namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Tarjetas : c_Base
    {

        public Tarjetas()
        {
            ID_Automatico = true;
            Tabla = "dbGastos.dbo.Entradas_Tarjeta";
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

        public int sucO { get; set; }
        public int sucD { get; set; }
        public DateTime fechai { get; set; }

        private Sucursales.Sucursales sucursales = new Sucursales.Sucursales();
        public Tipos_Tarjeta tipos_Tarjeta = new Tipos_Tarjeta();


        public new DataTable Datos(string filtro = "")
        {
            return Datos(filtro);
        }

        public DataTable datos_lotes(string Filtro)
        {
            return Datos_Vista($"{Filtro} AND Suc = {sucO}", "DISTINCT Lote", "Lote");
        }

        public DataTable sucdatos()
        {
            return sucursales.Datos("Ver = 1 AND Propio = 1");
        }

        public DataTable Datos_Vista(string filtro = "")
        {
            return Datos_Vista(filtro, "Id, Fecha, Id_Tipo, Nombre, Importe, Lote, Tarjeta, Comprobante", "Fecha, Id_tipo, lote, Importe");
        }

        public DataTable Datos_Resumen()
        {
            if (Fecha.Length > 0)
            {
                string s;
                string campos;
                string OrderBy = "";
                Herramientas h = new Herramientas();
                s = h.Unir(Fecha, sucs);
                if (aAcreditados == true) { s = h.Unir(s, " Acreditado = 1 "); }
                if (Tipos.Length > 0) { s = h.Unir(s, $"Id_Tipo IN{Tipos}"); }
                campos = "Fecha, Suc, Sucursal, Id_Tipo, Nombre, Importe, Acreditado";
                if (Agrupar == true)
                {
                    campos = "";
                    if (aFecha == true) { campos = h.Unir(campos, "Fecha", ","); }
                    if (aSucs == true) { campos = h.Unir(campos, "Suc, Sucursal", ","); }
                    if (aTipo == true) { campos = h.Unir(campos, "Id_Tipo, Nombre", ","); }
                    s = s + " GROUP BY " + campos;
                    if (OrdenxSuc == false) { OrderBy = campos; } else { if (campos.IndexOf(", Suc") > -1) { OrderBy = "Suc ," + campos.Replace(", Suc, Sucursal", ", Sucursal"); } }
                    campos = h.Unir(campos, " SUM(Importe) as Importe ", ",");
                }
                else
                {
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

        public new void Actualizar()
        {
            Actualizar("Suc", sucD);
        }

        public void Backup_cambios(string cambios, int usuario)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                //Borrar direccion de carpeta
                SqlCommand command =
                    new SqlCommand($"DELETE FROM dbGastos.dbo.Revertir_Tarjetas WHERE Usuario = {usuario}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                if (sql.State == ConnectionState.Closed) { sql.Open(); }

                var d = command.ExecuteNonQuery();

                //Agregar nueva direccion de carpeta

                command =
                    new SqlCommand($"INSERT INTO dbGastos.dbo.Revertir_Tarjetas (Registros, Origen, Usuario) VALUES ('{cambios}', {sucO}, {usuario})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;

                d = command.ExecuteNonQuery();

                sql.Close();

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message, "Error");
            }
        }

        public void Revertir_cambios(int usuario) 
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                //Obtener los cambios
                int id_revertir = Convert.ToInt32(Dato_Generico($"SELECT Id FROM dbGastos.dbo.Revertir_Tarjetas WHERE Usuario = {usuario}"));
                int origen = Convert.ToInt32(Dato_Generico($"SELECT Origen FROM dbGastos.dbo.Revertir_Tarjetas WHERE Id = {id_revertir}"));
                string registros = Dato_Generico($"SELECT ISNULL((SELECT Registros FROM dbGastos.dbo.Revertir_Tarjetas WHERE Id ={id_revertir}), '')").ToString();

                //Deshacer los cambios
                if (registros.Length > 1)
                {
                    SqlCommand command =
                        new SqlCommand($"UPDATE dbGastos.dbo.entradas_tarjeta SET Suc = {origen} WHERE Id IN ({registros})", sql);
                    command.CommandType = CommandType.Text;
                    command.Connection = sql;
                    if (sql.State == ConnectionState.Closed) { sql.Open(); }

                    var d = command.ExecuteNonQuery();

                    //Borrar el registro

                    command =
                      new SqlCommand($"DELETE FROM dbGastos.dbo.Revertir_Tarjetas WHERE Id = {id_revertir}", sql);
                    command.CommandType = CommandType.Text;
                    command.Connection = sql;

                    d = command.ExecuteNonQuery();
                }
                else
                {
                    Exception e;
                    MessageBox.Show(null,"No hay cambios que revertir","Cuidado Pau!");
                }
                sql.Close();

            }
            catch (Exception e)
            {
               // MessageBox.Show(e.Message, "Error");
            }
        }

    }
}