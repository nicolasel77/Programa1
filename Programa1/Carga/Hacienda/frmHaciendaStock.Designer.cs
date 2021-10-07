namespace Programa1.Carga.Hacienda
{
    partial class frmHaciendaStock
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
            this.grdCategorias = new Grilla2.SpeedGrilla();
            this.grdTipo = new Grilla2.SpeedGrilla();
            this.grdStock = new Grilla2.SpeedGrilla();
            this.grdDetalle = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmdMostrar = new Programa1.Controles.cBoton();
            this.calFecha = new System.Windows.Forms.MonthCalendar();
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
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grdCategorias);
            this.splitContainer1.Panel1.Controls.Add(this.grdTipo);
            this.splitContainer1.Panel1.Controls.Add(this.grdStock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(1147, 651);
            this.splitContainer1.SplitterDistance = 425;
            this.splitContainer1.TabIndex = 2;
            // 
            // grdCategorias
            // 
            this.grdCategorias.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCategorias.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCategorias.AutoResize = false;
            this.grdCategorias.bColor = System.Drawing.SystemColors.Window;
            this.grdCategorias.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCategorias.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCategorias.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCategorias.Col = 0;
            this.grdCategorias.Cols = 10;
            this.grdCategorias.DataMember = "";
            this.grdCategorias.DataSource = null;
            this.grdCategorias.EnableEdicion = true;
            this.grdCategorias.Encabezado = "";
            this.grdCategorias.fColor = System.Drawing.SystemColors.Control;
            this.grdCategorias.FixCols = 0;
            this.grdCategorias.FixRows = 0;
            this.grdCategorias.FuenteEncabezado = null;
            this.grdCategorias.FuentePieDePagina = null;
            this.grdCategorias.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCategorias.Location = new System.Drawing.Point(918, 0);
            this.grdCategorias.Name = "grdCategorias";
            this.grdCategorias.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCategorias.PintarFilaSel = true;
            this.grdCategorias.Redraw = true;
            this.grdCategorias.Row = 0;
            this.grdCategorias.Rows = 50;
            this.grdCategorias.Size = new System.Drawing.Size(224, 425);
            this.grdCategorias.TabIndex = 1;
            // 
            // grdTipo
            // 
            this.grdTipo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTipo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTipo.AutoResize = false;
            this.grdTipo.bColor = System.Drawing.SystemColors.Window;
            this.grdTipo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTipo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTipo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTipo.Col = 0;
            this.grdTipo.Cols = 10;
            this.grdTipo.DataMember = "";
            this.grdTipo.DataSource = null;
            this.grdTipo.EnableEdicion = true;
            this.grdTipo.Encabezado = "";
            this.grdTipo.fColor = System.Drawing.SystemColors.Control;
            this.grdTipo.FixCols = 0;
            this.grdTipo.FixRows = 0;
            this.grdTipo.FuenteEncabezado = null;
            this.grdTipo.FuentePieDePagina = null;
            this.grdTipo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipo.Location = new System.Drawing.Point(625, 0);
            this.grdTipo.Name = "grdTipo";
            this.grdTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipo.PintarFilaSel = true;
            this.grdTipo.Redraw = true;
            this.grdTipo.Row = 0;
            this.grdTipo.Rows = 50;
            this.grdTipo.Size = new System.Drawing.Size(287, 425);
            this.grdTipo.TabIndex = 1;
            // 
            // grdStock
            // 
            this.grdStock.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdStock.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStock.AutoResize = false;
            this.grdStock.bColor = System.Drawing.SystemColors.Window;
            this.grdStock.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdStock.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdStock.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdStock.Col = 0;
            this.grdStock.Cols = 10;
            this.grdStock.DataMember = "";
            this.grdStock.DataSource = null;
            this.grdStock.EnableEdicion = true;
            this.grdStock.Encabezado = "";
            this.grdStock.fColor = System.Drawing.SystemColors.Control;
            this.grdStock.FixCols = 0;
            this.grdStock.FixRows = 0;
            this.grdStock.FuenteEncabezado = null;
            this.grdStock.FuentePieDePagina = null;
            this.grdStock.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdStock.Location = new System.Drawing.Point(3, 0);
            this.grdStock.Name = "grdStock";
            this.grdStock.PieDePagina = "\t\tPage {0} of {1}";
            this.grdStock.PintarFilaSel = true;
            this.grdStock.Redraw = true;
            this.grdStock.Row = 0;
            this.grdStock.Rows = 50;
            this.grdStock.Size = new System.Drawing.Size(616, 425);
            this.grdStock.TabIndex = 0;
            this.grdStock.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdStock_CambioFila);
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalle.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalle.AutoResize = false;
            this.grdDetalle.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalle.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalle.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalle.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalle.Col = 0;
            this.grdDetalle.Cols = 10;
            this.grdDetalle.DataMember = "";
            this.grdDetalle.DataSource = null;
            this.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetalle.EnableEdicion = true;
            this.grdDetalle.Encabezado = "";
            this.grdDetalle.fColor = System.Drawing.SystemColors.Control;
            this.grdDetalle.FixCols = 0;
            this.grdDetalle.FixRows = 1;
            this.grdDetalle.FuenteEncabezado = null;
            this.grdDetalle.FuentePieDePagina = null;
            this.grdDetalle.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalle.Location = new System.Drawing.Point(0, 0);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = true;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 1;
            this.grdDetalle.Rows = 2;
            this.grdDetalle.Size = new System.Drawing.Size(1147, 222);
            this.grdDetalle.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Location = new System.Drawing.Point(12, 12);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.cmdMostrar);
            this.splitContainer2.Panel2.Controls.Add(this.calFecha);
            this.splitContainer2.Size = new System.Drawing.Size(1468, 651);
            this.splitContainer2.SplitterDistance = 1147;
            this.splitContainer2.TabIndex = 3;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Location = new System.Drawing.Point(3, 174);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(192, 38);
            this.cmdMostrar.TabIndex = 3;
            this.cmdMostrar.Texto = "Mostrar Actual";
            this.cmdMostrar.Click += new System.EventHandler(this.cmdMostrar_Click);
            // 
            // calFecha
            // 
            this.calFecha.Location = new System.Drawing.Point(3, 0);
            this.calFecha.Name = "calFecha";
            this.calFecha.TabIndex = 2;
            this.calFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CalFecha_DateSelected);
            // 
            // frmHaciendaStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 675);
            this.Controls.Add(this.splitContainer2);
            this.Name = "frmHaciendaStock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.FrmHaciendaStock_Load);
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

        private Grilla2.SpeedGrilla grdStock;
        private Grilla2.SpeedGrilla grdDetalle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MonthCalendar calFecha;
        private Grilla2.SpeedGrilla grdTipo;
        private Grilla2.SpeedGrilla grdCategorias;
        private Controles.cBoton cmdMostrar;
    }
}