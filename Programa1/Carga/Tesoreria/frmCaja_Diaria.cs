
namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmCaja_Diaria : Form
    {
        #region " Columnas Entradas"
        private Byte e_Id;
        private Byte e_Fecha;
        private Byte e_Tipo;
        private Byte e_Subtipo;
        private Byte e_Descripcion;
        private Byte e_Importe;
        private Byte e_Grupo;
        private Byte e_Es_Entrega;
        private Byte e_Tabla;

        #endregion

        private Entradas cd_E = new Entradas();

        public frmCaja_Diaria()
        {
            InitializeComponent();
        }
        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
            e_Id = Convert.ToByte(grdEntradas.get_ColIndex("Id"));
            e_Fecha = Convert.ToByte(grdEntradas.get_ColIndex("Fecha"));
            e_Tipo = Convert.ToByte(grdEntradas.get_ColIndex("ID_TipoEntrada"));
            e_Subtipo = Convert.ToByte(grdEntradas.get_ColIndex("ID_SubTipoEntrada"));
            e_Descripcion = Convert.ToByte(grdEntradas.get_ColIndex("Descripcion"));
            e_Importe = Convert.ToByte(grdEntradas.get_ColIndex("Importe"));
            e_Grupo = Convert.ToByte(grdEntradas.get_ColIndex("Grupo"));
            e_Es_Entrega = Convert.ToByte(grdEntradas.get_ColIndex("Es_Entrega"));
            e_Tabla = Convert.ToByte(grdEntradas.get_ColIndex("Tabla"));
            Fromato_Entradas();

        }

        private void frmCaja_Diaria_Resize(object sender, EventArgs e)
        {
            if (splPrincipal.Width != 0) { splPrincipal.SplitterDistance = (splPrincipal.Width - 212); }
        }


        private void Cargar_Datos()
        {
            grdEntradas.MostrarDatos(cd_E.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            Fromato_Entradas();

            Totales();
        }

        private void Fromato_Entradas()
        {
            grdEntradas.set_ColW(e_Id, 0);
            grdEntradas.set_ColW(e_Fecha, 0);
            grdEntradas.set_ColW(e_Tipo, 50);
            grdEntradas.set_ColW(e_Tipo + 1, 90);
            grdEntradas.set_ColW(e_Subtipo, 50);
            grdEntradas.set_ColW(e_Descripcion, 120);
            grdEntradas.set_ColW(e_Importe, 90);
            grdEntradas.set_ColW(e_Grupo, 0);
            grdEntradas.set_ColW(e_Es_Entrega, 0);
            grdEntradas.set_ColW(e_Tabla, 0);

            grdEntradas.set_Texto(0, e_Tipo, "Tipo");
            grdEntradas.set_Texto(0, e_Subtipo, "SubTipo");

            grdEntradas.Columnas[e_Importe].Style.Format = "N1";
        }

        private void Totales()
        {
            Double t = grdEntradas.SumarCol(e_Importe, false);
            lblTEntrada.Text = "Total Entradas: " + t.ToString("C1");
            lblSEntradas.Text = t.ToString("C1");

            double Sa = cd_E.Total_AFecha(mntFecha.SelectionStart.AddDays(-1));

            lblSSantEntradas.Text = Sa.ToString("C1");

        }

        private void mntFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cargar_Datos();
        }

        private void grdEntradas_Editado(short f, short c, object a)
        {
            cd_E.ID = Convert.ToInt32(grdEntradas.get_Texto(f, e_Id));
            switch (c)
            {
                case 2: //Tipo
                    cd_E.TE.Id_Tipo = Convert.ToInt32(a);
                    if (cd_E.TE.Existe() == true)
                    {
                        grdEntradas.set_Texto(f, c, a);
                        grdEntradas.set_Texto(f, c + 1, cd_E.TE.Nombre);
                        grdEntradas.ActivarCelda(f, e_Subtipo);

                    }
                    break;

                case 4: //SubTipo
                    cd_E.TE.Id_Tipo = Convert.ToInt32(a);
                    if (cd_E.TE.Existe() == true)
                    {
                        grdEntradas.set_Texto(f, c, a);
                        grdEntradas.set_Texto(f, c + 1, cd_E.TE.Nombre);
                        grdEntradas.ActivarCelda(f, e_Subtipo);

                    }
                    break;
            }
        }
    }
}
