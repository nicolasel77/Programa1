namespace Programa1.Carga.TM
{
    partial class frmPagarHacienda
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
            this.grdFacturas = new Grilla2.SpeedGrilla();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grdFacturas
            // 
            this.grdFacturas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdFacturas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFacturas.AutoResize = false;
            this.grdFacturas.bColor = System.Drawing.SystemColors.Window;
            this.grdFacturas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdFacturas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdFacturas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdFacturas.Col = 0;
            this.grdFacturas.Cols = 10;
            this.grdFacturas.DataMember = "";
            this.grdFacturas.DataSource = null;
            this.grdFacturas.EnableEdicion = true;
            this.grdFacturas.Encabezado = "";
            this.grdFacturas.fColor = System.Drawing.Color.Silver;
            this.grdFacturas.FixCols = 0;
            this.grdFacturas.FixRows = 0;
            this.grdFacturas.Frozen = 0;
            this.grdFacturas.FuenteEncabezado = null;
            this.grdFacturas.FuentePieDePagina = null;
            this.grdFacturas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdFacturas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdFacturas.Location = new System.Drawing.Point(12, 12);
            this.grdFacturas.Name = "grdFacturas";
            this.grdFacturas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdFacturas.PintarFilaSel = true;
            this.grdFacturas.Redraw = true;
            this.grdFacturas.Row = 0;
            this.grdFacturas.Rows = 50;
            this.grdFacturas.Size = new System.Drawing.Size(1032, 365);
            this.grdFacturas.TabIndex = 0;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAceptar.Location = new System.Drawing.Point(834, 383);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(102, 23);
            this.cmdAceptar.TabIndex = 9;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSalir.Location = new System.Drawing.Point(942, 383);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(102, 23);
            this.cmdSalir.TabIndex = 10;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // frmPagarHacienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 418);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.grdFacturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPagarHacienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Hacienda";
            this.Load += new System.EventHandler(this.frmPagarHacienda_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdFacturas;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdSalir;
    }
}