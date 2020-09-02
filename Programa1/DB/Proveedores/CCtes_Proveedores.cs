using Programa1.DB;
using Programa1.DB.Proveedores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proveedores
{    
    class CCtes_Proveedores
    {
        private Programa1.DB.Proveedores.Proveedores prov;
        private Compras Compra;

        public CCtes_Proveedores(int prov)
        {
            this.prov.Id = prov;
        }
    }
}
