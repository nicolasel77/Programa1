namespace Programa1.DB.Proveedores
{
    using Programa1.Clases;
    using System;

    public class Estados_Compra : c_Base
    {
        public enum e_Estado : byte
        {
            Sin_Chequear = 0,
            Chequeado = 1,
            Error = 2
        }

        public Estados_Compra()
        {
            Tabla = "Estados_Compra";
            ID_Automatico = true;
        }
        public DateTime Fecha { get; set; }
        public Proveedores Proveedor { get; set; } = new Proveedores();
        public e_Estado Estado { get; set; }
        public string Observacion { get; set; }

        public void Siguiente()
        {
            switch (Estado)
            {
                case e_Estado.Chequeado:
                    Estado = e_Estado.Error;
                    Actualizar("Estado", (byte)Estado);
                    break;
                case e_Estado.Error:
                    Estado = e_Estado.Sin_Chequear;
                    Borrar();
                    break;
                case e_Estado.Sin_Chequear:
                    Estado = e_Estado.Chequeado;
                    Agregar();
                    break;
            }
        }

        public new void Agregar()
        {
            Agregar_NoID("Fecha", Fecha);
            Actualizar("Id_Proveedor", Proveedor.Id);
            Actualizar("Estado", (byte) Estado);
            Actualizar("Observacion", Observacion);
        }
    }
}
