namespace Programa1.Carga.Hacienda
{
    partial class frmHacienda_Salidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHacienda_Salidas));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdSalida = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.chMediasUsadas = new MaterialSkin.Controls.MaterialCheckBox();
            this.grdResumen = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBoletas = new System.Windows.Forms.ListBox();
            this.lstTropas = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.cFecha = new Programa1.Controles.cFechas();
            this.cSucursal = new Programa1.Controles.cSucursales();
            this.cProds = new Programa1.Controles.cProductos();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.statusStrip1.Size = new System.Drawing.Size(1433, 28);
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
            this.lblCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(73, 23);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilos
            // 
            this.lblKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(42, 23);
            this.lblKilos.Text = "Kilos";
            this.lblKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(109, 23);
            this.lblTotalS.Text = "Totales Salida";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalE
            // 
            this.lblTotalE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalE.Name = "lblTotalE";
            this.lblTotalE.Size = new System.Drawing.Size(121, 23);
            this.lblTotalE.Text = "Totales Compra";
            this.lblTotalE.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(81, 23);
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
            this.splitContainer1.Panel1.Controls.Add(this.grdSalida);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1433, 687);
            this.splitContainer1.SplitterDistance = 873;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdSalida
            // 
            this.grdSalida.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSalida.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSalida.AutoResize = false;
            this.grdSalida.bColor = System.Drawing.SystemColors.Window;
            this.grdSalida.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSalida.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSalida.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSalida.Col = 0;
            this.grdSalida.Cols = 10;
            this.grdSalida.DataMember = "";
            this.grdSalida.DataSource = null;
            this.grdSalida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSalida.EnableEdicion = true;
            this.grdSalida.Encabezado = "";
            this.grdSalida.fColor = System.Drawing.SystemColors.Control;
            this.grdSalida.FixCols = 0;
            this.grdSalida.FixRows = 0;
            this.grdSalida.FuenteEncabezado = null;
            this.grdSalida.FuentePieDePagina = null;
            this.grdSalida.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalida.Location = new System.Drawing.Point(0, 0);
            this.grdSalida.Name = "grdSalida";
            this.grdSalida.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalida.PintarFilaSel = true;
            this.grdSalida.Redraw = true;
            this.grdSalida.Row = 0;
            this.grdSalida.Rows = 50;
            this.grdSalida.Size = new System.Drawing.Size(873, 687);
            this.grdSalida.TabIndex = 0;
            this.grdSalida.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSalida_Editado);
            this.grdSalida.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdSalida_CambioFila);
            this.grdSalida.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdSalida_KeyUp);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(552, 687);
            this.splitContainer3.SplitterDistance = 278;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.chMediasUsadas);
            this.splitContainer5.Panel1.Controls.Add(this.grdResumen);
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            this.splitContainer5.Panel1.Controls.Add(this.label2);
            this.splitContainer5.Panel1.Controls.Add(this.lstBoletas);
            this.splitContainer5.Panel1.Controls.Add(this.lstTropas);
            this.splitContainer5.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.cProds);
            this.splitContainer5.Size = new System.Drawing.Size(270, 687);
            this.splitContainer5.SplitterDistance = 546;
            this.splitContainer5.SplitterWidth = 8;
            this.splitContainer5.TabIndex = 7;
            // 
            // chMediasUsadas
            // 
            this.chMediasUsadas.AutoSize = true;
            this.chMediasUsadas.Depth = 0;
            this.chMediasUsadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chMediasUsadas.Location = new System.Drawing.Point(5, 151);
            this.chMediasUsadas.Margin = new System.Windows.Forms.Padding(0);
            this.chMediasUsadas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chMediasUsadas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chMediasUsadas.Name = "chMediasUsadas";
            this.chMediasUsadas.Ripple = true;
            this.chMediasUsadas.Size = new System.Drawing.Size(139, 30);
            this.chMediasUsadas.TabIndex = 4;
            this.chMediasUsadas.Text = "Medias Utilizadas";
            this.chMediasUsadas.UseVisualStyleBackColor = true;
            // 
            // grdResumen
            // 
            this.grdResumen.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResumen.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResumen.AutoResize = false;
            this.grdResumen.bColor = System.Drawing.SystemColors.Window;
            this.grdResumen.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResumen.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResumen.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResumen.Col = 0;
            this.grdResumen.Cols = 10;
            this.grdResumen.DataMember = "";
            this.grdResumen.DataSource = null;
            this.grdResumen.EnableEdicion = false;
            this.grdResumen.Encabezado = "";
            this.grdResumen.fColor = System.Drawing.SystemColors.Control;
            this.grdResumen.FixCols = 0;
            this.grdResumen.FixRows = 0;
            this.grdResumen.FuenteEncabezado = null;
            this.grdResumen.FuentePieDePagina = null;
            this.grdResumen.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResumen.Location = new System.Drawing.Point(0, 212);
            this.grdResumen.Name = "grdResumen";
            this.grdResumen.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResumen.PintarFilaSel = true;
            this.grdResumen.Redraw = true;
            this.grdResumen.Row = 0;
            this.grdResumen.Rows = 50;
            this.grdResumen.Size = new System.Drawing.Size(263, 334);
            this.grdResumen.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Boletas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(78, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tropas";
            // 
            // lstBoletas
            // 
            this.lstBoletas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoletas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstBoletas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstBoletas.FormattingEnabled = true;
            this.lstBoletas.ItemHeight = 18;
            this.lstBoletas.Location = new System.Drawing.Point(5, 21);
            this.lstBoletas.Name = "lstBoletas";
            this.lstBoletas.Size = new System.Drawing.Size(70, 126);
            this.lstBoletas.TabIndex = 0;
            this.lstBoletas.SelectedIndexChanged += new System.EventHandler(this.LstBoletas_SelectedIndexChanged);
            this.lstBoletas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LstBoletas_MouseUp);
            // 
            // lstTropas
            // 
            this.lstTropas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTropas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstTropas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstTropas.FormattingEnabled = true;
            this.lstTropas.ItemHeight = 18;
            this.lstTropas.Location = new System.Drawing.Point(81, 21);
            this.lstTropas.Name = "lstTropas";
            this.lstTropas.Size = new System.Drawing.Size(70, 126);
            this.lstTropas.TabIndex = 0;
            this.lstTropas.SelectedIndexChanged += new System.EventHandler(this.LstBoletas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label3.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label3.Location = new System.Drawing.Point(4, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Resumen";
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLimpiar.Location = new System.Drawing.Point(1224, 690);
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
            this.cmdMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMostrar.Location = new System.Drawing.Point(1330, 690);
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
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 1;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(278, 196);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cSucursal
            // 
            this.cSucursal.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSucursal.Filtro_In = "";
            this.cSucursal.Location = new System.Drawing.Point(0, 0);
            this.cSucursal.Mostrar_Botones = true;
            this.cSucursal.Mostrar_Tipo = false;
            this.cSucursal.Name = "cSucursal";
            this.cSucursal.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucursal.Size = new System.Drawing.Size(278, 487);
            this.cSucursal.TabIndex = 3;
            this.cSucursal.Titulo = "Sucursales";
            this.cSucursal.Valor_Actual = -1;
            this.cSucursal.Cambio_Seleccion += new System.EventHandler(this.Csuc_Cambio_Seleccion);
            // 
            // cProds
            // 
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProds.Filtrar_Ver = false;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(0, 0);
            this.cProds.Mostrar_Tipo = false;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(270, 133);
            this.cProds.TabIndex = 0;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
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
            this.splitContainer2.Panel1.Controls.Add(this.cSucursal);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cFecha);
            this.splitContainer2.Size = new System.Drawing.Size(278, 687);
            this.splitContainer2.SplitterDistance = 487;
            this.splitContainer2.TabIndex = 4;
            // 
            // frmHacienda_Salidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 715);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmHacienda_Salidas";
            this.Text = "Salida";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSalida_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdSalida;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private Controles.cSucursales cSucursal;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTropas;
        private System.Windows.Forms.ListBox lstBoletas;
        private Controles.cProductos cProds;
        private MaterialSkin.Controls.MaterialCheckBox chMediasUsadas;
        private Grilla2.SpeedGrilla grdResumen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}