namespace Programa1
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Programa1.Carga;
    using Programa1.Carga.Precios;
    
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
                if (f.Name.StartsWith("frm"+ sender.ToString()) == true)
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
                if (f.Name == "frmResumenSuc")
                {
                    f.BringToFront();
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ToolStripMenuItem t = new ToolStripMenuItem("frmResumenSuc");
                t.Text = "Resumen Sucs";
                t.Click += new EventHandler(Mostrar);
                this.tstMenu.Items.Add(t);
                
                Form frmResumenSuc = new Programa1.Carga.frmResumenSuc();
                frmResumenSuc.MdiParent = this;
                forms.Add(frmResumenSuc);
                frmResumenSuc.Show();
                frmResumenSuc.WindowState = FormWindowState.Minimized;
                frmResumenSuc.WindowState = FormWindowState.Maximized;
            }
        }

        private void PruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menudenciasToolStripMenuItem.PerformClick();
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
                if(f.Name=="frmProductos")
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
    }
}
