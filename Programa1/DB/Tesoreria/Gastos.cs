namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using Programa1.DB.Varios;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    public class Gastos : c_Base
    {
        Detalle_Gastos dg = new Detalle_Gastos();

        public Gastos()
        {
            ID_Automatico = true;
            Tabla = "CD_Gastos";
            Vista = "vw_Gastos";
        }

        public DateTime Fecha { get; set; }
        public Cajas caja { get; set; } = new Cajas();

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
        public DateTime Fecha_Acreditacion { get; set; }
        public int Cheque { get; set; }

        public bool Autorizado { get; set; }
        public DateTime Fecha_Autorizado { get; set; }
        public Usuarios Usuario { get; set; } = new Usuarios();

        public bool EsARendir { get { return ID == 12; } }

        private A_Rendir a_Rendir { get; set; } = new A_Rendir();

        #region " Editrar Datos "
        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Caja", caja.ID);
            Actualizar("ID_TipoGastos", TG.Id_Tipo);
            Actualizar("Id_SubTipoGastos", Id_SubTipoGastos);
            Actualizar("Id_DetalleGastos", Id_DetalleGastos);
            Actualizar("Desc_SubTipo", Desc_SubTipo);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Importe", Importe);
            Actualizar("Fecha_Acreditacion", Fecha_Acreditacion);
            Actualizar("Cheque", Cheque);
            Actualizar("Autorizado", Autorizado);
            Actualizar("Fecha_Autorizado", Fecha_Autorizado);
            Actualizar("Usuario", Usuario.ID);            
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO CD_Gastos " +
                    $"(Fecha, ID_Caja, ID_TipoGastos, ID_SubTipoGastos, Desc_SubTipo, ID_DetalleGastos, Descripcion, Importe, Cheque, Autorizado, Fecha_Acreditacion, Fecha_Autorizado, Usuario) " +
                    $"VALUES('{Fecha:MM/dd/yy}', {caja.ID}, {TG.Id_Tipo}, {Id_SubTipoGastos}, '{Desc_SubTipo}', {Id_DetalleGastos}, '{Descripcion}', " +
                    $"{Importe.ToString().Replace(",", ".")}, {Cheque}, {(Autorizado ? "1" : "0")}, '{Fecha_Acreditacion:MM/dd/yy HH:mm}', '{Fecha_Autorizado:MM/dd/yy HH:mm}', {Usuario.ID})", sql);
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
                                        
                    if (caja.EsARendir == true)
                    {
                        if (caja.nombre_ARendir.ID == 0) { caja.Seleccionar_Nombre(); }
                        a_Rendir.ID_Salida = ID;
                        a_Rendir.ID_NARendir = caja.nombre_ARendir.ID;
                        a_Rendir.Agregar();
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public new void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM CD_Gastos WHERE ID={ID}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                //HORRIBLE.
                if (caja.ID == 12)
                {
                    a_Rendir.ID_Salida = ID;
                    a_Rendir.ID_NARendir = caja.nombre_ARendir.ID;
                    a_Rendir.Borrar_Salida();
                }

                if (TG.EsHacienda == true)
                {
                    Compra_Hacienda c = new Compra_Hacienda();
                    c.Consignatario.ID = Id_SubTipoGastos;
                    int n = Id_DetalleGastos;
                    n = Convert.ToInt32( c.Dato("ID_CompraFrigo=" + n, "NBoleta", ""));
                    c.NBoleta.ID = n;

                    c.Calcular_Saldo();
                }
                if (TG.EsAgregados == true)
                {
                    Agregados_Hacienda c = new Agregados_Hacienda();
                    c.Consignatario.ID = Id_SubTipoGastos;
                    int n = Id_DetalleGastos;
                    n = Convert.ToInt32(c.Dato("ID_Agregados_Frigo=" + n, "NBoleta", ""));
                    c.nb.ID = n;

                    c.Calcular_Saldo();
                }
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
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(ISNULL(Importe, 0)) FROM CD_Gastos WHERE Autorizado=1 AND Fecha<='{f:MM/dd/yy}'", conexionSql);

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
                Descripcion = s;
            }
            return s;
        }
               

        /// <summary>
        /// Devuelve el último valor que se cargo con los datos actuales.
        /// </summary>
        /// <returns></returns>
        public DataTable Ultimo_Valor()
        {
            var dt = new DataTable("Datos");

            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Fecha, Importe FROM CD_Gastos WHERE Fecha<'{Fecha:MM/dd/yy}' AND ID_TipoGastos={TG.Id_Tipo} AND ID_SubTipoGastos={Id_SubTipoGastos} AND ID_DetalleGastos={Id_DetalleGastos} ORDER BY ID DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                conexionSql.Close();
            }
            catch (Exception)
            {
            }

            return dt;
        }

        public DataTable Datos_DetalleP(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string Cadena = $"SELECT Fecha, ID_SubTipoGastos as ID_consignatario, Desc_SubTipo as Consignatario, Descripcion as NBoleta FROM {Tabla} {filtro} ORDER BY {Campo_ID}";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public bool Fecha_Cerrada()
        {
            if ( Usuario.Permiso == Usuarios.e_Permiso.Administrador) { return false; }
            return Fecha_Cerrada(Fecha);
        }
        #endregion

    }
}
