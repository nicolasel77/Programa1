namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Productos
    {
        public Productos()
        {
            Tipo = new TipoProductos();
        }

        public Productos(int id, string nombre, int tipo, bool ver, bool imp, bool pesable, int multi)
        {
            Id = id;
            Nombre = nombre;
            Tipo.Id = tipo;
            Ver = ver;
            Imprimir = imp;
            Pesable = pesable;
            Multiplicador = multi;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoProductos Tipo { get; set; }

        public bool Ver { get; set; }

        public bool Imprimir { get; set; }

        public bool Pesable { get; set; }

        public int Multiplicador { get; set; }


        public bool Mostrar_Ocultos { get; set; } = false;
        public bool Ordern_XId { get; set; } = true;

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (Mostrar_Ocultos == false)
            {
                filtro = h.Unir(filtro, " (Ver=1) ");
            }

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            if (Ordern_XId == false)
            {
                filtro += " ORDER BY Nombre ";
            }
            else
            {
                filtro += " ORDER BY Id";
            }


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Productos" + filtro, conexionSql);
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

        public void Siguiente()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 * FROM vw_Productos WHERE Id>{Id} ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
                DataRow dr;

                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    Asignar(dr);
                }
                else
                {
                    comandoSql.CommandText = ($"SELECT TOP 1 * FROM vw_Productos ORDER BY Id");
                    comandoSql.CommandType = CommandType.Text;

                    SqlDat.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.Rows[0];
                        Asignar(dr);
                    }
                }
            }
            catch (Exception)
            {
                Id = 0;
            }
        }

        private void Asignar(DataRow dr)
        {
            Id = Convert.ToInt32(dr["Id"]);
            Nombre = dr["Nombre"].ToString();
            Tipo.Id = Convert.ToInt32(dr["Id_Tipo"]);
            Ver = Convert.ToBoolean(dr["Ver"]);
            Imprimir = Convert.ToBoolean(dr["Imprimir"]);
            Pesable = Convert.ToBoolean(dr["Pesable"]);
            Multiplicador = Convert.ToInt32(dr["Multiplicador"]);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string vver = Ver ? "1" : "0";
                string vimp = Imprimir ? "1" : "0";
                string vpesa = Pesable ? "1" : "0";

                SqlCommand command =
                    new SqlCommand($"UPDATE Productos SET Nombre='{Nombre}', Id_Tipo={Tipo.Id}, Ver={vver}, Imprimir={vimp}, Pesable={vpesa}, Multiplicador={Multiplicador} WHERE Id={Id}", sql);
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
                string vver = Ver ? "1" : "0";
                string vimp = Imprimir ? "1" : "0";
                string vpesa = Pesable ? "1" : "0";

                SqlCommand command =
                    new SqlCommand($"INSERT INTO Productos (Id, Nombre, Id_Tipo, Ver, Imprimir, Pesable, Multiplicador) VALUES({Id}, '{Nombre}', {Tipo.Id}, {vver}, " +
                    $"{vimp}, {vpesa}, {Multiplicador})", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Productos WHERE Id=" + Id, sql);
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


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Productos WHERE Id=" + Id, sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();

                if (string.IsNullOrEmpty(Convert.ToString(d)))
                {
                    return false;
                }
                else
                {
                    if (d.ToString().Length == 0)
                    {
                        Nombre = "";
                        return false;
                    }
                    else
                    {
                        Nombre = d.ToString();
                        return true;
                    }

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
