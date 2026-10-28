
namespace Programa1.Carga.Precios
{
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;
    using Programa1.Clases;
    using Programa1.Datos;
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Varios;
    using Programa1.Herramientas;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmPreciosMen : Form
    {
        Precios_Sucursales precios = new Precios_Sucursales();
        Precios_Franquicia precios_fr = new Precios_Franquicia();
        Precios_Proveedores precios_prov = new Precios_Proveedores();
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

            h.Llenar_List(lstTipos, precios.Producto.Tipo.Datos());
            h.Llenar_List(lstFranquicia, precios_fr.Fechas_DT(), "dd/MM/yy");

            estCambiado = grd.Styles.Add("");
            estCambiado.BackColor = Color.LemonChiffon;
            grd.TeclasManejadas = new int[] { 43 };
        }

        private void FrmPreciosMen_Load(object sender, EventArgs e)
        {

        }

        private void Cargar_Lista()
        {
            if (lstTipos.SelectedIndex > -1)
            {
                DataTable dt = precios.Tabla_Precios(h.Codigo_Seleccionado(lstTipos.Text));
                
                dt.Columns.Add("% Au", Type.GetType("System.Single"));

                grd.MostrarDatos(dt, true, false);
                grd.set_ColW(0, 60);
                grd.set_ColW(1, 150);
                grd.set_ColW(5, 50);
                grd.Columnas[2].Format = $"N{nuDecimales.Value}";
                grd.Columnas[3].Format = $"N{nuDecimales.Value}";
                grd.Columnas[4].Format = $"N{nuDecimales.Value}";

                // Buscar los Porcentajes_Precios para los productos de franquicia
                for (int i = 1; i < grd.Rows; i++)
                {
                    int vProd = Convert.ToInt32(grd.get_Texto(i, 0));
                    if (vProd != 0)
                    {
                        Precios_Franquicia prf = new Precios_Franquicia();
                        prf.Producto = vProd;
                        Single por = prf.Buscar_Porcentaje();
                        grd.set_Texto(i, grd.get_ColIndex("% Au"), por);
                    }
                }
            }
        }

        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Lista();

            int tipo = h.Codigo_Seleccionado(lstTipos.Text);
            h.Llenar_List(lstFechas, precios.Fechas(tipo), "dd/MM/yy");
            h.Llenar_List(lstFranquicia, precios_fr.Fechas_DT(Suc.Valor_Actual, tipo), "dd/MM/yy");

            if(Suc.Valor_Actual != 0)
            {
                Cargar_Precios();
            }
            
            Text = lstTipos.Text;
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void lstFranquicia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void Cargar_Precios()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (grd.Rows <= 1) return;

                int vSuc = Suc.Valor_Actual;
                DateTime fecha = lstFechas.SelectedIndex > -1
                    ? Convert.ToDateTime(lstFechas.Text)
                    : DateTime.Now;
                DateTime fechafr = lstFranquicia.SelectedIndex > -1
                    ? Convert.ToDateTime(lstFranquicia.Text)
                    : DateTime.Now;

                precios_prov.Fecha = fecha;
                precios_prov.Proveedor.Id = 0; // Asumiendo que se quiere el precio del proveedor sin filtrar por proveedor específico

                precios.Fecha = fecha;
                precios.Sucursal.ID = vSuc;

                precios_fr.Fecha = fechafr;
                precios_fr.Sucursal = vSuc;

                // Obtener todos los IDs de productos de una vez
                var productIds = new List<int>();
                for (int i = 1; i < grd.Rows; i++)
                {
                    productIds.Add((int)grd.get_Texto(i, 0));
                }

                // Cargar todos los precios en una sola consulta
                //var preciosData = CargarTodosLosPrecios(productIds, vSuc, fecha, fechafr);

                // Aplicar los datos al grid
                for (int i = 1; i < grd.Rows; i++)
                {
                    int prod = (int)grd.get_Texto(i, 0);

                    precios.Producto.ID = prod;
                    precios_fr.Producto = prod;
                    precios_prov.Producto.ID = prod;
                    
                    grd.set_Texto(i, 2, precios_prov.Buscar());
                    grd.set_Texto(i, 3, precios_fr.Buscar_Precio(precios_fr));
                    grd.set_Texto(i, 4, precios.Buscar());
                                        

                    //// Comparar con precio anterior
                    //bool cambio = Math.Abs(Convert.ToSingle(precios.PrecioActual ?? 0) -
                    //                      Convert.ToSingle(precios.PrecioAnterior ?? 0)) > 0.001f;
                    //grd.Filas[i].Style = cambio ? estCambiado : null;

                }

                // Formato de columnas
                string formato = $"N{nuDecimales.Value}";
                grd.Columnas[2].Format = formato;
                grd.Columnas[3].Format = formato;
                grd.Columnas[4].Format = formato;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private Dictionary<int, PreciosProducto> CargarTodosLosPrecios(
            List<int> productIds, int vSuc, DateTime fecha, DateTime fechafr)
        {
            var resultado = new Dictionary<int, PreciosProducto>();

            if (productIds.Count == 0) return resultado;

            string idsString = string.Join(",", productIds);
            string fechaStr = fecha.ToString("MM/dd/yy");
            string fechafrStr = fechafr.ToString("MM/dd/yy");

            c_Base datos = new c_Base();

            // Query consolidada usando OUTER APPLY para obtener todos los precios
            string query = $@"
        SELECT 
            p.ID_Productos,
            pp.Precio AS PrecioProveedor,
            pf.Precio AS PrecioFranquicia,
            ps.Precio AS PrecioActual,
            psa.Precio AS PrecioAnterior
        FROM (SELECT ID_Productos FROM Precios_Proveedores WHERE ID_Productos IN ({idsString}) GROUP BY ID_Productos) p
        OUTER APPLY (
            SELECT TOP 1 Precio 
            FROM Precios_Proveedores 
            WHERE ID_Productos = p.ID_Productos 
            ORDER BY Fecha DESC
        ) pp
        OUTER APPLY (
            SELECT TOP 1 Precio 
            FROM Precios_Franquicia 
            WHERE ID_Productos = p.ID_Productos 
                AND Id_Sucursales = {vSuc} 
                AND Fecha <= '{fechafrStr}'
            ORDER BY Fecha DESC
        ) pf
        OUTER APPLY (
            SELECT TOP 1 ROUND(Precio, 3) AS Precio
            FROM Precios_Sucursales 
            WHERE ID_Productos = p.ID_Productos 
                AND Id_Sucursales = {vSuc} 
                AND Fecha = '{fechaStr}'
            ORDER BY Fecha DESC
        ) ps
        OUTER APPLY (
            SELECT TOP 1 ROUND(Precio, 3) AS Precio
            FROM Precios_Sucursales 
            WHERE ID_Productos = p.ID_Productos 
                AND Id_Sucursales = {vSuc} 
                AND Fecha < '{fechaStr}'
            ORDER BY Fecha DESC
        ) psa";

            // Ejecutar consulta y llenar diccionario
            using (DataTable reader = datos.Datos_Genericos(query))
            {
                foreach (DataRow row in reader.Rows)
                {
                    int id = row[0] != DBNull.Value ? Convert.ToInt32(row[0]) : 0;
                    resultado[id] = new PreciosProducto {
                        PrecioProveedor = row[1] != DBNull.Value ? row[1] : null,
                        PrecioFranquicia = row[2] != DBNull.Value ? row[2] : null,
                        PrecioActual = row[3] != DBNull.Value ? row[3] : null,
                        PrecioAnterior = row[4] != DBNull.Value ? row[4] : null
                    };
                }
            }

            return resultado;
        }

        private class PreciosProducto
        {
            public object PrecioProveedor { get; set; }
            public object PrecioFranquicia { get; set; }
            public object PrecioActual { get; set; }
            public object PrecioAnterior { get; set; }
        }

        private void Cargar_PreciosNotanOld()
        {
            this.Cursor = Cursors.WaitCursor;

            if (grd.Rows > 1)
            {
                int vSuc = Suc.Valor_Actual;
                DateTime fecha = DateTime.Now;
                DateTime fechafr = DateTime.Now;
                if (lstFechas.SelectedIndex > -1) { fecha = Convert.ToDateTime(lstFechas.Text); }
                if (lstFranquicia.SelectedIndex > -1) { fechafr = Convert.ToDateTime(lstFranquicia.Text); }
                int prod = 0;

                c_Base datos = new c_Base();

                for (int i = 1; i < grd.Rows; i++)
                {
                    prod = (int)grd.get_Texto(i, 0);
                    string cadena = $"SELECT TOP 1 Precio FROM Precios_Proveedores WHERE ID_Productos={prod} ORDER BY Fecha DESC";
                    object precio = datos.Dato_Generico(cadena);
                    grd.set_Texto(i, 2, precio);

                    cadena = $"SELECT TOP 1 Precio FROM Precios_Franquicia WHERE ID_Productos={prod} AND Id_Sucursales={vSuc} AND Fecha<='{fechafr:MM/dd/yy}' ORDER BY Fecha DESC";
                    precio = datos.Dato_Generico(cadena);
                    grd.set_Texto(i, 3, precio);

                    cadena = $"SELECT TOP 1 ROUND(Precio, 3) FROM Precios_Sucursales WHERE ID_Productos={prod} AND Id_Sucursales={vSuc} AND Fecha='{fecha:MM/dd/yy}' ORDER BY Fecha DESC";
                    precio = datos.Dato_Generico(cadena);
                    grd.set_Texto(i, 4, precio);

                    cadena = $"SELECT TOP 1 ROUND(Precio, 3) FROM Precios_Sucursales WHERE ID_Productos={prod} AND Id_Sucursales={vSuc} AND Fecha<'{fecha:MM/dd/yy}' ORDER BY Fecha DESC";
                    object precio_ant = datos.Dato_Generico(cadena);
                    if (Convert.ToSingle(precio) != Convert.ToSingle(precio_ant))
                    {
                        grd.Filas[i].Style = estCambiado;
                    }
                    else
                    {
                        grd.Filas[i].Style = null;
                    }
                }
                grd.Columnas[2].Format = $"N{nuDecimales.Value}";
                grd.Columnas[3].Format = $"N{nuDecimales.Value}";
                grd.Columnas[4].Format = $"N{nuDecimales.Value}";
            }

            this.Cursor = Cursors.Default;
        }

        private void Cargar_PreciosOLD()
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
            if(lstTipos.SelectedIndex > -1)
            {
                Cargar_Lista();
            }
            if (lstFechas.SelectedIndex > -1 | lstFranquicia.SelectedIndex > -1)
            {
                Cargar_Precios();
            }
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
                    precios.Precio = Convert.ToSingle((grd.get_Texto(i, grd.get_ColIndex("Venta"))));

                    if (precios.Precio != 0 | chValoresCero.Checked == true)
                    {
                        precios.Agregar();
                    }
                }
            }
        }
        private void cmdGuardarFran_Click(object sender, EventArgs e)
        {
            frmGuardar_Varios fr = new frmGuardar_Varios();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Guardar == true)
            {
                Cursor = Cursors.WaitCursor;

                precios.Fecha = fr.mntFecha.SelectionStart.Date;

                precios_fr.Fecha = fr.mntFecha.SelectionStart.Date;
                foreach (string suc in fr.lstSucursales.SelectedItems)
                {
                    //Guardar todo por cada Sucursal                    
                    precios_fr.Sucursal = h.Codigo_Seleccionado(suc);
                    for (int i = 1; i < grd.Rows; i++)
                    {
                        precios_fr.Producto = (int)grd.get_Texto(i, 0);
                        precios_fr.Precio = Convert.ToSingle(grd.get_Texto(i, 3));

                        if (precios_fr.Precio > 0 | chValoresCero.Checked)
                        {
                            precios_fr.Agregar();
                        }
                    }
                }
                Cargar_Lista();

                Cursor = Cursors.Default;
            }
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c > 1)
            {
                if (c == grd.get_ColIndex("% Au"))
                {
                    double p = Convert.ToDouble(a);
                    grd.set_Texto(f, c, p);

                    // Guardar el porcentaje en la base de datos
                    
                    Precios_Franquicia prf = new Precios_Franquicia();
                    prf.Guardar_Porcentaje(Convert.ToInt32(grd.get_Texto(f, 0)), p);

                    // Si hay precio en la grilla de productos, recalculo el precio de franquicia
                    
                    double pr = Convert.ToDouble(grd.get_Texto(f, grd.get_ColIndex("Compra")));
                    if (pr > 0)
                    {
                        pr = pr + (pr * p / 100);
                        grd.set_Texto(f, grd.get_ColIndex("Franquicia"), pr);
                    }
                    grd.ActivarCelda((c <= grd.Rows - 1) ? f + 1 : 1, c);

                }else
                {
                    grd.set_Texto(f, c, Convert.ToSingle(a));
                    grd.ActivarCelda(f + 1, c);
                }
            }
        }


        private void nuDecimales_ValueChanged(object sender, EventArgs e)
        {
            Configuraciones cn = new Configuraciones();
            cn.Escribir("Decimales en Precios Otros", nuDecimales.Value.ToString());
            Cargar_Precios();
        }

        private void cmdActualizar_Franquicia_Click(object sender, EventArgs e)
        {
            frmSeleccionarFecha frm = new frmSeleccionarFecha();
            frm.StoreProcedure = "sp_ActualizarFechaFranquicia"; // Nombre de tu stored procedure
            frm.Sucursal = Suc.Valor_Actual; // Pasar la sucursal actual al formulario
            
            if(frm.Sucursal == 0)
            {
                MessageBox.Show("Seleccione una sucursal antes de actualizar la fecha de franquicia.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // La fecha fue actualizada correctamente
                // Recargar los precios con la nueva fecha
                lstFranquicia_SelectedIndexChanged(null, null);
                h.Llenar_List(lstFranquicia, precios_fr.Fechas_DT(Suc.Valor_Actual, h.Codigo_Seleccionado(lstTipos.Text)), "dd/MM/yy");
                MessageBox.Show("Precios de franquicia actualizados correctamente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdPorcentaje_Click(object sender, EventArgs e)
        {
            // Recorrer la grilla de franquicia y aplicar el porcentaje ingresado al precio de cada producto.
            try
            {
                for (int i = 1; i < grd.Rows; i++)
                {
                    Single p = Convert.ToSingle(grd.get_Texto(i, "% Au"));
                    Single precio = Convert.ToSingle(grd.get_Texto(i, "Compra"));

                    if (p != 0) { precio = precio + (precio * p / 100); }

                    grd.set_Texto(i, "Franquicia", precio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 43)
            {
                if (grd.Row < grd.Rows && grd.Col == grd.Cols - 1)
                {
                    double p = Convert.ToDouble(grd.get_Texto(grd.Row - 1, "% Au"));

                    grd.set_Texto(grd.Row, grd.Col, p);

                    // Guardar el porcentaje en la base de datos

                    Precios_Franquicia prf = new Precios_Franquicia();

                    prf.Guardar_Porcentaje(Convert.ToInt32(grd.get_Texto(grd.Row, 0)), p);

                    // Si hay precio en la grilla de productos, recalculo el precio de franquicia
                    double pr = Convert.ToDouble(grd.get_Texto(grd.Row, grd.get_ColIndex("Compra")));
                    if (pr > 0)
                    {
                        pr = pr + (pr * p / 100);
                        grd.set_Texto(grd.Row, grd.get_ColIndex("Franquicia"), pr);
                    }
                    grd.ActivarCelda((grd.Col <= grd.Rows - 1) ? grd.Row + 1 : 1, grd.Col);
                }
            }
        }
    }
}
