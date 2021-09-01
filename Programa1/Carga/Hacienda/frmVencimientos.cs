namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Data;
    public partial class frmVencimientos : Form
    {
        public Saldos_Consignatarios saldos = new Saldos_Consignatarios();

        C1.Win.C1FlexGrid.CellStyle estP1Azul;
        C1.Win.C1FlexGrid.CellStyle estP1Rojo;

        C1.Win.C1FlexGrid.CellStyle estP2Azul;
        C1.Win.C1FlexGrid.CellStyle estP2Rojo;


        #region Columnas P1
        const int cID = 0;
        const int cKilos = 9;
        const int cCosto = 10;
        const int cTotal = 11;
        const int cPago = 12;
        const int cDif = 13;
        const int cSaldo = 14;
        const int cEstado = 15;
        const int cIDMat = 16;
        const int cMatricula = 17;
        #endregion

        #region Columnas P2
        //Id_Agregados_Frigo, Fecha, Plazo, NBoleta, Nombre, Descripcion, Importe, Pagos, (Pagos-Importe) Dif, Saldo, Estado, ID_Matr, Matricula
        const int aID = 0;
        const int aImporte = 6;
        const int aPago = 7;
        const int aDif = 8;
        const int aSaldo = 9;
        const int aEstado = 10;
        const int aIDMat = 11;
        const int aMatricula = 12;
        #endregion

        public frmVencimientos()
        {
            InitializeComponent();

            grd.TeclasManejadas = new int[] { 32 };
            grdAgr.TeclasManejadas = new int[] { 32 };

            estP1Azul = grd.Styles.Add("");
            estP1Rojo = grd.Styles.Add("");
            estP1Azul.BackColor = Color.LightCyan;
            estP1Rojo.BackColor = Color.LightCoral;

            estP2Azul = grd.Styles.Add("");
            estP2Rojo = grd.Styles.Add("");
            estP2Azul.BackColor = Color.LightCyan;
            estP2Rojo.BackColor = Color.LightCoral;

            Cargar();
        }
        public void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            Compras_P1();
            Compras_P2();
            this.Cursor = Cursors.Default;
        }

        private void Compras_P1()
        {
            grd.MostrarDatos(saldos.Vencimientos(), true, cDif);


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
                grd.set_ColorLetraCelda(i, cDif, (Convert.ToDouble(grd.get_Texto(i, cDif)) < -1) ? Color.Red : (Convert.ToDouble(grd.get_Texto(i, cSaldo)) > 1) ? Color.Blue : Color.Black);
                grd.set_ColorLetraCelda(i, cSaldo, (Convert.ToDouble(grd.get_Texto(i, cSaldo)) < -1) ? Color.Red : (Convert.ToDouble(grd.get_Texto(i, cSaldo)) > 1) ? Color.Blue : Color.Black);
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
            grd.Columnas[cTotal].Style.Format = "N1";
            grd.Columnas[cPago].Style.Format = "N1";
            grd.Columnas[cDif].Style.Format = "N1";
            grd.Columnas[cSaldo].Style.Format = "N1";

            grd.AutosizeAll();
            grd.set_ColW(cID, 0);
            grd.set_ColW(cTotal, 80);
            grd.set_ColW(cPago, 80);
            grd.set_ColW(cDif, 90);
            grd.set_ColW(cSaldo, 0);
            grd.set_ColW(cEstado, 0);
            grd.set_ColW(cIDMat, 0);
            grd.set_ColW(cMatricula, 30);

            grd.ActivarCelda(1, 0);
        }
        private void Compras_P2()
        {
            grdAgr.MostrarDatos(saldos.Vencimientos_Agr(), true, aDif);


            double valor = 0;
            for (int i = 1; i <= grdAgr.Rows - 1; i++)
            {
                if (valor == Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)))
                {
                    grdAgr.set_Texto(i, aSaldo, 0);
                }
                else
                {
                    valor = Convert.ToDouble(grdAgr.get_Texto(i, aSaldo));
                }
                grdAgr.set_ColorLetraCelda(i, aDif, (Convert.ToDouble(grdAgr.get_Texto(i, aDif)) < -1) ? Color.Red : (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) > 1) ? Color.Blue : Color.Black);
                grdAgr.set_ColorLetraCelda(i, aSaldo, (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) < -1) ? Color.Red : (Convert.ToDouble(grdAgr.get_Texto(i, aSaldo)) > 1) ? Color.Blue : Color.Black);
                if (Convert.ToInt16(grdAgr.get_Texto(i, aEstado)) == 1)
                {
                    grdAgr.Filas[i].Style = estP2Azul;
                }
                else
                {
                    if (Convert.ToInt16(grdAgr.get_Texto(i, aEstado)) == 2)
                    {
                        grdAgr.Filas[i].Style = estP2Rojo;
                    }
                }
            }

            grdAgr.Columnas[aImporte].Style.Format = "N1";
            grdAgr.Columnas[aPago].Style.Format = "N1";
            grdAgr.Columnas[aDif].Style.Format = "N1";
            grdAgr.Columnas[aSaldo].Style.Format = "N1";

            grdAgr.AutosizeAll();
            grdAgr.set_ColW(aID, 0);
            grdAgr.set_ColW(aImporte, 80);
            grdAgr.set_ColW(aPago, 80);
            grdAgr.set_ColW(aDif, 90);
            grdAgr.set_ColW(aSaldo, 0);
            grdAgr.set_ColW(aEstado, 0);
            grdAgr.set_ColW(aIDMat, 0);
            grdAgr.set_ColW(aMatricula, 30);

            grdAgr.ActivarCelda(1, grdAgr.Rows -1);
        }

        private void cmdActualizar_Click(object sender, System.EventArgs e)
        {
            Cargar();
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                int f = grd.Row;
                if (Convert.ToInt16(grd.get_Texto(f, cEstado)) == 0)
                {
                    grd.set_Texto(f, cEstado, 1);
                    grd.Filas[f].Style = estP1Azul;                    
                }
                else
                {
                    if (Convert.ToInt16(grd.get_Texto(f, cEstado)) == 1)
                    {
                        grd.set_Texto(f, cEstado, 2);
                        grd.Filas[f].Style = estP1Rojo;
                    }
                    else
                    {
                        grd.set_Texto(f, cEstado, 0);
                        grd.Filas[f].Style = null;
                    }
                }
                saldos.Ejecutar_Comando($"UPDATE Hacienda_Compras SET Estado={grd.get_Texto(f, cEstado)} WHERE ID_CompraFrigo={grd.get_Texto(f, cID)}");
            }
        }

        private void grdAgr_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                int f = grdAgr.Row;
                if (Convert.ToInt16(grdAgr.get_Texto(f, aEstado)) == 0)
                {
                    grdAgr.set_Texto(f, aEstado, 1);
                    grdAgr.Filas[f].Style = estP2Azul;
                }
                else
                {
                    if (Convert.ToInt16(grdAgr.get_Texto(f, aEstado)) == 1)
                    {
                        grdAgr.set_Texto(f, aEstado, 2);
                        grdAgr.Filas[f].Style = estP2Rojo;
                    }
                    else
                    {
                        grdAgr.set_Texto(f, aEstado, 0);
                        grdAgr.Filas[f].Style = null;
                    }
                }
                saldos.Ejecutar_Comando($"UPDATE Hacienda_Agregados SET Estado={grdAgr.get_Texto(f, aEstado)} WHERE ID_Agregados_Frigo={grdAgr.get_Texto(f, aID)}");
            }
        }

        private void cmbnvaBoleta_Click(object sender, EventArgs e)
        {
            frmGenerarnvaBoleta fr = new frmGenerarnvaBoleta();
            fr.dt = saldos.Vencimientos();
            fr.Cargar();
            fr.ShowDialog();
            fr.Close();
        }
    }
}
