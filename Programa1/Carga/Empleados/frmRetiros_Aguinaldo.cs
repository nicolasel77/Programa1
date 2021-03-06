﻿namespace Programa1.Carga.Empleados
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmRetiros_Aguinaldo : Form
    {
        public Retiros retiros;

        public frmRetiros_Aguinaldo()
        {
            InitializeComponent();

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdDetalle.TeclasManejadas = n;

        }

        public void Cargar()
        {
            retiros.Empleado.Existe();
            
            lblNombre.Text = retiros.Empleado.Nombre;
            lblFecha.Text = retiros.Fecha.ToString("dd/MM/yyy");
            lblAlta.Text = retiros.Empleado.Alta.ToString("dd/MM/yyy");
            lblAguinaldo.Text = retiros.Aguinaldo_Empleado().ToString("C1");

            grdDetalle.MostrarDatos(retiros.Retiro_Aguinaldo(), true, true);

            grdDetalle.set_ColW(0, 0);
            grdDetalle.set_ColW(1, 60);
            grdDetalle.set_ColW(2, 0);
            grdDetalle.set_ColW(3, 0);
            grdDetalle.set_ColW(4, 40);
            grdDetalle.set_ColW(5, 40);
            grdDetalle.set_ColW(6, 80);
            grdDetalle.set_ColW(7, 70);
            grdDetalle.set_Texto(0, 4, "Suc");
            grdDetalle.Columnas[7].Format = "N1";
            grdDetalle.ActivarCelda(grdDetalle.Rows - 1, 1);
        }

        private void FrmRetiros_Aguinaldo_KeyUp(object sender, KeyEventArgs e)
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
                        grdDetalle.ActivarCelda(f, 5);
                        Actualizar();
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                    }
                    break;
                case "Id_Tipo":
                    retiros.Tipo.ID = Convert.ToInt32(a);
                    if (retiros.Tipo.Existe() == true)
                    {
                        grdDetalle.set_Texto(f, c, a);
                        grdDetalle.set_Texto(f, c + 1, retiros.Tipo.Nombre);
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
                    
                    grdRetiros.set_Texto(-1, -1, grdDetalle.SumarCol(c, false));
                    grdRetiros.set_Texto(-1, grdRetiros.Col + 1, retiros.Aguinaldo_Saldo());
                    
                    if (grdDetalle.EsUltimaFila()) grdDetalle.AgregarFila();
                    grdDetalle.ActivarCelda(f + 1, 1);
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
                    grdRetiros.set_Texto(-1, grdRetiros.Col + 1, retiros.Aguinaldo_Saldo());
                }
            }
        }
    }
}
