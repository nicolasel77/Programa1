namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;

    public partial class frmReclamos : Form
    {
        private Reclamos reclamos;
        private Herramientas h;
        public frmReclamos()
        {
            InitializeComponent();
            reclamos = new Reclamos();
            h = new Herramientas();
            Cargar_listados();
        }

        //  Carga
        private void Cargar_listados()
        {
            string filtro = "";

            h.Llenar_List(lstEntidad, reclamos.Entidades());

            if (chResueltos.Checked)
            { filtro = "Resuelto = 0"; }
            if (lstEntidad.SelectedIndex > -1)
            { h.Unir(filtro, $"Entidad = {h.Codigo_Seleccionado(lstCasos.Items[lstCasos.SelectedIndex].ToString())} "); }

            h.Llenar_List(lstCasos, reclamos.Casos(filtro));
        }

        private void Cargar()
        {
            DataTable dt = reclamos.Datos();

            txtTitulo.Text = dt.Rows[0][1].ToString();
            txtDescripcion.Text = dt.Rows[0][2].ToString(); ;
            txtDesarrollo.Text = dt.Rows[0][3].ToString(); ;
            txtResolucion.Text = dt.Rows[0][4].ToString(); ;
            dtpInicio.Value = Convert.ToDateTime(dt.Rows[0][5]);
            dtpFinal.Value = Convert.ToDateTime(dt.Rows[0][6]);
        }


        //  Edición

        private void Guardar_cambios()
        {
            if (reclamos.ID > 0)
            {
                reclamos.vTitulo = txtTitulo.Text;
                reclamos.vDescripcion = txtDescripcion.Text;
                reclamos.vDesarrollo = txtDesarrollo.Text;
                reclamos.vResolucion = txtResolucion.Text;
                reclamos.vFecha_ini = dtpInicio.Value;
                reclamos.vFecha_fin = dtpFinal.Value;
                if (reclamos.vResolucion.Length > 5)
                { reclamos.vResuelto = 1; }
                else { reclamos.vResuelto = 0; }
                reclamos.vEntidad = 0;

                reclamos.Actualizar();
            }
            else if (txtTitulo.Text.Length > 0)
            {
                reclamos.vTitulo = txtTitulo.Text;
                reclamos.Agregar();
                Cargar_listados();
                string ruta = @"D:\Reclamos";
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                ruta = $@"D:\Reclamos\{reclamos.vTitulo}";
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                Guardar_cambios();
            }
        }

        private void Guardar_archivos(string[] files)
        {
            if (reclamos.ID > 0)
            {
                string ruta = $@"D:\Reclamos\{reclamos.vTitulo}";

                foreach (var f in files)
                {
                    ruta = ruta + $@"{f.Substring(f.LastIndexOf(@"\"))}";
                    Directory.Move(f, ruta);
                }
                MessageBox.Show("Se movieron los archivos a la carpeta del reclamo.");
            }
            materialDivider1.SendToBack();
            lblArrastre.SendToBack();

        }

        //  Eventos

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            Guardar_cambios();
        }

        private void chResueltos_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_listados();
        }

        private void lstEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_listados();
        }

        private void lstCasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            reclamos.ID = h.Codigo_Seleccionado(lstCasos.Items[lstCasos.SelectedIndex].ToString());
            Cargar();
        }

        private void txtDescripcion_DragEnter_1(object sender, DragEventArgs e)
        {
            materialDivider1.BringToFront();
            lblArrastre.BringToFront();
            e.Effect = DragDropEffects.All;
        }
        private void txtDescripcion_DragLeave(object sender, EventArgs e)
        {
            materialDivider1.SendToBack();
            lblArrastre.SendToBack();
        }
        private void txtDesarrollo_DragDrop(object sender, DragEventArgs e)
        {
            Guardar_archivos((string[])e.Data.GetData(DataFormats.FileDrop, false));
        }

        private void txtDescripcion_DragOver(object sender, DragEventArgs e)
        {
            materialDivider1.BringToFront();
            lblArrastre.BringToFront();
            e.Effect = DragDropEffects.All;
        }

    }
}