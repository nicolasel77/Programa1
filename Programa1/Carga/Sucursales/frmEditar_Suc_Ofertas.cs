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

    public partial class frmEditar_Suc_Ofertas : Form
    {
        Lugares_imp lugares = new Lugares_imp();
        public frmEditar_Suc_Ofertas()
        {
            InitializeComponent();
        }

        private void frmEditar_Suc_Ofertas_Load(object sender, EventArgs e)
        {
            grdLugar_Imp.MostrarDatos(lugares.Datos(), true,true);
            grdLugar_Imp.AutosizeAll();
            grdLugar_Imp.FixCols = 0;
        }

        private void grdLugar_Imp_Editado(short f, short c, object a)
        {
            if (c == 1)
            { grdLugar_Imp.set_Texto(f, c, a);
                if (lugares.ID < 0)
                {
                    lugares.Nombre = a.ToString();
                    lugares.Actualizar(); }
                else
                {
                    lugares.Nombre = a.ToString();
                    lugares.agregar();
                    grdLugar_Imp.set_Texto(f, 0, lugares.ID);
                    grdLugar_Imp.AgregarFila();
                }
                grdLugar_Imp.ActivarCelda(f, c + 1);
            }
        }

        private void grdLugar_Imp_CambioFila(short Fila)
        {
            lugares.ID = Convert.ToInt32(grdLugar_Imp.get_Texto(Fila, 0));
            lugares.Nombre = grdLugar_Imp.get_Texto(Fila, 0).ToString();
        }

        private void frmEditar_Suc_Ofertas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { this.Close(); }
            else if (e.KeyCode == Keys.Delete & lugares.ID < 0)
            {
                lugares.Borrar();
                grdLugar_Imp.BorrarFila();
                grdLugar_Imp_CambioFila(Convert.ToInt16(grdLugar_Imp.Row));
            }
        }
    }
}
