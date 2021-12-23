namespace Programa1.Carga.Hacienda
{

    partial class frmGenerarNuevaBoleta
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
            this.cmbImprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdOriginal = new Grilla2.SpeedGrilla();
            this.grdnvaBoleta = new Grilla2.SpeedGrilla();
            this.cmdGuardar = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.lblDif = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbImprimir
            // 
            this.cmbImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImprimir.AutoSize = true;
            this.cmbImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmbImprimir.Depth = 0;
            this.cmbImprimir.Location = new System.Drawing.Point(1445, 638);
            this.cmbImprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbImprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmbImprimir.Name = "cmbImprimir";
            this.cmbImprimir.Primary = false;
            this.cmbImprimir.Size = new System.Drawing.Size(74, 36);
            this.cmbImprimir.TabIndex = 3;
            this.cmbImprimir.Text = "Imprimir";
            this.cmbImprimir.UseVisualStyleBackColor = true;
            this.cmbImprimir.Click += new System.EventHandler(this.cmbImprimir_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1507, 629);
            this.splitContainer1.SplitterDistance = 953;
            this.splitContainer1.TabIndex = 4;
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
            this.grdOriginal.Size = new System.Drawing.Size(953, 629);
            this.grdOriginal.TabIndex = 1;
            this.grdOriginal.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdOriginal_Editado);
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
            this.grdnvaBoleta.Size = new System.Drawing.Size(550, 629);
            this.grdnvaBoleta.TabIndex = 0;
            this.grdnvaBoleta.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdnvaBoleta_Editado);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.AutoSize = true;
            this.cmdGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdGuardar.Depth = 0;
            this.cmdGuardar.Location = new System.Drawing.Point(1285, 638);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Primary = false;
            this.cmdGuardar.Size = new System.Drawing.Size(60, 36);
            this.cmdGuardar.TabIndex = 5;
            this.cmdGuardar.Text = "Enviar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 647);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Presupuesto:";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPresupuesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresupuesto.Location = new System.Drawing.Point(117, 647);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(142, 19);
            this.txtPresupuesto.TabIndex = 7;
            this.txtPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPresupuesto.TextChanged += new System.EventHandler(this.txtPresupuesto_TextChanged);
            this.txtPresupuesto.Leave += new System.EventHandler(this.txtPresupuesto_Leave);
            // 
            // lblDif
            // 
            this.lblDif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDif.AutoSize = true;
            this.lblDif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDif.Location = new System.Drawing.Point(356, 647);
            this.lblDif.Name = "lblDif";
            this.lblDif.Size = new System.Drawing.Size(14, 20);
            this.lblDif.TabIndex = 8;
            this.lblDif.Text = "-";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 647);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Diferencia:";
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(1352, 647);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(86, 20);
            this.dtFecha.TabIndex = 10;
            // 
            // frmGenerarNuevaBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 676);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDif);
            this.Controls.Add(this.txtPresupuesto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmbImprimir);
            this.Name = "frmGenerarNuevaBoleta";
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
        private MaterialSkin.Controls.MaterialFlatButton cmbImprimir;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialFlatButton cmdGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Label lblDif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
    }
}