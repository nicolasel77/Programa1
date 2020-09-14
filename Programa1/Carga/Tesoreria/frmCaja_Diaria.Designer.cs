namespace Programa1.Carga.Tesoreria
{
    partial class frmCaja_Diaria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja_Diaria));
            this.splPrincipal = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTEntrada = new MaterialSkin.Controls.MaterialLabel();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.mnuEntradas = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTSalida = new MaterialSkin.Controls.MaterialLabel();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSTotalEntradas = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSEntradas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSSantEntradas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmdCerrar_Fecha = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).BeginInit();
            this.splPrincipal.Panel1.SuspendLayout();
            this.splPrincipal.Panel2.SuspendLayout();
            this.splPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.mnuEntradas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splPrincipal
            // 
            this.splPrincipal.BackColor = System.Drawing.Color.Gainsboro;
            this.splPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splPrincipal.Location = new System.Drawing.Point(0, 0);
            this.splPrincipal.Name = "splPrincipal";
            // 
            // splPrincipal.Panel1
            // 
            this.splPrincipal.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splPrincipal.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splPrincipal.Panel2
            // 
            this.splPrincipal.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splPrincipal.Panel2.Controls.Add(this.panel1);
            this.splPrincipal.Panel2.Controls.Add(this.materialLabel4);
            this.splPrincipal.Panel2.Controls.Add(this.mntFecha);
            this.splPrincipal.Size = new System.Drawing.Size(1118, 719);
            this.splPrincipal.SplitterDistance = 909;
            this.splPrincipal.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer2.Panel1.Controls.Add(this.lblTEntrada);
            this.splitContainer2.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer2.Panel2.Controls.Add(this.lblTSalida);
            this.splitContainer2.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer2.Size = new System.Drawing.Size(909, 719);
            this.splitContainer2.SplitterDistance = 488;
            this.splitContainer2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 3);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(514, 20);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Entradas";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTEntrada
            // 
            this.lblTEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.lblTEntrada.Depth = 0;
            this.lblTEntrada.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTEntrada.Location = new System.Drawing.Point(3, 693);
            this.lblTEntrada.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTEntrada.Name = "lblTEntrada";
            this.lblTEntrada.Size = new System.Drawing.Size(514, 26);
            this.lblTEntrada.TabIndex = 1;
            this.lblTEntrada.Text = "Total Entrada";
            this.lblTEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.grdEntradas.Col = -2;
            this.grdEntradas.Cols = 0;
            this.grdEntradas.ContextMenuStrip = this.mnuEntradas;
            this.grdEntradas.DataMember = "";
            this.grdEntradas.DataSource = null;
            this.grdEntradas.EnableEdicion = true;
            this.grdEntradas.Encabezado = "";
            this.grdEntradas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntradas.FixCols = 0;
            this.grdEntradas.FixRows = 0;
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.Location = new System.Drawing.Point(3, 26);
            this.grdEntradas.MenuActivado = false;
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 50;
            this.grdEntradas.Size = new System.Drawing.Size(482, 664);
            this.grdEntradas.TabIndex = 0;
            this.grdEntradas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdEntradas_Editado);
            // 
            // mnuEntradas
            // 
            this.mnuEntradas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuEntradas.Depth = 0;
            this.mnuEntradas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarToolStripMenuItem,
            this.cambiarFechaToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.mnuEntradas.MouseState = MaterialSkin.MouseState.HOVER;
            this.mnuEntradas.Name = "mnuEntradas";
            this.mnuEntradas.Size = new System.Drawing.Size(154, 70);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // cambiarFechaToolStripMenuItem
            // 
            this.cambiarFechaToolStripMenuItem.Name = "cambiarFechaToolStripMenuItem";
            this.cambiarFechaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cambiarFechaToolStripMenuItem.Text = "Cambiar Fecha";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(3, 3);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(442, 20);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Gastos";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTSalida
            // 
            this.lblTSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTSalida.BackColor = System.Drawing.SystemColors.Control;
            this.lblTSalida.Depth = 0;
            this.lblTSalida.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTSalida.Location = new System.Drawing.Point(3, 693);
            this.lblTSalida.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTSalida.Name = "lblTSalida";
            this.lblTSalida.Size = new System.Drawing.Size(442, 26);
            this.lblTSalida.TabIndex = 2;
            this.lblTSalida.Text = "Total Salida";
            this.lblTSalida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.grdSalidas.Col = -2;
            this.grdSalidas.Cols = 0;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = true;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.Location = new System.Drawing.Point(3, 26);
            this.grdSalidas.MenuActivado = false;
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 50;
            this.grdSalidas.Size = new System.Drawing.Size(414, 664);
            this.grdSalidas.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblSTotalEntradas);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblSEntradas);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblSSantEntradas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.materialLabel5);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.cmdCerrar_Fecha);
            this.panel1.Location = new System.Drawing.Point(8, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 507);
            this.panel1.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(109, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "$ 0,0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTotalEntradas
            // 
            this.lblSTotalEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTotalEntradas.Location = new System.Drawing.Point(109, 57);
            this.lblSTotalEntradas.Name = "lblSTotalEntradas";
            this.lblSTotalEntradas.Size = new System.Drawing.Size(73, 16);
            this.lblSTotalEntradas.TabIndex = 6;
            this.lblSTotalEntradas.Text = "$ 0,0";
            this.lblSTotalEntradas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(109, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "$ 0,0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSEntradas
            // 
            this.lblSEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSEntradas.Location = new System.Drawing.Point(109, 41);
            this.lblSEntradas.Name = "lblSEntradas";
            this.lblSEntradas.Size = new System.Drawing.Size(73, 16);
            this.lblSEntradas.TabIndex = 6;
            this.lblSEntradas.Text = "$ 0,0";
            this.lblSEntradas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Salidas:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Entradas:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(109, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "$ 0,0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSSantEntradas
            // 
            this.lblSSantEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSSantEntradas.Location = new System.Drawing.Point(109, 25);
            this.lblSSantEntradas.Name = "lblSSantEntradas";
            this.lblSSantEntradas.Size = new System.Drawing.Size(73, 16);
            this.lblSSantEntradas.TabIndex = 6;
            this.lblSSantEntradas.Text = "$ 0,0";
            this.lblSSantEntradas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Caja Externa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saldo Anterior:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(-17, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(231, 2);
            this.panel5.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(-17, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 2);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(0, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 2);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 2);
            this.panel3.TabIndex = 5;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(0, 81);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(58, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "Salidas";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(0, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(68, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Entradas";
            // 
            // cmdCerrar_Fecha
            // 
            this.cmdCerrar_Fecha.AutoSize = true;
            this.cmdCerrar_Fecha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCerrar_Fecha.Depth = 0;
            this.cmdCerrar_Fecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdCerrar_Fecha.Location = new System.Drawing.Point(0, 471);
            this.cmdCerrar_Fecha.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCerrar_Fecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCerrar_Fecha.Name = "cmdCerrar_Fecha";
            this.cmdCerrar_Fecha.Primary = false;
            this.cmdCerrar_Fecha.Size = new System.Drawing.Size(185, 36);
            this.cmdCerrar_Fecha.TabIndex = 0;
            this.cmdCerrar_Fecha.Text = "Cerrar Fecha";
            this.cmdCerrar_Fecha.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(8, 3);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(204, 20);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "Fecha";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mntFecha
            // 
            this.mntFecha.BackColor = System.Drawing.Color.Gainsboro;
            this.mntFecha.Location = new System.Drawing.Point(8, 26);
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 0;
            this.mntFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mntFecha_DateSelected);
            // 
            // frmCaja_Diaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 719);
            this.Controls.Add(this.splPrincipal);
            this.Name = "frmCaja_Diaria";
            this.Text = "Caja Diaria";
            this.Load += new System.EventHandler(this.frmCaja_Diaria_Load);
            this.Resize += new System.EventHandler(this.frmCaja_Diaria_Resize);
            this.splPrincipal.Panel1.ResumeLayout(false);
            this.splPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).EndInit();
            this.splPrincipal.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.mnuEntradas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splPrincipal;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MaterialSkin.Controls.MaterialLabel lblTEntrada;
        private Grilla2.SpeedGrilla grdEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblTSalida;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.MonthCalendar mntFecha;
        private MaterialSkin.Controls.MaterialFlatButton cmdCerrar_Fecha;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialContextMenuStrip mnuEntradas;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSTotalEntradas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSEntradas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSSantEntradas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}