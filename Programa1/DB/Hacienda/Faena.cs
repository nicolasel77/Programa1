using Programa1.Clases;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB
{
    public class Faena : c_Base
    {
        public Faena()
        {
            Tabla = "Faena";
            Vista = "vw_Faena";            
        }              
        
        public NBoletas nBoleta { get; set; } = new NBoletas();
        public DateTime Fecha { get; set; }
        public Categorias Categoria { get; set; } = new Categorias();
        public int NRomaneo { get; set; }
        public int Tropa { get; set; }
        public Frigorificos Frigorifico { get; set; } = new Frigorificos();
        public Productos Producto { get; set; } = new Productos();
        public Single Recupero { get; set; }
        public Single Kilos { get; set; }
        
        public void Borrar_Faena()
        {
            Ejecutar_Comando("DELETE FROM Faena WHERE NBoleta=" + nBoleta.ID);
        }

        public DataTable Romaneos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT NRomaneo, COUNT(Kilos) AS Cant, SUM(Kilos) AS Kilos FROM vw_Faena WHERE NBoleta={nBoleta.ID}" +
                    $" GROUP BY NRomaneo", conexionSql);
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
        public DataTable Stock_Faena(DateTime f)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Reparto, Tropa, Nombre_Producto Prod, Nombre_Categoria Cat, COUNT(Kilos) Cant, SUM(Kilos) Kilos, Costo, Costo_Carne, Fecha, NBoleta " +
                    $"FROM vw_Faena WHERE Fecha <='{f.ToString("MM/dd/yy")}' AND Id NOT IN(SELECT Id_Faena FROM Hacienda_Salidas WHERE Fecha <='{f.ToString("MM/dd/yy")}') " +
                    $"GROUP BY Reparto, Tropa, Nombre_Producto, Nombre_Categoria, Costo, Costo_Carne, Fecha, NBoleta " +
                    $"ORDER BY Reparto, Fecha", conexionSql);
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
        public DataTable Stock_DetalleFaena(DateTime f, string filtro ="")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) filtro = " AND " + filtro;
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, Id_Categorias Cat, Nombre_Categoria Descr, Id_Frigorificos Frig, Nombre_Frigorifico Nombre" +
                    $", NRomaneo, Tropa, Id_Productos Prod, Nombre_Producto Producto, Recupero Recup, Kilos " +
                    $"FROM vw_Faena " +
                    $"WHERE Fecha <='{f.ToString("MM/dd/yy")}' " +
                    $"AND Id NOT IN(SELECT Id_Faena FROM Hacienda_Salidas WHERE Fecha <='{f.ToString("MM/dd/yy")}')  " +
                    $"AND NBoleta={nBoleta.ID} {filtro}" +
                    $"ORDER BY Id", conexionSql);
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
        public DataTable Stock_Tipo(DateTime f)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Tipo_Stock Tipo, COUNT(Kilos) Cant, SUM(Kilos) Kilos, SUM(Costo_Carne*Kilos)/SUM(Kilos) Integracion " +
                    $"FROM vw_Faena WHERE Fecha<='{f.ToString("MM/dd/yy")}' AND Id NOT IN(SELECT Id_Faena FROM Hacienda_Salidas WHERE Fecha<='{f.ToString("MM/dd/yy")}') " +
                    $"GROUP BY Tipo_Stock", conexionSql);
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
        public DataTable Stock_Categorias(DateTime f)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Nombre_Categoria Cat, COUNT(Kilos) Cant, SUM(Kilos) Kilos, SUM(Costo_Carne*Kilos)/SUM(Kilos) Integracion " +
                    $"FROM vw_Faena WHERE Fecha<='{f.ToString("MM/dd/yy")}' AND Id NOT IN(SELECT Id_Faena FROM Hacienda_Salidas WHERE Fecha<='{f.ToString("MM/dd/yy")}') " +
                    $"GROUP BY Nombre_Categoria", conexionSql);
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
    }
}
