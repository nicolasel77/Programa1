
namespace Programa1.Carga.Sucursales
{
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using System;
    using System.Windows.Forms;

    public partial class frmPrecios_Stock : Form
    {
        Cambio_Precios_Stock cm = new Cambio_Precios_Stock();
        private DateTime vSemana;
        public frmPrecios_Stock()
        {
            InitializeComponent();
            Semanas sm = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sm.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            vSemana = Convert.ToDateTime(lstSemanas.Text);
            grd.MostrarDatos(cm.Datos_Vista($"Costo_Nuevo<>0 AND Fecha='{vSemana.AddDays(-1):MM/dd/yy}'", "*, (Costo_Nuevo*Kilos) AS Total_Nuevo, ((Costo_Nuevo*Kilos) - Total) AS Diferencia", "Suc, Prod"), true, false);
            grd.Columnas[5].Format = "N1";
            grd.Columnas[6].Format = "N1";
            grd.Columnas[7].Format = "N1";
            grd.Columnas[8].Format = "N1";
            grd.Columnas[9].Format = "N1";
            grd.Columnas[10].Format = "N1";
            grd.AutosizeAll();

            grdResumen.MostrarDatos(cm.Datos_Vista($"Costo_Nuevo<>0 AND Fecha='{vSemana.AddDays(-1):MM/dd/yy}'  GROUP BY Suc,Nombre", "Suc, Nombre, SUM((Costo_Nuevo*Kilos) - Total) AS Diferencia", "Suc"), true, 2);
            grdResumen.Columnas[2].Format = "N1";
            grdResumen.AutosizeAll();

            this.Cursor = Cursors.Default;

        }

        private void cmdCopiar_Click(object sender, EventArgs e)
        {
            // Copiar el importe resumen por -1
            Reintegros r = new Reintegros();

            for (int i = 1; i <= grdResumen.Rows - 2; i++)
            {
                r.Fecha = vSemana;
                r.Sucursal.Id = Convert.ToInt32(grdResumen.get_Texto(i, 0));
                if (r.Sucursal.Id != 0)
                {
                    r.Tipo.ID = 4;
                    r.Descripcion = "Reintegro por cambio de precios.";
                    r.Importe = Convert.ToDouble(grdResumen.get_Texto(i, 2));
                    r.Importe = r.Importe * -1;
                    r.Agregar(); 
                }
            }
        }
    }
}
