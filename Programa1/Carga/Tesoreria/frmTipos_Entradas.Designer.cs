namespace Programa1.Carga.Tesoreria
{
    partial class frmTipos_Entradas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipos_Entradas));
            this.grdTipos_Entradas = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdGrupo = new Grilla2.SpeedGrilla();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdTipos_Entradas
            // 
            this.grdTipos_Entradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTipos_Entradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTipos_Entradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTipos_Entradas.AutoResize = false;
            this.grdTipos_Entradas.bColor = System.Drawing.SystemColors.Window;
            this.grdTipos_Entradas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTipos_Entradas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTipos_Entradas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTipos_Entradas.Col = 0;
            this.grdTipos_Entradas.Cols = 10;
            this.grdTipos_Entradas.DataMember = "";
            this.grdTipos_Entradas.DataSource = null;
            this.grdTipos_Entradas.EnableEdicion = true;
            this.grdTipos_Entradas.Encabezado = "";
            this.grdTipos_Entradas.fColor = System.Drawing.SystemColors.Control;
            this.grdTipos_Entradas.FixCols = 0;
            this.grdTipos_Entradas.FixRows = 0;
            this.grdTipos_Entradas.FuenteEncabezado = null;
            this.grdTipos_Entradas.FuentePieDePagina = null;
            this.grdTipos_Entradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipos_Entradas.Location = new System.Drawing.Point(299, 26);
            this.grdTipos_Entradas.MenuActivado = false;
            this.grdTipos_Entradas.Name = "grdTipos_Entradas";
            this.grdTipos_Entradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipos_Entradas.PintarFilaSel = true;
            this.grdTipos_Entradas.Redraw = true;
            this.grdTipos_Entradas.Row = 0;
            this.grdTipos_Entradas.Rows = 50;
            this.grdTipos_Entradas.Size = new System.Drawing.Size(761, 591);
            this.grdTipos_Entradas.TabIndex = 10;
            this.grdTipos_Entradas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdTipos_Entradas_Editado);
            this.grdTipos_Entradas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdTipos_Entradas_CambioFila);
            this.grdTipos_Entradas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdTipos_Entradas_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(296, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tipos Entradas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupos Entradas";
            // 
            // grdGrupo
            // 
            this.grdGrupo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdGrupo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdGrupo.AutoResize = false;
            this.grdGrupo.bColor = System.Drawing.SystemColors.Window;
            this.grdGrupo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdGrupo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdGrupo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdGrupo.Col = 0;
            this.grdGrupo.Cols = 10;
            this.grdGrupo.DataMember = "";
            this.grdGrupo.DataSource = null;
            this.grdGrupo.EnableEdicion = true;
            this.grdGrupo.Encabezado = "";
            this.grdGrupo.fColor = System.Drawing.SystemColors.Control;
            this.grdGrupo.FixCols = 0;
            this.grdGrupo.FixRows = 0;
            this.grdGrupo.FuenteEncabezado = null;
            this.grdGrupo.FuentePieDePagina = null;
            this.grdGrupo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGrupo.Location = new System.Drawing.Point(12, 26);
            this.grdGrupo.MenuActivado = false;
            this.grdGrupo.Name = "grdGrupo";
            this.grdGrupo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGrupo.PintarFilaSel = true;
            this.grdGrupo.Redraw = true;
            this.grdGrupo.Row = 0;
            this.grdGrupo.Rows = 50;
            this.grdGrupo.Size = new System.Drawing.Size(281, 318);
            this.grdGrupo.TabIndex = 0;
            this.grdGrupo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdGrupo_Editado);
            this.grdGrupo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdGrupo_CambioFila);
            this.grdGrupo.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdGrupo_KeyUp);
            this.grdGrupo.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdGrupo_KeyPress);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Interval = 5000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1072, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Hint = "Buscar";
            this.txtBuscar.Location = new System.Drawing.Point(299, 620);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(356, 23);
            this.txtBuscar.TabIndex = 19;
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // frmTipos_Entradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 668);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.grdGrupo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdTipos_Entradas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Name = "frmTipos_Entradas";
            this.Text = "Tipos Entradas";
            this.Load += new System.EventHandler(this.FrmTipos_Entradas_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Grilla2.SpeedGrilla grdTipos_Entradas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdGrupo;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
    }
}