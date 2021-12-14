namespace Programa1.Herramientas
{
    using System.Text.RegularExpressions;

    internal class Expresiones_Regulares
    {
        public Expresiones_Regulares()
        {

        }

        //Funcion que valida una cadena de texto con una expresion regular
        public bool Validar(string cadena, string expresion)
        {
            Regex rg = new Regex(expresion);
            return rg.IsMatch(cadena);
        }

        //Extraer un valor de una cadena de texto
        public string Extraer(string cadena, string expresion)
        {
            Regex rg = new Regex(expresion);
            MatchCollection mc = rg.Matches(cadena);
            return mc[0].Value;
        }
    }
}
