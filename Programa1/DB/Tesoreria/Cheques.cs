namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;

    public class Cheques : c_Base
    {
        public Cheques()
        {
            Tabla = "Cheques";
            Vista = "vw_Cheques";
            ID_Automatico = true;
        }

        public Bancos Banco { get; set; } = new Bancos();
        public int Numero { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Acreditacion { get; set; }
        public double Importe { get; set; }


        #region " Editar Datos "

        public new void Agregar()
        {
            Agregar_NoID("Numero", Numero);
            Actualizar("ID_Banco", Banco.ID);
            Actualizar("Fecha_Entrada", Fecha_Entrada);
            Actualizar("Fecha_Acreditacion", Fecha_Acreditacion);
            Actualizar("Importe", Importe);
        }
        public new void Actualizar()
        {

            Actualizar("Numero", Numero);
            Actualizar("ID_Banco", Banco.ID);
            Actualizar("Fecha_Entrada", Fecha_Entrada);
            Actualizar("Fecha_Acreditacion", Fecha_Acreditacion);
            Actualizar("Importe", Importe);
        }


        #endregion

    }
}
