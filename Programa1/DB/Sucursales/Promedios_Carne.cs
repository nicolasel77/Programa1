namespace Programa1.DB.Sucursales
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Programa1.Clases;
    class Promedios_Carne : c_Base
    {

        public Promedios_Carne()
         {
            Tabla = "Promedios_Carne";
            Vista = "Promedios_Carne";
        }


    public Productos Producto { get; set; } = new Productos();
    public double Kilos { get; set; }

    public DataTable Datos_prom(string filtro = "")
        {
            return Datos_Vista("", "Id_Prod, CONVERT(DECIMAL(10,3), kg) as kg, Id_lista", "Id_lista DESC, Id_Prod");
        }

        public DataTable Nombres_list()
        {
            return Datos_Genericos("SELECT Nombre FROM Promedios_carne_nombres ORDER BY Id DESC");
        }

        public int nvo_idlista()
        {
            return Convert.ToInt32(Dato_Generico("SELECT ISNULL(MAX(Id),0) FROM Promedios_carne_nombres"));
        }

        public void Agregar_Prom(int Id_lista)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Promedios_Carne (Id_Lista, Id_Prod, kg) " +
                        $"VALUES({Id_lista}, {Producto.ID}, {Kilos.ToString().Replace(",", ".")})", sql);
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

        public void Agregar_List(string Nom_List)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Promedios_carne_nombres (Nombre) " +
                        $"VALUES('{Nom_List}')", sql);
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

        public DataTable datosunidos()
        {
            DataTable dt = Datos_prod();
            DataTable dt2 = Datos_Totales();
            if (dt2.Rows.Count < 1)
            { 
                for (int i = 1; i <= Convert.ToInt32(Dato_Generico("SELECT COUNT(DISTINCT Id) FROM vw_Productos WHERE Id IN (1, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58)")); i++)
                {
                    DataRow dr = dt2.NewRow();
                    dr[1] = "$0";
                    dr[2] = "0";
                    dt2.Rows.Add(dr);
                }
            }
            if (dt2.Columns.Count > 0 & dt2.Rows.Count == dt.Rows.Count)
            {
                for (int j = 1; j < dt2.Columns.Count; j++)
                {
                    dt.Columns.Add("",dt2.Columns[j].DataType);
                    dt.Columns[dt.Columns.Count-1].ColumnName = dt2.Columns[j].ColumnName;
                    for (int i = 0; i < dt.Rows.Count; i++)
                {
                        dt.Rows[i][dt.Columns.Count - 1] = dt2.Rows[i][j];
                }
                }
            }

            return dt;
        }

        public DataTable Datos_prod(string filtro = "")
        {
            return Producto.Datos_Vista("Id IN (1, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58)", "Id, Nombre,0.00 as Kilos, FORMAT(0.00,'P2') as Porcentaje, 0.00 as Prom_Kilos, " +
                "(SELECT TOP 1 precio FROM Precios_Sucursales WHERE Id_Productos = vw_Productos.id ORDER BY Fecha DESC) precio, 0.00 as Total");
        }

        public DataTable Datos_Totales(string filtro = "")
        {
            return Datos_Genericos("SELECT Id_Prod, ISNULL(((SELECT TOP 1 Precio FROM Precios_Sucursales WHERE Id_Productos = Promedios_Carne_fijos.Id_Prod ORDER BY Fecha DESC)*kg),0) as Promedio, kg FROM Promedios_Carne_fijos ORDER BY Id_Prod");
        }

        public DataTable lista_precios(string suc, DateTime fecha)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            string filtro = $"Fecha <= '{fecha.ToString("MM/dd/yyyy")}'";
           filtro = h.Unir(suc,filtro);
        return Datos_Genericos($"SELECT Id, ISNULL((SELECT TOP 1 Precio FROM Precios_Sucursales WHERE Id_Productos = Productos.Id AND {filtro} ORDER BY fecha DESC),0) " +
            $"FROM Productos WHERE Id IN (1, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58) ORDER BY Id");
        }
        public DataTable Fechas()
        {
            Precios_Sucursales pr = new Precios_Sucursales();
            return pr.Fechas(1);
        }

        public void Actualizar_promedios_fijos(int id_prod, double kg)
        {
            if (id_prod > 0)
            { 
            Ejecutar_Comando($"UPDATE Promedios_Carne_fijos SET kg = {kg} WHERE Id_Prod = {id_prod}");
            }
        }
    }
}
