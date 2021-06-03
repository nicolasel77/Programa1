namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Compra_Hacienda : c_Base
    {
        public enum Estados_Hacienda : byte
        {
            Sin_Chequear = 0,
            Aprovado = 1,
            Error = 2
        }

        public Compra_Hacienda()
        {
            Vista = "vw_CompraHacienda";
            Tabla = "Hacienda_Compras";            
        }

        public NBoletas NBoleta { get; set; }
        public Consignatarios Consignatario { get; set; }
        public Productos Producto { get; set; }
        public int Cabezas { get; set; }
        public Single Kilos { get; set; }
        public Single Costo { get; set; }
        public Single IVA { get; set; }
        public Byte Plazo { get; set; }
        public int Estado { get; set; }


        public new void Actualizar()
        {
            Actualizar("NBoleta", NBoleta.NBoleta);
            Actualizar("ID_Consignatarios", Consignatario.ID);
            Actualizar("Id_Productos", Producto.ID);
            Actualizar("Cabezas", Cabezas);
            Actualizar("Kilos", Kilos);
            Actualizar("Costo", Costo);
            Actualizar("Iva", IVA);
            Actualizar("Plazo", Plazo);
            Actualizar("Estado", Estado);

        }

        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Hacienda_Compras (NBoleta, Id_Consignatarios, Id_Productos, Cabezas, Kilos, Costo, IVA, Plazo) " +
                        $"VALUES({NBoleta.NBoleta},{Consignatario.ID},{Producto.ID},{Cabezas},{Kilos.ToString().Replace(",", ".")},{Costo.ToString().Replace(",", ".")},{IVA.ToString().Replace(",", ".")},{Plazo})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                int n2 = Max_ID();
                if (n == n2)
                {
                    ID = 0;
                    MessageBox.Show("No se pudo guardar el registro.", "Error");
                }
                else
                {
                    ID = n2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
                            

        public void Cargar_Boleta(int nb)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_CompraHacienda WHERE NBoleta=" + nb, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = Convert.ToInt32(dr["Id"]);
                NBoleta.NBoleta = Convert.ToInt32(dr["NBoleta"]);
                Consignatario.ID = Convert.ToInt32(dr["Id_Consignatarios"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Cabezas = Convert.ToInt32(dr["Cabezas"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);
                IVA = Convert.ToSingle(dr["IVA"]);
                Plazo = Convert.ToByte(dr["Plazo"]);
            }
            catch (Exception)
            {
                ID = 0;
            }


        }

        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_CompraHacienda WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                NBoleta.NBoleta = Convert.ToInt32(dr["NBoleta"]);
                Consignatario.ID = Convert.ToInt32(dr["Id_Consignatarios"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Cabezas = Convert.ToInt32(dr["Cabezas"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);
                IVA = Convert.ToSingle(dr["IVA"]);
                Plazo = Convert.ToByte(dr["Plazo"]);
            }
            catch (Exception)
            {
                ID = 0;
            }
        }
    }
}
