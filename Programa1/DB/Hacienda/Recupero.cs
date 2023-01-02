using Programa1.Clases;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB
{
    public class Recupero : c_Base
    {
        public Recupero()
        {
            Tabla = "Recuperos";
            Vista = "vw_Recuperos";
        }

        public DateTime Fecha { get; set; }

        public Productos Producto { get; set; } = new Productos();
        public Frigorificos Frigorifico { get; set; } = new Frigorificos();
        public bool Mercado { get; set; }
        public float Valor { get; set; }



        public float Buscar(DateTime fecha, int prod, int frigo, bool mercado)
        {
            string m = mercado ? "1" : "0";
            object d = Dato($"Fecha<='{fecha:MM/dd/yy}' AND ID_Productos={prod} AND ID_Frigorificos={frigo} AND Mercado={m}", "Recupero", "Fecha DESC");

            if (d == DBNull.Value) { d = 0; }

            return Convert.ToSingle(d);
        }

        public DataTable Fechas()
        {
            if (Frigorifico.ID != 0)
            {
                return Datos_Vista("Id_Frigorificos=" + Frigorifico.ID, "TOP 50 Fecha", "Fecha DESC", "Fecha");
            }
            else
            {
                return Datos_Vista("", "TOP 50 Fecha", "Fecha DESC", "Fecha");
            }
        }

        public DataTable Valores()
        {
            return Datos_Genericos($"SELECT * FROM (SELECT Id_Productos Prod, Descripcion, Mercado, Recupero FROM vw_Recuperos WHERE Id_Frigorificos ={Frigorifico.ID} AND Fecha ='{Fecha:MM/dd/yyy}') AS Valores " +
                $"PIVOT(SUM(Recupero) FOR Mercado IN( [0], [1])) AS Valor ORDER BY Prod");

        }

        public DataTable Resumen(int cant = 50)
        {
            SqlParameter p1 = new SqlParameter("f", Fecha);
            SqlParameter p2 = new SqlParameter("frigo", Frigorifico.ID);
            SqlParameter p3 = new SqlParameter("t", cant);
            
            DataTable dt = sp_Datos("dbo.sp_ResumenSaldoRecupero", new SqlParameter[] { p1, p2, p3 });
            dt.Columns.Add("Diferencia", typeof(float));
            dt.Columns.Add("Saldo", typeof(float));

            return dt;
        }

        public new void Agregar()
        {
            Ejecutar_Comando($"INSERT INTO Recuperos(Fecha, ID_Frigorificos, ID_Productos, Mercado, Recupero) VALUES('{Fecha:MM/dd/yyy}', {Frigorifico.ID}, {Producto.ID}, {(Mercado ? "1" : "0")}, {Valor.ToString().Replace(",", ".")})");
        }

        internal void Actualizar_Faena()
        {
            Ejecutar_Comando($"UPDATE Faena SET Recupero=(SELECT TOP 1 r.Recupero FROM Recuperos r WHERE r.Fecha<=Faena.Fecha AND r.ID_Frigorificos=Faena.Id_Frigorificos AND r.Id_Productos=Faena.Id_Productos AND r.Mercado=(SELECT TOP 1 Mercado FROM vw_NBoletas NB WHERE NB.NBoleta=Faena.NBoleta)	ORDER BY Fecha DESC) WHERE Fecha>='{Fecha:MM/dd/yyy}' AND ID_Frigorificos={Frigorifico.ID}");

            NBoletas nb = new NBoletas();
            DataTable dt = nb.Datos($"Fecha>='{Fecha:MM/dd/yyy}'");

            foreach (DataRow dr in dt.Rows)
            {
                nb.Actualizar_CostoFinal(Convert.ToInt32(dr["NBoleta"]));
            }
        }

        internal double Saldo(DateTime f)
        {
            object s = Dato_Generico($"SELECT dbo.f_SaldoRecupero({Frigorifico.ID}, '{f:MM/dd/yy}')");
            return Convert.ToDouble(s);
        }
    }
}
