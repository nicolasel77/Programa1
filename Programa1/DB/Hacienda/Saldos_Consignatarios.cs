namespace Programa1.DB
{
    using Programa1.Clases;
    using Programa1.Carga.Hacienda;
    using System.Data;
    using Programa1.DB.Tesoreria;

    public class Saldos_Consignatarios : c_Base
    {
        public Saldos_Consignatarios()
        {
            Vista = "vw_Saldos_Hacienda";
        }

        public Gastos gastos { get; set; }
        public bool Aceptado;

        public void Cargar_Pago()
        {
            frmPagar_Hacienda fr = new frmPagar_Hacienda();
            fr.saldos = this;
            fr.Cargar();
            fr.ShowDialog();
            Aceptado = fr.Aceptado;
        }



        public DataTable Datos()
        {
            return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND ROUND(Saldo, 0) <> 0", "TOP 100 Id, Fecha, Plazo, Venc, Dias, NBoleta, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Saldo, 0.0 AS Nuevo", "NBoleta DESC");
        }
    }
}
