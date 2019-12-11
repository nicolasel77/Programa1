namespace Programa1.Carga.Empleados
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.lblNombre = new System.Windows.Forms.Label();
            this.grdEmpleado = new Grilla2.SpeedGrilla();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblNombre.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(46, 18);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "label1";
            // 
            // grdEmpleado
            // 
            this.grdEmpleado.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEmpleado.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEmpleado.AutoResize = false;
            this.grdEmpleado.bColor = System.Drawing.SystemColors.Window;
            this.grdEmpleado.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEmpleado.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEmpleado.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEmpleado.Col = 1;
            this.grdEmpleado.Cols = 2;
            this.grdEmpleado.DataMember = "";
            this.grdEmpleado.DataSource = null;
            this.grdEmpleado.EnableEdicion = true;
            this.grdEmpleado.Encabezado = "";
            this.grdEmpleado.fColor = System.Drawing.SystemColors.Control;
            this.grdEmpleado.FixCols = 1;
            this.grdEmpleado.FixRows = 0;
            this.grdEmpleado.FuenteEncabezado = null;
            this.grdEmpleado.FuentePieDePagina = null;
            this.grdEmpleado.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEmpleado.Location = new System.Drawing.Point(12, 30);
            this.grdEmpleado.MenuActivado = false;
            this.grdEmpleado.Name = "grdEmpleado";
            this.grdEmpleado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEmpleado.PintarFilaSel = true;
            this.grdEmpleado.Redraw = true;
            this.grdEmpleado.Row = 0;
            this.grdEmpleado.Rows = 50;
            this.grdEmpleado.Size = new System.Drawing.Size(249, 383);
            this.grdEmpleado.TabIndex = 1;
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 425);
            this.Controls.Add(this.grdEmpleado);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private Grilla2.SpeedGrilla grdEmpleado;
    }
}