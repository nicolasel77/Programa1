
namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Hacienda_Salidas : c_Base
    {        
        public Hacienda_Salidas()
        {
            
        }
        public Hacienda_Salidas(string tabla, string vista)
        {
            Tabla = tabla;
            Vista = vista;
        }

        public DateTime Fecha { get; set; }
        public Faena Faena { get; set; } = new Faena();
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public Single Costo_Salida { get; set; }
        public Single Media { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();        
        
        public void Cargar_CostoSalida()
        {
            precios.Fecha = Fecha;
            precios.Sucursal = Sucursal;
            precios.Producto = Faena.Producto;
            Costo_Salida = precios.Buscar();
        }

        public DataTable Datos_Salidas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Fecha, Id_Sucursales, Nombre, Tropa, Nombre_Categoria, Nombre_Producto, NBoleta, " +
                    $"Costo_Final, Costo_Salida, Media, Kilos AS Original, Total_Compra, Total_Salida FROM vw_Hacienda_Salidas {filtro} ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public DataTable Resumen_Salidas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id_Sucursales Suc, SUM(Media) Kilos, COUNT(Media) Cant " +
                    $"FROM vw_Hacienda_Salidas {filtro} " +
                    $"GROUP BY Id_Sucursales " +
                    $"ORDER BY Id_Sucursales", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public DataTable Boletas_Salidas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) filtro = " WHERE " + filtro;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT DISTINCT NBoleta FROM vw_Hacienda_Salidas {filtro} ORDER BY NBoleta DESC", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        public DataTable Tropas_Salidas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) filtro = " WHERE " + filtro;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT DISTINCT Tropa FROM vw_Hacienda_Salidas {filtro} ORDER BY Tropa DESC", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Hacienda_Salidas (Id, Fecha, Id_Sucursales, Id_Faena, Costo_Salida, Media) " +
                        $"VALUES({ID}, '{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Faena.ID}, {Costo_Salida.ToString().Replace(",", ".")}, {Media.ToString().Replace(",", ".")})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        
        public DateTime Max_Fecha()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Fecha) FROM Hacienda_Salidas", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToDateTime(d);
        }

        

        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Hacienda_Salidas WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Faena.ID = Convert.ToInt32(dr["Id_Faena"]);
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Costo_Salida = Convert.ToSingle(dr["Costo_Salida"]);
                Media = Convert.ToSingle(dr["Media"]);

            }
            catch (Exception)
            {
                ID = 0;
            }


        }

        internal void Actualizar_Costos(DateTime f1, DateTime f2)
        {
            Ejecutar_Comando($"sp_Acualizar_Costos_Salida '{f1:MM/dd/yy}', '{f2:MM/dd/yy}'");
        }
    }
}
