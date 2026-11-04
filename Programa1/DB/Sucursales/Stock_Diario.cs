namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Media;
    using System.Windows.Forms;

    /// <summary>
    /// Stock diario de carne y pollo (kilos) por sucursal y fecha.
    /// Lo cargan las sucursales desde el inicio de Sistema-Web (tabla Stock_Diario, un registro por sucursal y fecha).
    /// </summary>
    public class Stock_Diario : c_Base
    {
        public Stock_Diario()
        {
            Tabla = "Stock_Diario";
            // Vista armada en línea para no depender de una vista en la base
            Vista = "(SELECT S.Id, S.Fecha, S.Id_Sucursales, Su.Nombre, S.Carne, S.Pollo, S.Modificado " +
                    "FROM Stock_Diario S LEFT JOIN Sucursales Su ON Su.Id = S.Id_Sucursales) AS vw_StockDiario";
            ID_Automatico = true;
        }

        public DateTime Fecha { get; set; }

        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();

        public decimal Carne { get; set; }

        public decimal Pollo { get; set; }


        public new void Actualizar()
        {
            var cnn = new SqlConnection(cadCN);
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Stock_Diario SET Fecha=@f, Id_Sucursales=@s, Carne=@c, Pollo=@p, Modificado=GETDATE() WHERE Id=@id", cnn);
                cmd.Parameters.Add("@f", SqlDbType.Date).Value = Fecha.Date;
                cmd.Parameters.Add("@s", SqlDbType.Int).Value = Sucursal.ID;
                cmd.Parameters.Add("@c", SqlDbType.Decimal).Value = Carne;
                cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = Pollo;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public new void Agregar()
        {
            var cnn = new SqlConnection(cadCN);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Stock_Diario (Fecha, Id_Sucursales, Carne, Pollo) VALUES (@f, @s, @c, @p); SELECT CAST(SCOPE_IDENTITY() AS INT);", cnn);
                cmd.Parameters.Add("@f", SqlDbType.Date).Value = Fecha.Date;
                cmd.Parameters.Add("@s", SqlDbType.Int).Value = Sucursal.ID;
                cmd.Parameters.Add("@c", SqlDbType.Decimal).Value = Carne;
                cmd.Parameters.Add("@p", SqlDbType.Decimal).Value = Pollo;

                cnn.Open();
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                cnn.Close();
            }
            catch (Exception e)
            {
                ID = 0;
                MessageBox.Show("No se pudo guardar el registro." + Environment.NewLine + e.Message, "Error");
            }
        }

        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(cadCN);

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Fecha, Id_Sucursales, Carne, Pollo FROM Stock_Diario WHERE Id=@id", cnn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Carne = Convert.ToDecimal(dr["Carne"]);
                Pollo = Convert.ToDecimal(dr["Pollo"]);
            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Sucursal.ID = 0;
                Carne = 0;
                Pollo = 0;
            }
        }

        /// <summary>
        /// True si ya hay otro registro con la misma fecha y sucursal (la tabla admite uno solo).
        /// </summary>
        public bool Existe_Dato()
        {
            var cnn = new SqlConnection(cadCN);
            int d = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Stock_Diario WHERE Fecha=@f AND Id_Sucursales=@s AND Id<>@id", cnn);
                cmd.Parameters.Add("@f", SqlDbType.Date).Value = Fecha.Date;
                cmd.Parameters.Add("@s", SqlDbType.Int).Value = Sucursal.ID;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cnn.Open();
                d = (int)cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }
            return (d >= 1);
        }
    }
}
