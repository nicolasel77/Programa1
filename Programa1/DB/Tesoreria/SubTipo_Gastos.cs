﻿namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    class SubTipo_Gastos
    {

        public SubTipo_Gastos()
        {
        }
        
        private Tipo_Gastos tg = new Tipo_Gastos();
        private int vId;

        [Required]
        [Key]
        public int Id_Tipo
        {
            get { return vId; }
            set
            {
                vId = value;
                tg.Id_Tipo = vId;
                Cargar();
            }
        }

        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public int ID_SubTipo { get; set; }


        public void Cargar()
        {
            DataTable dt = Datos();
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    ID_SubTipo = Convert.ToInt32(dt.Rows[0][tg.grupoS.Campo_Id]);
                    Nombre = Convert.ToString(dt.Rows[0][tg.grupoS.Campo_Nombre]);
                }
                else
                {
                    Nombre = "";
                    ID_SubTipo = 0;
                } 
            }

        }

        public DataTable Datos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            string ci, cn, w, t;

            //Busco los nombre de los campos
            
            tg.Id_Tipo = Id_Tipo;
            ci = tg.grupoS.Campo_Id;
            cn = tg.grupoS.Campo_Nombre;
            t = tg.grupoS.Tabla;
            if (tg.grupoS.Campo_Filtro != "") { w = $" WHERE {tg.grupoS.Campo_Filtro}={Id_Tipo}"; } else { w = ""; }

            string s = $"SELECT {ci}, {cn} FROM {t} {w} ORDER BY {ci}";

            try
            {

                SqlCommand comandoSql = new SqlCommand(s, conexionSql);
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

        public DataTable SubTipos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ID_Tipo, ID_SubTipo, Nombre FROM SubTipos_Gastos" + filtro, conexionSql);
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

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string padre = "";
                if (tg.grupoS.Campo_Filtro != "") { padre = $"{tg.grupoS.Campo_Filtro}={Id_Tipo} AND"; }

                string cu = $"UPDATE {tg.grupoS.Tabla} SET {tg.grupoS.Campo_Nombre}='{Nombre}', " +
                    $"{tg.grupoS.Campo_Id}={ID_SubTipo} WHERE {padre} {tg.grupoS.Campo_Id}={ID_SubTipo}";

                SqlCommand command = new SqlCommand(cu, sql);
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

        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string padre = ""; string tipoPadre = "";
                if (tg.grupoS.Campo_Filtro != "") { padre = $"{tg.grupoS.Campo_Filtro}, "; tipoPadre = $"{Id_Tipo}, "; }

                string ci = $"INSERT INTO {tg.grupoS.Tabla} ({padre}{tg.grupoS.Campo_Id}, {tg.grupoS.Campo_Nombre}) VALUES({tipoPadre}{ID_SubTipo}, '{Nombre}')";

                SqlCommand command = new SqlCommand(ci, sql);                
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM SubTipos_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_SubTipo={ID_SubTipo}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id_Tipo = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT Nombre FROM SubTipos_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_SubTipo={ID_SubTipo}", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();

                if (string.IsNullOrEmpty(Convert.ToString(d)))
                {
                    return false;
                }
                else
                {
                    if (d.ToString().Length == 0)
                    {
                        Nombre = "";
                        return false;
                    }
                    else
                    {
                        Nombre = d.ToString();
                        return true;
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }
    }
}
