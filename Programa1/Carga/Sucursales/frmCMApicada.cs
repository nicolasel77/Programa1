namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCMApicada : Form
    {
        private List<int> Id;
        private APicada apicada = new APicada();
        private Precios_Sucursales precios = new Precios_Sucursales();

        public frmCMApicada()
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
            DataTable dt = apicada.Datos($" Id IN ({s})");
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);

            formato_Grilla();
            Totales();

            dt = apicada.Sucursal.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbSuc.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = apicada.Producto_A.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProdsA.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = apicada.Producto_S.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                cmbProdsS.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Suc"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Suc_Entrada"), 35);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre_Entrada"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
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
                apicada.Cargar_Fila(i);

                precios.Sucursal = apicada.Sucursal;
                precios.Producto = apicada.Producto_A;

                if (chFecha.Checked)
                {
                    apicada.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = apicada.Fecha;

                if (chSuc.Checked)
                {
                    if (cmbSuc.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        apicada.Sucursal.ID = h.Codigo_Seleccionado(cmbSuc.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Suc_Entrada"), apicada.Sucursal.ID);
                        string s = cmbSuc.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre_Entrada"), s);
                    }
                }
                precios.Sucursal.ID = apicada.Sucursal.ID;

                if (chProdA.Checked)
                {
                    if (cmbProdsA.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        apicada.Producto_A.ID = h.Codigo_Seleccionado(cmbProdsA.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), apicada.Producto_A.ID);
                        string s = cmbProdsA.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto.ID = apicada.Producto_A.ID;


                if (chCostoA.Checked)
                {
                    if (rdAutoA.Checked)
                    {
                        precios.Buscar();
                        apicada.Costo_S = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoA.Text.Replace(".", ","), out c))
                        {
                            apicada.Costo_S = c;
                        }
                        else
                        {
                            apicada.Costo_S = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Salida"), apicada.Costo_S);
                }
                if (chCostoA.Checked)
                {
                    if (rdAutoS.Checked)
                    {
                        precios.Sucursal.ID = apicada.Sucursal.ID;
                        precios.Buscar();
                        apicada.Costo_A = precios.Precio;

                    }
                    else
                    {
                        float c = 0;

                        if (float.TryParse(txtCostoA.Text.Replace(".", ","), out c))
                        {
                            apicada.Costo_A = c;
                        }
                        else
                        {
                            apicada.Costo_A = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo_Entrada"), apicada.Costo_A);
                }

                if (chKilosA.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilosA.Text.Replace(".", ","), out c))
                    {
                        apicada.Kilos_A = c;
                    }
                    else
                    {
                        apicada.Kilos_A = 0;
                    }

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), apicada.Kilos_A);
                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Salida"), apicada.Costo_S * apicada.Kilos_A);
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total_Entrada"), apicada.Costo_A * apicada.Kilos_A);
            }
            Totales();
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                apicada.ID = i;
                apicada.Fecha = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                apicada.Sucursal.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Suc_Salida")));
                apicada.Sucursal.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Suc_Entrada")));
                apicada.Producto_A.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                apicada.Costo_S = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Salida")));
                apicada.Costo_A = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo_Entrada")));
                apicada.Kilos_A = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                apicada.Actualizar();
            }
            this.Close();
        }



        private void ChFecha_CheckedChanged(object sender, System.EventArgs e)
        {
            dtFecha.Enabled = chFecha.Checked;
            Resultado();
        }

        private void ChSucursalEntrada_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbSuc.Enabled = chSuc.Checked;
        }

        private void ChProd_CheckedChanged(object sender, System.EventArgs e)
        {
            cmbProdsA.Enabled = chProdA.Checked;
        }

        private void ChCosto_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoA.Enabled = chCostoA.Checked;
            rdManualA.Enabled = chCostoA.Checked;
            txtCostoA.Enabled = chCostoA.Checked;
        }
        private void ChCosto_Antrada_CheckedChanged(object sender, System.EventArgs e)
        {
            rdAutoS.Enabled = chCostoA.Checked;
            rdManualS.Enabled = chCostoA.Checked;
            txtCostoA.Enabled = chCostoA.Checked;
        }

        private void ChKilos_CheckedChanged(object sender, System.EventArgs e)
        {
            txtKilosA.Enabled = chKilosA.Checked;
            txtKilosA.Focus();
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

        private void cmbProdsS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resultado();
        }

        private void chProdS_CheckedChanged(object sender, EventArgs e)
        {
            cmbProdsS.Enabled = chProdS.Checked;
        }

        private void chKilosS_CheckedChanged(object sender, EventArgs e)
        {
            txtKilosS.Enabled = chKilosS.Checked;
            txtKilosS.Focus();
        }

        private void txtKilosS_TextChanged(object sender, EventArgs e)
        {
            Resultado();
        }

    }
}
