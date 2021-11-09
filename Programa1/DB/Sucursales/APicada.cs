namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class APicada : c_Base
    {
        public APicada()
        {
            Tabla = "APicada";
            Vista = "vw_APicada";
            ID_Automatico = true;
        }


        public DateTime Fecha { get; set; }

        public Sucursales.Sucursales Sucursal = new Sucursales.Sucursales();
        public Productos Producto_A { get; set; } = new Productos();
        public Productos Producto_S { get; set; } = new Productos();

        public Single Kilos_A { get; set; }
        public Single Kilos_S { get; set; }

        public Single Costo_A { get; set; }
        public Single Costo_S { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();


        public new void Actualizar()
        {
            if (Fecha_Cerrada(Fecha) == false)
            {
                Actualizar("Fecha", Fecha);
                Actualizar("Id_Sucursales", Sucursal.ID);
                Actualizar("Id_Productos_A", Producto_A.ID);
                Actualizar("Id_Productos_S", Producto_S.ID);
                Actualizar("Costo_A", Costo_A);
                Actualizar("Costo_S", Costo_S);
                Actualizar("Kilos_A", Kilos_A);
                Actualizar("Kilos_S", Kilos_S);
            }
        }

        public new void Agregar()
        {

            var sql = new SqlConnection(cadCN);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO APicada (Fecha, Id_Sucursales, Id_Productos_A, Id_Productos_S, Costo_A, Costo_S, Kilos_A, Kilos_S) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Producto_A.ID}, {Producto_S.ID}, {Costo_A.ToString().Replace(",", ".")}, {Costo_S.ToString().Replace(",", ".")}, " +
                        $"{Kilos_A.ToString().Replace(",", ".")}, {Kilos_S.ToString().Replace(",", ".")})", sql);
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



        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(cadCN);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_APicada WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Producto_A.ID = Convert.ToInt32(dr["Id_Productos_A"]);
                Costo_A = Convert.ToSingle(dr["Costo_A"]);
                Kilos_A = Convert.ToSingle(dr["Kilos_A"]);
                Producto_S.ID = Convert.ToInt32(dr["Id_Productos_S"]);
                Costo_S = Convert.ToSingle(dr["Costo_S"]);
                Kilos_S = Convert.ToSingle(dr["Kilos_S"]);
            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Sucursal.ID = 0;
                Producto_A.ID = 0;
                Costo_A = 0;
                Kilos_A = 0;
                Producto_S.ID = 0;
                Costo_S = 0;
                Kilos_S = 0;
            }


        }
    }
}
