namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Tipos_Entradas : c_Base
    {
        private int vId;
        /// <summary>
        /// Grupos_Entradas
        /// </summary>
        public Grupos_Entradas grupoE = new Grupos_Entradas();
        public Tipos_Entradas()
        {
            Tabla = "Tipos_Entradas";
            Vista = Tabla;

            Campo_ID = "ID_Tipo";
        }

      
        [Required]
        [Key]
        public int Id_Tipo
        {
            get { return vId; }
            set
            {
                vId = value;
                Cargar();
            }
        }

        public int Grupo { get; set; }

        public bool Es_Entrega { get; set; }


        public void Cargar()
        {
            DataTable dt = Datos("Id_Tipo=" + Id_Tipo);
            if (dt.Rows.Count != 0)
            {
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Grupo = Convert.ToInt32(dt.Rows[0]["Grupo"]);
                grupoE.Id = Grupo;

                Es_Entrega = Convert.ToBoolean(dt.Rows[0]["Es_Entrega"]); 
            }

        }


        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }

        public DataTable SubTipos(string filtro = "")
        {
            DataTable dt = new DataTable();
            if (Id_Tipo != 0)
            {
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (filtro.Length != 0) { filtro = "WHERE " + filtro; }

                string s = $"SELECT  {grupoE.Campo_Id}, {grupoE.Campo_Nombre} FROM {grupoE.Tabla} {filtro}";
                try
                {
                    SqlCommand comandoSql = new SqlCommand(s, conexionSql);

                    conexionSql.Open();

                    SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                    SqlDat.Fill(dt);

                }
                catch (Exception)
                {
                    dt = null;
                }
            }
            return dt;
        }


        public new void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {

                SqlCommand command = new SqlCommand($"UPDATE Tipos_Entradas SET Nombre='{Nombre}', " +
                    $"Grupo={Grupo}, Es_Entrega={(Es_Entrega ? "1" : "0")} WHERE Id_Tipo={Id_Tipo}", sql);
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

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Tipos_Entradas (Id_Tipo, Nombre, Grupo, Es_Entrega) VALUES({Id_Tipo}, '{Nombre}', {Grupo}, {(Es_Entrega ? "1" : "0")})", sql);
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

    }
}
