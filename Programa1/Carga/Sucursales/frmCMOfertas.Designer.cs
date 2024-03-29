﻿namespace Programa1.Carga
{
    partial class frmCMOfertas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMOfertas));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.txtKilos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDescripcion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCostoOri = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManualOri = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoOri = new MaterialSkin.Controls.MaterialRadioButton();
            this.cmbProds = new System.Windows.Forms.ComboBox();
            this.cmbSucs = new System.Windows.Forms.ComboBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.chKilos = new MaterialSkin.Controls.MaterialCheckBox();
            this.chCosto_Original = new MaterialSkin.Controls.MaterialCheckBox();
            this.chDescripcion = new MaterialSkin.Controls.MaterialCheckBox();
            this.chProd = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSucursal = new MaterialSkin.Controls.MaterialCheckBox();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalO = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdOriginal = new Grilla2.SpeedGrilla();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblTotalR = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdResultado = new Grilla2.SpeedGrilla();
            this.txtCostoOfer = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManualOfe = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoOfe = new MaterialSkin.Controls.MaterialRadioButton();
            this.chCosto_Oferta = new MaterialSkin.Controls.MaterialCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.txtCostoOfer);
            this.splitContainer1.Panel1.Controls.Add(this.rdManualOfe);
            this.splitContainer1.Panel1.Controls.Add(this.rdAutoOfe);
            this.splitContainer1.Panel1.Controls.Add(this.chCosto_Oferta);
            this.splitContainer1.Panel1.Controls.Add(this.cmdGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.txtKilos);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.txtCostoOri);
            this.splitContainer1.Panel1.Controls.Add(this.rdManualOri);
            this.splitContainer1.Panel1.Controls.Add(this.rdAutoOri);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProds);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSucs);
            this.splitContainer1.Panel1.Controls.Add(this.dtFecha);
            this.splitContainer1.Panel1.Controls.Add(this.chKilos);
            this.splitContainer1.Panel1.Controls.Add(this.chCosto_Original);
            this.splitContainer1.Panel1.Controls.Add(this.chDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.chProd);
            this.splitContainer1.Panel1.Controls.Add(this.chSucursal);
            this.splitContainer1.Panel1.Controls.Add(this.chFecha);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1177, 639);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 1;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.BackColor = System.Drawing.Color.MistyRose;
            this.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar.Location = new System.Drawing.Point(1054, 46);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(111, 23);
            this.cmdGuardar.TabIndex = 5;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = false;
            this.cmdGuardar.Click += new System.EventHandler(this.CmdGuardar_Click);
            // 
            // txtKilos
            // 
            this.txtKilos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKilos.Depth = 0;
            this.txtKilos.Enabled = false;
            this.txtKilos.Hint = "Kilos";
            this.txtKilos.Location = new System.Drawing.Point(931, 45);
            this.txtKilos.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtKilos.Name = "txtKilos";
            this.txtKilos.PasswordChar = '\0';
            this.txtKilos.SelectedText = "";
            this.txtKilos.SelectionLength = 0;
            this.txtKilos.SelectionStart = 0;
            this.txtKilos.Size = new System.Drawing.Size(110, 23);
            this.txtKilos.TabIndex = 4;
            this.txtKilos.UseSystemPasswordChar = false;
            this.txtKilos.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescripcion.Depth = 0;
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Hint = "Descripcion";
            this.txtDescripcion.Location = new System.Drawing.Point(512, 46);
            this.txtDescripcion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.PasswordChar = '\0';
            this.txtDescripcion.SelectedText = "";
            this.txtDescripcion.SelectionLength = 0;
            this.txtDescripcion.SelectionStart = 0;
            this.txtDescripcion.Size = new System.Drawing.Size(159, 23);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.UseSystemPasswordChar = false;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // txtCostoOri
            // 
            this.txtCostoOri.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoOri.Depth = 0;
            this.txtCostoOri.Enabled = false;
            this.txtCostoOri.Hint = " Costo nuevo";
            this.txtCostoOri.Location = new System.Drawing.Point(816, 45);
            this.txtCostoOri.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoOri.Name = "txtCostoOri";
            this.txtCostoOri.PasswordChar = '\0';
            this.txtCostoOri.SelectedText = "";
            this.txtCostoOri.SelectionLength = 0;
            this.txtCostoOri.SelectionStart = 0;
            this.txtCostoOri.Size = new System.Drawing.Size(108, 23);
            this.txtCostoOri.TabIndex = 4;
            this.txtCostoOri.UseSystemPasswordChar = false;
            this.txtCostoOri.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            // 
            // rdManualOri
            // 
            this.rdManualOri.AutoSize = true;
            this.rdManualOri.Checked = true;
            this.rdManualOri.Depth = 0;
            this.rdManualOri.Enabled = false;
            this.rdManualOri.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdManualOri.Location = new System.Drawing.Point(735, 42);
            this.rdManualOri.Margin = new System.Windows.Forms.Padding(0);
            this.rdManualOri.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManualOri.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManualOri.Name = "rdManualOri";
            this.rdManualOri.Ripple = true;
            this.rdManualOri.Size = new System.Drawing.Size(78, 30);
            this.rdManualOri.TabIndex = 3;
            this.rdManualOri.TabStop = true;
            this.rdManualOri.Text = "Manual:";
            this.rdManualOri.UseVisualStyleBackColor = true;
            // 
            // rdAutoOri
            // 
            this.rdAutoOri.AutoSize = true;
            this.rdAutoOri.Depth = 0;
            this.rdAutoOri.Enabled = false;
            this.rdAutoOri.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoOri.Location = new System.Drawing.Point(673, 42);
            this.rdAutoOri.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoOri.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoOri.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoOri.Name = "rdAutoOri";
            this.rdAutoOri.Ripple = true;
            this.rdAutoOri.Size = new System.Drawing.Size(58, 30);
            this.rdAutoOri.TabIndex = 3;
            this.rdAutoOri.Text = "Auto";
            this.rdAutoOri.UseVisualStyleBackColor = true;
            this.rdAutoOri.CheckedChanged += new System.EventHandler(this.RdAuto_CheckedChanged);
            // 
            // cmbProds
            // 
            this.cmbProds.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbProds.Enabled = false;
            this.cmbProds.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbProds.FormattingEnabled = true;
            this.cmbProds.Location = new System.Drawing.Point(331, 42);
            this.cmbProds.Name = "cmbProds";
            this.cmbProds.Size = new System.Drawing.Size(175, 26);
            this.cmbProds.TabIndex = 2;
            this.cmbProds.Text = "Seleccionar";
            this.cmbProds.SelectedIndexChanged += new System.EventHandler(this.CmbProds_SelectedIndexChanged);
            // 
            // cmbSucs
            // 
            this.cmbSucs.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSucs.Enabled = false;
            this.cmbSucs.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbSucs.FormattingEnabled = true;
            this.cmbSucs.Location = new System.Drawing.Point(139, 42);
            this.cmbSucs.Name = "cmbSucs";
            this.cmbSucs.Size = new System.Drawing.Size(175, 26);
            this.cmbSucs.TabIndex = 2;
            this.cmbSucs.Text = "Seleccionar";
            this.cmbSucs.SelectedIndexChanged += new System.EventHandler(this.CmbSucs_SelectedIndexChanged);
            // 
            // dtFecha
            // 
            this.dtFecha.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtFecha.Enabled = false;
            this.dtFecha.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(12, 42);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(113, 24);
            this.dtFecha.TabIndex = 1;
            this.dtFecha.ValueChanged += new System.EventHandler(this.DtFecha_ValueChanged);
            // 
            // chKilos
            // 
            this.chKilos.AutoSize = true;
            this.chKilos.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chKilos.Depth = 0;
            this.chKilos.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chKilos.Location = new System.Drawing.Point(925, 9);
            this.chKilos.Margin = new System.Windows.Forms.Padding(0);
            this.chKilos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chKilos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chKilos.Name = "chKilos";
            this.chKilos.Ripple = true;
            this.chKilos.Size = new System.Drawing.Size(61, 30);
            this.chKilos.TabIndex = 0;
            this.chKilos.Text = "Kilos";
            this.chKilos.UseVisualStyleBackColor = true;
            this.chKilos.CheckedChanged += new System.EventHandler(this.ChKilos_CheckedChanged);
            // 
            // chCosto_Original
            // 
            this.chCosto_Original.AutoSize = true;
            this.chCosto_Original.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCosto_Original.Depth = 0;
            this.chCosto_Original.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCosto_Original.Location = new System.Drawing.Point(673, 9);
            this.chCosto_Original.Margin = new System.Windows.Forms.Padding(0);
            this.chCosto_Original.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCosto_Original.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCosto_Original.Name = "chCosto_Original";
            this.chCosto_Original.Ripple = true;
            this.chCosto_Original.Size = new System.Drawing.Size(117, 30);
            this.chCosto_Original.TabIndex = 0;
            this.chCosto_Original.Text = "Costo Original";
            this.chCosto_Original.UseVisualStyleBackColor = true;
            this.chCosto_Original.CheckedChanged += new System.EventHandler(this.ChCosto_CheckedChanged);
            // 
            // chDescripcion
            // 
            this.chDescripcion.AutoSize = true;
            this.chDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chDescripcion.Depth = 0;
            this.chDescripcion.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chDescripcion.Location = new System.Drawing.Point(507, 9);
            this.chDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.chDescripcion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chDescripcion.MouseState = MaterialSkin.MouseState.HOVER;
            this.chDescripcion.Name = "chDescripcion";
            this.chDescripcion.Ripple = true;
            this.chDescripcion.Size = new System.Drawing.Size(103, 30);
            this.chDescripcion.TabIndex = 0;
            this.chDescripcion.Text = "Descripcion";
            this.chDescripcion.UseVisualStyleBackColor = true;
            this.chDescripcion.CheckedChanged += new System.EventHandler(this.ChDescripcion_CheckedChanged);
            // 
            // chProd
            // 
            this.chProd.AutoSize = true;
            this.chProd.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chProd.Depth = 0;
            this.chProd.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chProd.Location = new System.Drawing.Point(326, 9);
            this.chProd.Margin = new System.Windows.Forms.Padding(0);
            this.chProd.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProd.Name = "chProd";
            this.chProd.Ripple = true;
            this.chProd.Size = new System.Drawing.Size(86, 30);
            this.chProd.TabIndex = 0;
            this.chProd.Text = "Producto";
            this.chProd.UseVisualStyleBackColor = true;
            this.chProd.CheckedChanged += new System.EventHandler(this.ChProd_CheckedChanged);
            // 
            // chSucursal
            // 
            this.chSucursal.AutoSize = true;
            this.chSucursal.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chSucursal.Depth = 0;
            this.chSucursal.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chSucursal.Location = new System.Drawing.Point(134, 9);
            this.chSucursal.Margin = new System.Windows.Forms.Padding(0);
            this.chSucursal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSucursal.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSucursal.Name = "chSucursal";
            this.chSucursal.Ripple = true;
            this.chSucursal.Size = new System.Drawing.Size(84, 30);
            this.chSucursal.TabIndex = 0;
            this.chSucursal.Text = "Sucursal";
            this.chSucursal.UseVisualStyleBackColor = true;
            this.chSucursal.CheckedChanged += new System.EventHandler(this.ChSucursal_CheckedChanged);
            // 
            // chFecha
            // 
            this.chFecha.AutoSize = true;
            this.chFecha.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chFecha.Depth = 0;
            this.chFecha.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chFecha.Location = new System.Drawing.Point(9, 9);
            this.chFecha.Margin = new System.Windows.Forms.Padding(0);
            this.chFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFecha.Name = "chFecha";
            this.chFecha.Ripple = true;
            this.chFecha.Size = new System.Drawing.Size(67, 30);
            this.chFecha.TabIndex = 0;
            this.chFecha.Text = "Fecha";
            this.chFecha.UseVisualStyleBackColor = true;
            this.chFecha.CheckedChanged += new System.EventHandler(this.ChFecha_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer2.Panel1.Controls.Add(this.grdOriginal);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer2.Panel2.Controls.Add(this.grdResultado);
            this.splitContainer2.Size = new System.Drawing.Size(1177, 482);
            this.splitContainer2.SplitterDistance = 198;
            this.splitContainer2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalO});
            this.statusStrip1.Location = new System.Drawing.Point(0, 176);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1177, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalO
            // 
            this.lblTotalO.Name = "lblTotalO";
            this.lblTotalO.Size = new System.Drawing.Size(0, 17);
            // 
            // grdOriginal
            // 
            this.grdOriginal.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdOriginal.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdOriginal.AutoResize = false;
            this.grdOriginal.bColor = System.Drawing.SystemColors.Window;
            this.grdOriginal.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdOriginal.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdOriginal.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdOriginal.Col = 0;
            this.grdOriginal.Cols = 10;
            this.grdOriginal.DataMember = "";
            this.grdOriginal.DataSource = null;
            this.grdOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOriginal.EnableEdicion = true;
            this.grdOriginal.Encabezado = "";
            this.grdOriginal.fColor = System.Drawing.SystemColors.Control;
            this.grdOriginal.FixCols = 0;
            this.grdOriginal.FixRows = 0;
            this.grdOriginal.FuenteEncabezado = null;
            this.grdOriginal.FuentePieDePagina = null;
            this.grdOriginal.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdOriginal.Location = new System.Drawing.Point(0, 0);
            this.grdOriginal.Name = "grdOriginal";
            this.grdOriginal.PieDePagina = "\t\tPage {0} of {1}";
            this.grdOriginal.PintarFilaSel = true;
            this.grdOriginal.Redraw = true;
            this.grdOriginal.Row = 0;
            this.grdOriginal.Rows = 50;
            this.grdOriginal.Size = new System.Drawing.Size(1177, 198);
            this.grdOriginal.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalR});
            this.statusStrip2.Location = new System.Drawing.Point(0, 258);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1177, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblTotalR
            // 
            this.lblTotalR.Name = "lblTotalR";
            this.lblTotalR.Size = new System.Drawing.Size(0, 17);
            // 
            // grdResultado
            // 
            this.grdResultado.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResultado.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResultado.AutoResize = false;
            this.grdResultado.bColor = System.Drawing.SystemColors.Window;
            this.grdResultado.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResultado.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResultado.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResultado.Col = 0;
            this.grdResultado.Cols = 10;
            this.grdResultado.DataMember = "";
            this.grdResultado.DataSource = null;
            this.grdResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResultado.EnableEdicion = true;
            this.grdResultado.Encabezado = "";
            this.grdResultado.fColor = System.Drawing.SystemColors.Control;
            this.grdResultado.FixCols = 0;
            this.grdResultado.FixRows = 0;
            this.grdResultado.FuenteEncabezado = null;
            this.grdResultado.FuentePieDePagina = null;
            this.grdResultado.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResultado.Location = new System.Drawing.Point(0, 0);
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResultado.PintarFilaSel = true;
            this.grdResultado.Redraw = true;
            this.grdResultado.Row = 0;
            this.grdResultado.Rows = 50;
            this.grdResultado.Size = new System.Drawing.Size(1177, 280);
            this.grdResultado.TabIndex = 1;
            // 
            // txtCostoOfer
            // 
            this.txtCostoOfer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoOfer.Depth = 0;
            this.txtCostoOfer.Enabled = false;
            this.txtCostoOfer.Hint = " Costo nuevo";
            this.txtCostoOfer.Location = new System.Drawing.Point(816, 115);
            this.txtCostoOfer.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoOfer.Name = "txtCostoOfer";
            this.txtCostoOfer.PasswordChar = '\0';
            this.txtCostoOfer.SelectedText = "";
            this.txtCostoOfer.SelectionLength = 0;
            this.txtCostoOfer.SelectionStart = 0;
            this.txtCostoOfer.Size = new System.Drawing.Size(108, 23);
            this.txtCostoOfer.TabIndex = 9;
            this.txtCostoOfer.UseSystemPasswordChar = false;
            this.txtCostoOfer.TextChanged += new System.EventHandler(this.txtCostoOfer_TextChanged);
            // 
            // rdManualOfe
            // 
            this.rdManualOfe.AutoSize = true;
            this.rdManualOfe.Checked = true;
            this.rdManualOfe.Depth = 0;
            this.rdManualOfe.Enabled = false;
            this.rdManualOfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdManualOfe.Location = new System.Drawing.Point(735, 112);
            this.rdManualOfe.Margin = new System.Windows.Forms.Padding(0);
            this.rdManualOfe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManualOfe.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManualOfe.Name = "rdManualOfe";
            this.rdManualOfe.Ripple = true;
            this.rdManualOfe.Size = new System.Drawing.Size(78, 30);
            this.rdManualOfe.TabIndex = 7;
            this.rdManualOfe.TabStop = true;
            this.rdManualOfe.Text = "Manual:";
            this.rdManualOfe.UseVisualStyleBackColor = true;
            this.rdManualOfe.CheckedChanged += new System.EventHandler(this.rdManualOfe_CheckedChanged);
            // 
            // rdAutoOfe
            // 
            this.rdAutoOfe.AutoSize = true;
            this.rdAutoOfe.Depth = 0;
            this.rdAutoOfe.Enabled = false;
            this.rdAutoOfe.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoOfe.Location = new System.Drawing.Point(673, 112);
            this.rdAutoOfe.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoOfe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoOfe.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoOfe.Name = "rdAutoOfe";
            this.rdAutoOfe.Ripple = true;
            this.rdAutoOfe.Size = new System.Drawing.Size(58, 30);
            this.rdAutoOfe.TabIndex = 8;
            this.rdAutoOfe.Text = "Auto";
            this.rdAutoOfe.UseVisualStyleBackColor = true;
            this.rdAutoOfe.CheckedChanged += new System.EventHandler(this.rdAutoOfe_CheckedChanged);
            // 
            // chCosto_Oferta
            // 
            this.chCosto_Oferta.AutoSize = true;
            this.chCosto_Oferta.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCosto_Oferta.Depth = 0;
            this.chCosto_Oferta.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCosto_Oferta.Location = new System.Drawing.Point(673, 79);
            this.chCosto_Oferta.Margin = new System.Windows.Forms.Padding(0);
            this.chCosto_Oferta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCosto_Oferta.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCosto_Oferta.Name = "chCosto_Oferta";
            this.chCosto_Oferta.Ripple = true;
            this.chCosto_Oferta.Size = new System.Drawing.Size(108, 30);
            this.chCosto_Oferta.TabIndex = 6;
            this.chCosto_Oferta.Text = "Costo Oferta";
            this.chCosto_Oferta.UseVisualStyleBackColor = true;
            this.chCosto_Oferta.CheckedChanged += new System.EventHandler(this.chCosto_Oferta_CheckedChanged);
            // 
            // frmCMOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 639);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCMOfertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Masivo Ofertas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdOriginal;
        private Grilla2.SpeedGrilla grdResultado;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalO;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalR;
        private MaterialSkin.Controls.MaterialCheckBox chFecha;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private MaterialSkin.Controls.MaterialCheckBox chSucursal;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoOri;
        private MaterialSkin.Controls.MaterialRadioButton rdManualOri;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoOri;
        private System.Windows.Forms.ComboBox cmbProds;
        private System.Windows.Forms.ComboBox cmbSucs;
        private MaterialSkin.Controls.MaterialCheckBox chCosto_Original;
        private MaterialSkin.Controls.MaterialCheckBox chProd;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtKilos;
        private MaterialSkin.Controls.MaterialCheckBox chKilos;
        private System.Windows.Forms.Button cmdGuardar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescripcion;
        private MaterialSkin.Controls.MaterialCheckBox chDescripcion;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoOfer;
        private MaterialSkin.Controls.MaterialRadioButton rdManualOfe;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoOfe;
        private MaterialSkin.Controls.MaterialCheckBox chCosto_Oferta;
    }
}