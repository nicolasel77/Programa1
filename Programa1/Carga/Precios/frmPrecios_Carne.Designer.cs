namespace Programa1.Carga.Precios
{
    partial class frmPrecios_Carne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecios_Carne));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPromedio = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIntegracion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBifes = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdProductos = new Grilla2.SpeedGrilla();
            this.splFormulas = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSuc = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdFormulas = new Programa1.Controles.cBoton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdSucursales = new Grilla2.SpeedGrilla();
            this.cmdCalcular = new Programa1.Controles.cBoton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdFormulas = new Grilla2.SpeedGrilla();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splFormulas)).BeginInit();
            this.splFormulas.Panel1.SuspendLayout();
            this.splFormulas.Panel2.SuspendLayout();
            this.splFormulas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splFormulas);
            this.splitContainer1.Size = new System.Drawing.Size(1041, 692);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPromedio,
            this.lblIntegracion,
            this.lblBifes});
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(445, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPromedio
            // 
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(124, 21);
            this.lblPromedio.Text = "Promedio: 0,000";
            // 
            // lblIntegracion
            // 
            this.lblIntegracion.Name = "lblIntegracion";
            this.lblIntegracion.Size = new System.Drawing.Size(118, 21);
            this.lblIntegracion.Text = "Costo Int: 0,000";
            // 
            // lblBifes
            // 
            this.lblBifes.Name = "lblBifes";
            this.lblBifes.Size = new System.Drawing.Size(85, 21);
            this.lblBifes.Text = "Bifes Desh:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.grdProductos);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 664);
            this.panel1.TabIndex = 0;
            // 
            // grdProductos
            // 
            this.grdProductos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProductos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProductos.AutoResize = false;
            this.grdProductos.bColor = System.Drawing.SystemColors.Window;
            this.grdProductos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProductos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProductos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProductos.Col = 0;
            this.grdProductos.Cols = 10;
            this.grdProductos.DataMember = "";
            this.grdProductos.DataSource = null;
            this.grdProductos.EnableEdicion = true;
            this.grdProductos.Encabezado = "";
            this.grdProductos.fColor = System.Drawing.SystemColors.Control;
            this.grdProductos.FixCols = 0;
            this.grdProductos.FixRows = 0;
            this.grdProductos.FuenteEncabezado = null;
            this.grdProductos.FuentePieDePagina = null;
            this.grdProductos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProductos.Location = new System.Drawing.Point(3, 3);
            this.grdProductos.MenuActivado = false;
            this.grdProductos.Name = "grdProductos";
            this.grdProductos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProductos.PintarFilaSel = true;
            this.grdProductos.Redraw = true;
            this.grdProductos.Row = 0;
            this.grdProductos.Rows = 50;
            this.grdProductos.Size = new System.Drawing.Size(433, 657);
            this.grdProductos.TabIndex = 0;
            this.grdProductos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdProductos_Editado);
            this.grdProductos.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdProductos_KeyUp);
            // 
            // splFormulas
            // 
            this.splFormulas.BackColor = System.Drawing.Color.Gainsboro;
            this.splFormulas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splFormulas.Location = new System.Drawing.Point(0, 0);
            this.splFormulas.Name = "splFormulas";
            this.splFormulas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splFormulas.Panel1
            // 
            this.splFormulas.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splFormulas.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splFormulas.Panel2
            // 
            this.splFormulas.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splFormulas.Panel2.Controls.Add(this.cmdCalcular);
            this.splFormulas.Panel2.Controls.Add(this.panel2);
            this.splFormulas.Panel2Collapsed = true;
            this.splFormulas.Size = new System.Drawing.Size(592, 692);
            this.splFormulas.SplitterDistance = 526;
            this.splFormulas.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.lstFechas);
            this.splitContainer3.Panel1.Controls.Add(this.panel4);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.cmdBorrar);
            this.splitContainer3.Panel1.Controls.Add(this.cmdGuardar);
            this.splitContainer3.Panel1.Controls.Add(this.cmdImprimir);
            this.splitContainer3.Panel1.Controls.Add(this.cmdFormulas);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panel3);
            this.splitContainer3.Size = new System.Drawing.Size(592, 692);
            this.splitContainer3.SplitterDistance = 109;
            this.splitContainer3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lblSuc);
            this.panel4.Location = new System.Drawing.Point(0, 486);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(105, 56);
            this.panel4.TabIndex = 2;
            // 
            // lblSuc
            // 
            this.lblSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSuc.Depth = 0;
            this.lblSuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSuc.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSuc.Location = new System.Drawing.Point(0, 0);
            this.lblSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(105, 56);
            this.lblSuc.TabIndex = 1;
            this.lblSuc.Text = "Sucursal";
            this.lblSuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fechas";
            // 
            // lstFechas
            // 
            this.lstFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(5, 19);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(100, 460);
            this.lstFechas.TabIndex = 1;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.Enabled = false;
            this.cmdBorrar.Location = new System.Drawing.Point(3, 584);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(103, 30);
            this.cmdBorrar.TabIndex = 0;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.Enabled = false;
            this.cmdGuardar.Location = new System.Drawing.Point(3, 548);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(103, 30);
            this.cmdGuardar.TabIndex = 0;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(3, 620);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(103, 30);
            this.cmdImprimir.TabIndex = 0;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdFormulas
            // 
            this.cmdFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFormulas.Location = new System.Drawing.Point(3, 656);
            this.cmdFormulas.Name = "cmdFormulas";
            this.cmdFormulas.Size = new System.Drawing.Size(103, 30);
            this.cmdFormulas.TabIndex = 0;
            this.cmdFormulas.Texto = "Fórmulas";
            this.cmdFormulas.Click += new System.EventHandler(this.cmdFormulas_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.grdSucursales);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 686);
            this.panel3.TabIndex = 0;
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
            this.grdSucursales.Cols = 10;
            this.grdSucursales.DataMember = "";
            this.grdSucursales.DataSource = null;
            this.grdSucursales.EnableEdicion = false;
            this.grdSucursales.Encabezado = "";
            this.grdSucursales.fColor = System.Drawing.SystemColors.Control;
            this.grdSucursales.FixCols = 0;
            this.grdSucursales.FixRows = 0;
            this.grdSucursales.FuenteEncabezado = null;
            this.grdSucursales.FuentePieDePagina = null;
            this.grdSucursales.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSucursales.Location = new System.Drawing.Point(3, 3);
            this.grdSucursales.MenuActivado = false;
            this.grdSucursales.Name = "grdSucursales";
            this.grdSucursales.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSucursales.PintarFilaSel = false;
            this.grdSucursales.Redraw = true;
            this.grdSucursales.Row = 0;
            this.grdSucursales.Rows = 50;
            this.grdSucursales.Size = new System.Drawing.Size(467, 680);
            this.grdSucursales.TabIndex = 0;
            this.grdSucursales.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdSucursales_CambioFila);
            // 
            // cmdCalcular
            // 
            this.cmdCalcular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCalcular.Location = new System.Drawing.Point(424, 140);
            this.cmdCalcular.Name = "cmdCalcular";
            this.cmdCalcular.Size = new System.Drawing.Size(165, 19);
            this.cmdCalcular.TabIndex = 1;
            this.cmdCalcular.Texto = "Calcular";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.grdFormulas);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 131);
            this.panel2.TabIndex = 0;
            // 
            // grdFormulas
            // 
            this.grdFormulas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdFormulas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFormulas.AutoResize = false;
            this.grdFormulas.bColor = System.Drawing.SystemColors.Window;
            this.grdFormulas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdFormulas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdFormulas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdFormulas.Col = 0;
            this.grdFormulas.Cols = 10;
            this.grdFormulas.DataMember = "";
            this.grdFormulas.DataSource = null;
            this.grdFormulas.EnableEdicion = true;
            this.grdFormulas.Encabezado = "";
            this.grdFormulas.fColor = System.Drawing.SystemColors.Control;
            this.grdFormulas.FixCols = 0;
            this.grdFormulas.FixRows = 0;
            this.grdFormulas.FuenteEncabezado = null;
            this.grdFormulas.FuentePieDePagina = null;
            this.grdFormulas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdFormulas.Location = new System.Drawing.Point(3, 3);
            this.grdFormulas.MenuActivado = false;
            this.grdFormulas.Name = "grdFormulas";
            this.grdFormulas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdFormulas.PintarFilaSel = true;
            this.grdFormulas.Redraw = true;
            this.grdFormulas.Row = 0;
            this.grdFormulas.Rows = 50;
            this.grdFormulas.Size = new System.Drawing.Size(580, 126);
            this.grdFormulas.TabIndex = 0;
            // 
            // frmPrecios_Carne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrecios_Carne";
            this.Text = "Carne";
            this.Load += new System.EventHandler(this.frmPrecios_Carne_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splFormulas.Panel1.ResumeLayout(false);
            this.splFormulas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splFormulas)).EndInit();
            this.splFormulas.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private Grilla2.SpeedGrilla grdProductos;
        private System.Windows.Forms.ToolStripStatusLabel lblPromedio;
        private System.Windows.Forms.ToolStripStatusLabel lblIntegracion;
        private System.Windows.Forms.ToolStripStatusLabel lblBifes;
        private System.Windows.Forms.SplitContainer splFormulas;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel3;
        private Grilla2.SpeedGrilla grdSucursales;
        private Controles.cBoton cmdCalcular;
        private System.Windows.Forms.Panel panel2;
        private Grilla2.SpeedGrilla grdFormulas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstFechas;
        private Controles.cBoton cmdGuardar;
        private Controles.cBoton cmdImprimir;
        private Controles.cBoton cmdFormulas;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialLabel lblSuc;
        private Controles.cBoton cmdBorrar;
    }
}