namespace Programa1.Carga.Empleados
{
    partial class frmRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdRetiros = new Grilla2.SpeedGrilla();
            this.cntMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dtResto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdExcel = new System.Windows.Forms.Button();
            this.lstMes = new System.Windows.Forms.ListBox();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cSuc = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.cntMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdRetiros);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1556, 724);
            this.splitContainer1.SplitterDistance = 1270;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdRetiros
            // 
            this.grdRetiros.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdRetiros.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdRetiros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRetiros.AutoResize = false;
            this.grdRetiros.bColor = System.Drawing.SystemColors.Window;
            this.grdRetiros.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdRetiros.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdRetiros.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdRetiros.Col = 0;
            this.grdRetiros.Cols = 10;
            this.grdRetiros.ContextMenuStrip = this.cntMenu;
            this.grdRetiros.DataMember = "";
            this.grdRetiros.DataSource = null;
            this.grdRetiros.EnableEdicion = true;
            this.grdRetiros.Encabezado = "";
            this.grdRetiros.fColor = System.Drawing.SystemColors.Control;
            this.grdRetiros.FixCols = 0;
            this.grdRetiros.FixRows = 0;
            this.grdRetiros.FuenteEncabezado = null;
            this.grdRetiros.FuentePieDePagina = null;
            this.grdRetiros.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdRetiros.Location = new System.Drawing.Point(12, 12);
            this.grdRetiros.MenuActivado = false;
            this.grdRetiros.Name = "grdRetiros";
            this.grdRetiros.PieDePagina = "\t\tPage {0} of {1}";
            this.grdRetiros.PintarFilaSel = true;
            this.grdRetiros.Redraw = true;
            this.grdRetiros.Row = 0;
            this.grdRetiros.Rows = 50;
            this.grdRetiros.Size = new System.Drawing.Size(1255, 700);
            this.grdRetiros.TabIndex = 0;
            this.grdRetiros.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdRetiros_Editado);
            this.grdRetiros.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdRetiros_CambioFila);
            this.grdRetiros.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdRetiros_KeyUp);
            // 
            // cntMenu
            // 
            this.cntMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.darDeBajaEmpleadoToolStripMenuItem});
            this.cntMenu.Name = "cntMenu";
            this.cntMenu.Size = new System.Drawing.Size(190, 48);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // darDeBajaEmpleadoToolStripMenuItem
            // 
            this.darDeBajaEmpleadoToolStripMenuItem.Name = "darDeBajaEmpleadoToolStripMenuItem";
            this.darDeBajaEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.darDeBajaEmpleadoToolStripMenuItem.Text = "Dar de baja empleado";
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
            this.splitContainer2.Panel1.Controls.Add(this.cSuc);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtBuscar);
            this.splitContainer2.Panel2.Controls.Add(this.dtResto);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.cmdImprimir);
            this.splitContainer2.Panel2.Controls.Add(this.cmdAgregar);
            this.splitContainer2.Panel2.Controls.Add(this.cmdExcel);
            this.splitContainer2.Panel2.Controls.Add(this.lstMes);
            this.splitContainer2.Size = new System.Drawing.Size(282, 724);
            this.splitContainer2.SplitterDistance = 552;
            this.splitContainer2.TabIndex = 0;
            // 
            // dtResto
            // 
            this.dtResto.Location = new System.Drawing.Point(96, 24);
            this.dtResto.Name = "dtResto";
            this.dtResto.Size = new System.Drawing.Size(174, 20);
            this.dtResto.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dtResto, "Con esta fecha se cargará Resto.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(93, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha Resto";
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Location = new System.Drawing.Point(149, 141);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(131, 24);
            this.cmdImprimir.TabIndex = 1;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAgregar.Location = new System.Drawing.Point(149, 81);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(131, 24);
            this.cmdAgregar.TabIndex = 1;
            this.cmdAgregar.Text = "Empleado Nuevo";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.CmdExcel_Click);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcel.Location = new System.Drawing.Point(149, 111);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(131, 24);
            this.cmdExcel.TabIndex = 1;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.UseVisualStyleBackColor = true;
            this.cmdExcel.Click += new System.EventHandler(this.CmdExcel_Click);
            // 
            // lstMes
            // 
            this.lstMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMes.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstMes.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstMes.FormattingEnabled = true;
            this.lstMes.ItemHeight = 18;
            this.lstMes.Location = new System.Drawing.Point(3, 3);
            this.lstMes.Name = "lstMes";
            this.lstMes.Size = new System.Drawing.Size(78, 144);
            this.lstMes.TabIndex = 0;
            this.lstMes.SelectedIndexChanged += new System.EventHandler(this.LstMes_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Hint = "Buscar por nombre";
            this.txtBuscar.Location = new System.Drawing.Point(96, 52);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(174, 23);
            this.txtBuscar.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtBuscar, "Presione la tecla Enter para buscar.");
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(-1, 12);
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.Size = new System.Drawing.Size(280, 537);
            this.cSuc.TabIndex = 0;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.CSuc_Cambio_Seleccion);
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1556, 724);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRetiros";
            this.Text = "Retiros";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.cntMenu.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdRetiros;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cSucursales cSuc;
        private System.Windows.Forms.ListBox lstMes;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdExcel;
        private System.Windows.Forms.ContextMenuStrip cntMenu;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darDeBajaEmpleadoToolStripMenuItem;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DateTimePicker dtResto;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}