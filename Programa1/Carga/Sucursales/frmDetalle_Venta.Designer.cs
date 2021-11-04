namespace Programa1.Carga.Sucursales
{

    partial class frmDetalle_Venta
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
            this.grdDetalle = new Grilla2.SpeedGrilla();
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
            this.grdDetalle.fColor = System.Drawing.Color.Silver;
            this.grdDetalle.FixCols = 0;
            this.grdDetalle.FixRows = 0;
            this.grdDetalle.FuenteEncabezado = null;
            this.grdDetalle.FuentePieDePagina = null;
            this.grdDetalle.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalle.Location = new System.Drawing.Point(12, 12);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = true;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 0;
            this.grdDetalle.Rows = 50;
            this.grdDetalle.Size = new System.Drawing.Size(570, 302);
            this.grdDetalle.TabIndex = 0;
            this.grdDetalle.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdDetalle_Editado);
            this.grdDetalle.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdDetalle_CambioFila);
            this.grdDetalle.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdDetalle_KeyUp);
            // 
            // frmDetalle_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 326);
            this.Controls.Add(this.grdDetalle);
            this.KeyPreview = true;
            this.Name = "frmDetalle_Venta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Ventas";
            this.Load += new System.EventHandler(this.frmDetalle_Venta_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDetalle_Venta_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdDetalle;
    }
}