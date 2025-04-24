namespace Programa1.Carga.Tesoreria
{
    partial class frmSubir_Ajustes
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
            this.grdTarjetas = new Grilla2.SpeedGrilla();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTarjetas
            // 
            this.grdTarjetas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTarjetas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTarjetas.AutoResize = false;
            this.grdTarjetas.bColor = System.Drawing.SystemColors.Window;
            this.grdTarjetas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTarjetas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTarjetas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTarjetas.Col = 0;
            this.grdTarjetas.Cols = 1;
            this.grdTarjetas.DataMember = "";
            this.grdTarjetas.DataSource = null;
            this.grdTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTarjetas.EnableEdicion = false;
            this.grdTarjetas.Encabezado = "";
            this.grdTarjetas.fColor = System.Drawing.SystemColors.Control;
            this.grdTarjetas.FixCols = 0;
            this.grdTarjetas.FixRows = 0;
            this.grdTarjetas.Frozen = 0;
            this.grdTarjetas.FuenteEncabezado = null;
            this.grdTarjetas.FuentePieDePagina = null;
            this.grdTarjetas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTarjetas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdTarjetas.Location = new System.Drawing.Point(0, 0);
            this.grdTarjetas.Name = "grdTarjetas";
            this.grdTarjetas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTarjetas.PintarFilaSel = true;
            this.grdTarjetas.Redraw = true;
            this.grdTarjetas.Row = 0;
            this.grdTarjetas.Rows = 1;
            this.grdTarjetas.Size = new System.Drawing.Size(981, 479);
            this.grdTarjetas.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdTarjetas);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 479);
            this.panel1.TabIndex = 2;
            // 
            // frmSubir_Ajustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 503);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSubir_Ajustes";
            this.Text = "Ajustes";
            this.Load += new System.EventHandler(this.frmSubir_Ajustes_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdTarjetas;
        private System.Windows.Forms.Panel panel1;
    }
}