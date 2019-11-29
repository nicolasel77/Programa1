namespace Programa1.DB
{
    using System;
    class Compra_Hacienda
    {

        public Compra_Hacienda()
        {
        }

        public Compra_Hacienda(int id, NBoletas nBoleta, Consignatarios consignatario, Productos producto, int cabezas, float kilos, float costo, float iVA, byte plazo)
        {
            Id = id;
            NBoleta = nBoleta;
            Consignatario = consignatario;
            Producto = producto;
            Cabezas = cabezas;
            Kilos = kilos;
            Costo = costo;
            IVA = iVA;
            Plazo = plazo;
        }

        public int Id { get; set; }
        public NBoletas NBoleta { get; set; }
        public Consignatarios Consignatario { get; set; }
        public Productos Producto { get; set; }
        public int Cabezas { get; set; }
        public Single Kilos { get; set; }
        public Single Costo { get; set; }
        public Single IVA { get; set; }
        public Byte Plazo { get; set; }

    }
}
