namespace Programa1.Carga.TM
{
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmComprasHaciendaTM : Form
    {
        private clsTM tM = new clsTM();
        private int id_Factura = 0;
        
        clsTM._Detalle_Hacienda dth = new clsTM._Detalle_Hacienda();
        clsTM._Agregados_Hacienda agh = new clsTM._Agregados_Hacienda();

        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmComprasHaciendaTM()
        {
            InitializeComponent();
            Cargar_Facturas();

            DataTable dt = new DataTable();
            dt = tM.Consignatarios();
            h.Llenar_List(lstConsignatarios, dt);

            grdDetalle.TeclasManejadas = new int[] { 46 };
            grdAgregados.TeclasManejadas = new int[] { 46 };
        }

        private void Cargar_Facturas()
        {
            DataTable dt = new DataTable();
            int idconsig = 0;

            if (lstConsignatarios.SelectedItems.Count == 1)
            {
                idconsig = h.Codigo_Seleccionado(lstConsignatarios.Text);
                dt = tM.Resumen_ComprasHacienda(idconsig);
            }
            else
            {
                if (lstConsignatarios.SelectedItems.Count > 1)
                {
                    string consignatarios = h.Codigos_Seleccionados(lstConsignatarios);
                    dt = tM.Resumen_ComprasHacienda(consignatarios);
                }
                else
                {
                    dt = tM.Resumen_ComprasHacienda();
                }
            }
            grdDetalle.Rows = 0;
            grdAgregados.Rows = 0;

            grdFacturas.MostrarDatos(dt, true, false);

            grdFacturas.Columnas["Id_Consignatarios"].Visible = false;
            grdFacturas.Columnas["Id"].Visible = false;

            grdFacturas.Columnas["Total_Cab"].Style.Format = "N";
            grdFacturas.Columnas["Total_Kilos"].Style.Format = "N";
            grdFacturas.Columnas["SubTotal"].Style.Format = "N";
            grdFacturas.Columnas["Agregados"].Style.Format = "N";
            grdFacturas.Columnas["IVA"].Style.Format = "N";
            grdFacturas.Columnas["Total"].Style.Format = "N";
            grdFacturas.Columnas["Pagos"].Style.Format = "N";
            grdFacturas.Columnas["Saldo"].Style.Format = "N";

            grdFacturas.AutosizeAll();
        }

        private void grdFacturas_CambioFila(short Fila)
        {
            if (Fila > 0)
            {
                grdDetalle.Rows = 1;
                grdDetalle.Rows = 2;
                grdAgregados.Rows = 1;
                grdAgregados.Rows = 2;

                int id = Convert.ToInt32(grdFacturas.get_Texto(Fila, 0));
                if (id > 0)
                {
                    id_Factura = id;
                    DataTable dt = new DataTable();
                    dt = tM.Detalles_Factura(id);
                    grdDetalle.MostrarDatos(dt, true, true);

                    grdDetalle.set_Texto(0, 2, "Prod");

                    grdDetalle.Columnas["Id"].Visible = false;
                    grdDetalle.Columnas["Id_Factura"].Visible = false;

                    grdDetalle.Columnas["Kilos"].Style.Format = "N";
                    grdDetalle.Columnas["Precio"].Style.Format = "N";
                    grdDetalle.Columnas["Total"].Style.Format = "N";

                    grdDetalle.AutosizeAll();
                    grdDetalle.set_ColW(5, 80);
                    grdDetalle.set_ColW(6, 80);
                    grdDetalle.set_ColW(7, 80);

                    dt = tM.Agregados_Factura(id);

                    grdAgregados.MostrarDatos(dt, true, true);

                    grdAgregados.set_Texto(0, 2, "Tipo");

                    grdAgregados.Columnas["Id"].Visible = false;
                    grdAgregados.Columnas["Id_Factura"].Visible = false;

                    grdAgregados.Columnas["Importe"].Style.Format = "N";

                    grdAgregados.AutosizeAll();
                    
                    grdAgregados.set_ColW(2, 80);
                    grdAgregados.set_ColW(3, 100);
                    grdAgregados.set_ColW(4, 100);


                    dt = tM.Pagos_Factura(id);
                    grdPagos.MostrarDatos(dt, true, false);
                    grdPagos.Columnas["Importe"].Style.Format = "N";
                    grdPagos.AutosizeAll();

                    Cuentas();
                }
            }
        }

        private void Cuentas()
        {
            float c = (float)grdDetalle.SumarCol(grdDetalle.get_ColIndex("Cabezas"), false);
            float k = (float)grdDetalle.SumarCol(grdDetalle.get_ColIndex("Kilos"), false);
            float t = (float)grdDetalle.SumarCol(grdDetalle.get_ColIndex("Total"), false);

            lblTDetalle.Text = $"Cabezas: {c}  Kilos: {k:N0}  Total: {t:C1}   ";
            t = 0;
            k = 0;
            for (int i = 1; i < grdAgregados.Rows; i++)
            {
                if ((bool)grdAgregados.get_Texto(i, grdAgregados.get_ColIndex("Gravado")) != true)
                {
                    t += Convert.ToSingle(grdAgregados.get_Texto(i, grdAgregados.get_ColIndex("Importe")));
                }
                else
                {
                    k += Convert.ToSingle(grdAgregados.get_Texto(i, grdAgregados.get_ColIndex("Importe")));
                }
            }

            lblTAgregados.Text = $"Gravado: {k:C1}  No Gravado: {t:C1} Total: {(t + k):C1}   ";

            t = (float)grdPagos.SumarCol(grdPagos.get_ColIndex("Importe"), false);

            lblTPagos.Text = $"Total: {t:C1}   ";
        }

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            Cargar_Facturas();
        }

        private void cmdNueva_Click(object sender, EventArgs e)
        {
            frmNuevaCompraHacienda fr = new frmNuevaCompraHacienda();
            fr.ShowDialog();
            if (fr.fc.ID > 0)
            {
                Cargar_Facturas();
                grdFacturas.ActivarCelda(1, grdFacturas.get_ColIndex("Fecha"));
            }
        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lstConsignatarios.Items.Clear();
            DataTable dt = new DataTable();
            dt = tM.Consignatarios(txtBuscar.Text);
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstConsignatarios, dt);
        }

        private void lstConsignatarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Facturas();
        }

        
        private void grdDetalle_Editado(short f, short c, object a)
        {
            if (id_Factura != 0)
            {
                dth.ID = Convert.ToInt32(grdDetalle.get_Texto(f, 0));
                dth.Id_Factura = id_Factura;
                dth.Id_Produtos = Convert.ToInt32(grdDetalle.get_Texto(f, 2));
                dth.Cabezas = Convert.ToInt32(grdDetalle.get_Texto(f, 4));
                dth.Kilos = Convert.ToSingle(grdDetalle.get_Texto(f, 5));
                dth.Precio = Convert.ToSingle(grdDetalle.get_Texto(f, 6));

                if (c == 2)
                {
                    // Producto
                    string pr = tM.Nombre_Producto((int)a);
                    if (pr.Length > 0)
                    {
                        grdDetalle.set_Texto(f, c, a);
                        grdDetalle.set_Texto(f, c + 1, pr);
                        grdDetalle.ActivarCelda(f, c + 2);

                        dth.Id_Produtos = (int)a;
                    }
                    else
                    {
                        grdDetalle.ErrorEnTxt();
                        return;
                    }
                    if (dth.ID > 0) { tM.Guardar_DetalleFactura(dth); }
                    return;
                }
                if (c == 4)
                {
                    // Cabezas
                    grdDetalle.set_Texto(f, c, a);
                    grdDetalle.ActivarCelda(f, c + 1);

                    dth.Cabezas = (int)a;
                    if (dth.ID > 0) { tM.Guardar_DetalleFactura(dth); }
                    Cuentas();
                    return;
                }

                if (c == 5)
                {
                    // Kilos
                    grdDetalle.set_Texto(f, c, a);

                    dth.Kilos = Convert.ToSingle(a);
                    grdDetalle.set_Texto(f, 8, dth.Kilos * dth.Precio);
                    grdDetalle.ActivarCelda(f, c + 1);

                    if (dth.ID > 0) { tM.Guardar_DetalleFactura(dth); }
                    Cuentas();
                    return;
                }

                if (c == 6)
                {
                    // Precio
                    grdDetalle.set_Texto(f, c, a);

                    dth.Precio = Convert.ToSingle(a);
                    grdDetalle.set_Texto(f, 7, Convert.ToSingle(dth.Kilos * dth.Precio));

                    tM.Guardar_DetalleFactura(dth);

                    if (grdDetalle.Row == grdDetalle.Rows - 1)
                    {
                        // Agregar
                        grdDetalle.AgregarFila();

                        dth.ID = tM.Ultimo_ID("Hacienda_Detalle");

                        grdDetalle.set_Texto(f, 0, dth.ID);
                        grdDetalle.set_Texto(f, 1, id_Factura);
                        grdDetalle.ActivarCelda(f + 1, 2);
                    }
                    else
                    {
                        grdDetalle.ActivarCelda(f + 1, c);
                    }
                    Cuentas();
                }
            }
        }

        private void grdDetalle_KeyUp(object sender, short e)
        {
            if (e == 46)
            {
                // Borrar
                int id = Convert.ToInt32(grdDetalle.get_Texto(grdDetalle.Row, 0));
                if (id != 0)
                {
                    tM.Borrar_DetalleHacienda(id);
                    grdDetalle.BorrarFila(grdDetalle.Row);
                    Cuentas();
                }
            }
        }

        private void grdAgregados_Editado(short f, short c, object a)
        {
            if (id_Factura != 0)
            {
                agh.ID = Convert.ToInt32(grdAgregados.get_Texto(f, 0));
                agh.Id_Factura = id_Factura;
                agh.Id_TipoAgregados = Convert.ToInt32(grdAgregados.get_Texto(f, 2));
                agh.Importe = Convert.ToSingle(grdAgregados.get_Texto(f, 4));

                if (c == 2)
                {
                    // Tipo
                    string ta = tM.Nombre_TipoAgregado((int)a);
                    if (ta.Length > 0)
                    {
                        bool gr = tM.Grava_TipoAgregado((int)a);
                        grdAgregados.set_Texto(f, c, a);
                        grdAgregados.set_Texto(f, c + 1, ta);
                        grdAgregados.set_Texto(f, c + 3, gr);
                        grdAgregados.ActivarCelda(f, c + 2);

                        agh.Id_TipoAgregados = (int)a;
                    }
                    else
                    {
                        grdAgregados.ErrorEnTxt();
                        return;
                    }
                    if (agh.ID > 0) { tM.Guardar_AgregadoFactura(agh); }
                    return;
                }                

                if (c == 4)
                {
                    // Importe
                    grdAgregados.set_Texto(f, c, a);

                    agh.Importe = Convert.ToSingle(a);

                    tM.Guardar_AgregadoFactura(agh);

                    if (grdAgregados.Row == grdAgregados.Rows - 1)
                    {
                        // Agregar
                        grdAgregados.AgregarFila();

                        agh.ID = tM.Ultimo_ID("Hacienda_Agregados");

                        grdAgregados.set_Texto(f, 0, agh.ID);
                        grdAgregados.set_Texto(f, 1, id_Factura);
                        grdAgregados.ActivarCelda(f + 1, 2);
                    }
                    else
                    {
                        grdAgregados.ActivarCelda(f + 1, c);
                    }
                    Cuentas();
                }
            }
        }
        private void grdAgregados_KeyUp(object sender, short e)
        {
            if (e == 46)
            {
                // Borrar
                int id = Convert.ToInt32(grdAgregados.get_Texto(grdAgregados.Row, 0));
                if (id != 0)
                {
                    tM.Borrar_AgregadoHacienda(id);
                    grdAgregados.BorrarFila(grdAgregados.Row);
                    Cuentas();
                }
            }
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if(id_Factura != 0)
            {
                // Mensaje de confirmación
                DialogResult dr = MessageBox.Show($"¿Confirma el borrado de la factura seleccionada?\n No se podrá deshacer la operación.", "Borrar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    tM.Borrar_Factura(id_Factura);
                    Cargar_Facturas();
                }
            }
        }

    }
}
