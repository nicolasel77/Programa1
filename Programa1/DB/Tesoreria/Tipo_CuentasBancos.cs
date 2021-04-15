namespace Programa1.DB.Tesoreria
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    class Tipo_CuentasBancos
    {
        public Tipo_CuentasBancos()
        {
        }

        public int ID { get; set; }
        public string Nombre { get; set; }

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
                string Cadena = "SELECT Id, Nombre FROM Tipo_CuentasBancos {filtro} ORDER BY Id";

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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Tipo_CuentasBancos WHERE Id=" + ID, sql);
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
    }
}
