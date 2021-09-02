namespace Programa1.Carga.Hacienda
{
    partial class frmVencimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVencimientos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.grdAgr = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.chConSaldo = new MaterialSkin.Controls.MaterialCheckBox();
            this.cFecha = new Programa1.Controles.cFechas();
            this.grdDetalle = new Grilla2.SpeedGrilla();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdActualizar = new Programa1.Controles.cBoton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbnvaBoleta = new Programa1.Controles.cBoton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.grdDetalle);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1456, 780);
            this.splitContainer1.SplitterDistance = 690;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.grd);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.grdAgr);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1344, 690);
            this.splitContainer2.SplitterDistance = 752;
            this.splitContainer2.TabIndex = 1;
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoResize = false;
            this.grd.bColor = System.Drawing.SystemColors.Window;
            this.grd.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grd.bFColor = System.Drawing.SystemColors.WindowText;
            this.grd.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grd.Col = 0;
            this.grd.Cols = 10;
            this.grd.DataMember = "";
            this.grd.DataSource = null;
            this.grd.EnableEdicion = false;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(3, 31);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = false;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(746, 656);
            this.grd.TabIndex = 3;
            this.grd.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grd_CambioFila);
            this.grd.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(-1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Compras P1";
            // 
            // grdAgr
            // 
            this.grdAgr.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAgr.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAgr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAgr.AutoResize = false;
            this.grdAgr.bColor = System.Drawing.SystemColors.Window;
            this.grdAgr.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAgr.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAgr.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAgr.Col = 0;
            this.grdAgr.Cols = 10;
            this.grdAgr.DataMember = "";
            this.grdAgr.DataSource = null;
            this.grdAgr.EnableEdicion = false;
            this.grdAgr.Encabezado = "";
            this.grdAgr.fColor = System.Drawing.SystemColors.Control;
            this.grdAgr.FixCols = 0;
            this.grdAgr.FixRows = 0;
            this.grdAgr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAgr.FuenteEncabezado = null;
            this.grdAgr.FuentePieDePagina = null;
            this.grdAgr.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAgr.Location = new System.Drawing.Point(3, 31);
            this.grdAgr.Name = "grdAgr";
            this.grdAgr.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAgr.PintarFilaSel = false;
            this.grdAgr.Redraw = true;
            this.grdAgr.Row = 0;
            this.grdAgr.Rows = 50;
            this.grdAgr.Size = new System.Drawing.Size(582, 656);
            this.grdAgr.TabIndex = 5;
            this.grdAgr.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdAgr_CambioFila);
            this.grdAgr.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdAgr_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(-1, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Compras P2";
            // 
            // chConSaldo
            // 
            this.chConSaldo.AutoSize = true;
            this.chConSaldo.Checked = true;
            this.chConSaldo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chConSaldo.Depth = 0;
            this.chConSaldo.Font = new System.Drawing.Font("Roboto", 10F);
            this.chConSaldo.Location = new System.Drawing.Point(1, 309);
            this.chConSaldo.Margin = new System.Windows.Forms.Padding(0);
            this.chConSaldo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chConSaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.chConSaldo.Name = "chConSaldo";
            this.chConSaldo.Ripple = true;
            this.chConSaldo.Size = new System.Drawing.Size(91, 30);
            this.chConSaldo.TabIndex = 6;
            this.chConSaldo.Text = "Con saldo";
            this.chConSaldo.UseVisualStyleBackColor = true;
            this.chConSaldo.CheckedChanged += new System.EventHandler(this.chConSaldo_CheckedChanged);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(5, 3);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(100, 243);
            this.cFecha.TabIndex = 5;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalle.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDetalle.AutoResize = false;
            this.grdDetalle.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalle.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalle.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalle.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalle.Col = 0;
            this.grdDetalle.Cols = 10;
            this.grdDetalle.DataMember = "";
            this.grdDetalle.DataSource = null;
            this.grdDetalle.EnableEdicion = false;
            this.grdDetalle.Encabezado = "";
            this.grdDetalle.fColor = System.Drawing.SystemColors.Control;
            this.grdDetalle.FixCols = 0;
            this.grdDetalle.FixRows = 0;
            this.grdDetalle.FuenteEncabezado = null;
            this.grdDetalle.FuentePieDePagina = null;
            this.grdDetalle.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalle.Location = new System.Drawing.Point(188, 6);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = false;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 0;
            this.grdDetalle.Rows = 50;
            this.grdDetalle.Size = new System.Drawing.Size(624, 80);
            this.grdDetalle.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmdActualizar);
            this.panel2.Location = new System.Drawing.Point(1266, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 79);
            this.panel2.TabIndex = 3;
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdActualizar.Location = new System.Drawing.Point(0, 0);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(187, 79);
            this.cmdActualizar.TabIndex = 0;
            this.cmdActualizar.Texto = "Actualizar";
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.cmbnvaBoleta);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 80);
            this.panel1.TabIndex = 2;
            // 
            // cmbnvaBoleta
            // 
            this.cmbnvaBoleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbnvaBoleta.Location = new System.Drawing.Point(0, 0);
            this.cmbnvaBoleta.Name = "cmbnvaBoleta";
            this.cmbnvaBoleta.Size = new System.Drawing.Size(170, 80);
            this.cmbnvaBoleta.TabIndex = 1;
            this.cmbnvaBoleta.Texto = "Generar Boleta";
            this.cmbnvaBoleta.Click += new System.EventHandler(this.cmbnvaBoleta_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.chFecha);
            this.splitContainer3.Panel2.Controls.Add(this.panel3);
            this.splitContainer3.Panel2.Controls.Add(this.chConSaldo);
            this.splitContainer3.Size = new System.Drawing.Size(1456, 690);
            this.splitContainer3.SplitterDistance = 1344;
            this.splitContainer3.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.cFecha);
            this.panel3.Location = new System.Drawing.Point(1, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 249);
            this.panel3.TabIndex = 7;
            // 
            // chFecha
            // 
            this.chFecha.AutoSize = true;
            this.chFecha.Checked = true;
            this.chFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFecha.Depth = 0;
            this.chFecha.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFecha.Location = new System.Drawing.Point(1, 279);
            this.chFecha.Margin = new System.Windows.Forms.Padding(0);
            this.chFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFecha.Name = "chFecha";
            this.chFecha.Ripple = true;
            this.chFecha.Size = new System.Drawing.Size(107, 30);
            this.chFecha.TabIndex = 8;
            this.chFecha.Text = "Filtrar Fecha";
            this.chFecha.UseVisualStyleBackColor = true;
            this.chFecha.CheckedChanged += new System.EventHandler(this.chFecha_CheckedChanged);
            // 
            // frmVencimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 780);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmVencimientos";
            this.Text = "Vencimientos";
            this.splitContainer1.Panel1.ResumeLayout(false);
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
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Label label1;
        private Controles.cBoton cmdActualizar;
        private Grilla2.SpeedGrilla grdAgr;
        private System.Windows.Forms.Label label2;
        private Controles.cBoton cmbnvaBoleta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Grilla2.SpeedGrilla grdDetalle;
        private MaterialSkin.Controls.MaterialCheckBox chConSaldo;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialCheckBox chFecha;
    }
}