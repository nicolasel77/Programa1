namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmValores_Recupero : Form
    {
        private readonly Recupero recu = new Recupero();
        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();
        public frmValores_Recupero()
        {
            InitializeComponent();
            h.Llenar_List(lstFrigorificos, recu.Frigorifico.Datos());
            grd.TeclasManejadas = new int[] { 13, 42, 45, 46, 107, 112 };
        }

        private void lstFrigorificos_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstFrigorificos.SelectedIndex != -1)
            {
                recu.Frigorifico.ID = h.Codigo_Seleccionado(lstFrigorificos.Text);
                h.Llenar_List(lstFechas, recu.Fechas(), "dd/MM/yyyy");
            }
        }

        private void lstFechas_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstFechas.SelectedIndex != -1)
            {
                recu.Fecha = DateTime.Parse(lstFechas.Text);
                grd.MostrarDatos(recu.Valores(), true, false);
                grd.set_Texto(0, 2, "Directo");
                grd.set_Texto(0, 3, "Mercado");
                grd.AutosizeAll();
            }
        }

        private void grd_Editado(short f, short c, object a)
        {
            if (c > 1)
            {
                grd.set_Texto(f, c, a);
                if (f == grd.Rows - 1)
                {
                    if (c == 3)
                    {
                        grd.ActivarCelda(1, 2);
                    }
                    else
                    {
                        grd.ActivarCelda(1, 3);
                    }
                }
                else
                {
                    grd.ActivarCelda(f + 1, c);
                }
            }
        }

        private void grd_KeyUp(object sender, short e)
        {
            if (e == (short)Keys.Add)
            {
                short f = (short)grd.Row;
                short c = (short)grd.Col;
                float n = 0;

                if (f > 1) { n = Convert.ToSingle(grd.get_Texto(f - 1, c)); }
                grd_Editado(f, c, n);
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (recu.Frigorifico.ID != 0)
            {
                recu.Borrar($"ID_Frigorificos={recu.Frigorifico.ID} AND Fecha='{mntFecha.SelectionStart.Date:MM/dd/yyy}'");
                recu.Fecha = mntFecha.SelectionStart.Date;

                for (int i = 1; i <= grd.Rows - 1; i++)
                {
                    recu.Producto.ID = Convert.ToInt32(grd.get_Texto(i, 0));

                    recu.Mercado = false;
                    recu.Valor = Convert.ToSingle(grd.get_Texto(i, 2));
                    recu.Agregar();

                    recu.Mercado = true;
                    recu.Valor = Convert.ToSingle(grd.get_Texto(i, 3));
                    recu.Agregar();
                }
                recu.Actualizar_Faena();
            }
        }

    }
}
