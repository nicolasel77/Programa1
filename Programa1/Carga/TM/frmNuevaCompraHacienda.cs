namespace Programa1.Carga.TM
{
    using Microsoft.Office.Core;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmNuevaCompraHacienda : Form
    {
        clsTM tm = new clsTM();

        internal clsTM._Factura_Hacienda fc = new clsTM._Factura_Hacienda();


        public frmNuevaCompraHacienda()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Plazo", typeof(Int16));
            dt.Columns.Add("Vencimiento", typeof(DateTime));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Factura", typeof(long));

            grd.MostrarDatos(dt, true, true);

            grd.set_ColW(0, 60);
            grd.set_ColW(1, 40);
            grd.set_ColW(2, 60);
            grd.set_ColW(3, 40);
            grd.set_ColW(4, 100);
            grd.set_ColW(5, 100);

            grd.ActivarCelda(1, 0);

            int[] i = { 112 };
            grd.TeclasManejadas = i;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grd_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 0:
                    //Fecha
                    grd.set_Texto(f, c, a);
                    grd.ActivarCelda(f, c + 1);

                    fc.Fecha = Convert.ToDateTime(a);

                    break;
                case 1:
                    //Plazo
                    DateTime fecha = fc.Fecha.AddDays(Convert.ToInt16(a));

                    grd.set_Texto(f, c, a);
                    grd.set_Texto(f, c + 1, fecha);
                    grd.ActivarCelda(f, c + 2);

                    fc.Plazo = Convert.ToInt32(a);

                    break;
                case 3:
                    //ID Consignatario
                    string nc = tm.Nombre_SubTipo(12, Convert.ToInt32(a));
                    if (nc.Length > 0)
                    {
                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, c + 1, nc);

                        grd.ActivarCelda(f, c + 2);

                        fc.ID_Consignatarios = Convert.ToInt32(a);
                    }
                    else
                    {
                        grd.ErrorEnTxt();
                    }
                    break;
                case 5:
                    // Factura
                    grd.set_Texto(f, c, a);

                    fc.Factura = Convert.ToInt64(a);

                    break;
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            // Si estan todos los valores de fc asignados guardar la factura
            if (fc.Fecha.Ticks == 0)
            {
                MessageBox.Show("Debe ingresar la fecha.");
                grd.ActivarCelda(1, 0);
                return;
            }
            if (fc.Plazo == 0)
            {
                MessageBox.Show("Debe ingresar el plazo.");
                grd.ActivarCelda(1, 1);
                return;
            }
            if (fc.ID_Consignatarios == 0)
            {
                MessageBox.Show("Debe ingresar el consignatario.");
                grd.ActivarCelda(1, 3);
                return;
            }
            if (fc.Factura == 0)
            {
                MessageBox.Show("Debe ingresar el número de factura.");
                grd.ActivarCelda(1, 5);
                return;
            }

            int nid = tm.Ultimo_ID("Hacienda_Compras");

            tm.Guardar_FacturaHacienda(fc);

            int nid2 = tm.Ultimo_ID("Hacienda_Compras");

            if (nid == nid2)
            {
                MessageBox.Show("Hubo un error al ingresar el dato");
                return;
            }
            fc.ID = nid2;
            this.Hide();

        }

        private void grd_KeyUp(object sender, short e)
        {
            // Ayuda
            if (e == 112)
            {                
                string tabla = "Consignatarios";
                frmAyuda fr = new frmAyuda();
                fr.Tabla = tabla;


                fr.ShowDialog();
                if (fr.ID_Seleccionado != 0)
                {
                    grd.set_Texto(1, 3, fr.ID_Seleccionado);
                    grd.set_Texto(1, 4, fr.Nombre_Seleccionado);
                    grd.ActivarCelda(1, 5);
                }                
            }
        }
    }
}
