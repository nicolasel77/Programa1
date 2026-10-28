namespace Programa1.Carga.TM
{
    partial class frmResumenGastosTM
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.grdGastos = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmdDerecha = new System.Windows.Forms.Button();
            this.cmdIzquierda = new System.Windows.Forms.Button();
            this.lblSubTipo = new MaterialSkin.Controls.MaterialLabel();
            this.lst = new System.Windows.Forms.ListBox();
            this.lblTipo = new MaterialSkin.Controls.MaterialLabel();
            this.chMostrarCajas = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblCaja = new MaterialSkin.Controls.MaterialLabel();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.lstCajas = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cFechas1 = new Programa1.Controles.cFechas();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 724);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Location = new System.Drawing.Point(14, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.cmdImprimir);
            this.splitContainer1.Panel1.Controls.Add(this.lblTotal);
            this.splitContainer1.Panel1.Controls.Add(this.grdGastos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1108, 696);
            this.splitContainer1.SplitterDistance = 690;
            this.splitContainer1.TabIndex = 5;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(496, 700);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(143, 10);
            this.cmdImprimir.TabIndex = 2;
            this.cmdImprimir.Texto = "Imprimir";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(3, 674);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
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
            this.grdGastos.Frozen = 0;
            this.grdGastos.FuenteEncabezado = null;
            this.grdGastos.FuentePieDePagina = null;
            this.grdGastos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGastos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdGastos.Location = new System.Drawing.Point(19, 18);
            this.grdGastos.Name = "grdGastos";
            this.grdGastos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGastos.PintarFilaSel = true;
            this.grdGastos.Redraw = true;
            this.grdGastos.Row = 0;
            this.grdGastos.Rows = 1;
            this.grdGastos.Size = new System.Drawing.Size(658, 666);
            this.grdGastos.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.cmdDerecha);
            this.splitContainer2.Panel1.Controls.Add(this.cmdIzquierda);
            this.splitContainer2.Panel1.Controls.Add(this.lblSubTipo);
            this.splitContainer2.Panel1.Controls.Add(this.lst);
            this.splitContainer2.Panel1.Controls.Add(this.lblTipo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.chMostrarCajas);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer2.Size = new System.Drawing.Size(414, 696);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 4;
            // 
            // cmdDerecha
            // 
            this.cmdDerecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDerecha.Location = new System.Drawing.Point(124, 268);
            this.cmdDerecha.Name = "cmdDerecha";
            this.cmdDerecha.Size = new System.Drawing.Size(99, 22);
            this.cmdDerecha.TabIndex = 1;
            this.cmdDerecha.Text = ">";
            this.cmdDerecha.UseVisualStyleBackColor = true;
            // 
            // cmdIzquierda
            // 
            this.cmdIzquierda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdIzquierda.Location = new System.Drawing.Point(19, 268);
            this.cmdIzquierda.Name = "cmdIzquierda";
            this.cmdIzquierda.Size = new System.Drawing.Size(99, 22);
            this.cmdIzquierda.TabIndex = 1;
            this.cmdIzquierda.Text = "<";
            this.cmdIzquierda.UseVisualStyleBackColor = true;
            // 
            // lblSubTipo
            // 
            this.lblSubTipo.AutoSize = true;
            this.lblSubTipo.Depth = 0;
            this.lblSubTipo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSubTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSubTipo.Location = new System.Drawing.Point(15, 350);
            this.lblSubTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSubTipo.Name = "lblSubTipo";
            this.lblSubTipo.Size = new System.Drawing.Size(64, 19);
            this.lblSubTipo.TabIndex = 3;
            this.lblSubTipo.Text = "SubTipo";
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 20;
            this.lst.Location = new System.Drawing.Point(19, 9);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(362, 220);
            this.lst.TabIndex = 0;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Depth = 0;
            this.lblTipo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTipo.Location = new System.Drawing.Point(15, 332);
            this.lblTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 19);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo";
            // 
            // chMostrarCajas
            // 
            this.chMostrarCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chMostrarCajas.AutoSize = true;
            this.chMostrarCajas.Depth = 0;
            this.chMostrarCajas.Font = new System.Drawing.Font("Roboto", 10F);
            this.chMostrarCajas.Location = new System.Drawing.Point(3, 353);
            this.chMostrarCajas.Margin = new System.Windows.Forms.Padding(0);
            this.chMostrarCajas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chMostrarCajas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chMostrarCajas.Name = "chMostrarCajas";
            this.chMostrarCajas.Ripple = true;
            this.chMostrarCajas.Size = new System.Drawing.Size(109, 30);
            this.chMostrarCajas.TabIndex = 9;
            this.chMostrarCajas.Text = "Mostrar Caja";
            this.chMostrarCajas.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.splitContainer3);
            this.panel2.Location = new System.Drawing.Point(141, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 383);
            this.panel2.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.lblCaja);
            this.splitContainer3.Panel1.Controls.Add(this.lstGrupos);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.lstCajas);
            this.splitContainer3.Panel2.Controls.Add(this.materialLabel1);
            this.splitContainer3.Size = new System.Drawing.Size(267, 377);
            this.splitContainer3.SplitterDistance = 185;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.TabIndex = 6;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Depth = 0;
            this.lblCaja.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCaja.Location = new System.Drawing.Point(3, 0);
            this.lblCaja.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(49, 19);
            this.lblCaja.TabIndex = 3;
            this.lblCaja.Text = "Grupo";
            // 
            // lstGrupos
            // 
            this.lstGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.ItemHeight = 18;
            this.lstGrupos.Location = new System.Drawing.Point(0, 24);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGrupos.Size = new System.Drawing.Size(264, 144);
            this.lstGrupos.TabIndex = 5;
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
            this.lstCajas.Location = new System.Drawing.Point(3, 19);
            this.lstCajas.Name = "lstCajas";
            this.lstCajas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCajas.Size = new System.Drawing.Size(261, 162);
            this.lstCajas.TabIndex = 5;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(39, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Caja";
            // 
            // cFechas1
            // 
            this.cFechas1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(3, 3);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(132, 347);
            this.cFechas1.TabIndex = 1;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // frmResumenGastosTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 748);
            this.Controls.Add(this.panel1);
            this.Name = "frmResumenGastosTM";
            this.Text = "Resumen_GastosTM";
            this.panel1.ResumeLayout(false);
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
            this.panel2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.cBoton cmdImprimir;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private Grilla2.SpeedGrilla grdGastos;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button cmdDerecha;
        private System.Windows.Forms.Button cmdIzquierda;
        private System.Windows.Forms.ListBox lst;
        private MaterialSkin.Controls.MaterialCheckBox chMostrarCajas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private MaterialSkin.Controls.MaterialLabel lblCaja;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.ListBox lstCajas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblSubTipo;
        private Controles.cFechas cFechas1;
        private MaterialSkin.Controls.MaterialLabel lblTipo;
    }
}