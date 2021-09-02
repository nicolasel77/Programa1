namespace Programa1.Carga
{
    partial class frmCMApicada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMApicada));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtKilosS = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.chKilosS = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmbProdsS = new System.Windows.Forms.ComboBox();
            this.chProdS = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCostoS = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManualS = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoS = new MaterialSkin.Controls.MaterialRadioButton();
            this.chCostoS = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.txtKilosA = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtCostoA = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.rdManualA = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAutoA = new MaterialSkin.Controls.MaterialRadioButton();
            this.cmbProdsA = new System.Windows.Forms.ComboBox();
            this.cmbSuc = new System.Windows.Forms.ComboBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.chKilosA = new MaterialSkin.Controls.MaterialCheckBox();
            this.chCostoA = new MaterialSkin.Controls.MaterialCheckBox();
            this.chProdA = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSuc = new MaterialSkin.Controls.MaterialCheckBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtKilosS);
            this.splitContainer1.Panel1.Controls.Add(this.chKilosS);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProdsS);
            this.splitContainer1.Panel1.Controls.Add(this.chProdS);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.cmdGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.txtKilosA);
            this.splitContainer1.Panel1.Controls.Add(this.txtCostoA);
            this.splitContainer1.Panel1.Controls.Add(this.rdManualA);
            this.splitContainer1.Panel1.Controls.Add(this.rdAutoA);
            this.splitContainer1.Panel1.Controls.Add(this.cmbProdsA);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSuc);
            this.splitContainer1.Panel1.Controls.Add(this.dtFecha);
            this.splitContainer1.Panel1.Controls.Add(this.chKilosA);
            this.splitContainer1.Panel1.Controls.Add(this.chCostoA);
            this.splitContainer1.Panel1.Controls.Add(this.chProdA);
            this.splitContainer1.Panel1.Controls.Add(this.chSuc);
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
            // txtKilosS
            // 
            this.txtKilosS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKilosS.Depth = 0;
            this.txtKilosS.Enabled = false;
            this.txtKilosS.Hint = "Kilos S";
            this.txtKilosS.Location = new System.Drawing.Point(977, 107);
            this.txtKilosS.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtKilosS.Name = "txtKilosS";
            this.txtKilosS.PasswordChar = '\0';
            this.txtKilosS.SelectedText = "";
            this.txtKilosS.SelectionLength = 0;
            this.txtKilosS.SelectionStart = 0;
            this.txtKilosS.Size = new System.Drawing.Size(110, 23);
            this.txtKilosS.TabIndex = 10;
            this.txtKilosS.UseSystemPasswordChar = false;
            this.txtKilosS.TextChanged += new System.EventHandler(this.txtKilosS_TextChanged);
            // 
            // chKilosS
            // 
            this.chKilosS.AutoSize = true;
            this.chKilosS.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chKilosS.Depth = 0;
            this.chKilosS.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chKilosS.Location = new System.Drawing.Point(971, 71);
            this.chKilosS.Margin = new System.Windows.Forms.Padding(0);
            this.chKilosS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chKilosS.MouseState = MaterialSkin.MouseState.HOVER;
            this.chKilosS.Name = "chKilosS";
            this.chKilosS.Ripple = true;
            this.chKilosS.Size = new System.Drawing.Size(72, 30);
            this.chKilosS.TabIndex = 9;
            this.chKilosS.Text = "Kilos S";
            this.chKilosS.UseVisualStyleBackColor = true;
            this.chKilosS.CheckedChanged += new System.EventHandler(this.chKilosS_CheckedChanged);
            // 
            // cmbProdsS
            // 
            this.cmbProdsS.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbProdsS.Enabled = false;
            this.cmbProdsS.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbProdsS.FormattingEnabled = true;
            this.cmbProdsS.Location = new System.Drawing.Point(331, 107);
            this.cmbProdsS.Name = "cmbProdsS";
            this.cmbProdsS.Size = new System.Drawing.Size(175, 26);
            this.cmbProdsS.TabIndex = 8;
            this.cmbProdsS.Text = "Seleccionar";
            this.cmbProdsS.SelectedIndexChanged += new System.EventHandler(this.cmbProdsS_SelectedIndexChanged);
            // 
            // chProdS
            // 
            this.chProdS.AutoSize = true;
            this.chProdS.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chProdS.Depth = 0;
            this.chProdS.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chProdS.Location = new System.Drawing.Point(326, 74);
            this.chProdS.Margin = new System.Windows.Forms.Padding(0);
            this.chProdS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProdS.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProdS.Name = "chProdS";
            this.chProdS.Ripple = true;
            this.chProdS.Size = new System.Drawing.Size(98, 30);
            this.chProdS.TabIndex = 7;
            this.chProdS.Text = "Producto S";
            this.chProdS.UseVisualStyleBackColor = true;
            this.chProdS.CheckedChanged += new System.EventHandler(this.chProdS_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCostoS);
            this.panel1.Controls.Add(this.rdManualS);
            this.panel1.Controls.Add(this.rdAutoS);
            this.panel1.Controls.Add(this.chCostoS);
            this.panel1.Location = new System.Drawing.Point(673, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 74);
            this.panel1.TabIndex = 6;
            // 
            // txtCostoS
            // 
            this.txtCostoS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoS.Depth = 0;
            this.txtCostoS.Enabled = false;
            this.txtCostoS.Hint = " Costo nuevo";
            this.txtCostoS.Location = new System.Drawing.Point(145, 36);
            this.txtCostoS.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoS.Name = "txtCostoS";
            this.txtCostoS.PasswordChar = '\0';
            this.txtCostoS.SelectedText = "";
            this.txtCostoS.SelectionLength = 0;
            this.txtCostoS.SelectionStart = 0;
            this.txtCostoS.Size = new System.Drawing.Size(108, 23);
            this.txtCostoS.TabIndex = 4;
            this.txtCostoS.UseSystemPasswordChar = false;
            this.txtCostoS.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            // 
            // rdManualS
            // 
            this.rdManualS.AutoSize = true;
            this.rdManualS.Checked = true;
            this.rdManualS.Depth = 0;
            this.rdManualS.Enabled = false;
            this.rdManualS.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdManualS.Location = new System.Drawing.Point(64, 33);
            this.rdManualS.Margin = new System.Windows.Forms.Padding(0);
            this.rdManualS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManualS.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManualS.Name = "rdManualS";
            this.rdManualS.Ripple = true;
            this.rdManualS.Size = new System.Drawing.Size(78, 30);
            this.rdManualS.TabIndex = 3;
            this.rdManualS.TabStop = true;
            this.rdManualS.Text = "Manual:";
            this.rdManualS.UseVisualStyleBackColor = true;
            // 
            // rdAutoS
            // 
            this.rdAutoS.AutoSize = true;
            this.rdAutoS.Depth = 0;
            this.rdAutoS.Enabled = false;
            this.rdAutoS.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoS.Location = new System.Drawing.Point(2, 33);
            this.rdAutoS.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoS.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoS.Name = "rdAutoS";
            this.rdAutoS.Ripple = true;
            this.rdAutoS.Size = new System.Drawing.Size(58, 30);
            this.rdAutoS.TabIndex = 3;
            this.rdAutoS.Text = "Auto";
            this.rdAutoS.UseVisualStyleBackColor = true;
            this.rdAutoS.CheckedChanged += new System.EventHandler(this.RdAuto_CheckedChanged);
            // 
            // chCostoS
            // 
            this.chCostoS.AutoSize = true;
            this.chCostoS.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCostoS.Depth = 0;
            this.chCostoS.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCostoS.Location = new System.Drawing.Point(1, 0);
            this.chCostoS.Margin = new System.Windows.Forms.Padding(0);
            this.chCostoS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCostoS.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCostoS.Name = "chCostoS";
            this.chCostoS.Ripple = true;
            this.chCostoS.Size = new System.Drawing.Size(78, 30);
            this.chCostoS.TabIndex = 0;
            this.chCostoS.Text = "Costo S";
            this.chCostoS.UseVisualStyleBackColor = true;
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
            // txtKilosA
            // 
            this.txtKilosA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtKilosA.Depth = 0;
            this.txtKilosA.Enabled = false;
            this.txtKilosA.Hint = "Kilos A";
            this.txtKilosA.Location = new System.Drawing.Point(977, 45);
            this.txtKilosA.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtKilosA.Name = "txtKilosA";
            this.txtKilosA.PasswordChar = '\0';
            this.txtKilosA.SelectedText = "";
            this.txtKilosA.SelectionLength = 0;
            this.txtKilosA.SelectionStart = 0;
            this.txtKilosA.Size = new System.Drawing.Size(110, 23);
            this.txtKilosA.TabIndex = 4;
            this.txtKilosA.UseSystemPasswordChar = false;
            this.txtKilosA.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // txtCostoA
            // 
            this.txtCostoA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCostoA.Depth = 0;
            this.txtCostoA.Enabled = false;
            this.txtCostoA.Hint = " Costo nuevo";
            this.txtCostoA.Location = new System.Drawing.Point(817, 45);
            this.txtCostoA.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCostoA.Name = "txtCostoA";
            this.txtCostoA.PasswordChar = '\0';
            this.txtCostoA.SelectedText = "";
            this.txtCostoA.SelectionLength = 0;
            this.txtCostoA.SelectionStart = 0;
            this.txtCostoA.Size = new System.Drawing.Size(108, 23);
            this.txtCostoA.TabIndex = 4;
            this.txtCostoA.UseSystemPasswordChar = false;
            this.txtCostoA.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            // 
            // rdManualA
            // 
            this.rdManualA.AutoSize = true;
            this.rdManualA.Checked = true;
            this.rdManualA.Depth = 0;
            this.rdManualA.Enabled = false;
            this.rdManualA.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdManualA.Location = new System.Drawing.Point(736, 42);
            this.rdManualA.Margin = new System.Windows.Forms.Padding(0);
            this.rdManualA.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdManualA.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdManualA.Name = "rdManualA";
            this.rdManualA.Ripple = true;
            this.rdManualA.Size = new System.Drawing.Size(78, 30);
            this.rdManualA.TabIndex = 3;
            this.rdManualA.TabStop = true;
            this.rdManualA.Text = "Manual:";
            this.rdManualA.UseVisualStyleBackColor = true;
            // 
            // rdAutoA
            // 
            this.rdAutoA.AutoSize = true;
            this.rdAutoA.Depth = 0;
            this.rdAutoA.Enabled = false;
            this.rdAutoA.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAutoA.Location = new System.Drawing.Point(674, 42);
            this.rdAutoA.Margin = new System.Windows.Forms.Padding(0);
            this.rdAutoA.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAutoA.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAutoA.Name = "rdAutoA";
            this.rdAutoA.Ripple = true;
            this.rdAutoA.Size = new System.Drawing.Size(58, 30);
            this.rdAutoA.TabIndex = 3;
            this.rdAutoA.Text = "Auto";
            this.rdAutoA.UseVisualStyleBackColor = true;
            this.rdAutoA.CheckedChanged += new System.EventHandler(this.RdAuto_CheckedChanged);
            // 
            // cmbProdsA
            // 
            this.cmbProdsA.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbProdsA.Enabled = false;
            this.cmbProdsA.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbProdsA.FormattingEnabled = true;
            this.cmbProdsA.Location = new System.Drawing.Point(331, 42);
            this.cmbProdsA.Name = "cmbProdsA";
            this.cmbProdsA.Size = new System.Drawing.Size(175, 26);
            this.cmbProdsA.TabIndex = 2;
            this.cmbProdsA.Text = "Seleccionar";
            this.cmbProdsA.SelectedIndexChanged += new System.EventHandler(this.CmbProds_SelectedIndexChanged);
            // 
            // cmbSuc
            // 
            this.cmbSuc.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSuc.Enabled = false;
            this.cmbSuc.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.cmbSuc.FormattingEnabled = true;
            this.cmbSuc.Location = new System.Drawing.Point(131, 40);
            this.cmbSuc.Name = "cmbSuc";
            this.cmbSuc.Size = new System.Drawing.Size(175, 26);
            this.cmbSuc.TabIndex = 2;
            this.cmbSuc.Text = "Seleccionar";
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
            // chKilosA
            // 
            this.chKilosA.AutoSize = true;
            this.chKilosA.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chKilosA.Depth = 0;
            this.chKilosA.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chKilosA.Location = new System.Drawing.Point(971, 9);
            this.chKilosA.Margin = new System.Windows.Forms.Padding(0);
            this.chKilosA.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chKilosA.MouseState = MaterialSkin.MouseState.HOVER;
            this.chKilosA.Name = "chKilosA";
            this.chKilosA.Ripple = true;
            this.chKilosA.Size = new System.Drawing.Size(73, 30);
            this.chKilosA.TabIndex = 0;
            this.chKilosA.Text = "Kilos A";
            this.chKilosA.UseVisualStyleBackColor = true;
            this.chKilosA.CheckedChanged += new System.EventHandler(this.ChKilos_CheckedChanged);
            // 
            // chCostoA
            // 
            this.chCostoA.AutoSize = true;
            this.chCostoA.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chCostoA.Depth = 0;
            this.chCostoA.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chCostoA.Location = new System.Drawing.Point(673, 9);
            this.chCostoA.Margin = new System.Windows.Forms.Padding(0);
            this.chCostoA.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCostoA.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCostoA.Name = "chCostoA";
            this.chCostoA.Ripple = true;
            this.chCostoA.Size = new System.Drawing.Size(79, 30);
            this.chCostoA.TabIndex = 0;
            this.chCostoA.Text = "Costo A";
            this.chCostoA.UseVisualStyleBackColor = true;
            this.chCostoA.CheckedChanged += new System.EventHandler(this.ChCosto_CheckedChanged);
            // 
            // chProdA
            // 
            this.chProdA.AutoSize = true;
            this.chProdA.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chProdA.Depth = 0;
            this.chProdA.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chProdA.Location = new System.Drawing.Point(326, 9);
            this.chProdA.Margin = new System.Windows.Forms.Padding(0);
            this.chProdA.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProdA.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProdA.Name = "chProdA";
            this.chProdA.Ripple = true;
            this.chProdA.Size = new System.Drawing.Size(99, 30);
            this.chProdA.TabIndex = 0;
            this.chProdA.Text = "Producto A";
            this.chProdA.UseVisualStyleBackColor = true;
            this.chProdA.CheckedChanged += new System.EventHandler(this.ChProd_CheckedChanged);
            // 
            // chSuc
            // 
            this.chSuc.AutoSize = true;
            this.chSuc.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chSuc.Depth = 0;
            this.chSuc.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.chSuc.Location = new System.Drawing.Point(126, 7);
            this.chSuc.Margin = new System.Windows.Forms.Padding(0);
            this.chSuc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSuc.Name = "chSuc";
            this.chSuc.Ripple = true;
            this.chSuc.Size = new System.Drawing.Size(84, 30);
            this.chSuc.TabIndex = 0;
            this.chSuc.Text = "Sucursal";
            this.chSuc.UseVisualStyleBackColor = true;
            this.chSuc.CheckedChanged += new System.EventHandler(this.ChSucursalEntrada_CheckedChanged);
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
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResultado.PintarFilaSel = true;
            this.grdResultado.Redraw = true;
            this.grdResultado.Row = 0;
            this.grdResultado.Rows = 50;
            this.grdResultado.Size = new System.Drawing.Size(1222, 286);
            this.grdResultado.TabIndex = 1;
            // 
            // frmCMApicada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 639);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCMApicada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio Masivo Traslados";
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
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoA;
        private MaterialSkin.Controls.MaterialRadioButton rdManualA;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoA;
        private System.Windows.Forms.ComboBox cmbProdsA;
        private MaterialSkin.Controls.MaterialCheckBox chCostoA;
        private MaterialSkin.Controls.MaterialCheckBox chProdA;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtKilosA;
        private MaterialSkin.Controls.MaterialCheckBox chKilosA;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCostoS;
        private MaterialSkin.Controls.MaterialRadioButton rdManualS;
        private MaterialSkin.Controls.MaterialRadioButton rdAutoS;
        private MaterialSkin.Controls.MaterialCheckBox chCostoS;
        private System.Windows.Forms.ComboBox cmbSuc;
        private MaterialSkin.Controls.MaterialCheckBox chSuc;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtKilosS;
        private MaterialSkin.Controls.MaterialCheckBox chKilosS;
        private System.Windows.Forms.ComboBox cmbProdsS;
        private MaterialSkin.Controls.MaterialCheckBox chProdS;
    }
}