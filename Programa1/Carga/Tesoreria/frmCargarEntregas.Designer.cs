namespace Programa1.Carga.Tesoreria
{
    partial class frmCargarEntregas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargarEntregas));
            this.lblSuc = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.cmdCerrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdEntregas = new Grilla2.SpeedGrilla();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSuc
            // 
            this.lblSuc.AutoSize = true;
            this.lblSuc.Depth = 0;
            this.lblSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSuc.Location = new System.Drawing.Point(12, 9);
            this.lblSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(48, 18);
            this.lblSuc.TabIndex = 0;
            this.lblSuc.Text = "lblSuc";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(12, 239);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 18);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total";
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.AutoSize = true;
            this.cmdCerrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCerrar.Depth = 0;
            this.cmdCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCerrar.Location = new System.Drawing.Point(0, 0);
            this.cmdCerrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCerrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Primary = false;
            this.cmdCerrar.Size = new System.Drawing.Size(109, 39);
            this.cmdCerrar.TabIndex = 3;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdCerrar);
            this.panel1.Location = new System.Drawing.Point(173, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 39);
            this.panel1.TabIndex = 4;
            // 
            // grdEntregas
            // 
            this.grdEntregas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEntregas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEntregas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntregas.AutoResize = false;
            this.grdEntregas.bColor = System.Drawing.SystemColors.Window;
            this.grdEntregas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEntregas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEntregas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEntregas.Col = 0;
            this.grdEntregas.Cols = 10;
            this.grdEntregas.DataMember = "";
            this.grdEntregas.DataSource = null;
            this.grdEntregas.EnableEdicion = true;
            this.grdEntregas.Encabezado = "";
            this.grdEntregas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntregas.FixCols = 0;
            this.grdEntregas.FixRows = 0;
            this.grdEntregas.FuenteEncabezado = null;
            this.grdEntregas.FuentePieDePagina = null;
            this.grdEntregas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntregas.Location = new System.Drawing.Point(16, 31);
            this.grdEntregas.MenuActivado = false;
            this.grdEntregas.Name = "grdEntregas";
            this.grdEntregas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntregas.PintarFilaSel = true;
            this.grdEntregas.Redraw = true;
            this.grdEntregas.Row = 0;
            this.grdEntregas.Rows = 50;
            this.grdEntregas.Size = new System.Drawing.Size(266, 193);
            this.grdEntregas.TabIndex = 1;
            this.grdEntregas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdEntregas_Editado);
            this.grdEntregas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdEntregas_CambioFila);
            this.grdEntregas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdEntregas_KeyUp);
            // 
            // frmCargarEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 277);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.grdEntregas);
            this.Controls.Add(this.lblSuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCargarEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entregas";
            this.Load += new System.EventHandler(this.frmCargarEntregas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MaterialSkin.Controls.MaterialLabel lblSuc;
        public Grilla2.SpeedGrilla grdEntregas;
        public MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialFlatButton cmdCerrar;
        private System.Windows.Forms.Panel panel1;
    }
}