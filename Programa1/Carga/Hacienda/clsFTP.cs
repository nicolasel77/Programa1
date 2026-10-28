namespace Programa1.Carga.Hacienda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class clsFTP
    {
        public string servidor { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }

        public clsFTP() 
        { 
            servidor = "lacosteleta.com.ar";
            usuario = "tdulces";
            password = "h%sQ@ZMCFfQ8rRneg3*CGnw*";

        }

        public void bajar_archivo(string archivo = "dbStock.accdb")
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    string carpeta = AppDomain.CurrentDomain.BaseDirectory + "\\ftp";
                    //Si no existe la carpeta la creo
                    if (!System.IO.Directory.Exists(carpeta))
                    {
                        System.IO.Directory.CreateDirectory(carpeta);
                    }

                    client.Credentials = new System.Net.NetworkCredential(usuario, password);
                    client.DownloadFile("ftp://" + servidor + "/ftp/" + archivo, carpeta + "\\" + archivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al bajar archivo FTP: " + ex.Message);
            }
        }


    }
}
