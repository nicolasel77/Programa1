namespace Programa1.Carga
{
    partial class frmCargaSebo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargaSebo));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdVenta = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cSucursal = new Programa1.Controles.cSucursales();
            this.cProds = new Programa1.Controles.cProductos();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProveedores = new Programa1.Controles.cProveedores();
            this.cmdCambioMasivo = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.cmdATraslados = new System.Windows.Forms.Button();
            this.cmdACompras = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.grdVenta);
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
            // grdVenta
            // 
            this.grdVenta.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdVenta.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdVenta.AutoResize = false;
            this.grdVenta.bColor = System.Drawing.SystemColors.Window;
            this.grdVenta.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdVenta.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdVenta.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdVenta.Col = 0;
            this.grdVenta.Cols = 10;
            this.grdVenta.DataMember = "";
            this.grdVenta.DataSource = null;
            this.grdVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVenta.EnableEdicion = true;
            this.grdVenta.Encabezado = "";
            this.grdVenta.fColor = System.Drawing.SystemColors.Control;
            this.grdVenta.FixCols = 0;
            this.grdVenta.FixRows = 0;
            this.grdVenta.FuenteEncabezado = null;
            this.grdVenta.FuentePieDePagina = null;
            this.grdVenta.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdVenta.Location = new System.Drawing.Point(0, 0);
            this.grdVenta.MenuActivado = false;
            this.grdVenta.Name = "grdVenta";
            this.grdVenta.PieDePagina = "\t\tPage {0} of {1}";
            this.grdVenta.PintarFilaSel = true;
            this.grdVenta.Redraw = true;
            this.grdVenta.Row = 0;
            this.grdVenta.Rows = 50;
            this.grdVenta.Size = new System.Drawing.Size(831, 687);
            this.grdVenta.TabIndex = 0;
            this.grdVenta.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdVenta_Editado);
            this.grdVenta.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdVenta_CambioFila);
            this.grdVenta.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdVenta_KeyUp);
            this.grdVenta.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdVenta_KeyPress);
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
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(2, 3);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(258, 447);
            this.cProds.TabIndex = 1;
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
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
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Location = new System.Drawing.Point(3, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(223, 230);
            this.cFecha.TabIndex = 3;
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
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
            // cmdCambioMasivo
            // 
            this.cmdCambioMasivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCambioMasivo.Location = new System.Drawing.Point(1047, 690);
            this.cmdCambioMasivo.Name = "cmdCambioMasivo";
            this.cmdCambioMasivo.Size = new System.Drawing.Size(100, 23);
            this.cmdCambioMasivo.TabIndex = 4;
            this.cmdCambioMasivo.Text = "Cambio Masivo";
            this.cmdCambioMasivo.UseVisualStyleBackColor = true;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLimpiar.Location = new System.Drawing.Point(1153, 690);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(100, 23);
            this.cmdLimpiar.TabIndex = 4;
            this.cmdLimpiar.Text = "Limpiar Grilla";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMostrar.Location = new System.Drawing.Point(1259, 690);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(100, 23);
            this.cmdMostrar.TabIndex = 4;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // cmdATraslados
            // 
            this.cmdATraslados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdATraslados.Location = new System.Drawing.Point(941, 690);
            this.cmdATraslados.Name = "cmdATraslados";
            this.cmdATraslados.Size = new System.Drawing.Size(100, 23);
            this.cmdATraslados.TabIndex = 4;
            this.cmdATraslados.Text = "A Traslados";
            this.cmdATraslados.UseVisualStyleBackColor = true;
            // 
            // cmdACompras
            // 
            this.cmdACompras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdACompras.Location = new System.Drawing.Point(834, 690);
            this.cmdACompras.Name = "cmdACompras";
            this.cmdACompras.Size = new System.Drawing.Size(100, 23);
            this.cmdACompras.TabIndex = 4;
            this.cmdACompras.Text = "A Compras";
            this.cmdACompras.UseVisualStyleBackColor = true;
            // 
            // frmCargaSebo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.cmdACompras);
            this.Controls.Add(this.cmdATraslados);
            this.Controls.Add(this.cmdCambioMasivo);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmCargaSebo";
            this.Text = "Venta";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmVenta_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdVenta;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cProveedores cProveedores;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.Button cmdCambioMasivo;
        private Controles.cSucursales cSucursal;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.Button cmdATraslados;
        private System.Windows.Forms.Button cmdACompras;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}