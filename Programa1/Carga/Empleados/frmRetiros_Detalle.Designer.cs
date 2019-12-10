namespace Programa1.Carga.Empleados
{
    partial class frmRetiros_Detalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros_Detalle));
            this.grdDetalle = new Grilla2.SpeedGrilla();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
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
            this.grdDetalle.MenuActivado = false;
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = true;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 0;
            this.grdDetalle.Rows = 50;
            this.grdDetalle.Size = new System.Drawing.Size(246, 195);
            this.grdDetalle.TabIndex = 0;
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
            // frmRetiros_Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 250);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.grdDetalle);
            this.Name = "frmRetiros_Detalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdDetalle;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblFecha;
    }
}