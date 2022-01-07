namespace Programa1.Carga.Tesoreria
{
    partial class frmResumen_Gastos
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
            this.grdGastos = new Grilla2.SpeedGrilla();
            this.lblTipo = new MaterialSkin.Controls.MaterialLabel();
            this.lblSubTipo = new MaterialSkin.Controls.MaterialLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lst = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCaja = new MaterialSkin.Controls.MaterialLabel();
            this.lstCajas = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.cFechas1 = new Programa1.Controles.cFechas();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGastos
            // 
            this.grdGastos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdGastos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGastos.AutoResize = false;
            this.grdGastos.bColor = System.Drawing.SystemColors.Window;
            this.grdGastos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdGastos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdGastos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdGastos.Col = 0;
            this.grdGastos.Cols = 10;
            this.grdGastos.DataMember = "";
            this.grdGastos.DataSource = null;
            this.grdGastos.EnableEdicion = false;
            this.grdGastos.Encabezado = "";
            this.grdGastos.fColor = System.Drawing.SystemColors.Control;
            this.grdGastos.FixCols = 0;
            this.grdGastos.FixRows = 0;
            this.grdGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdGastos.FuenteEncabezado = null;
            this.grdGastos.FuentePieDePagina = null;
            this.grdGastos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGastos.Location = new System.Drawing.Point(0, 0);
            this.grdGastos.Name = "grdGastos";
            this.grdGastos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGastos.PintarFilaSel = true;
            this.grdGastos.Redraw = true;
            this.grdGastos.Row = 0;
            this.grdGastos.Rows = 1;
            this.grdGastos.Size = new System.Drawing.Size(705, 634);
            this.grdGastos.TabIndex = 0;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Depth = 0;
            this.lblTipo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTipo.Location = new System.Drawing.Point(3, 0);
            this.lblTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 19);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            // 
            // lblSubTipo
            // 
            this.lblSubTipo.AutoSize = true;
            this.lblSubTipo.Depth = 0;
            this.lblSubTipo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSubTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubTipo.Location = new System.Drawing.Point(3, 18);
            this.lblSubTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSubTipo.Name = "lblSubTipo";
            this.lblSubTipo.Size = new System.Drawing.Size(64, 19);
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
            this.splitContainer1.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel1.Controls.Add(this.grdGastos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1048, 664);
            this.splitContainer1.SplitterDistance = 708;
            this.splitContainer1.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(3, 642);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 19);
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
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.lblSubTipo);
            this.splitContainer2.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer2.Panel2.Controls.Add(this.lblTipo);
            this.splitContainer2.Size = new System.Drawing.Size(336, 664);
            this.splitContainer2.SplitterDistance = 425;
            this.splitContainer2.SplitterWidth = 8;
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
            this.lst.Size = new System.Drawing.Size(336, 425);
            this.lst.TabIndex = 0;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblCaja);
            this.panel2.Controls.Add(this.lstCajas);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.lstGrupos);
            this.panel2.Location = new System.Drawing.Point(231, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 220);
            this.panel2.TabIndex = 6;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Depth = 0;
            this.lblCaja.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCaja.Location = new System.Drawing.Point(4, 2);
            this.lblCaja.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(49, 19);
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
            this.lstCajas.Size = new System.Drawing.Size(168, 36);
            this.lstCajas.TabIndex = 5;
            this.lstCajas.SelectedIndexChanged += new System.EventHandler(this.lstGrupos_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(4, 138);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(39, 19);
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
            this.lstGrupos.Size = new System.Drawing.Size(168, 108);
            this.lstGrupos.TabIndex = 5;
            this.lstGrupos.SelectedIndexChanged += new System.EventHandler(this.lstGrupos_SelectedIndexChanged);
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
            this.cFechas1.Size = new System.Drawing.Size(228, 184);
            this.cFechas1.TabIndex = 1;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 679);
            this.panel1.TabIndex = 5;
            // 
            // frmResumen_Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 688);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmResumen_Gastos";
            this.Text = "Resumen";
            this.Load += new System.EventHandler(this.frmResumen_Gastos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmResumen_Gastos_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdGastos;
        private Controles.cFechas cFechas1;
        private MaterialSkin.Controls.MaterialLabel lblTipo;
        private MaterialSkin.Controls.MaterialLabel lblSubTipo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.ListBox lst;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialLabel lblCaja;
        private System.Windows.Forms.ListBox lstCajas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel panel2;
    }
}