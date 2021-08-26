namespace Programa1.Carga.Empleados
{
    partial class frmRetiros_Aguinaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros_Aguinaldo));
            this.grdDetalle = new Grilla2.SpeedGrilla();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.grdRetiros = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAlta = new System.Windows.Forms.Label();
            this.lblAguinaldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalle.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetalle.AutoResize = false;
            this.grdDetalle.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalle.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalle.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalle.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalle.Col = 0;
            this.grdDetalle.Cols = 10;
            this.grdDetalle.DataMember = "";
            this.grdDetalle.DataSource = null;
            this.grdDetalle.EnableEdicion = true;
            this.grdDetalle.Encabezado = "";
            this.grdDetalle.fColor = System.Drawing.SystemColors.Control;
            this.grdDetalle.FixCols = 0;
            this.grdDetalle.FixRows = 0;
            this.grdDetalle.FuenteEncabezado = null;
            this.grdDetalle.FuentePieDePagina = null;
            this.grdDetalle.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalle.Location = new System.Drawing.Point(12, 43);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = true;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 0;
            this.grdDetalle.Rows = 50;
            this.grdDetalle.Size = new System.Drawing.Size(353, 313);
            this.grdDetalle.TabIndex = 0;
            this.grdDetalle.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdDetalle_Editado);
            this.grdDetalle.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdDetalle_CambioFila);
            this.grdDetalle.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdDetalle_KeyUp);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblNombre.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblNombre.Location = new System.Drawing.Point(12, 6);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(133, 18);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Empleado";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 27);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha";
            // 
            // grdRetiros
            // 
            this.grdRetiros.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdRetiros.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdRetiros.AutoResize = false;
            this.grdRetiros.bColor = System.Drawing.SystemColors.Window;
            this.grdRetiros.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdRetiros.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdRetiros.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdRetiros.Col = 0;
            this.grdRetiros.Cols = 10;
            this.grdRetiros.DataMember = "";
            this.grdRetiros.DataSource = null;
            this.grdRetiros.EnableEdicion = true;
            this.grdRetiros.Encabezado = "";
            this.grdRetiros.fColor = System.Drawing.SystemColors.Control;
            this.grdRetiros.FixCols = 0;
            this.grdRetiros.FixRows = 0;
            this.grdRetiros.FuenteEncabezado = null;
            this.grdRetiros.FuentePieDePagina = null;
            this.grdRetiros.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdRetiros.Location = new System.Drawing.Point(160, 77);
            this.grdRetiros.Name = "grdRetiros";
            this.grdRetiros.PieDePagina = "\t\tPage {0} of {1}";
            this.grdRetiros.PintarFilaSel = true;
            this.grdRetiros.Redraw = true;
            this.grdRetiros.Row = 0;
            this.grdRetiros.Rows = 50;
            this.grdRetiros.Size = new System.Drawing.Size(91, 61);
            this.grdRetiros.TabIndex = 3;
            this.grdRetiros.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alta:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aguinaldo:";
            // 
            // lblAlta
            // 
            this.lblAlta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(291, 10);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(25, 13);
            this.lblAlta.TabIndex = 2;
            this.lblAlta.Text = "Alta";
            // 
            // lblAguinaldo
            // 
            this.lblAguinaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAguinaldo.AutoSize = true;
            this.lblAguinaldo.Location = new System.Drawing.Point(291, 27);
            this.lblAguinaldo.Name = "lblAguinaldo";
            this.lblAguinaldo.Size = new System.Drawing.Size(25, 13);
            this.lblAguinaldo.TabIndex = 2;
            this.lblAguinaldo.Text = "Alta";
            // 
            // frmRetiros_Aguinaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 368);
            this.Controls.Add(this.grdRetiros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAguinaldo);
            this.Controls.Add(this.lblAlta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.grdDetalle);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRetiros_Aguinaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguinaldo";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRetiros_Aguinaldo_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdDetalle;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFecha;
        public Grilla2.SpeedGrilla grdRetiros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.Label lblAguinaldo;
    }
}