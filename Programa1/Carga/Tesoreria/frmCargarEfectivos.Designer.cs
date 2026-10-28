namespace Programa1.Carga.Tesoreria
{
    partial class frmCargarEfectivos
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grdEfectivos = new Grilla2.SpeedGrilla();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grdAgrpado = new Grilla2.SpeedGrilla();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(669, 773);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(750, 773);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grdEfectivos
            // 
            this.grdEfectivos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEfectivos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEfectivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEfectivos.AutoResize = false;
            this.grdEfectivos.bColor = System.Drawing.SystemColors.Window;
            this.grdEfectivos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEfectivos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEfectivos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEfectivos.Col = 0;
            this.grdEfectivos.Cols = 10;
            this.grdEfectivos.DataMember = "";
            this.grdEfectivos.DataSource = null;
            this.grdEfectivos.EnableEdicion = true;
            this.grdEfectivos.Encabezado = "";
            this.grdEfectivos.fColor = System.Drawing.Color.Silver;
            this.grdEfectivos.FixCols = 0;
            this.grdEfectivos.FixRows = 0;
            this.grdEfectivos.Frozen = 0;
            this.grdEfectivos.FuenteEncabezado = null;
            this.grdEfectivos.FuentePieDePagina = null;
            this.grdEfectivos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEfectivos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdEfectivos.Location = new System.Drawing.Point(12, 12);
            this.grdEfectivos.Name = "grdEfectivos";
            this.grdEfectivos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEfectivos.PintarFilaSel = true;
            this.grdEfectivos.Redraw = true;
            this.grdEfectivos.Row = 0;
            this.grdEfectivos.Rows = 50;
            this.grdEfectivos.Size = new System.Drawing.Size(483, 755);
            this.grdEfectivos.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 780);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(38, 16);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            // 
            // grdAgrpado
            // 
            this.grdAgrpado.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAgrpado.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAgrpado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAgrpado.AutoResize = false;
            this.grdAgrpado.bColor = System.Drawing.SystemColors.Window;
            this.grdAgrpado.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAgrpado.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAgrpado.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAgrpado.Col = 0;
            this.grdAgrpado.Cols = 10;
            this.grdAgrpado.DataMember = "";
            this.grdAgrpado.DataSource = null;
            this.grdAgrpado.EnableEdicion = true;
            this.grdAgrpado.Encabezado = "";
            this.grdAgrpado.fColor = System.Drawing.Color.Silver;
            this.grdAgrpado.FixCols = 0;
            this.grdAgrpado.FixRows = 0;
            this.grdAgrpado.Frozen = 0;
            this.grdAgrpado.FuenteEncabezado = null;
            this.grdAgrpado.FuentePieDePagina = null;
            this.grdAgrpado.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAgrpado.LimpiarEstilosAntesDeOrdenar = false;
            this.grdAgrpado.Location = new System.Drawing.Point(501, 12);
            this.grdAgrpado.Name = "grdAgrpado";
            this.grdAgrpado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAgrpado.PintarFilaSel = true;
            this.grdAgrpado.Redraw = true;
            this.grdAgrpado.Row = 0;
            this.grdAgrpado.Rows = 50;
            this.grdAgrpado.Size = new System.Drawing.Size(323, 754);
            this.grdAgrpado.TabIndex = 4;
            // 
            // frmCargarEfectivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 808);
            this.Controls.Add(this.grdAgrpado);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.grdEfectivos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCargarEfectivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Efectivos";
            this.Load += new System.EventHandler(this.frmCargarEfectivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Grilla2.SpeedGrilla grdEfectivos;
        private System.Windows.Forms.Label lblTotal;
        private Grilla2.SpeedGrilla grdAgrpado;
    }
}