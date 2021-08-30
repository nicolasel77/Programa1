namespace Programa1.Carga.Hacienda
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Programa1.DB.Tesoreria;
    public partial class frmGenerarnvaBoleta : Form
    {
        public Generar_Boleta nvaBoleta = new Generar_Boleta();

        C1.Win.C1FlexGrid.CellStyle estP1Azul;
        C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        C1.Win.C1FlexGrid.CellStyle estP2Azul;
        C1.Win.C1FlexGrid.CellStyle estP2Rojo;


        #region Columnas Nueva grd
        const int cID = 0;
        const int cFecha = 1;
        const int cNombre = 2;
        const int cImporte = 3;
        #endregion

        #region Columnas grd Ori
        //Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula
        const int cid = 0;
        const int cCosto = 10;
        const int cTotal = 11;
        const int cPago = 12;
        const int cDif = 13;
        const int cSaldo = 14;
        const int cEstado = 15;
        const int cIDMat = 16;
        const int cMatricula = 17;
        #endregion

        public DataTable dt = null;


        public frmGenerarnvaBoleta()
        {
            InitializeComponent();
            grdOriginal.TeclasManejadas = new int[] { 32 };
            grdnvaBoleta.TeclasManejadas = new int[] { 32 };

            estP1Azul = grdOriginal.Styles.Add("");
            estP1Rojo = grdOriginal.Styles.Add("");
            estP1Azul.BackColor = Color.LightCyan;
            estP1Rojo.BackColor = Color.LightCoral;

            estP2Azul = grdOriginal.Styles.Add("");
            estP2Rojo = grdOriginal.Styles.Add("");
            estP2Azul.BackColor = Color.LightCyan;
            estP2Rojo.BackColor = Color.LightCoral;

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            Bancos bancos = new Bancos();
            h.Llenar_List(cbBancos, bancos.Datos());
        }
        public void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            dt.Columns.Add("Boleta", typeof(bool));
            grdOriginal.MostrarDatos(dt, true, false);

            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Importe", typeof(double));

            grdnvaBoleta.MostrarDatos(dt,true,false);
            grdnvaBoleta.AgregarFila();
            grdnvaBoleta.AgregarFila();
            grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1, cNombre, "Total:");
            grdnvaBoleta.AutosizeAll();
            //Compras_P2();
            this.Cursor = Cursors.Default;
        }

        private void grdOriginal_Editado(short f, short c, object a)
        {
            if (c == grdOriginal.get_ColIndex("Boleta"))
            {
                if (Convert.ToInt32(a) == 1)
                {
                    grdnvaBoleta.AgregarFila(null,1);
                    grdnvaBoleta.set_Texto(1, cID, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    grdnvaBoleta.set_Texto(1, cFecha, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Fecha")));
                    grdnvaBoleta.set_Texto(1, cNombre, grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Nombre")));
                    grdnvaBoleta.set_Texto(1, cImporte, Convert.ToDouble(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("Importe")))*-1);
                    grdnvaBoleta.set_Texto(1, cImporte, grdnvaBoleta.SumarCol("Importe"));
                }
                else
                {
                    int idOriginal = Convert.ToInt32(grdOriginal.get_Texto(f, grdOriginal.get_ColIndex("NBoleta")));
                    for (int i = 1; i == grdnvaBoleta.Rows-2; i++)
                    {
                        if (Convert.ToInt32(grdOriginal.get_Texto(i, 0)) == idOriginal)
                        { grdnvaBoleta.BorrarFila(i); }
                    }
                }

            }
            //if (c == grdOriginal.get_ColIndex("Boleta"))
            //{
            //    foreach (int a in grdnvaBoleta)
            //    {
            //        foreach(int nvac in grdnvaBoleta.Cols )
            //        grdnvaBoleta.set_Texto(grdnvaBoleta.Rows - 1,)
            //            }
            //}
        }

        private void grdnvaBoleta_Editado(short f, short c, object a)
        {
            grdnvaBoleta.set_Texto(f, c, a);
        }
    }
}
