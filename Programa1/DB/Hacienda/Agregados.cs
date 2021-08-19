namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Agregados_Hacienda : c_Base
    {
        public Agregados_Hacienda()
        {
            Tabla = "Hacienda_Agregados";
            Vista = "vw_Hacienda_Agregados";
            Campo_ID = "ID_Agregados_Frigo";
        }

        public NBoletas nb { get; set; } = new NBoletas();

        public TipoAgregados tipoAgregados = new TipoAgregados();
        public Consignatarios Consignatario { get; set; } = new Consignatarios();
        public TipoAgregados Tipo { get; set; } = new TipoAgregados();
        public DateTime Fecha { get; set; }
        public Single Importe { get; set; }
        public int Plazo { get; set; }
        public int Estado { get; set; }
        public double Saldo { get; set; }
        public Matriculas Matricula { get; set; } = new Matriculas();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "ID, Fecha, ID_TipoAgregados, Descripcion, ID_Consignatarios, Nombre, Importe, Plazo");
        }

        public new void Actualizar()
        {
            Actualizar("NBoleta", nb.ID);
            Actualizar("Fecha", Fecha);
            Actualizar("id_Consignatarios", Consignatario.ID);
            Actualizar("id_TipoAgregados", Tipo.ID);
            Actualizar("Importe", Importe);
            Actualizar("Plazo", Plazo);
            Actualizar("Saldo", Saldo);
            Actualizar("Estado", Estado);
            Actualizar("Matricula", Matricula.ID);
            Actualizar("Saldo", Saldo);
        }
        public void Calcular_Saldo()
        {
            Ejecutar_Comando($"EXEC sp_ActualizarSaldoBoleta {Consignatario.ID}, {nb.ID}");

        }
        public void Actualizar_Saldo()
        {
            Actualizar("Saldo", Saldo);
        }
    }
}
