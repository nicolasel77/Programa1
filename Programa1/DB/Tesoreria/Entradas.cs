namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Entradas
    {

        public Entradas()
        {
        }
        public Entradas(int iD, DateTime fecha, Tipos_Entradas tE, int id_SubTipoEntrada, string descripcion, double importe)
        {
            ID = iD;
            Fecha = fecha;
            TE = tE;
            Id_SubTipoEntrada = id_SubTipoEntrada;
            Descripcion = descripcion;
            Importe = importe;
        }

        /// <summary>
        /// El ID es automático.
        /// </summary>
        public int ID { get; set; }
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Tipo Entradas
        /// </summary>
        public Tipos_Entradas TE { get; set; } = new Tipos_Entradas();
        public int Id_SubTipoEntrada { get; set; }        

        [MaxLength(500, ErrorMessage = "El campo Descripción solo puede tener 500 caracteres.")]
        public string Descripcion { get; set; }
        public Double Importe { get; set; }


        #region " Editrar Datos "
        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE CD_Entradas SET " +
                    $" Fecha='{Fecha:MM/dd/yy}', ID_TipoEntrada={TE.Id_Tipo}, ID_SubTipoEntrada={Id_SubTipoEntrada}" +
                    $", Descripcion='{Descripcion}', Importe={Importe.ToString().Replace(",", ".")}" +
                    $" WHERE ID={ID}", sql);
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
            int n = MaxId();

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO CD_Entradas (Fecha, ID_TipoEntrada, ID_SubTipoEntrada, Descripcion, Importe) " +
                    $"VALUES('{Fecha:MM/dd/yy}', {TE.Id_Tipo}, {Id_SubTipoEntrada}, '{Descripcion}', {Importe.ToString().Replace(",", ".")})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();
                sql.Close();

                int n2 = MaxId();
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM CD_Entradas WHERE ID={ID}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                command = new SqlCommand($"DELETE FROM Fecha_Entregas WHERE ID_Entradas={ID}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;                

                d = command.ExecuteNonQuery();

                ID = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        #endregion 

        #region " Devolver Datos "
        public DataTable Datos(string filtro = " ID=-1")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Entradas " + filtro, conexionSql);
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
        /// Devuelve la suma de entradas a la fecha seleccionada.
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public Double Total_AFecha(DateTime f)
        {
            Double t = 0;
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(ISNULL(Importe, 0)) FROM CD_Entradas WHERE Fecha<='{f:MM/dd/yy}'", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();

                t = Convert.ToDouble(d);
            }
            catch (Exception)
            {
                t = 0;
            }
            return t;
        }

        public string Nombre_SubTipo()
        {
            string s = "";
            if (TE.Id_Tipo != 0)
            {
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
                object d = null;

                TE.grupoE.Id = TE.Grupo;

                s = $"SELECT TOP 1 {TE.grupoE.Campo_Nombre} FROM {TE.grupoE.Tabla} WHERE {TE.grupoE.Campo_Id}={Id_SubTipoEntrada}";
                try
                {
                    SqlCommand comandoSql = new SqlCommand(s, conexionSql);

                    conexionSql.Open();

                    comandoSql.CommandType = CommandType.Text;
                    d = comandoSql.ExecuteScalar();

                    conexionSql.Close();

                    s = Convert.ToString(d);
                }
                catch (Exception)
                {
                    s = "";
                }
            }
            return s;
        }

        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM CD_Entradas", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToInt32(d);
        }
        #endregion
    }
}
