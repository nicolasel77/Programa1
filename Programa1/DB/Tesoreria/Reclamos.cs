namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal class Reclamos : c_Base
    {

        public Reclamos()
        {
            Tabla = "Reclamos";
            Vista = "Reclamos";
            ID_Automatico = true;
        }

        public DateTime vFecha_ini;
        public DateTime vFecha_fin;
        public string vTitulo;
        public string vDescripcion;
        public string vDesarrollo;
        public string vResolucion;
        public byte vResuelto;
        public int vEntidad;

        //public Entidades entidades { get; set; } = new Entidades();

        //  Datos

        public DataTable Datos()
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(cadCN);

            string filtro = " WHERE Id = " + ID; 

            try
            {
                string Cadena = $"SELECT * FROM {Tabla} {filtro}";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);


                vTitulo = dt.Rows[0][1].ToString();
                vDescripcion = dt.Rows[0][2].ToString(); ;
                vDesarrollo = dt.Rows[0][3].ToString(); ;
                vResolucion = dt.Rows[0][4].ToString(); ;
                vFecha_ini = Convert.ToDateTime(dt.Rows[0][5]);
                vFecha_fin = Convert.ToDateTime(dt.Rows[0][6]);
                if (vResolucion.Length > 0)
                { vResuelto = 1; }
                else { vResuelto = 0; }
                
                vEntidad = 0;

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable Casos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(cadCN);

            string Orden = "Id DESC ";
            string Campos = "Id, Titulo";

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }
            if (Campos == "") { Campos = "*"; }
            if (Orden != "") { Orden = (Orden != "ORDER BY ") ? " ORDER BY " + Orden : " ORDER BY " + Campo_ID; }

            try
            {
                string Cadena = $"SELECT {Campos} FROM {Tabla} {filtro} {Orden}";

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

        public DataTable Entidades()
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(cadCN);

            try
            {
                string Cadena = $"SELECT * FROM Entidades ORDER BY Id";

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

        //  Modificaciones
        public new void Agregar()
        {
            var sql = new SqlConnection(cadCN);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO {Tabla} (Titulo) " +
                        $"VALUES('{vTitulo}')", sql);
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

        public new void Actualizar()
        {
            var cnn = new SqlConnection(cadCN);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE {Tabla} SET Titulo = '{vTitulo}', Descripcion='{vDescripcion}', Desarrollo='{vDesarrollo}', Resolucion='{vResolucion}', " +
                    $"Inicio='{vFecha_ini.ToString("MM/dd/yyy")}', Final='{vFecha_fin.ToString("MM/dd/yyy")}', Resuelto={vResuelto}, Entidad={vEntidad} WHERE Id={ID}", cnn);
                command.CommandType = CommandType.Text;
                command.Connection = cnn;
                cnn.Open();

                var d = command.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

    }

}