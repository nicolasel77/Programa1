namespace Programa1.DB.Tesoreria
{
    using Programa1.Carga.Tesoreria;
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class Cajas : c_Base
    {

        public Cajas()
        {
            Tabla = "Cajas";
            Vista = Tabla;
        }

        public Nombres_ARendir nombre_ARendir { get; set; } = new Nombres_ARendir();
        public A_Rendir a_Rendir { get; set; } = new A_Rendir();

        /// <summary>
        /// Por ahora es fijo (solo evalúa que Id=11). Mas que nada se hizo para que quede dentro de la clase.
        /// </summary>
        public bool EsCheque { get { return ID == 11; } }
        /// <summary>
        /// Por ahora es fijo (solo evalúa que Id=12). Mas que nada se hizo para que quede dentro de la clase.
        /// </summary>
        public bool EsARendir { get { return ID == 12; } }


        public DataTable Saldos(DateTime fecha)
        {

            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID, Nombre, dbo.f_SaldoCaja('{fecha:MM/dd/yy}', ID) AS Disponible, dbo.f_SaldoBanco('{fecha:MM/dd/yy}', ID) AS Saldo_Banco   FROM Cajas", conexionSql);
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

        public void Seleccionar_Nombre()
        {
            frmNARendir fr = new frmNARendir();
            fr.ShowDialog();

            nombre_ARendir = fr.nombres_ARendir;
        }

    }
}

