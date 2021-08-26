namespace Programa1.Carga
{
    partial class frmDevoluciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevoluciones));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cProveedores = new Programa1.Controles.cProveedores();
            this.cFecha = new Programa1.Controles.cFechas();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cProds = new Programa1.Controles.cProductos();
            this.cSucursal = new Programa1.Controles.cSucursales();
            this.GrdDevoluciones = new Grilla2.SpeedGrilla();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilos,
            this.lblTotalS,
            this.lblTotalE,
            this.lblDiferencia});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 28);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 23);
            // 
            // lblCant
            // 
            this.lblCant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(60, 23);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilos
            // 
            this.lblKilos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(36, 23);
            this.lblKilos.Text = "Kilos";
            this.lblKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(85, 23);
            this.lblTotalS.Text = "Totales Venta";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalE
            // 
            this.lblTotalE.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalE.Name = "lblTotalE";
            this.lblTotalE.Size = new System.Drawing.Size(100, 23);
            this.lblTotalE.Text = "Totales Compra";
            this.lblTotalE.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(66, 23);
            this.lblDiferencia.Text = "Diferencia";
            this.lblDiferencia.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(523, 687);
            this.splitContainer2.SplitterDistance = 453;
            this.splitContainer2.TabIndex = 6;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.cFecha);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cProveedores);
            this.splitContainer4.Size = new System.Drawing.Size(523, 230);
            this.splitContainer4.SplitterDistance = 226;
            this.splitContainer4.TabIndex = 4;
            // 
            // cProveedores
            // 
            this.cProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProveedores.BackColor = System.Drawing.Color.Gainsboro;
            this.cProveedores.Filtro_In = "";
            this.cProveedores.Location = new System.Drawing.Point(0, 0);
            this.cProveedores.Mostrar_Tipo = true;
            this.cProveedores.Name = "cProveedores";
            this.cProveedores.Size = new System.Drawing.Size(290, 230);
            this.cProveedores.TabIndex = 2;
            this.cProveedores.Titulo = "Proveedores";
            this.cProveedores.Valor_Actual = -1;
            this.cProveedores.Cambio_Seleccion += new System.EventHandler(this.Csuc_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(3, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(223, 230);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cSucursal);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cProds);
            this.splitContainer3.Size = new System.Drawing.Size(523, 453);
            this.splitContainer3.SplitterDistance = 256;
            this.splitContainer3.TabIndex = 0;
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(2, 3);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(258, 447);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cSucursal
            // 
            this.cSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucursal.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucursal.Filtro_In = "";
            this.cSucursal.Location = new System.Drawing.Point(3, 3);
            this.cSucursal.Mostrar_Tipo = true;
            this.cSucursal.Name = "cSucursal";
            this.cSucursal.Size = new System.Drawing.Size(253, 447);
            this.cSucursal.TabIndex = 3;
            this.cSucursal.Titulo = "Sucursales";
            this.cSucursal.Valor_Actual = -1;
            this.cSucursal.Cambio_Seleccion += new System.EventHandler(this.Csuc_Cambio_Seleccion);
            // 
            // GrdDevoluciones
            // 
            this.GrdDevoluciones.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.GrdDevoluciones.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.GrdDevoluciones.AutoResize = false;
            this.GrdDevoluciones.bColor = System.Drawing.SystemColors.Window;
            this.GrdDevoluciones.bColorSel = System.Drawing.SystemColors.Highlight;
            this.GrdDevoluciones.bFColor = System.Drawing.SystemColors.WindowText;
            this.GrdDevoluciones.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.GrdDevoluciones.Col = 0;
            this.GrdDevoluciones.Cols = 10;
            this.GrdDevoluciones.DataMember = "";
            this.GrdDevoluciones.DataSource = null;
            this.GrdDevoluciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdDevoluciones.EnableEdicion = true;
            this.GrdDevoluciones.Encabezado = "";
            this.GrdDevoluciones.fColor = System.Drawing.SystemColors.Control;
            this.GrdDevoluciones.FixCols = 0;
            this.GrdDevoluciones.FixRows = 0;
            this.GrdDevoluciones.FuenteEncabezado = null;
            this.GrdDevoluciones.FuentePieDePagina = null;
            this.GrdDevoluciones.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.GrdDevoluciones.Location = new System.Drawing.Point(0, 0);
            this.GrdDevoluciones.Name = "GrdDevoluciones";
            this.GrdDevoluciones.PieDePagina = "\t\tPage {0} of {1}";
            this.GrdDevoluciones.PintarFilaSel = true;
            this.GrdDevoluciones.Redraw = true;
            this.GrdDevoluciones.Row = 0;
            this.GrdDevoluciones.Rows = 50;
            this.GrdDevoluciones.Size = new System.Drawing.Size(831, 687);
            this.GrdDevoluciones.TabIndex = 0;
            this.GrdDevoluciones.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdDevoluciones_Editado);
            this.GrdDevoluciones.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdDevoluciones_CambioFila);
            this.GrdDevoluciones.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdDevoluciones_KeyUp);
            this.GrdDevoluciones.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdDevoluciones_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.GrdDevoluciones);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 687);
            this.splitContainer1.SplitterDistance = 831;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(767, 688);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 27);
            this.panel1.TabIndex = 9;
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(412, 2);
            this.paMostrar.Name = "paMostrar";
            this.paMostrar.Size = new System.Drawing.Size(177, 25);
            this.paMostrar.TabIndex = 5;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.AutoSize = true;
            this.cmdMostrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMostrar.Depth = 0;
            this.cmdMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMostrar.Location = new System.Drawing.Point(0, 0);
            this.cmdMostrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Primary = false;
            this.cmdMostrar.Size = new System.Drawing.Size(177, 25);
            this.cmdMostrar.TabIndex = 0;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // paLimpiar
            // 
            this.paLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paLimpiar.Controls.Add(this.cmdLimpiar);
            this.paLimpiar.Location = new System.Drawing.Point(228, 2);
            this.paLimpiar.Name = "paLimpiar";
            this.paLimpiar.Size = new System.Drawing.Size(177, 25);
            this.paLimpiar.TabIndex = 5;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.AutoSize = true;
            this.cmdLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdLimpiar.Depth = 0;
            this.cmdLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdLimpiar.Location = new System.Drawing.Point(0, 0);
            this.cmdLimpiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Primary = false;
            this.cmdLimpiar.Size = new System.Drawing.Size(177, 25);
            this.cmdLimpiar.TabIndex = 0;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // frmDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmDevoluciones";
            this.Text = "Venta";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmVenta_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Controles.cSucursales cSucursal;
        private Controles.cProductos cProds;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Controles.cFechas cFecha;
        private Controles.cProveedores cProveedores;
        private Grilla2.SpeedGrilla GrdDevoluciones;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
    }
}