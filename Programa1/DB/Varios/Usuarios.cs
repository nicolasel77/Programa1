﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB.Varios
{
    public class Usuarios
    {
        public enum e_Permiso : byte
        {
            Operador = 1,
            Supervisor = 2,
            Administrador = 3
        }
        public enum e_TipoUsuario : byte
        {
            Operadores = 0,
            Tesoreria = 1,
            Administrador = 2,
            Supervisor = 3,
            RRHH = 4,
            Sistemas = 5
        }

        string vNombre = "";
                
        public Usuarios()
        {
        }

        public int ID { get; set; }
        public string Nombre
        {
            get { return vNombre; }
            set
            {
                var dt = new DataTable("Datos");
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
                                
                try
                {
                    string Cadena = $"SELECT * FROM dbGastos.dbo.Usuarios WHERE Usuario LIKE '{value}%'";

                    SqlCommand comandoSql = new SqlCommand(Cadena, conexionSql);
                    comandoSql.CommandType = CommandType.Text;

                    SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                    SqlDat.Fill(dt);
                }
                catch (Exception)
                {
                    vNombre = "";
                    ID = 0;
                }

                ID = Convert.ToInt32( dt.Rows[0]["ID"]);
                vNombre = Convert.ToString(dt.Rows[0]["Usuario"]);
                //Contraseña por ahora no, se usa la de sistema para iniciar sesion.
                switch( Convert.ToByte(dt.Rows[0]["Permiso"]))
                {
                    case 1:
                        Permiso = e_Permiso.Operador;
                        break;
                    case 2:
                        Permiso = e_Permiso.Supervisor;
                        break;
                    case 3:
                        Permiso = e_Permiso.Administrador;
                        break;
                }

                switch (Convert.ToByte(dt.Rows[0]["TipoUsuario"]))
                {
                    case 0:
                        Tipo = e_TipoUsuario.Operadores;
                        break;
                    case 1:
                        Tipo = e_TipoUsuario.Tesoreria;
                        break;
                    case 2:
                        Tipo = e_TipoUsuario.Administrador;
                        break;
                    case 3:
                        Tipo = e_TipoUsuario.Supervisor;
                        break;
                    case 4:
                        Tipo = e_TipoUsuario.RRHH;
                        break;
                    case 5:
                        Tipo = e_TipoUsuario.Sistemas;
                        break;
                }
            }
        }
        public string Clave { get; set; }
        public e_Permiso Permiso { get; set; }
        public e_TipoUsuario Tipo { get; set; }

    }
}
