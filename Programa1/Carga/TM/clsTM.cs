namespace Programa1.Carga.TM
{
    using DocumentFormat.OpenXml.Drawing.Charts;
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Security.Cryptography;
    using static System.ComponentModel.Design.ObjectSelectorEditor;

    internal class clsTM
    {
        public class _Factura_Hacienda
        {
            public int ID;
            public DateTime Fecha;
            public int Plazo;
            public int ID_Consignatarios;
            public long Factura;
        }
        public class _Detalle_Hacienda
        {
            public int ID;
            public int Id_Factura;
            public int Id_Produtos;
            public int Cabezas;
            public Single Kilos;
            public Single Precio;
        }
        public class _Agregados_Hacienda
        {
            public int ID;
            public int Id_Factura;
            public int Id_TipoAgregados;
            public Single Importe;
        }
        public class _Bancos
        {
            public int ID;
            public string Nombre;

            public override string ToString()
            {
                return string.Format("{0}. {1}", ID, Nombre);
            }
        }
        public class _Cajas
        {
            public int ID;
            public string Nombre;
            public override string ToString()
            {
                return string.Format("{0}. {1}", ID, Nombre);
            }
        }
        public class _Cuentas_Bancarias
        {
            public int ID;
            public string Nombre;

            public override string ToString()
            {
                return string.Format("{0}. {1}", ID, Nombre);
            }
        }
        public class _Cheques
        {
            public int ID;
            public int ID_Banco;
            public long Numero;
            public DateTime Fecha_Entrada;
            public DateTime Fecha_Acreditacion;
            public int ID_Caja;
            public decimal Importe;
            public bool eCheq;

        }
        private string cadenaConexion = Programa1.Properties.Settings.Default.dbTM;

        internal System.Data.DataTable Cajas_TM()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT Id, Nombre FROM Cajas ORDER BY ID";
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return dt;
        }

        internal System.Data.DataTable Grupos_Gastos()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            string sql = "SELECT Id, Nombre, Tabla, Campo_ID, Campo_Nombre, Campo_Filtro FROM Grupos_Salidas ORDER BY ID";
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return dt;
        }
        internal System.Data.DataTable Tipos_TM()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = "SELECT Grupo, Id_Tipo, Nombre FROM Tipos_Salidas ORDER BY ID_Tipo";
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return dt;
        }
        internal System.Data.DataTable SubTipos_TM(int tipo)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            // Devolver los subtipos con sp_ObtenerDatosPorTipo usando el tipo como parámetro
            string sql = "EXEC sp_ObtenerDatosPorTipo @Tipo";
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }


            return dt;
        }
        internal System.Data.DataTable Detalles_TM(int id)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            // Devolver los detalles con ID_Tipo igual al id pasado como parámetro
            string sql = "SELECT Id_Detalle, Nombre FROM Detalles_Gastos WHERE ID_Tipo = @ID_Tipo ORDER BY ID_Detalle";
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Tipo", id);
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return dt;
        }


        internal void Nueva_Caja(int ID)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Cajas (ID, Nombre) VALUES (@ID, '')";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Modificar_Caja(int id, string nombre)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE Cajas SET Nombre = @Nombre WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Borrar_Caja(int id)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "DELETE FROM Cajas WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        internal void Nuevo_Grupo(int a)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Grupos_Salidas (ID, Nombre, Tabla, Campo_ID, Campo_Nombre, Campo_Filtro) " +
                             "VALUES (@ID, '', '', '', '', '')";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", a);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Modificar_Grupo(int id, string nombre, string tabla, string campo_id, string campo_nombre, string campo_filtro)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE Grupos_Salidas SET Nombre = @Nombre, Tabla = @Tabla, Campo_ID = @Campo_ID, " +
                             "Campo_Nombre = @Campo_Nombre, Campo_Filtro = @Campo_Filtro WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Tabla", tabla);
                    cmd.Parameters.AddWithValue("@Campo_ID", campo_id);
                    cmd.Parameters.AddWithValue("@Campo_Nombre", campo_nombre);
                    cmd.Parameters.AddWithValue("@Campo_Filtro", campo_filtro);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Borrar_Grupo(int id)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "DELETE FROM Grupos_Salidas WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        internal bool Existe_Tipo_TM(int gr, int a)
        {
            // Comprobar si existe un tipo con el grupo y id_tipo dados
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT COUNT(*) FROM Tipos_Salidas WHERE Grupo = @Grupo AND Id_Tipo = @Id_Tipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Grupo", gr);
                    cmd.Parameters.AddWithValue("@Id_Tipo", a);
                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        con.Close();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        internal void Nuevo_Tipo_TM(int gr, int a)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Tipos_Salidas (Grupo, Id_Tipo, Nombre) VALUES (@Grupo, @Id_Tipo, '')";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Grupo", gr);
                    cmd.Parameters.AddWithValue("@Id_Tipo", a);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Modificar_Tipo_TM(int gr, int id, string v)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE Tipos_Salidas SET Nombre = @Nombre WHERE Grupo = @Grupo AND Id_Tipo = @Id_Tipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Grupo", gr);
                    cmd.Parameters.AddWithValue("@Id_Tipo", id);
                    cmd.Parameters.AddWithValue("@Nombre", v);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Borrar_Tipo_TM(int gr, int id)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "DELETE FROM Tipos_Salidas WHERE Grupo = @Grupo AND Id_Tipo = @Id_Tipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Grupo", gr);
                    cmd.Parameters.AddWithValue("@Id_Tipo", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }



        /// <summary>
        /// Devuelve el nombre de la tabla asociada al sub-tipo
        /// </summary>
        /// <param name="t">Tipo</param>
        /// <returns></returns>
        internal string Tabla_SubTipo(int t, bool salida = true)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Tabla FROM Grupos_Salidas WHERE ID=(SELECT Grupo FROM Tipos_Salidas WHERE ID_Tipo=@ID)";
                if (salida == false) sql = "SELECT Tabla FROM Grupos_Entradas WHERE ID=(SELECT Grupo FROM Tipos_Entradas WHERE ID_Tipo=@ID)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", t);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close();
                        return result != null ? result.ToString() : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal bool Existe_SubTipo_TM(int idTipo, int a)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT COUNT(*) FROM SubTipos_Gastos WHERE ID_Tipo = @ID_Tipo AND Id_SubTipo = @Id_SubTipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Tipo", idTipo);
                    cmd.Parameters.AddWithValue("@Id_SubTipo", a);
                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        con.Close();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        internal bool Existe_SubTipo_TM(int idGrupo, int idTipo, int a)
        {

            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT CONCAT('SELECT COUNT(*) FROM ', Tabla, ' WHERE ', IIF(Tabla = 'SubTipos_Gastos', CONCAT('Id_Tipo=', @t, ' AND '), ''), Campo_ID, '=', @st) FROM Grupos_Salidas WHERE ID=@gr";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@gr", idGrupo);
                    cmd.Parameters.AddWithValue("@t", idTipo);
                    cmd.Parameters.AddWithValue("@st", a);
                    try
                    {
                        con.Open();
                        sql = cmd.ExecuteScalar().ToString();
                        cmd.CommandText = sql;

                        int count = (int)cmd.ExecuteScalar();
                        con.Close();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        internal void Nuevo_SubTipo(int idGrupo, int idTipo, int a)
        {
            // Ejecutar el sp_AgregarSubTipo con los parámetros adecuados
            // @gr int, @t int, @st int, @n varchar(50) = ''
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "EXEC sp_AgregarSubTipo @gr, @t, @st, @n";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@gr", idGrupo);
                    cmd.Parameters.AddWithValue("@t", idTipo);
                    cmd.Parameters.AddWithValue("@st", a);
                    cmd.Parameters.AddWithValue("@n", string.Empty);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Modificar_SubTipo_TM(int gr, int idTipo, int idSubTipo, string n)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT CONCAT('UPDATE ', Tabla, ' SET ', Campo_Nombre, '=''', @n" +
                    ", ''' WHERE ', Campo_ID, '=', @st, IIF(Tabla = 'SubTipos_Gastos', CONCAT(' AND ID_Tipo=', @t), ''))  FROM Grupos_Salidas WHERE ID=@gr";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@gr", gr);
                    cmd.Parameters.AddWithValue("@t", idTipo);
                    cmd.Parameters.AddWithValue("@st", idSubTipo);
                    cmd.Parameters.AddWithValue("@n", n);
                    try
                    {
                        con.Open();
                        sql = cmd.ExecuteScalar().ToString();

                        cmd.CommandText = sql;
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();

                        con.Close();

                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        internal bool Existe_Detalle(int t, int d)
        {
            // Comprobar si existe un tipo con el grupo y id_tipo dados
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT COUNT(*) FROM Detalles_Gastos WHERE ID_Tipo=@t AND Id_Detalle=@d";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@t", t);
                    cmd.Parameters.AddWithValue("@d", d);
                    try
                    {
                        con.Open();
                        int count = (int)cmd.ExecuteScalar();
                        con.Close();
                        return count > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        internal void Nuevo_Detalle(int t, int d, string n)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Detalles_Gastos (Id_Tipo, ID_Detalle, Nombre) VALUES (@t, @d, @n)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@t", t);
                    cmd.Parameters.AddWithValue("@d", d);
                    cmd.Parameters.AddWithValue("@n", n);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Modificar_Detalle(int t, int d, string n)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE Detalles_Gastos SET Nombre = @n WHERE ID_Tipo = @t AND Id_Detalle = @d";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@t", t);
                    cmd.Parameters.AddWithValue("@d", d);
                    cmd.Parameters.AddWithValue("@n", n);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal System.Data.DataTable Gastos(DateTime fecha)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT * FROM vw_Gastos WHERE Fecha = @Fecha ORDER BY ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return dt;
        }

        internal string Nombre_Caja(int c)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Nombre FROM Cajas WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", c);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close();
                        return result != null ? result.ToString() : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal string Nombre_Tipo(int t)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Nombre FROM Tipos_Salidas WHERE Id_Tipo = @Id_Tipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", t);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close();
                        return result != null ? result.ToString() : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal string Nombre_SubTipo(int t, int st)
        {
            // Obtener el grupo del tipo
            // Luego obtener el nombre del sub-tipo en la tabla correspondiente
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Tabla, Campo_Nombre, Campo_ID FROM Grupos_Salidas WHERE ID=(SELECT Grupo FROM Tipos_Salidas WHERE Id_Tipo=@Id_Tipo)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", t);
                    try
                    {
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tabla = reader.GetString(0);
                                string campo_nombre = reader.GetString(1);
                                string campo_id = reader.GetString(2);

                                reader.Close();
                                // Ahora obtener el nombre del sub-tipo
                                sql = $"SELECT {campo_nombre} FROM {tabla} WHERE {campo_id}=@Id_SubTipo";
                                if (tabla == "SubTipos_Gastos") // Si es SubTipos_Gastos, añadir condición de ID_Tipo
                                {
                                    sql += " AND ID_Tipo=" + t;
                                }
                                using (var cmd2 = new System.Data.SqlClient.SqlCommand(sql, con))
                                {
                                    cmd2.Parameters.AddWithValue("@Id_SubTipo", st);
                                    object result = cmd2.ExecuteScalar();
                                    con.Close();
                                    return result != null ? result.ToString() : string.Empty;
                                }
                            }
                            else
                            {
                                con.Close();
                                return string.Empty;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal string Nombre_Detalle(int t, int a)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Nombre FROM Detalles_Gastos WHERE ID_Tipo = @ID_Tipo AND Id_Detalle = @Id_Detalle";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID_Tipo", t);
                    cmd.Parameters.AddWithValue("@Id_Detalle", a);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close();
                        return result != null ? result.ToString() : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal void Modifcar_Gasto(int id, DateTime fecha, int idc, int t, int st, string dst, int d, string v1, decimal v2, int fc)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE CD_Gastos SET Fecha=@Fecha, ID_Caja=@IDC, ID_TipoGastos=@ID_TipoGastos, " +
                             "ID_SubTipoGastos=@ID_SubTipoGastos, Desc_SubTipo=@DSTipo, ID_DetalleGastos=@ID_DetalleGastos, " +
                             "Descripcion=@Detalle, Importe=@Importe, ID_Factura=@fc" +
                             "WHERE ID=@ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@IDC", idc);
                    cmd.Parameters.AddWithValue("@ID_TipoGastos", t);
                    cmd.Parameters.AddWithValue("@ID_SubTipoGastos", st);
                    cmd.Parameters.AddWithValue("@DSTipo", dst);
                    cmd.Parameters.AddWithValue("@ID_DetalleGastos", d);
                    cmd.Parameters.AddWithValue("@Detalle", v1);
                    cmd.Parameters.AddWithValue("@Importe", v2);
                    cmd.Parameters.AddWithValue("@fc", fc);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Nuevo_Gasto(DateTime fecha, int idc, int t, int st, string dst, int d, string sd, decimal importe, int fc, int ch = 0)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO CD_Gastos (Fecha, ID_Caja, ID_TipoGastos, ID_SubTipoGastos, Desc_SubTipo, ID_DetalleGastos, Descripcion, Importe, ID_Factura, Cheque) " +
                             "VALUES (@Fecha, @IDC, @ID_TipoGastos, @ID_SubTipoGastos, @DSTipo, @ID_DetalleGastos, @Detalle, @Importe, @fc, @ch)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@IDC", idc);
                    cmd.Parameters.AddWithValue("@ID_TipoGastos", t);
                    cmd.Parameters.AddWithValue("@ID_SubTipoGastos", st);
                    cmd.Parameters.AddWithValue("@DSTipo", dst);
                    cmd.Parameters.AddWithValue("@ID_DetalleGastos", d);
                    cmd.Parameters.AddWithValue("@Detalle", sd);
                    cmd.Parameters.AddWithValue("@Importe", importe);
                    cmd.Parameters.AddWithValue("@fc", fc);
                    cmd.Parameters.AddWithValue("@ch", ch);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        internal System.Data.DataTable Entradas(DateTime fecha)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT * FROM vw_Entradas WHERE Fecha = @Fecha ORDER BY ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    try
                    {
                        con.Open();
                        using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return dt;
        }

        internal string Nombre_TipoEntrada(int t)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Nombre FROM Tipos_Entradas WHERE Id_Tipo = @Id_Tipo";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", t);
                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        con.Close();
                        return result != null ? result.ToString() : string.Empty;
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal string Nombre_SubTipoEntrada(int t, int st)
        {
            // Obtener el grupo del tipo
            // Luego obtener el nombre del sub-tipo en la tabla correspondiente
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Tabla, Campo_Nombre, Campo_ID FROM Grupos_Entradas WHERE ID=(SELECT Grupo FROM Tipos_Entradas WHERE Id_Tipo=@Id_Tipo)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", t);
                    try
                    {
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tabla = reader.GetString(0);
                                string campo_nombre = reader.GetString(1);
                                string campo_id = reader.GetString(2);

                                reader.Close();
                                // Ahora obtener el nombre del sub-tipo
                                sql = $"SELECT {campo_nombre} FROM {tabla} WHERE {campo_id}=@Id_SubTipo";

                                using (var cmd2 = new System.Data.SqlClient.SqlCommand(sql, con))
                                {
                                    cmd2.Parameters.AddWithValue("@Id_SubTipo", st);
                                    object result = cmd2.ExecuteScalar();
                                    con.Close();
                                    return result != null ? result.ToString() : string.Empty;
                                }
                            }
                            else
                            {
                                con.Close();
                                return string.Empty;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        return string.Empty;
                    }
                }
            }
        }

        internal void Modifcar_Entrada(int id, DateTime fecha, int idc, int t, int st, string dsc, decimal importe)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "UPDATE CD_Entradas SET Fecha=@Fecha, ID_Caja=@IDC, ID_TipoEntrada=@ID_Tipo, ID_SubTipoEntrada=@ID_SubTipo" +
                    ", Descripcion=@Descripcion, Importe=@Importe WHERE ID=@ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@IDC", idc);
                    cmd.Parameters.AddWithValue("@ID_Tipo", t);
                    cmd.Parameters.AddWithValue("@ID_SubTipo", st);
                    cmd.Parameters.AddWithValue("@Descripcion", dsc);
                    cmd.Parameters.AddWithValue("@Importe", importe);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void Nueva_Entrada(DateTime fecha, int idc, int t, int st, string dsc, decimal importe, int ch = 0)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO CD_Entradas (Fecha, ID_Caja, ID_TipoEntrada, ID_SubTipoEntrada, Descripcion, Importe, Cheque) " +
                             "VALUES (@Fecha, @IDC, @ID_Tipo, @ID_SubTipo, @Descripcion, @Importe, @ch)";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@IDC", idc);
                    cmd.Parameters.AddWithValue("@ID_Tipo", t);
                    cmd.Parameters.AddWithValue("@ID_SubTipo", st);
                    cmd.Parameters.AddWithValue("@Descripcion", dsc);
                    cmd.Parameters.AddWithValue("@Importe", importe);
                    cmd.Parameters.AddWithValue("@ch", ch);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }


        /// <summary>
        /// Ultimo ID
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        internal int Ultimo_ID(string tabla = "CD_Gastos")
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ISNULL(MAX(ID), 0) FROM " + tabla;
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        int result = (int)cmd.ExecuteScalar();
                        con.Close();
                        return result;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
        }

        internal void Borrar_Gasto(int id)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(cadenaConexion))
            {
                string sql = "DELETE FROM CD_Gastos WHERE ID = @ID";
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal System.Data.DataTable Resumen_Cajas(DateTime fecha)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ID, Nombre, (dbo.f_SaldoCaja(@f, ID)) AS Saldo FROM Cajas ORDER BY Id";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@f", fecha);
                conn.Open();
                sqlDataAdapter.Fill(dt);
                conn.Close();

            }
            return dt;
        }

        internal System.Data.DataTable Resumen_ComprasHacienda(int consignatario = 0, bool conSaldo = false)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = $"SELECT Id, Factura, Fecha, Plazo, Vencimiento, Id_Consignatarios, Nombre, Total_Cab, Total_Kilos, SubTotal, Agregados" +
                    $", IVA, (SubTotal+Agregados+IVA) Total, Pagos,(Pagos-IVA-SubTotal-Agregados) Saldo FROM vw_ComprasHacienda ";

                string filtro = "";
                if (consignatario != 0)
                {
                    filtro = " WHERE ID_Consignatarios = @c";
                }
                if (conSaldo)
                {
                    if (filtro.Length > 0)
                    {
                        filtro += " AND (Pagos-SubTotal-Agregados-IVA)<>0";
                    }
                    else
                    {
                        filtro = " WHERE (Pagos-SubTotal-Agregados-IVA)<>0";
                    }
                }

                sql = $"{sql} {filtro} ORDER BY Fecha DESC, ID DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@c", consignatario);
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        internal System.Data.DataTable Resumen_ComprasHacienda(string consignatarios, bool conSaldo = false)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = $"SELECT Id, Factura, Fecha, Plazo, Vencimiento, Id_Consignatarios, Nombre, Total_Cab, Total_Kilos, SubTotal, Agregados" +
                    $", IVA, (SubTotal+Agregados+IVA) Total, Pagos,(Pagos-IVA-SubTotal-Agregados) Saldo FROM vw_ComprasHacienda ";

                string filtro = "";
                if (consignatarios.Length > 0)
                {
                    filtro = $" WHERE ID_Consignatarios IN {consignatarios}";
                }
                if (conSaldo)
                {
                    if (filtro.Length > 0)
                    {
                        filtro += " AND (Pagos-SubTotal-Agregados-IVA)<>0";
                    }
                    else
                    {
                        filtro = " WHERE (Pagos-SubTotal-Agregados-IVA)<>0";
                    }
                }

                sql = $"{sql} {filtro} ORDER BY Fecha DESC, ID DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        internal System.Data.DataTable Detalles_Factura(int id)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT * FROM vw_HaciendaDetalle WHERE Id_Factura=@f ORDER BY Id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", id);
                conn.Open();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    return null;
                }
                conn.Close();
                return dt;
            }
        }

        internal System.Data.DataTable Agregados_Factura(int id)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT * FROM vw_HaciendaAgregados WHERE Id_Factura=@f ORDER BY Gravado DESC, Id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@f", id);
                conn.Open();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    return null;
                }
                conn.Close();
                return dt;
            }
        }

        internal System.Data.DataTable Pagos_Factura(int id)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Fecha, Descripcion, Importe FROM CD_Gastos WHERE ID_Factura=@Id";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@Id", id);
                conn.Open();

                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }

        }

        internal void Guardar_FacturaHacienda(_Factura_Hacienda fc)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Hacienda_Compras (Factura, Id_Consignatarios, Fecha, Plazo) VALUES" +
                    "(@fc, @c, @f, @p)";
                if (fc.ID != 0)
                {
                    sql = "UPDATE Hacienda_Compras SET Factura=@f, Id_Consignatarios=@c, Fecha=@f, Plazo=@p WHERE ID=@id";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@fc", fc.Factura);
                cmd.Parameters.AddWithValue("@c", fc.ID_Consignatarios);
                cmd.Parameters.AddWithValue("@f", fc.Fecha);
                cmd.Parameters.AddWithValue("@p", fc.Plazo);
                cmd.Parameters.AddWithValue("@id", fc.ID);

                try
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al guardar la factura.");
                }

            }
        }

        internal string Nombre_Producto(int p)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT TOP 1 ISNULL(Nombre, '') From Productos WHERE ID=" + p;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();

                try
                {
                    sql = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    sql = "";
                }

                conn.Close();

                return sql;
            }
        }

        internal void Guardar_DetalleFactura(_Detalle_Hacienda dth)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Hacienda_Detalle (Id_Factura, Id_Productos, Kilos, Precio, Cabezas) VALUES" +
                    "(@fc, @p, @k, @r, @c)";
                if (dth.ID != 0)
                {
                    sql = "UPDATE Hacienda_Detalle SET Id_Factura=@fc, Id_Productos=@p, Kilos=@k, Precio=@r, Cabezas=@c WHERE ID=@id";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@fc", dth.Id_Factura);
                cmd.Parameters.AddWithValue("@p", dth.Id_Produtos);
                cmd.Parameters.AddWithValue("@k", dth.Kilos);
                cmd.Parameters.AddWithValue("@r", dth.Precio);
                cmd.Parameters.AddWithValue("@c", dth.Cabezas);
                cmd.Parameters.AddWithValue("@id", dth.ID);

                try
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al guardar el detalle.");
                }

            }
        }

        internal System.Data.DataTable Consignatarios(string filtro = "")
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ID, Nombre FROM Consignatarios";
                if (!string.IsNullOrEmpty(filtro))
                {
                    sql += $" WHERE Nombre Like '%{filtro}%'";
                }
                sql += " ORDER BY ID";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        internal void Borrar_DetalleHacienda(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Hacienda_Detalle WHERE ID=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal string Nombre_TipoAgregado(int t)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT TOP 1 ISNULL(Nombre, '') From TipoAgregados WHERE ID=" + t;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();

                try
                {
                    sql = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    sql = "";
                }

                conn.Close();

                return sql;
            }
        }

        internal bool Grava_TipoAgregado(int t)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT TOP 1 Gravado From TipoAgregados WHERE ID=" + t;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();

                bool r = false;
                try
                {
                    r = (bool)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al consultar la tabla TipoAgregados");
                }

                conn.Close();

                return r;
            }
        }

        internal void Guardar_AgregadoFactura(_Agregados_Hacienda agh)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "INSERT INTO Hacienda_Agregados (Id_Factura, Id_TipoAgregados, Importe) VALUES" +
                    "(@fc, @t, @i)";
                if (agh.ID != 0)
                {
                    sql = "UPDATE Hacienda_Agregados SET Id_Factura=@fc, Id_TipoAgregados=@t, Importe=@i WHERE ID=@id";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@fc", agh.Id_Factura);
                cmd.Parameters.AddWithValue("@t", agh.Id_TipoAgregados);
                cmd.Parameters.AddWithValue("@i", agh.Importe);
                cmd.Parameters.AddWithValue("@id", agh.ID);

                try
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al guardar el agregado.");
                }

            }
        }

        internal void Borrar_Factura(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Hacienda_Detalle WHERE id_Factura=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM Hacienda_Agregados WHERE id_Factura=@id";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM Hacienda_Compras WHERE ID=@id";
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        internal void Borrar_AgregadoHacienda(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Hacienda_Agregados WHERE ID=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal void Borrar_Entrada(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM CD_Entradas WHERE ID=@id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        internal System.Data.DataTable Cheques(int banco = 0, int caja = 0, string fecha = "", long numero = 0)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                // Construir la consulta SQL con los filtros proporcionados
                string filtro = "";
                if (banco != 0)
                {
                    filtro += " AND ID_Banco = " + banco;
                }
                if (caja != 0)
                {
                    filtro += " AND ID_Caja = " + caja;
                }
                if (!string.IsNullOrEmpty(fecha))
                {
                    filtro += $" AND {fecha}";
                }
                if (numero != 0)
                {
                    filtro += " AND Numero = " + numero;
                }
                string sql = "SELECT * FROM vw_Cheques";
                if (filtro.Length > 0)
                {
                    filtro = " WHERE " + filtro.Substring(5); // Eliminar el primer " AND "
                    sql = $"{sql} {filtro} ORDER BY Fecha_Entrada DESC, ID DESC";
                }
                else
                {
                    sql = "SELECT TOP 100 * FROM vw_Cheques ORDER BY Fecha_Entrada DESC, ID DESC";
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                conn.Open();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
                return dt;
            }
        }

        internal List<_Bancos> Bancos()
        {
            List<_Bancos> lista = new List<_Bancos>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ID, Nombre FROM Bancos ORDER BY ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _Bancos b = new _Bancos {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                            lista.Add(b);
                        }
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al consultar la tabla Bancos");
                }
                conn.Close();
                return lista;
            }
        }
        internal List<_Cajas> Cajas()
        {
            // Retorna la lista de cajas
            List<_Cajas> lista = new List<_Cajas>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ID, Nombre FROM Cajas ORDER BY ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _Cajas c = new _Cajas {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                            lista.Add(c);
                        }
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al consultar la tabla Cajas");
                }
                conn.Close();
                return lista;
            }
        }

        internal List<_Cuentas_Bancarias> Cuentas_Bancarias()
        {
            // Retorna la lista de cuentas bancarias
            List<_Cuentas_Bancarias> lista = new List<_Cuentas_Bancarias>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT ID, Nombre FROM Cuentas_Bancos ORDER BY ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _Cuentas_Bancarias cb = new _Cuentas_Bancarias {
                                ID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            };
                            lista.Add(cb);
                        }
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Error al consultar la tabla Cuentas_Bancarias");
                }
                conn.Close();
                return lista;
            }
        }

        internal string Nombre_Banco(int b)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT TOP 1 ISNULL(Nombre, '') From Bancos WHERE ID=" + b;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                try
                {
                    sql = cmd.ExecuteScalar().ToString();
                }
                catch (Exception)
                {
                    sql = "";
                }
                conn.Close();
                return sql;
            }
        }

        internal void Actualizar_Cheque(_Cheques cheque)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                if (cheque.ID != 0)
                {
                    string sql = "UPDATE Cheques SET ID_Banco=@banco, Numero=@numero, Fecha_Entrada=@fechae, Fecha_Acreditacion=@fechaa, " +
                        "ID_Caja=@caja, Importe=@importe, eCheq=@echeq WHERE ID=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@banco", cheque.ID_Banco);
                    cmd.Parameters.AddWithValue("@numero", cheque.Numero);
                    cmd.Parameters.AddWithValue("@fechae", cheque.Fecha_Entrada);
                    cmd.Parameters.AddWithValue("@fechaa", cheque.Fecha_Acreditacion);
                    cmd.Parameters.AddWithValue("@caja", cheque.ID_Caja);
                    cmd.Parameters.AddWithValue("@importe", cheque.Importe);
                    cmd.Parameters.AddWithValue("@echeq", cheque.eCheq);
                    cmd.Parameters.AddWithValue("@id", cheque.ID);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Error al actualizar el cheque.");
                    }
                }
                else
                {
                    // Primero agregar el chque
                    string sql = "INSERT INTO Cheques (Numero, ID_Banco, ID_Caja, eCheq, Fecha_Entrada, Fecha_Acreditacion, Importe) " +
                        "VALUES (@n, @b, @c, @e, @fe, @fa, @i)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@n", cheque.Numero);
                    cmd.Parameters.AddWithValue("@b", cheque.ID_Banco);
                    cmd.Parameters.AddWithValue("@c", cheque.ID_Caja);
                    cmd.Parameters.AddWithValue("@e", cheque.eCheq);
                    cmd.Parameters.AddWithValue("@fe", cheque.Fecha_Entrada);
                    cmd.Parameters.AddWithValue("@fa", cheque.Fecha_Acreditacion);
                    cmd.Parameters.AddWithValue("@i", cheque.Importe);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Error al agregar el cheque.");
                    }
                    // Segundo, agregar el ingreso en caja y la salida de la caja
                    cheque.ID = Ultimo_ID("Cheques");
                    Nueva_Entrada(cheque.Fecha_Entrada, 11, 100, cheque.ID_Caja, "Ingreso por cheque No. " + cheque.Numero.ToString(), cheque.Importe, cheque.ID);
                    Nuevo_Gasto(cheque.Fecha_Entrada, cheque.ID_Caja, 100, 11, "Salida a Cheques", 1, "Salida por cheque No. " + cheque.Numero.ToString(), cheque.Importe, 0, cheque.ID);

                }
            }
        }

        internal void Borrar_Cheque(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "DELETE FROM Cheques WHERE ID = @ID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        sql = "DELETE FROM CD_Entradas WHERE ID_TipoEntrada = 100 AND Cheque = @ID";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "DELETE FROM CD_Gastos WHERE ID_TipoGastos = 100 AND Cheque = @ID";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Busca la fecha de salida del cheque en los gastos
        /// </summary>
        /// <param name="id">Buscar el id</param>
        /// <returns></returns>
        internal DateTime Salida_Cheque(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = "SELECT Fecha FROM CD_Gastos WHERE Cheque=@id AND ID_TipoGastos<>100";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                DateTime fecha = new DateTime(1900, 1, 1);
                try
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        fecha = Convert.ToDateTime(result);
                    }
                }
                catch (Exception)
                {
                    fecha = new DateTime(1900, 1, 1);
                }
                conn.Close();
                return fecha;
            }
        }

        public bool fecha_Cerrada(DateTime fecha)
        {
            // Verifica si la fecha está cerrada en la tabla Semanas

            const string sql = "SELECT TOP 1 Cerrada FROM dbDatos.dbo.Semanas WHERE Semana <= @fecha ORDER BY Semana DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

                    conn.Open();
                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                        return false; // no hay semana cerrada registrada <= fecha

                    return Convert.ToBoolean(resultado);
                }
            }
            catch (SqlException ex)
            {
                // logueá el error real en vez de tragártelo silenciosamente
                // Log.Error(ex, "Error consultando fecha_Cerrada");
                throw; // o devolvé false si preferís que sea "silencioso" a propósito
            }
        }
    }
}

