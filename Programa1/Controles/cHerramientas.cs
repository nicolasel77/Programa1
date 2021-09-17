namespace Programa1.Controles
{
    using System;
    using System.Windows.Forms;
  
    public partial class cHerramientas : UserControl
    {
        public cHerramientas()
        {
            InitializeComponent();
        }
        public int vi { get; set; }

        public enum iopciones 
        {
                fecha = 1,
                suc = 2,
                nada =3,
                prov = 4,
                prod = 5
        }
        public iopciones Siopciones;

        private void rdFecha_CheckedChanged(object sender, EventArgs e)
        {
            rdSuc.Checked = false;
            rdNada.Checked = false;
            rdProv.Checked = false;
            rdProd.Checked = false;
            vi = 1;
        }

        private void rdSuc_CheckedChanged(object sender, EventArgs e)
        {
            rdFecha.Checked = false;
            rdNada.Checked = false;
            rdProv.Checked = false;
            rdProd.Checked = false;
            vi = 2;
        }

        private void rdNada_CheckedChanged(object sender, EventArgs e)
        {
            rdSuc.Checked = false;
            rdFecha.Checked = false;
            rdProv.Checked = false;
            rdProd.Checked = false;
            vi = 3;
        }

        private void rdProv_CheckedChanged(object sender, EventArgs e)
        {
            rdSuc.Checked = false;
            rdFecha.Checked = false;
            rdNada.Checked = false;
            rdProd.Checked = false;
            vi = 4;
        }

        private void rdProd_CheckedChanged(object sender, EventArgs e)
        {
            rdSuc.Checked = false;
            rdFecha.Checked = false;
            rdNada.Checked = false;
            rdProv.Checked = false;
            vi = 5;
        }

        
    }
}
