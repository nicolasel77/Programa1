namespace Programa1.Carga.Hacienda
{
    partial class frmFriorificosABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFriorificosABM));
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.grdConsignatarios = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdfrigorificos = new Grilla2.SpeedGrilla();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tiMensaje
            // 
            this.tiMensaje.Interval = 5000;
            this.tiMensaje.Tick += new System.EventHandler(this.tiMensaje_Tick_1);
            // 
            // grdConsignatarios
            // 
            this.grdConsignatarios.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdConsignatarios.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdConsignatarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdConsignatarios.AutoResize = false;
            this.grdConsignatarios.bColor = System.Drawing.SystemColors.Window;
            this.grdConsignatarios.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdConsignatarios.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdConsignatarios.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdConsignatarios.Col = 0;
            this.grdConsignatarios.Cols = 10;
            this.grdConsignatarios.DataMember = "";
            this.grdConsignatarios.DataSource = null;
            this.grdConsignatarios.EnableEdicion = true;
            this.grdConsignatarios.Encabezado = "";
            this.grdConsignatarios.fColor = System.Drawing.SystemColors.Control;
            this.grdConsignatarios.FixCols = 0;
            this.grdConsignatarios.FixRows = 0;
            this.grdConsignatarios.FuenteEncabezado = null;
            this.grdConsignatarios.FuentePieDePagina = null;
            this.grdConsignatarios.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdConsignatarios.Location = new System.Drawing.Point(404, 30);
            this.grdConsignatarios.Name = "grdConsignatarios";
            this.grdConsignatarios.PieDePagina = "\t\tPage {0} of {1}";
            this.grdConsignatarios.PintarFilaSel = true;
            this.grdConsignatarios.Redraw = true;
            this.grdConsignatarios.Row = 0;
            this.grdConsignatarios.Rows = 50;
            this.grdConsignatarios.Size = new System.Drawing.Size(742, 638);
            this.grdConsignatarios.TabIndex = 1;
            this.grdConsignatarios.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdConsignatarios_Editado_1);
            this.grdConsignatarios.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdConsignatarios_CambioFila_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(401, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Consignatarios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Frigorificos";
            // 
            // grdfrigorificos
            // 
            this.grdfrigorificos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdfrigorificos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdfrigorificos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdfrigorificos.AutoResize = false;
            this.grdfrigorificos.bColor = System.Drawing.SystemColors.Window;
            this.grdfrigorificos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdfrigorificos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdfrigorificos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdfrigorificos.Col = 0;
            this.grdfrigorificos.Cols = 10;
            this.grdfrigorificos.DataMember = "";
            this.grdfrigorificos.DataSource = null;
            this.grdfrigorificos.EnableEdicion = true;
            this.grdfrigorificos.Encabezado = "";
            this.grdfrigorificos.fColor = System.Drawing.SystemColors.Control;
            this.grdfrigorificos.FixCols = 0;
            this.grdfrigorificos.FixRows = 0;
            this.grdfrigorificos.FuenteEncabezado = null;
            this.grdfrigorificos.FuentePieDePagina = null;
            this.grdfrigorificos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdfrigorificos.Location = new System.Drawing.Point(4, 30);
            this.grdfrigorificos.Name = "grdfrigorificos";
            this.grdfrigorificos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdfrigorificos.PintarFilaSel = true;
            this.grdfrigorificos.Redraw = true;
            this.grdfrigorificos.Row = 0;
            this.grdfrigorificos.Rows = 50;
            this.grdfrigorificos.Size = new System.Drawing.Size(394, 661);
            this.grdfrigorificos.TabIndex = 6;
            this.grdfrigorificos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdfrigorificos_Editado_1);
            this.grdfrigorificos.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdfrigorificos_CambioFila_1);
            this.grdfrigorificos.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdfrigorificos_KeyPress_1);            
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBuscar.Location = new System.Drawing.Point(449, 671);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(296, 20);
            this.txtBuscar.TabIndex = 7;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 671);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1158, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // frmFriorificosABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 716);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdConsignatarios);
            this.Controls.Add(this.grdfrigorificos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFriorificosABM";
            this.Text = "ABM Frigorificos y Consignatarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tiMensaje;
        private Grilla2.SpeedGrilla grdConsignatarios;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdfrigorificos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
    }
}