namespace Programa1.Carga.Precios
{
    partial class frmPrecios_GranjaFr
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblPromedio = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIntegracion = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.nuDecimales = new System.Windows.Forms.NumericUpDown();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSuc = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdProductos = new Grilla2.SpeedGrilla();
            this.grdFranquicia = new Grilla2.SpeedGrilla();
            this.grdSucursales = new Grilla2.SpeedGrilla();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdGuardarFR = new Programa1.Controles.cBoton();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdPorcentaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuDecimales)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1331, 627);
            this.splitContainer1.SplitterDistance = 657;
            this.splitContainer1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPromedio,
            this.toolStripStatusLabel1,
            this.lblIntegracion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(657, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblPromedio
            // 
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(124, 21);
            this.lblPromedio.Text = "Promedio: 0,000";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(79, 21);
            this.toolStripStatusLabel1.Text = "Costo Int: ";
            // 
            // lblIntegracion
            // 
            this.lblIntegracion.Name = "lblIntegracion";
            this.lblIntegracion.Size = new System.Drawing.Size(49, 21);
            this.lblIntegracion.Text = "0,000";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 599);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grdProductos);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdFranquicia);
            this.splitContainer2.Size = new System.Drawing.Size(651, 599);
            this.splitContainer2.SplitterDistance = 357;
            this.splitContainer2.TabIndex = 1;
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
            this.splitContainer3.Panel1.Controls.Add(this.cmdPorcentaje);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            this.splitContainer3.Panel1.Controls.Add(this.nuDecimales);
            this.splitContainer3.Panel1.Controls.Add(this.lstFechas);
            this.splitContainer3.Panel1.Controls.Add(this.panel4);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.cmdBorrar);
            this.splitContainer3.Panel1.Controls.Add(this.cmdGuardarFR);
            this.splitContainer3.Panel1.Controls.Add(this.cmdImprimir);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panel3);
            this.splitContainer3.Size = new System.Drawing.Size(670, 627);
            this.splitContainer3.SplitterDistance = 183;
            this.splitContainer3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(2, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dec:";
            // 
            // nuDecimales
            // 
            this.nuDecimales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuDecimales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuDecimales.ForeColor = System.Drawing.Color.DimGray;
            this.nuDecimales.Location = new System.Drawing.Point(50, 357);
            this.nuDecimales.Name = "nuDecimales";
            this.nuDecimales.Size = new System.Drawing.Size(37, 22);
            this.nuDecimales.TabIndex = 11;
            this.nuDecimales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.lstFechas.Size = new System.Drawing.Size(174, 300);
            this.lstFechas.TabIndex = 1;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lblSuc);
            this.panel4.Location = new System.Drawing.Point(6, 385);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(172, 56);
            this.panel4.TabIndex = 2;
            // 
            // lblSuc
            // 
            this.lblSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSuc.Depth = 0;
            this.lblSuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSuc.Location = new System.Drawing.Point(0, 0);
            this.lblSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(172, 56);
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
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.grdSucursales);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(477, 621);
            this.panel3.TabIndex = 0;
            // 
            // grdProductos
            // 
            this.grdProductos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProductos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProductos.AutoResize = false;
            this.grdProductos.bColor = System.Drawing.SystemColors.Window;
            this.grdProductos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProductos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProductos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProductos.Col = 0;
            this.grdProductos.Cols = 10;
            this.grdProductos.DataMember = "";
            this.grdProductos.DataSource = null;
            this.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProductos.EnableEdicion = true;
            this.grdProductos.Encabezado = "";
            this.grdProductos.fColor = System.Drawing.SystemColors.Control;
            this.grdProductos.FixCols = 0;
            this.grdProductos.FixRows = 0;
            this.grdProductos.Frozen = 0;
            this.grdProductos.FuenteEncabezado = null;
            this.grdProductos.FuentePieDePagina = null;
            this.grdProductos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProductos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdProductos.Location = new System.Drawing.Point(0, 0);
            this.grdProductos.Name = "grdProductos";
            this.grdProductos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProductos.PintarFilaSel = true;
            this.grdProductos.Redraw = true;
            this.grdProductos.Row = 0;
            this.grdProductos.Rows = 50;
            this.grdProductos.Size = new System.Drawing.Size(357, 599);
            this.grdProductos.TabIndex = 0;
            // 
            // grdFranquicia
            // 
            this.grdFranquicia.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdFranquicia.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdFranquicia.AutoResize = false;
            this.grdFranquicia.bColor = System.Drawing.SystemColors.Window;
            this.grdFranquicia.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdFranquicia.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdFranquicia.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdFranquicia.Col = 0;
            this.grdFranquicia.Cols = 10;
            this.grdFranquicia.DataMember = "";
            this.grdFranquicia.DataSource = null;
            this.grdFranquicia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFranquicia.EnableEdicion = true;
            this.grdFranquicia.Encabezado = "";
            this.grdFranquicia.fColor = System.Drawing.Color.Silver;
            this.grdFranquicia.FixCols = 0;
            this.grdFranquicia.FixRows = 0;
            this.grdFranquicia.Frozen = 0;
            this.grdFranquicia.FuenteEncabezado = null;
            this.grdFranquicia.FuentePieDePagina = null;
            this.grdFranquicia.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdFranquicia.LimpiarEstilosAntesDeOrdenar = false;
            this.grdFranquicia.Location = new System.Drawing.Point(0, 0);
            this.grdFranquicia.Name = "grdFranquicia";
            this.grdFranquicia.PieDePagina = "\t\tPage {0} of {1}";
            this.grdFranquicia.PintarFilaSel = true;
            this.grdFranquicia.Redraw = true;
            this.grdFranquicia.Row = 0;
            this.grdFranquicia.Rows = 50;
            this.grdFranquicia.Size = new System.Drawing.Size(290, 599);
            this.grdFranquicia.TabIndex = 0;
            this.grdFranquicia.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdFranquicia_Editado);
            this.grdFranquicia.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdFranquicia_KeyPress);
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
            this.grdSucursales.Col = -2;
            this.grdSucursales.Cols = 0;
            this.grdSucursales.DataMember = "";
            this.grdSucursales.DataSource = null;
            this.grdSucursales.EnableEdicion = false;
            this.grdSucursales.Encabezado = "";
            this.grdSucursales.fColor = System.Drawing.SystemColors.Control;
            this.grdSucursales.FixCols = 0;
            this.grdSucursales.FixRows = 0;
            this.grdSucursales.Frozen = 0;
            this.grdSucursales.FuenteEncabezado = null;
            this.grdSucursales.FuentePieDePagina = null;
            this.grdSucursales.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSucursales.LimpiarEstilosAntesDeOrdenar = false;
            this.grdSucursales.Location = new System.Drawing.Point(3, 3);
            this.grdSucursales.Name = "grdSucursales";
            this.grdSucursales.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSucursales.PintarFilaSel = false;
            this.grdSucursales.Redraw = true;
            this.grdSucursales.Row = 0;
            this.grdSucursales.Rows = 50;
            this.grdSucursales.Size = new System.Drawing.Size(471, 615);
            this.grdSucursales.TabIndex = 0;
            this.grdSucursales.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdSucursales_CambioFila);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.Enabled = false;
            this.cmdBorrar.Location = new System.Drawing.Point(5, 558);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(172, 30);
            this.cmdBorrar.TabIndex = 0;
            this.cmdBorrar.Texto = "Borrar";
            // 
            // cmdGuardarFR
            // 
            this.cmdGuardarFR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardarFR.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGuardarFR.Location = new System.Drawing.Point(5, 522);
            this.cmdGuardarFR.Name = "cmdGuardarFR";
            this.cmdGuardarFR.Size = new System.Drawing.Size(172, 30);
            this.cmdGuardarFR.TabIndex = 0;
            this.cmdGuardarFR.Texto = "Guardar Fr";
            this.cmdGuardarFR.Click += new System.EventHandler(this.cmdGuardarFR_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(5, 594);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(172, 30);
            this.cmdImprimir.TabIndex = 0;
            this.cmdImprimir.Texto = "Imprimir";
            // 
            // cmdPorcentaje
            // 
            this.cmdPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPorcentaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPorcentaje.Location = new System.Drawing.Point(6, 325);
            this.cmdPorcentaje.Name = "cmdPorcentaje";
            this.cmdPorcentaje.Size = new System.Drawing.Size(75, 23);
            this.cmdPorcentaje.TabIndex = 16;
            this.cmdPorcentaje.Text = "Calcular %";
            this.cmdPorcentaje.UseVisualStyleBackColor = true;
            this.cmdPorcentaje.Click += new System.EventHandler(this.cmdPorcentaje_Click);
            // 
            // frmPrecios_GranjaFr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 627);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrecios_GranjaFr";
            this.Text = "Granja Fr";
            this.Load += new System.EventHandler(this.frmPrecios_GranjaFr_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuDecimales)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblPromedio;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblIntegracion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdProductos;
        private Grilla2.SpeedGrilla grdFranquicia;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuDecimales;
        private System.Windows.Forms.ListBox lstFechas;
        private System.Windows.Forms.Panel panel4;
        private MaterialSkin.Controls.MaterialLabel lblSuc;
        private System.Windows.Forms.Label label1;
        private Controles.cBoton cmdBorrar;
        private Controles.cBoton cmdGuardarFR;
        private Controles.cBoton cmdImprimir;
        private System.Windows.Forms.Panel panel3;
        private Grilla2.SpeedGrilla grdSucursales;
        private System.Windows.Forms.Button cmdPorcentaje;
    }
}