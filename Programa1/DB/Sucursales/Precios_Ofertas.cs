namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Lista_Ofertas : c_Base
    {
        public Lista_Ofertas()
        {
            Vista = "vw_PreciosOfertas";
            Campo_ID = "Orden";
        }
               

        public int Orden { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public string Descripcion { get; set; }

        public Single Costo { get; set; }

        public Single Buscar_Costo()
        {
            try
            {
                var dt = new DataTable("Datos");
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                string sel = $"SELECT TOP 1 * FROM vw_PreciosOfertas WHERE Id_Productos={Producto.ID} ORDER BY Orden";
                
                SqlCommand comandoSql = new SqlCommand(sel, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Orden = Convert.ToInt32(dr["Orden"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Costo = Convert.ToSingle(dr["Costo"]);


            }
            catch (Exception)
            {
                Orden = 0;
                Costo = 0;
                Producto.ID = 0;
                Descripcion = "";
            }
            return Costo;
        }
        public Single Buscar_SiguienteCosto()
        {
            try
            {
                var dt = new DataTable("Datos");
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                string sel = $"SELECT TOP 1 * FROM vw_PreciosOfertas WHERE Orden>{Orden} ORDER BY Orden";

                SqlCommand comandoSql = new SqlCommand(sel, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Orden = Convert.ToInt32(dr["Orden"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Costo = Convert.ToSingle(dr["Costo"]);


            }
            catch (Exception)
            {
                Orden = 0;
                Costo = 0;
                Producto.ID = 0;
                Descripcion = "";
            }
            return Costo;
        }

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }

        public new void Actualizar()
        {
            Actualizar("Orden", Orden);
            Actualizar("ID_Productos", Producto.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Costo", Costo);
            
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Precios_Ofertas (Orden, Id_Productos, Descripcion, Costo) " +
                    $"VALUES({Orden}, {Producto.ID}, '{Descripcion}', {Costo.ToString().Replace(",", ".")} )", sql);
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
        
    }
}
