namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmCMCompras : Form
    {
        private List<int> Id;
        private readonly Compras Compras = new Compras();
        private readonly Precios_Sucursales precios = new Precios_Sucursales();
        private readonly Precios_Proveedores preciosPr = new Precios_Proveedores();

        public frmCMCompras()
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
            DataTable dt = Compras.Datos($" Id IN ({s})");
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);

            formato_Grilla();
            Totales();

            dt = Compras.Proveedor.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProveedor.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Compras.Producto.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProds.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Compras.Camion.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbCamion.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Camion"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Proveedores"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Proveedores") + 1, 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 150);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Cantidad"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total"), 80);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Promedio"), 60);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Promedio")].Format = "N2";

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Id_Proveedores") + 1].Style.ForeColor = Color.DimGray;
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Proveedores"), "Prov");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");
            ////

            grdResultado.set_ColW(grdResultado.get_ColIndex("Id"), 0);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Fecha"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Camion"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Proveedores"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Proveedores") + 1, 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Productos"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Descripcion"), 150);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Cantidad"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Kilos"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total"), 80);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Promedio"), 60);

            grdResultado.Columnas[grdResultado.get_ColIndex("Costo")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Promedio")].Format = "N2";

            grdResultado.Columnas[grdResultado.get_ColIndex("Id_Proveedores") + 1].Style.ForeColor = Color.DimGray;
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Proveedores"), "Prov");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total"), false);
            double k = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Kilos"), false);
            int c = grdOriginal.Rows - 1;

            lblTotalO.Text = $"Registros: {c} Kilos: {k:N2} Total: {t:C2}";

            t = 0;
            k = 0;

            for (int i = 1; i <= grdResultado.Rows - 1; i++)
            {
                t += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total")));
                k += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Kilos")));
            }

            c = grdResultado.Rows - 1;

            if (c > 0)
            {
                lblTotalR.Text = $"Registros: {c} Kilos: {k:N2} Total: {t:C2}";
            }
            else { lblTotalR.Text = ""; }
        }

        private void Resultado()
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Compras.Cargar_Fila(i);

                precios.Producto = Compras.Producto;
                preciosPr.Proveedor = Compras.Proveedor;

                if (chFecha.Checked)
                {
                    Compras.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = Compras.Fecha;
                preciosPr.Fecha = Compras.Fecha;

                if (chProveedor.Checked)
                {
                    if (cmbProveedor.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Compras.Proveedor.Id = h.Codigo_Seleccionado(cmbProveedor.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Proveedores"), Compras.Proveedor.Id);
                        string s = cmbProveedor.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre"), s);
                    }
                }

                if (chProd.Checked)
                {
                    if (cmbProds.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Compras.Producto.ID = h.Codigo_Seleccionado(cmbProds.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), Compras.Producto.ID);
                        string s = cmbProds.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto = Compras.Producto;
                preciosPr.Producto = Compras.Producto;

                if (chDescripcion.Checked)
                {
                    Compras.Descripcion = txtDescripcion.Text;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), txtDescripcion.Text);
                }

                if (chCosto.Checked)
                {
                    if (rdAuto.Checked)
                    {
                        preciosPr.Buscar();
                        Compras.Costo = preciosPr.Precio;

                    }
                    else
                    {
                        Single c = 0;

                        if (float.TryParse(txtCosto.Text.Replace(".", ","), out c))
                        {
                            Compras.Costo = c;
                        }
                        else
                        {
                            Compras.Costo = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo"), Compras.Costo);
                }

                if (chKilos.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilos.Text.Replace(".", ","), out c))
                    {
                        Compras.Kilos = c;
                    }
                    else
                    {
                        Compras.Kilos = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), Compras.Kilos);

                    if (Compras.Kilos > 0 & Compras.Cantidad > 0)
                    { grdResultado.set_Texto(f, grdResultado.get_ColIndex("Promedio"), Compras.Kilos / Compras.Cantidad); }
                    else
                    { grdResultado.set_Texto(f, grdResultado.get_ColIndex("Promedio"), 0); }

                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total"), Compras.Costo * Compras.Kilos);

                if (chCamion.Checked)
                {
                    if (cmbCamion.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Compras.Camion.ID = h.Codigo_Seleccionado(cmbCamion.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("ID_Camion"), Compras.Camion.ID);
                    }
                }

                if (chCantidad.Checked)
                {
                    int c = 0;

                    if (int.TryParse(txtCantidad.Text, out c))
                    {
                        Compras.Cantidad = c;
                    }
                    else
                    {
                        Compras.Cantidad = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Cantidad"), Compras.Cantidad);
                    if (Compras.Kilos > 0 & Compras.Cantidad > 0)
                    { grdResultado.set_Texto(f, grdResultado.get_ColIndex("Promedio"), Compras.Kilos / Compras.Cantidad); }
                    else
                    { grdResultado.set_Texto(f, grdResultado.get_ColIndex("Promedio"), 0); }

                }

            }
            Totales();
        }

        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Compras.ID = i;
                Compras.Fecha = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                Compras.Proveedor.Id = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Proveedores")));
                Compras.Producto.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                Compras.Descripcion = Convert.ToString(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Descripcion")));
                Compras.Costo = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo")));
                Compras.Cantidad = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Cantidad")));
                Compras.Kilos = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                Compras.Camion.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("ID_Camion")));
                Compras.Actualizar();
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

        private void ChProd_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProds.Enabled = chProd.Checked;
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

        private void chCamion_CheckedChanged(object sender, EventArgs e)
        {
            cmbCamion.Enabled = chCamion.Checked;
        }

        private void chCosto_CheckedChanged_1(object sender, EventArgs e)
        {
            rdAuto.Enabled = chCosto.Checked;
            rdManual.Enabled = chCosto.Checked;
            txtCosto.Enabled = chCosto.Checked;
        }

        private void cmbCamion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void chCantidad_CheckedChanged(object sender, EventArgs e)
        {
            txtCantidad.Enabled = chCantidad.Checked;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            Resultado();
        }
    }
}
