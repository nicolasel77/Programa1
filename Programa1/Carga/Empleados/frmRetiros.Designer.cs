namespace Programa1.Carga.Empleados
{
    partial class frmRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetiros));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdRetiros = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstMes = new System.Windows.Forms.ListBox();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.cmdExcel = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdRetiros);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1272, 690);
            this.splitContainer1.SplitterDistance = 927;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdRetiros
            // 
            this.grdRetiros.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdRetiros.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdRetiros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grdRetiros.Location = new System.Drawing.Point(12, 12);
            this.grdRetiros.MenuActivado = false;
            this.grdRetiros.Name = "grdRetiros";
            this.grdRetiros.PieDePagina = "\t\tPage {0} of {1}";
            this.grdRetiros.PintarFilaSel = true;
            this.grdRetiros.Redraw = true;
            this.grdRetiros.Row = 0;
            this.grdRetiros.Rows = 50;
            this.grdRetiros.Size = new System.Drawing.Size(912, 666);
            this.grdRetiros.TabIndex = 0;
            this.grdRetiros.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdRetiros_Editado);
            this.grdRetiros.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdRetiros_CambioFila);
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
            this.splitContainer2.Panel1.Controls.Add(this.cSuc);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cmdImprimir);
            this.splitContainer2.Panel2.Controls.Add(this.cmdExcel);
            this.splitContainer2.Panel2.Controls.Add(this.lstMes);
            this.splitContainer2.Size = new System.Drawing.Size(341, 690);
            this.splitContainer2.SplitterDistance = 432;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstMes
            // 
            this.lstMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMes.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstMes.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstMes.FormattingEnabled = true;
            this.lstMes.ItemHeight = 18;
            this.lstMes.Location = new System.Drawing.Point(3, 3);
            this.lstMes.Name = "lstMes";
            this.lstMes.Size = new System.Drawing.Size(78, 234);
            this.lstMes.TabIndex = 0;
            this.lstMes.SelectedIndexChanged += new System.EventHandler(this.LstMes_SelectedIndexChanged);
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(-1, 12);
            this.cSuc.Mostrar_Tipo = true;
            this.cSuc.Name = "cSuc";
            this.cSuc.Size = new System.Drawing.Size(339, 417);
            this.cSuc.TabIndex = 0;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.CSuc_Cambio_Seleccion);
            // 
            // cmdExcel
            // 
            this.cmdExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdExcel.Location = new System.Drawing.Point(222, 183);
            this.cmdExcel.Name = "cmdExcel";
            this.cmdExcel.Size = new System.Drawing.Size(116, 24);
            this.cmdExcel.TabIndex = 1;
            this.cmdExcel.Text = "Excel";
            this.cmdExcel.UseVisualStyleBackColor = true;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdImprimir.Location = new System.Drawing.Point(222, 213);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(116, 24);
            this.cmdImprimir.TabIndex = 1;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 690);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRetiros";
            this.Text = "Retiros";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdRetiros;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cSucursales cSuc;
        private System.Windows.Forms.ListBox lstMes;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdExcel;
    }
}