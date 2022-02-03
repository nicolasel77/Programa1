namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public partial class frmPagar_Hacienda : Form
    {
        public Saldos_Consignatarios saldos = new Saldos_Consignatarios();
        public Cheques ch = new Cheques();
        public bool Aceptado = false;

        const int cID = 0;
        const int cNB = 5;
        const int cCab = 6;
        const int cDescripcion = 7;
        const int cKilos = 8;
        const int cCosto = 9;
        const int cTotal = 10;
        const int cPago = 11;
        const int cDif = 12;
        const int cSaldo = 13;
        const int cNuevo = 14;
        const int cEstado = 15;
        readonly C1.Win.C1FlexGrid.CellStyle estP1Azul;
        readonly C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        //Id, Fecha, Plazo, Venc, Dias, NBoleta, Cabezas Cab, Descripcion Descr, Kilos, Costo, Total, Pago, Dif, Saldo, Nuevo
        public frmPagar_Hacienda()
        {
            InitializeComponent();
            estP1Azul = grd.Styles.Add("");
            estP1Rojo = grd.Styles.Add("");
            estP1Azul.BackColor = Color.LightCyan;
            estP1Rojo.BackColor = Color.LightCoral;
        }
        public void Cargar()
        {
            lblConsignatario.Text = saldos.gastos.Desc_SubTipo;

            grd.TeclasManejadas = new int[] { 13, 43 };

            DataTable dt = saldos.Datos();
            //dt.Columns.Add("Sel", typeof(Button));

            grd.MostrarDatos(dt, true, false);
            
            double valor = 0;
            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                if (valor == Convert.ToDouble(grd.get_Texto(i, cSaldo)))
                {
                    grd.set_Texto(i, cSaldo, 0);
                }
                else
                {
                    valor = Convert.ToDouble(grd.get_Texto(i, cSaldo));
                }
                grd.set_ColorLetraCelda(i, cDif, (Convert.ToDouble(grd.get_Texto(i, cDif)) < -1) ? Color.Red : Color.Blue);
                grd.set_ColorLetraCelda(i, cSaldo, (Convert.ToDouble(grd.get_Texto(i, cSaldo)) < -1) ? Color.Red : Color.Blue);

                if (Convert.ToInt16(grd.get_Texto(i, cEstado)) == 1)
                {
                    grd.Filas[i].Style = estP1Azul;
                }
                else
                {
                    if (Convert.ToInt16(grd.get_Texto(i, cEstado)) == 2)
                    {
                        grd.Filas[i].Style = estP1Rojo;
                    }
                }

            }

            grd.Columnas[cKilos].Style.Format = "N1";
            grd.Columnas[cCosto].Style.Format = "N1";
            grd.Columnas[cTotal].Style.Format = "N2";
            grd.Columnas[cPago].Style.Format = "N2";
            grd.Columnas[cDif].Style.Format = "N2";
            grd.Columnas[cSaldo].Style.Format = "N2";
            grd.Columnas[cNuevo].Style.Format = "N2";

            grd.AutosizeAll();
            grd.set_ColW(cID, 0);
            grd.set_ColW(cTotal, 80);
            grd.set_ColW(cPago, 80);
            grd.set_ColW(cDif, 90);
            grd.set_ColW(cSaldo, 0);
            grd.set_ColW(cNuevo, 90);
            grd.set_ColW(cEstado, 0);

            grd.ActivarCelda(grd.Rows - 1, cNuevo);
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c == cNuevo)
            {
                if (Convert.ToInt16(grd.get_Texto(f, cEstado)) == 1)
                {
                    double dife = Convert.ToDouble(grd.get_Texto(f, cDif));
                    double saldo = Convert.ToDouble(grd.get_Texto(f, cSaldo));
                    double pago = (double)a;
                    if (saldos.gastos.caja.EsCheque == true)
                    {
                        //Seleccionar el cheque                    
                        ch.Seleccionar_Cheques();
                        pago = ch.cheques_seleccionados.Sum(item => item.Importe);
                        grd.Focus();
                    }

                    grd.set_Texto(f, cNuevo, pago);
                    grd.set_Texto(f, cDif, dife + pago);
                    grd.set_Texto(f, cSaldo, saldo + pago);
                    if (f > 1) { grd.ActivarCelda(f - 1, cNuevo); }
                    lblTotal.Text = $"Pagos: {grd.SumarCol(cNuevo, false):C1}";
                }
            }
        }

        private void grd_KeyPress(object sender, short e)
        {
            //  +
            if (e == 43)
            {
                int r = grd.Row;
                if (Convert.ToInt16(grd.get_Texto(r, cEstado)) == 1)
                {
                    double saldo = Convert.ToDouble(grd.get_Texto(r, cSaldo));
                    double pago = 0;
                    if (saldos.gastos.caja.EsCheque == true)
                    {
                        //Seleccionar el cheque                    
                        ch.Seleccionar_Cheques();
                        pago = ch.cheques_seleccionados.Sum(item => item.Importe);
                        grd.Focus();
                    }
                    else
                    {
                        pago = Convert.ToDouble(grd.get_Texto(r, cDif)) * -1;
                    }
                    grd.set_Texto(r, cNuevo, pago);
                    grd.set_Texto(r, cDif, 0);
                    grd.set_Texto(r, cSaldo, saldo + pago);
                    if (r > 1) { grd.ActivarCelda(r - 1, cNuevo); }
                    lblTotal.Text = $"Pagos: {grd.SumarCol(cNuevo, false):C1}";
                }
            }
            else
            {
                if (e == 13)
                {
                    Aceptarr();
                    this.Hide();
                }
            }
        }

        private void cmdAceptar_Click(object sender, System.EventArgs e)
        {
            Aceptarr();
            this.Hide();
        }

        private void Aceptarr()
        {
            if (saldos.gastos.Fecha < Convert.ToDateTime("1/1/2020"))
            {
                MessageBox.Show("error");
            }
            Cursor = Cursors.WaitCursor;
            Compra_Hacienda compraHacienda = new Compra_Hacienda();
            compraHacienda.Consignatario.ID = saldos.gastos.Id_SubTipoGastos;

            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                double n = Convert.ToDouble(grd.get_Texto(i, cNuevo));

                if (n != 0)
                {
                    int idD = Convert.ToInt32(grd.get_Texto(i, cID));
                    string t = Convert.ToDouble(grd.get_Texto(i, cDif)) == 0 ? "Total" : "Parcial";
                    string s = string.Format("{0}: {1} {2}  - {3}", grd.get_Texto(i, cNB), grd.get_Texto(i, cCab), grd.get_Texto(i, cDescripcion), t);

                    saldos.gastos.Id_DetalleGastos = idD;
                    saldos.gastos.Descripcion = s;

                    if (saldos.gastos.caja.EsCheque == false)
                    {
                        // Esta línea es porque queda en memoria
                        saldos.gastos.Cheque = 0;

                        saldos.gastos.Importe = n;
                        saldos.gastos.Agregar();
                    }
                    else
                    {
                        foreach (Cheques cheque in ch.cheques_seleccionados)
                        {
                            saldos.gastos.Cheque = cheque.Numero;
                            saldos.gastos.Importe = cheque.Importe;
                            saldos.gastos.Agregar();
                        }
                    }
                    //compraHacienda.NBoleta.ID = Convert.ToInt32(grd.get_Texto(i, cNB));
                    compraHacienda.ID = idD;
                    compraHacienda.Saldo = Convert.ToDouble(grd.get_Texto(i, cDif));
                    compraHacienda.Actualizar_Saldo();
                }
            }
            Aceptado = true;
            Cursor = Cursors.Default;

        }

        private void cmdSalir_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void frmPagar_Hacienda_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }


    }
}
