namespace Programa1.DB.Varios
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Estadisticas : c_Base
    {
        public Semanas semanas = new Semanas();
        public Estadisticas()
        {

        }

        public void Guardar(DateTime semana)
        {
            Ejecutar_Comando($"EXEC dbo.sp_Guardar_Semana '{semana:MM/dd/yy}'");
        }
        public void Guardar()
        {
            if (semanas.Semana != null)
            {
                Ejecutar_Comando($"EXEC dbo.sp_Guardar_Semana '{semanas.Semana:MM/dd/yy}'"); 
            }
        }

        public void Venta_PorProductos(DateTime semana)
        {
            Ejecutar_Comando($"EXEC dbo.sp_VentaPorSucProd '{semana:MM/dd/yy}'");
        }
        public void Venta_PorProductos()
        {
            if (semanas.Semana != null)
            {
                Ejecutar_Comando($"EXEC dbo.sp_VentaPorSucProd '{semanas.Semana:MM/dd/yy}'");
            }
        }
    }

}
