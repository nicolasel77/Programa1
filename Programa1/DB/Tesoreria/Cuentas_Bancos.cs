namespace Programa1.DB.Tesoreria
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    class Cuentas_Bancos
    {
        public Cuentas_Bancos()
        {
        }

        public int ID { get; set; }
        
        public Tipo_CuentasBancos Tipo { get; set; } = new Tipo_CuentasBancos();
        public Bancos Banco { get; set; } = new Bancos();

        public string Nombre { get; set; }

        public string Razon_Social { get; set; }
        
        public string Numero { get; set; }
        public string Sucursal { get; set; }



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
                string Cadena = "SELECT * FROM Cuentas_Bancos {filtro} ORDER BY Id";

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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Cuentas_Bancos WHERE Id=" + ID, sql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);



                if (dt.Rows.Count == 0)
                {
                    Nombre = "";
                    return false;
                }
                else
                {
                    Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }

        }


        #region " Editar Datos "
        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE Cuentas_Bancos SET " +
                    "Nombre='{1}'" +
                    "Id_Tipo={2}" +
                    "Id_Banco={3}" +
                    "Razon_Social='{4}'" +
                    "Numero='{5}'" +
                    "Sucursal='{6}'" +
                    " WHERE Id={0}", ID, Nombre, Tipo.ID, Banco.ID, Razon_Social, Numero, Sucursal), sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO Cuentas_Bancos (Id_Tipo, Id_Banco, Nombre, Razon_Social, Numero, Sucursal) VALUES({Tipo.ID}, {Banco.ID}, '{Nombre}', '{Razon_Social}', '{Sucursal}')", sql);
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
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Cuentas_Bancos WHERE Id={0}", ID), sql);
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
