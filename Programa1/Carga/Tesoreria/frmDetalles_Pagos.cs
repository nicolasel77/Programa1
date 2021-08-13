namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmDetalles_Pagos : Form
    {
        private Detalles_Pagos Detalles = new Detalles_Pagos();
        #region " Columnas "
        //private Byte c_Id;
        private Byte c_Fecha;
        private Byte c_IdSubTipo;
        private Byte c_Descripcion;
        private Byte c_Importe;
        private Byte c_Carga;
        #endregion
        public frmDetalles_Pagos()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdDetalles.TeclasManejadas = n;
            // c_Id = Convert.ToByte(grdDetalles.get_ColIndex("Id"));

            //El intercambio de columnas para estas teclas
            //grdDetalles.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);
            //grdDetalles.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

        }

        private void cargar(string filtro)
        {
            grdDetalles.MostrarDatos(Detalles.Datos(filtro), true,false);
            c_Fecha = Convert.ToByte(grdDetalles.get_ColIndex("Fecha"));
            c_IdSubTipo = Convert.ToByte(grdDetalles.get_ColIndex("ID_SubTipoEntrada"));
            c_Descripcion = Convert.ToByte(grdDetalles.get_ColIndex("Descripcion"));
            c_Importe = Convert.ToByte(grdDetalles.get_ColIndex("Importe"));
            c_Carga = Convert.ToByte(grdDetalles.get_ColIndex("Carga"));
            formato_Grilla();
            Totales();
        }

        private void formato_Grilla()
        {
            //grdDetalles.set_ColW(c_Id, 0);
            grdDetalles.set_ColW(c_Fecha, 80);
            grdDetalles.set_ColW(c_IdSubTipo, 30);
            grdDetalles.set_ColW(c_Descripcion, 150);
            grdDetalles.set_ColW(c_Importe, 100);
            grdDetalles.set_ColW(c_Carga, 80);

            grdDetalles.Columnas[c_Importe].Format = "C2";
            //grdDetalles.Columnas[c_Total].Format = "C2";
            grdDetalles.Columnas[c_IdSubTipo + 1].Style.ForeColor = Color.DimGray;

            grdDetalles.set_Texto(0, c_IdSubTipo, "Suc");
        }

        private void Totales()
        {
            grdDetalles.AgregarFila();
            double total = grdDetalles.SumarCol(c_Importe);
            lblTotal.Text = $"Total: {total:C1}";
        }

      
        private void Armar_Cadena()
        {
            string s = "";
            string suc = "";
            string f = "";
            string fc = "";
            if (chFecha.Checked == true) {  f = cFecha.Cadena(); }
            if (chFcarga.Checked == true) { fc = cFechaCarga.Cadena("Carga"); }
            if (cSuc.Valor_Actual > 0) { suc = cSuc.Cadena("ID_SubTipoEntrada"); }

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = f != "" ? f : (fc != "" ? fc:s);

            if (s != "")
            {
                if (fc != "" & fc != s) { s = h.Unir(s, fc); }
                if (suc != "") { s = h.Unir(s, suc); }
                cargar(s);
            }
            else
            {
                grdDetalles.Rows = 0;
            }
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            if (chFecha.Checked == true) { Armar_Cadena(); chFecha.Checked = true; }            
        }

        private void cFechaCarga_Cambio_Seleccion(object sender, EventArgs e)
        {
            Armar_Cadena();
        }

        private void cSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
             Armar_Cadena(); 
        }

        private void chFecha_CheckedChanged(object sender, EventArgs e)
        {
            Armar_Cadena();
        }
        private void chFcarga_CheckedChanged(object sender, EventArgs e)
        {
            Armar_Cadena();
        }

        private void cmdMostrar_Click(object sender, EventArgs e)
        {
            Armar_Cadena();
        }

        private void chFcarga_CheckedChanged_1(object sender, EventArgs e)
        {
            Armar_Cadena();
        }
    }
}
