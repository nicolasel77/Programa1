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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.lblNombre = new System.Windows.Forms.Label();
            this.grdEmpleado = new Grilla2.SpeedGrilla();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grdLocalidades = new Grilla2.SpeedGrilla();
            this.grdTipo = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblNombre.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblNombre.Location = new System.Drawing.Point(3, 0);
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
            this.grdEmpleado.FixRows = 1;
            this.grdEmpleado.FuenteEncabezado = null;
            this.grdEmpleado.FuentePieDePagina = null;
            this.grdEmpleado.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEmpleado.Location = new System.Drawing.Point(3, 21);
            this.grdEmpleado.MenuActivado = false;
            this.grdEmpleado.Name = "grdEmpleado";
            this.grdEmpleado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEmpleado.PintarFilaSel = true;
            this.grdEmpleado.Redraw = true;
            this.grdEmpleado.Row = 1;
            this.grdEmpleado.Rows = 50;
            this.grdEmpleado.Size = new System.Drawing.Size(366, 484);
            this.grdEmpleado.TabIndex = 1;
            this.grdEmpleado.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdEmpleado_Editado);
            // 
            // grdLocalidades
            // 
            this.grdLocalidades.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdLocalidades.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdLocalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLocalidades.AutoResize = false;
            this.grdLocalidades.bColor = System.Drawing.SystemColors.Window;
            this.grdLocalidades.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdLocalidades.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdLocalidades.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdLocalidades.Col = 0;
            this.grdLocalidades.Cols = 10;
            this.grdLocalidades.DataMember = "";
            this.grdLocalidades.DataSource = null;
            this.grdLocalidades.EnableEdicion = false;
            this.grdLocalidades.Encabezado = "";
            this.grdLocalidades.fColor = System.Drawing.SystemColors.Control;
            this.grdLocalidades.FixCols = 0;
            this.grdLocalidades.FixRows = 0;
            this.grdLocalidades.FuenteEncabezado = null;
            this.grdLocalidades.FuentePieDePagina = null;
            this.grdLocalidades.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdLocalidades.Location = new System.Drawing.Point(3, 21);
            this.grdLocalidades.MenuActivado = false;
            this.grdLocalidades.Name = "grdLocalidades";
            this.grdLocalidades.PieDePagina = "\t\tPage {0} of {1}";
            this.grdLocalidades.PintarFilaSel = true;
            this.grdLocalidades.Redraw = true;
            this.grdLocalidades.Row = 0;
            this.grdLocalidades.Rows = 50;
            this.grdLocalidades.Size = new System.Drawing.Size(236, 316);
            this.grdLocalidades.TabIndex = 2;
            // 
            // grdTipo
            // 
            this.grdTipo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTipo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTipo.AutoResize = false;
            this.grdTipo.bColor = System.Drawing.SystemColors.Window;
            this.grdTipo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTipo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTipo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTipo.Col = 0;
            this.grdTipo.Cols = 10;
            this.grdTipo.DataMember = "";
            this.grdTipo.DataSource = null;
            this.grdTipo.EnableEdicion = false;
            this.grdTipo.Encabezado = "";
            this.grdTipo.fColor = System.Drawing.SystemColors.Control;
            this.grdTipo.FixCols = 0;
            this.grdTipo.FixRows = 0;
            this.grdTipo.FuenteEncabezado = null;
            this.grdTipo.FuentePieDePagina = null;
            this.grdTipo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipo.Location = new System.Drawing.Point(0, 21);
            this.grdTipo.MenuActivado = false;
            this.grdTipo.Name = "grdTipo";
            this.grdTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipo.PintarFilaSel = true;
            this.grdTipo.Redraw = true;
            this.grdTipo.Row = 0;
            this.grdTipo.Rows = 50;
            this.grdTipo.Size = new System.Drawing.Size(239, 140);
            this.grdTipo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localidades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo Empleado";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 9);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.grdEmpleado);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(618, 508);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.grdLocalidades);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.grdTipo);
            this.splitContainer2.Size = new System.Drawing.Size(242, 508);
            this.splitContainer2.SplitterDistance = 340;
            this.splitContainer2.TabIndex = 4;
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 529);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private Grilla2.SpeedGrilla grdEmpleado;
        private System.Windows.Forms.ToolTip toolTip1;
        private Grilla2.SpeedGrilla grdLocalidades;
        private Grilla2.SpeedGrilla grdTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}