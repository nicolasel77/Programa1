namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCMTraslados : Form
    {
        private List<int> Id;
        private Traslados Traslados = new Traslados();
        private Precios_Sucursales precios = new Precios_Sucursales();

        public frmCMTraslados()
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
            DataTable dt = Traslados.Datos($" Id IN ({s})");
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);

            formato_Grilla();
            Totales();

            dt = Traslados.sucS.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSucSalida.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Traslados.sucE.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSucEntrada.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Traslados.Producto.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProds.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Suc_Salida"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre_Salida"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Suc_Entrada"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre_Entrada"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Salida"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo_Entrada"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total_Salida"), 80);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total_Entrada"), 80);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Salida")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo_Entrada")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total_Salida")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total_Entrada")].Format = "C2";

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Suc_Salida"), "Suc S");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Suc_Entrada"), "Suc E");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");

            grdResultado.set_ColW(grdResultado.get_ColIndex("Id"), 0);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Fecha"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Suc_Salida"), 35);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre_Salida"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Suc_Entrada"), 35);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre_Entrada"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Productos"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Descripcion"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Salida"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo_Entrada"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Kilos"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total_Salida"), 80);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total_Entrada"), 80);

            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Salida")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Costo_Entrada")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total_Salida")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total_Entrada")].Format = "C2";

            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Suc_Salida"), "Suc S");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Suc_Entrada"), "Suc E");
            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total_Salida"), false);
            double te = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total_Entrada"), false);
            double k = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Kilos"), false);
            int c = grdOriginal.Rows - 1;

            lblTotalO.Text = $"Registros: {c} Kilos: {k:N2} Total Salida: {t:C2} Total Entrada: {te:C2}";

            t = 0;
            te = 0;
            k = 0;

            for (int i = 1; i <= grdResultado.Rows - 1; i++)
            {
                t += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total_Salida")));
                te += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total_Entrada")));
                k += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Kilos")));
            }

            c = grdResultado.Rows - 1;

            if (c > 0)
            {
                lblTotalR.Text = $"Registros: {c} Kilos: {k:N2} Total Salida: {t:C2} Total Entrada: {te:C2}";
            }
            else { lblTotalR.Text = ""; }
        }

        private void Resultado()
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Traslados.Cargar_Fila(i);

                precios.Sucursal = Traslados.sucS;
                precios.Producto = Traslados.Producto;

                if (chFecha.Checked)
                {
                    Traslados.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = Traslados.Fecha;

                if (chSucSalida.Checked)
                {
                    if (cmbSucSalida.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Traslados.sucS.ID = h.Codigo_Seleccionado(cmbSucSalida.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Suc_Salida"), Traslados.sucS.ID);
                        string s = cmbSucSalida.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre_Salida"), s);
                    }
                }
                if (chSucEntrada.Checked)
                {
                    if (cmbSucEntrada.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Traslados.sucE.ID = h.Codigo_Seleccionado(cmbSucEntrada.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Suc_Entrada"), Traslados.sucE.ID);
                        string s = cmbSucEntrada.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre_Entrada"), s);
                    }
                }
                precios.Sucursal.ID = Traslados.sucS.ID;

                if (chProd.Checked)
                {
                    if (cmbProds.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        Traslados.Producto.ID = h.Codigo_Seleccionado(cmbProds.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), Traslados.Producto.ID);
                        string s = cmbProds.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto.ID = Traslados.Producto.ID;

                if (chDescripcion.Checked)
                {
                    Traslados.Descripcion = txtDescripcion.Text;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), txtDescripcion.Text);
                }

                if (chCostoSalida.Checked)
                {
                    if (rdAuto.Checked)
                    {
                        precios.Buscar();
                        Traslados.CostoS = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCosto.Text.Replace(".", ","), out c))
                        {
                            Traslados.CostoS = c;
                        }
                        else
                        {
                            Traslados.CostoS = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Salida"), Traslados.CostoS);
                }
                if (chCostoEntrada.Checked)
                {
                    if (rdAutoEntrada.Checked)
                    {
                        precios.Sucursal.ID = Traslados.sucE.ID;
                        precios.Buscar();
                        Traslados.CostoE = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoEntrada.Text.Replace(".", ","), out c))
                        {
                            Traslados.CostoE = c;
                        }
                        else
                        {
                            Traslados.CostoE = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Entrada"), Traslados.CostoE);
                }

                if (chKilos.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilos.Text.Replace(".", ","), out c))
                    {
                        Traslados.Kilos = c;
                    }
                    else
                    {
                        Traslados.Kilos = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), Traslados.Kilos);
                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Salida"), Traslados.CostoS * Traslados.Kilos);
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Entrada"), Traslados.CostoE * Traslados.Kilos);
            }
            Totales();
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                Traslados.Id = i;
                Traslados.Fecha = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                Traslados.sucS.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Suc_Salida")));
                Traslados.sucE.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Suc_Entrada")));
                Traslados.Producto.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                Traslados.Descripcion = Convert.ToString(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Descripcion")));
                Traslados.CostoS = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Salida")));
                Traslados.CostoE = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Entrada")));
                Traslados.Kilos = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                Traslados.Actualizar();
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
            cmbSucSalida.Enabled = chSucSalida.Checked;
        }
        private void ChSucursalEntrada_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbSucEntrada.Enabled = chSucEntrada.Checked;
        }

        private void ChProd_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProds.Enabled = chProd.Checked;
        }

        private void ChCosto_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAuto.Enabled = chCostoSalida.Checked;
            rdManual.Enabled = chCostoSalida.Checked;
            txtCosto.Enabled = chCostoSalida.Checked;
        }
        private void ChCostoEntrada_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoEntrada.Enabled = chCostoEntrada.Checked;
            rdManualEntrada.Enabled = chCostoEntrada.Checked;
            txtCostoEntrada.Enabled = chCostoEntrada.Checked;
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


    }
}
