﻿namespace Programa1.DB.Sucursales
{
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    class Resumen_Sucursales
    {
        public Resumen_Sucursales()
        {
        }

        public DataTable Listado_Balances(DateTime Semana, Usuarios.e_Permiso permiso, bool esSuc = true)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string t = "";
                
                if (permiso != Usuarios.e_Permiso.Administrador)
                {
                    t = $"SELECT Id, Nombre, 0 AS Balance FROM Sucursales WHERE Ver=1 AND Propio={(esSuc ? "1" : "0")} ORDER BY Id";
                }
                else
                {
                    t = $"SELECT Id, Nombre, dbo.f_Balance (Id, '{Semana:MM/dd/yy}', '{Semana.AddDays(6):MM/dd/yy}') AS Balance FROM Sucursales WHERE Ver=1 AND Propio={(esSuc ? "1" : "0")} ORDER BY Id";
                }
                SqlCommand comandoSql = new SqlCommand(t, conexionSql);
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

        public DataTable Entradas(int Suc, DateTime f1, DateTime f2, byte Filtro = 0)
        {
            var dt = new DataTable("Entradas");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("sp_ResumenEntradasSuc", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.AddWithValue("Suc", Suc);
                comandoSql.Parameters.AddWithValue("F1", f1);
                comandoSql.Parameters.AddWithValue("F2", f2);
                comandoSql.Parameters.AddWithValue("Filtro", Filtro);

                conexionSql.Open();

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable Salidas(int Suc, DateTime f1, DateTime f2, byte Filtro = 0)
        {
            var dt = new DataTable("Salidas");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("sp_ResumenSalidasSuc", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.AddWithValue("Suc", Suc);
                comandoSql.Parameters.AddWithValue("F1", f1);
                comandoSql.Parameters.AddWithValue("F2", f2);
                comandoSql.Parameters.AddWithValue("Filtro", Filtro);

                conexionSql.Open();

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }


    }
}
