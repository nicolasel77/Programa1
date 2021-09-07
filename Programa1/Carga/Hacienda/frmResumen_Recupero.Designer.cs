namespace Programa1.Carga.Hacienda
{

    partial class frmResumen_Recupero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumen_Recupero));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.lstFrigorificos = new System.Windows.Forms.ListBox();
            this.nuCant = new System.Windows.Forms.NumericUpDown();
            this.grd = new Grilla2.SpeedGrilla();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nuCant);
            this.splitContainer1.Panel2.Controls.Add(this.lstFechas);
            this.splitContainer1.Panel2.Controls.Add(this.lstFrigorificos);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 801);
            this.splitContainer1.SplitterDistance = 725;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstFechas
            // 
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(229, 12);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(111, 280);
            this.lstFechas.TabIndex = 1;
            // 
            // lstFrigorificos
            // 
            this.lstFrigorificos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFrigorificos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFrigorificos.FormattingEnabled = true;
            this.lstFrigorificos.ItemHeight = 20;
            this.lstFrigorificos.Location = new System.Drawing.Point(14, 12);
            this.lstFrigorificos.Name = "lstFrigorificos";
            this.lstFrigorificos.Size = new System.Drawing.Size(209, 280);
            this.lstFrigorificos.TabIndex = 2;
            this.lstFrigorificos.SelectedIndexChanged += new System.EventHandler(this.lstFrigorificos_SelectedIndexChanged);
            // 
            // nuCant
            // 
            this.nuCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuCant.Location = new System.Drawing.Point(14, 298);
            this.nuCant.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuCant.Name = "nuCant";
            this.nuCant.Size = new System.Drawing.Size(85, 31);
            this.nuCant.TabIndex = 3;
            this.nuCant.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
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
            this.grd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = -2;
            this.grd.Rows = 0;
            this.grd.Size = new System.Drawing.Size(701, 777);
            this.grd.TabIndex = 0;
            // 
            // frmResumen_Recupero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 801);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResumen_Recupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen Recupero";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstFechas;
        private System.Windows.Forms.ListBox lstFrigorificos;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.NumericUpDown nuCant;
    }
}