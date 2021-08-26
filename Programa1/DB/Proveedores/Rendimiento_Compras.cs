namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Rendimiento_Compras
    {
        public Rendimiento_Compras()
        {
        }

        public DataTable Datos(string fecha, bool ocultar_ceros = true, string prov = "", string prod = "", string camiones = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (prov.Length > 0) { prov = $" {prov} AND "; }
            if (prod.Length > 0) { prod = $" WHERE {prod}"; }
            if (camiones.Length > 0) { camiones = $" AND ID_Camion IN {camiones}"; }

            string c = $"SELECT  Productos.Id, Productos.Nombre" +
                $", ISNULL((SELECT SUM(c.Kilos) FROM Compras c WHERE {prov} c.Id_Productos = Productos.Id AND {fecha} {camiones}), 0) KCompras" +
                $", ISNULL((SELECT SUM(v.Kilos) FROM Ventas v WHERE {prov} v.Id_Productos = Productos.Id AND {fecha} {camiones}), 0) KVentas" +
                $", ISNULL((SELECT SUM(c.Costo * c.Kilos) FROM Compras c WHERE {prov} c.Id_Productos = Productos.Id AND {fecha} {camiones}), 0) TCompras" +
                $", ISNULL((SELECT SUM(v.Costo_Compra * v.Kilos) FROM Ventas v WHERE {prov} v.Id_Productos = Productos.Id AND {fecha} {camiones}), 0) TVentas" +
                $"    FROM Productos {prod}" +
                $"    ORDER BY Productos.Id";

            try
            {
                SqlCommand comandoSql = new SqlCommand(c, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                dt.Columns.Add("DifKilos", typeof(Single), "KVentas-KCompras");
                dt.Columns.Add("Rend", typeof(Single), "(KVentas/KCompras*100)-100");
                dt.Columns.Add("Diferencia", typeof(Single), "TVentas-TCompras");

                if (ocultar_ceros == true)
                {
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToSingle(dt.Rows[i]["DifKilos"]) == 0)
                        {
                            dt.Rows.RemoveAt(i);
                        }
                    }
                }

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

    }
}
