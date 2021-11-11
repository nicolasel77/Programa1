namespace Programa1.Carga.Tesoreria
{
    partial class frmPrestamos
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
            this.grdEntrada = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdPagos = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.cFecha = new Programa1.Controles.cFechas();
            this.lblDiferencia = new System.Windows.Forms.Label();
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
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdEntrada);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1596, 779);
            this.splitContainer1.SplitterDistance = 798;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdEntrada
            // 
            this.grdEntrada.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEntrada.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntrada.AutoResize = false;
            this.grdEntrada.bColor = System.Drawing.SystemColors.Window;
            this.grdEntrada.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEntrada.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEntrada.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEntrada.Col = 0;
            this.grdEntrada.Cols = 10;
            this.grdEntrada.DataMember = "";
            this.grdEntrada.DataSource = null;
            this.grdEntrada.EnableEdicion = true;
            this.grdEntrada.Encabezado = "";
            this.grdEntrada.fColor = System.Drawing.Color.Silver;
            this.grdEntrada.FixCols = 0;
            this.grdEntrada.FixRows = 0;
            this.grdEntrada.FuenteEncabezado = null;
            this.grdEntrada.FuentePieDePagina = null;
            this.grdEntrada.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntrada.Location = new System.Drawing.Point(12, 21);
            this.grdEntrada.Name = "grdEntrada";
            this.grdEntrada.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntrada.PintarFilaSel = true;
            this.grdEntrada.Redraw = true;
            this.grdEntrada.Row = 0;
            this.grdEntrada.Rows = 50;
            this.grdEntrada.Size = new System.Drawing.Size(783, 737);
            this.grdEntrada.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(798, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entradas";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grdPagos);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblDiferencia);
            this.splitContainer2.Panel2.Controls.Add(this.cFecha);
            this.splitContainer2.Size = new System.Drawing.Size(790, 779);
            this.splitContainer2.SplitterDistance = 491;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // grdPagos
            // 
            this.grdPagos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdPagos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPagos.AutoResize = false;
            this.grdPagos.bColor = System.Drawing.SystemColors.Window;
            this.grdPagos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdPagos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdPagos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdPagos.Col = 0;
            this.grdPagos.Cols = 10;
            this.grdPagos.DataMember = "";
            this.grdPagos.DataSource = null;
            this.grdPagos.EnableEdicion = true;
            this.grdPagos.Encabezado = "";
            this.grdPagos.fColor = System.Drawing.Color.Silver;
            this.grdPagos.FixCols = 0;
            this.grdPagos.FixRows = 0;
            this.grdPagos.FuenteEncabezado = null;
            this.grdPagos.FuentePieDePagina = null;
            this.grdPagos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdPagos.Location = new System.Drawing.Point(3, 21);
            this.grdPagos.Name = "grdPagos";
            this.grdPagos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdPagos.PintarFilaSel = true;
            this.grdPagos.Redraw = true;
            this.grdPagos.Row = 0;
            this.grdPagos.Rows = 50;
            this.grdPagos.Size = new System.Drawing.Size(485, 737);
            this.grdPagos.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pagos";
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 3;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(288, 738);
            this.cFecha.TabIndex = 0;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDiferencia.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblDiferencia.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblDiferencia.Location = new System.Drawing.Point(3, 752);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(375, 18);
            this.lblDiferencia.TabIndex = 3;
            this.lblDiferencia.Text = "Diferencia:";
            // 
            // frmPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 779);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPrestamos";
            this.Text = "Pestamos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
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
        private Controles.cFechas cFecha;
        private Grilla2.SpeedGrilla grdEntrada;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdPagos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDiferencia;
    }
}