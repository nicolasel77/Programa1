namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;

    public class Compra_Hacienda : c_Base
    {
        public enum Estados_Hacienda : byte
        {
            Sin_Chequear = 0,
            Aprovado = 1,
            Error = 2
        }

        public Compra_Hacienda()
        {
            Vista = "vw_Hacienda_Compras";
            Tabla = "Hacienda_Compras";
            Campo_ID = "ID_CompraFrigo";
        }

        public NBoletas NBoleta { get; set; } = new NBoletas();
        public Consignatarios Consignatario { get; set; } = new Consignatarios();
        public Productos Producto { get; set; } = new Productos();
        public int Cabezas { get; set; }
        public Single Kilos { get; set; }
        public Single Costo { get; set; }
        public Single Costo2 { get; set; }
        public Single IVA { get; set; }
        public Byte Plazo { get; set; }
        public int Estado { get; set; }
        public double Percepcion { get; set; }
        public double Saldo { get; set; }
        public DateTime Fecha { get; set; }

        public Matriculas Matricula { get; set; } = new Matriculas();

        public new void Actualizar()
        {
            Actualizar("NBoleta", NBoleta.ID);
            Actualizar("ID_Consignatarios", Consignatario.ID);
            Actualizar("Id_Productos", Producto.ID);
            Actualizar("Fecha", Fecha);
            Actualizar("Cabezas", Cabezas);
            Actualizar("Kilos", Kilos);
            Actualizar("Costo", Costo);
            Actualizar("Costo2", Costo2);
            Actualizar("Iva", IVA);
            Actualizar("Percepcion", Percepcion);
            Actualizar("Plazo", Plazo);
            Actualizar("Saldo", Saldo);
            Actualizar("Estado", Estado);
            Actualizar("Matricula", Matricula.ID);
            Actualizar("Saldo", Saldo);
            
        }


        public void Calcular_Saldo()
        {
            Ejecutar_Comando($"EXEC sp_ActualizarSaldoBoleta {Consignatario.ID}, {NBoleta.ID}");
            
        }

        public void Actualizar_Saldo()
        {
            Actualizar("Saldo", Saldo);
        }

        public new void Agregar()
        {
            Agregar("NBoleta", NBoleta.ID);
            Actualizar();
        }

        public new void Borrar()
        {
            //Uso este comando, que es igual al del c_Base para poder actualizar el saldo
            Borrar("Id=" + ID);
            Actualizar_Saldo();
        }

        public void Cargar_Fila(int id)
        {
            var dt = Datos_Vista("Id=" + id);

            if (dt.Rows.Count != 0)
            {
                try
                {
                    DataRow dr = dt.Rows[0];

                    ID = id;
                    NBoleta.ID = Convert.ToInt32(dr["NBoleta"]);
                    Fecha = Convert.ToDateTime(dr["Fecha"]);
                    Consignatario.ID = Convert.ToInt32(dr["Id_Consignatarios"]);
                    Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                    Cabezas = Convert.ToInt32(dr["Cabezas"]);
                    Costo = Convert.ToSingle(dr["Costo"]);
                    Costo2 = Convert.ToSingle(dr["Costo2"]);
                    Kilos = Convert.ToSingle(dr["Kilos"]);
                    IVA = Convert.ToSingle(dr["IVA"]);
                    Percepcion = Convert.ToDouble(dr["Percepcion"]);
                    Plazo = Convert.ToByte(dr["Plazo"]);
                    Saldo = Convert.ToDouble(dr["Saldo"]);
                    Matricula.ID = Convert.ToInt32(dr["ID_Matr"]);
                }
                catch (Exception)
                {
                    ID = 0;
                }
            }
        }

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "ID_CompraFrigo, Fecha, ID_Matr, Matricula, ID_Consignatarios, Nombre, Cabezas Cab, ID_Productos Prod, Nombre_Producto Descr, Kilos, Costo, Costo2, Sub_Total, IVA, Percepcion, Total, Plazo");
        }
        public DataTable Consignatarios_En_Boleta(int nb)
        {
            return Datos_Vista("NBoleta=" + nb, "ID_Consignatarios", "ID_Consignatarios", "ID_Consignatarios");

        }
    }
}
