namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Suc_Cuentas : c_Base
    {
        public Suc_Cuentas()
        {
            Tabla = "dbGastos.dbo.Suc_Cuentas";
            Vista = "dbGastos.dbo.vw_SucCuentas";
        }

        public int suc;
        public int N_Cuenta;
        public int Tipo;
        public string Titular;
        public Sucursales Sucursal { get; set; } = new Sucursales();

        public DataTable Datos_Vista()
        {
            return Datos_Vista("", "Suc, Nombre, N_Cuenta, Tipo, Descripcion, Titular ", " Suc, Tipo");
        }

        public bool Cuentas_Compartidas(int cta)
        {
            if (Datos_Vista($"N_Cuenta IN (SELECT N_Cuenta FROM dbGastos.dbo.vw_SucCuentas WHERE N_cuenta = {cta})", "Suc", "Suc").Rows.Count > 1)
            { return true; }
            else
            { return false; }
        }

        //public int N_Cuentas_Compartidas(int suc)
        //{
        //    return Convert.ToInt32(Dato_Generico($"SELECT COUNT(Suc) FROM {Vista} WHERE Tipo = 1 AND N_Cuenta = (SELECT TOP 1 N_Cuenta FROM Suc_Cuentas WHERE Suc = {suc})"));
        //}

        //public DataTable nccc(int suc)
        //{ 
        //return Datos_Genericos($"SELECT Suc FROM {Vista} WHERE Tipo = 1 AND N_Cuenta = (SELECT TOP 1 N_Cuenta FROM Suc_Cuentas WHERE Suc = {suc})");
        //}

        public int buscar_suc(int establecimiento)
        {
            int suc = 0;
            try
            {
                suc = Convert.ToInt32(Dato_Generico(Tabla, $" N_Cuenta = {establecimiento} ORDER BY Suc", "Suc"));
            }
            catch
            { 
            }
            return suc;
        }

        public new void Actualizar(string campo_editado, object valor)
        {
            var cnn = new SqlConnection(cadCN);

            try
            {
                string otros_Campos = $"Suc = {suc} AND N_Cuenta = {N_Cuenta} AND Tipo = {Tipo} AND Titular = '{Titular}'";

                if (campo_editado != "Titular")
                { otros_Campos.Remove(otros_Campos.IndexOf(campo_editado), campo_editado.Length + valor.ToString().Length + 8); }
                else { otros_Campos.Remove(otros_Campos.IndexOf(" AND Titular")); valor = $"'{valor}'"; }

                SqlCommand command = new SqlCommand($"UPDATE {Tabla} SET {campo_editado}={valor} WHERE {otros_Campos}", cnn);
                command.CommandType = CommandType.Text;
                command.Connection = cnn;
                cnn.Open();

                var d = command.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
            }
        }
    }
}
