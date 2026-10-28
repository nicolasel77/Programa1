namespace Programa1.Carga.TM
{
    using Programa1.Carga.Proveedores;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmPagarHacienda : Form
    {
        private clsTM tM = new clsTM();
        public int id_factura = 0;
        public double importe = 0;
        public string detalle = "";
        public frmPagarHacienda()
        {
            InitializeComponent();
        }

        private void frmPagarHacienda_Load(object sender, EventArgs e)
        {
            
        }

        internal void Cargar_Facturas(int consignatario)
        {            
            DataTable dt = new DataTable();
            dt = tM.Resumen_ComprasHacienda(consignatario, true);
            grdFacturas.MostrarDatos(dt, true, false);

            grdFacturas.Columnas["Id_Consignatarios"].Visible = false;
            grdFacturas.Columnas["Id"].Visible = false;

            grdFacturas.Columnas["Total_Cab"].Style.Format = "N";
            grdFacturas.Columnas["Total_Kilos"].Style.Format = "N";
            grdFacturas.Columnas["SubTotal"].Style.Format = "N";
            grdFacturas.Columnas["Agregados"].Style.Format = "N";
            grdFacturas.Columnas["Total"].Style.Format = "N";
            grdFacturas.Columnas["Pagos"].Style.Format = "N";
            grdFacturas.Columnas["Saldo"].Style.Format = "N";

            grdFacturas.AutosizeAll();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdFacturas.Row > 0)
            {
                id_factura = (int)grdFacturas.get_Texto(grdFacturas.Row, 0);
                importe = Convert.ToDouble(grdFacturas.get_Texto(grdFacturas.Row, grdFacturas.get_ColIndex("Saldo")));
                importe = importe * -1;
                double compra = Convert.ToDouble(grdFacturas.get_Texto(grdFacturas.Row, grdFacturas.get_ColIndex("Total")));

                if ((importe - compra) < 1 && (importe - compra) > 1)
                {
                    detalle = "Total";
                }
                else
                {
                    detalle = "Parcial";
                }
            }
            this.Hide();
        }
    }
}
