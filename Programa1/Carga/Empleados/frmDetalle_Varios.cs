namespace Programa1.Carga.Empleados
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmDetalle_Varios : Form
    {
        public Retiros retiros;

        public frmDetalle_Varios()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdDetalle.TeclasManejadas = n;

        }

        public void Cargar()
        {
            retiros.Tipo.Existe();
            this.Text = retiros.Tipo.Nombre;
            retiros.Empleado.Existe();
            lblNombre.Text = retiros.Empleado.Nombre;
            lblFecha.Text = retiros.Fecha.ToString("dd/MM/yyy");
            grdDetalle.MostrarDatos(retiros.Detalle_Varios(), true, true);
            
            grdDetalle.set_ColW(0, 0);
            grdDetalle.set_ColW(1, 60);
            grdDetalle.set_ColW(2, 0);
            grdDetalle.set_ColW(3, 0);
            grdDetalle.set_ColW(4, 40);
            grdDetalle.set_ColW(5, 0);
            grdDetalle.set_ColW(6, 0);
            grdDetalle.set_ColW(7, 70);
            grdDetalle.set_Texto(0, 4, "Suc");
            grdDetalle.Columnas[7].Format = "N1";
            grdDetalle.ActivarCelda(grdDetalle.Rows - 1, 1);
        }

        private void FrmDetalle_Varios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void GrdDetalle_Editado(short f, short c, object a)
        {
            switch (grdDetalle.get_Texto(0, c))
            {
                case "Fecha":
                    retiros.Fecha = Convert.ToDateTime(a);
                    grdDetalle.set_Texto(f, c, a);
                    grdDetalle.ActivarCelda(f, 4);
                    Actualizar();
                    break;
                case "Suc":
                    retiros.Sucursal.ID = Convert.ToInt32(a);
                    if (retiros.Sucursal.Existe() == true)
                    {
                        grdDetalle.set_Texto(f, c, a);
                        grdDetalle.ActivarCelda(f, 7);
                        Actualizar();
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                    break;
                case "Importe":
                    retiros.Importe = Convert.ToSingle(a);
                    grdDetalle.set_Texto(f, c, a);
                    retiros.Actualizar();
                    
                    grdDetalle.set_Texto(f, 0, retiros.Id);
                    if (grdDetalle.EsUltimaFila()) grdDetalle.AgregarFila();
                    grdDetalle.ActivarCelda(f + 1, 1);

                    grdRetiros.set_Texto(-1, -1, grdDetalle.SumarCol(c, false));
                    break;
            }

        }

        private void Actualizar()
        {
            if (retiros.Id != 0)
            {
                retiros.Actualizar();
            }
        }

        private void GrdDetalle_CambioFila(short Fila)
        {
            retiros.Id = Convert.ToInt32(grdDetalle.get_Texto(Fila, 0));
        }

        private void GrdDetalle_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt16(Keys.Delete))
            {
                if (retiros.Id != 0)
                {
                    retiros.Borrar();
                    grdDetalle.BorrarFila();
                    grdRetiros.set_Texto(-1, -1, grdDetalle.SumarCol(grdDetalle.get_ColIndex("Importe"), false));
                }
            }
        }
    }
}
