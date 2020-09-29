﻿namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    class Gastos
    {
        Detalle_Gastos dg = new Detalle_Gastos();

        public Gastos()
        {
        }

        /// <summary>
        /// El ID es automático.
        /// </summary>
        public int ID { get; set; }
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Tipo Gastos
        /// </summary>
        public Tipo_Gastos TG { get; set; } = new Tipo_Gastos();
        public int Id_SubTipoGastos { get; set; }
        public int Id_DetalleGastos { get; set; }
        public string Desc_SubTipo { get; set; }

        [MaxLength(500, ErrorMessage = "El campo Descripción solo puede tener 500 caracteres.")]
        public string Descripcion { get; set; }
        public Double Importe { get; set; }

        public bool Autorizado { get; set; }
        public DateTime Fecha_Autorizado { get; set; }


        #region " Editrar Datos "
        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE CD_Gastos SET " +
                    $" Fecha='{Fecha:MM/dd/yy}', ID_TipoGastos={TG.Id_Tipo}, Id_SubTipoGastos={Id_SubTipoGastos}" +
                    $", Id_DetalleGastos={Id_DetalleGastos}, Desc_SubTipo='{Desc_SubTipo}', Descripcion='{Descripcion}', Importe={Importe.ToString().Replace(",", ".")}" +
                    $", Autorizado={(Autorizado ? "1" : "0")}, Fecha_Autorizado='{Fecha_Autorizado:MM/dd/yy HH:mm}'" +
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
                SqlCommand command = new SqlCommand($"INSERT INTO CD_Gastos " +
                    $"(Fecha, ID_TipoGastos, ID_SubTipoGastos, Desc_SubTipo, ID_DetalleGastos, Descripcion, Importe, Autorizado, Fecha_Autorizado) " +
                    $"VALUES('{Fecha:MM/dd/yy}', {TG.Id_Tipo}, {Id_SubTipoGastos}, '{Desc_SubTipo}', {Id_DetalleGastos}, '{Descripcion}', " +
                    $"{Importe.ToString().Replace(",", ".")}, {(Autorizado ? "1" : "0")}, '{Fecha_Autorizado:MM/dd/yy HH:mm}')", sql);
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
                SqlCommand command = new SqlCommand($"DELETE FROM CD_Gastos WHERE ID={ID}", sql);
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

        #region " Devolver Datos "
        public DataTable Datos(string filtro = " ID=-1")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Gastos {filtro} ORDER BY ID", conexionSql);
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
        /// Devuelve un dt con el resumen de Tipos, Nombre en un rango de fechas.
        /// </summary>
        /// <param name="filtro">La fecha a filtrar.</param>
        /// <returns></returns>
        public DataTable Tipos_Rango(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoGastos, Desc_Tipo FROM vw_Gastos" +
                    $" {filtro}  GROUP BY ID_TipoGastos, Desc_Tipo ORDER BY ID_TipoGastos", conexionSql);
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
        /// Devuelve un dt con el resumen de SubTipo, Nombre en un rango de fechas.
        /// </summary>
        /// <param name="filtro">La fecha a filtrar.</param>
        /// <returns></returns>
        public DataTable SubTipos_Rango(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_SubTipoGastos, Desc_SubTipo FROM vw_Gastos" +
                    $" {filtro}  GROUP BY ID_SubTipoGastos, Desc_SubTipo ORDER BY ID_SubTipoGastos", conexionSql);
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
        /// Devuelve un dt con el resumen de Detalle, Nombre en un rango de fechas.
        /// </summary>
        /// <param name="filtro">La fecha a filtrar.</param>
        /// <returns></returns>
        public DataTable Detalles_Rango(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_DetalleGastos, Nombre FROM vw_DetallesGastos" +
                    $" {filtro}  GROUP BY ID_DetalleGastos, Nombre ORDER BY ID_DetalleGastos", conexionSql);
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
        /// Devuelve un total por Tipo, Nombre, Total según la fecha seleccionada.
        /// </summary>
        /// <param name="filtro">Rango a filtrar.</param>
        /// <returns></returns>
        public DataTable TotalPorTipo(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoGastos ID, Desc_Tipo Descripcion, SUM(Importe) Total FROM vw_Gastos" +
                    $" {filtro}  GROUP BY ID_TipoGastos, Desc_Tipo ORDER BY ID_TipoGastos", conexionSql);
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
        /// Devuelve un total por SubTipo, Nombre, Total según el Tipo y la fecha seleccionada.
        /// </summary>
        /// <param name="filtro">Tipo y rango a filtrar.</param>
        /// <returns></returns>
        public DataTable TotalPorSubTipo(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoGastos IDT, Desc_Tipo, ID_SubTipoGastos ID, Desc_SubTipo Descripcion, SUM(Importe) Total FROM vw_Gastos" +
                    $" {filtro}  GROUP BY ID_TipoGastos, Desc_Tipo, ID_SubTipoGastos, Desc_SubTipo ORDER BY ID_TipoGastos, ID_SubTipoGastos", conexionSql);
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
        /// Devuelve un total por Detalle, Nombre, Total según el Tipo y la fecha seleccionada.
        /// </summary>
        /// <param name="filtro">Tipo y rango a filtrar.</param>
        /// <returns></returns>
        public DataTable TotalPorDetalle(string filtro = "", bool Mostrar_Fecha = false)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string fe = Mostrar_Fecha ? "Fecha, " : "";

                SqlCommand comandoSql = new SqlCommand(
                    $"SELECT {fe}ID_TipoGastos IDT, Desc_Tipo, ID_SubTipoGastos ID_ST, Desc_SubTipo, ID_DetalleGastos ID, Descripcion" +
                    $", SUM(Importe) Total FROM vw_Gastos" +
                    $" {filtro}  GROUP BY {fe}ID_TipoGastos, Desc_Tipo, ID_SubTipoGastos, Desc_SubTipo, ID_DetalleGastos, Descripcion " +
                    $"ORDER BY {fe}ID_DetalleGastos", conexionSql);
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
        /// Devuelve la suma de Gastos a la fecha seleccionada.
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
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(ISNULL(Importe, 0)) FROM CD_Gastos WHERE Fecha<='{f:MM/dd/yy}'", conexionSql);

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
            if (TG.Id_Tipo != 0)
            {
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
                object d = null;

                if (TG.grupoS.Campo_Filtro.Length > 0) { s = $"{TG.grupoS.Campo_Filtro}={TG.Id_Tipo} AND "; }

                s = $"SELECT TOP 1 {TG.grupoS.Campo_Nombre} FROM {TG.grupoS.Tabla} WHERE {s} {TG.grupoS.Campo_Id}={Id_SubTipoGastos}";

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
        public string Nombre_Detalle()
        {
            string s = "";
            if (Id_DetalleGastos != 0)
            {
                dg.Id_Tipo = TG.Id_Tipo;
                dg.ID_Detalle = Id_DetalleGastos;
                s = dg.Nombre;
            }
            return s;
        }

        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM CD_Gastos", conexionSql);

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
