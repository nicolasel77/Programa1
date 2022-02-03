namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;

    internal class Diarios : c_Base
    {
        public Diarios()
        {
            Tabla = "Diarios";
            Vista = "Diarios";
        }

        public int Caja { get; set; }
        public int Tipo { get; set; }
        public int SubTipo { get; set; }
        public string Desc_SubTipo { get; set; }
        public int Detalle { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
                
        public new void Agregar()
        {
            Agregar_NoID("Caja", Caja);
            ID = Max_ID();
            Actualizar();
        }
        public new void Actualizar()
        {
            Actualizar("Caja", Caja);
            Actualizar("Tipo", Tipo);
            Actualizar("SubTipo", SubTipo);
            Actualizar("Desc_SubTipo", Desc_SubTipo);
            Actualizar("Detalle", Detalle);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Importe", Importe);            
        }
    }
}
