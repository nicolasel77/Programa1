namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Media;
    using System.Windows.Forms;

    class Listas_Ofertas : c_Base
    {
        public Listas_Ofertas()
        {
            ID_Automatico = true;
            Tabla = "dbo.Lista_Ofertas";
            Vista = "dbo.vw_Imprimir_Ofertas";
        }

        public DateTime Fecha { get; set; }
        public int Tipos { get; set; }
        public int Orden { get; set; }
        public new string Nombre { get; set; }
        public string descripcion { get; set; }
        public string desc_venta { get; set; }
        public string Detalle { get; set; }
        public bool Pintar { get; set; }
        public double costo { get; set; }

        public Productos productos = new Productos();

        public TipoProductos tipo = new TipoProductos();
        public Lugares_imp lugares_Imp = new Lugares_imp();
        public Supervisores supervisores = new Supervisores();
        public Nombre_Listas_ofertas lista = new Nombre_Listas_ofertas();
        public Titulos titulos = new Titulos();

        public DataTable Datos_Vista(string Filtro)
        {
            DataTable dt = new DataTable();
            dt = Datos_Vista(Filtro, "Id, Orden, Id_Prod, Nombre, Id_Tipo, Tipo, Descripcion, Desc_Venta, Costo, Detalle, Pintar, Id_Lista");
            return dt;
        }

        public DataTable sucdatos()
        {
            return lugares_Imp.Datos_Vista("id < 0 UNION ALL SELECT Id, nombre FROM Sucursales WHERE ver = 1 AND Propio = 1", "Id, Nombre");
        }
        public new bool Existe(int suc_list)
        {
            SqlConnection cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Listas_Suc_Ofertas WHERE Id_Lista={lista.ID} AND Id_suc = {suc_list}", cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                string printar = Pintar ? "1" : "0";
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Lista_Ofertas (Orden, id_prod, Descripcion, Detalle, Pintar, costo, Id_Lista, Nombre, Desc_Venta) " +
                        $"VALUES({Orden}, {productos.ID}, '{descripcion}', '{Detalle}', { printar}, {costo.ToString().Replace(",", ".")}, {lista.ID}, '{Nombre}', '{desc_venta}')", sql);
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

        public void Cargar_Fila()
        {
            Cargar_Fila(ID);
        }
        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Lista_Ofertas WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Orden = Convert.ToInt32(dr["Orden"]);
                productos.ID = Convert.ToInt32(dr["Id_Prod"]);
                descripcion = dr["Descripcion"].ToString();
                desc_venta = dr["Desc_Venta"].ToString();
                Detalle = dr["Detalle"].ToString();
                Pintar = Convert.ToBoolean(dr["Pintar"]);
                costo = Convert.ToSingle(dr["Costo"]);
                Nombre = dr["Nombre"].ToString();
            }
            catch (Exception)
            {
                ID = 0;
                Orden = 0;
                productos.ID = 0;
                descripcion = "";
                desc_venta = "";
                Pintar = false;
                costo = 0;
                Nombre = "";
            }
        }

        public new void Actualizar()
        {
            Actualizar("Orden", Orden);
            Actualizar("Id_Prod", productos.ID);
            Actualizar("Descripcion", descripcion);
            Actualizar("Desc_Venta", desc_venta);
            Actualizar("Detalle", Detalle);
            Actualizar("Pintar", Pintar);
            Actualizar("Costo", costo);
            Actualizar("Nombre", Nombre);
        }

        public void Agregar_sucs_a_Lista(string Nombre_suc, int id_suc)
        {
            if (ID > 0)
            {
                var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                try
                {
                    string cadena = $"INSERT INTO Listas_Suc_Ofertas (Id_Lista, Suc, Id_Suc) VALUES({lista.ID}, '{Nombre_suc}', {id_suc})";
                    SqlCommand cmd = new SqlCommand(cadena, cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cnn;
                    cnn.Open();

                    var d = cmd.ExecuteNonQuery();

                    cnn.Close();
                    ID = Max_ID();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error");
                }
            }
        }
        public void Borrar_Suc_Listas()
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string cadena = $"DELETE FROM Listas_Suc_Ofertas WHERE Id_Lista={lista.ID}";
                SqlCommand cmd = new SqlCommand(cadena, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                cnn.Close();
                ID = Max_ID();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public int Max_Orden()
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int d = 0;

            try
            {
                string Cadena = $"SELECT MAX(Orden) FROM {Tabla} WHERE Id_Lista = {lista.ID}";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();
                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                d = (int)cmd.ExecuteScalar();

                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }

            return d;
        }

        public int FilasdeImpresion()
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int d = 0;

            try
            {
                string Cadena = $"SELECT (SELECT (COUNT(DISTINCT tipo)*2) -1 FROM {Vista} WHERE Id_Lista = {lista.ID}) + (SELECT COUNT(Id_Prod) FROM {Vista} WHERE Id_Lista = {lista.ID})";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();
                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                d = (int)cmd.ExecuteScalar();

                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }
            return d;
        }
        public DataTable sucs_imp()
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string Cadena = $"SELECT Id_Suc, Suc FROM Listas_Suc_Ofertas WHERE Id_Lista = {lista.ID} Order By Id_Suc";

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

        public DataTable sucs_imp_supervisores(string Filtro)
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string Cadena = $"SELECT Id as Id_Suc, Nombre AS Suc FROM Sucursales WHERE {Filtro} Order By ID_Supervisor, Id";

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

    }
}