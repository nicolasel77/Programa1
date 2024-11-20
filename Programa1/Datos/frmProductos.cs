namespace Programa1.Datos
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmProductos : Form
    {
        private Productos prods = new Productos();

        private DataTable dt;

        private const byte cId = 0;
        private const byte cTipo = 1;
        private const byte cDescripcion = 2;
        private const byte cNombre = 3;
        private const byte cVer = 4;
        private const byte cImprimir = 5;
        private const byte cPesable = 6;
        private const byte cMultiplicador = 7;
        private const byte cResumirPorVenta = 2;
        private const byte cTiene_Estadistica = 3;
        private const byte cOrden= 8;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            //Tipo Producto
            //Datos
            dt = prods.Tipo.Datos_Vista("","Id, Nombre, ResumirPorVenta, Tiene_Estadistica");
            grdTipo.MostrarDatos(dt, true);
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdTipo.TeclasManejadas = n;

            //Formato
            grdTipo.set_ColW(0, 40);

            //Productos
            //Datos
            dt = prods.Datos();
            grdProductos.MostrarDatos(dt, true);
            //Formato
            grdProductos.set_ColW(cId, 40);
            grdProductos.TeclasManejadas = n;
        }


        #region " Tipo Productos "

        private void GrdTipo_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdTipo.get_Texto(f, 0));

            switch (c)
            {
                case 0: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id de un Tipo.");
                    }
                    else
                    {
                        prods.Tipo.ID = Convert.ToInt32(a);
                        if (prods.Tipo.Existe() == true)
                        {
                            Mensaje($"El Tipo '{a.ToString()}' ya existe.");
                            grdTipo.ErrorEnTxt();
                        }
                        else
                        {
                            grdTipo.set_Texto(f, c, a);
                            prods.Tipo.Agregar();
                            grdTipo.AgregarFila();
                            grdTipo.ActivarCelda(f, 1);
                            grdTipo.set_Texto(f, cResumirPorVenta, 1);
                            grdTipo.set_Texto(f, cTiene_Estadistica, 1);
                        }
                    }
                    break;

                case 1: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.Tipo.ID = i;
                        prods.Tipo.Nombre = a.ToString();
                        grdTipo.set_Texto(f, c, a);
                        prods.Tipo.Actualizar();
                        grdTipo.ActivarCelda(f, c + 1);
                    }
                    break;
                case cResumirPorVenta: // ResumirPorVenta
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.Tipo.ID = i;
                        prods.Tipo.ResumirPorVenta = (bool) a;
                        grdTipo.set_Texto(f, c, a);
                        prods.Tipo.Actualizar("ResumirPorVenta", a);
                        grdTipo.ActivarCelda(f , c + 1);
                    }
                    break;
                case cTiene_Estadistica: // Tiene_Estadistica
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdTipo.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.Tipo.ID = i;
                        prods.Tipo.Tiene_Estadistica = (bool)a;
                        grdTipo.set_Texto(f, c, a);
                        prods.Tipo.Actualizar("Tiene_Estadistica", a);
                        grdTipo.ActivarCelda(f + 1, c);
                    }
                    break;
            }
        }

        private void GrdTipo_CambioFila(short Fila)
        {
            prods.Tipo.ID = Convert.ToInt32(grdTipo.get_Texto(Fila, 0));
            prods.Tipo.Nombre = grdTipo.get_Texto(Fila, 1).ToString();
        }

        private void GrdTipo_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                int f = grdTipo.Row;
                if (f == grdTipo.Rows - 1)
                {
                    grdTipo.ActivarCelda(1, grdTipo.Col);
                }
                else
                {
                    grdTipo.ActivarCelda(f + 1, grdTipo.Col);
                }
            }
        }

        private void GrdTipo_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el item '{grdTipo.get_Texto(grdTipo.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdTipo.get_Texto(grdTipo.Row, 0)) != 0)
                    {
                        prods.Tipo.ID = Convert.ToInt32(grdTipo.get_Texto(grdTipo.Row, 0));
                        prods.Tipo.Borrar();
                        grdTipo.BorrarFila(grdTipo.Row);
                    }

                }
            }
        }

        #endregion


        #region " Productos 

        private void GrdProductos_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grdProductos.get_Texto(f, 0));

            switch (c)
            {
                case cId: // Id
                    if (i != 0)
                    {
                        Mensaje("Error: no se puede cambiar el Id.");
                    }
                    else
                    {
                        prods.ID = Convert.ToInt32(a);
                        if (prods.Existe() == true)
                        {
                            Mensaje($"El producto '{a}' ya existe.");
                            grdProductos.ErrorEnTxt();
                        }
                        else
                        {
                            prods.Agregar();
                            grdProductos.set_Texto(f, c, a);
                            grdProductos.AgregarFila();
                            grdProductos.ActivarCelda(f, cTipo);
                        }
                    }
                    break;
                case cTipo: // Tipo
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, cId);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Tipo.ID = Convert.ToInt32(a);
                        if (prods.Tipo.Existe() == true)
                        {
                            prods.Actualizar();
                            grdProductos.set_Texto(f, c, a);
                            grdProductos.set_Texto(f, c + 1, prods.Tipo.Nombre);
                            grdProductos.ActivarCelda(f, cNombre);
                        }
                        else
                        {
                            Mensaje($"No se encontro el tipo '{a.ToString()}'.");
                            grdProductos.ErrorEnTxt();
                        }
                    }
                    break;
                case cNombre: // Nombre
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, cId);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Nombre = a.ToString();
                        prods.Actualizar();
                        grdProductos.set_Texto(f, c, a);
                        grdProductos.ActivarCelda(f, cVer);
                    }
                    break;
                case cVer: // Ver
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Ver = bool.Parse(a.ToString());
                        grdProductos.set_Texto(f, c, a);
                        prods.Actualizar();
                        grdProductos.ActivarCelda(f, 5);
                    }
                    break;
                case cImprimir: // Imp
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Imprimir = bool.Parse(a.ToString());
                        grdProductos.set_Texto(f, c, a);
                        prods.Actualizar();
                        grdProductos.ActivarCelda(f, 6);
                    }
                    break;
                case cPesable: // Pesable
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Pesable = bool.Parse(a.ToString());
                        grdProductos.set_Texto(f, c, a);
                        prods.Actualizar();
                        grdProductos.ActivarCelda(f, 7);
                    }
                    break;
                case cMultiplicador: // Multiplicador
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Multiplicador = Convert.ToInt32(a);
                        grdProductos.set_Texto(f, c, a);
                        prods.Actualizar();
                        grdProductos.ActivarCelda(f + 1, 0);
                    }
                    break;
                case cOrden: // Orden
                    if (i == 0)
                    {
                        Mensaje("Debe ingresar el Id primero");
                        grdProductos.ActivarCelda(f, 0);
                    }
                    else
                    {
                        prods.ID = i;
                        prods.Orden = Convert.ToInt32(a);
                        grdProductos.set_Texto(f, c, a);
                        prods.Actualizar();
                        grdProductos.ActivarCelda(f + 1, 0);
                    }
                    break;
                    //case cResumirPorVenta: // ResumirPorVenta
                    //    if (i == 0)
                    //    {
                    //        Mensaje("Debe ingresar el Id primero");
                    //        grdProductos.ActivarCelda(f, 0);
                    //    }
                    //    else
                    //    {
                    //        prods.ID = i;
                    //        prods.Multiplicador = Convert.ToInt32(a);
                    //        grdProductos.set_Texto(f, c, a);
                    //        prods.Actualizar();
                    //        grdProductos.ActivarCelda(f + 1, 0);
                    //    }
                    //    break;
            }
        }

        private void GrdProductos_KeyUp(object sender, short e)
        {
            // F12
            if (e == 123 | e == 46)
            {
                if (MessageBox.Show($"¿Esta segura/o de borrar el producto '{grdProductos.get_Texto(grdProductos.Row, 1).ToString()}' ?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(grdProductos.get_Texto(grdProductos.Row, 0)) != 0)
                    {
                        prods.ID = Convert.ToInt32(grdProductos.get_Texto(grdProductos.Row, 0));
                        prods.Borrar();
                        grdProductos.BorrarFila(grdProductos.Row);
                    }

                }
            }
        }

        private void GrdProductos_CambioFila(short Fila)
        {
            // 0 int Id 
            // 1 int Tipo 
            // 2 Descripcion
            // 3 string Nombre 
            // 4 bool Ver
            // 5 bool Imprimir
            // 6 bool Pesable
            // 7 int Multiplicador
            // 8 int Orden
            prods.ID = Convert.ToInt32(grdProductos.get_Texto(Fila, 0));
            prods.Tipo.ID = Convert.ToInt32(grdProductos.get_Texto(Fila, 1));
            prods.Nombre = grdProductos.get_Texto(Fila, 3).ToString();
            prods.Ver = bool.Parse(grdProductos.get_Texto(Fila, 4).ToString());
            prods.Imprimir = bool.Parse(grdProductos.get_Texto(Fila, 5).ToString());
            prods.Pesable = bool.Parse(grdProductos.get_Texto(Fila, 6).ToString());
            prods.Multiplicador = Convert.ToInt32(grdProductos.get_Texto(Fila, 7));
            prods.Orden = Convert.ToInt32(grdProductos.get_Texto(Fila, 8));
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    grdProductos.MostrarDatos(prods.Datos_Vista($"Nombre like '%{i}%' OR Id={i}"));
                }
                else
                {
                    grdProductos.MostrarDatos(prods.Datos_Vista($"Nombre like '%{txtBuscar.Text}%'"));
                }
            }
            else
            {
                grdProductos.MostrarDatos(prods.Datos_Vista());
            }
            
        }

        #endregion 


        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }
        private void TiMensaje_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }

        #endregion


    }
}
