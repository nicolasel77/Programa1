namespace Programa1.Carga.Tesoreria
{
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

    public partial class frmSubir_Ajustes : Form
    {
        private Tarjetas tarjetas = new Tarjetas();
        private Tipos_Tarjeta t_tarjetas = new Tipos_Tarjeta();
        private Leer_Tarjetas leer = new Leer_Tarjetas();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();
        public DateTime Semana;

        public frmSubir_Ajustes()
        {
            InitializeComponent();
        }

        private void frmSubir_Ajustes_Load(object sender, EventArgs e)
        {
            DataTable dt;
            dt = tarjetas.Datos_ajustes("Id = 0");
            grdTarjetas.MostrarDatos(dt);

        }
    }
}
