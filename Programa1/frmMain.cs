namespace Programa1
{
    using Programa1.Carga;
    using Programa1.Carga.Empleados;
    using Programa1.Carga.Hacienda;
    using Programa1.Carga.Precios;
    using Programa1.Carga.Sebero;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;

    public partial class frmMain : Form
    {
        List<Form> forms = new List<Form>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Mostrar(object sender, EventArgs e)
        {
            foreach (Form f in forms)
            {
                if (f.Name.StartsWith("frm" + sender.ToString()) == true)
                {
                    f.BringToFront();
                    break;
                }

            }
        }

        private void ResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Suc")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumen_Suc");
                t.Text = "Resumen_Suc";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmResumen_Suc = new Programa1.Carga.frmResumen_Suc();
                frmResumen_Suc.MdiParent = this;
                frmResumen_Suc.Disposed += FrmResumen_Suc_Dispose;
                forms.Add(frmResumen_Suc);
                frmResumen_Suc.Show();
                frmResumen_Suc.WindowState = FormWindowState.Minimized;
                frmResumen_Suc.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmResumen_Suc_Dispose(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Resumen_Suc")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Suc")
                {
                    forms.Remove(f);
                    break;
                }
            }

        }
        private void PruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ecsel = new OpenFileDialog();
            ecsel.InitialDirectory = "D:\\Proyectos\\Excels A Importar";
            ecsel.ShowDialog();

            if (ecsel.FileName.Length > 0 )
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ecsel.FileName);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;


                Entradas en = new Entradas();
                Detalle_Entregas de = new Detalle_Entregas();

                int fila_actual = 2;
                int idviejo = 0;
                for (int i = 2; i <= 5336; i++)
                {
                    en.Fecha = Convert.ToDateTime(xlRange.Cells[i, 1].value);
                    en.TE.Id_Tipo = Convert.ToInt32(xlRange.Cells[i, 2].value);
                    en.Id_SubTipoEntrada = Convert.ToInt32(xlRange.Cells[i, 4].value);
                    en.Descripcion = Convert.ToString(xlRange.Cells[i, 5].value);
                    en.Importe = Convert.ToDouble(xlRange.Cells[i, 6].value);
                    idviejo = Convert.ToInt32(xlRange.Cells[i, 7].value);

                    en.Agregar();

                    for (int n = fila_actual; n <= 11947; n++)
                    {

                        if (idviejo == Convert.ToInt32(xlRange.Cells[n, 13].value))
                        {
                            de.ID_Entradas = en.ID;
                            de.Fecha = Convert.ToDateTime(xlRange.Cells[n, 11].value);
                            de.Importe = Convert.ToDouble(xlRange.Cells[n, 12].value);

                            de.Agregar();

                            fila_actual++;
                        }
                        else
                        {
                            break;
                        }
                    }
                } 
            }
        }

        private void FrmMail_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Mail")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmMail")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void FrmMailMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmMail")
                {
                    f.BringToFront();
                    f.Show();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmMail");
                t.Text = "Mail";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmMail = new Programa1.Mail.frmMail();
                frmMail.MdiParent = this;
                frmMail.Disposed += FrmMail_Disposed;
                forms.Add(frmMail);
                frmMail.Show();
                frmMail.WindowState = FormWindowState.Minimized;
                frmMail.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmProds_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Productos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmProductos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmProductos")
                {
                    f.BringToFront();
                    f.Show();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmProductos");
                t.Text = "Productos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmProds = new Programa1.Datos.frmProductos();
                frmProds.MdiParent = this;
                frmProds.Disposed += FrmProds_Disposed;
                forms.Add(frmProds);
                frmProds.Show();
                frmProds.WindowState = FormWindowState.Minimized;
                frmProds.WindowState = FormWindowState.Maximized;
            }
        }

        private void SucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmSucursales")
                {
                    f.Show();
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmSucursales");
                t.Text = "Sucursales";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmSucursales = new Programa1.Datos.frmSucursales();
                frmSucursales.MdiParent = this;
                frmSucursales.Disposed += FrmSucursales_Disposed;
                forms.Add(frmSucursales);
                frmSucursales.Show();
                frmSucursales.WindowState = FormWindowState.Minimized;
                frmSucursales.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmSucursales_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Sucursales")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmSucursales")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmProveedores")
                {
                    f.Show();
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmProveedores");
                t.Text = "Proveedores";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmProveedores = new Datos.frmProveedores();
                frmProveedores.MdiParent = this;
                frmProveedores.Disposed += FrmProveedores_Disposed;
                forms.Add(frmProveedores);
                frmProveedores.Show();
                frmProveedores.WindowState = FormWindowState.Minimized;
                frmProveedores.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmProveedores_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Proveedores")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmProveedores")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void StockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmStock")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmStock");
                t.Text = "Stock";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmStock = new Programa1.Carga.frmStock();
                frmStock.MdiParent = this;
                frmStock.Disposed += FrmStock_Disposed;
                forms.Add(frmStock);
                frmStock.Show();
                frmStock.WindowState = FormWindowState.Minimized;
                frmStock.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmStock_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Stock")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmStock")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void MenudenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPreciosMen")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPreciosMen");
                t.Text = "Precios Men";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrecios = new frmPreciosMen();
                frmPrecios.MdiParent = this;
                frmPrecios.Disposed += FrmPrecios_Disposed;
                forms.Add(frmPrecios);
                frmPrecios.Show();
                frmPrecios.WindowState = FormWindowState.Minimized;
                frmPrecios.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrecios_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Precios Men")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPreciosMen")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void TrasladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmTraslados")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmTraslados");
                t.Text = "Traslados";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmTraslados = new frmTraslados();
                frmTraslados.MdiParent = this;
                frmTraslados.Disposed += FrmTraslados_Disposed;
                forms.Add(frmTraslados);
                frmTraslados.Show();
                frmTraslados.WindowState = FormWindowState.Minimized;
                frmTraslados.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmTraslados_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Traslados")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmTraslados")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void VentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmVentas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmVentas");
                t.Text = "Ventas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmVentas = new frmVentas();
                frmVentas.MdiParent = this;
                frmVentas.Disposed += FrmVentas_Disposed;
                forms.Add(frmVentas);
                frmVentas.Show();
                frmVentas.WindowState = FormWindowState.Minimized;
                frmVentas.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmVentas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Ventas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmVentas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ReintegrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmReintegros")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmReintegros");
                t.Text = "Reintegros";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmReintegros = new frmReintegros();
                frmReintegros.MdiParent = this;
                frmReintegros.Disposed += FrmReintegros_Disposed;
                forms.Add(frmReintegros);
                frmReintegros.Show();
                frmReintegros.WindowState = FormWindowState.Minimized;
                frmReintegros.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmReintegros_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Reintegros")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmReintegros")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void CompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCompras")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCompras");
                t.Text = "Compras";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCompras = new frmCompras();
                frmCompras.MdiParent = this;
                frmCompras.Disposed += FrmCompras_Disposed;
                forms.Add(frmCompras);
                frmCompras.Show();
                frmCompras.WindowState = FormWindowState.Minimized;
                frmCompras.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmCompras_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Compras")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCompras")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void OfertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmOfertas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmOfertas");
                t.Text = "Ofertas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmOfertas = new frmOfertas();
                frmOfertas.MdiParent = this;
                frmOfertas.Disposed += FrmOfertas_Disposed;
                forms.Add(frmOfertas);
                frmOfertas.Show();
                frmOfertas.WindowState = FormWindowState.Minimized;
                frmOfertas.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmOfertas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Ofertas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmOfertas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void APicadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmAPicada")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmAPicada");
                t.Text = "APicada";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmAPicada = new frmAPicada();
                frmAPicada.MdiParent = this;
                frmAPicada.Disposed += FrmAPicada_Disposed;
                forms.Add(frmAPicada);
                frmAPicada.Show();
                frmAPicada.WindowState = FormWindowState.Minimized;
                frmAPicada.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmAPicada_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "APicada")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmAPicada")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmGastos_Sucursales")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmGastos_Sucursales");
                t.Text = "Gastos_Sucursales";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmGastos_Sucursales = new frmGastos_Sucursales();
                frmGastos_Sucursales.MdiParent = this;
                frmGastos_Sucursales.Disposed += FrmGastos_Sucursales_Disposed;
                forms.Add(frmGastos_Sucursales);
                frmGastos_Sucursales.Show();
                frmGastos_Sucursales.WindowState = FormWindowState.Minimized;
                frmGastos_Sucursales.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmGastos_Sucursales_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Gastos_Sucursales")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmGastos_Sucursales")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void CantClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCantidad_Clientes")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCantidad_Clientes");
                t.Text = "Cantidad Clientes";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCantidad_Clientes = new frmCantidad_Clientes();
                frmCantidad_Clientes.MdiParent = this;
                frmCantidad_Clientes.Disposed += FrmCantidad_Clientes_Disposed;
                forms.Add(frmCantidad_Clientes);
                frmCantidad_Clientes.Show();
                frmCantidad_Clientes.WindowState = FormWindowState.Minimized;
                frmCantidad_Clientes.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmCantidad_Clientes_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Cantidad Clientes")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCantidad_Clientes")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void EmpleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmEmpleados")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmEmpleados");
                t.Text = "Empleados";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmEmpleados = new frmEmpleados();
                frmEmpleados.MdiParent = this;
                frmEmpleados.Disposed += FrmEmpleados_Disposed;
                forms.Add(frmEmpleados);
                frmEmpleados.Show();
                frmEmpleados.WindowState = FormWindowState.Minimized;
                frmEmpleados.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmEmpleados_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Empleados")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmEmpleados")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void RetirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmRetiros")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmRetiros");
                t.Text = "Retiros";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmRetiros = new frmRetiros();
                frmRetiros.MdiParent = this;
                frmRetiros.Disposed += FrmRetiros_Disposed;
                forms.Add(frmRetiros);
                frmRetiros.Show();
                frmRetiros.WindowState = FormWindowState.Minimized;
                frmRetiros.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmRetiros_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Retiros")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmRetiros")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void RendimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmRendimiento_Compras")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmRendimiento_Compras");
                t.Text = "Rendimiento_Compras";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmRendimiento_Compras = new frmRendimiento_Compras();
                frmRendimiento_Compras.MdiParent = this;
                frmRendimiento_Compras.Disposed += FrmRendimiento_Compras_Disposed;
                forms.Add(frmRendimiento_Compras);
                frmRendimiento_Compras.Show();
                frmRendimiento_Compras.WindowState = FormWindowState.Minimized;
                frmRendimiento_Compras.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmRendimiento_Compras_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Rendimiento_Compras")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmRendimiento_Compras")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void AjustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmAjustes")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmAjustes");
                t.Text = "Ajustes";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmAjustes = new frmAjustes();
                frmAjustes.MdiParent = this;
                frmAjustes.Disposed += FrmAjustes_Disposed;
                forms.Add(frmAjustes);
                frmAjustes.Show();
                frmAjustes.WindowState = FormWindowState.Minimized;
                frmAjustes.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmAjustes_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Ajustes")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmAjustes")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void DevolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmDevoluciones")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmDevoluciones");
                t.Text = "Devoluciones";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmDevoluciones = new frmDevoluciones();
                frmDevoluciones.MdiParent = this;
                frmDevoluciones.Disposed += FrmDevoluciones_Disposed;
                forms.Add(frmDevoluciones);
                frmDevoluciones.Show();
                frmDevoluciones.WindowState = FormWindowState.Minimized;
                frmDevoluciones.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmDevoluciones_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Devoluciones")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmDevoluciones")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ComprasFaenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmComprasFaena")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmComprasFaena");
                t.Text = "ComprasFaena";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmComprasFaena = new frmComprasFaena();
                frmComprasFaena.MdiParent = this;
                frmComprasFaena.Disposed += FrmComprasFaena_Disposed;
                forms.Add(frmComprasFaena);
                frmComprasFaena.Show();
                frmComprasFaena.WindowState = FormWindowState.Minimized;
                frmComprasFaena.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmComprasFaena_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "ComprasFaena")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmComprasFaena")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void CargaSeboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCargaSebo")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCargaSebo");
                t.Text = "CargaSebo";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCargaSebo = new frmCargaSebo();
                frmCargaSebo.MdiParent = this;
                frmCargaSebo.Disposed += FrmCargaSebo_Disposed;
                forms.Add(frmCargaSebo);
                frmCargaSebo.Show();
                frmCargaSebo.WindowState = FormWindowState.Minimized;
                frmCargaSebo.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmCargaSebo_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "CargaSebo")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCargaSebo")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void seberosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmSeberos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmSeberos");
                t.Text = "Seberos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmSeberos = new frmSeberos();
                frmSeberos.MdiParent = this;
                frmSeberos.Disposed += FrmSeberos_Disposed;
                forms.Add(frmSeberos);
                frmSeberos.Show();
                frmSeberos.WindowState = FormWindowState.Minimized;
                frmSeberos.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmSeberos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Seberos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmSeberos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void RepartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmHacienda_Salidas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmHacienda_Salidas");
                t.Text = "Hacienda_Salidas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmHacienda_Salidas = new frmHacienda_Salidas();
                frmHacienda_Salidas.MdiParent = this;
                frmHacienda_Salidas.Disposed += FrmHacienda_Salidas_Disposed;
                forms.Add(frmHacienda_Salidas);
                frmHacienda_Salidas.Show();
                frmHacienda_Salidas.WindowState = FormWindowState.Minimized;
                frmHacienda_Salidas.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmHacienda_Salidas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Hacienda_Salidas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmHacienda_Salidas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void StockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmHaciendaStock")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmHaciendaStock");
                t.Text = "HaciendaStock";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmHaciendaStock = new frmHaciendaStock();
                frmHaciendaStock.MdiParent = this;
                frmHaciendaStock.Disposed += FrmHaciendaStock_Disposed;
                forms.Add(frmHaciendaStock);
                frmHaciendaStock.Show();
                frmHaciendaStock.WindowState = FormWindowState.Minimized;
                frmHaciendaStock.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmHaciendaStock_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "HaciendaStock")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmHaciendaStock")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ttResumenProveedores_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Proveedores")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumen_Proveedores");
                t.Text = "Resumen_Prov";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmResumen_Proveedores = new Programa1.Carga.frmResumen_Proveedores();
                frmResumen_Proveedores.MdiParent = this;
                frmResumen_Proveedores.Disposed += FrmResumen_Proveedores_Disposed;
                forms.Add(frmResumen_Proveedores);
                frmResumen_Proveedores.Show();
                frmResumen_Proveedores.WindowState = FormWindowState.Minimized;
                frmResumen_Proveedores.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmResumen_Proveedores_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Resumen_Prov")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Proveedores")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void editarTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmTipos_Entradas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmTipos_Entradas");
                t.Text = "Tipos_Entradas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmTipos_Entradas = new Programa1.Carga.Tesoreria.frmTipos_Entradas();
                frmTipos_Entradas.MdiParent = this;
                frmTipos_Entradas.Disposed += FrmTipos_Entradas_Disposed;
                forms.Add(frmTipos_Entradas);
                frmTipos_Entradas.Show();
                frmTipos_Entradas.WindowState = FormWindowState.Minimized;
                frmTipos_Entradas.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmTipos_Entradas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Tipos_Entradas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmTipos_Entradas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void editarTiposGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmTipos_Gastos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmTipos_Gastos");
                t.Text = "Tipos_Gastos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmTipos_Gastos = new Programa1.Carga.Tesoreria.frmTipos_Gastos();
                frmTipos_Gastos.MdiParent = this;
                frmTipos_Gastos.Disposed += FrmTipos_Gastos_Disposed;
                forms.Add(frmTipos_Gastos);
                frmTipos_Gastos.Show();
                frmTipos_Gastos.WindowState = FormWindowState.Minimized;
                frmTipos_Gastos.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmTipos_Gastos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Tipos_Gastos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmTipos_Gastos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void cajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCaja_Diaria")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCaja_Diaria");
                t.Text = "Caja_Diaria";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCaja_Diaria = new Programa1.Carga.Tesoreria.frmCaja_Diaria();
                frmCaja_Diaria.MdiParent = this;
                frmCaja_Diaria.Disposed += FrmCaja_Diaria_Disposed;
                forms.Add(frmCaja_Diaria);
                frmCaja_Diaria.Show();
                frmCaja_Diaria.WindowState = FormWindowState.Minimized;
                frmCaja_Diaria.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmCaja_Diaria_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Caja_Diaria")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCaja_Diaria")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void Resumen_GastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Gastos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumen_Gastos");
                t.Text = "Resumen_Gastos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmResumen_Gastos = new Programa1.Carga.Tesoreria.frmResumen_Gastos();
                frmResumen_Gastos.MdiParent = this;
                frmResumen_Gastos.Disposed += FrmResumen_Gastos_Disposed;
                forms.Add(frmResumen_Gastos);
                frmResumen_Gastos.Show();
                frmResumen_Gastos.WindowState = FormWindowState.Minimized;
                frmResumen_Gastos.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmResumen_Gastos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Resumen_Gastos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Gastos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void carneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Carne")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPrecios_Carne");
                t.Text = "Precios_Carne";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrecios_Carne = new Programa1.Carga.Precios.frmPrecios_Carne();
                frmPrecios_Carne.MdiParent = this;
                frmPrecios_Carne.Disposed += FrmPrecios_Carne_Disposed;
                forms.Add(frmPrecios_Carne);
                frmPrecios_Carne.Show();
                frmPrecios_Carne.WindowState = FormWindowState.Minimized;
                frmPrecios_Carne.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrecios_Carne_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Precios_Carne")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Carne")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }
    }
}
