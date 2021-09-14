namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmCMOfertas : Form
    {
        private List<int> Id;
        private Ofertas Ofertas = new Ofertas();
        private Precios_Sucursales precios = new Precios_Sucursales();

        public frmCMOfertas()
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
            DataTable dt = Ofertas.Datos($" Id IN ({s})");
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);

            formato_Grilla();
            Totales();

            dt = Ofertas.Sucursal.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSucs.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Ofertas.Producto.Datos("Ver=1");
            foreach (DataRow dr in dt.Rows)
            {
                cmbProds.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Sucursales"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 200);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Original"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Oferta"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Diferencia"), 80);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Original")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Oferta")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Reintegro")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos_Vendidos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Diferencia")].Format = "N2";


            grdOriginal.Columnas[grdOriginal.get_ColIndex("Id_Sucursales") + 1].Style.ForeColor = Color.DimGray;
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Id_Sucursales")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Sucursales"), "Suc");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");

            grdResultado.set_ColW(grdResultado.get_ColIndex("Id"), 0);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Fecha"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Sucursales"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Productos"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Descripcion"), 200);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Original"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Oferta"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Kilos"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Diferencia"), 80);

            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Original")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Oferta")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Reintegro")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos_Vendidos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Diferencia")].Format = "N2";

            grdResultado.Columnas[grdResultado.get_ColIndex("Id_Sucursales") + 1].Style.ForeColor = Color.DimGray;
            grdResultado.Columnas[grdResultado.get_ColIndex("Id_Sucursales")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold);

            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Sucursales"), "Suc");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Reintegro"), false);
            double k = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Kilos"), false);
            int c = grdOriginal.Rows - 1;

            lblTotalO.Text = $"Registros: {c} Kilos: {k:N2} Reintegro: {t:C2}";

            t = 0;
            k = 0;

            for (int i = 1; i <= grdResultado.Rows - 1; i++)
            {
                t += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Reintegro")));
                k += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Kilos")));
            }

            c = grdResultado.Rows - 1;

            if (c > 0)
            {
                lblTotalR.Text = $"Registros: {c} Kilos: {k:N2} Reintegro: {t:C2}";
            }
            else { lblTotalR.Text = ""; }
        }

        private void Resultado()
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Ofertas.Cargar_Fila(i);

                precios.Sucursal = Ofertas.Sucursal;
                precios.Producto = Ofertas.Producto;

                if (chFecha.Checked)
                {
                    Ofertas.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = Ofertas.Fecha;

                if (chSucursal.Checked)
                {
                    if (cmbSucs.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ofertas.Sucursal.ID = h.Codigo_Seleccionado(cmbSucs.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Sucursales"), Ofertas.Sucursal.ID);
                        string s = cmbSucs.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre"), s);
                    }
                }
                precios.Sucursal.ID = Ofertas.Sucursal.ID;

                if (chProd.Checked)
                {
                    if (cmbProds.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Ofertas.Producto.ID = h.Codigo_Seleccionado(cmbProds.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), Ofertas.Producto.ID);
                        string s = cmbProds.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto.ID = Ofertas.Producto.ID;

                if (chDescripcion.Checked)
                {
                    Ofertas.Descripcion = txtDescripcion.Text;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), txtDescripcion.Text);
                }

                if (chCosto_Original.Checked)
                {
                    if (rdAutoOri.Checked)
                    {
                        precios.Buscar();
                        Ofertas.Costo_Original = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoOri.Text.Replace(".", ","), out c))
                        {
                            Ofertas.Costo_Original = c;
                        }
                        else
                        {
                            Ofertas.Costo_Original = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Original"), Ofertas.Costo_Original);
                }

                if (chCosto_Oferta.Checked)
                {
                    if (rdAutoOfe.Checked)
                    {
                        precios.Buscar();
                        Ofertas.Costo_Oferta = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoOfer.Text.Replace(".", ","), out c))
                        {
                            Ofertas.Costo_Oferta = c;
                        }
                        else
                        {
                            Ofertas.Costo_Oferta = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Oferta"), Ofertas.Costo_Oferta);
                }

                if (chKilos.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilos.Text.Replace(".", ","), out c))
                    {
                        Ofertas.Kilos = c;
                    }
                    else
                    {
                        Ofertas.Kilos = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), Ofertas.Kilos);
                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Reintegro"), (Ofertas.Costo_Original * Ofertas.Kilos) - (Ofertas.Costo_Oferta * Ofertas.Kilos));
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Diferencia"), Ofertas.Kilos - Convert.ToDouble(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos_Vendidos"))));
            }
            Totales();
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Ofertas.ID = i;
                Ofertas.Fecha = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                Ofertas.Sucursal.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Sucursales")));
                Ofertas.Producto.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                Ofertas.Descripcion = Convert.ToString(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Descripcion")));
                Ofertas.Costo_Original = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Original")));
                Ofertas.Costo_Oferta = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Oferta")));
                Ofertas.Kilos = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                Ofertas.Actualizar();
            }
            this.Close();
        }



        private void ChFecha_CheckedChanged(object sender, System.EventArgs e)
        {
            dtFecha.Enabled = chFecha.Checked;
            Resultado();
        }

        private void ChSucursal_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbSucs.Enabled = chSucursal.Checked;
        }

        private void ChProd_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProds.Enabled = chProd.Checked;
        }

        private void ChCosto_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoOri.Enabled = chCosto_Original.Checked;
            rdManualOri.Enabled = chCosto_Original.Checked;
            txtCostoOri.Enabled = chCosto_Original.Checked;
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

        private void CmbSucs_SelectedIndexChanged(object sender, EventArgs e)
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

        private void chCosto_Oferta_CheckedChanged(object sender, EventArgs e)
        {
            rdAutoOfe.Enabled = chCosto_Oferta.Checked;
            rdManualOfe.Enabled = chCosto_Oferta.Checked;
            txtCostoOfer.Enabled = chCosto_Oferta.Checked;
        }

        private void rdAutoOfe_CheckedChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void rdManualOfe_CheckedChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void txtCostoOfer_TextChanged(object sender, EventArgs e)
        {
            Resultado();
        }
    }
}
