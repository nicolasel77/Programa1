namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmComprasFaena : Form
    {
        readonly Hacienda hc = new Hacienda();
        //ID_CompraFrigo, Fecha, ID_Matr, Matricula, ID_Consignatarios, Nombre, Cabezas Cab, ID_Productos Prod, Nombre_Producto Descr, Kilos, Costo, Costo2, Sub_Total, IVA, Percepcion, Total, Plazo
        //  0               1       2         3             4             5           6             7                   8               9        10    11       12      13       14        15    16
        #region " Columnas "
        private const Byte c_Id = 0;
        private const Byte c_Fecha = 1;
        private const Byte c_Matricula = 2;
        private const Byte c_Consig = 4;
        private const Byte c_IdProd = 7;
        private const Byte c_Cab = 6;
        private const Byte c_Kilos = 9;
        private const Byte c_Costo = 10;
        private const Byte c_Costo2 = 11;
        private const Byte c_SubT = 12;
        private const Byte c_IVA = 13;
        private const Byte c_Perc = 14;
        private const Byte c_Total = 15;
        private const Byte c_Plazo = 16;

        private readonly Byte A_Id;
        private readonly Byte A_Fecha;
        private readonly Byte A_Consig;
        private readonly Byte A_Tipo;
        private readonly Byte A_Impporte;
        private readonly Byte A_Plazo;

        private readonly Byte F_Id;
        private readonly Byte F_Fecha;
        private readonly Byte F_Cat;
        private readonly Byte F_NRomaneo;
        private readonly Byte F_Tropa;
        private readonly Byte F_Prod;
        private readonly Byte F_Frigo;
        private readonly Byte F_Recu;
        private readonly Byte F_Kilos;
        #endregion
        public frmComprasFaena()
        {
            InitializeComponent();

            grdBoletas.MostrarDatos(hc.nBoletas.Datos_Vista("", $"TOP {nuTop.Value} *", "NBoleta DESC"), true, false);
            grdBoletas.AutosizeAll();

            grdBoletas.Columnas[grdBoletas.get_ColIndex("Costo")].Format = "N3";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Costo_Faena")].Format = "N3";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Costo_Final")].Format = "N3";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Kilos_Compra")].Format = "N0";
            grdBoletas.Columnas[grdBoletas.get_ColIndex("Kilos_Faena")].Format = "N0";

            grdCompras.MostrarDatos(hc.compra.Datos("NBoleta=0"), true, true);

            grdCompras.set_ColW(c_Id, 0);
            grdCompras.set_ColW(c_Fecha, 55);
            grdCompras.set_ColW(c_Matricula, 30);
            grdCompras.set_ColW(c_Matricula + 1, 30);
            grdCompras.set_ColW(c_Consig, 40);
            grdCompras.set_ColW(c_Consig + 1, 100);
            grdCompras.set_ColW(c_IdProd, 40);
            grdCompras.set_ColW(c_IdProd + 1, 60);
            grdCompras.set_ColW(c_Cab, 30);
            grdCompras.set_ColW(c_Kilos, 80);
            grdCompras.set_ColW(c_Costo, 60);
            grdCompras.set_ColW(c_Costo2, 60);
            grdCompras.set_ColW(c_SubT, 100);
            grdCompras.set_ColW(c_IVA, 100);
            grdCompras.set_ColW(c_Perc, 100);
            grdCompras.set_ColW(c_Total, 100);
            grdCompras.set_ColW(c_Plazo, 40);

            grdCompras.Columnas[c_Kilos].Format = "N2";
            grdCompras.Columnas[c_Costo].Format = "C2";
            grdCompras.Columnas[c_Costo2].Format = "C2";
            grdCompras.Columnas[c_SubT].Format = "C2";
            grdCompras.Columnas[c_IVA].Format = "C2";
            grdCompras.Columnas[c_Perc].Format = "C2";
            grdCompras.Columnas[c_Total].Format = "C2";

            grdCompras.Filas[0].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

            grdAgregados.MostrarDatos(hc.Agregados.Datos("NBoleta=0"), true, true);

            A_Id = Convert.ToByte(grdAgregados.get_ColIndex("Id"));
            A_Fecha = Convert.ToByte(grdAgregados.get_ColIndex("Fecha"));
            A_Consig = Convert.ToByte(grdAgregados.get_ColIndex("Id_Consignatarios"));
            A_Tipo = Convert.ToByte(grdAgregados.get_ColIndex("Id_TipoAgregados"));
            A_Impporte = Convert.ToByte(grdAgregados.get_ColIndex("Importe"));
            A_Plazo = Convert.ToByte(grdAgregados.get_ColIndex("Plazo"));

            grdAgregados.set_ColW(A_Id, 0);
            grdAgregados.set_ColW(A_Fecha, 55);
            grdAgregados.set_ColW(A_Consig, 40);
            grdAgregados.set_ColW(A_Consig + 1, 100);
            grdAgregados.set_ColW(A_Tipo, 40);
            grdAgregados.set_ColW(A_Tipo + 1, 100);
            grdAgregados.set_ColW(A_Impporte, 100);
            grdAgregados.set_ColW(A_Plazo, 40);

            grdAgregados.Columnas[A_Impporte].Format = "C2";


            grdFaena.MostrarDatos(hc.Faena.Datos_Vista("NBoleta=0"), true, true);

            F_Id = Convert.ToByte(grdFaena.get_ColIndex("Id"));
            F_Fecha = Convert.ToByte(grdFaena.get_ColIndex("Fecha"));
            F_Cat = Convert.ToByte(grdFaena.get_ColIndex("Id_Categorias"));
            F_NRomaneo = Convert.ToByte(grdFaena.get_ColIndex("NRomaneo"));
            F_Tropa = Convert.ToByte(grdFaena.get_ColIndex("Tropa"));
            F_Prod = Convert.ToByte(grdFaena.get_ColIndex("Id_Productos"));
            F_Frigo = Convert.ToByte(grdFaena.get_ColIndex("Id_Frigorificos"));
            F_Recu = Convert.ToByte(grdFaena.get_ColIndex("Recupero"));
            F_Kilos = Convert.ToByte(grdFaena.get_ColIndex("Kilos"));

            grdFaena.set_Texto(0, F_Prod, "Prod");
            grdFaena.set_Texto(0, F_Prod + 1, "Desc");

            grdFaena.set_ColW(F_Id, 0);
            grdFaena.set_ColW(F_Fecha, 60);
            grdFaena.set_ColW(F_Cat, 40);
            grdFaena.set_ColW(F_Cat + 1, 50);
            grdFaena.set_ColW(F_NRomaneo, 70);
            grdFaena.set_ColW(F_Tropa, 60);
            grdFaena.set_ColW(F_Prod, 40);
            grdFaena.set_ColW(F_Prod + 1, 50);
            grdFaena.set_ColW(F_Frigo, 40);
            grdFaena.set_ColW(F_Frigo + 1, 50);
            grdFaena.set_ColW(F_Recu, 50);
            grdFaena.set_ColW(F_Kilos, 80);

            grdFaena.Columnas[F_Kilos].Format = "N2";
            grdFaena.Columnas[F_NRomaneo].Format = "N0";
            grdFaena.Columnas[F_Recu].Format = "C2";
        }

        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            System.Media.SystemSounds.Beep.Play();
        }

        private void GrdBoletas_CambioFila(short Fila)
        {
            this.Cursor = Cursors.WaitCursor;

            hc.nBoletas.ID = Convert.ToInt32(grdBoletas.get_Texto(Fila, 0));

            Cargar_Boleta();

            this.Cursor = Cursors.Default;

        }

        private void Cargar_Boleta()
        {
            grdCompras.MostrarDatos(hc.compra.Datos("NBoleta=" + hc.nBoletas.ID), false);
            grdCompras.Filas[0].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

            grdAgregados.MostrarDatos(hc.Agregados.Datos("NBoleta=" + hc.nBoletas.ID), false);

            hc.Faena.nBoleta = hc.nBoletas;
            grdFaena.MostrarDatos(hc.Faena.Datos_Vista("NBoleta=" + hc.nBoletas.ID), false);
            grdFaena.AutosizeAll();

            grdRomaneos.MostrarDatos(hc.Faena.Romaneos(), true, true);
            grdRomaneos.SumarCol(2, true);

            grdRomaneos.Columnas[0].Format = "N0";
            grdRomaneos.Columnas[2].Format = "N1";

            grdRomaneos.set_ColW(0, 80);
            grdRomaneos.set_ColW(1, 40);
            grdRomaneos.set_ColW(2, 70);

            Totales();
        }

        private void Totales()
        {
            double tSubTotal = grdCompras.SumarCol(c_SubT, false);
            double tIVA = grdCompras.SumarCol(c_IVA, false);
            double tPercepcion = grdCompras.SumarCol(c_Perc, false);
            double tCompra = grdCompras.SumarCol(c_Total, false);
            double kCompra = grdCompras.SumarCol(c_Kilos, false);
            double cabezas = grdCompras.SumarCol(c_Cab, false);
            lblCCant.Text = $"Cabezas: {cabezas:N0}";
            lblCKilos.Text = $"Kilos: {kCompra:N1}";
            lblSubTotal.Text = $"SubTotal: {tSubTotal:C1}";
            lblTPercepciones.Text = $"Percepciones: {tPercepcion:C1}";
            lblIVA.Text = $"IVA: {tIVA:C1}";
            lblCTotal.Text = $"Total: {tCompra:C1}";

            double tAgregados = grdAgregados.SumarCol(A_Impporte, false);
            lblTAgregados.Text = $"Agregados: {tAgregados:C1}";
            lblATotal.Text = $"Total: {tAgregados:C1}";

            tCompra = (tCompra + tAgregados);
            if (kCompra != 0)
            {
                lblCInt.Text = $"Integración: {tCompra / kCompra:C3}";
            }
            else
            {
                lblCInt.Text = "";
            }

            double tRecupero = 0;
            double kFaena = 0;
            double cFaena = 0;

            for (int i = 1; i < grdFaena.Rows - 1; i++)
            {
                tRecupero += Convert.ToSingle(grdFaena.get_Texto(i, F_Recu)) * Convert.ToSingle(grdFaena.get_Texto(i, F_Kilos));
                kFaena += Convert.ToSingle(grdFaena.get_Texto(i, F_Kilos));
                cFaena++;
            }
            lblCant.Text = $"Cantidad: {cFaena:N0}";
            lblKilos.Text = $"Kilos: {kFaena:N2}";
            lblTotal.Text = $"Recupero: {tRecupero:C2}";
            lblCostoFaena.Text = $"Costo Faena: {tCompra / kFaena:C3}";
            lblCostoFinal.Text = $"Costo Carne: {(tCompra / kFaena) - (tRecupero / kFaena):C3}";

            if (kCompra != 0)
            {
                lblRendimiento.Text = $"Rendimiento: {(kFaena / kCompra * 100):N2}";
            }
            else
            {
                lblRendimiento.Text = "";
            }
            if (cabezas != 0 & cFaena != (cabezas * 2))
            {
                lblCant.BackColor = Color.Red;
            }
            else
            {
                lblCant.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void grdCompras_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case c_Matricula:
                    hc.compra.Matricula.ID = Convert.ToInt32(a);
                    if (hc.compra.Matricula.Existe() == true)
                    {
                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c + 1, hc.compra.Matricula.Nombre);
                        grdCompras.ActivarCelda(f, c_Consig);
                        if (hc.compra.ID > 0) { hc.compra.Actualizar("Matricula", a); }
                    }
                    break;
                case c_Consig:
                    hc.compra.Consignatario.ID = Convert.ToInt32(a);
                    if (hc.compra.Consignatario.Existe() == true)
                    {
                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c + 1, hc.compra.Consignatario.Nombre);
                        grdCompras.ActivarCelda(f, c_Cab);
                        if (hc.compra.ID > 0) { hc.compra.Actualizar("Id_Consignatarios", a); }
                    }
                    break;
                case c_Cab:
                    hc.compra.Cabezas = Convert.ToInt32(a);
                    grdCompras.set_Texto(f, c, a);
                    grdCompras.ActivarCelda(f, c_IdProd);
                    if (hc.compra.ID > 0) { hc.compra.Actualizar("Cabezas", a); }

                    break;
                case c_IdProd:
                    hc.compra.Producto.ID = Convert.ToInt32(a);
                    if (hc.compra.Producto.Existe() == true)
                    {
                        grdCompras.set_Texto(f, c, a);
                        grdCompras.set_Texto(f, c + 1, hc.compra.Producto.Nombre);
                        grdCompras.ActivarCelda(f, c_Kilos);
                        if (hc.compra.ID > 0) { hc.compra.Actualizar("Id_Productos", a); }
                    }
                    break;
                case c_Kilos:
                    hc.compra.Kilos = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);
                    grdCompras.ActivarCelda(f, c_Costo);

                    Total_Linea(f);

                    if (hc.compra.ID > 0) { hc.compra.Actualizar("Kilos", a); }

                    break;

                case c_Costo:
                    hc.compra.Costo = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);
                    grdCompras.ActivarCelda(f, c_Costo2);

                    Total_Linea(f);

                    if (hc.compra.ID > 0) { hc.compra.Actualizar("Costo", a); }

                    break;
                case c_Costo2:
                    hc.compra.Costo2 = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);

                    Total_Linea(f);

                    if (hc.compra.ID > 0)
                    {
                        hc.compra.Actualizar("Costo2", a);
                    }
                    else
                    {
                        hc.compra.Agregar();
                        grdCompras.set_Texto(f, c_Id, hc.compra.ID);
                    }

                    grdCompras.ActivarCelda(f + 1, c_Cab);
                    break;

                case c_IVA:
                    hc.compra.IVA = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);

                    Total_Linea(f);

                    if (hc.compra.ID > 0) { hc.compra.Actualizar("IVA", a); }

                    grdCompras.ActivarCelda(f + 1, c_IVA);

                    break;

                case c_Perc:
                    hc.compra.Percepcion = Convert.ToSingle(a);
                    grdCompras.set_Texto(f, c, a);

                    Total_Linea(f);

                    if (hc.compra.ID > 0) { hc.compra.Actualizar("Percepcion", a); }

                    grdCompras.ActivarCelda(f + 1, c_Perc);

                    break;

                case c_Plazo:
                    hc.compra.Plazo = Convert.ToByte(a);
                    grdCompras.set_Texto(f, c, a);

                    if (hc.compra.ID > 0) { hc.compra.Actualizar("Plazo", a); }

                    grdCompras.ActivarCelda(f + 1, c_Plazo);

                    break;
            }
        }

        private void Total_Linea(short f)
        {
            float kilos = Convert.ToSingle(grdCompras.get_Texto(f, c_Kilos));
            float costo = Convert.ToSingle(grdCompras.get_Texto(f, c_Costo));
            float costo2 = Convert.ToSingle(grdCompras.get_Texto(f, c_Costo2));
            double iva = (kilos * costo) * 10.5 / 100;
            double percepcion = Convert.ToSingle(grdCompras.get_Texto(f, c_Perc));

            grdCompras.set_Texto(f, c_SubT, kilos * costo);
            grdCompras.set_Texto(f, c_Total, (kilos * costo) + iva + percepcion);

            hc.compra.Actualizar("Kilos", kilos);
            hc.compra.Actualizar("Costo", costo);
            hc.compra.Actualizar("Costo2", costo2);
            hc.compra.Actualizar("Iva", iva);
            hc.compra.Actualizar("Percepcion", percepcion);

            hc.compra.Calcular_Saldo();

            MessageBox.Show("Falta el calculo de Pago en Mano");
        }

        private void grdCompras_CambioFila(short Fila)
        {
            hc.compra.ID = Convert.ToInt32(grdCompras.get_Texto(Fila, c_Id));
            hc.compra.Cargar_Fila(hc.compra.ID);
        }

        private void cmdActualizar_Listado_Click(object sender, EventArgs e)
        {
            grdBoletas.MostrarDatos(hc.nBoletas.Datos_Vista("", $"TOP {nuTop.Value} *", "NBoleta DESC"), false, false);
        }

        private void lblSubTotal_Click(object sender, EventArgs e)
        {

        }

        private void txtNBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                int nb = 0;
                if (int.TryParse(txtNBoleta.Text, out nb) == true)
                {
                    hc.nBoletas.ID = Convert.ToInt32(txtNBoleta.Text);
                    Cargar_Boleta();
                }
            }
        }
    }
}
