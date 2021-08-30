namespace Programa1.Carga.Hacienda
{

    partial class frmGenerarnvaBoleta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerarnvaBoleta));
            this.grdnvaBoleta = new Grilla2.SpeedGrilla();
            this.grdOriginal = new Grilla2.SpeedGrilla();
            this.chCargarPagos = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmbImprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.cbDepositante = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdnvaBoleta
            // 
            this.grdnvaBoleta.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdnvaBoleta.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdnvaBoleta.AutoResize = false;
            this.grdnvaBoleta.bColor = System.Drawing.SystemColors.Window;
            this.grdnvaBoleta.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdnvaBoleta.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdnvaBoleta.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdnvaBoleta.Col = 0;
            this.grdnvaBoleta.Cols = 9;
            this.grdnvaBoleta.DataMember = "";
            this.grdnvaBoleta.DataSource = null;
            this.grdnvaBoleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdnvaBoleta.EnableEdicion = true;
            this.grdnvaBoleta.Encabezado = "";
            this.grdnvaBoleta.fColor = System.Drawing.SystemColors.Control;
            this.grdnvaBoleta.FixCols = 0;
            this.grdnvaBoleta.FixRows = 0;
            this.grdnvaBoleta.FuenteEncabezado = null;
            this.grdnvaBoleta.FuentePieDePagina = null;
            this.grdnvaBoleta.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdnvaBoleta.Location = new System.Drawing.Point(0, 0);
            this.grdnvaBoleta.Name = "grdnvaBoleta";
            this.grdnvaBoleta.PieDePagina = "\t\tPage {0} of {1}";
            this.grdnvaBoleta.PintarFilaSel = true;
            this.grdnvaBoleta.Redraw = true;
            this.grdnvaBoleta.Row = 0;
            this.grdnvaBoleta.Rows = 3;
            this.grdnvaBoleta.Size = new System.Drawing.Size(585, 607);
            this.grdnvaBoleta.TabIndex = 0;
            this.grdnvaBoleta.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdnvaBoleta_Editado);
            // 
            // grdOriginal
            // 
            this.grdOriginal.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdOriginal.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdOriginal.AutoResize = false;
            this.grdOriginal.bColor = System.Drawing.SystemColors.Window;
            this.grdOriginal.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdOriginal.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdOriginal.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdOriginal.Col = 0;
            this.grdOriginal.Cols = 10;
            this.grdOriginal.DataMember = "";
            this.grdOriginal.DataSource = null;
            this.grdOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOriginal.EnableEdicion = true;
            this.grdOriginal.Encabezado = "";
            this.grdOriginal.fColor = System.Drawing.SystemColors.Control;
            this.grdOriginal.FixCols = 0;
            this.grdOriginal.FixRows = 0;
            this.grdOriginal.FuenteEncabezado = null;
            this.grdOriginal.FuentePieDePagina = null;
            this.grdOriginal.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdOriginal.Location = new System.Drawing.Point(0, 0);
            this.grdOriginal.Name = "grdOriginal";
            this.grdOriginal.PieDePagina = "\t\tPage {0} of {1}";
            this.grdOriginal.PintarFilaSel = true;
            this.grdOriginal.Redraw = true;
            this.grdOriginal.Row = 0;
            this.grdOriginal.Rows = 50;
            this.grdOriginal.Size = new System.Drawing.Size(649, 607);
            this.grdOriginal.TabIndex = 1;
            this.grdOriginal.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdOriginal_Editado);
            // 
            // chCargarPagos
            // 
            this.chCargarPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chCargarPagos.AutoSize = true;
            this.chCargarPagos.Depth = 0;
            this.chCargarPagos.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCargarPagos.Location = new System.Drawing.Point(12, 620);
            this.chCargarPagos.Margin = new System.Windows.Forms.Padding(0);
            this.chCargarPagos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCargarPagos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCargarPagos.Name = "chCargarPagos";
            this.chCargarPagos.Ripple = true;
            this.chCargarPagos.Size = new System.Drawing.Size(114, 30);
            this.chCargarPagos.TabIndex = 2;
            this.chCargarPagos.Text = "Cargar Pagos";
            this.chCargarPagos.UseVisualStyleBackColor = true;
            this.chCargarPagos.Visible = false;
            // 
            // cmbImprimir
            // 
            this.cmbImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImprimir.AutoSize = true;
            this.cmbImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmbImprimir.Depth = 0;
            this.cmbImprimir.Location = new System.Drawing.Point(1176, 616);
            this.cmbImprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbImprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmbImprimir.Name = "cmbImprimir";
            this.cmbImprimir.Primary = false;
            this.cmbImprimir.Size = new System.Drawing.Size(74, 36);
            this.cmbImprimir.TabIndex = 3;
            this.cmbImprimir.Text = "Imprimir";
            this.cmbImprimir.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Location = new System.Drawing.Point(12, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdOriginal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdnvaBoleta);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 607);
            this.splitContainer1.SplitterDistance = 649;
            this.splitContainer1.TabIndex = 4;
            // 
            // cbBancos
            // 
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(665, 625);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(158, 21);
            this.cbBancos.TabIndex = 5;
            this.cbBancos.Text = "Seleccionar Banco";
            // 
            // cbDepositante
            // 
            this.cbDepositante.FormattingEnabled = true;
            this.cbDepositante.Location = new System.Drawing.Point(829, 625);
            this.cbDepositante.Name = "cbDepositante";
            this.cbDepositante.Size = new System.Drawing.Size(158, 21);
            this.cbDepositante.TabIndex = 6;
            this.cbDepositante.Text = "Seleccionar Depositante";
            // 
            // frmGenerarnvaBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 654);
            this.Controls.Add(this.cbDepositante);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmbImprimir);
            this.Controls.Add(this.chCargarPagos);
            this.Name = "frmGenerarnvaBoleta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Boleta";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdnvaBoleta;
        private Grilla2.SpeedGrilla grdOriginal;
        private MaterialSkin.Controls.MaterialCheckBox chCargarPagos;
        private MaterialSkin.Controls.MaterialFlatButton cmbImprimir;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.ComboBox cbDepositante;
    }
}