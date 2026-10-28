namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmEfectivos : Form
    {
        Efectivos efectivos = new Efectivos();
        public frmEfectivos()
        {
            InitializeComponent();
        }

        private void frmEfectivos_Load(object sender, EventArgs e)
        {
            
        }

        private void Cargar() 
        {
            string filtro = cFecha.Cadena();

            if (cSuc.Valor_Actual > 0)
            {
                filtro += " AND " + cSuc.Cadena("ID_Sucursal");
            }

            grdEfectivos.MostrarDatos(efectivos.Datos_Vista(filtro, "*", "Fecha, ID_Sucursal, id"), true, false);
            if (grdEfectivos.Rows > 0)
            {
                int c_imp = grdEfectivos.get_ColIndex("Importe");
                if (c_imp > 0)
                {
                    if (grdEfectivos.Cols > 0) { grdEfectivos.Columnas[c_imp].Style.Format = "N2"; }
                    ttTotal.Text = grdEfectivos.SumarCol(grdEfectivos.get_ColIndex("Importe"), false).ToString("C1");
                    grdEfectivos.AutosizeAll();
                }
            }
        }

        private void Cargar(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
