namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;

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
        }

        public NBoletas NBoleta { get; set; } = new NBoletas();
        public Consignatarios Consignatario { get; set; } = new Consignatarios();
        public Productos Producto { get; set; } = new Productos();
        public int Cabezas { get; set; }
        public Single Kilos { get; set; }
        public Single Costo { get; set; }
        public Single IVA { get; set; }
        public Byte Plazo { get; set; }
        public int Estado { get; set; }
        public double Saldo { get; set; }
        public Matriculas Matricula { get; set; } = new Matriculas();
        public new void Actualizar()
        {
            Actualizar("NBoleta", NBoleta.NBoleta);
            Actualizar("ID_Consignatarios", Consignatario.ID);
            Actualizar("Id_Productos", Producto.ID);
            Actualizar("Cabezas", Cabezas);
            Actualizar("Kilos", Kilos);
            Actualizar("Costo", Costo);
            Actualizar("Iva", IVA);
            Actualizar("Plazo", Plazo);
            Actualizar("Saldo", Saldo);
            Actualizar("Estado", Estado);
            Actualizar("Matricula", Matricula.ID);

            Actualizar_Saldo();
        }

        public void Actualizar_Saldo()
        {
            SqlParameter sqC = new SqlParameter("@C", Consignatario.ID);
            SqlParameter sqNB = new SqlParameter("@NB", NBoleta.NBoleta);
            SqlParameter[] sql = { sqC, sqNB };
            Ejecutar_sp("sp_ActualizarSaldosConsignatario", sql);
        }

        public new void Agregar()
        {
            Agregar("NBoleta", NBoleta.NBoleta);
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
                    NBoleta.NBoleta = Convert.ToInt32(dr["NBoleta"]);
                    Consignatario.ID = Convert.ToInt32(dr["Id_Consignatarios"]);
                    Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                    Cabezas = Convert.ToInt32(dr["Cabezas"]);
                    Costo = Convert.ToSingle(dr["Costo"]);
                    Kilos = Convert.ToSingle(dr["Kilos"]);
                    IVA = Convert.ToSingle(dr["IVA"]);
                    Plazo = Convert.ToByte(dr["Plazo"]);
                    Saldo = Convert.ToDouble(dr["Saldo"]);
                    Matricula.ID = Convert.ToInt32(dr["Matricula"]);
                }
                catch (Exception)
                {
                    ID = 0;
                }
            }
        }

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "ID, ID_Consignatarios, Nombre, Cabezas Cab, ID_Productos Prod, Nombre_Producto Descr, Kilos, Costo, Sub_Total, IVA, Total, Plazo");
        }
    }
}
