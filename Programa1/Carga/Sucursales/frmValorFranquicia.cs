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
        }

        private void grd_Editado(short f, short c, object a)
        {
            Franquicia f1 = new Franquicia();
            if (c == grd.get_ColIndex("Importe"))
            {
                DateTime fecha = Convert.ToDateTime(grd.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(grd.get_Texto(f, "id_Sucursal"));


                string sql = $"UPDATE valor_Franquicia SET Importe = {a} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {suc}";
                if (f == grd.Rows - 1)
                {
                    sql = $"INSERT INTO valor_Franquicia (Fecha, id_Sucursal, Importe) VALUES ('{fecha:yyyy-MM-dd}', {suc}, {a.ToString().Replace(",", ".")})";
                    grd.AgregarFila();
                    grd.set_Texto(f + 1, "Fecha", fecha.ToString("dd/MM/yyyy"));
                    
                }
                f1.Ejecutar_Comando(sql);
                grd.set_Texto(f, c, a);
                grd.ActivarCelda(f + 1, 1);
                return;
            }
            if (c == grd.get_ColIndex("Fecha"))
            {
                DateTime fecha = Convert.ToDateTime(a);
                grd.set_Texto(f, c, fecha);
                if (f == grd.Rows - 1)
                {
                    grd.ActivarCelda(f, c + 1);
                    return;
                }
                int suc = Convert.ToInt32(grd.get_Texto(f, "id_Sucursal"));
                string sql = $"UPDATE valor_Franquicia SET Fecha = '{fecha:yyyy-MM-dd}' WHERE id_Sucursal = {suc} AND Fecha = '{grd.get_Texto(f, "Fecha"):yyyy-MM-dd}'";
                f1.Ejecutar_Comando(sql);
                return;
            }
            if (c == grd.get_ColIndex("id_Sucursal"))
            {
                int suc = Convert.ToInt32(a);
                Sucursales s = new Sucursales();
                string nombre = s.Dato_Generico("SELECT Nombre FROM Sucursales WHERE id = " + suc).ToString();
                grd.set_Texto(f, c, suc);
                grd.set_Texto(f, c + 1, nombre);
                if (f == grd.Rows - 1)
                {
                    grd.ActivarCelda(f, c + 2);
                    return;
                }
                DateTime fecha = Convert.ToDateTime(grd.get_Texto(f, "Fecha"));
                string sql = $"UPDATE valor_Franquicia SET id_Sucursal = {suc} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {grd.get_Texto(f, "id_Sucursal")}";
                f1.Ejecutar_Comando(sql);
                return;
            }
        }

        private void grdImpuestos_Editado(short f, short c, object a)
        {
            Franquicia f1 = new Franquicia();
            if (c == grdImpuestos.get_ColIndex("Importe"))
            {
                DateTime fecha = Convert.ToDateTime(grdImpuestos.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(grdImpuestos.get_Texto(f, "id_Sucursal"));


                string sql = $"UPDATE valor_impuestos SET Importe = {a} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {suc}";
                if (f == grdImpuestos.Rows - 1)
                {
                    sql = $"INSERT INTO valor_impuestos (Fecha, id_Sucursal, Importe) VALUES ('{fecha:yyyy-MM-dd}', {suc}, {a.ToString().Replace(",", ".")})";
                    grdImpuestos.AgregarFila();
                    grdImpuestos.set_Texto(f + 1, "Fecha", fecha.ToString("dd/MM/yyyy"));

                }
                f1.Ejecutar_Comando(sql);
                grdImpuestos.set_Texto(f, c, a);
                grdImpuestos.ActivarCelda(f + 1, 1);
                return;
            }
            if (c == grdImpuestos.get_ColIndex("Fecha"))
            {
                DateTime fecha = Convert.ToDateTime(a);
                grdImpuestos.set_Texto(f, c, fecha);
                if (f == grdImpuestos.Rows - 1)
                {
                    grdImpuestos.ActivarCelda(f, c + 1);
                    return;
                }
                int suc = Convert.ToInt32(grdImpuestos.get_Texto(f, "id_Sucursal"));
                string sql = $"UPDATE valor_impuestos SET Fecha = '{fecha:yyyy-MM-dd}' WHERE id_Sucursal = {suc} AND Fecha = '{grdImpuestos.get_Texto(f, "Fecha"):yyyy-MM-dd}'";
                f1.Ejecutar_Comando(sql);
                return;
            }
            if (c == grdImpuestos.get_ColIndex("id_Sucursal"))
            {
                int suc = Convert.ToInt32(a);
                Sucursales s = new Sucursales();
                string nombre = s.Dato_Generico("SELECT Nombre FROM Sucursales WHERE id = " + suc).ToString();
                grdImpuestos.set_Texto(f, c, suc);
                grdImpuestos.set_Texto(f, c + 1, nombre);
                if (f == grdImpuestos.Rows - 1)
                {
                    grdImpuestos.ActivarCelda(f, c + 2);
                    return;
                }
                DateTime fecha = Convert.ToDateTime(grdImpuestos.get_Texto(f, "Fecha"));
                string sql = $"UPDATE valor_impuestos SET id_Sucursal = {suc} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {grdImpuestos.get_Texto(f, "id_Sucursal")}";
                f1.Ejecutar_Comando(sql);
                return;
            }
        }

        private void grdGastos_Editado(short f, short c, object a)
        {
            Franquicia f1 = new Franquicia();
            if (c == grdGastos.get_ColIndex("Importe"))
            {
                DateTime fecha = Convert.ToDateTime(grdGastos.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(grdGastos.get_Texto(f, "id_Sucursal"));


                string sql = $"UPDATE valor_gasto SET Importe = {a} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {suc}";
                if (f == grdGastos.Rows - 1)
                {
                    sql = $"INSERT INTO valor_gasto (Fecha, id_Sucursal, Importe) VALUES ('{fecha:yyyy-MM-dd}', {suc}, {a.ToString().Replace(",", ".")})";
                    grdGastos.AgregarFila();
                    grdGastos.set_Texto(f + 1, "Fecha", fecha.ToString("dd/MM/yyyy"));

                }
                f1.Ejecutar_Comando(sql);
                grdGastos.set_Texto(f, c, a);
                grdGastos.ActivarCelda(f + 1, 1);
                return;
            }
            if (c == grdGastos.get_ColIndex("Fecha"))
            {
                DateTime fecha = Convert.ToDateTime(a);
                grdGastos.set_Texto(f, c, fecha);
                if (f == grdGastos.Rows - 1)
                {
                    grdGastos.ActivarCelda(f, c + 1);
                    return;
                }
                int suc = Convert.ToInt32(grdGastos.get_Texto(f, "id_Sucursal"));
                string sql = $"UPDATE valor_gasto SET Fecha = '{fecha:yyyy-MM-dd}' WHERE id_Sucursal = {suc} AND Fecha = '{grdGastos.get_Texto(f, "Fecha"):yyyy-MM-dd}'";
                f1.Ejecutar_Comando(sql);
                return;
            }
            if (c == grdGastos.get_ColIndex("id_Sucursal"))
            {
                int suc = Convert.ToInt32(a);
                Sucursales s = new Sucursales();
                string nombre = s.Dato_Generico("SELECT Nombre FROM Sucursales WHERE id = " + suc).ToString();
                grdGastos.set_Texto(f, c, suc);
                grdGastos.set_Texto(f, c + 1, nombre);
                if (f == grdGastos.Rows - 1)
                {
                    grdGastos.ActivarCelda(f, c + 2);
                    return;
                }
                DateTime fecha = Convert.ToDateTime(grdGastos.get_Texto(f, "Fecha"));
                string sql = $"UPDATE valor_gasto SET id_Sucursal = {suc} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {grdGastos.get_Texto(f, "id_Sucursal")}";
                f1.Ejecutar_Comando(sql);
                return;
            }
        }

        private void grdCargasSociales_Editado(short f, short c, object a)
        {
            Franquicia f1 = new Franquicia();
            if (c == grdCargasSociales.get_ColIndex("Importe"))
            {
                DateTime fecha = Convert.ToDateTime(grdCargasSociales.get_Texto(f, "Fecha"));
                int suc = Convert.ToInt32(grdCargasSociales.get_Texto(f, "id_Sucursal"));


                string sql = $"UPDATE valor_cargassociales SET Importe = {a} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {suc}";
                if (f == grdCargasSociales.Rows - 1)
                {
                    sql = $"INSERT INTO valor_cargassociales (Fecha, id_Sucursal, Importe) VALUES ('{fecha:yyyy-MM-dd}', {suc}, {a.ToString().Replace(",", ".")})";
                    grdCargasSociales.AgregarFila();
                    grdCargasSociales.set_Texto(f + 1, "Fecha", fecha.ToString("dd/MM/yyyy"));

                }
                f1.Ejecutar_Comando(sql);
                grdCargasSociales.set_Texto(f, c, a);
                grdCargasSociales.ActivarCelda(f + 1, 1);
                return;
            }
            if (c == grdCargasSociales.get_ColIndex("Fecha"))
            {
                DateTime fecha = Convert.ToDateTime(a);
                grdCargasSociales.set_Texto(f, c, fecha);
                if (f == grdCargasSociales.Rows - 1)
                {
                    grdCargasSociales.ActivarCelda(f, c + 1);
                    return;
                }
                int suc = Convert.ToInt32(grdCargasSociales.get_Texto(f, "id_Sucursal"));
                string sql = $"UPDATE valor_cargassociales SET Fecha = '{fecha:yyyy-MM-dd}' WHERE id_Sucursal = {suc} AND Fecha = '{grdCargasSociales.get_Texto(f, "Fecha"):yyyy-MM-dd}'";
                f1.Ejecutar_Comando(sql);
                return;
            }
            if (c == grdCargasSociales.get_ColIndex("id_Sucursal"))
            {
                int suc = Convert.ToInt32(a);
                Sucursales s = new Sucursales();
                string nombre = s.Dato_Generico("SELECT Nombre FROM Sucursales WHERE id = " + suc).ToString();
                grdCargasSociales.set_Texto(f, c, suc);
                grdCargasSociales.set_Texto(f, c + 1, nombre);
                if (f == grdCargasSociales.Rows - 1)
                {
                    grdCargasSociales.ActivarCelda(f, c + 2);
                    return;
                }
                DateTime fecha = Convert.ToDateTime(grdCargasSociales.get_Texto(f, "Fecha"));
                string sql = $"UPDATE valor_cargassociales SET id_Sucursal = {suc} WHERE Fecha = '{fecha:yyyy-MM-dd}' AND id_Sucursal = {grdCargasSociales.get_Texto(f, "id_Sucursal")}";
                f1.Ejecutar_Comando(sql);
                return;
            }
        }
    }
}
