namespace Programa1.DB
{
    /// <summary>
    /// Control de lo que carga la sucursal en Sistema-Web (Efectivos y Entregas/tarjetas)
    /// contra la caja de Tesorería y los archivos de los procesadores.
    /// Solo lectura: vista dbo.vw_Control_Declarado (script DB/Sucursales/Scripts/cuentas_datos_sucursal.sql).
    /// </summary>
    public class Control_Declarado : c_Base
    {
        public Control_Declarado()
        {
            Tabla = "vw_Control_Declarado";
            Vista = "vw_Control_Declarado";
        }
    }
}
