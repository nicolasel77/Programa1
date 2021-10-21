namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
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
        public string descripcion { get; set; }
        public int cantidad { get; set; }
        public double costo { get; set; }

        public Productos productos = new Productos();

        public TipoProductos tipo = new TipoProductos();
        public Lugares_imp lugares_Imp = new Lugares_imp();
        public Nombre_Listas_ofertas lista = new Nombre_Listas_ofertas();

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
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Lista_Ofertas (Orden, id_prod, Descripcion, Cantidad, costo, Id_Lista) " +
                        $"VALUES({Orden}, {productos.ID}, '{descripcion}', {cantidad}, {costo.ToString().Replace(",", ".")}, {lista.ID})", sql);
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
                cantidad = Convert.ToInt32(dr["Cantidad"]);
                costo = Convert.ToSingle(dr["Costo"]);
            }
            catch (Exception)
            {
                ID = 0;
                Orden = 0;
                productos.ID = 0;
                descripcion = "";
                cantidad = 0;
                costo = 0;
            }
        }

        public new void Actualizar()
        {
            Actualizar("Orden", Orden);
            Actualizar("Id_Prod", productos.ID);
            Actualizar("Descripcion", descripcion);
            Actualizar("Cantidad", cantidad);
            Actualizar("Costo", costo);
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

    }
}