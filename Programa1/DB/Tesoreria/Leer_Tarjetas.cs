namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using Programa1.DB.Sucursales;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Leer_Tarjetas : c_Base
    {
        public Leer_Tarjetas()
        {
            Tabla = "dbGastos.dbo.Entradas_Tarjeta";
            Vista = "dbGastos.dbo.Entradas_Tarjeta";
            ID_Automatico = true;
        }

        public DateTime vFecha;
        public int vlote;
        public long vcomprobante;
        public long vtarjeta;
        public int vtipo;
        public Single vimporte;
        public DateTime vpago;

        public Sucursales Sucursal { get; set; } = new Sucursales();
        public Suc_Cuentas suc_cuentas { get; set; } = new Suc_Cuentas();
        public Tipos_Tarjeta tipos_tarjeta { get; set; } = new Tipos_Tarjeta();

        public void Actualizar_Registros()
        {
            String vBorrar = $"[Fecha]='{vFecha.ToString("MM/dd/yyy")}' AND [Importe]={vimporte.ToString().Replace(",", ".")} AND Lote={vlote} AND Comprobante={vcomprobante} AND Tarjeta={vtarjeta}";
            Borrar(vBorrar);

            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO dbGastos.dbo.Entradas_Tarjeta ([Fecha], [Id_Tipo], [Importe], [Acreditado], [Suc], [Fecha_Pago], Lote, Comprobante, Tarjeta) " +
                        $"VALUES('{vFecha.ToString("MM/dd/yyy")}', {vtipo}, {vimporte.ToString().Replace(",", ".")}, 1, {Sucursal.ID}, '{vpago.ToString("MM/dd/yyy")}', {vlote}, {vcomprobante}, {vtarjeta})", sql);
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

        public void Actualizar_carpeta(string carpeta)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                //Borrar direccion de carpeta
                SqlCommand command =
                    new SqlCommand("DELETE FROM Varios.dbo.Varios WHERE Dato LIKE 'fCarpeta'", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                if (sql.State == ConnectionState.Closed) { sql.Open(); }

                var d = command.ExecuteNonQuery();

                //Agregar nueva direccion de carpeta

                command =
                    new SqlCommand($"INSERT INTO Varios.dbo.Varios (Dato, Valor) VALUES ('fCarpeta', '{carpeta}')", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;

                d = command.ExecuteNonQuery();

                sql.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public string Carpeta_guardada()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            string d;
            try
            {
                SqlCommand command = new SqlCommand($"SELECT TOP 1 Valor FROM Varios.dbo.Varios WHERE Dato='fCarpeta'", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();
                d = Convert.ToString(command.ExecuteScalar());
                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                d = "";
            }
            return d;
        }

        public DataTable titulares()
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(cadCN);

            try
            {
                string Cadena = $"SELECT Id, Titular FROM dbGastos.dbo.Credenciales_API ORDER BY Id";

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

        public int titular(int suc_titular)
        { return Convert.ToInt32(Dato_Generico($"SELECT Id FROM dbGastos.dbo.Credenciales_API WHERE Titular = (SELECT Titular FROM dbGastos.dbo.Suc_Cuentas WHERE Tipo = 14 AND Suc = {suc_titular})")); }
        public int caja_titular(int Id_Titular)
        { return Convert.ToInt32(Dato_Generico($"SELECT Caja FROM dbGastos.dbo.Credenciales_API WHERE Id = {Id_Titular}")); }
        public DataTable sucdatos()
        { return Sucursal.Datos("Ver = 1 AND Propio = 1"); }
        public string Bearer(int titular_id) 
        { return Dato_Generico($"SELECT Bearer FROM dbGastos.dbo.Credenciales_API WHERE Id = {titular_id}").ToString(); }
        public int terminalMP(int terminal)
        { return Convert.ToInt32(Dato_Generico($"SELECT Terminal FROM dbGastos.dbo.Terminales_MP WHERE Suc = {terminal}")); }
        public void Exportardt(DataTable dt)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(sql);
            sqlbulkcopy.DestinationTableName = "dbGastos.dbo.Entradas_Tarjeta";
            sqlbulkcopy.WriteToServer(dt);
        }
    }
}