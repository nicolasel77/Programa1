namespace Programa1.Carga.Tesoreria
{
    partial class frmResumen_Entradas
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
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.lblTipo = new MaterialSkin.Controls.MaterialLabel();
            this.lblSubTipo = new MaterialSkin.Controls.MaterialLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lst = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCaja = new MaterialSkin.Controls.MaterialLabel();
            this.lstCajas = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.cFechas1 = new Programa1.Controles.cFechas();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEntradas
            // 
            this.grdEntradas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEntradas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntradas.AutoResize = false;
            this.grdEntradas.bColor = System.Drawing.SystemColors.Window;
            this.grdEntradas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEntradas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEntradas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEntradas.Col = 0;
            this.grdEntradas.Cols = 1;
            this.grdEntradas.DataMember = "";
            this.grdEntradas.DataSource = null;
            this.grdEntradas.EnableEdicion = false;
            this.grdEntradas.Encabezado = "";
            this.grdEntradas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntradas.FixCols = 0;
            this.grdEntradas.FixRows = 0;
            this.grdEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.Location = new System.Drawing.Point(0, 0);
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 1;
            this.grdEntradas.Size = new System.Drawing.Size(691, 634);
            this.grdEntradas.TabIndex = 0;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Depth = 0;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTipo.Location = new System.Drawing.Point(3, 1);
            this.lblTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(37, 18);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            // 
            // lblSubTipo
            // 
            this.lblSubTipo.AutoSize = true;
            this.lblSubTipo.Depth = 0;
            this.lblSubTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSubTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubTipo.Location = new System.Drawing.Point(3, 19);
            this.lblSubTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSubTipo.Name = "lblSubTipo";
            this.lblSubTipo.Size = new System.Drawing.Size(63, 18);
            this.lblSubTipo.TabIndex = 3;
            this.lblSubTipo.Text = "SubTipo";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1062, 664);
            this.splitContainer1.SplitterDistance = 691;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Location = new System.Drawing.Point(3, 637);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 24);
            this.panel2.TabIndex = 19;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(3, 3);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 18);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.lst);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Panel2.Controls.Add(this.lblSubTipo);
            this.splitContainer2.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer2.Panel2.Controls.Add(this.lblTipo);
            this.splitContainer2.Size = new System.Drawing.Size(367, 664);
            this.splitContainer2.SplitterDistance = 357;
            this.splitContainer2.TabIndex = 4;
            // 
            // lst
            // 
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 20;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(367, 357);
            this.lst.TabIndex = 0;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 679);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblCaja);
            this.panel3.Controls.Add(this.lstCajas);
            this.panel3.Controls.Add(this.materialLabel1);
            this.panel3.Controls.Add(this.lstGrupos);
            this.panel3.Location = new System.Drawing.Point(203, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 297);
            this.panel3.TabIndex = 7;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Depth = 0;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCaja.Location = new System.Drawing.Point(4, 2);
            this.lblCaja.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(50, 18);
            this.lblCaja.TabIndex = 3;
            this.lblCaja.Text = "Grupo";
            // 
            // lstCajas
            // 
            this.lstCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCajas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstCajas.FormattingEnabled = true;
            this.lstCajas.ItemHeight = 18;
            this.lstCajas.Location = new System.Drawing.Point(3, 159);
            this.lstCajas.Name = "lstCajas";
            this.lstCajas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCajas.Size = new System.Drawing.Size(155, 126);
            this.lstCajas.TabIndex = 5;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(4, 138);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(38, 18);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Caja";
            // 
            // lstGrupos
            // 
            this.lstGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.ItemHeight = 18;
            this.lstGrupos.Location = new System.Drawing.Point(3, 24);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGrupos.Size = new System.Drawing.Size(155, 108);
            this.lstGrupos.TabIndex = 5;
            // 
            // cFechas1
            // 
            this.cFechas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(0, 40);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(197, 263);
            this.cFechas1.TabIndex = 1;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // frmResumen_Entradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 688);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmResumen_Entradas";
            this.Text = "Resumen";
            this.Load += new System.EventHandler(this.frmResumen_Entradas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmResumen_Entradas_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdEntradas;
        private Controles.cFechas cFechas1;
        private MaterialSkin.Controls.MaterialLabel lblTipo;
        private MaterialSkin.Controls.MaterialLabel lblSubTipo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lst;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel lblCaja;
        private System.Windows.Forms.ListBox lstCajas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ListBox lstGrupos;
    }
}