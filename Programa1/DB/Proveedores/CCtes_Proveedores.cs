using Programa1.DB;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.DB.Proveedores
{    
    class CCtes_Proveedores
    {
        private Proveedores prov;
        private Compras Compra;

        public CCtes_Proveedores(int prov)
        {
            this.prov.Id = prov;
        }
    }
}
