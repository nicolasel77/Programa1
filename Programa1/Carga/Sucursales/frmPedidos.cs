namespace Programa1.Carga.Sucursales
{
    using Programa1.Carga.Empleados;
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmPedidos : Form
    {

        public frmPedidos()
        {
            InitializeComponent();
        }

        private void cSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            // Mostrar los datos de Pedidos
            c_Base _Base = new c_Base();
            string s = "";
            string campos = "*";
            string agrupar = "";
            string sucursales = cSuc.Codigos_Seleccionados();

            if (chAgruparProductos.Checked)
            {
                campos = "Id_Producto, Descripcion, SUM(Cantidad) AS Cantidad";
                agrupar = " GROUP BY Id_Producto, Descripcion";
            }


            if (cSuc.Valor_Actual > 0)
            {
                s = cSuc.Cadena("Suc");
            }

            if (cFecha.Cadena("Fecha") != "")
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += cFecha.Cadena("Fecha");
            }else
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += $"Fecha = '{DateTime.Today:yyyy-MM-dd}'";
            }

            if (cProds.Cadena("Producto") != "")
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += cProds.Cadena("Id_Producto");
            }

            if (s != "")
            {
                s = $"SELECT {campos} FROM vw_Pedidos WHERE {s} {agrupar} ORDER BY {(!chAgruparProductos.Checked ? "Suc, " : "")}Id_Producto";

                if (chColumnas.Checked)
                {

                    System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[4];
                    p[0] = new System.Data.SqlClient.SqlParameter("@fecha", cFecha.fecha_Actual);
                    p[1] = new System.Data.SqlClient.SqlParameter("@id_tipo", cProds.Tipo_Seleccionado());
                    p[2] = new System.Data.SqlClient.SqlParameter("@id_supervisor", cSuc.Supervisor_Seleccionado());
                    p[3] = new System.Data.SqlClient.SqlParameter("@sucursales", sucursales);
                    grd.MostrarDatos(_Base.sp_Datos("dbo.sp_Pedidos", p), true, false);

                    // Insertar una columna en la posicion 2 para mostrar el total de la fila
                    grd.Columnas.Insert(2);
                    grd.set_Texto(0, 2, "Total");
                    
                    C1.Win.C1FlexGrid.CellStyle estGris;
                    
                    estGris = grd.Styles.Add("gris");
                    estGris.BackColor = Color.LightGray;

                    grd.Columnas[2].Style = estGris;

                    // sumar la fila a partir de la columna 3
                    for (int f = 1; f < grd.Rows; f++)
                    {
                        decimal total = 0;
                        for (int c = 3; c < grd.Cols; c++)
                        {
                            object obj = grd.get_Texto(f, c);
                            total += Convert.ToDecimal(obj);
                        }
                        grd.set_Texto(f, 2, total);
                    }

                    for (int c = 2; c < grd.Cols; c++)
                    {
                        grd.Columnas[c].Format = "#,#";
                    }
                    grd.AutosizeAll();
                }
                else
                {
                    grd.MostrarDatos(_Base.Datos_Genericos(s), true, true);
                    grd.SumarCol(grd.get_ColIndex("Cantidad"), true);
                    grd.AutosizeAll();
                    grd.Columnas[0].Width = 0;

                }

            }
            else
            {
                grd.Rows = 1;
            }
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void chAgruparProductos_CheckedChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cmdMostrar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c_Base _Base = new c_Base();
            string s = "";
            string campos = "*";
            string agrupar = "";
            string sucursales = cSuc.Codigos_Seleccionados();

            if (chAgruparProductos.Checked)
            {
                campos = "Id_Producto, Descripcion, SUM(Cantidad) AS Cantidad";
                agrupar = " GROUP BY Id_Producto, Descripcion";
            }


            if (cSuc.Valor_Actual > 0)
            {
                s = cSuc.Cadena("Suc");
            }

            if (cFecha.Cadena("Fecha") != "")
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += cFecha.Cadena("Fecha");
            }
            else
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += $"Fecha = '{DateTime.Today:yyyy-MM-dd}'";
            }

            if (cProds.Cadena("Producto") != "")
            {
                if (!string.IsNullOrEmpty(s))
                {
                    s += " AND ";
                }
                s += cProds.Cadena("Id_Producto");
            }
            
            DataTable dt = new DataTable();

            if (s != "")
            {
                s = $"SELECT {campos} FROM vw_Pedidos WHERE {s} {agrupar} ORDER BY {(!chAgruparProductos.Checked ? "Suc, " : "")}Id_Producto";

                if (chColumnas.Checked)
                {

                    System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[4];
                    p[0] = new System.Data.SqlClient.SqlParameter("@fecha", cFecha.fecha_Actual);
                    p[1] = new System.Data.SqlClient.SqlParameter("@id_tipo", cProds.Tipo_Seleccionado());
                    p[2] = new System.Data.SqlClient.SqlParameter("@id_supervisor", cSuc.Supervisor_Seleccionado());
                    p[3] = new System.Data.SqlClient.SqlParameter("@sucursales", sucursales);
                    dt = _Base.sp_Datos("dbo.sp_Pedidos", p);                    
                }
                else
                {
                    dt = _Base.Datos_Genericos(s);
                }
            }
            // Exportar a Excel
            Formatear_Excel.Formatear fm = new Formatear_Excel.Formatear();
            fm.Formato_Automatico(dt, false, false, false, true);
        }
    }
}
