namespace Programa1.Carga.Hacienda
{
    partial class frmVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVencimientos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.grdAgr = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdActualizar = new Programa1.Controles.cBoton();
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
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.cmdActualizar);
            this.splitContainer1.Size = new System.Drawing.Size(1456, 780);
            this.splitContainer1.SplitterDistance = 730;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.grd);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.grdAgr);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1456, 730);
            this.splitContainer2.SplitterDistance = 815;
            this.splitContainer2.TabIndex = 1;
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
            this.grd.EnableEdicion = false;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(3, 31);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = false;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(809, 696);
            this.grd.TabIndex = 3;
            this.grd.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(-1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compras P1";
            // 
            // grdAgr
            // 
            this.grdAgr.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAgr.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAgr.AutoResize = false;
            this.grdAgr.bColor = System.Drawing.SystemColors.Window;
            this.grdAgr.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAgr.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAgr.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAgr.Col = 0;
            this.grdAgr.Cols = 10;
            this.grdAgr.DataMember = "";
            this.grdAgr.DataSource = null;
            this.grdAgr.EnableEdicion = false;
            this.grdAgr.Encabezado = "";
            this.grdAgr.fColor = System.Drawing.SystemColors.Control;
            this.grdAgr.FixCols = 0;
            this.grdAgr.FixRows = 0;
            this.grdAgr.FuenteEncabezado = null;
            this.grdAgr.FuentePieDePagina = null;
            this.grdAgr.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAgr.Location = new System.Drawing.Point(3, 31);
            this.grdAgr.Name = "grdAgr";
            this.grdAgr.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAgr.PintarFilaSel = false;
            this.grdAgr.Redraw = true;
            this.grdAgr.Row = 0;
            this.grdAgr.Rows = 50;
            this.grdAgr.Size = new System.Drawing.Size(631, 696);
            this.grdAgr.TabIndex = 5;
            this.grdAgr.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdAgr_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(-1, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Compras P2";
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdActualizar.Location = new System.Drawing.Point(1301, 7);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(143, 27);
            this.cmdActualizar.TabIndex = 0;
            this.cmdActualizar.Texto = "Actualizar";
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // frmVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 780);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmVencimientos";
            this.Text = "Vencimientos";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Label label1;
        private Controles.cBoton cmdActualizar;
        private Grilla2.SpeedGrilla grdAgr;
        private System.Windows.Forms.Label label2;
    }
}