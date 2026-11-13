namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmValorFranquicia : Form
    {
        public frmValorFranquicia()
        {
            InitializeComponent();
        }

        private void frmValorFranquicia_Load(object sender, EventArgs e)
        {
            Franquicia f = new Franquicia();
            grd.MostrarDatos(f.valores(), true, true);
            grd.Columnas[3].Style.Format = "N2";
            grd.AutosizeAll();
            DateTime fecha = DateTime.Now;
            // Buscar el lunes actual
            while (fecha.DayOfWeek != DayOfWeek.Monday)
            {
                fecha = fecha.AddDays(-1);
            }
            
            grdImpuestos.MostrarDatos(f.impuestos(fecha), true, true);
            grdImpuestos.Columnas[3].Style.Format = "N2";
            grdImpuestos.AutosizeAll();

            grdGastos.MostrarDatos(f.gastos(fecha), true, true);
            grdGastos.Columnas[3].Style.Format = "N2";
            grdGastos.AutosizeAll();

            grdCargasSociales.MostrarDatos(f.cargasSociales(fecha), true, true);
            grdCargasSociales.Columnas[3].Style.Format = "N2";
            grdCargasSociales.AutosizeAll();

            grdDevolucionEmpleados.MostrarDatos(f.devolucionEmpleados(), true, true);
            grdDevolucionEmpleados.Columnas[3].Style.Format = "N2";
            grdDevolucionEmpleados.AutosizeAll();
        }

        private void grd_Editado(short f, short c, object a)
        {
            Editar_Valor(grd, "valor_Franquicia", f, c, a);
        }

        private void grdImpuestos_Editado(short f, short c, object a)
        {
            Editar_Valor(grdImpuestos, "valor_impuestos", f, c, a);
        }

        private void grdGastos_Editado(short f, short c, object a)
        {
            Editar_Valor(grdGastos, "valor_gasto", f, c, a);
        }

        private void grdCargasSociales_Editado(short f, short c, object a)
        {
            Editar_Valor(grdCargasSociales, "valor_cargassociales", f, c, a);
        }

        private void grdDevolucionEmpleados_Editado(short f, short c, object a)
        {
            Editar_Valor(grdDevolucionEmpleados, "valor_devolucionempleado", f, c, a);
        }

        /// <summary>
        /// Guarda la edicion de una celda en una de las tablas de valores (Fecha, id_Sucursal, Importe).
        /// La ultima fila de la grilla es la fila nueva: al cargar el importe se inserta el registro.
        /// </summary>
        private void Editar_Valor(Grilla2.SpeedGrilla g, string tabla, short f, short c, object a)
        {
            Franquicia f1 = new Franquicia();
            if (c == g.get_ColIndex("Importe"))
            {
                DateTime fecha = Convert.ToDateTime(g.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(g.get_Texto(f, "id_Sucursal"));
                string importe = a.ToString().Replace(",", ".");

                string sql = $"UPDATE {tabla} SET Importe = {importe} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {suc}";
                if (f == g.Rows - 1)
                {
                    sql = $"INSERT INTO {tabla} (Fecha, id_Sucursal, Importe) VALUES ('{fecha:yyyy-MM-dd}', {suc}, {importe})";
                    g.AgregarFila();
                    g.set_Texto(f + 1, "Fecha", fecha.ToString("dd/MM/yyyy"));
                }
                f1.Ejecutar_Comando(sql);
                g.set_Texto(f, c, a);
                g.ActivarCelda(f + 1, 1);
                return;
            }
            if (c == g.get_ColIndex("Fecha"))
            {
                DateTime fecha = Convert.ToDateTime(a);
                if (f == g.Rows - 1)
                {
                    g.set_Texto(f, c, fecha);
                    g.ActivarCelda(f, c + 1);
                    return;
                }
                // Se toma la fecha anterior antes de pisarla en la grilla
                DateTime fechaAnterior = Convert.ToDateTime(g.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(g.get_Texto(f, "id_Sucursal"));
                string sql = $"UPDATE {tabla} SET Fecha = '{fecha:yyyy-MM-dd}' WHERE id_Sucursal = {suc} AND Fecha = '{fechaAnterior:yyyy-MM-dd}'";
                f1.Ejecutar_Comando(sql);
                g.set_Texto(f, c, fecha);
                return;
            }
            if (c == g.get_ColIndex("id_Sucursal"))
            {
                int suc = Convert.ToInt32(a);
                Sucursales s = new Sucursales();
                string nombre = s.Dato_Generico("SELECT Nombre FROM Sucursales WHERE id = " + suc).ToString();
                if (f == g.Rows - 1)
                {
                    g.set_Texto(f, c, suc);
                    g.set_Texto(f, c + 1, nombre);
                    g.ActivarCelda(f, c + 2);
                    return;
                }
                // Se toma la sucursal anterior antes de pisarla en la grilla
                int sucAnterior = Convert.ToInt32(g.get_Texto(f, "id_Sucursal"));
                DateTime fecha = Convert.ToDateTime(g.get_Texto(f, "Fecha"));
                string sql = $"UPDATE {tabla} SET id_Sucursal = {suc} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {sucAnterior}";
                f1.Ejecutar_Comando(sql);
                g.set_Texto(f, c, suc);
                g.set_Texto(f, c + 1, nombre);
                return;
            }
        }
    }
}
