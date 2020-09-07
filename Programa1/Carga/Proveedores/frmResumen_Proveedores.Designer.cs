namespace Programa1.Carga
{
    partial class frmResumen_Proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumen_Proveedores));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.rdAgrupado = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdDetalle = new MaterialSkin.Controls.MaterialRadioButton();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalSalidas = new System.Windows.Forms.Label();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSaldoProveedores = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAjustes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDevoluciones = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCompras = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSaldoAnt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chSoloSaldos = new MaterialSkin.Controls.MaterialCheckBox();
            this.grdProv = new Grilla2.SpeedGrilla();
            this.cFechas1 = new Programa1.Controles.cFechas();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 607);
            this.splitContainer1.SplitterDistance = 825;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.lblGanancia);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.lblSaldoProveedores);
            this.splitContainer2.Panel2.Controls.Add(this.lblSaldo);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.lblAjustes);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.lblDevoluciones);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.lblPagos);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.lblCompras);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.lblSaldoAnt);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(825, 607);
            this.splitContainer2.SplitterDistance = 470;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.lblEntradas);
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            this.splitContainer4.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.label9);
            this.splitContainer4.Panel2.Controls.Add(this.panel2);
            this.splitContainer4.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer4.Size = new System.Drawing.Size(825, 470);
            this.splitContainer4.SplitterDistance = 443;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalEntradas);
            this.panel1.Controls.Add(this.rdAgrupado);
            this.panel1.Controls.Add(this.rdDetalle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 444);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 26);
            this.panel1.TabIndex = 3;
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
            this.rdAgrupado.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAgrupado.Location = new System.Drawing.Point(273, 0);
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
            this.rdAgrupado.CheckedChanged += new System.EventHandler(this.rdAgrupado_CheckedChanged);
            // 
            // rdDetalle
            // 
            this.rdDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdDetalle.AutoSize = true;
            this.rdDetalle.Depth = 0;
            this.rdDetalle.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdDetalle.Location = new System.Drawing.Point(362, 0);
            this.rdDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.rdDetalle.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdDetalle.Name = "rdDetalle";
            this.rdDetalle.Ripple = true;
            this.rdDetalle.Size = new System.Drawing.Size(72, 30);
            this.rdDetalle.TabIndex = 2;
            this.rdDetalle.Text = "Detalle";
            this.rdDetalle.UseVisualStyleBackColor = true;
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
            this.grdEntradas.Cols = 10;
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
            this.grdEntradas.Location = new System.Drawing.Point(0, 24);
            this.grdEntradas.MenuActivado = false;
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 50;
            this.grdEntradas.Size = new System.Drawing.Size(443, 420);
            this.grdEntradas.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotalSalidas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 444);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 26);
            this.panel2.TabIndex = 4;
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
            this.grdSalidas.Cols = 10;
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
            this.grdSalidas.Location = new System.Drawing.Point(0, 24);
            this.grdSalidas.MenuActivado = false;
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 50;
            this.grdSalidas.Size = new System.Drawing.Size(378, 420);
            this.grdSalidas.TabIndex = 0;
            // 
            // lblGanancia
            // 
            this.lblGanancia.Location = new System.Drawing.Point(303, 9);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(94, 13);
            this.lblGanancia.TabIndex = 1;
            this.lblGanancia.Text = "0";
            this.lblGanancia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ganancia:";
            // 
            // lblSaldoProveedores
            // 
            this.lblSaldoProveedores.Location = new System.Drawing.Point(526, 9);
            this.lblSaldoProveedores.Name = "lblSaldoProveedores";
            this.lblSaldoProveedores.Size = new System.Drawing.Size(106, 13);
            this.lblSaldoProveedores.TabIndex = 0;
            this.lblSaldoProveedores.Text = "0";
            this.lblSaldoProveedores.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Location = new System.Drawing.Point(112, 114);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(106, 13);
            this.lblSaldo.TabIndex = 0;
            this.lblSaldo.Text = "0";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Saldo Proveedores:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Saldo:";
            // 
            // lblAjustes
            // 
            this.lblAjustes.Location = new System.Drawing.Point(112, 93);
            this.lblAjustes.Name = "lblAjustes";
            this.lblAjustes.Size = new System.Drawing.Size(106, 13);
            this.lblAjustes.TabIndex = 0;
            this.lblAjustes.Text = "0";
            this.lblAjustes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Ajustes:";
            // 
            // lblDevoluciones
            // 
            this.lblDevoluciones.Location = new System.Drawing.Point(112, 72);
            this.lblDevoluciones.Name = "lblDevoluciones";
            this.lblDevoluciones.Size = new System.Drawing.Size(106, 13);
            this.lblDevoluciones.TabIndex = 0;
            this.lblDevoluciones.Text = "0";
            this.lblDevoluciones.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Devoluciones:";
            // 
            // lblPagos
            // 
            this.lblPagos.Location = new System.Drawing.Point(112, 51);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(106, 13);
            this.lblPagos.TabIndex = 0;
            this.lblPagos.Text = "0";
            this.lblPagos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Pagos:";
            // 
            // lblCompras
            // 
            this.lblCompras.Location = new System.Drawing.Point(112, 30);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(106, 13);
            this.lblCompras.TabIndex = 0;
            this.lblCompras.Text = "0";
            this.lblCompras.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Compras:";
            // 
            // lblSaldoAnt
            // 
            this.lblSaldoAnt.Location = new System.Drawing.Point(112, 9);
            this.lblSaldoAnt.Name = "lblSaldoAnt";
            this.lblSaldoAnt.Size = new System.Drawing.Size(106, 13);
            this.lblSaldoAnt.TabIndex = 0;
            this.lblSaldoAnt.Text = "0";
            this.lblSaldoAnt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Anterior:";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.chSoloSaldos);
            this.splitContainer3.Panel1.Controls.Add(this.grdProv);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer3.Size = new System.Drawing.Size(259, 607);
            this.splitContainer3.SplitterDistance = 413;
            this.splitContainer3.TabIndex = 0;
            // 
            // chSoloSaldos
            // 
            this.chSoloSaldos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chSoloSaldos.AutoSize = true;
            this.chSoloSaldos.Checked = true;
            this.chSoloSaldos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSoloSaldos.Depth = 0;
            this.chSoloSaldos.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSoloSaldos.Location = new System.Drawing.Point(0, 378);
            this.chSoloSaldos.Margin = new System.Windows.Forms.Padding(0);
            this.chSoloSaldos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSoloSaldos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSoloSaldos.Name = "chSoloSaldos";
            this.chSoloSaldos.Ripple = true;
            this.chSoloSaldos.Size = new System.Drawing.Size(151, 30);
            this.chSoloSaldos.TabIndex = 1;
            this.chSoloSaldos.Text = "Ver solo con saldos";
            this.chSoloSaldos.UseVisualStyleBackColor = true;
            this.chSoloSaldos.CheckedChanged += new System.EventHandler(this.chSoloSaldos_CheckedChanged);
            // 
            // grdProv
            // 
            this.grdProv.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProv.AutoResize = false;
            this.grdProv.bColor = System.Drawing.SystemColors.Window;
            this.grdProv.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProv.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProv.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProv.Col = 0;
            this.grdProv.Cols = 10;
            this.grdProv.DataMember = "";
            this.grdProv.DataSource = null;
            this.grdProv.EnableEdicion = false;
            this.grdProv.Encabezado = "";
            this.grdProv.fColor = System.Drawing.SystemColors.Control;
            this.grdProv.FixCols = 0;
            this.grdProv.FixRows = 0;
            this.grdProv.FuenteEncabezado = null;
            this.grdProv.FuentePieDePagina = null;
            this.grdProv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProv.Location = new System.Drawing.Point(0, 0);
            this.grdProv.MenuActivado = false;
            this.grdProv.Name = "grdProv";
            this.grdProv.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProv.PintarFilaSel = true;
            this.grdProv.Redraw = true;
            this.grdProv.Row = 0;
            this.grdProv.Rows = 50;
            this.grdProv.Size = new System.Drawing.Size(259, 375);
            this.grdProv.TabIndex = 0;
            this.grdProv.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdProv_CambioFila);
            // 
            // cFechas1
            // 
            this.cFechas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(0, 0);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(259, 190);
            this.cFechas1.TabIndex = 0;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // lblEntradas
            // 
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblEntradas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblEntradas.Location = new System.Drawing.Point(3, 3);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(67, 18);
            this.lblEntradas.TabIndex = 4;
            this.lblEntradas.Text = "Entradas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label9.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 5;
            this.label9.Text = "Salidas";
            // 
            // frmResumen_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1093, 613);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResumen_Proveedores";
            this.Text = "Resumen Proveedores";
            this.Load += new System.EventHandler(this.frmResumen_Proveedores_Load);
            this.Resize += new System.EventHandler(this.frmResumen_Proveedores_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Grilla2.SpeedGrilla grdEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private Controles.cFechas cFechas1;
        private Grilla2.SpeedGrilla grdProv;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAjustes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDevoluciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaldoAnt;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialCheckBox chSoloSaldos;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSaldoProveedores;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialRadioButton rdDetalle;
        private MaterialSkin.Controls.MaterialRadioButton rdAgrupado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalSalidas;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Label label9;
    }
}