namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCMStock : Form
    {
        private List<int> Id;
        private Stock stock = new Stock();
        private Precios_Sucursales precios = new Precios_Sucursales();

        public frmCMStock()
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
            DataTable dt = stock.Datos($" Id IN ({s})"); 
            grdOriginal.MostrarDatos(dt, true, false);
            grdResultado.MostrarDatos(dt, true, false);
            
            formato_Grilla();
            Totales();

            dt = stock.Sucursal.Datos();
            foreach(DataRow dr in dt.Rows)
            {
                cmbSucs.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = stock.Producto.Datos("Ver=1");
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
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total"), 80);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Format = "C2";

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Sucursales"), "Suc");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");

            grdResultado.set_ColW(grdResultado.get_ColIndex("Id"), 0);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Fecha"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Sucursales"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Nombre"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Id_Productos"), 30);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Descripcion"), 100);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Costo"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Kilos"), 60);
            grdResultado.set_ColW(grdResultado.get_ColIndex("Total"), 80);

            grdResultado.Columnas[grdResultado.get_ColIndex("Costo")].Format = "C2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Format = "N2";
            grdResultado.Columnas[grdResultado.get_ColIndex("Total")].Format = "C2";

            grdResultado.Columnas[grdResultado.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdResultado.set_Texto(0, grdResultado.get_ColIndex("Id_Sucursales"), "Suc");
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
            
            for (int i = 1; i <= grdResultado.Rows-1; i++)
            {
                t += Convert.ToDouble(grdResultado.get_Texto(i, grdResultado.get_ColIndex("Total")));
                k += Convert.ToDouble(grdResultado.get_Texto(i , grdResultado.get_ColIndex("Kilos")));
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
            for (int f = 1; f<= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                stock.Cargar_Fila(i);
                
                precios.Sucursal = stock.Sucursal;
                precios.Producto = stock.Producto;

                if (chFecha.Checked)
                {                    
                    stock.Fecha = dtFecha.Value;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Fecha"), dtFecha.Value);
                }
                precios.Fecha = stock.Fecha;

                if (chSucursal.Checked)
                {
                    if (cmbSucs.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        stock.Sucursal.Id = h.Codigo_Seleccionado(cmbSucs.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Sucursales"), stock.Sucursal.Id);
                        string s = cmbSucs.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Nombre"), s);
                    }                    
                }
                precios.Sucursal.Id = stock.Sucursal.Id;

                if (chProd.Checked)
                {
                    if (cmbProds.SelectedIndex > -1)
                    {
                        Herramientas.Herramientas h = new Herramientas.Herramientas();
                        stock.Producto.ID = h.Codigo_Seleccionado(cmbProds.Text);

                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Id_Productos"), stock.Producto.ID);
                        string s = cmbProds.Text;
                        s = s.Substring(s.IndexOf(".") + 1);
                        grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), s);
                    }
                }
                precios.Producto.ID = stock.Producto.ID;

                if (chDescripcion.Checked)
                {
                    stock.Descripcion = txtDescripcion.Text;

                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Descripcion"), txtDescripcion.Text);
                }

                if (chCosto.Checked)
                {
                    if (rdAuto.Checked)
                    {
                        precios.Buscar();
                        stock.Costo = precios.Precio;

                    }
                    else
                    {
                        float c = 0;
                        
                        if (float.TryParse(txtCosto.Text.Replace(".", ","), out c))
                        {
                            stock.Costo = c;
                        }
                        else
                        {
                            stock.Costo = 0;
                        }

                    }
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Costo"), stock.Costo);
                }

                if (chKilos.Checked)
                {
                    float c = 0;

                    if (float.TryParse(txtKilos.Text.Replace(".", ","), out c))
                    {
                        stock.Kilos = c;
                    }
                    else
                    {
                        stock.Kilos = 0;
                    }
                    
                    grdResultado.set_Texto(f, grdResultado.get_ColIndex("Kilos"), stock.Kilos);
                }
                grdResultado.set_Texto(f, grdResultado.get_ColIndex("Total"), stock.Costo*stock.Kilos);
            }
            Totales();
        }


        private void CmdGuardar_Click(object sender, EventArgs e)
        {
            for (int f = 1; f <= grdResultado.Rows - 1; f++)
            {
                int i = Convert.ToInt32(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id")).ToString());
                stock.Id = i;
                stock.Fecha  = Convert.ToDateTime(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Fecha")));
                stock.Sucursal.Id  = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Sucursales")));
                stock.Producto.ID = Convert.ToInt16(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Id_Productos")));
                stock.Descripcion = Convert.ToString(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Descripcion")));
                stock.Costo = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Costo")));
                stock.Kilos = Convert.ToSingle(grdResultado.get_Texto(f, grdResultado.get_ColIndex("Kilos")));
                stock.Actualizar();
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
            rdAuto.Enabled = chCosto.Checked;
            rdManual.Enabled = chCosto.Checked;
            txtCosto.Enabled = chCosto.Checked;
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
