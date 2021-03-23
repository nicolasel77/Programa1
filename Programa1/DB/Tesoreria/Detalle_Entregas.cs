namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Detalle_Entregas
    {
        public Detalle_Entregas()
        {
        }

        /// <summary>
        /// El ID de la tabla CD_Entradas
        /// </summary>
        [Required]
        public int ID_Entradas { get; set; }

        /// <summary>
        /// Automático
        /// </summary>
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public Double Importe { get; set; }


        public DataTable Datos(String filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length != 0) { filtro = " WHERE " + filtro; }
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM Fecha_Entregas {filtro} ORDER By Fecha, ID", conexionSql);
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

        /// <summary>
        /// Devuelve el total cargado en el Id_Entradas
        /// </summary>
        /// <param name="ID_E">ID En caja diaria.</param>
        /// <returns></returns>
        public Double Total_IDEntradas(int ID_E)
        {
            Double t = 0;
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;
            
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ISNULL(SUM(Importe), 0) FROM Fecha_Entregas WHERE ID_Entradas={ID_E.ToString()}", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                t = Convert.ToDouble(d);

                conexionSql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                d = 0;
            }

            return Convert.ToInt32(t);
        }
        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            int n = MaxId();

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM Fecha_Entregas", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                int n2 = MaxId();
                if (n == n2)
                {
                    Id = 0;
                    MessageBox.Show("No se pudo guardar el registro.", "Error");
                }
                else
                {
                    Id = n2;
                }
                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToInt32(d);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Fecha_Entregas SET ID_Entradas={ID_Entradas}, Fecha='{Fecha:MM/dd/yy}'" +
                    $", Importe={Importe.ToString().Replace(",", ".")} WHERE Id={Id}", sql);
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

        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Fecha_Entregas (Id_Entradas, Fecha, Importe) " +
                    $"VALUES({ID_Entradas}, '{Fecha:MM/dd/yy}', {Importe.ToString().Replace(",", ".")})", sql);
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Fecha_Entregas WHERE Id={0}", Id), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();
                Id = 0;
                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        
    }
}
