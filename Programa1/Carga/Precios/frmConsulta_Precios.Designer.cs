namespace Programa1.Carga.Precios
{
    partial class frmConsulta_Precios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdLimpiar = new Programa1.Controles.cBoton();
            this.lstTipos = new System.Windows.Forms.ListBox();
            this.lstListas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmdLimpiar);
            this.splitContainer1.Panel2.Controls.Add(this.lstTipos);
            this.splitContainer1.Panel2.Controls.Add(this.lstListas);
            this.splitContainer1.Size = new System.Drawing.Size(1116, 726);
            this.splitContainer1.SplitterDistance = 787;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.grd);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 720);
            this.panel1.TabIndex = 1;
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
            this.grd.Location = new System.Drawing.Point(3, 3);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(775, 714);
            this.grd.TabIndex = 0;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.BackColor = System.Drawing.Color.Gainsboro;
            this.cmdLimpiar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmdLimpiar.Location = new System.Drawing.Point(0, 686);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(325, 40);
            this.cmdLimpiar.TabIndex = 3;
            this.cmdLimpiar.Texto = "Limpiar";
            // 
            // lstTipos
            // 
            this.lstTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstTipos.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstTipos.FormattingEnabled = true;
            this.lstTipos.ItemHeight = 18;
            this.lstTipos.Location = new System.Drawing.Point(3, 3);
            this.lstTipos.Name = "lstTipos";
            this.lstTipos.Size = new System.Drawing.Size(155, 684);
            this.lstTipos.TabIndex = 2;
            this.lstTipos.SelectedIndexChanged += new System.EventHandler(this.lstTipos_SelectedIndexChanged);
            // 
            // lstListas
            // 
            this.lstListas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstListas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstListas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstListas.FormattingEnabled = true;
            this.lstListas.ItemHeight = 18;
            this.lstListas.Location = new System.Drawing.Point(164, 3);
            this.lstListas.Name = "lstListas";
            this.lstListas.Size = new System.Drawing.Size(154, 684);
            this.lstListas.TabIndex = 2;
            // 
            // frmConsulta_Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 750);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmConsulta_Precios";
            this.Text = "Consulta_Precios";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private Grilla2.SpeedGrilla grd;
        private Controles.cBoton cmdLimpiar;
        private System.Windows.Forms.ListBox lstTipos;
        private System.Windows.Forms.ListBox lstListas;
    }
}