namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmCopiarVentaACompra : Form
    {
        private Ventas venta;

        //Compra = 1
        //Traslado = 2
        public int cargado = 0;
        public bool Aceptado = false;
        public bool Agrupar = true;
        public bool BorrarOri = false;
        public string filtro = "";
        public DataTable dt;


        public frmCopiarVentaACompra()
        {
            InitializeComponent();
            venta = new Ventas();
        }

        public void Cargarc()
        {
            if (filtro.Length > 0)
            {
                dt = venta.Resumen_Compra(filtro, Agrupar);
                if (dt != null)
                {
                    grd.MostrarDatos(dt, true, false);
                    grd.AutosizeAll();
                    grd.Columnas[grd.get_ColIndex("Costo")].Format = "C2";
                    grd.Columnas[grd.get_ColIndex("Kilos")].Format = "N2";
                    grd.Columnas[grd.get_ColIndex("Total")].Format = "C2";
                }
            }
        }

        public void cargarT()
        {
            if (filtro.Length > 0)
            {
                dt = venta.Resumen_ATraslados(filtro, Agrupar);
                if (dt != null)
                {
                    grd.MostrarDatos(dt, true, false);
                    grd.Columnas[grd.get_ColIndex("Costo_Entrada")].Format = "C2";
                    grd.Columnas[grd.get_ColIndex("Costo_Salida")].Format = "C2";
                    grd.Columnas[grd.get_ColIndex("Kilos")].Format = "N2";
                    grd.Columnas[grd.get_ColIndex("Total_Entrada")].Format = "C2";
                    grd.Columnas[grd.get_ColIndex("Total_Salida")].Format = "C2";
                }
            }
        }
        private void CmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptado = true;
        }

        private void chAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            Agrupar = chAgrupar.Checked;
            if (cargado == 1)
            { Cargarc(); }
            else
            {
                if (cargado == 2)
                { cargarT(); }
            }
        }

        private void chBorrarOriginal_CheckedChanged(object sender, EventArgs e)
        {
            BorrarOri = chBorrarOriginal.Checked;
        }
    }
}
