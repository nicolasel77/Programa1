namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Windows.Forms;
    public partial class frmImprimir_Ofertas : Form
    {
        Listas_Ofertas listas = new Listas_Ofertas();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        #region " Columnas "
        private readonly Byte c_Id;
        private readonly Byte c_Orden;
        private readonly Byte c_IdProd;
        private readonly Byte c_Nombre;
        private readonly Byte c_Tipo;
        private readonly Byte c_Descripcion;
        private readonly Byte c_Cantidad;
        private readonly Byte c_Costo;
        private readonly Byte c_Id_lista;
        #endregion
        bool cargando_lista = false;
        public frmImprimir_Ofertas()
        {
            InitializeComponent();
            h.Llenar_List(lstSucs, listas.sucdatos());
            h.Llenar_List(lstListas, listas.lista.Datos());
            grdLista.MostrarDatos(listas.Datos_Vista("ID=0"), true);

            c_Id = Convert.ToByte(grdLista.get_ColIndex("Id"));
            c_Orden = Convert.ToByte(grdLista.get_ColIndex("Orden"));
            c_IdProd = Convert.ToByte(grdLista.get_ColIndex("Id_Prod"));
            c_Nombre = Convert.ToByte(grdLista.get_ColIndex("Nombre"));
            c_Tipo = Convert.ToByte(grdLista.get_ColIndex("Tipo"));
            c_Descripcion = Convert.ToByte(grdLista.get_ColIndex("Descripcion"));
            c_Cantidad = Convert.ToByte(grdLista.get_ColIndex("Cantidad"));
            c_Costo = Convert.ToByte(grdLista.get_ColIndex("Costo"));
            c_Id_lista = Convert.ToByte(grdLista.get_ColIndex("Id_Lista"));
            Formato_Grilla();
        }
        private void frmImprimir_Ofertas_Load(object sender, EventArgs e)
        {

        }

        private void Formato_Grilla()
        {
            grdLista.set_ColW(c_Id, 0);
            grdLista.set_ColW(c_Id_lista, 0);
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            listas.lista.ID = h.Codigo_Seleccionado(lstListas.Text);
            grdLista.MostrarDatos(listas.Datos_Vista("Id_Lista = " + h.Codigo_Seleccionado(lstListas.Text)), true);
            Formato_Grilla();
            cargar_sucs();
        }

        private void cargar_sucs()
        {
            lstSucs.SelectedIndex = -1;
            cargando_lista = true;
            for (int i = 0; i <= lstSucs.Items.Count - 1; i++)
            {
                if (listas.Existe(h.Codigo_Seleccionado(lstSucs.GetItemText(lstSucs.Items[i]))) == true)
                {
                    lstSucs.SelectedIndex = i;
                }
            }
            cargando_lista = false;
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtAgregar.Text;
            if (nuevoNombre.Length != 0)
            {
                listas.lista.Nombre = nuevoNombre;
                listas.lista.Agregar();

                lstListas.Items.Add($"{listas.lista.ID}. {nuevoNombre}");
                txtAgregar.Text = "";
            }
        }

        private void grdLista_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 1://Orden
                    grdLista.set_Texto(f, c, a);
                    listas.Orden = Convert.ToInt32(a);
                    if (listas.ID > 0)
                    {
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    { grdLista.ActivarCelda(f, c + 1); }
                    break;
                case 2://Id_Prod
                    if (listas.productos.Existe(Convert.ToInt32(a)))
                    {
                        listas.productos.Buscar();
                        grdLista.set_Texto(f, c, a);
                        listas.productos.ID = Convert.ToInt32(a);
                        grdLista.set_Texto(f, c_Nombre, listas.productos.Nombre);
                        grdLista.set_Texto(f, c_Tipo, listas.productos.Tipo.Nombre);
                        if (listas.ID > 0)
                        {
                            listas.Actualizar();
                            grdLista.ActivarCelda(f + 1, c);
                        }
                        else
                        { grdLista.ActivarCelda(f, c_Descripcion); }
                    }
                    break;
                case 5://Descripcion
                    grdLista.set_Texto(f, c, a);
                    listas.descripcion = a.ToString();
                    if (listas.ID > 0)
                    {
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    { grdLista.ActivarCelda(f, c + 1); }
                    break;
                case 6://Cantidad
                    grdLista.set_Texto(f, c, a);
                    listas.cantidad = Convert.ToInt32(a);
                    if (listas.ID > 0)
                    {
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    { grdLista.ActivarCelda(f, c + 1); }
                    break;
                case 7://Costo

                    if (listas.ID > 0)
                    {
                        grdLista.set_Texto(f, c, a);
                        listas.costo = Convert.ToDouble(a);
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        if (listas.productos.ID > 0)
                        {
                            grdLista.set_Texto(f, c, a);
                            listas.costo = Convert.ToDouble(a);
                            listas.Agregar();
                            grdLista.set_Texto(f, c_Id, listas.ID);
                            grdLista.AgregarFila();
                            grdLista.ActivarCelda(f + 1, c_Orden);
                        }
                        else
                        {
                            grdLista.ActivarCelda(f, c_IdProd);
                            grdLista.ErrorEnTxt();
                        }
                    }
                    break;
            }
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
        }

        private void grdLista_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdLista.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                listas.ID = i;
                listas.Cargar_Fila();
            }
            else
            {
                listas.ID = 0;
                listas.Orden = Convert.ToInt32(grdLista.get_Texto(Fila, c_Orden));
                listas.productos.ID = Convert.ToInt32(grdLista.get_Texto(Fila, c_IdProd));
                listas.descripcion = grdLista.get_Texto(Fila, c_Descripcion).ToString();
                listas.cantidad = Convert.ToInt32(grdLista.get_Texto(Fila, c_Cantidad));
                listas.costo = Convert.ToSingle(grdLista.get_Texto(Fila, c_Costo));
            }
        }

        private void lstSucs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listas.lista.ID > 0 & cargando_lista == false)
            {
                listas.Borrar_Suc_Listas();
                string nom_suc;
                foreach (string item in lstSucs.SelectedItems)
                {
                    nom_suc = item.ToString();
                    if (nom_suc.IndexOf(".") > -1)
                    {
                        nom_suc = nom_suc.Substring(nom_suc.IndexOf(".") + 2);
                        if (nom_suc.Length > 0)
                        {
                            listas.Agregar_sucs_a_Lista(nom_suc, h.Codigo_Seleccionado(item));
                        }
                    }
                }
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            frmEditar_Suc_Ofertas frm = new frmEditar_Suc_Ofertas();
            frm.ShowDialog();
            frm.Close();
            h.Llenar_List(lstSucs, listas.sucdatos());
            cargar_sucs();
        }

    
        private void grdLista_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdLista.get_Texto(grdLista.Row, c_Id)) != 0)
                    {
                        if (listas.Fecha_Cerrada(listas.Fecha) == false)
                        {
                            if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                listas.ID = Convert.ToInt32(grdLista.get_Texto(grdLista.Row, c_Id));
                                listas.Borrar();
                                grdLista.BorrarFila(grdLista.Row);
                                grdLista_CambioFila(Convert.ToByte(grdLista.Row));
                            }
                        }
                        else
                        {
                            MessageBox.Show("La fecha se encuentra cerrada", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    break;
            }
        }
    }
}
