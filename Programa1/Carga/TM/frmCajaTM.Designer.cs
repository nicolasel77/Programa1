namespace Programa1.Carga.TM
{
    partial class frmCajaTM
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
            this.splPrincipal = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.lblTotalGrillaEntrada = new System.Windows.Forms.Label();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.mnuEntradas = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialLabel3 = new System.Windows.Forms.Label();
            this.lblTotalGrillaGastos = new System.Windows.Forms.Label();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.mnuGastos = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.cmdPagoHacienda = new System.Windows.Forms.Button();
            this.grdCajas = new Grilla2.SpeedGrilla();
            this.materialLabel4 = new System.Windows.Forms.Label();
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verTransferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarEntregasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCheques = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).BeginInit();
            this.splPrincipal.Panel1.SuspendLayout();
            this.splPrincipal.Panel2.SuspendLayout();
            this.splPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.mnuEntradas.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.splPrincipal.Panel2.Controls.Add(this.cmdCheques);
            this.splPrincipal.Panel2.Controls.Add(this.cmdPagoHacienda);
            this.splPrincipal.Panel2.Controls.Add(this.grdCajas);
            this.splPrincipal.Panel2.Controls.Add(this.materialLabel4);
            this.splPrincipal.Panel2.Controls.Add(this.mntFecha);
            this.splPrincipal.Panel2MinSize = 250;
            this.splPrincipal.Size = new System.Drawing.Size(1486, 719);
            this.splPrincipal.SplitterDistance = 1186;
            this.splPrincipal.SplitterWidth = 8;
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
            this.splitContainer2.Size = new System.Drawing.Size(1186, 719);
            this.splitContainer2.SplitterDistance = 450;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblEntradas
            // 
            this.lblEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEntradas.BackColor = System.Drawing.SystemColors.Control;
            this.lblEntradas.Font = new System.Drawing.Font("Arial", 11F);
            this.lblEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEntradas.Location = new System.Drawing.Point(3, 3);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(444, 20);
            this.lblEntradas.TabIndex = 1;
            this.lblEntradas.Text = "Entradas";
            this.lblEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalGrillaEntrada
            // 
            this.lblTotalGrillaEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGrillaEntrada.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalGrillaEntrada.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTotalGrillaEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalGrillaEntrada.Location = new System.Drawing.Point(12, 693);
            this.lblTotalGrillaEntrada.Name = "lblTotalGrillaEntrada";
            this.lblTotalGrillaEntrada.Size = new System.Drawing.Size(435, 24);
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
            this.grdEntradas.Frozen = 0;
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdEntradas.Location = new System.Drawing.Point(12, 40);
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 50;
            this.grdEntradas.Size = new System.Drawing.Size(435, 646);
            this.grdEntradas.TabIndex = 0;
            this.grdEntradas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdEntradas_Editado);
            this.grdEntradas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdEntradas_KeyUp);
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
            this.materialLabel3.Font = new System.Drawing.Font("Arial", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(3, 3);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(645, 20);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Gastos";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalGrillaGastos
            // 
            this.lblTotalGrillaGastos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalGrillaGastos.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotalGrillaGastos.Font = new System.Drawing.Font("Arial", 11F);
            this.lblTotalGrillaGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalGrillaGastos.Location = new System.Drawing.Point(3, 693);
            this.lblTotalGrillaGastos.Name = "lblTotalGrillaGastos";
            this.lblTotalGrillaGastos.Size = new System.Drawing.Size(718, 24);
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
            this.grdSalidas.ContextMenuStrip = this.mnuGastos;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = true;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.Frozen = 0;
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdSalidas.Location = new System.Drawing.Point(3, 40);
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 50;
            this.grdSalidas.Size = new System.Drawing.Size(718, 646);
            this.grdSalidas.TabIndex = 0;
            this.grdSalidas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSalidas_Editado);
            this.grdSalidas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdSalidas_KeyUp);
            // 
            // mnuGastos
            // 
            this.mnuGastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mnuGastos.Depth = 0;
            this.mnuGastos.MouseState = MaterialSkin.MouseState.HOVER;
            this.mnuGastos.Name = "mnuGastos";
            this.mnuGastos.Size = new System.Drawing.Size(61, 4);
            // 
            // cmdPagoHacienda
            // 
            this.cmdPagoHacienda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPagoHacienda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPagoHacienda.Location = new System.Drawing.Point(158, 692);
            this.cmdPagoHacienda.Name = "cmdPagoHacienda";
            this.cmdPagoHacienda.Size = new System.Drawing.Size(110, 23);
            this.cmdPagoHacienda.TabIndex = 8;
            this.cmdPagoHacienda.Text = "Pago de Hacienda";
            this.cmdPagoHacienda.UseVisualStyleBackColor = true;
            this.cmdPagoHacienda.Click += new System.EventHandler(this.cmdPagoHacienda_Click);
            // 
            // grdCajas
            // 
            this.grdCajas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCajas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
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
            this.grdCajas.EnableEdicion = false;
            this.grdCajas.Encabezado = "";
            this.grdCajas.fColor = System.Drawing.SystemColors.Control;
            this.grdCajas.FixCols = 0;
            this.grdCajas.FixRows = 0;
            this.grdCajas.Frozen = 0;
            this.grdCajas.FuenteEncabezado = null;
            this.grdCajas.FuentePieDePagina = null;
            this.grdCajas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCajas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCajas.Location = new System.Drawing.Point(6, 200);
            this.grdCajas.Name = "grdCajas";
            this.grdCajas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCajas.PintarFilaSel = true;
            this.grdCajas.Redraw = true;
            this.grdCajas.Row = 0;
            this.grdCajas.Rows = 50;
            this.grdCajas.Size = new System.Drawing.Size(258, 486);
            this.grdCajas.TabIndex = 7;
            // 
            // materialLabel4
            // 
            this.materialLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel4.Font = new System.Drawing.Font("Arial", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(8, 3);
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(243, 20);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "Fecha";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mntFecha
            // 
            this.mntFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mntFecha.BackColor = System.Drawing.Color.White;
            this.mntFecha.Location = new System.Drawing.Point(13, 26);
            this.mntFecha.MaxSelectionCount = 1;
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 0;
            this.mntFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mntFecha_DateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTransferenciasToolStripMenuItem,
            this.transferenciaToolStripMenuItem,
            this.verToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.importarEntregasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1486, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verTransferenciasToolStripMenuItem
            // 
            this.verTransferenciasToolStripMenuItem.Name = "verTransferenciasToolStripMenuItem";
            this.verTransferenciasToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.verTransferenciasToolStripMenuItem.Text = "Ver Transferencias";
            // 
            // transferenciaToolStripMenuItem
            // 
            this.transferenciaToolStripMenuItem.Name = "transferenciaToolStripMenuItem";
            this.transferenciaToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.transferenciaToolStripMenuItem.Text = "Transferencia";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soloToolStripMenuItem,
            this.todosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.entradasToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // soloToolStripMenuItem
            // 
            this.soloToolStripMenuItem.Name = "soloToolStripMenuItem";
            this.soloToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.soloToolStripMenuItem.Text = "Solo";
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Checked = true;
            this.todosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(116, 6);
            // 
            // entradasToolStripMenuItem
            // 
            this.entradasToolStripMenuItem.Checked = true;
            this.entradasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            this.entradasToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.entradasToolStripMenuItem.Text = "Entradas";
            this.entradasToolStripMenuItem.Click += new System.EventHandler(this.entradasToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.buscarToolStripMenuItem.Text = "Buscar [F3]";
            this.buscarToolStripMenuItem.Visible = false;
            // 
            // importarEntregasToolStripMenuItem
            // 
            this.importarEntregasToolStripMenuItem.Name = "importarEntregasToolStripMenuItem";
            this.importarEntregasToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.importarEntregasToolStripMenuItem.Text = "Importar Entregas";
            this.importarEntregasToolStripMenuItem.Visible = false;
            // 
            // cmdCheques
            // 
            this.cmdCheques.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCheques.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCheques.Location = new System.Drawing.Point(42, 692);
            this.cmdCheques.Name = "cmdCheques";
            this.cmdCheques.Size = new System.Drawing.Size(110, 23);
            this.cmdCheques.TabIndex = 8;
            this.cmdCheques.Text = "Cheques";
            this.cmdCheques.UseVisualStyleBackColor = true;
            this.cmdCheques.Click += new System.EventHandler(this.cmdCheques_Click);
            // 
            // frmCajaTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 719);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splPrincipal);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCajaTM";
            this.Text = "Caja Diaria";
            this.splPrincipal.Panel1.ResumeLayout(false);
            this.splPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splPrincipal)).EndInit();
            this.splPrincipal.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.mnuEntradas.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splPrincipal;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblTotalGrillaEntrada;
        private Grilla2.SpeedGrilla grdEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Label materialLabel3;
        private System.Windows.Forms.Label lblTotalGrillaGastos;
        private System.Windows.Forms.Label materialLabel4;
        private System.Windows.Forms.MonthCalendar mntFecha;
        private MaterialSkin.Controls.MaterialContextMenuStrip mnuEntradas;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verTransferenciasToolStripMenuItem;
        private MaterialSkin.Controls.MaterialContextMenuStrip mnuGastos;
        private System.Windows.Forms.ToolStripMenuItem transferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarEntregasToolStripMenuItem;
        private Grilla2.SpeedGrilla grdCajas;
        private System.Windows.Forms.Button cmdPagoHacienda;
        private System.Windows.Forms.Button cmdCheques;
    }
}
