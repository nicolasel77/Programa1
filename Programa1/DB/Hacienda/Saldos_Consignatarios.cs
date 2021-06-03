namespace Programa1.DB
{
    using Programa1.Carga.Hacienda;
    using Programa1.Clases;
    using Programa1.DB.Tesoreria;
    using System.Data;

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
            fr.gastos = gastos;
            fr.Cargar();
            fr.ShowDialog();
            Aceptado = fr.Aceptado;
        }

        public DataTable Datos(bool conNuevo = true)
        {
            if (gastos is null) { gastos = new Gastos(); }
            if (gastos.Id_SubTipoGastos != 0)
            {
                return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND (Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Venc, Dias, NBoleta, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo, Estado" : "")}", "NBoleta DESC, ID_Consignatarios");
            }
            else
            {
                return Datos_Vista("(Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo" : "")}, Estado", "NBoleta DESC, ID_Consignatarios");
            }            
        }

        public DataTable Vencimientos()
        {
            Vista = "vw_Saldos_Hacienda";
            if (gastos is null) { gastos = new Gastos(); }
            if (gastos.Id_SubTipoGastos != 0)
            {
                return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND (Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
            }
            else
            {
                return Datos_Vista("(Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
            }
        }
        public DataTable Vencimientos_Agr()
        {
            Vista = "vw_Agregados_Hacienda";
            if (gastos is null) { gastos = new Gastos(); }
            if (gastos.Id_SubTipoGastos != 0)
            {
                return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND (Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Dias, NBoleta, Nombre, Descripcion, Importe, Pago, Dif, Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
            }
            else
            {
                return Datos_Vista("(Saldo >10 OR Saldo<-10)", $"TOP 100 Id, Fecha, Plazo, Dias, NBoleta, Nombre, Descripcion, Importe, 0.0 Pago, 0.0 Dif, 0.0 Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
            }
        }
    }
}
