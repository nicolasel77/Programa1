namespace Programa1.Carga.Tesoreria
{
    partial class frmTipos_Gastos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipos_Gastos));
            this.grdTipo = new Grilla2.SpeedGrilla();
            this.grdDetalles = new Grilla2.SpeedGrilla();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.grdSubTipo = new Grilla2.SpeedGrilla();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lstTablas = new System.Windows.Forms.ListBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.grdGrupo = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblST = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
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
            this.grdTipo.EnableEdicion = true;
            this.grdTipo.Encabezado = "";
            this.grdTipo.fColor = System.Drawing.SystemColors.Control;
            this.grdTipo.FixCols = 0;
            this.grdTipo.FixRows = 0;
            this.grdTipo.FuenteEncabezado = null;
            this.grdTipo.FuentePieDePagina = null;
            this.grdTipo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipo.Location = new System.Drawing.Point(4, 42);
            this.grdTipo.Name = "grdTipo";
            this.grdTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipo.PintarFilaSel = true;
            this.grdTipo.Redraw = true;
            this.grdTipo.Row = 0;
            this.grdTipo.Rows = 2;
            this.grdTipo.Size = new System.Drawing.Size(355, 651);
            this.grdTipo.TabIndex = 13;
            this.grdTipo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdTipo_Editado);
            this.grdTipo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdTipo_CambioFila);
            // 
            // grdDetalles
            // 
            this.grdDetalles.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalles.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetalles.AutoResize = false;
            this.grdDetalles.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalles.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalles.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalles.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalles.Col = 0;
            this.grdDetalles.Cols = 10;
            this.grdDetalles.DataMember = "";
            this.grdDetalles.DataSource = null;
            this.grdDetalles.EnableEdicion = true;
            this.grdDetalles.Encabezado = "";
            this.grdDetalles.fColor = System.Drawing.SystemColors.Control;
            this.grdDetalles.FixCols = 0;
            this.grdDetalles.FixRows = 0;
            this.grdDetalles.FuenteEncabezado = null;
            this.grdDetalles.FuentePieDePagina = null;
            this.grdDetalles.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalles.Location = new System.Drawing.Point(3, 42);
            this.grdDetalles.Name = "grdDetalles";
            this.grdDetalles.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalles.PintarFilaSel = true;
            this.grdDetalles.Redraw = true;
            this.grdDetalles.Row = 0;
            this.grdDetalles.Rows = 2;
            this.grdDetalles.Size = new System.Drawing.Size(372, 651);
            this.grdDetalles.TabIndex = 15;
            this.grdDetalles.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdDetalles_Editado);
            this.grdDetalles.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdDetalles_CambioFila);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 711);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1461, 22);
            this.statusStrip1.TabIndex = 14;
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
            // 
            // grdSubTipo
            // 
            this.grdSubTipo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSubTipo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSubTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSubTipo.AutoResize = false;
            this.grdSubTipo.bColor = System.Drawing.SystemColors.Window;
            this.grdSubTipo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSubTipo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSubTipo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSubTipo.Col = 0;
            this.grdSubTipo.Cols = 10;
            this.grdSubTipo.DataMember = "";
            this.grdSubTipo.DataSource = null;
            this.grdSubTipo.EnableEdicion = true;
            this.grdSubTipo.Encabezado = "";
            this.grdSubTipo.fColor = System.Drawing.SystemColors.Control;
            this.grdSubTipo.FixCols = 0;
            this.grdSubTipo.FixRows = 0;
            this.grdSubTipo.FuenteEncabezado = null;
            this.grdSubTipo.FuentePieDePagina = null;
            this.grdSubTipo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSubTipo.Location = new System.Drawing.Point(3, 42);
            this.grdSubTipo.Name = "grdSubTipo";
            this.grdSubTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSubTipo.PintarFilaSel = true;
            this.grdSubTipo.Redraw = true;
            this.grdSubTipo.Row = 0;
            this.grdSubTipo.Rows = 2;
            this.grdSubTipo.Size = new System.Drawing.Size(325, 651);
            this.grdSubTipo.TabIndex = 13;
            this.grdSubTipo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSubTipo_Editado);
            this.grdSubTipo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdSubTipo_CambioFila);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.grdTipo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1090, 696);
            this.splitContainer1.SplitterDistance = 362;
            this.splitContainer1.TabIndex = 19;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblST);
            this.splitContainer2.Panel1.Controls.Add(this.grdSubTipo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.grdDetalles);
            this.splitContainer2.Size = new System.Drawing.Size(724, 696);
            this.splitContainer2.SplitterDistance = 334;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Location = new System.Drawing.Point(12, 12);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.lstTablas);
            this.splitContainer3.Panel1.Controls.Add(this.materialLabel5);
            this.splitContainer3.Panel1.Controls.Add(this.grdGrupo);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer3.Size = new System.Drawing.Size(1437, 696);
            this.splitContainer3.SplitterDistance = 343;
            this.splitContainer3.TabIndex = 19;
            // 
            // lstTablas
            // 
            this.lstTablas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTablas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTablas.ForeColor = System.Drawing.Color.DimGray;
            this.lstTablas.FormattingEnabled = true;
            this.lstTablas.ItemHeight = 16;
            this.lstTablas.Location = new System.Drawing.Point(7, 533);
            this.lstTablas.Name = "lstTablas";
            this.lstTablas.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstTablas.Size = new System.Drawing.Size(333, 160);
            this.lstTablas.TabIndex = 21;
            // 
            // materialLabel5
            // 
            this.materialLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(3, 511);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(54, 19);
            this.materialLabel5.TabIndex = 20;
            this.materialLabel5.Text = "Tablas";
            // 
            // grdGrupo
            // 
            this.grdGrupo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdGrupo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grdGrupo.Location = new System.Drawing.Point(7, 42);
            this.grdGrupo.Name = "grdGrupo";
            this.grdGrupo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGrupo.PintarFilaSel = true;
            this.grdGrupo.Redraw = true;
            this.grdGrupo.Row = 0;
            this.grdGrupo.Rows = 2;
            this.grdGrupo.Size = new System.Drawing.Size(333, 466);
            this.grdGrupo.TabIndex = 13;
            this.grdGrupo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdGrupo_Editado);
            this.grdGrupo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdGrupo_CambioFila);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 30);
            this.label1.TabIndex = 22;
            this.label1.Text = "Grupo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 30);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblST
            // 
            this.lblST.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblST.BackColor = System.Drawing.SystemColors.Control;
            this.lblST.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblST.Location = new System.Drawing.Point(3, 9);
            this.lblST.Name = "lblST";
            this.lblST.Size = new System.Drawing.Size(325, 30);
            this.lblST.TabIndex = 23;
            this.lblST.Text = "SubTipo";
            this.lblST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 30);
            this.label4.TabIndex = 23;
            this.label4.Text = "Detalle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTipos_Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 733);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmTipos_Gastos";
            this.Text = "Tipos Gastos";
            this.Load += new System.EventHandler(this.frmTipos_Gastos_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdTipo;
        private Grilla2.SpeedGrilla grdDetalles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Timer tiMensaje;
        private Grilla2.SpeedGrilla grdSubTipo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Grilla2.SpeedGrilla grdGrupo;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.ListBox lstTablas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblST;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}