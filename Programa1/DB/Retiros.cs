namespace Programa1.DB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Retiros
    {
        public Retiros()
        {
        }
        public Retiros(int id, DateTime fecha, Empleados empl, Sucursales suc, TipoRetiros tipo, Single importe)
        {
            Id = id;
            Fecha = fecha;
            Empleado = empl;
            Sucursal = suc;
            Tipo = tipo;
            Importe = importe;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Empleados Empleado { get; set; }
        public Sucursales Sucursal { get; set; }
        public TipoRetiros Tipo { get; set; }
        public Single Importe { get; set; }


    }
}
