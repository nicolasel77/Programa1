namespace Programa1.DB.Varios
{
    using Programa1.Clases;

    public class Configuraciones : c_Base
    {
        public Configuraciones()
        {
            Tabla = "Configuraciones";
        }

        public string Leer(string dato)
        {
            string ndato = (string)Dato_Generico($"SELECT Valor FROM Configuraciones WHERE Dato LIKE '{dato}' AND Usuario LIKE '{System.Environment.UserName}'");

            if (string.IsNullOrEmpty(ndato))
            {
                ndato = "";
            }

            return ndato;
        }

        public void Escribir(string dato, string valor)
        {
            Ejecutar_Comando($"DELETE FROM Configuraciones WHERE Dato LIKE '{dato}' AND Usuario LIKE '{System.Environment.UserName}'");
            Ejecutar_Comando($"INSERT INTO Configuraciones (Dato, Valor, Usuario) VALUES('{dato}', '{valor}', '{System.Environment.UserName}')");
        }
    }
}
