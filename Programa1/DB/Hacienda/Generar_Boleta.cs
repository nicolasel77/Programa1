using Programa1.Carga.Hacienda;
using Programa1.Clases;
using Programa1.DB.Tesoreria;
using System.Data;

public class Generar_Boleta : c_Base
{
    public Generar_Boleta()
    {
        Vista = "vw_Hacienda_Saldos";
    }

    public Gastos gastos { get; set; }
    public bool Aceptado;

    //public void Cargar_Pago()
    //{
    //    frmPagar_Hacienda fr = new frmPagar_Hacienda();
    //    fr.saldos = this;
    //    fr.Cargar();
    //    fr.ShowDialog();
    //    Aceptado = fr.Aceptado;
    //}
    //public void Cargar_PagoAgregados()
    //{
    //    frmPagar_Agregados fr = new frmPagar_Agregados();
    //    fr.saldos = this;
    //    fr.gastos = gastos;
    //    fr.Cargar();
    //    fr.ShowDialog();
    //    Aceptado = fr.Aceptado;
    //}

    public DataTable Datos(bool conNuevo = true)
    {
        Vista = "vw_Hacienda_Saldos";
        if (gastos is null) { gastos = new Gastos(); }
        if (gastos.Id_SubTipoGastos != 0)
        {
            return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND Saldo<-10", $"Id_CompraFrigo, Fecha, Plazo, Venc, Dias, NBoleta, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo, Estado" : "")}", "NBoleta DESC, ID_Consignatarios");
        }
        else
        {
            return Datos_Vista("Saldo<-10", $"Id_CompraFrigo, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo" : "")}, Estado", "NBoleta DESC, ID_Consignatarios");
        }
    }
    public DataTable Datos_Agr(bool conNuevo = true)
    {
        Vista = "vw_Hacienda_Agregados";
        if (gastos is null) { gastos = new Gastos(); }
        if (gastos.Id_SubTipoGastos != 0)
        {
            return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND Saldo<-10", $" Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo" : "")}, Estado", "NBoleta DESC, ID_Consignatarios");
        }
        else
        {
            return Datos_Vista("Saldo<-10", $"Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo{(conNuevo ? ", 0.0 AS Nuevo" : "")}, Estado", "NBoleta DESC, ID_Consignatarios");
        }
    }

    public DataTable Vencimientos()
    {
        Vista = "vw_Hacienda_Saldos";
        if (gastos is null) { gastos = new Gastos(); }
        if (gastos.Id_SubTipoGastos != 0)
        {
            return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND Saldo<-10", $" Id_CompraFrigo, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo, Estado, ID_Matr, Matricula, (SELECT CONVERT(bit,0)) as Boleta", "NBoleta DESC, ID_Consignatarios");
        }
        else
        {
            return Datos_Vista("Saldo<-10", $" Id_CompraFrigo, Fecha, Plazo, Venc, Dias, NBoleta, Nombre, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo, Estado, ID_Matr, Matricula, (SELECT CONVERT(bit,0)) as Boleta", "NBoleta DESC, ID_Consignatarios");
        }
    }
    public DataTable Vencimientos_Agr()
    {
        Vista = "vw_Hacienda_Agregados";
        if (gastos is null) { gastos = new Gastos(); }
        if (gastos.Id_SubTipoGastos != 0)
        {
            return Datos_Vista($"ID_Consignatarios={gastos.Id_SubTipoGastos} AND Saldo<-10", $" Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
        }
        else
        {
            return Datos_Vista("Saldo<-10", $" Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula", "NBoleta DESC, ID_Consignatarios");
        }
    }

}
