namespace Programa1
{
    using Programa1.Carga;
    using Programa1.Carga.Empleados;
    using Programa1.Carga.Hacienda;
    using Programa1.Carga.Sebero;
    using Programa1.Carga.Tesoreria;
    using Programa1.Carga.Varios;
    using Programa1.DB.Varios;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmMain : Form
    {
        public Usuarios usuario;
        readonly List<Form> forms = new List<Form>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = usuario.Nombre;
            foreach (ToolStripMenuItem n in mnuPrincipal.Items)
            {
                if (n.Tag != null)
                {
                    if (n.Tag.ToString().IndexOf(usuario.Tipo.ToString().ToLower()) > -1)
                    {
                        n.Visible = true;
                    }
                }
            }
            switch (usuario.Nombre)
            {
                case "Nicolas":

                    break;
                case "Ale":
                    cajaDiariaToolStripMenuItem.PerformClick();
                    break;
            }

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

                Form frmResumen_Suc = new Programa1.Carga.frmResumen_Suc(usuario);
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
            frmPartidos fr = new frmPartidos();
            fr.ShowDialog();
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

                Form frmStock = new Programa1.Carga.frmStock(usuario);
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

        private void PreciosMenToolStripMenuItem_Click(object sender, EventArgs e)
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
                t.Text = "PreciosMen";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPreciosMen = new Carga.Precios.frmPreciosMen();
                frmPreciosMen.MdiParent = this;
                frmPreciosMen.Disposed += frmPreciosMen_Disposed;
                forms.Add(frmPreciosMen);
                frmPreciosMen.Show();
                frmPreciosMen.WindowState = FormWindowState.Minimized;
                frmPreciosMen.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmPreciosMen_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "PreciosMen")
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
                t.Text = "Cantidad_Clientes";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCantidad_Clientes = new Carga.frmCantidad_Clientes();
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
                if (t.Text == "Cantidad_Clientes")
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

        private void SeberosToolStripMenuItem_Click_1(object sender, EventArgs e)
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

                Form frmCaja_Diaria = new Programa1.Carga.Tesoreria.frmCaja_Diaria(usuario);
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
        private void resumenEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Entradas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumen_Entradas");
                t.Text = "Resumen_Entradas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmResumen_Entradas = new Programa1.Carga.Tesoreria.frmResumen_Entradas();
                frmResumen_Entradas.MdiParent = this;
                frmResumen_Entradas.Disposed += FrmResumen_Entradas_Disposed;
                forms.Add(frmResumen_Entradas);
                frmResumen_Entradas.Show();
                frmResumen_Entradas.WindowState = FormWindowState.Minimized;
                frmResumen_Entradas.WindowState = FormWindowState.Maximized;
            }
        }

        private void FrmResumen_Entradas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Resumen_Entradas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Entradas")
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

        private void granjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Granja")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPrecios_Granja");
                t.Text = "Precios_Granja";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrecios_Granja = new Programa1.Carga.Precios.frmPrecios_Granja();
                frmPrecios_Granja.MdiParent = this;
                frmPrecios_Granja.Disposed += FrmPrecios_Granja_Disposed;
                forms.Add(frmPrecios_Granja);
                frmPrecios_Granja.Show();
                frmPrecios_Granja.WindowState = FormWindowState.Minimized;
                frmPrecios_Granja.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrecios_Granja_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Precios_Granja")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Granja")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void promediosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPromedios")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPromedios");
                t.Text = "Promedios";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPromedios = new Programa1.Carga.Precios.frmPromedios();
                frmPromedios.MdiParent = this;
                frmPromedios.Disposed += FrmPromedios_Disposed;
                forms.Add(frmPromedios);
                frmPromedios.Show();
                frmPromedios.WindowState = FormWindowState.Minimized;
                frmPromedios.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPromedios_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Promedios")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPromedios")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void tstMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem t in tstMenu.Items)
            {
                t.BackColor = DefaultBackColor;
            }
            e.ClickedItem.BackColor = Color.LightSkyBlue;
        }


        private void tstMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            foreach (ToolStripItem t in tstMenu.Items)
            {
                t.BackColor = DefaultBackColor;
            }
            e.Item.BackColor = Color.LightSkyBlue;
        }

        private void pagosAutorizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPagos_Autorizados")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPagos_Autorizados");
                t.Text = "Pagos_Autorizados";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPagos_Autorizados = new Carga.Tesoreria.frmPagos_Autorizados();
                frmPagos_Autorizados.MdiParent = this;
                frmPagos_Autorizados.Disposed += FrmPagos_Autorizados_Disposed;
                forms.Add(frmPagos_Autorizados);
                frmPagos_Autorizados.Show();
                frmPagos_Autorizados.WindowState = FormWindowState.Minimized;
                frmPagos_Autorizados.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPagos_Autorizados_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Pagos_Autorizados")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPagos_Autorizados")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void capitalDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCapitalDeTrabajo")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCapitalDeTrabajo");
                t.Text = "CapitalDeTrabajo";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCapitalDeTrabajo = new frmCapitalDeTrabajo();
                frmCapitalDeTrabajo.MdiParent = this;
                frmCapitalDeTrabajo.Disposed += FrmCapitalDeTrabajo_Disposed;
                forms.Add(frmCapitalDeTrabajo);
                frmCapitalDeTrabajo.Show();
                frmCapitalDeTrabajo.WindowState = FormWindowState.Minimized;
                frmCapitalDeTrabajo.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmCapitalDeTrabajo_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "CapitalDeTrabajo")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCapitalDeTrabajo")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void vencimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmVencimientos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmVencimientos");
                t.Text = "Vencimientos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmVencimientos = new Carga.Hacienda.frmVencimientos();
                frmVencimientos.MdiParent = this;
                frmVencimientos.Disposed += FrmVencimientos_Disposed;
                forms.Add(frmVencimientos);
                frmVencimientos.Show();
                frmVencimientos.WindowState = FormWindowState.Minimized;
                frmVencimientos.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmVencimientos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Vencimientos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmVencimientos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void stockCarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmStocks_CarneSucs")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmStocks_CarneSucs");
                t.Text = "Stocks_CarneSucs";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmStocks_CarneSucs = new Carga.Sucursales.frmStocks_CarneSucs();
                frmStocks_CarneSucs.MdiParent = this;
                frmStocks_CarneSucs.Disposed += FrmStocks_CarneSucs_Disposed;
                forms.Add(frmStocks_CarneSucs);
                frmStocks_CarneSucs.Show();
                frmStocks_CarneSucs.WindowState = FormWindowState.Minimized;
                frmStocks_CarneSucs.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmStocks_CarneSucs_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Stocks_CarneSucs")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmStocks_CarneSucs")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void preciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Proveedores")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPrecios_Proveedores");
                t.Text = "Precios_Proveedores";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrecios_Proveedores = new Carga.Proveedores.frmPrecios_Proveedores();
                frmPrecios_Proveedores.MdiParent = this;
                frmPrecios_Proveedores.Disposed += FrmPrecios_Proveedores_Disposed;
                forms.Add(frmPrecios_Proveedores);
                frmPrecios_Proveedores.Show();
                frmPrecios_Proveedores.WindowState = FormWindowState.Minimized;
                frmPrecios_Proveedores.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrecios_Proveedores_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Precios_Proveedores")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Proveedores")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void reintXCambioDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Stock")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPrecios_Stock");
                t.Text = "Precios_Stock";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrecios_Stock = new Carga.Sucursales.frmPrecios_Stock();
                frmPrecios_Stock.MdiParent = this;
                frmPrecios_Stock.Disposed += FrmPrecios_Stock_Disposed;
                forms.Add(frmPrecios_Stock);
                frmPrecios_Stock.Show();
                frmPrecios_Stock.WindowState = FormWindowState.Minimized;
                frmPrecios_Stock.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrecios_Stock_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Precios_Stock")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrecios_Stock")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void ventasPorProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmVenta_Productos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmVenta_Productos");
                t.Text = "Venta_Productos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmVenta_Productos = new Carga.Varios.frmVenta_Productos();
                frmVenta_Productos.MdiParent = this;
                frmVenta_Productos.Disposed += FrmVenta_Productos_Disposed;
                forms.Add(frmVenta_Productos);
                frmVenta_Productos.Show();
                frmVenta_Productos.WindowState = FormWindowState.Minimized;
                frmVenta_Productos.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmVenta_Productos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Venta_Productos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmVenta_Productos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void sincronizarAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmSincronizarAccess")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmSincronizarAccess");
                t.Text = "SincronizarAccess";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmSincronizarAccess = new Carga.Hacienda.frmSincronizarAccess();
                frmSincronizarAccess.MdiParent = this;
                frmSincronizarAccess.Disposed += FrmSincronizarAccess_Disposed;
                forms.Add(frmSincronizarAccess);
                frmSincronizarAccess.Show();
                frmSincronizarAccess.WindowState = FormWindowState.Minimized;
                frmSincronizarAccess.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmSincronizarAccess_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "SincronizarAccess")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmSincronizarAccess")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void detallesPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmDetalles_Pagos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmDetalles_Pagos");
                t.Text = "Detalles_Pagos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmDetalles_Pagos = new Carga.Tesoreria.frmDetalles_Pagos();
                frmDetalles_Pagos.MdiParent = this;
                frmDetalles_Pagos.Disposed += frmDetalles_Pagos_Disposed;
                forms.Add(frmDetalles_Pagos);
                frmDetalles_Pagos.Show();
                frmDetalles_Pagos.WindowState = FormWindowState.Minimized;
                frmDetalles_Pagos.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmDetalles_Pagos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Detalles_Pagos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmDetalles_Pagos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }
        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmTarjetas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmTarjetas");
                t.Text = "Tarjetas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmTarjetas = new Carga.Tesoreria.frmTarjetas();
                frmTarjetas.MdiParent = this;
                frmTarjetas.Disposed += frmTarjetas_Disposed;
                forms.Add(frmTarjetas);
                frmTarjetas.Show();
                frmTarjetas.WindowState = FormWindowState.Minimized;
                frmTarjetas.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmTarjetas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Tarjetas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmTarjetas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void frigorificosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmFrigorificosABM")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmFrigorificosABM");
                t.Text = "Frigorificos y Consignatarios";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmFrigorificosABM = new Carga.Hacienda.frmFriorificosABM();
                frmFrigorificosABM.MdiParent = this;
                frmFrigorificosABM.Disposed += frmFrigorificosABM_Disposed;
                forms.Add(frmFrigorificosABM);
                frmFrigorificosABM.Show();
                frmFrigorificosABM.WindowState = FormWindowState.Minimized;
                frmFrigorificosABM.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmFrigorificosABM_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Frigorificos y Consignatarios")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmFrigorificosABM")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            frmGuardar_Semana fr = new frmGuardar_Semana();
            fr.ShowDialog();
        }

        private void valoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValores_Recupero fr = new frmValores_Recupero();
            fr.ShowDialog();
        }

        private void recuperoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmResumen_Recupero fr = new frmResumen_Recupero();
            fr.Show();
        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmControl_Carne")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmControl_Carne");
                t.Text = "Control_Carne";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmControl_Carne = new Carga.Hacienda.frmControl_Carne();
                frmControl_Carne.MdiParent = this;
                frmControl_Carne.Disposed += FrmControl_Carne_Disposed;
                forms.Add(frmControl_Carne);
                frmControl_Carne.Show();
                frmControl_Carne.WindowState = FormWindowState.Minimized;
                frmControl_Carne.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmControl_Carne_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Control_Carne")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmControl_Carne")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void stockCorralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHacienda_Corrales fr = new frmHacienda_Corrales();
            fr.ShowDialog();
        }

        private void editarARendirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditar_ARendir fr = new frmEditar_ARendir();
            fr.ShowDialog();
        }

        private void editarCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditar_Cajas fr = new frmEditar_Cajas();
            fr.ShowDialog();
        }

        private void deudaHaciendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmDeuda_Hacienda")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmDeuda_Hacienda");
                t.Text = "Deuda_Hacienda";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmDeuda_Hacienda = new Carga.Hacienda.frmDeuda_Hacienda();
                frmDeuda_Hacienda.MdiParent = this;
                frmDeuda_Hacienda.Disposed += FrmDeuda_Hacienda_Disposed;
                forms.Add(frmDeuda_Hacienda);
                frmDeuda_Hacienda.Show();
                frmDeuda_Hacienda.WindowState = FormWindowState.Minimized;
                frmDeuda_Hacienda.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmDeuda_Hacienda_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Deuda_Hacienda")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmDeuda_Hacienda")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void leerTarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmLeer_Tarjetas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmLeer_Tarjetas");
                t.Text = "Leer_Tarjetas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmLeer_Tarjetas = new Carga.Tesoreria.frmLeer_Tarjetas();
                frmLeer_Tarjetas.MdiParent = this;
                frmLeer_Tarjetas.Disposed += frmLeer_Tarjetas_Disposed;
                forms.Add(frmLeer_Tarjetas);
                frmLeer_Tarjetas.Show();
                frmLeer_Tarjetas.WindowState = FormWindowState.Minimized;
                frmLeer_Tarjetas.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmLeer_Tarjetas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Leer_Tarjetas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmLeer_Tarjetas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void modificarTarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmModificar_Tarjetas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmModificar_Tarjetas");
                t.Text = "Modificar_Tarjetas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmModificar_Tarjetas = new Carga.Tesoreria.frmModificar_Tarjetas();
                frmModificar_Tarjetas.MdiParent = this;
                frmModificar_Tarjetas.Disposed += frmModificar_Tarjetas_Disposed;
                forms.Add(frmModificar_Tarjetas);
                frmModificar_Tarjetas.Show();
                frmModificar_Tarjetas.WindowState = FormWindowState.Minimized;
                frmModificar_Tarjetas.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmModificar_Tarjetas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Modificar_Tarjetas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmModificar_Tarjetas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void imprimirOfertasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmImprimir_Ofertas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmImprimir_Ofertas");
                t.Text = "Imprimir_Ofertas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmImprimir_Ofertas = new Carga.Sucursales.frmImprimir_Ofertas();
                frmImprimir_Ofertas.MdiParent = this;
                frmImprimir_Ofertas.Disposed += frmImprimir_Ofertas_Disposed;
                forms.Add(frmImprimir_Ofertas);
                frmImprimir_Ofertas.Show();
                frmImprimir_Ofertas.WindowState = FormWindowState.Minimized;
                frmImprimir_Ofertas.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmImprimir_Ofertas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Imprimir_Ofertas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmImprimir_Ofertas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }
        private void chequesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmCheques")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmCheques");
                t.Text = "Cheques";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmCheques = new Carga.Tesoreria.frmCheques();
                frmCheques.MdiParent = this;
                frmCheques.Disposed += FrmCheques_Disposed;
                forms.Add(frmCheques);
                frmCheques.Show();
                frmCheques.WindowState = FormWindowState.Minimized;
                frmCheques.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmCheques_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Cheques")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmCheques")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void resumenToolStripMenuItem1_Click(object sender, EventArgs e)
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

                Form frmResumen_Suc = new frmResumen_Suc(usuario);
                frmResumen_Suc.MdiParent = this;
                frmResumen_Suc.Disposed += FrmResumen_Suc_Disposed;
                forms.Add(frmResumen_Suc);
                frmResumen_Suc.Show();
                frmResumen_Suc.WindowState = FormWindowState.Minimized;
                frmResumen_Suc.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmResumen_Suc_Disposed(object sender, EventArgs e)
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

        private void stockCarneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmStock_CarneSucs")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmStock_CarneSucs");
                t.Text = "Stock_CarneSucs";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmStock_CarneSucs = new Carga.Sucursales.frmStocks_CarneSucs();
                frmStock_CarneSucs.MdiParent = this;
                frmStock_CarneSucs.Disposed += FrmStock_CarneSucs_Disposed;
                forms.Add(frmStock_CarneSucs);
                frmStock_CarneSucs.Show();
                frmStock_CarneSucs.WindowState = FormWindowState.Minimized;
                frmStock_CarneSucs.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmStock_CarneSucs_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Stock_CarneSucs")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmStock_CarneSucs")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
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
                frmStock frmStock = new Programa1.Carga.frmStock(this.usuario);

                frmStock.MdiParent = this;
                frmStock.Disposed += FrmStock_Disposed;
                forms.Add(frmStock);
                frmStock.Show();
                frmStock.WindowState = FormWindowState.Minimized;
                frmStock.WindowState = FormWindowState.Maximized;
            }
        }

        private void analisisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmAnalisis")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmAnalisis");
                t.Text = "Analisis";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmAnalisis = new Carga.Varios.frmAnalisis();
                frmAnalisis.MdiParent = this;
                frmAnalisis.Disposed += FrmAnalisis_Disposed;
                forms.Add(frmAnalisis);
                frmAnalisis.Show();
                frmAnalisis.WindowState = FormWindowState.Minimized;
                frmAnalisis.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmAnalisis_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Analisis")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmAnalisis")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrestamos")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPrestamos");
                t.Text = "Prestamos";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPrestamos = new Carga.Tesoreria.frmPrestamos();
                frmPrestamos.MdiParent = this;
                frmPrestamos.Disposed += FrmPrestamos_Disposed;
                forms.Add(frmPrestamos);
                frmPrestamos.Show();
                frmPrestamos.WindowState = FormWindowState.Minimized;
                frmPrestamos.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmPrestamos_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Prestamos")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPrestamos")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void consultaPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)            {

                if (f.Name == "frmConsulta_Precios")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmConsulta_Precios");
                t.Text = "Consulta_Precios";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmConsulta_Precios = new Carga.Precios.frmConsulta_Precios();
                frmConsulta_Precios.MdiParent = this;
                frmConsulta_Precios.Disposed += FrmConsulta_Precios_Disposed;
                forms.Add(frmConsulta_Precios);
                frmConsulta_Precios.Show();
                frmConsulta_Precios.WindowState = FormWindowState.Minimized;
                frmConsulta_Precios.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmConsulta_Precios_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Consulta_Precios")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmConsulta_Precios")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void promediosCarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {

                if (f.Name == "frmPromedios_Carne")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmPromedios_Carne");
                t.Text = "Promedios_Carne";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmPromedios_Carne = new Carga.Precios.frmPromedios_Carne();
                frmPromedios_Carne.MdiParent = this;
                frmPromedios_Carne.Disposed += frmPromedios_Carne_Disposed;
                forms.Add(frmPromedios_Carne);
                frmPromedios_Carne.Show();
                frmPromedios_Carne.WindowState = FormWindowState.Minimized;
                frmPromedios_Carne.WindowState = FormWindowState.Maximized;
            }
        }
        private void frmPromedios_Carne_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Promedios_Carne")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmPromedios_Carne")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }
        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Nombre = "Edi";
        }

        private void cargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Nombre = "Caro";
        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Nombre = "Nicolas";
        }

        private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportar_Excel fr = new frmImportar_Excel();
            fr.Owner = this;   
            fr.Show();
        }

        private void tesoreriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Nombre = "Ale";
        }

        private void tMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.Nombre = "Lorena";
        }

        private void resumenCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Cajas")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumen_Cajas");
                t.Text = "Resumen_Cajas";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmResumen_Cajas = new Carga.Tesoreria.frmResumen_Cajas();
                frmResumen_Cajas.MdiParent = this;
                frmResumen_Cajas.Disposed += FrmResumen_Cajas_Disposed;
                forms.Add(frmResumen_Cajas);
                frmResumen_Cajas.Show();
                frmResumen_Cajas.WindowState = FormWindowState.Minimized;
                frmResumen_Cajas.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmResumen_Cajas_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Resumen_Cajas")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmResumen_Cajas")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }

        private void editarDiariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiarios fr = new frmDiarios();
            fr.ShowDialog();
        }

        private void vencimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (Form f in forms)
            {
                if (f.Name == "frmVencimientos_Proveedores")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmVencimientos_Proveedores");
                t.Text = "Vencimientos_Proveedores";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);

                Form frmVencimientos_Proveedores = new Carga.Proveedores.frmVencimientos_Proveedores();
                frmVencimientos_Proveedores.MdiParent = this;
                frmVencimientos_Proveedores.Disposed += FrmVencimientos_Proveedores_Disposed;
                forms.Add(frmVencimientos_Proveedores);
                frmVencimientos_Proveedores.Show();
                frmVencimientos_Proveedores.WindowState = FormWindowState.Minimized;
                frmVencimientos_Proveedores.WindowState = FormWindowState.Maximized;
            }
        }
        private void FrmVencimientos_Proveedores_Disposed(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in tstMenu.Items)
            {
                if (t.Text == "Vencimientos_Proveedores")
                {
                    tstMenu.Items.Remove(t);
                    break;
                }
            }
            foreach (Form f in forms)
            {
                if (f.Name == "frmVencimientos_Proveedores")
                {
                    forms.Remove(f);
                    break;
                }
            }
        }
    }
}
