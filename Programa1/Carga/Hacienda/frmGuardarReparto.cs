namespace Programa1.Carga.Hacienda
{
    using Programa1.Clases;
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmGuardarReparto : Form
    {
        public frmGuardarReparto()
        {
            InitializeComponent();
        }

        private void cmdSincSalidas_Click(object sender, EventArgs e)
        {
            Cargar_Salida();
        }

        private void Cargar_Salida()
        {
            Hacienda_Salidas salidas_sistema = new Hacienda_Salidas("Hacienda_Salidas", "vw_Hacienda_Salidas");
            salidas_sistema.Borrar($"Fecha BETWEEN '{mDesde.Value:MM/dd/yy}' AND '{mHasta.Value:MM/dd/yy}'");

            c_Base_Access clsAccess = new c_Base_Access("Salidas", "vw_Salidas");
            clsAccess.Campo_ID = "ID_Salidas";
            clsAccess.Base_Access = "D:/GDrive2/dbStock.accdb";

            DataTable dtFechas = clsAccess.Datos_Vista($"Fecha BETWEEN #{mDesde.Value:MM/dd/yy}# AND #{mHasta.Value:MM/dd/yy}#", "Fecha", "Fecha", "Fecha");

            if (dtFechas != null)
            {
                foreach (DataRow drF in dtFechas.Rows)
                {
                    cmdSincSalidas.Text =  $"Guardando: {Convert.ToDateTime(drF["Fecha"]):dd/MM}";
                    Application.DoEvents();
                    DataTable dtSalidas = clsAccess.Datos_Vista($"Fecha=#{Convert.ToDateTime(drF["Fecha"]):MM/dd/yy}#", "ID_Salidas, Fecha, ID_Sucursales, ID_Faena, Media");

                    foreach (DataRow drS in dtSalidas.Rows)
                    {
                        salidas_sistema.ID = Convert.ToInt32(drS["ID_Salidas"]);
                        salidas_sistema.Fecha = Convert.ToDateTime(drS["Fecha"]);
                        salidas_sistema.Sucursal.ID = Convert.ToInt32(drS["ID_Sucursales"]);
                        salidas_sistema.Faena.ID = Convert.ToInt32(drS["ID_Faena"]);
                        salidas_sistema.Faena.Cargar_Registro();
                        salidas_sistema.Media = Convert.ToInt32(drS["Media"]);
                        salidas_sistema.Cargar_CostoSalida();
                        salidas_sistema.Agregar();
                    }
                }
            }
            cmdSincSalidas.Text = "Sincronizar Salidas";
        }
    }
}
