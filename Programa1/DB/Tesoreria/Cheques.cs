namespace Programa1.DB.Tesoreria
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Cheques
    {
        public Cheques()
        {
        }

        public int ID { get; set; }

        public Bancos Banco { get; set; } = new Bancos();

        public int Numero { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Acreditacion { get; set; }
        public double Importe { get; set; }

        #region " Devolver Datos "
        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                string Cadena = "SELECT Id, Nombre FROM Cheques {filtro} ORDER BY Id";

                SqlCommand comandoSql = new SqlCommand(Cadena, conexionSql);
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

        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Cheques WHERE Numero=" + Numero, sql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);



                if (dt.Rows.Count == 0)
                {
                    Numero = 0;
                    return false;
                }
                else
                {
                    Numero = Convert.ToInt32(dt.Rows[0]["Numero"]); 
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }

        }
        #endregion


        #region " Editar Datos "
        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE Cheques SET Id_Banco={0}, Numero={1}, Fecha_Entrada='{2}', Fecha_Acreditacion='{3}' WHERE Id={4}", Banco.ID, Numero, Fecha_Entrada.ToString("MM/dd/yyyy"), Fecha_Acreditacion.ToString("MM/dd/yyyy"), Importe.ToString().Replace(",", "."), ID), sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO Cheques (Id_Banco, Numero, Fecha_Entrada, Fecha_Acreditacion, Importe) VALUES({Banco.ID}, {Numero}, '{Fecha_Entrada.ToString("MM/dd/yyyy")}', '{Fecha_Acreditacion.ToString("MM/dd/yyyy")}')", sql);
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
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Cheques WHERE Id={0}", ID), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                ID = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        #endregion

    }
}
