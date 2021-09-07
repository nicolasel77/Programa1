namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCMVentas : Form
    {
        private List<int> Id;
        private readonly Ventas Ventas = new Ventas();
        private readonly Precios_Sucursales precios = new Precios_Sucursales();
        private readonly Precios_Proveedores preciosPr = new Precios_Proveedores();

        public frmCMVentas()
        {
            InitializeComponent();
        }

        public List<int> Ids
        {
            set
            {
                Id = value;
                Cargar();
            }

        }

        private void Cargar()
        {
            string s = string.Join(",", Id);
            DataTable dt = Ventas.Datos($" Id IN ({s})");
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);

            formato_Grilla();
            Totales();

            dt = Ventas.Proveedor.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProveedor.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Ventas.Sucursal.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSucursal.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Ventas.Producto.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProds.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Ventas.Camion.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbCamion.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Proveedores"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre_Proveedor"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Sucursales"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Compra"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Venta"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total_Compra"), 80);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total_Venta"), 80);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Compra")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Venta")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total_Compra")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total_Venta")].Format = "C2";

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Proveedores"), "Suc S");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Sucursales"), "Suc E");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");

            grdResultado.set_ColW(grdResultado.get_ColIndex("Id"), 0);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Fecha"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Proveedores"), 35);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre_Proveedor"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Sucursales"), 35);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Productos"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Descripcion"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Compra"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Venta"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Kilos"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total_Compra"), 80);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total_Venta"), 80);

            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Compra")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Venta")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total_Compra")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total_Venta")].Format = "C2";

            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Proveedores"), "Suc S");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Sucursales"), "Suc E");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total_Compra"), false);
            double te = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total_Venta"), false);
            double k = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Kilos"), false);
            int c = grdOriginal.Rows - 1;

            lblTotalO.Text = $"Registros: {c} Kilos: {k:N2} Total Compra: {t:C2} Total Venta: {te:C2}";

            t = 0;
            te = 0;
            k = 0;

            for (int i = 1; i <= grdResultado.Rows - 1; i++)
            {
                t += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total_Compra")));
                te += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total_Venta")));
                k += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Kilos")));
            }

            c = grdResultado.Rows - 1;

            if (c > 0)
            {
                lblTotalR.Text = $"Registros: {c} Kilos: {k:N2} Total Compra: {t:C2} Total Venta: {te:C2}";
            }
            else { lblTotalR.Text = ""; }
        }

        private void Resultado()
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Ventas.Cargar_Fila(i);

                precios.Sucursal = Ventas.Sucursal;
                precios.Producto = Ventas.Producto;
                preciosPr.Proveedor = Ventas.Proveedor;

                if (chFecha.Checked)
                {
                    Ventas.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = Ventas.Fecha;
                preciosPr.Fecha = Ventas.Fecha;

                if (chProveedor.Checked)
                {
                    if (cmbProveedor.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ventas.Proveedor.Id = h.Codigo_Seleccionado(cmbProveedor.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Proveedores"), Ventas.Proveedor.Id);
                        string s = cmbProveedor.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre_Proveedor"), s);
                    }
                }
                if (chSucursal.Checked)
                {
                    if (cmbSucursal.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ventas.Sucursal.ID = h.Codigo_Seleccionado(cmbSucursal.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Sucursales"), Ventas.Sucursal.ID);
                        string s = cmbSucursal.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre"), s);
                    }
                }
                precios.Sucursal.ID = Ventas.Sucursal.ID;

                if (chProd.Checked)
                {
                    if (cmbProds.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ventas.Producto.ID = h.Codigo_Seleccionado(cmbProds.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), Ventas.Producto.ID);
                        string s = cmbProds.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto = Ventas.Producto;
                preciosPr.Producto = Ventas.Producto;

                if (chDescripcion.Checked)
                {
                    Ventas.Descripcion = txtDescripcion.Text;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), txtDescripcion.Text);
                }

                if (chCostoCompra.Checked)
                {
                    if (rdAutoCompra.Checked)
                    {
                        preciosPr.Buscar();
                        Ventas.CostoCompra = preciosPr.Precio;

                    }
                    else
                    {
                        Single c = 0;

                        if (float.TryParse(txtCostoCompra.Text.Replace(".", ","), out c))
                        {
                            Ventas.CostoCompra = c;
                        }
                        else
                        {
                            Ventas.CostoCompra = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Compra"), Ventas.CostoCompra);
                }
                if (chCostoVenta.Checked)
                {
                    if (rdAutoVenta.Checked)
                    {
                        precios.Sucursal.ID = Ventas.Sucursal.ID;
                        precios.Buscar();
                        Ventas.CostoVenta = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoVenta.Text.Replace(".", ","), out c))
                        {
                            Ventas.CostoVenta = c;
                        }
                        else
                        {
                            Ventas.CostoVenta = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Venta"), Ventas.CostoVenta);
                }

                if (chKilos.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilos.Text.Replace(".", ","), out c))
                    {
                        Ventas.Kilos = c;
                    }
                    else
                    {
                        Ventas.Kilos = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), Ventas.Kilos);
                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Compra"), Ventas.CostoCompra * Ventas.Kilos);
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Venta"), Ventas.CostoVenta * Ventas.Kilos);

                if (chCamion.Checked)
                {
                    if (cmbCamion.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ventas.Camion.ID = h.Codigo_Seleccionado(cmbCamion.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("ID_Camion"), Ventas.Camion.ID);
                    }
                }
            }
            Totales();
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Ventas.ID = i;
                Ventas.Fecha = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                Ventas.Proveedor.Id = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Proveedores")));
                Ventas.Sucursal.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Sucursales")));
                Ventas.Producto.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                Ventas.Descripcion = Convert.ToString(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Descripcion")));
                Ventas.CostoCompra = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Compra")));
                Ventas.CostoVenta = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Venta")));
                Ventas.Kilos = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                Ventas.Camion.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("ID_Camion")));
                Ventas.Actualizar();
            }
            this.Close();
        }

        private void ChFecha_CheckedChanged(object sender, System.EventArgs e)
        {
            dtFecha.Enabled = chFecha.Checked;
            Resultado();
        }

        private void ChProveedor_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProveedor.Enabled = chProveedor.Checked;
        }
        private void ChSucursal_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbSucursal.Enabled = chSucursal.Checked;
        }

        private void ChProd_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProds.Enabled = chProd.Checked;
        }

        private void ChCosto_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoCompra.Enabled = chCostoCompra.Checked;
            rdManual.Enabled = chCostoCompra.Checked;
            txtCostoCompra.Enabled = chCostoCompra.Checked;
        }
        private void ChCostoVenta_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoVenta.Enabled = chCostoVenta.Checked;
            rdManualVenta.Enabled = chCostoVenta.Checked;
            txtCostoVenta.Enabled = chCostoVenta.Checked;
        }

        private void ChKilos_CheckedChanged(object sender, System.EventArgs e)
        {
            txtKilos.Enabled = chKilos.Checked;
            txtKilos.Focus();
        }

        private void ChDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = chDescripcion.Checked;
        }

        private void CmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void CmbProds_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void DtFecha_ValueChanged(object sender, EventArgs e)
        {
            Resultado();
        }


        private void RdAuto_CheckedChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void TxtCosto_TextChanged(object sender, EventArgs e)
        {
            Resultado();
        }


    }
}
