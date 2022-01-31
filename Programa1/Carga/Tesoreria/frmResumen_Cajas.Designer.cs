namespace Programa1.Carga.Tesoreria
{
    partial class frmResumen_Cajas
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.lstCajas = new System.Windows.Forms.ListBox();
            this.cFechas1 = new Programa1.Controles.cFechas();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chEDetalle = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSDetalle = new MaterialSkin.Controls.MaterialCheckBox();
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Location = new System.Drawing.Point(12, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstCajas);
            this.splitContainer1.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer1.Panel2.Controls.Add(this.materialLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(1561, 703);
            this.splitContainer1.SplitterDistance = 1039;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Location = new System.Drawing.Point(3, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chEDetalle);
            this.splitContainer2.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chSDetalle);
            this.splitContainer2.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer2.Size = new System.Drawing.Size(1033, 662);
            this.splitContainer2.SplitterDistance = 593;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
            // 
            // grdEntradas
            // 
            this.grdEntradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEntradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntradas.AutoResize = false;
            this.grdEntradas.bColor = System.Drawing.SystemColors.Window;
            this.grdEntradas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEntradas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEntradas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEntradas.Col = 0;
            this.grdEntradas.Cols = 10;
            this.grdEntradas.DataMember = "";
            this.grdEntradas.DataSource = null;
            this.grdEntradas.EnableEdicion = false;
            this.grdEntradas.Encabezado = "";
            this.grdEntradas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntradas.FixCols = 0;
            this.grdEntradas.FixRows = 0;
            this.grdEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.Location = new System.Drawing.Point(0, 3);
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 1;
            this.grdEntradas.Size = new System.Drawing.Size(590, 626);
            this.grdEntradas.TabIndex = 0;
            // 
            // grdSalidas
            // 
            this.grdSalidas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSalidas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSalidas.AutoResize = false;
            this.grdSalidas.bColor = System.Drawing.SystemColors.Window;
            this.grdSalidas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSalidas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSalidas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSalidas.Col = 0;
            this.grdSalidas.Cols = 10;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = false;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.Location = new System.Drawing.Point(3, 3);
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 1;
            this.grdSalidas.Size = new System.Drawing.Size(426, 626);
            this.grdSalidas.TabIndex = 1;
            // 
            // lstCajas
            // 
            this.lstCajas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCajas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstCajas.FormattingEnabled = true;
            this.lstCajas.ItemHeight = 18;
            this.lstCajas.Location = new System.Drawing.Point(303, 24);
            this.lstCajas.Name = "lstCajas";
            this.lstCajas.Size = new System.Drawing.Size(200, 648);
            this.lstCajas.TabIndex = 5;
            this.lstCajas.SelectedIndexChanged += new System.EventHandler(this.lstCajas_SelectedIndexChanged);
            // 
            // cFechas1
            // 
            this.cFechas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(3, 3);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(294, 697);
            this.cFechas1.TabIndex = 1;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(303, 3);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(39, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Caja";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 676);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(51, 24);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total";
            // 
            // chEDetalle
            // 
            this.chEDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chEDetalle.AutoSize = true;
            this.chEDetalle.Depth = 0;
            this.chEDetalle.Font = new System.Drawing.Font("Roboto", 10F);
            this.chEDetalle.Location = new System.Drawing.Point(0, 632);
            this.chEDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.chEDetalle.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chEDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.chEDetalle.Name = "chEDetalle";
            this.chEDetalle.Ripple = true;
            this.chEDetalle.Size = new System.Drawing.Size(73, 30);
            this.chEDetalle.TabIndex = 1;
            this.chEDetalle.Text = "Detalle";
            this.chEDetalle.UseVisualStyleBackColor = true;
            this.chEDetalle.CheckedChanged += new System.EventHandler(this.chEDetalle_CheckedChanged);
            // 
            // chSDetalle
            // 
            this.chSDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chSDetalle.AutoSize = true;
            this.chSDetalle.Depth = 0;
            this.chSDetalle.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSDetalle.Location = new System.Drawing.Point(3, 632);
            this.chSDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.chSDetalle.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSDetalle.Name = "chSDetalle";
            this.chSDetalle.Ripple = true;
            this.chSDetalle.Size = new System.Drawing.Size(73, 30);
            this.chSDetalle.TabIndex = 1;
            this.chSDetalle.Text = "Detalle";
            this.chSDetalle.UseVisualStyleBackColor = true;
            this.chSDetalle.CheckedChanged += new System.EventHandler(this.chSDetalle_CheckedChanged);
            // 
            // frmResumen_Cajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 724);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResumen_Cajas";
            this.Text = "Resumen_Cajas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
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
        private Grilla2.SpeedGrilla grdEntradas;
        private System.Windows.Forms.ListBox lstCajas;
        private Controles.cFechas cFechas1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdSalidas;
        private System.Windows.Forms.Label lblTotal;
        private MaterialSkin.Controls.MaterialCheckBox chEDetalle;
        private MaterialSkin.Controls.MaterialCheckBox chSDetalle;
    }
}