namespace Programa1.Carga.Precios
{
    partial class frmPromedios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromedios));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.grdPromedios = new Grilla2.SpeedGrilla();
            this.lstPromedios = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cSucs = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.grdPromedios);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.cSucs);
            this.splitContainer1.Panel2.Controls.Add(this.lstFechas);
            this.splitContainer1.Panel2.Controls.Add(this.lstPromedios);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel3);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel2);
            this.splitContainer1.Size = new System.Drawing.Size(1437, 707);
            this.splitContainer1.SplitterDistance = 644;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 5);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(53, 18);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Detalle";
            // 
            // grdPromedios
            // 
            this.grdPromedios.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdPromedios.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdPromedios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPromedios.AutoResize = false;
            this.grdPromedios.bColor = System.Drawing.SystemColors.Window;
            this.grdPromedios.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdPromedios.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdPromedios.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdPromedios.Col = 2;
            this.grdPromedios.Cols = 11;
            this.grdPromedios.DataMember = "";
            this.grdPromedios.DataSource = null;
            this.grdPromedios.EnableEdicion = true;
            this.grdPromedios.Encabezado = "";
            this.grdPromedios.fColor = System.Drawing.SystemColors.Control;
            this.grdPromedios.FixCols = 2;
            this.grdPromedios.FixRows = 1;
            this.grdPromedios.FuenteEncabezado = null;
            this.grdPromedios.FuentePieDePagina = null;
            this.grdPromedios.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdPromedios.Location = new System.Drawing.Point(6, 33);
            this.grdPromedios.MenuActivado = false;
            this.grdPromedios.Name = "grdPromedios";
            this.grdPromedios.PieDePagina = "\t\tPage {0} of {1}";
            this.grdPromedios.PintarFilaSel = true;
            this.grdPromedios.Redraw = true;
            this.grdPromedios.Row = 1;
            this.grdPromedios.Rows = 11;
            this.grdPromedios.Size = new System.Drawing.Size(635, 668);
            this.grdPromedios.TabIndex = 0;
            // 
            // lstPromedios
            // 
            this.lstPromedios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPromedios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPromedios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPromedios.FormattingEnabled = true;
            this.lstPromedios.ItemHeight = 20;
            this.lstPromedios.Location = new System.Drawing.Point(7, 31);
            this.lstPromedios.Name = "lstPromedios";
            this.lstPromedios.Size = new System.Drawing.Size(251, 660);
            this.lstPromedios.TabIndex = 2;
            this.lstPromedios.SelectedIndexChanged += new System.EventHandler(this.lstPromedios_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(3, 5);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(53, 18);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Detalle";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 27);
            this.panel1.TabIndex = 2;
            // 
            // lstFechas
            // 
            this.lstFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(264, 31);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(125, 660);
            this.lstFechas.TabIndex = 2;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(261, 5);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(57, 18);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Fechas";
            // 
            // cSucs
            // 
            this.cSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(395, 3);
            this.cSucs.Mostrar_Botones = false;
            this.cSucs.Mostrar_Tipo = true;
            this.cSucs.Name = "cSucs";
            this.cSucs.selectionMode = System.Windows.Forms.SelectionMode.One;
            this.cSucs.Size = new System.Drawing.Size(378, 701);
            this.cSucs.TabIndex = 3;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            // 
            // frmPromedios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 707);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPromedios";
            this.Text = "Promedios";
            this.Load += new System.EventHandler(this.frmPromedios_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdPromedios;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Controles.cSucursales cSucs;
        private System.Windows.Forms.ListBox lstPromedios;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstFechas;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}