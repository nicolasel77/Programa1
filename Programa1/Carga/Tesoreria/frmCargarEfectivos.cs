namespace Programa1.Carga.Tesoreria
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

    public partial class frmCargarEfectivos : Form
    {
        public frmCargarEfectivos()
        {
            InitializeComponent();
        }

        private void frmCargarEfectivos_Load(object sender, EventArgs e)
        {
            Efectivos efectivos = new Efectivos();
            DataTable dt = efectivos.SinCargar();
            dt.Columns.Add("Seleccionar", typeof(bool));
            grdEfectivos.MostrarDatos(dt, true, false);
            grdEfectivos.set_Texto(0, "ID_Sucursal", "Suc");
            grdEfectivos.AutosizeAll();
            grdEfectivos.set_ColW(0, 0);
            grdEfectivos.Columnas["Importe"].Format = "N0";
            double total = grdEfectivos.SumarCol("Importe", false);
            lblTotal.Text = "Total: " + total.ToString("N0");

            grdAgrpado.MostrarDatos(efectivos.Agrupados(), true, false);
            grdAgrpado.set_Texto(0, "ID_Sucursal", "Suc");
            grdAgrpado.AutosizeAll();            
            grdAgrpado.Columnas["Importe"].Format = "N0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdEfectivos_Editado(short f, short c, object a)
        {
            // Solo se puede editar la columna Cargado, la columan Seleccionar es para marcar los registros a cargar
            if (grdEfectivos.Columnas[c].Name == "Cargado")
            {
                Efectivos ef = new Efectivos();
                ef.ID = Convert.ToInt32(grdEfectivos.get_Texto(f, "ID"));
                ef.Actualizar("Cargado", a);
                grdEfectivos.ActivarCelda(f + 1, c);
            }
            if (grdEfectivos.Columnas[c].Name == "Seleccionar")
            {
                grdEfectivos.ActivarCelda(f + 1, c);
            }
        }
    }
}
