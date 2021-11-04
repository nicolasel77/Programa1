namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Windows.Forms;

    public partial class frmDetalle_Venta : Form
    {
        Detalle_Venta Detalle_Venta = new Detalle_Venta();
        public int Id_Venta;
        public frmDetalle_Venta()
        {
            InitializeComponent();
            int[] n = { 27, 46 };
            grdDetalle.TeclasManejadas = n;
        }

        public void cargar_id_Venta()
        {Detalle_Venta.Id_Venta = Id_Venta;}

        private void frmDetalle_Venta_Load(object sender, EventArgs e)
        {
            grdDetalle.MostrarDatos(Detalle_Venta.Datos_Vista(filtro: $"Id_Venta = {Id_Venta}", Orden: "Id"), true, true);
            grdDetalle.AutosizeAll();
            grdDetalle.set_ColW(0, 0);
            grdDetalle.set_ColW(1, 0);
            grdDetalle.set_ColW(2, 350);
        }

        private void grdDetalle_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 2:
                    if (Detalle_Venta.ID < 1)
                    {
                        grdDetalle.set_Texto(f, c, a);
                        Detalle_Venta.Descripcion = a.ToString();
                        Detalle_Venta.Agregar();

                        grdDetalle.AgregarFila();
                        grdDetalle.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        grdDetalle.set_Texto(f, c, a);
                        Detalle_Venta.Descripcion = a.ToString();
                        Detalle_Venta.Actualizar();
                        grdDetalle.ActivarCelda(f + 1, c);
                    }
                    break;
            }

        }

        private void grdDetalle_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                        Detalle_Venta.ID = Convert.ToInt32(grdDetalle.get_Texto(grdDetalle.Row, 0));
                    if (Detalle_Venta.ID > 0)
                    { 
                        Detalle_Venta.Borrar();
                        grdDetalle.BorrarFila(grdDetalle.Row);
                        grdDetalle_CambioFila(Convert.ToByte(grdDetalle.Row));
                    }
                    break;
            }
        }

        private void grdDetalle_CambioFila(short Fila)
        {
            Detalle_Venta.ID = Convert.ToInt32(grdDetalle.get_Texto(Fila, 0));
            Detalle_Venta.Descripcion = grdDetalle.get_Texto(Fila, 2).ToString();
        }

        private void frmDetalle_Venta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
        }
    }
}
