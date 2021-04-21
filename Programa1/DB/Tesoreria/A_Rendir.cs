namespace Programa1.DB.Tesoreria
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class A_Rendir
    {
        public A_Rendir()
        {
        }

        public int ID_Entrada { get; set; }
        public int ID_Salida { get; set; }
        public int ID_NARendir { get; set; }

        #region " Devolver Datos "
        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string Cadena = $"SELECT * FROM vw_ARendirSalidas {filtro} ORDER BY Fecha";

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

        public DataTable Salidas(string filtro)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            
            if (ID_NARendir != 0) { filtro = h.Unir(filtro, " ID_DetalleGastos=" + ID_NARendir); }            

            try
            {
                string Cadena = $"SELECT Fecha, Importe FROM CD_Gastos WHERE ID_TipoGastos=100 AND ID_SubTipoGastos=12 AND {filtro} ORDER BY Fecha";

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
        public DataTable Gastos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();


            if (ID_NARendir != 0) { filtro = h.Unir(filtro, " ID_NARendir=" + ID_NARendir); }
            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string Cadena = $"SELECT Fecha, ID_TipoGastos TG, Desc_Tipo Tipo, ID_SubTipoGastos ST, Desc_SubTipo SubTipo, ID_DetalleGastos DT, Descripcion, Importe FROM vw_ARendirGastos {filtro} ORDER BY Fecha";

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

        public DataTable Saldos(DateTime fecha)
        {

            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID, Nombre, dbo.f_SaldoARendir('{fecha:MM/dd/yy}', ID) AS Saldo  FROM Nombres_ARendir", conexionSql);
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


        #endregion



        #region " Editar Datos "
        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO A_Rendir (Id_Entrada, Id_Salida, Id_NARendir) VALUES({ID_Entrada}, {ID_Salida}, {ID_NARendir})", sql);
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

        public void Actualizar_Entrada()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE A_Rendir SET ID_NARendir={0} WHERE ID_Entrada={1}", ID_NARendir, ID_Entrada), sql);
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
        public void Actualizar_Salida()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE A_Rendir SET ID_NARendir={0} WHERE ID_Salida={1}", ID_NARendir, ID_Salida), sql);
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

        public void Borrar_Entrada()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM A_Rendir WHERE Id_Entrada={0}", ID_Entrada), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                ID_Entrada = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void Borrar_Salida()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM A_Rendir WHERE Id_Salida={0}", ID_Salida), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                ID_Salida = 0;

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
