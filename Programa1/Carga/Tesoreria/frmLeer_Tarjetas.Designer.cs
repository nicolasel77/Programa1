namespace Programa1.Carga.Tesoreria
{

    partial class frmLeer_Tarjetas
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
            this.components = new System.ComponentModel.Container();
            this.cmdRuta = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmdCarpeta = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblCuentas = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtMaxima = new System.Windows.Forms.DateTimePicker();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tiAuto = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.grdCuentas = new Grilla2.SpeedGrilla();
            this.grdDatos = new Grilla2.SpeedGrilla();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdRecargar = new MaterialSkin.Controls.MaterialFlatButton();
            this.pbLeer = new System.Windows.Forms.ProgressBar();
            this.lblpb = new System.Windows.Forms.Label();
            this.cmdMP = new MaterialSkin.Controls.MaterialFlatButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chAuto = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lstTitulares = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSuc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rdTerminalesMP = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdCuentas = new MaterialSkin.Controls.MaterialRadioButton();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRuta
            // 
            this.cmdRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRuta.AutoSize = true;
            this.cmdRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRuta.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRuta.Depth = 0;
            this.cmdRuta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRuta.Location = new System.Drawing.Point(4, -8);
            this.cmdRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRuta.Name = "cmdRuta";
            this.cmdRuta.Primary = false;
            this.cmdRuta.Size = new System.Drawing.Size(8, 36);
            this.cmdRuta.TabIndex = 2;
            this.cmdRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRuta.UseVisualStyleBackColor = false;
            // 
            // cmdCarpeta
            // 
            this.cmdCarpeta.AutoSize = true;
            this.cmdCarpeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCarpeta.Depth = 0;
            this.cmdCarpeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarpeta.Location = new System.Drawing.Point(0, 0);
            this.cmdCarpeta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCarpeta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCarpeta.Name = "cmdCarpeta";
            this.cmdCarpeta.Primary = false;
            this.cmdCarpeta.Size = new System.Drawing.Size(215, 25);
            this.cmdCarpeta.TabIndex = 3;
            this.cmdCarpeta.Text = "Carpeta";
            this.cmdCarpeta.UseVisualStyleBackColor = true;
            this.cmdCarpeta.Click += new System.EventHandler(this.cmdCarpeta_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(688, 53);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(0, 16);
            this.lblSucursal.TabIndex = 8;
            // 
            // lblCuentas
            // 
            this.lblCuentas.AutoSize = true;
            this.lblCuentas.Location = new System.Drawing.Point(2, 2);
            this.lblCuentas.Name = "lblCuentas";
            this.lblCuentas.Size = new System.Drawing.Size(46, 13);
            this.lblCuentas.TabIndex = 9;
            this.lblCuentas.Text = "Cuentas";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(-3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Tipo";
            // 
            // lstTipo
            // 
            this.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.ItemHeight = 20;
            this.lstTipo.Location = new System.Drawing.Point(0, 0);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.Size = new System.Drawing.Size(157, 154);
            this.lstTipo.TabIndex = 7;
            this.lstTipo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstTipo_MouseUp);
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(-2, 219);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(99, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Cargar desde-hasta";
            // 
            // dtMaxima
            // 
            this.dtMaxima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtMaxima.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMaxima.Location = new System.Drawing.Point(112, 235);
            this.dtMaxima.Name = "dtMaxima";
            this.dtMaxima.Size = new System.Drawing.Size(105, 20);
            this.dtMaxima.TabIndex = 12;
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(0, 235);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(106, 20);
            this.dtFecha.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdCarpeta);
            this.panel2.Location = new System.Drawing.Point(0, 261);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 27);
            this.panel2.TabIndex = 19;
            // 
            // tiAuto
            // 
            this.tiAuto.Interval = 5000;
            this.tiAuto.Tick += new System.EventHandler(this.tiAuto_Tick);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmdRuta);
            this.panel5.Location = new System.Drawing.Point(223, 261);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 27);
            this.panel5.TabIndex = 22;
            // 
            // lblArchivo
            // 
            this.lblArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(2, 199);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 13);
            this.lblArchivo.TabIndex = 23;
            // 
            // grdCuentas
            // 
            this.grdCuentas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCuentas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCuentas.AutoResize = false;
            this.grdCuentas.bColor = System.Drawing.SystemColors.Window;
            this.grdCuentas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCuentas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCuentas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCuentas.Col = 0;
            this.grdCuentas.Cols = 10;
            this.grdCuentas.DataMember = "";
            this.grdCuentas.DataSource = null;
            this.grdCuentas.EnableEdicion = true;
            this.grdCuentas.Encabezado = "";
            this.grdCuentas.fColor = System.Drawing.Color.Silver;
            this.grdCuentas.FixCols = 0;
            this.grdCuentas.FixRows = 0;
            this.grdCuentas.Frozen = 0;
            this.grdCuentas.FuenteEncabezado = null;
            this.grdCuentas.FuentePieDePagina = null;
            this.grdCuentas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCuentas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCuentas.Location = new System.Drawing.Point(0, 18);
            this.grdCuentas.Name = "grdCuentas";
            this.grdCuentas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCuentas.PintarFilaSel = true;
            this.grdCuentas.Redraw = true;
            this.grdCuentas.Row = 0;
            this.grdCuentas.Rows = 50;
            this.grdCuentas.Size = new System.Drawing.Size(666, 325);
            this.grdCuentas.TabIndex = 1;
            this.grdCuentas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdCuentas_Editado);
            this.grdCuentas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdCuentas_CambioFila);
            this.grdCuentas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdCuentas_KeyUp);
            this.grdCuentas.CambioColumna += new Grilla2.SpeedGrilla.CambioColumnaEventHandler(this.grdCuentas_CambioColumna);
            // 
            // grdDatos
            // 
            this.grdDatos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDatos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDatos.AutoResize = false;
            this.grdDatos.bColor = System.Drawing.SystemColors.Window;
            this.grdDatos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDatos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDatos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDatos.Col = 0;
            this.grdDatos.Cols = 1;
            this.grdDatos.DataMember = "";
            this.grdDatos.DataSource = null;
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDatos.EnableEdicion = true;
            this.grdDatos.Encabezado = "";
            this.grdDatos.fColor = System.Drawing.Color.Silver;
            this.grdDatos.FixCols = 0;
            this.grdDatos.FixRows = 0;
            this.grdDatos.Frozen = 0;
            this.grdDatos.FuenteEncabezado = null;
            this.grdDatos.FuentePieDePagina = null;
            this.grdDatos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDatos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDatos.PintarFilaSel = true;
            this.grdDatos.Redraw = true;
            this.grdDatos.Row = 0;
            this.grdDatos.Rows = 1;
            this.grdDatos.Size = new System.Drawing.Size(754, 643);
            this.grdDatos.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(2, 173);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 16);
            this.lblTotal.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cmdRecargar);
            this.panel6.Location = new System.Drawing.Point(550, 261);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(116, 27);
            this.panel6.TabIndex = 19;
            // 
            // cmdRecargar
            // 
            this.cmdRecargar.AutoSize = true;
            this.cmdRecargar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRecargar.Depth = 0;
            this.cmdRecargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdRecargar.Location = new System.Drawing.Point(0, 0);
            this.cmdRecargar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdRecargar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRecargar.Name = "cmdRecargar";
            this.cmdRecargar.Primary = false;
            this.cmdRecargar.Size = new System.Drawing.Size(114, 25);
            this.cmdRecargar.TabIndex = 4;
            this.cmdRecargar.Text = "Recargar";
            this.cmdRecargar.UseVisualStyleBackColor = true;
            this.cmdRecargar.Click += new System.EventHandler(this.cmdRecargar_Click);
            // 
            // pbLeer
            // 
            this.pbLeer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLeer.Location = new System.Drawing.Point(223, 228);
            this.pbLeer.Name = "pbLeer";
            this.pbLeer.Size = new System.Drawing.Size(321, 27);
            this.pbLeer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLeer.TabIndex = 25;
            // 
            // lblpb
            // 
            this.lblpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblpb.AutoSize = true;
            this.lblpb.Location = new System.Drawing.Point(220, 211);
            this.lblpb.Name = "lblpb";
            this.lblpb.Size = new System.Drawing.Size(52, 13);
            this.lblpb.TabIndex = 26;
            this.lblpb.Text = "Progreso:";
            // 
            // cmdMP
            // 
            this.cmdMP.AutoSize = true;
            this.cmdMP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMP.Depth = 0;
            this.cmdMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMP.Location = new System.Drawing.Point(0, 0);
            this.cmdMP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdMP.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMP.Name = "cmdMP";
            this.cmdMP.Primary = false;
            this.cmdMP.Size = new System.Drawing.Size(114, 25);
            this.cmdMP.TabIndex = 32;
            this.cmdMP.Text = "Actualizar MP";
            this.cmdMP.UseVisualStyleBackColor = true;
            this.cmdMP.Click += new System.EventHandler(this.cmdMP_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1428, 643);
            this.splitContainer1.SplitterDistance = 754;
            this.splitContainer1.TabIndex = 33;
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
            this.splitContainer2.Panel1.Controls.Add(this.rdCuentas);
            this.splitContainer2.Panel1.Controls.Add(this.rdTerminalesMP);
            this.splitContainer2.Panel1.Controls.Add(this.chAuto);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.panel8);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.cmbSuc);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.panel7);
            this.splitContainer2.Panel1.Controls.Add(this.Label1);
            this.splitContainer2.Panel1.Controls.Add(this.lblArchivo);
            this.splitContainer2.Panel1.Controls.Add(this.lblpb);
            this.splitContainer2.Panel1.Controls.Add(this.pbLeer);
            this.splitContainer2.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer2.Panel1.Controls.Add(this.panel6);
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.dtMaxima);
            this.splitContainer2.Panel1.Controls.Add(this.Label3);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.dtFecha);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdCuentas);
            this.splitContainer2.Panel2.Controls.Add(this.lblCuentas);
            this.splitContainer2.Size = new System.Drawing.Size(670, 643);
            this.splitContainer2.SplitterDistance = 293;
            this.splitContainer2.TabIndex = 0;
            // 
            // chAuto
            // 
            this.chAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAuto.AutoSize = true;
            this.chAuto.Depth = 0;
            this.chAuto.Font = new System.Drawing.Font("Roboto", 10F);
            this.chAuto.Location = new System.Drawing.Point(606, 0);
            this.chAuto.Margin = new System.Windows.Forms.Padding(0);
            this.chAuto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chAuto.MouseState = MaterialSkin.MouseState.HOVER;
            this.chAuto.Name = "chAuto";
            this.chAuto.Ripple = true;
            this.chAuto.Size = new System.Drawing.Size(59, 30);
            this.chAuto.TabIndex = 39;
            this.chAuto.Text = "Auto";
            this.chAuto.UseVisualStyleBackColor = true;
            this.chAuto.CheckedChanged += new System.EventHandler(this.chAuto_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdMP);
            this.panel1.Location = new System.Drawing.Point(550, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 27);
            this.panel1.TabIndex = 20;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lstTitulares);
            this.panel8.Location = new System.Drawing.Point(163, 16);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(184, 83);
            this.panel8.TabIndex = 34;
            // 
            // lstTitulares
            // 
            this.lstTitulares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTitulares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTitulares.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTitulares.FormattingEnabled = true;
            this.lstTitulares.ItemHeight = 20;
            this.lstTitulares.Location = new System.Drawing.Point(0, 0);
            this.lstTitulares.Name = "lstTitulares";
            this.lstTitulares.Size = new System.Drawing.Size(184, 83);
            this.lstTitulares.TabIndex = 7;
            this.lstTitulares.SelectedIndexChanged += new System.EventHandler(this.lstTitulares_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Filtrar suc";
            // 
            // cmbSuc
            // 
            this.cmbSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSuc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSuc.FormattingEnabled = true;
            this.cmbSuc.Location = new System.Drawing.Point(163, 146);
            this.cmbSuc.Name = "cmbSuc";
            this.cmbSuc.Size = new System.Drawing.Size(184, 24);
            this.cmbSuc.TabIndex = 37;
            this.cmbSuc.SelectedIndexChanged += new System.EventHandler(this.cmbSuc_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Titular";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.Controls.Add(this.lstTipo);
            this.panel7.Location = new System.Drawing.Point(0, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(157, 154);
            this.panel7.TabIndex = 33;
            // 
            // rdTerminalesMP
            // 
            this.rdTerminalesMP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdTerminalesMP.AutoSize = true;
            this.rdTerminalesMP.Depth = 0;
            this.rdTerminalesMP.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdTerminalesMP.Location = new System.Drawing.Point(544, 190);
            this.rdTerminalesMP.Margin = new System.Windows.Forms.Padding(0);
            this.rdTerminalesMP.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdTerminalesMP.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdTerminalesMP.Name = "rdTerminalesMP";
            this.rdTerminalesMP.Ripple = true;
            this.rdTerminalesMP.Size = new System.Drawing.Size(122, 30);
            this.rdTerminalesMP.TabIndex = 41;
            this.rdTerminalesMP.Text = "Terminales MP";
            this.rdTerminalesMP.UseVisualStyleBackColor = true;
            this.rdTerminalesMP.CheckedChanged += new System.EventHandler(this.rdTerminalesMP_CheckedChanged);
            // 
            // rdCuentas
            // 
            this.rdCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdCuentas.AutoSize = true;
            this.rdCuentas.Checked = true;
            this.rdCuentas.Depth = 0;
            this.rdCuentas.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdCuentas.Location = new System.Drawing.Point(464, 190);
            this.rdCuentas.Margin = new System.Windows.Forms.Padding(0);
            this.rdCuentas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdCuentas.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdCuentas.Name = "rdCuentas";
            this.rdCuentas.Ripple = true;
            this.rdCuentas.Size = new System.Drawing.Size(80, 30);
            this.rdCuentas.TabIndex = 42;
            this.rdCuentas.TabStop = true;
            this.rdCuentas.Text = "Cuentas";
            this.rdCuentas.UseVisualStyleBackColor = true;
            // 
            // frmLeer_Tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 643);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblSucursal);
            this.Name = "frmLeer_Tarjetas";
            this.Text = "Leer_Tarjetas";
            this.Load += new System.EventHandler(this.frmLeer_Tarjetas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdDatos;
        private Grilla2.SpeedGrilla grdCuentas;
        private MaterialSkin.Controls.MaterialFlatButton cmdRuta;
        private MaterialSkin.Controls.MaterialFlatButton cmdCarpeta;
        internal System.Windows.Forms.Label lblSucursal;
        internal System.Windows.Forms.Label lblCuentas;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstTipo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtMaxima;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Timer tiAuto;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label lblArchivo;
        internal System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialFlatButton cmdRecargar;
        private System.Windows.Forms.ProgressBar pbLeer;
        internal System.Windows.Forms.Label lblpb;
        private MaterialSkin.Controls.MaterialFlatButton cmdMP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        internal System.Windows.Forms.ListBox lstTitulares;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialCheckBox chAuto;
        private MaterialSkin.Controls.MaterialRadioButton rdTerminalesMP;
        private MaterialSkin.Controls.MaterialRadioButton rdCuentas;
    }
}