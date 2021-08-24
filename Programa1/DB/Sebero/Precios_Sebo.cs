﻿
namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Precios_Sebo
    {
        public Precios_Sebo()
        {
        }
        //public Precios_Sebo(int id, DateTime fecha, Productos prod, Proveedores.Proveedores proveedor, Single pr)
        //{
        //    Id = id;
        //    Fecha = fecha;
        //    Producto = prod;
        //    Proveedor = proveedor;
        //    Precio = pr;
        //}

        //public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public Single Precio { get; set; }

        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM dbSebero.dbo.Compra WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND CodProd={Producto.ID} AND Id_Sebero={Proveedor.Id} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Precio = Convert.ToSingle(d);
            return Precio;
        }

        //public DataTable Datos(string filtro = "")
        //{
        //    var dt = new DataTable("Datos");
        //    var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

        //    if (filtro.Length > 0)
        //    {
        //        filtro = " WHERE " + filtro;
        //    }

        //    try
        //    {
        //        SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_PreciosProveedores" + filtro, conexionSql);
        //        comandoSql.CommandType = CommandType.Text;

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
        //        SqlDat.Fill(dt);

        //    }
        //    catch (Exception)
        //    {
        //        dt = null;
        //    }

        //    return dt;
        //}

        //public DataTable Tabla_Men()
        //{
        //    var dt = new DataTable("Datos");
        //    var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

        //    try
        //    {
        //        SqlCommand comandoSql = new SqlCommand("SELECT Id, Nombre, 0.0 Precio FROM Productos WHERE Id_Tipo=2 AND Ver=1 ORDER BY Id", conexionSql);
        //        comandoSql.CommandType = CommandType.Text;

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
        //        SqlDat.Fill(dt);

        //    }
        //    catch (Exception)
        //    {
        //        dt = null;
        //    }

        //    return dt;
        //}

        //public DataTable Fechas()
        //{
        //    var dt = new DataTable("Datos");
        //    var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
        //    try
        //    {

        //        SqlCommand comandoSql = new SqlCommand($"SELECT TOP 100 Fecha FROM vw_PreciosProveedores WHERE ID_Proveedores={Proveedor.Id} GROUP BY Fecha ORDER BY Fecha DESC", conexionSql);
        //        comandoSql.CommandType = CommandType.Text;

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
        //        SqlDat.Fill(dt);

        //    }
        //    catch (Exception)
        //    {
        //        dt = null;
        //    }

        //    return dt;
        //}

        //public void Actualizar()
        //{
        //    var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

        //    try
        //    {
        //        SqlCommand command =
        //            new SqlCommand($"UPDATE Precios_Sebo " +
        //            $"SET Fecha='{Fecha.ToString("MM/dd/yyy")}', Id_Proveedores={Proveedor.Id}, Id_Productos={Producto.ID}, Precio={Precio.ToString().Replace(",", ".")} " +
        //            $"WHERE Id={Id}", sql);
        //        command.CommandType = CommandType.Text;
        //        command.Connection = sql;
        //        sql.Open();

        //        var d = command.ExecuteNonQuery();

        //        sql.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Error");
        //    }
        //}

        //public void Agregar()
        //{
        //    var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

        //    try
        //    {
        //        SqlCommand command =
        //            new SqlCommand($"INSERT INTO Precio_Proveedores (Fecha, Id_Proveedores, Id_Productos, Precio) " +
        //            $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Proveedor.Id}, {Producto.ID}, {Precio.ToString().Replace(",", ".")} )", sql);
        //        command.CommandType = CommandType.Text;
        //        command.Connection = sql;
        //        sql.Open();

        //        var d = command.ExecuteNonQuery();

        //        sql.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Error");
        //    }
        //}

        //public void Borrar()
        //{
        //    var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

        //    try
        //    {
        //        SqlCommand command = new SqlCommand("DELETE FROM Precios_Sebo WHERE Id=" + Id, sql);
        //        command.CommandType = CommandType.Text;
        //        command.Connection = sql;
        //        sql.Open();

        //        var d = command.ExecuteNonQuery();

        //        Id = 0;

        //        sql.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Error");
        //    }
        //}
    }
}
