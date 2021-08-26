namespace Programa1.Carga
{
    partial class frmSeberos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeberos));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.grdSeberos = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1158, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Interval = 5000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // grdSeberos
            // 
            this.grdSeberos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSeberos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSeberos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSeberos.AutoResize = false;
            this.grdSeberos.bColor = System.Drawing.SystemColors.Window;
            this.grdSeberos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSeberos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSeberos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSeberos.Col = 0;
            this.grdSeberos.Cols = 10;
            this.grdSeberos.DataMember = "";
            this.grdSeberos.DataSource = null;
            this.grdSeberos.EnableEdicion = true;
            this.grdSeberos.Encabezado = "";
            this.grdSeberos.fColor = System.Drawing.SystemColors.Control;
            this.grdSeberos.FixCols = 0;
            this.grdSeberos.FixRows = 0;
            this.grdSeberos.FuenteEncabezado = null;
            this.grdSeberos.FuentePieDePagina = null;
            this.grdSeberos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSeberos.Location = new System.Drawing.Point(12, 30);
            this.grdSeberos.Name = "grdSeberos";
            this.grdSeberos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSeberos.PintarFilaSel = true;
            this.grdSeberos.Redraw = true;
            this.grdSeberos.Row = 0;
            this.grdSeberos.Rows = 50;
            this.grdSeberos.Size = new System.Drawing.Size(1134, 661);
            this.grdSeberos.TabIndex = 1;
            this.grdSeberos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdSeberos_Editado);
            this.grdSeberos.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdSeberos_CambioFila);
            this.grdSeberos.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdSeberos_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seberos";
            // 
            // frmSeberos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 716);
            this.Controls.Add(this.grdSeberos);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Name = "frmSeberos";
            this.Text = "Seberos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSeberos_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Timer tiMensaje;
        private Grilla2.SpeedGrilla grdSeberos;
    }
}