namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmBuscarGasto : Form
    {
        Gastos gastos;
        string topp = "TOP 100";

        public bool IR = false;
        public bool COPIAR = false;

        public frmBuscarGasto(Gastos gasto)
        {
            InitializeComponent();
            gastos = gasto;

            grd.MostrarDatos(gastos.Datos_Genericos("SELECT  [ID], [Fecha], [IDC], [Caja], [ID_TipoGastos] Tipo, [Desc_Tipo], [ID_SubTipoGastos] ST, [Desc_SubTipo], [ID_DetalleGastos] DT, [Descripcion], Importe FROM vw_Gastos WHERE ID=-1"), true, false);
            formato();
        }

        private void txtBuscar_TextChanged(object sender, System.EventArgs e)
        {
            tiBuscar.Stop();
            tiBuscar.Start();
        }

        private void cmdCerrar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cmdCien_Click(object sender, System.EventArgs e)
        {
            topp = "TOP 100";
            tiBuscar.Stop();
            tiBuscar.Start();
        }

        private void tiBuscar_Tick(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            grd.Rows = 1;
            if (txtBuscar.TextLength > 0)
            {
                string consulta = txtBuscar.Text;
                consulta = consulta.Replace(" ", "%");
                consulta = $"%{consulta}%";
                consulta = $"SELECT {topp} " +
                    $" [ID], [Fecha], [IDC], [Caja], [ID_TipoGastos] Tipo, [Desc_Tipo], [ID_SubTipoGastos] ST, [Desc_SubTipo], [ID_DetalleGastos] DT, [Descripcion], Importe" +
                    $" FROM vw_Gastos " +
                    $" WHERE Descripcion LIKE '{consulta}' " +
                    $" ORDER BY Fecha DESC";
                DataTable dt = gastos.Datos_Genericos(consulta);

                grd.MostrarDatos(dt, true, false);
                formato();
            }
            tiBuscar.Stop();
            this.Cursor = Cursors.Default;

        }

        private void formato()
        {
            grd.set_ColW(0, 0);
            grd.set_ColW(1, 60);
            grd.set_ColW(2, 20);
            grd.set_ColW(3, 60);
            grd.set_ColW(4, 20);
            grd.set_ColW(5, 60);
            grd.set_ColW(6, 40);
            grd.set_ColW(7, 80);
            grd.set_ColW(8, 40);
            grd.set_ColW(9, 400);
            grd.set_ColW(10, 90);


            grd.Columnas[grd.get_ColIndex("Importe")].Format = "N2";
        }

        private void cmdMil_Click(object sender, System.EventArgs e)
        {
            topp = "TOP 1000";
            tiBuscar.Stop();
            tiBuscar.Start();
        }

        private void cmdTodos_Click(object sender, System.EventArgs e)
        {
            topp = "";
            tiBuscar.Stop();
            tiBuscar.Start();
        }

        private void cmdIr_Click(object sender, System.EventArgs e)
        {
            if (grd.Row > 0)
            {
                IR = true;
                gastos.Fecha = Convert.ToDateTime(grd.get_Texto(grd.Row, 1));

                this.Close();
            }
        }

        private void cmdCopiar_Click(object sender, EventArgs e)
        {
            if (grd.Row > 0)
            {
                COPIAR = true;
                gastos.caja.ID = Convert.ToInt32(grd.get_Texto(grd.Row, 2));
                gastos.TG.Id_Tipo = Convert.ToInt32(grd.get_Texto(grd.Row, 4));
                gastos.Id_SubTipoGastos = Convert.ToInt32(grd.get_Texto(grd.Row, 6));
                gastos.Desc_SubTipo = Convert.ToString(grd.get_Texto(grd.Row, 7));
                gastos.Id_DetalleGastos = Convert.ToInt32(grd.get_Texto(grd.Row, 8));
                gastos.Descripcion = Convert.ToString(grd.get_Texto(grd.Row, 9));
                gastos.Importe = Convert.ToDouble(grd.get_Texto(grd.Row, 10));                
                
                gastos.Agregar();

                this.Close();
            }
        }
    }
}
