namespace Programa1.DB
{
    using Programa1.Clases;
    using System;

    public class Fichador : c_Base
    {
        public Fichador()
        {
            Tabla = "dbEmpleados2.dbo.Registro_Asistencias";

        }
        public int Id { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime Hora { get; set; } = DateTime.Now;
        public Empleados Empleado { get; set; } = new Empleados();
        public string Dispositivo { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Empleado.Nombre} - {Fecha.ToShortDateString()}";
        }

        /// <summary>
        /// Devuelve las fichadas de empleados de la sucursal del dia pasado rotando por empleado
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="suc"></param>
        /// <param name="emp">El resultado se ordena por empleado, si se pasa un valor se busca el siguiente</param>
        /// <returns>el primer empleado encontrado</returns>
        public int Fichadas_EnSuc(DateTime fecha, int suc, int emp = 0)
        {
            int id = 0;
            string filtro = $"SELECT TOP 1 ISNULL(Empleado, 0) FROM dbEmpleados2.dbo.Registros_Asistencias F WHERE CONVERT(DATE, Fecha)='{fecha:MM/dd/yy}' AND Dispositivo='{suc}' AND Empleado>{emp} ORDER BY Empleado, Hora";
            
            object n = base.Dato_Generico(filtro);
            id = Convert.ToInt32(n);

            if (id == 0 && emp != 0)
            {
                emp = 0; // Si no hay fichadas, se reinicia el emp para buscar desde el principio
                filtro = $"SELECT TOP 1 ISNULL(Empleado, 0) FROM dbEmpleados2.dbo.Registros_Asistencias F WHERE CONVERT(DATE, Fecha)='{fecha:MM/dd/yy}' AND Dispositivo='{suc}' ORDER BY Empleado, Hora";
                n = base.Dato_Generico(filtro);
            }
            id = Convert.ToInt32(n);
            return id;
        }
    }
}
