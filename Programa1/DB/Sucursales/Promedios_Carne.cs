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

        public DataTable Datos_prod(string filtro = "")
        {
            return Producto.Datos_Vista("Id IN (1, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58)", "Id, Nombre,0.00 as Kilos, FORMAT(0.00,'P2') as Porcentaje, 0.00 as Prom_Kilos, " +
                "(SELECT TOP 1 precio FROM Precios_Sucursales WHERE Id_Productos = vw_Productos.id ORDER BY Fecha DESC) precio, 0 as Total");
        }

        public DataTable Datos_Totales(string filtro = "")
        {
            return Datos_Vista("", "Id_Prod, (CONVERT(DECIMAL(10,3),(SUM(CONVERT(DECIMAL(10,3), kg))/(SELECT COUNT(DISTINCT Id_Lista) FROM Promedios_Carne)))) as totales", "Id_Prod", "Id_Prod");
        }

        public DataTable lista_precios(string suc, DateTime fecha)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            string filtro = $"Fecha <= '{fecha.ToString("MM/dd/yyyy")}'";
           filtro = h.Unir(suc,filtro);
        return Datos_Genericos($"SELECT Id, ISNULL((SELECT TOP 1 Precio FROM Precios_Sucursales WHERE Id_Productos = Productos.Id AND {filtro} ORDER BY fecha DESC),0) " +
            $"FROM Productos WHERE Id IN (1, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 51, 52, 54, 57, 58) ORDER BY Id");
        }
    }
}
