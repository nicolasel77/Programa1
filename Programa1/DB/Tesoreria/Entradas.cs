namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Entradas : c_Base
    {

        public Entradas()
        {
            ID_Automatico = true;
            Tabla = "CD_Entradas";
            Vista = "vw_Entradas";
        }
      
      
        public DateTime Fecha { get; set; }
        public Cajas caja { get; set; } = new Cajas();

        /// <summary>
        /// Tipo Entradas
        /// </summary>
        public Tipos_Entradas TE { get; set; } = new Tipos_Entradas();
        public int Id_SubTipoEntrada { get; set; }

        /// <summary>
        /// Campo oculto usado por ahora para Numero de cheque.
        /// </summary>
        public int Cheque { get; set; }

        [MaxLength(500, ErrorMessage = "El campo Descripción solo puede tener 500 caracteres.")]
        public string Descripcion { get; set; }
        public Double Importe { get; set; }

        public void Cargar()
        {
            DataTable dt = Datos("ID=" + ID);

            if (dt != null)
            {
                Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                caja.ID = Convert.ToInt32(dt.Rows[0]["IDC"]);
                TE.Id_Tipo = Convert.ToInt32(dt.Rows[0]["ID_TipoEntrada"]);
                Id_SubTipoEntrada = Convert.ToInt32(dt.Rows[0]["ID_SubTipoEntrada"]);
                Descripcion = Convert.ToString(dt.Rows[0]["Descripcion"]);
                Importe = Convert.ToDouble(dt.Rows[0]["Importe"]);
            }
        }

        private A_Rendir a_Rendir { get; set; } = new A_Rendir();

        #region " Editrar Datos "

        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Caja", caja.ID);
            Actualizar("ID_TipoEntrada", TE.Id_Tipo);
            Actualizar("ID_SubTipoEntrada", Id_SubTipoEntrada);            
            Actualizar("Descripcion", Descripcion);
            Actualizar("Importe", Importe);            
            Actualizar("Cheque", Cheque);            
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(cadCN);
            int n = Max_ID();

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO CD_Entradas (Fecha, ID_Caja, ID_TipoEntrada, ID_SubTipoEntrada, Descripcion, Cheque, Importe) " +
                    $"VALUES('{Fecha:MM/dd/yy}', {caja.ID}, {TE.Id_Tipo}, {Id_SubTipoEntrada}, '{Descripcion}', {Cheque}, {Importe.ToString().Replace(",", ".")})", sql);
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

        public new void Borrar()
        {
            Borrar("Fecha_Entregas", "ID_Entradas=" + ID);
            Borrar("CD_Entradas", "ID= " +ID);
        }
        #endregion

        #region " Devolver Datos "

        /// <summary>
        /// Devuelve un dt con el resumen de Tipos, Nombre en un rango de fechas.
        /// </summary>
        /// <param name="filtro">La fecha a filtrar.</param>
        /// <returns></returns>
        public DataTable Tipos_Rango(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(cadCN);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoEntrada, Nombre FROM vw_Entradas" +
                    $" {filtro}  GROUP BY ID_TipoEntrada, Nombre ORDER BY ID_TipoEntrada", conexionSql);
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
            var conexionSql = new SqlConnection(cadCN);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_SubTipoEntrada, Descripcion FROM vw_Entradas" +
                    $" {filtro}  GROUP BY ID_SubTipoEntrada, Descripcion ORDER BY ID_SubTipoEntrada", conexionSql);
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

        public new DataTable Datos(string filtro = " ID=-1")
        {
            return Datos_Vista(filtro);            
        }

        /// <summary>
        /// Devuelve un total por Tipo, Nombre, Total según la fecha seleccionada.
        /// </summary>
        /// <param name="filtro">Rango a filtrar.</param>
        /// <returns></returns>
        public DataTable TotalPorTipo(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(cadCN);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoEntrada ID, Nombre Descripcion, SUM(Importe) Total FROM vw_Entradas" +
                    $" {filtro}  GROUP BY ID_TipoEntrada, Nombre ORDER BY ID_TipoEntrada", conexionSql);
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
            var conexionSql = new SqlConnection(cadCN);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_TipoEntrada IDT, Nombre, ID_SubTipoEntrada ID, Descripcion, SUM(Importe) Total FROM vw_Entradas" +
                    $" {filtro}  GROUP BY ID_TipoEntrada, Nombre, ID_SubTipoEntrada, Descripcion ORDER BY ID_TipoEntrada, ID_SubTipoEntrada", conexionSql);
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
            var conexionSql = new SqlConnection(cadCN);


            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha,ID_TipoEntrada IDT, Nombre, ID_SubTipoEntrada ID, Descripcion, Importe Total FROM vw_Entradas" +
                    filtro + " ORDER BY Nombre, Descripcion, Fecha ", conexionSql);
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
            var conexionSql = new SqlConnection(cadCN);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(ISNULL(Importe, 0)) FROM CD_Entradas WHERE ID_TipoEntrada NOT IN(13) AND Fecha<='{f:MM/dd/yy}'", conexionSql);

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
                var conexionSql = new SqlConnection(cadCN);
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
               

        public bool Fecha_Cerrada()
        {
            return Fecha_Cerrada(Fecha);
        }

        public DataTable Entregas_AImportar()
        {
            DataTable dt = Datos_Genericos("SELECT ID, Fecha, Suc, Importe FROM Fecha_Entregas WHERE ID_Entradas IS NULL AND Suc<>0 ORDER BY Suc, Fecha");
            dt.Columns.Add("Sel", typeof(Boolean));

            return dt;
        }
        #endregion
    }
}
