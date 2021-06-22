
namespace Programa1.Carga.Sucursales
{
    partial class frmPrecios_Stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecios_Stock));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.grdResumen = new Grilla2.SpeedGrilla();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmdCopiar = new Programa1.Controles.cBoton();
            this.label1 = new System.Windows.Forms.Label();
            this.cProds = new Programa1.Controles.cProductos();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cProds);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtDesc);
            this.splitContainer1.Panel2.Controls.Add(this.cmdCopiar);
            this.splitContainer1.Panel2.Controls.Add(this.lstSemanas);
            this.splitContainer1.Size = new System.Drawing.Size(1179, 672);
            this.splitContainer1.SplitterDistance = 933;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.grd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.grdResumen);
            this.splitContainer2.Size = new System.Drawing.Size(933, 672);
            this.splitContainer2.SplitterDistance = 654;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoResize = false;
            this.grd.bColor = System.Drawing.SystemColors.Window;
            this.grd.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grd.bFColor = System.Drawing.SystemColors.WindowText;
            this.grd.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grd.Col = 0;
            this.grd.Cols = 10;
            this.grd.DataMember = "";
            this.grd.DataSource = null;
            this.grd.EnableEdicion = true;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.MenuActivado = false;
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(626, 648);
            this.grd.TabIndex = 0;
            // 
            // grdResumen
            // 
            this.grdResumen.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResumen.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResumen.AutoResize = false;
            this.grdResumen.bColor = System.Drawing.SystemColors.Window;
            this.grdResumen.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResumen.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResumen.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResumen.Col = 0;
            this.grdResumen.Cols = 10;
            this.grdResumen.DataMember = "";
            this.grdResumen.DataSource = null;
            this.grdResumen.EnableEdicion = true;
            this.grdResumen.Encabezado = "";
            this.grdResumen.fColor = System.Drawing.SystemColors.Control;
            this.grdResumen.FixCols = 0;
            this.grdResumen.FixRows = 0;
            this.grdResumen.FuenteEncabezado = null;
            this.grdResumen.FuentePieDePagina = null;
            this.grdResumen.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResumen.Location = new System.Drawing.Point(15, 12);
            this.grdResumen.MenuActivado = false;
            this.grdResumen.Name = "grdResumen";
            this.grdResumen.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResumen.PintarFilaSel = true;
            this.grdResumen.Redraw = true;
            this.grdResumen.Row = 0;
            this.grdResumen.Rows = 50;
            this.grdResumen.Size = new System.Drawing.Size(235, 648);
            this.grdResumen.TabIndex = 0;
            // 
            // lstSemanas
            // 
            this.lstSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSemanas.FormattingEnabled = true;
            this.lstSemanas.ItemHeight = 20;
            this.lstSemanas.Items.AddRange(new object[] {
            "20/12/1977"});
            this.lstSemanas.Location = new System.Drawing.Point(13, 12);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.Size = new System.Drawing.Size(213, 220);
            this.lstSemanas.TabIndex = 1;
            this.lstSemanas.SelectedIndexChanged += new System.EventHandler(this.lstSemanas_SelectedIndexChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesc.Location = new System.Drawing.Point(13, 601);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(213, 13);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.Text = "Reintegro por cambio de precios.";
            // 
            // cmdCopiar
            // 
            this.cmdCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCopiar.Location = new System.Drawing.Point(13, 620);
            this.cmdCopiar.Name = "cmdCopiar";
            this.cmdCopiar.Size = new System.Drawing.Size(205, 40);
            this.cmdCopiar.TabIndex = 1;
            this.cmdCopiar.Texto = "Copiar";
            this.cmdCopiar.Click += new System.EventHandler(this.cmdCopiar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descripción:";
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(13, 238);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(213, 335);
            this.cProds.TabIndex = 4;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.cProds_Cambio_Seleccion);
            // 
            // frmPrecios_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 672);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrecios_Stock";
            this.Text = "Precios Stock";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grd;
        private Grilla2.SpeedGrilla grdResumen;
        private System.Windows.Forms.ListBox lstSemanas;
        private Controles.cBoton cmdCopiar;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private Controles.cProductos cProds;
    }
}