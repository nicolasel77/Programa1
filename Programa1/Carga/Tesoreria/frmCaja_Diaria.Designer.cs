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
            this.lblEntradas = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalGrillaEntrada = new MaterialSkin.Controls.MaterialLabel();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.mnuEntradas = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalGrillaGastos = new MaterialSkin.Controls.MaterialLabel();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdCajas = new Grilla2.SpeedGrilla();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSTotalEntradas = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGastos = new System.Windows.Forms.Label();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCajaExterna = new System.Windows.Forms.Label();
            this.lblSaldoAnterior = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmdCerrar_Fecha = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.lblUltimo = new MaterialSkin.Controls.MaterialLabel();
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
            this.splPrincipal.Panel2.Resize += new System.EventHandler(this.splPrincipal_Panel2_Resize);
            this.splPrincipal.Size = new System.Drawing.Size(1517, 719);
            this.splPrincipal.SplitterDistance = 1233;
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
            this.splitContainer2.Panel1.Controls.Add(this.lblEntradas);
            this.splitContainer2.Panel1.Controls.Add(this.lblTotalGrillaEntrada);
            this.splitContainer2.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer2.Panel2.Controls.Add(this.lblTotalGrillaGastos);
            this.splitContainer2.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer2.Size = new System.Drawing.Size(1233, 719);
            this.splitContainer2.SplitterDistance = 470;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblEntradas
            // 
            this.lblEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntradas.BackColor = System.Drawing.SystemColors.Control;
            this.lblEntradas.Depth = 0;
            this.lblEntradas.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEntradas.Location = new System.Drawing.Point(3, 3);
            this.lblEntradas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(464, 20);
            this.lblEntradas.TabIndex = 1;
            this.lblEntradas.Text = "Entradas";
            this.lblEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalGrillaEntrada
            // 
            this.lblTotalGrillaEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGrillaEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalGrillaEntrada.Depth = 0;
            this.lblTotalGrillaEntrada.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotalGrillaEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalGrillaEntrada.Location = new System.Drawing.Point(3, 693);
            this.lblTotalGrillaEntrada.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalGrillaEntrada.Name = "lblTotalGrillaEntrada";
            this.lblTotalGrillaEntrada.Size = new System.Drawing.Size(464, 22);
            this.lblTotalGrillaEntrada.TabIndex = 1;
            this.lblTotalGrillaEntrada.Text = "Total Entrada";
            this.lblTotalGrillaEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.grdEntradas.Size = new System.Drawing.Size(464, 664);
            this.grdEntradas.TabIndex = 0;
            this.grdEntradas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdEntradas_Editado);
            this.grdEntradas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdEntradas_CambioFila);
            this.grdEntradas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdEntradas_KeyUp);
            this.grdEntradas.DobleClick += new Grilla2.SpeedGrilla.DobleClickEventHandler(this.grdEntradas_DobleClick);
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
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // cambiarFechaToolStripMenuItem
            // 
            this.cambiarFechaToolStripMenuItem.Name = "cambiarFechaToolStripMenuItem";
            this.cambiarFechaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.cambiarFechaToolStripMenuItem.Text = "Cambiar Fecha";
            this.cambiarFechaToolStripMenuItem.Click += new System.EventHandler(this.cambiarFechaToolStripMenuItem_Click);
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
            this.materialLabel3.Size = new System.Drawing.Size(756, 20);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Gastos";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalGrillaGastos
            // 
            this.lblTotalGrillaGastos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGrillaGastos.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalGrillaGastos.Depth = 0;
            this.lblTotalGrillaGastos.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotalGrillaGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalGrillaGastos.Location = new System.Drawing.Point(3, 693);
            this.lblTotalGrillaGastos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalGrillaGastos.Name = "lblTotalGrillaGastos";
            this.lblTotalGrillaGastos.Size = new System.Drawing.Size(756, 22);
            this.lblTotalGrillaGastos.TabIndex = 2;
            this.lblTotalGrillaGastos.Text = "Total Salida";
            this.lblTotalGrillaGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.grdSalidas.Size = new System.Drawing.Size(756, 664);
            this.grdSalidas.TabIndex = 0;
            this.grdSalidas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSalidas_Editado);
            this.grdSalidas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdSalidas_CambioFila);
            this.grdSalidas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdSalidas_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblUltimo);
            this.panel1.Controls.Add(this.grdCajas);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblSTotalEntradas);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblGastos);
            this.panel1.Controls.Add(this.lblTotalEntradas);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCajaExterna);
            this.panel1.Controls.Add(this.lblSaldoAnterior);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.materialLabel5);
            this.panel1.Controls.Add(this.materialLabel2);
            this.panel1.Controls.Add(this.cmdCerrar_Fecha);
            this.panel1.Location = new System.Drawing.Point(8, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 507);
            this.panel1.TabIndex = 4;
            // 
            // grdCajas
            // 
            this.grdCajas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCajas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCajas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCajas.AutoResize = false;
            this.grdCajas.bColor = System.Drawing.SystemColors.Window;
            this.grdCajas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCajas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCajas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCajas.Col = 0;
            this.grdCajas.Cols = 10;
            this.grdCajas.DataMember = "";
            this.grdCajas.DataSource = null;
            this.grdCajas.EnableEdicion = true;
            this.grdCajas.Encabezado = "";
            this.grdCajas.fColor = System.Drawing.SystemColors.Control;
            this.grdCajas.FixCols = 0;
            this.grdCajas.FixRows = 0;
            this.grdCajas.FuenteEncabezado = null;
            this.grdCajas.FuentePieDePagina = null;
            this.grdCajas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCajas.Location = new System.Drawing.Point(6, 192);
            this.grdCajas.MenuActivado = false;
            this.grdCajas.Name = "grdCajas";
            this.grdCajas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCajas.PintarFilaSel = true;
            this.grdCajas.Redraw = true;
            this.grdCajas.Row = 0;
            this.grdCajas.Rows = 50;
            this.grdCajas.Size = new System.Drawing.Size(254, 219);
            this.grdCajas.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Location = new System.Drawing.Point(86, 138);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(178, 16);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "$ 0,0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSTotalEntradas
            // 
            this.lblSTotalEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSTotalEntradas.Location = new System.Drawing.Point(86, 57);
            this.lblSTotalEntradas.Name = "lblSTotalEntradas";
            this.lblSTotalEntradas.Size = new System.Drawing.Size(178, 16);
            this.lblSTotalEntradas.TabIndex = 6;
            this.lblSTotalEntradas.Text = "$ 0,0";
            this.lblSTotalEntradas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Total:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGastos
            // 
            this.lblGastos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGastos.Location = new System.Drawing.Point(86, 122);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(178, 16);
            this.lblGastos.TabIndex = 6;
            this.lblGastos.Text = "$ 0,0";
            this.lblGastos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalEntradas.Location = new System.Drawing.Point(86, 41);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(178, 16);
            this.lblTotalEntradas.TabIndex = 6;
            this.lblTotalEntradas.Text = "$ 0,0";
            this.lblTotalEntradas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Salidas:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Entradas:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCajaExterna
            // 
            this.lblCajaExterna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCajaExterna.Location = new System.Drawing.Point(86, 106);
            this.lblCajaExterna.Name = "lblCajaExterna";
            this.lblCajaExterna.Size = new System.Drawing.Size(178, 16);
            this.lblCajaExterna.TabIndex = 6;
            this.lblCajaExterna.Text = "$ 0,0";
            this.lblCajaExterna.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldoAnterior
            // 
            this.lblSaldoAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSaldoAnterior.Location = new System.Drawing.Point(86, 25);
            this.lblSaldoAnterior.Name = "lblSaldoAnterior";
            this.lblSaldoAnterior.Size = new System.Drawing.Size(178, 16);
            this.lblSaldoAnterior.TabIndex = 6;
            this.lblSaldoAnterior.Text = "$ 0,0";
            this.lblSaldoAnterior.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Caja Externa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saldo Anterior:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Location = new System.Drawing.Point(0, 184);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(313, 2);
            this.panel6.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(-17, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(313, 2);
            this.panel5.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(-17, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(313, 2);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(0, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 2);
            this.panel4.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 2);
            this.panel3.TabIndex = 5;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(0, 162);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(47, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Cajas";
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
            this.cmdCerrar_Fecha.Size = new System.Drawing.Size(267, 36);
            this.cmdCerrar_Fecha.TabIndex = 0;
            this.cmdCerrar_Fecha.Text = "Cerrar Fecha";
            this.cmdCerrar_Fecha.UseVisualStyleBackColor = true;
            this.cmdCerrar_Fecha.Click += new System.EventHandler(this.cmdCerrar_Fecha_Click);
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
            this.materialLabel4.Size = new System.Drawing.Size(279, 20);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "Fecha";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mntFecha
            // 
            this.mntFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mntFecha.BackColor = System.Drawing.Color.Gainsboro;
            this.mntFecha.Location = new System.Drawing.Point(46, 26);
            this.mntFecha.MaxSelectionCount = 1;
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 0;
            this.mntFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mntFecha_DateSelected);
            // 
            // lblUltimo
            // 
            this.lblUltimo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimo.Depth = 0;
            this.lblUltimo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblUltimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUltimo.Location = new System.Drawing.Point(3, 446);
            this.lblUltimo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUltimo.Name = "lblUltimo";
            this.lblUltimo.Size = new System.Drawing.Size(264, 19);
            this.lblUltimo.TabIndex = 8;
            this.lblUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCaja_Diaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1517, 719);
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
        private MaterialSkin.Controls.MaterialLabel lblTotalGrillaEntrada;
        private Grilla2.SpeedGrilla grdEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private MaterialSkin.Controls.MaterialLabel lblEntradas;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblTotalGrillaGastos;
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
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaldoAnterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGastos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCajaExterna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Grilla2.SpeedGrilla grdCajas;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblUltimo;
    }
}