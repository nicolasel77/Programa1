namespace Programa1.Carga
{
    partial class frmResumen_Suc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumen_Suc));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.rdAgrupado = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdDetalle = new MaterialSkin.Controls.MaterialRadioButton();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalSalidas = new System.Windows.Forms.Label();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.speedGrilla3 = new Grilla2.SpeedGrilla();
            this.lblCarneK = new System.Windows.Forms.Label();
            this.lblSuc = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdSucursales = new Grilla2.SpeedGrilla();
            this.paEstadistica = new System.Windows.Forms.Panel();
            this.paEst = new System.Windows.Forms.Panel();
            this.grdEstadistica = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdStock_Carne = new MaterialSkin.Controls.MaterialFlatButton();
            this.cFechas1 = new Programa1.Controles.cFechas();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.paEst.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1123, 678);
            this.splitContainer1.SplitterDistance = 790;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panel3);
            this.splitContainer3.Panel2.Controls.Add(this.speedGrilla3);
            this.splitContainer3.Panel2.Controls.Add(this.lblCarneK);
            this.splitContainer3.Panel2.Controls.Add(this.lblSuc);
            this.splitContainer3.Size = new System.Drawing.Size(790, 678);
            this.splitContainer3.SplitterDistance = 578;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            this.splitContainer4.Panel1.Controls.Add(this.grdEntradas);
            this.splitContainer4.Panel1.Controls.Add(this.lblEntradas);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.panel2);
            this.splitContainer4.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Size = new System.Drawing.Size(790, 578);
            this.splitContainer4.SplitterDistance = 347;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalEntradas);
            this.panel1.Controls.Add(this.rdAgrupado);
            this.panel1.Controls.Add(this.rdDetalle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 552);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 26);
            this.panel1.TabIndex = 4;
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.AutoSize = true;
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalEntradas.Location = new System.Drawing.Point(3, 3);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(42, 21);
            this.lblTotalEntradas.TabIndex = 3;
            this.lblTotalEntradas.Text = "Total";
            // 
            // rdAgrupado
            // 
            this.rdAgrupado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdAgrupado.AutoSize = true;
            this.rdAgrupado.Checked = true;
            this.rdAgrupado.Depth = 0;
            this.rdAgrupado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdAgrupado.Location = new System.Drawing.Point(177, 0);
            this.rdAgrupado.Margin = new System.Windows.Forms.Padding(0);
            this.rdAgrupado.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAgrupado.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAgrupado.Name = "rdAgrupado";
            this.rdAgrupado.Ripple = true;
            this.rdAgrupado.Size = new System.Drawing.Size(89, 30);
            this.rdAgrupado.TabIndex = 2;
            this.rdAgrupado.TabStop = true;
            this.rdAgrupado.Text = "Agrupado";
            this.rdAgrupado.UseVisualStyleBackColor = true;
            this.rdAgrupado.Visible = false;
            // 
            // rdDetalle
            // 
            this.rdDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdDetalle.AutoSize = true;
            this.rdDetalle.Depth = 0;
            this.rdDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdDetalle.Location = new System.Drawing.Point(266, 0);
            this.rdDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.rdDetalle.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdDetalle.Name = "rdDetalle";
            this.rdDetalle.Ripple = true;
            this.rdDetalle.Size = new System.Drawing.Size(72, 30);
            this.rdDetalle.TabIndex = 2;
            this.rdDetalle.Text = "Detalle";
            this.rdDetalle.UseVisualStyleBackColor = true;
            this.rdDetalle.Visible = false;
            // 
            // grdEntradas
            // 
            this.grdEntradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEntradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntradas.AutoResize = false;
            this.grdEntradas.bColor = System.Drawing.SystemColors.Window;
            this.grdEntradas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEntradas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEntradas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEntradas.Col = 0;
            this.grdEntradas.Cols = 1;
            this.grdEntradas.DataMember = "";
            this.grdEntradas.DataSource = null;
            this.grdEntradas.EnableEdicion = false;
            this.grdEntradas.Encabezado = "";
            this.grdEntradas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntradas.FixCols = 0;
            this.grdEntradas.FixRows = 0;
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.Location = new System.Drawing.Point(3, 24);
            this.grdEntradas.MenuActivado = false;
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 1;
            this.grdEntradas.Size = new System.Drawing.Size(341, 525);
            this.grdEntradas.TabIndex = 1;
            this.grdEntradas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdEntradas_KeyUp);
            this.grdEntradas.DobleClick += new Grilla2.SpeedGrilla.DobleClickEventHandler(this.grdEntradas_DobleClick);
            // 
            // lblEntradas
            // 
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblEntradas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblEntradas.Location = new System.Drawing.Point(3, 3);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(67, 18);
            this.lblEntradas.TabIndex = 0;
            this.lblEntradas.Text = "Entradas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotalSalidas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 26);
            this.panel2.TabIndex = 5;
            // 
            // lblTotalSalidas
            // 
            this.lblTotalSalidas.AutoSize = true;
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalSalidas.Location = new System.Drawing.Point(3, 3);
            this.lblTotalSalidas.Name = "lblTotalSalidas";
            this.lblTotalSalidas.Size = new System.Drawing.Size(42, 21);
            this.lblTotalSalidas.TabIndex = 3;
            this.lblTotalSalidas.Text = "Total";
            // 
            // grdSalidas
            // 
            this.grdSalidas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSalidas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSalidas.AutoResize = false;
            this.grdSalidas.bColor = System.Drawing.SystemColors.Window;
            this.grdSalidas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSalidas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSalidas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSalidas.Col = 0;
            this.grdSalidas.Cols = 1;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = false;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.Location = new System.Drawing.Point(3, 24);
            this.grdSalidas.MenuActivado = false;
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 1;
            this.grdSalidas.Size = new System.Drawing.Size(433, 525);
            this.grdSalidas.TabIndex = 1;
            this.grdSalidas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdSalidas_KeyUp);
            this.grdSalidas.DobleClick += new Grilla2.SpeedGrilla.DobleClickEventHandler(this.grdSalidas_DobleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salidas";
            // 
            // speedGrilla3
            // 
            this.speedGrilla3.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.speedGrilla3.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.speedGrilla3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedGrilla3.AutoResize = false;
            this.speedGrilla3.bColor = System.Drawing.SystemColors.Window;
            this.speedGrilla3.bColorSel = System.Drawing.SystemColors.Highlight;
            this.speedGrilla3.bFColor = System.Drawing.SystemColors.WindowText;
            this.speedGrilla3.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.speedGrilla3.Col = 0;
            this.speedGrilla3.Cols = 1;
            this.speedGrilla3.DataMember = "";
            this.speedGrilla3.DataSource = null;
            this.speedGrilla3.EnableEdicion = true;
            this.speedGrilla3.Encabezado = "";
            this.speedGrilla3.fColor = System.Drawing.SystemColors.Control;
            this.speedGrilla3.FixCols = 0;
            this.speedGrilla3.FixRows = 0;
            this.speedGrilla3.FuenteEncabezado = null;
            this.speedGrilla3.FuentePieDePagina = null;
            this.speedGrilla3.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.speedGrilla3.Location = new System.Drawing.Point(267, 3);
            this.speedGrilla3.MenuActivado = false;
            this.speedGrilla3.Name = "speedGrilla3";
            this.speedGrilla3.PieDePagina = "\t\tPage {0} of {1}";
            this.speedGrilla3.PintarFilaSel = true;
            this.speedGrilla3.Redraw = true;
            this.speedGrilla3.Row = 0;
            this.speedGrilla3.Rows = 1;
            this.speedGrilla3.Size = new System.Drawing.Size(520, 81);
            this.speedGrilla3.TabIndex = 1;
            // 
            // lblCarneK
            // 
            this.lblCarneK.AutoSize = true;
            this.lblCarneK.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblCarneK.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblCarneK.Location = new System.Drawing.Point(12, 3);
            this.lblCarneK.Name = "lblCarneK";
            this.lblCarneK.Size = new System.Drawing.Size(85, 18);
            this.lblCarneK.TabIndex = 0;
            this.lblCarneK.Text = "Kilos Carne";
            // 
            // lblSuc
            // 
            this.lblSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSuc.AutoSize = true;
            this.lblSuc.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblSuc.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblSuc.Location = new System.Drawing.Point(12, 69);
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(66, 18);
            this.lblSuc.TabIndex = 0;
            this.lblSuc.Text = "Sucursal";
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
            this.splitContainer2.Panel1.Controls.Add(this.grdSucursales);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer2.Size = new System.Drawing.Size(329, 678);
            this.splitContainer2.SplitterDistance = 468;
            this.splitContainer2.TabIndex = 0;
            // 
            // grdSucursales
            // 
            this.grdSucursales.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSucursales.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSucursales.AutoResize = false;
            this.grdSucursales.bColor = System.Drawing.SystemColors.Window;
            this.grdSucursales.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSucursales.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSucursales.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSucursales.Col = 0;
            this.grdSucursales.Cols = 1;
            this.grdSucursales.DataMember = "";
            this.grdSucursales.DataSource = null;
            this.grdSucursales.EnableEdicion = true;
            this.grdSucursales.Encabezado = "";
            this.grdSucursales.fColor = System.Drawing.SystemColors.Control;
            this.grdSucursales.FixCols = 0;
            this.grdSucursales.FixRows = 0;
            this.grdSucursales.FuenteEncabezado = null;
            this.grdSucursales.FuentePieDePagina = null;
            this.grdSucursales.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSucursales.Location = new System.Drawing.Point(2, 3);
            this.grdSucursales.MenuActivado = false;
            this.grdSucursales.Name = "grdSucursales";
            this.grdSucursales.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSucursales.PintarFilaSel = true;
            this.grdSucursales.Redraw = true;
            this.grdSucursales.Row = 0;
            this.grdSucursales.Rows = 1;
            this.grdSucursales.Size = new System.Drawing.Size(324, 462);
            this.grdSucursales.TabIndex = 1;
            this.grdSucursales.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdSucursales_CambioFila);
            // 
            // paEstadistica
            // 
            this.paEstadistica.BackColor = System.Drawing.Color.DarkGray;
            this.paEstadistica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paEstadistica.Dock = System.Windows.Forms.DockStyle.Right;
            this.paEstadistica.Location = new System.Drawing.Point(1116, 0);
            this.paEstadistica.Name = "paEstadistica";
            this.paEstadistica.Size = new System.Drawing.Size(35, 678);
            this.paEstadistica.TabIndex = 1;
            this.paEstadistica.Click += new System.EventHandler(this.paEstadistica_Click);
            // 
            // paEst
            // 
            this.paEst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paEst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paEst.Controls.Add(this.grdEstadistica);
            this.paEst.Controls.Add(this.label2);
            this.paEst.Location = new System.Drawing.Point(486, 0);
            this.paEst.Name = "paEst";
            this.paEst.Size = new System.Drawing.Size(637, 678);
            this.paEst.TabIndex = 2;
            this.paEst.Visible = false;
            // 
            // grdEstadistica
            // 
            this.grdEstadistica.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEstadistica.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEstadistica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEstadistica.AutoResize = false;
            this.grdEstadistica.bColor = System.Drawing.SystemColors.Window;
            this.grdEstadistica.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEstadistica.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEstadistica.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEstadistica.Col = 0;
            this.grdEstadistica.Cols = 10;
            this.grdEstadistica.DataMember = "";
            this.grdEstadistica.DataSource = null;
            this.grdEstadistica.EnableEdicion = true;
            this.grdEstadistica.Encabezado = "";
            this.grdEstadistica.fColor = System.Drawing.SystemColors.Control;
            this.grdEstadistica.FixCols = 0;
            this.grdEstadistica.FixRows = 0;
            this.grdEstadistica.FuenteEncabezado = null;
            this.grdEstadistica.FuentePieDePagina = null;
            this.grdEstadistica.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEstadistica.Location = new System.Drawing.Point(6, 22);
            this.grdEstadistica.MenuActivado = false;
            this.grdEstadistica.Name = "grdEstadistica";
            this.grdEstadistica.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEstadistica.PintarFilaSel = true;
            this.grdEstadistica.Redraw = true;
            this.grdEstadistica.Row = 0;
            this.grdEstadistica.Rows = 50;
            this.grdEstadistica.Size = new System.Drawing.Size(624, 640);
            this.grdEstadistica.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estadísticas";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.cmdStock_Carne);
            this.panel3.Location = new System.Drawing.Point(15, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 42);
            this.panel3.TabIndex = 2;
            // 
            // cmdStock_Carne
            // 
            this.cmdStock_Carne.AutoSize = true;
            this.cmdStock_Carne.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdStock_Carne.Depth = 0;
            this.cmdStock_Carne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdStock_Carne.Location = new System.Drawing.Point(0, 0);
            this.cmdStock_Carne.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdStock_Carne.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdStock_Carne.Name = "cmdStock_Carne";
            this.cmdStock_Carne.Primary = false;
            this.cmdStock_Carne.Size = new System.Drawing.Size(246, 42);
            this.cmdStock_Carne.TabIndex = 0;
            this.cmdStock_Carne.Text = "Stock Carne";
            this.cmdStock_Carne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdStock_Carne.UseVisualStyleBackColor = true;
            this.cmdStock_Carne.Click += new System.EventHandler(this.cmdStock_Carne_Click);
            // 
            // cFechas1
            // 
            this.cFechas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(0, 0);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(329, 206);
            this.cFechas1.TabIndex = 0;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // frmResumen_Suc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 678);
            this.Controls.Add(this.paEst);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.paEstadistica);
            this.Name = "frmResumen_Suc";
            this.Text = "Resumen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmResumen_Suc_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.paEst.ResumeLayout(false);
            this.paEst.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Grilla2.SpeedGrilla grdEntradas;
        private System.Windows.Forms.Label lblEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla speedGrilla3;
        private System.Windows.Forms.Label lblSuc;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdSucursales;
        private Controles.cFechas cFechas1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalEntradas;
        private MaterialSkin.Controls.MaterialRadioButton rdAgrupado;
        private MaterialSkin.Controls.MaterialRadioButton rdDetalle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalSalidas;
        private System.Windows.Forms.Panel paEstadistica;
        private System.Windows.Forms.Panel paEst;
        private Grilla2.SpeedGrilla grdEstadistica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCarneK;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialFlatButton cmdStock_Carne;
    }
}