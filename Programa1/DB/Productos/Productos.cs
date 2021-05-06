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
        }

        public Productos(int id, string nombre, int tipo, bool ver, bool imp, bool pesable, int multi)
        {
            ID = id;
            Nombre = nombre;
            Tipo.ID = tipo;
            Ver = ver;
            Imprimir = imp;
            Pesable = pesable;
            Multiplicador = multi;
        }

        [Required]
        [Key]
        public int ID { get; set; }

        [MaxLength(80, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoProductos Tipo { get; set; } = new TipoProductos();

        public bool Ver { get; set; }

        public bool Imprimir { get; set; }

        public bool Pesable { get; set; }

        public int Multiplicador { get; set; }


        public bool Mostrar_Ocultos { get; set; } = false;

        public bool Filtrar_Ver { get; set; } = true;

        public bool Ordern_XId { get; set; } = true;

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (Filtrar_Ver)
            {
                if (Mostrar_Ocultos == false)
                {
                    filtro = h.Unir(filtro, " (Ver=1) ");
                }
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
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 * FROM vw_Productos WHERE Id>{ID} ORDER BY Id", conexionSql);
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
                ID = 0;
            }
        }

        private void Asignar(DataRow dr)
        {
            ID = Convert.ToInt32(dr["Id"]);
            Nombre = dr["Nombre"].ToString();
            Tipo.ID = Convert.ToInt32(dr["Id_Tipo"]);
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
                    new SqlCommand($"UPDATE Productos SET Nombre='{Nombre}', Id_Tipo={Tipo.ID}, Ver={vver}, Imprimir={vimp}, Pesable={vpesa}, Multiplicador={Multiplicador} WHERE Id={ID}", sql);
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
                    new SqlCommand($"INSERT INTO Productos (Id, Nombre, Id_Tipo, Ver, Imprimir, Pesable, Multiplicador) VALUES({ID}, '{Nombre}', {Tipo.ID}, {vver}, " +
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
                SqlCommand command = new SqlCommand("DELETE FROM Productos WHERE Id=" + ID, sql);
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


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Productos WHERE Id=" + ID, sql);
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
                    Asignar(dt.Rows[0]);
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
