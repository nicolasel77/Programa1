namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Varios;
    using System;
    using System.Windows.Forms;

    public partial class frmListas_Carga : Form
    {
        Listas_Carga listas = new Listas_Carga();

        class t_Col
        {
            //ID, ID_Lista, Nombre, Orden, Producto, Nombre_Producto
            public const int ID = 0;
            public const int ID_Lista = 1;
            public const int Nombre = 2;
            public const int Orden = 3;
            public const int Producto = 4;
            public const int Nombre_Producto = 5;
        }

        public frmListas_Carga()
        {
            InitializeComponent();
            int[] n = { 8, 46};
            grd.TeclasManejadas = n;
        }

        private void frmListas_Carga_Load(object sender, EventArgs e)
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstListas, listas.Lista.Datos());
            Cargar();
        }

        private void Cargar()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
                        
            if (lstListas.SelectedIndex > -1) { listas.Lista.ID = h.Codigo_Seleccionado(lstListas.Text); }

            grd.MostrarDatos(listas.Datos(), true);
            grd.set_ColW(t_Col.ID, 0);
            grd.set_ColW(t_Col.ID_Lista, 30);
            grd.set_ColW(t_Col.Nombre, 100);
            grd.set_ColW(t_Col.Orden, 30);
            grd.set_ColW(t_Col.Producto, 60);
            grd.set_ColW(t_Col.Nombre_Producto, 120);
        }

        private void grd_Editado(short f, short c, object a)
        {
            int i = (int)grd.get_Texto(f, t_Col.ID);
            if (grd.get_Texto(grd.Row, 0).ToString() != "")
            {
                listas.ID = Convert.ToInt32(grd.get_Texto(grd.Row, 0));
            }
            else 
            {
                listas.ID = Convert.ToInt32("0");
            }
            switch (c)
            {
                case t_Col.ID_Lista:
                    if (listas.Lista.Existe(Convert.ToInt32(a)) == true)
                    {
                        if (i != 0) { listas.Actualizar("ID_Lista", a); }
                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, c + 1, listas.Lista.Nombre);
                        grd.ActivarCelda(f, t_Col.Orden);
                    }
                    break;
                case t_Col.Orden:
                    listas.Orden = Convert.ToInt32(a);
                    if (i != 0) { listas.Actualizar("Orden", a);  }

                    grd.set_Texto(f, c, a);
                    grd.ActivarCelda(f, t_Col.Producto);
                    break;
                case t_Col.Producto:
                    if (listas.Producto.Existe(Convert.ToInt32(a)) == true)
                    {
                        if (i == 0)
                        {
                            listas.Agregar_NoID("ID_Lista", listas.Lista.ID);
                            listas.Actualizar("Orden", listas.Orden);

                            grd.AgregarFila();
                            listas.Orden = listas.Orden + 1;
                            grd.set_Texto(f + 1, t_Col.ID_Lista, listas.Lista.ID);
                            grd.set_Texto(f + 1, t_Col.Nombre, listas.Lista.Nombre);
                            grd.set_Texto(f + 1, t_Col.Orden, listas.Orden);
                        }

                        listas.Actualizar("Producto", a);

                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, t_Col.Nombre_Producto, listas.Producto.Nombre);
                        grd.set_Texto(f, t_Col.ID, listas.ID);

                        grd.ActivarCelda(f + 1, t_Col.Producto);
                    }
                    break;
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtAgregar.Text;
            if (nuevoNombre.Length != 0)
            {
                listas.Lista.Nombre = nuevoNombre;
                listas.Lista.ID = listas.Lista.Max_ID() + 1;
                listas.Lista.Agregar();
                lstListas.Items.Add($"{listas.Lista.ID}. {nuevoNombre}");
                txtAgregar.Text = "";
            }
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (lstListas.SelectedIndex != -1)
            {
                if (MessageBox.Show($"¿Seguro que quiere borrar el ítem {lstListas.Text}?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Herramientas.Herramientas h = new Herramientas.Herramientas();
                    listas.Lista.ID = h.Codigo_Seleccionado(lstListas.Text);
                    listas.Lista.Borrar_Hijos();
                    listas.Lista.Borrar();
                    lstListas.Items.RemoveAt(lstListas.SelectedIndex);
                }
            }
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void grd_KeyUp(object sender, short e)
        {
                switch (Convert.ToInt32(e))
                {
                    case 46: //Delete
                        if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            if (Convert.ToInt32(grd.get_Texto(grd.Row, 0)) != 0)
                            {
                                listas.ID = Convert.ToInt32(grd.get_Texto(grd.Row, 0));
                                listas.Borrar();
                                grd.BorrarFila(grd.Row);
                            }
                        }
                        break;
            }
        }
    }
}
