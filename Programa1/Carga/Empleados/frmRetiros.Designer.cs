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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdRetiros = new Grilla2.SpeedGrilla();
            this.cSuc = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1221, 641);
            this.splitContainer1.SplitterDistance = 890;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Size = new System.Drawing.Size(327, 641);
            this.splitContainer2.SplitterDistance = 402;
            this.splitContainer2.TabIndex = 0;
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
            this.grdRetiros.Size = new System.Drawing.Size(875, 617);
            this.grdRetiros.TabIndex = 0;
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
            this.cSuc.Size = new System.Drawing.Size(325, 387);
            this.cSuc.TabIndex = 0;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            // 
            // frmRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 641);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRetiros";
            this.Text = "Retiros";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdRetiros;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cSucursales cSuc;
    }
}