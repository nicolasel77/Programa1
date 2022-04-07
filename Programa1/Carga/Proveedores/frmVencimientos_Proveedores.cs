namespace Programa1.Carga.Proveedores
{
    using System;
    using System.Windows.Forms;
    using global::Proveedores;
    using Programa1.DB.Proveedores;

    public partial class frmVencimientos_Proveedores : Form
    {
        CCtes_Proveedores CCtes = new CCtes_Proveedores();

        public frmVencimientos_Proveedores()
        {
            InitializeComponent();
            Cargar();
        }

        private void Fecha_Cambio_Seleccion(object sender, System.EventArgs e)
        {
            Cargar();
        }

        private void Proveedores_Cambio_Seleccion(object sender, System.EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            if(Proveedores.Valor_Actual != 0) { CCtes.gastos.Id_SubTipoGastos = Proveedores.Valor_Actual; }
            grd.MostrarDatos(CCtes.Pagos_Autorizados(), true);

            //"Fecha, Descripcion, Total, Pagos, Saldo, 0.0 Nuevo"
            int cfecha = grd.get_ColIndex("Fecha");
            int cdescripcion = grd.get_ColIndex("Descripcion");
            int ctotal = grd.get_ColIndex("Total");
            int cpagos = grd.get_ColIndex("Pagos");
            int csaldo = grd.get_ColIndex("Saldo");
            int cnuevo = grd.get_ColIndex("Nuevo");

            grd.set_ColW(cfecha, 60);
            grd.set_ColW(cdescripcion, 400);
            grd.set_ColW(ctotal, 90);
            grd.set_ColW(cpagos, 90);
            grd.set_ColW(csaldo, 90);
            grd.set_ColW(cnuevo, 0);

            if (ctotal > -1)
            {
                for (int i = ctotal; i <= cnuevo; i++)
                {
                    grd.Columnas[i].Format = "N1";
                } 
            }

        }

        private void frmVencimientos_Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void Cargar()
        { 
        
        }

        private void Fecha_Cambio_Seleccion(object sender, EventArgs e)
        {

        }

        private void Proveedores_Cambio_Seleccion(object sender, EventArgs e)
        {

        }

        private void chConSaldo_CheckedChanged(object sender, EventArgs e)
        {

        }

        //string armarCadena()
        //{
        //    //string s = "";
        //    //string f = "";
        //    //if (chFecha.Checked == true) { f = cFecha.Cadena(); }
        //    //if (chConSaldo.Checked == true) { s = "Saldo<-10"; }
        //    //Herramientas.Herramientas h = new Herramientas.Herramientas();
        //    //s = h.Unir(s, f);
        //    //f = h.Codigos_Seleccionados(lst_Cons, "Id_Consignatarios IN ({0})");
        //    //s = h.Unir(s, f);
        //    //return s;
        //}

    }
}
