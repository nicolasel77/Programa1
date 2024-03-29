﻿namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public partial class frmPagar_Agregados : Form
    {
        public Saldos_Consignatarios saldos = new Saldos_Consignatarios();
        public Gastos gastos;
        public Cheques ch = new Cheques();
        public bool Aceptado = false;

        const int cID = 0;
        const int cNB = 3;
        const int cDescripcion = 4;
        const int cImporte = 5;
        const int cPago = 6;
        const int cDif = 7;
        const int cSaldo = 8;
        const int cNuevo = 9;
        const int cEstado = 10;

        readonly C1.Win.C1FlexGrid.CellStyle estP1Azul;
        readonly C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        //Id, Fecha, Plazo, NBoleta, Descripcion, Importe, Pago, Dif, Saldo, Nuevo

        public frmPagar_Agregados()
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

            grd.MostrarDatos(saldos.Datos_Agr(), true, false);

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

            grd.Columnas[cImporte].Style.Format = "N2";
            grd.Columnas[cPago].Style.Format = "N2";
            grd.Columnas[cDif].Style.Format = "N2";
            grd.Columnas[cSaldo].Style.Format = "N2";
            grd.Columnas[cNuevo].Style.Format = "N2";

            grd.AutosizeAll();
            grd.set_ColW(cID, 0);
            grd.set_ColW(cImporte, 80);
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
                    if (gastos.caja.EsCheque == true)
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
                    if (gastos.caja.EsCheque == true)
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
                }
            }
            else
            {
                if (e == 13)
                {
                    Aceptarr();
                    Hide();
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
            Agregados_Hacienda agregadosHacienda = new Agregados_Hacienda();
            agregadosHacienda.Consignatario.ID = saldos.gastos.Id_SubTipoGastos;
            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                double n = Convert.ToDouble(grd.get_Texto(i, cNuevo));

                if (n != 0)
                {
                    int idD = Convert.ToInt32(grd.get_Texto(i, cID));
                    string t = Convert.ToDouble(grd.get_Texto(i, cDif)) == 0 ? "Total" : "Parcial";
                    string s = string.Format("{0}: {1}", grd.get_Texto(i, cNB), grd.get_Texto(i, cDescripcion), t);

                    saldos.gastos.Id_DetalleGastos = idD;
                    saldos.gastos.Fecha = gastos.Fecha;
                    saldos.gastos.Descripcion = s;

                    if (saldos.gastos.caja.EsCheque == false)
                    {
                        saldos.gastos.Importe = n;
                        saldos.gastos.Agregar();

                    }
                    else
                    {
                        foreach (Cheques c in ch.cheques_seleccionados)
                        {
                            saldos.gastos.Cheque = c.Numero;
                            saldos.gastos.Importe = c.Importe;
                            saldos.gastos.Agregar();
                        }
                    }
                    agregadosHacienda.Saldo = Convert.ToDouble(grd.get_Texto(i, cDif));
                    agregadosHacienda.ID = idD;
                    agregadosHacienda.Actualizar_Saldo();
                }
            }
            Aceptado = true;
            Cursor = Cursors.Default;

        }

        private void cmdSalir_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void frmPagar_Agregados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
    }
}
