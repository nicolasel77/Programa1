namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class NBoletas : c_Base
    {
        public NBoletas()
        {
            Tabla = "NBoletas";
            Vista = "vw_NBoletas";
            Campo_ID = "NBoleta";
        }

        public DateTime Fecha { get; set; }
        public int Reparto { get; set; }
        public float Costo { get; set; }
        public float Costo_Faena { get; set; }
        public bool Directo { get; set; }
        public float Costo_Final { get; internal set; }
        public double Kilos_Compra { get; internal set; }
        public double Kilos_Faena { get; internal set; }


        public void Cargar()
        {
            DataTable dt = Datos_Vista("NBoleta=" + ID);
            if (dt != null)
            {
                try
                {
                    Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    Reparto = Convert.ToInt32(dt.Rows[0]["Reparto"]);
                    Costo = Convert.ToSingle(dt.Rows[0]["Costo"]);
                    Costo_Faena = Convert.ToSingle(dt.Rows[0]["Costo_Faena"]);
                    Costo_Final = Convert.ToSingle(dt.Rows[0]["Costo_Final"]);
                    Kilos_Compra = Convert.ToSingle(dt.Rows[0]["Kilos_Compra"]);
                    Kilos_Faena = Convert.ToSingle(dt.Rows[0]["Kilos_Faena"]);
                    Directo = Convert.ToBoolean(dt.Rows[0]["Directo"]);
                }
                catch (Exception)
                {


                }
            }
        }
        internal void Actualizar_CostoFaena()
        {
            if (Kilos_Faena != 0)
            {
                Costo_Faena = (float)((Kilos_Compra * Costo) / Kilos_Faena);
                Actualizar("Costo_Faena", Costo_Faena);
            }
        }

        internal void Actualizar_CostoFinal(int nb)
        {
            object vRecu = Dato_Sumado("vw_Faena", "NBoleta=" + nb, "Kilos*Recupero");
            double tRecu = Convert.ToDouble(vRecu);
            if (Kilos_Faena != 0)
            {
                Costo_Final = (float)(((Kilos_Compra * Costo) - tRecu) / Kilos_Faena);
                Actualizar("Costo_Final", Costo_Final);
            }
        }

        public new void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"UPDATE NBoletas SET NBoleta={ID}, Fecha='{Fecha.ToString("MM/dd/yyy")}', Directo={(Directo ? "1" : "0")}, " +
                        $"Reparto={Reparto}, Costo={Costo.ToString().Replace(",", ".")}, Costo_Faena={Costo_Faena.ToString().Replace(",", ".")}, Costo_Final={Costo_Final.ToString().Replace(",", ".")} " +
                        $"Kilos_Faena={Kilos_Faena.ToString().Replace(",", ".")}, Kilos_Compra={Kilos_Compra.ToString().Replace(",", ".")} " +
                        $"WHERE NBoleta={ID}", sql);
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

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_Boleta();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO NBoletas (NBoleta, Fecha, Reparto, Costo, Costo_Faena, Costo_Final, Directo, Kilos_Compra, Kilos_Faena) " +
                        $"VALUES({ID}, '{Fecha.ToString("MM/dd/yyy")}', {Reparto}, {Costo.ToString().Replace(",", ".")}, " +
                        $"{Costo_Faena.ToString().Replace(",", ".")}, {Costo_Final.ToString().Replace(",", ".")}, {(Directo ? "1" : "0")}, {Kilos_Compra.ToString().Replace(",", ".")}, {Kilos_Faena.ToString().Replace(",", ".")})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                //int n2 = Max_Boleta();
                //if (n == n2)
                //{
                //    ID = 0;
                //    MessageBox.Show("No se pudo guardar el registro.", "Error");
                //}
                //else
                //{
                //    ID = n2;
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public int Max_Boleta()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(NBoleta) FROM NBoletas", conexionSql);

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

        public enum t_Opcion : byte
        {
            Compras_Faena = 0,
            Faena_Salidas = 1,
            Compras_Salidas = 2
        }

        public DataTable Control(DateTime f1, DateTime f2, t_Opcion opcion)
        {
            SqlParameter p1 = new SqlParameter("f1", f1);
            SqlParameter p2 = new SqlParameter("f2", f2);
            SqlParameter op = new SqlParameter("opcion", (int)opcion);

            DataTable dt = new DataTable("Datos");

            dt = sp_Datos("sp_ControlCarne", new SqlParameter[] { p1, p2, op });
            if (dt != null)
            {
                switch (opcion)
                {
                    case t_Opcion.Compras_Faena:
                        dt.Columns.Add("Dif_Medias", typeof(float), "(Cab*2)-Medias");
                        dt.Columns["Dif_Medias"].SetOrdinal(4);
                        dt.Columns.Add("Diferencia", typeof(float), "Compra+Agregados-Faena");
                        break;

                    case t_Opcion.Faena_Salidas:
                        dt.Columns.Add("Dif_Medias", typeof(float), "Medias-M_Sal");
                        dt.Columns["Dif_Medias"].SetOrdinal(4);
                        dt.Columns.Add("Dif_Kg", typeof(float), "k_Faena-k_Sal");
                        dt.Columns["Dif_Kg"].SetOrdinal(7);
                        dt.Columns.Add("Diferencia", typeof(float), "t_Faena-t_Sal");
                        break;
                    case t_Opcion.Compras_Salidas:
                        dt.Columns.Add("Dif_Medias", typeof(float), "(Cab*2)-M_Sal");
                        dt.Columns["Dif_Medias"].SetOrdinal(4);
                        dt.Columns.Add("Total", typeof(float), "Compra+Agregados");
                        dt.Columns["Total"].SetOrdinal(7);
                        dt.Columns.Add("Diferencia", typeof(float), "Compra+Agregados-t_Sal");
                        break;
                }
            }

            return dt;
        }
    }
}