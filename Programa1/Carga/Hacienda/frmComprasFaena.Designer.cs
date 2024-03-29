﻿namespace Programa1.Carga.Hacienda
{
    partial class frmComprasFaena
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComprasFaena));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdCompras = new Grilla2.SpeedGrilla();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSubTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIVA = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTPercepciones = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTAgregados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCInt = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblATotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdAgregados = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grdFaena = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.grdRomaneos = new Grilla2.SpeedGrilla();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRendimiento = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCostoFaena = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCostoFinal = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdBoletas = new Grilla2.SpeedGrilla();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.txtNBoleta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nuTop = new System.Windows.Forms.NumericUpDown();
            this.cmdActualizar_Listado = new Programa1.Controles.cBoton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuTop)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1201, 666);
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.grdCompras);
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip3);
            this.splitContainer2.Panel2.Controls.Add(this.grdAgregados);
            this.splitContainer2.Size = new System.Drawing.Size(1201, 255);
            this.splitContainer2.SplitterDistance = 862;
            this.splitContainer2.TabIndex = 2;
            // 
            // grdCompras
            // 
            this.grdCompras.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCompras.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCompras.AutoResize = false;
            this.grdCompras.bColor = System.Drawing.SystemColors.Window;
            this.grdCompras.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCompras.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCompras.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCompras.Col = -2;
            this.grdCompras.Cols = 0;
            this.grdCompras.DataMember = "";
            this.grdCompras.DataSource = null;
            this.grdCompras.EnableEdicion = true;
            this.grdCompras.Encabezado = "";
            this.grdCompras.fColor = System.Drawing.SystemColors.Control;
            this.grdCompras.FixCols = 0;
            this.grdCompras.FixRows = 0;
            this.grdCompras.FuenteEncabezado = null;
            this.grdCompras.FuentePieDePagina = null;
            this.grdCompras.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCompras.Location = new System.Drawing.Point(3, 3);
            this.grdCompras.Name = "grdCompras";
            this.grdCompras.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCompras.PintarFilaSel = true;
            this.grdCompras.Redraw = true;
            this.grdCompras.Row = 0;
            this.grdCompras.Rows = 50;
            this.grdCompras.Size = new System.Drawing.Size(856, 221);
            this.grdCompras.TabIndex = 2;
            this.grdCompras.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdCompras_Editado);
            this.grdCompras.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdCompras_CambioFila);
            // 
            // statusStrip2
            // 
            this.statusStrip2.AutoSize = false;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblCCant,
            this.lblCKilos,
            this.lblSubTotal,
            this.lblIVA,
            this.lblTPercepciones,
            this.lblCTotal,
            this.lblTAgregados,
            this.lblCInt});
            this.statusStrip2.Location = new System.Drawing.Point(0, 227);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(862, 28);
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 23);
            // 
            // lblCCant
            // 
            this.lblCCant.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCCant.Name = "lblCCant";
            this.lblCCant.Size = new System.Drawing.Size(57, 23);
            this.lblCCant.Text = "Cabezas";
            this.lblCCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblCKilos
            // 
            this.lblCKilos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCKilos.Name = "lblCKilos";
            this.lblCKilos.Size = new System.Drawing.Size(36, 23);
            this.lblCKilos.Text = "Kilos";
            this.lblCKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(62, 23);
            this.lblSubTotal.Text = "Sub Total";
            this.lblSubTotal.Click += new System.EventHandler(this.lblSubTotal_Click);
            // 
            // lblIVA
            // 
            this.lblIVA.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblIVA.Name = "lblIVA";
            this.lblIVA.Size = new System.Drawing.Size(26, 23);
            this.lblIVA.Text = "IVA";
            // 
            // lblTPercepciones
            // 
            this.lblTPercepciones.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTPercepciones.Name = "lblTPercepciones";
            this.lblTPercepciones.Size = new System.Drawing.Size(85, 23);
            this.lblTPercepciones.Text = "Percepciones";
            // 
            // lblCTotal
            // 
            this.lblCTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCTotal.Name = "lblCTotal";
            this.lblCTotal.Size = new System.Drawing.Size(36, 23);
            this.lblCTotal.Text = "Total";
            this.lblCTotal.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTAgregados
            // 
            this.lblTAgregados.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTAgregados.Name = "lblTAgregados";
            this.lblTAgregados.Size = new System.Drawing.Size(73, 23);
            this.lblTAgregados.Text = "Agregados";
            // 
            // lblCInt
            // 
            this.lblCInt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCInt.Name = "lblCInt";
            this.lblCInt.Size = new System.Drawing.Size(82, 23);
            this.lblCInt.Text = "Integración:";
            this.lblCInt.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // statusStrip3
            // 
            this.statusStrip3.AutoSize = false;
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5,
            this.lblATotal});
            this.statusStrip3.Location = new System.Drawing.Point(0, 227);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(335, 28);
            this.statusStrip3.TabIndex = 4;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 23);
            // 
            // lblATotal
            // 
            this.lblATotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATotal.Name = "lblATotal";
            this.lblATotal.Size = new System.Drawing.Size(49, 23);
            this.lblATotal.Text = "Totales";
            // 
            // grdAgregados
            // 
            this.grdAgregados.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAgregados.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAgregados.AutoResize = false;
            this.grdAgregados.bColor = System.Drawing.SystemColors.Window;
            this.grdAgregados.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAgregados.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAgregados.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAgregados.Col = -2;
            this.grdAgregados.Cols = 0;
            this.grdAgregados.DataMember = "";
            this.grdAgregados.DataSource = null;
            this.grdAgregados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAgregados.EnableEdicion = true;
            this.grdAgregados.Encabezado = "";
            this.grdAgregados.fColor = System.Drawing.SystemColors.Control;
            this.grdAgregados.FixCols = 0;
            this.grdAgregados.FixRows = 0;
            this.grdAgregados.FuenteEncabezado = null;
            this.grdAgregados.FuentePieDePagina = null;
            this.grdAgregados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAgregados.Location = new System.Drawing.Point(0, 0);
            this.grdAgregados.Name = "grdAgregados";
            this.grdAgregados.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAgregados.PintarFilaSel = true;
            this.grdAgregados.Redraw = true;
            this.grdAgregados.Row = 0;
            this.grdAgregados.Rows = 50;
            this.grdAgregados.Size = new System.Drawing.Size(335, 255);
            this.grdAgregados.TabIndex = 3;
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
            this.splitContainer3.Panel1.Controls.Add(this.grdFaena);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.grdRomaneos);
            this.splitContainer3.Size = new System.Drawing.Size(1201, 379);
            this.splitContainer3.SplitterDistance = 902;
            this.splitContainer3.TabIndex = 2;
            // 
            // grdFaena
            // 
            this.grdFaena.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdFaena.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdFaena.AutoResize = false;
            this.grdFaena.bColor = System.Drawing.SystemColors.Window;
            this.grdFaena.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdFaena.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdFaena.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdFaena.Col = 0;
            this.grdFaena.Cols = 10;
            this.grdFaena.DataMember = "";
            this.grdFaena.DataSource = null;
            this.grdFaena.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFaena.EnableEdicion = true;
            this.grdFaena.Encabezado = "";
            this.grdFaena.fColor = System.Drawing.SystemColors.Control;
            this.grdFaena.FixCols = 0;
            this.grdFaena.FixRows = 0;
            this.grdFaena.FuenteEncabezado = null;
            this.grdFaena.FuentePieDePagina = null;
            this.grdFaena.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdFaena.Location = new System.Drawing.Point(0, 0);
            this.grdFaena.Name = "grdFaena";
            this.grdFaena.PieDePagina = "\t\tPage {0} of {1}";
            this.grdFaena.PintarFilaSel = true;
            this.grdFaena.Redraw = true;
            this.grdFaena.Row = 0;
            this.grdFaena.Rows = 50;
            this.grdFaena.Size = new System.Drawing.Size(902, 379);
            this.grdFaena.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Romaneos";
            // 
            // grdRomaneos
            // 
            this.grdRomaneos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdRomaneos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdRomaneos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRomaneos.AutoResize = false;
            this.grdRomaneos.bColor = System.Drawing.SystemColors.Window;
            this.grdRomaneos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdRomaneos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdRomaneos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdRomaneos.Col = -2;
            this.grdRomaneos.Cols = 0;
            this.grdRomaneos.DataMember = "";
            this.grdRomaneos.DataSource = null;
            this.grdRomaneos.EnableEdicion = true;
            this.grdRomaneos.Encabezado = "";
            this.grdRomaneos.fColor = System.Drawing.SystemColors.Control;
            this.grdRomaneos.FixCols = 0;
            this.grdRomaneos.FixRows = 0;
            this.grdRomaneos.FuenteEncabezado = null;
            this.grdRomaneos.FuentePieDePagina = null;
            this.grdRomaneos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdRomaneos.Location = new System.Drawing.Point(3, 23);
            this.grdRomaneos.Name = "grdRomaneos";
            this.grdRomaneos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdRomaneos.PintarFilaSel = true;
            this.grdRomaneos.Redraw = true;
            this.grdRomaneos.Row = 0;
            this.grdRomaneos.Rows = 50;
            this.grdRomaneos.Size = new System.Drawing.Size(289, 178);
            this.grdRomaneos.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilos,
            this.lblTotal,
            this.lblRendimiento,
            this.lblCostoFaena,
            this.lblCostoFinal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1201, 28);
            this.statusStrip1.TabIndex = 1;
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
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 23);
            this.lblTotal.Text = "Totales";
            this.lblTotal.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblRendimiento
            // 
            this.lblRendimiento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRendimiento.Name = "lblRendimiento";
            this.lblRendimiento.Size = new System.Drawing.Size(81, 23);
            this.lblRendimiento.Text = "Rendimiento";
            this.lblRendimiento.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblCostoFaena
            // 
            this.lblCostoFaena.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoFaena.Name = "lblCostoFaena";
            this.lblCostoFaena.Size = new System.Drawing.Size(42, 23);
            this.lblCostoFaena.Text = "Faena";
            // 
            // lblCostoFinal
            // 
            this.lblCostoFinal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoFinal.Name = "lblCostoFinal";
            this.lblCostoFinal.Size = new System.Drawing.Size(34, 23);
            this.lblCostoFinal.Text = "Final";
            // 
            // grdBoletas
            // 
            this.grdBoletas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdBoletas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBoletas.AutoResize = false;
            this.grdBoletas.bColor = System.Drawing.SystemColors.Window;
            this.grdBoletas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdBoletas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdBoletas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdBoletas.Col = 0;
            this.grdBoletas.Cols = 10;
            this.grdBoletas.DataMember = "";
            this.grdBoletas.DataSource = null;
            this.grdBoletas.EnableEdicion = true;
            this.grdBoletas.Encabezado = "";
            this.grdBoletas.fColor = System.Drawing.SystemColors.Control;
            this.grdBoletas.FixCols = 0;
            this.grdBoletas.FixRows = 0;
            this.grdBoletas.FuenteEncabezado = null;
            this.grdBoletas.FuentePieDePagina = null;
            this.grdBoletas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdBoletas.Location = new System.Drawing.Point(3, 21);
            this.grdBoletas.Name = "grdBoletas";
            this.grdBoletas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdBoletas.PintarFilaSel = true;
            this.grdBoletas.Redraw = true;
            this.grdBoletas.Row = 0;
            this.grdBoletas.Rows = 50;
            this.grdBoletas.Size = new System.Drawing.Size(375, 577);
            this.grdBoletas.TabIndex = 1;
            this.grdBoletas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdBoletas_CambioFila);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.Location = new System.Drawing.Point(12, 12);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.txtNBoleta);
            this.splitContainer5.Panel2.Controls.Add(this.label3);
            this.splitContainer5.Panel2.Controls.Add(this.nuTop);
            this.splitContainer5.Panel2.Controls.Add(this.cmdActualizar_Listado);
            this.splitContainer5.Panel2.Controls.Add(this.grdBoletas);
            this.splitContainer5.Panel2.Controls.Add(this.label1);
            this.splitContainer5.Size = new System.Drawing.Size(1583, 666);
            this.splitContainer5.SplitterDistance = 1201;
            this.splitContainer5.TabIndex = 1;
            // 
            // txtNBoleta
            // 
            this.txtNBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNBoleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNBoleta.Location = new System.Drawing.Point(49, 607);
            this.txtNBoleta.Name = "txtNBoleta";
            this.txtNBoleta.Size = new System.Drawing.Size(100, 13);
            this.txtNBoleta.TabIndex = 6;
            this.txtNBoleta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNBoleta_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buscar";
            // 
            // nuTop
            // 
            this.nuTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuTop.Location = new System.Drawing.Point(320, 604);
            this.nuTop.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuTop.Name = "nuTop";
            this.nuTop.Size = new System.Drawing.Size(55, 16);
            this.nuTop.TabIndex = 4;
            this.nuTop.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdActualizar_Listado
            // 
            this.cmdActualizar_Listado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdActualizar_Listado.Location = new System.Drawing.Point(0, 626);
            this.cmdActualizar_Listado.Name = "cmdActualizar_Listado";
            this.cmdActualizar_Listado.Size = new System.Drawing.Size(378, 40);
            this.cmdActualizar_Listado.TabIndex = 3;
            this.cmdActualizar_Listado.Texto = "Actualizar";
            this.cmdActualizar_Listado.Click += new System.EventHandler(this.cmdActualizar_Listado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Boletas";
            // 
            // frmComprasFaena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1607, 690);
            this.Controls.Add(this.splitContainer5);
            this.Name = "frmComprasFaena";
            this.Text = "Compras/Faena";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCCant;
        private System.Windows.Forms.ToolStripStatusLabel lblCKilos;
        private System.Windows.Forms.ToolStripStatusLabel lblCTotal;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private Grilla2.SpeedGrilla grdCompras;
        private Grilla2.SpeedGrilla grdBoletas;
        private System.Windows.Forms.ToolStripStatusLabel lblCInt;
        private Grilla2.SpeedGrilla grdAgregados;
        private Grilla2.SpeedGrilla grdFaena;
        private System.Windows.Forms.Label label2;
        private Grilla2.SpeedGrilla grdRomaneos;
        private System.Windows.Forms.ToolStripStatusLabel lblRendimiento;
        private System.Windows.Forms.ToolStripStatusLabel lblCostoFinal;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblATotal;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel lblSubTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblTPercepciones;
        private System.Windows.Forms.ToolStripStatusLabel lblTAgregados;
        private System.Windows.Forms.ToolStripStatusLabel lblIVA;
        private Controles.cBoton cmdActualizar_Listado;
        private System.Windows.Forms.ToolStripStatusLabel lblCostoFaena;
        private System.Windows.Forms.NumericUpDown nuTop;
        private System.Windows.Forms.TextBox txtNBoleta;
        private System.Windows.Forms.Label label3;
    }
}