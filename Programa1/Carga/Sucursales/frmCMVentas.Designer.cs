namespace Programa1.Carga
{
    partial class frmCMVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVentas));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCostoVenta = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManualVenta = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoVenta = new MaterialSkin.Controls.MaterialRadioButton();
            this.chCostoVenta = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.txtKilos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDescripcion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCostoCompra = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManual = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoCompra = new MaterialSkin.Controls.MaterialRadioButton();
            this.cmbProds = new System.Windows.Forms.ComboBox();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.chKilos = new MaterialSkin.Controls.MaterialCheckBox();
            this.chCostoCompra = new MaterialSkin.Controls.MaterialCheckBox();
            this.chDescripcion = new MaterialSkin.Controls.MaterialCheckBox();
            this.chProd = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSucursal = new MaterialSkin.Controls.MaterialCheckBox();
            this.chProveedor = new MaterialSkin.Controls.MaterialCheckBox();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalO = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdOriginal = new Grilla2.SpeedGrilla();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblTotalR = new System.Windows.Forms.ToolStripStatusLabel();
            this.grdResultado = new Grilla2.SpeedGrilla();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.txtKilos);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.txtCostoCompra);
            this.splitContainer1.Panel1.Controls.Add(this.rdManual);
            this.splitContainer1.Panel1.Controls.Add(this.rdAutoCompra);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProds);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSucursal);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProveedor);
            this.splitContainer1.Panel1.Controls.Add(this.dtFecha);
            this.splitContainer1.Panel1.Controls.Add(this.chKilos);
            this.splitContainer1.Panel1.Controls.Add(this.chCostoCompra);
            this.splitContainer1.Panel1.Controls.Add(this.chDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.chProd);
            this.splitContainer1.Panel1.Controls.Add(this.chSucursal);
            this.splitContainer1.Panel1.Controls.Add(this.chProveedor);
            this.splitContainer1.Panel1.Controls.Add(this.chFecha);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 639);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCostoVenta);
            this.panel1.Controls.Add(this.rdManualVenta);
            this.panel1.Controls.Add(this.rdAutoVenta);
            this.panel1.Controls.Add(this.chCostoVenta);
            this.panel1.Location = new System.Drawing.Point(673, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 74);
            this.panel1.TabIndex = 6;
            // 
            // txtCostoVenta
            // 
            this.txtCostoVenta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoVenta.Depth = 0;
            this.txtCostoVenta.Enabled = false;
            this.txtCostoVenta.Hint = " Costo nuevo";
            this.txtCostoVenta.Location = new System.Drawing.Point(145, 36);
            this.txtCostoVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoVenta.Name = "txtCostoVenta";
            this.txtCostoVenta.PasswordChar = '\0';
            this.txtCostoVenta.SelectedText = "";
            this.txtCostoVenta.SelectionLength = 0;
            this.txtCostoVenta.SelectionStart = 0;
            this.txtCostoVenta.Size = new System.Drawing.Size(108, 23);
            this.txtCostoVenta.TabIndex = 4;
            this.txtCostoVenta.UseSystemPasswordChar = false;
            this.txtCostoVenta.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            // 
            // rdManualVenta
            // 
            this.rdManualVenta.AutoSize = true;
            this.rdManualVenta.Checked = true;
            this.rdManualVenta.Depth = 0;
            this.rdManualVenta.Enabled = false;
            this.rdManualVenta.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdManualVenta.Location = new System.Drawing.Point(64, 33);
            this.rdManualVenta.Margin = new System.Windows.Forms.Padding(0);
            this.rdManualVenta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManualVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManualVenta.Name = "rdManualVenta";
            this.rdManualVenta.Ripple = true;
            this.rdManualVenta.Size = new System.Drawing.Size(78, 30);
            this.rdManualVenta.TabIndex = 3;
            this.rdManualVenta.TabStop = true;
            this.rdManualVenta.Text = "Manual:";
            this.rdManualVenta.UseVisualStyleBackColor = true;
            // 
            // rdAutoVenta
            // 
            this.rdAutoVenta.AutoSize = true;
            this.rdAutoVenta.Depth = 0;
            this.rdAutoVenta.Enabled = false;
            this.rdAutoVenta.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoVenta.Location = new System.Drawing.Point(2, 33);
            this.rdAutoVenta.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoVenta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoVenta.Name = "rdAutoVenta";
            this.rdAutoVenta.Ripple = true;
            this.rdAutoVenta.Size = new System.Drawing.Size(58, 30);
            this.rdAutoVenta.TabIndex = 3;
            this.rdAutoVenta.Text = "Auto";
            this.rdAutoVenta.UseVisualStyleBackColor = true;
            this.rdAutoVenta.CheckedChanged += new System.EventHandler(this.RdAuto_CheckedChanged);
            // 
            // chCostoVenta
            // 
            this.chCostoVenta.AutoSize = true;
            this.chCostoVenta.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCostoVenta.Depth = 0;
            this.chCostoVenta.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCostoVenta.Location = new System.Drawing.Point(1, 0);
            this.chCostoVenta.Margin = new System.Windows.Forms.Padding(0);
            this.chCostoVenta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCostoVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCostoVenta.Name = "chCostoVenta";
            this.chCostoVenta.Ripple = true;
            this.chCostoVenta.Size = new System.Drawing.Size(106, 30);
            this.chCostoVenta.TabIndex = 0;
            this.chCostoVenta.Text = "Costo Venta";
            this.chCostoVenta.UseVisualStyleBackColor = true;
            this.chCostoVenta.CheckedChanged += new System.EventHandler(this.ChCostoVenta_CheckedChanged);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.BackColor = System.Drawing.Color.MistyRose;
            this.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar.Location = new System.Drawing.Point(1099, 46);
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
            this.txtKilos.Location = new System.Drawing.Point(977, 45);
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
            // txtCostoCompra
            // 
            this.txtCostoCompra.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoCompra.Depth = 0;
            this.txtCostoCompra.Enabled = false;
            this.txtCostoCompra.Hint = " Costo nuevo";
            this.txtCostoCompra.Location = new System.Drawing.Point(817, 45);
            this.txtCostoCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoCompra.Name = "txtCostoCompra";
            this.txtCostoCompra.PasswordChar = '\0';
            this.txtCostoCompra.SelectedText = "";
            this.txtCostoCompra.SelectionLength = 0;
            this.txtCostoCompra.SelectionStart = 0;
            this.txtCostoCompra.Size = new System.Drawing.Size(108, 23);
            this.txtCostoCompra.TabIndex = 4;
            this.txtCostoCompra.UseSystemPasswordChar = false;
            this.txtCostoCompra.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            // 
            // rdManual
            // 
            this.rdManual.AutoSize = true;
            this.rdManual.Checked = true;
            this.rdManual.Depth = 0;
            this.rdManual.Enabled = false;
            this.rdManual.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdManual.Location = new System.Drawing.Point(736, 42);
            this.rdManual.Margin = new System.Windows.Forms.Padding(0);
            this.rdManual.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManual.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManual.Name = "rdManual";
            this.rdManual.Ripple = true;
            this.rdManual.Size = new System.Drawing.Size(78, 30);
            this.rdManual.TabIndex = 3;
            this.rdManual.TabStop = true;
            this.rdManual.Text = "Manual:";
            this.rdManual.UseVisualStyleBackColor = true;
            // 
            // rdAutoCompra
            // 
            this.rdAutoCompra.AutoSize = true;
            this.rdAutoCompra.Depth = 0;
            this.rdAutoCompra.Enabled = false;
            this.rdAutoCompra.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoCompra.Location = new System.Drawing.Point(674, 42);
            this.rdAutoCompra.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoCompra.Name = "rdAutoCompra";
            this.rdAutoCompra.Ripple = true;
            this.rdAutoCompra.Size = new System.Drawing.Size(58, 30);
            this.rdAutoCompra.TabIndex = 3;
            this.rdAutoCompra.Text = "Auto";
            this.rdAutoCompra.UseVisualStyleBackColor = true;
            this.rdAutoCompra.CheckedChanged += new System.EventHandler(this.RdAuto_CheckedChanged);
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
            // cmbSucursal
            // 
            this.cmbSucursal.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSucursal.Enabled = false;
            this.cmbSucursal.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(139, 107);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(175, 26);
            this.cmbSucursal.TabIndex = 2;
            this.cmbSucursal.Text = "Seleccionar";
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.CmbSucursal_SelectedIndexChanged);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbProveedor.Enabled = false;
            this.cmbProveedor.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(139, 42);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(175, 26);
            this.cmbProveedor.TabIndex = 2;
            this.cmbProveedor.Text = "Seleccionar";
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.CmbSucursal_SelectedIndexChanged);
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
            this.chKilos.Location = new System.Drawing.Point(971, 9);
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
            // chCostoCompra
            // 
            this.chCostoCompra.AutoSize = true;
            this.chCostoCompra.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCostoCompra.Depth = 0;
            this.chCostoCompra.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCostoCompra.Location = new System.Drawing.Point(673, 9);
            this.chCostoCompra.Margin = new System.Windows.Forms.Padding(0);
            this.chCostoCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCostoCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCostoCompra.Name = "chCostoCompra";
            this.chCostoCompra.Ripple = true;
            this.chCostoCompra.Size = new System.Drawing.Size(118, 30);
            this.chCostoCompra.TabIndex = 0;
            this.chCostoCompra.Text = "Costo Compra";
            this.chCostoCompra.UseVisualStyleBackColor = true;
            this.chCostoCompra.CheckedChanged += new System.EventHandler(this.ChCosto_CheckedChanged);
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
            this.chSucursal.Location = new System.Drawing.Point(134, 74);
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
            // chProveedor
            // 
            this.chProveedor.AutoSize = true;
            this.chProveedor.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chProveedor.Depth = 0;
            this.chProveedor.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chProveedor.Location = new System.Drawing.Point(134, 9);
            this.chProveedor.Margin = new System.Windows.Forms.Padding(0);
            this.chProveedor.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProveedor.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProveedor.Name = "chProveedor";
            this.chProveedor.Ripple = true;
            this.chProveedor.Size = new System.Drawing.Size(93, 30);
            this.chProveedor.TabIndex = 0;
            this.chProveedor.Text = "Proveedor";
            this.chProveedor.UseVisualStyleBackColor = true;
            this.chProveedor.CheckedChanged += new System.EventHandler(this.ChProveedor_CheckedChanged);
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
            this.splitContainer2.Size = new System.Drawing.Size(1222, 492);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalO});
            this.statusStrip1.Location = new System.Drawing.Point(0, 180);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1222, 22);
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
            this.grdOriginal.MenuActivado = false;
            this.grdOriginal.Name = "grdOriginal";
            this.grdOriginal.PieDePagina = "\t\tPage {0} of {1}";
            this.grdOriginal.PintarFilaSel = true;
            this.grdOriginal.Redraw = true;
            this.grdOriginal.Row = 0;
            this.grdOriginal.Rows = 50;
            this.grdOriginal.Size = new System.Drawing.Size(1222, 202);
            this.grdOriginal.TabIndex = 0;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalR});
            this.statusStrip2.Location = new System.Drawing.Point(0, 264);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1222, 22);
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
            this.grdResultado.MenuActivado = false;
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResultado.PintarFilaSel = true;
            this.grdResultado.Redraw = true;
            this.grdResultado.Row = 0;
            this.grdResultado.Rows = 50;
            this.grdResultado.Size = new System.Drawing.Size(1222, 286);
            this.grdResultado.TabIndex = 1;
            // 
            // frmCMVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 639);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCMVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Masivo Ventas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private MaterialSkin.Controls.MaterialCheckBox chProveedor;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoCompra;
        private MaterialSkin.Controls.MaterialRadioButton rdManual;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoCompra;
        private System.Windows.Forms.ComboBox cmbProds;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private MaterialSkin.Controls.MaterialCheckBox chCostoCompra;
        private MaterialSkin.Controls.MaterialCheckBox chProd;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtKilos;
        private MaterialSkin.Controls.MaterialCheckBox chKilos;
        private System.Windows.Forms.Button cmdGuardar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDescripcion;
        private MaterialSkin.Controls.MaterialCheckBox chDescripcion;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoVenta;
        private MaterialSkin.Controls.MaterialRadioButton rdManualVenta;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoVenta;
        private MaterialSkin.Controls.MaterialCheckBox chCostoVenta;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private MaterialSkin.Controls.MaterialCheckBox chSucursal;
    }
}