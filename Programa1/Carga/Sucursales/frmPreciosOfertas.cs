namespace Programa1.Carga
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmPreciosOfertas : Form
    {
        private Lista_Ofertas lista = new Lista_Ofertas();

        #region " Columnas "
        private Byte c_Id;
        private Byte c_Orden;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Costo;
        #endregion

        public frmPreciosOfertas()
        {
            InitializeComponent();
            Cargar();
        }

        public void Cargar()
        {
            DataTable dt = lista.Datos();

            grd.MostrarDatos(dt, true, true);
            c_Id = Convert.ToByte(grd.get_ColIndex("ID"));
            c_Orden = Convert.ToByte(grd.get_ColIndex("Orden"));
            c_IdProd = Convert.ToByte(grd.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grd.get_ColIndex("Descripcion"));
            c_Costo = Convert.ToByte(grd.get_ColIndex("Costo"));

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grd.TeclasManejadas = n;

            grd.AutosizeAll();
            grd.set_ColW(c_Id, 0);
        }
        private void CmdAceptar_Click(object sender, EventArgs e)
        {
        }

        private void Grd_CambioFila(short Fila)
        {
            lista.ID = Convert.ToInt32(grd.get_Texto(Fila, c_Id));
            lista.Orden = Convert.ToInt32(grd.get_Texto(Fila, c_Orden));
            lista.Producto.ID = Convert.ToInt32(grd.get_Texto(Fila, c_IdProd));
            lista.Descripcion = Convert.ToString(grd.get_Texto(Fila, c_Descripcion));
            lista.Costo = Convert.ToSingle(grd.get_Texto(Fila, c_Costo));
        }

        private void Grd_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 0:
                    //Orden
                    lista.Orden = Convert.ToInt32(a);
                    grd.set_Texto(f, c, a);

                    if (grd.EsUltimaFila() != true)
                    {
                        lista.Actualizar();
                        grd.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        grd.ActivarCelda(f, c_IdProd);
                    }
                    break;
                case 1:
                    //Id_Productos
                    lista.Producto.ID = Convert.ToInt32(a);
                    if (lista.Producto.Existe() == true)
                    {
                        grd.set_Texto(f, c, a);
                        grd.set_Texto(f, c_IdProd + 1, lista.Producto.Nombre);
                        if (grd.EsUltimaFila() != true)
                        {
                            lista.Actualizar();
                            grd.ActivarCelda(f + 1, c);
                        }
                        else
                        {
                            grd.ActivarCelda(f, c_Descripcion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error", "No se encontró el producto " + a);
                    }
                    break;
                case 3:
                    //Descripcion
                    lista.Descripcion = Convert.ToString(a);
                    grd.set_Texto(f, c, a);

                    if (grd.EsUltimaFila() != true)
                    {
                        lista.Actualizar();
                        grd.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        grd.ActivarCelda(f, c_Costo);
                    }
                    break;
                case 4:
                    //Costo
                    lista.Costo = Convert.ToSingle(a);
                    grd.set_Texto(f, c, a);

                    if (grd.EsUltimaFila() != true)
                    {
                        lista.Actualizar();
                        grd.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        lista.Agregar();
                        grd.set_Texto(f, c_Id, lista.Max_ID());
                        grd.AgregarFila();
                        grd.ActivarCelda(f + 1, c_Orden);
                    }
                    break;
            }
        }

        private void Grd_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Convert.ToInt32(grd.get_Texto(grd.Row, c_Orden)) != 0)
                        {
                            lista.Orden = Convert.ToInt32(grd.get_Texto(grd.Row, c_Orden));
                            lista.Borrar();
                            grd.BorrarFila(grd.Row);                            
                        }
                    }
                    break;
            }
        }
    }
}
