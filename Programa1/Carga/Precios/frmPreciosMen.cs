﻿
namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using Programa1.DB.Varios;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using static Programa1.DB.Proveedores.Estados_Compra;

    public partial class frmPreciosMen : Form
    {
        Precios_Sucursales precios = new Precios_Sucursales();
        Herramientas h = new Herramientas();

        C1.Win.C1FlexGrid.CellStyle estCambiado;

        public frmPreciosMen()
        {
            InitializeComponent();
            Configuraciones cn = new Configuraciones();
            string n = cn.Leer("Decimales en Precios Otros");
            if (n.Length != 0)
            {
                nuDecimales.Value = Convert.ToInt32(n);
            }

            precios = new Precios_Sucursales();
            h.Llenar_List(lstTipos, precios.Producto.Tipo.Datos());

            estCambiado = grd.Styles.Add("");
            estCambiado.BackColor = Color.LemonChiffon;

        }

        private void FrmPreciosMen_Load(object sender, EventArgs e)
        {

        }

        private void Cargar_Lista()
        {
            if (lstTipos.SelectedIndex > -1)
            {
                DataTable dt = precios.Tabla_Precios(h.Codigo_Seleccionado(lstTipos.Text));

                grd.MostrarDatos(dt, true, false);
                grd.set_ColW(0, 60);
                grd.set_ColW(1, 300);
                grd.Columnas[2].Format = $"N{nuDecimales.Value}";
            }
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void Cargar_Precios()
        {
            this.Cursor = Cursors.WaitCursor;
            if (lstFechas.SelectedIndex > -1)
            {
                precios.Fecha = Convert.ToDateTime(lstFechas.Text);
            }
            else
            {
                //precios.Fecha = null;
            }

            precios.Sucursal.ID = Suc.Valor_Actual;


            if (lstTipos.SelectedIndex > -1)
            {
                DataTable dt = precios.Precios((byte)h.Codigo_Seleccionado(lstTipos.Text), true);

                grd.MostrarDatos(dt, true, false);
                grd.set_ColW(0, 60);
                grd.set_ColW(1, 300);
                grd.set_ColW(2, 70);
                grd.set_ColW(3, 70);
                grd.Columnas[2].Format = $"N{nuDecimales.Value}";
                grd.Columnas[3].Format = $"N{nuDecimales.Value}";

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (Convert.ToSingle(grd.get_Texto(i, 2)) != Convert.ToSingle(grd.get_Texto(i, 3)))
                    {
                        grd.Filas[i].Style = estCambiado;
                    }
                    else
                    {
                        grd.Filas[i].Style = null;
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Suc_Cambio_Seleccion(object sender, EventArgs e)
        {
            h.Llenar_List(lstFechas, precios.Fechas(h.Codigo_Seleccionado(lstTipos.Text)), "dd/MM/yyyy");
            Cargar_Precios();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            int suc = Suc.Valor_Actual;
            string fecha = lstFechas.Text;
            DateTime f;

            if (suc != 0 & DateTime.TryParse(fecha, out f) == true)
            {

                if (MessageBox.Show("¿Esta seguro de borrar la lista?"
                        , "Borrar lista"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    precios.Fecha = f;
                    precios.Sucursal.ID = suc;
                    //precios.Borrar_Lista(2);
                    MessageBox.Show("No implementado.");
                    h.Llenar_List(lstFechas, precios.Fechas(h.Codigo_Seleccionado(lstTipos.Text)), "dd/MM/yyyy");
                    Cargar_Precios();
                    this.Cursor = Cursors.Default;
                }

            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            if (lstTipos.SelectedIndex > -1)
            {
                frmImprimir_MenEmb fr = new frmImprimir_MenEmb();
                fr.Tipo = Convert.ToInt32(h.Codigo_Seleccionado(lstTipos.Text));
                fr.ShowDialog();
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            frmGuardar_Varios fr = new frmGuardar_Varios();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Guardar == true)
            {
                Cursor = Cursors.WaitCursor;

                precios.Fecha = fr.mntFecha.SelectionStart.Date;

                foreach (string suc in fr.lstSucursales.SelectedItems)
                {
                    //Guardar todo por cada Sucursal                    
                    Guardar(suc);
                }
                h.Llenar_List(lstFechas, precios.Fechas(Convert.ToByte(h.Codigo_Seleccionado(lstTipos.Text))), "dd/MM/yyyy");

                Cursor = Cursors.Default;
            }
        }

        private void Guardar(string suc)
        {
            precios.Sucursal.ID = h.Codigo_Seleccionado(suc);

            //Guardar la Lista
            for (int i = 1; i <= grd.Rows - 1; i++)
            {
                int prod = Convert.ToInt32((grd.get_Texto(i, grd.get_ColIndex("Id"))));

                if (prod != 0)
                {
                    precios.Producto.ID = prod;
                    precios.Precio = Convert.ToSingle((grd.get_Texto(i, grd.get_ColIndex("Precio"))));
                    if (precios.Precio != 0 | chValoresCero.Checked == true)
                    {
                        precios.Agregar();
                    }
                }
            }
        }

        private void grd_Editado(short f, short c, object a)
        {
            int cPr = grd.get_ColIndex("Precio");
            if (c == cPr)
            {
                grd.set_Texto(f, c, Convert.ToSingle(a));
                grd.ActivarCelda(f + 1, c);
            }
        }



        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Lista();
            if (Suc.Cantidad_Seleccionada() > 0) { h.Llenar_List(lstFechas, precios.Fechas(h.Codigo_Seleccionado(lstTipos.Text)), "dd/MM/yyyy"); }
            Text = lstTipos.Text;
        }

        private void nuDecimales_ValueChanged(object sender, EventArgs e)
        {
            Configuraciones cn = new Configuraciones();
            cn.Escribir("Decimales en Precios Otros", nuDecimales.Value.ToString());
            Cargar_Precios();
        }
    }
}
