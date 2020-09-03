namespace Programa1.Carga
{
    partial class frmResumen_Proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumen_Proveedores));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.grdEntradas = new Grilla2.SpeedGrilla();
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grdProv = new Grilla2.SpeedGrilla();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalEntradas = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblTotalSalidas = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSaldoAnt = new System.Windows.Forms.Label();
            this.lblCompras = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.lblDevoluciones = new System.Windows.Forms.Label();
            this.lblAjustes = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.cFechas1 = new Programa1.Controles.cFechas();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1088, 607);
            this.splitContainer1.SplitterDistance = 825;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.lblSaldo);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.lblAjustes);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.lblDevoluciones);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.lblPagos);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.lblCompras);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.lblSaldoAnt);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(825, 607);
            this.splitContainer2.SplitterDistance = 470;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.statusStrip1);
            this.splitContainer4.Panel1.Controls.Add(this.grdEntradas);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.statusStrip2);
            this.splitContainer4.Panel2.Controls.Add(this.grdSalidas);
            this.splitContainer4.Size = new System.Drawing.Size(825, 470);
            this.splitContainer4.SplitterDistance = 443;
            this.splitContainer4.TabIndex = 0;
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
            this.grdEntradas.Cols = 10;
            this.grdEntradas.DataMember = "";
            this.grdEntradas.DataSource = null;
            this.grdEntradas.EnableEdicion = true;
            this.grdEntradas.Encabezado = "";
            this.grdEntradas.fColor = System.Drawing.SystemColors.Control;
            this.grdEntradas.FixCols = 0;
            this.grdEntradas.FixRows = 0;
            this.grdEntradas.FuenteEncabezado = null;
            this.grdEntradas.FuentePieDePagina = null;
            this.grdEntradas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEntradas.Location = new System.Drawing.Point(0, 0);
            this.grdEntradas.MenuActivado = false;
            this.grdEntradas.Name = "grdEntradas";
            this.grdEntradas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEntradas.PintarFilaSel = true;
            this.grdEntradas.Redraw = true;
            this.grdEntradas.Row = 0;
            this.grdEntradas.Rows = 50;
            this.grdEntradas.Size = new System.Drawing.Size(443, 384);
            this.grdEntradas.TabIndex = 0;
            // 
            // grdSalidas
            // 
            this.grdSalidas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSalidas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSalidas.AutoResize = false;
            this.grdSalidas.bColor = System.Drawing.SystemColors.Window;
            this.grdSalidas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSalidas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSalidas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSalidas.Col = 0;
            this.grdSalidas.Cols = 10;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = true;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.Location = new System.Drawing.Point(0, 0);
            this.grdSalidas.MenuActivado = false;
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 50;
            this.grdSalidas.Size = new System.Drawing.Size(378, 384);
            this.grdSalidas.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.grdProv);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer3.Size = new System.Drawing.Size(259, 607);
            this.splitContainer3.SplitterDistance = 366;
            this.splitContainer3.TabIndex = 0;
            // 
            // grdProv
            // 
            this.grdProv.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProv.AutoResize = false;
            this.grdProv.bColor = System.Drawing.SystemColors.Window;
            this.grdProv.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProv.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProv.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProv.Col = 0;
            this.grdProv.Cols = 10;
            this.grdProv.DataMember = "";
            this.grdProv.DataSource = null;
            this.grdProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProv.EnableEdicion = false;
            this.grdProv.Encabezado = "";
            this.grdProv.fColor = System.Drawing.SystemColors.Control;
            this.grdProv.FixCols = 0;
            this.grdProv.FixRows = 0;
            this.grdProv.FuenteEncabezado = null;
            this.grdProv.FuentePieDePagina = null;
            this.grdProv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProv.Location = new System.Drawing.Point(0, 0);
            this.grdProv.MenuActivado = false;
            this.grdProv.Name = "grdProv";
            this.grdProv.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProv.PintarFilaSel = true;
            this.grdProv.Redraw = true;
            this.grdProv.Row = 0;
            this.grdProv.Rows = 50;
            this.grdProv.Size = new System.Drawing.Size(259, 366);
            this.grdProv.TabIndex = 0;
            this.grdProv.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdProv_CambioFila);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalEntradas});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(42, 21);
            this.lblTotalEntradas.Text = "Total";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalSalidas});
            this.statusStrip2.Location = new System.Drawing.Point(0, 444);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(378, 26);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblTotalSalidas
            // 
            this.lblTotalSalidas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalidas.Name = "lblTotalSalidas";
            this.lblTotalSalidas.Size = new System.Drawing.Size(42, 21);
            this.lblTotalSalidas.Text = "Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Anterior:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Compras:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Pagos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Devoluciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Ajustes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Saldo:";
            // 
            // lblSaldoAnt
            // 
            this.lblSaldoAnt.Location = new System.Drawing.Point(112, 9);
            this.lblSaldoAnt.Name = "lblSaldoAnt";
            this.lblSaldoAnt.Size = new System.Drawing.Size(106, 13);
            this.lblSaldoAnt.TabIndex = 0;
            this.lblSaldoAnt.Text = "0";
            this.lblSaldoAnt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCompras
            // 
            this.lblCompras.Location = new System.Drawing.Point(112, 30);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(106, 13);
            this.lblCompras.TabIndex = 0;
            this.lblCompras.Text = "0";
            this.lblCompras.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPagos
            // 
            this.lblPagos.Location = new System.Drawing.Point(112, 51);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(106, 13);
            this.lblPagos.TabIndex = 0;
            this.lblPagos.Text = "0";
            this.lblPagos.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDevoluciones
            // 
            this.lblDevoluciones.Location = new System.Drawing.Point(112, 72);
            this.lblDevoluciones.Name = "lblDevoluciones";
            this.lblDevoluciones.Size = new System.Drawing.Size(106, 13);
            this.lblDevoluciones.TabIndex = 0;
            this.lblDevoluciones.Text = "0";
            this.lblDevoluciones.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblAjustes
            // 
            this.lblAjustes.Location = new System.Drawing.Point(112, 93);
            this.lblAjustes.Name = "lblAjustes";
            this.lblAjustes.Size = new System.Drawing.Size(106, 13);
            this.lblAjustes.TabIndex = 0;
            this.lblAjustes.Text = "0";
            this.lblAjustes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Location = new System.Drawing.Point(112, 114);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(106, 13);
            this.lblSaldo.TabIndex = 0;
            this.lblSaldo.Text = "0";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cFechas1
            // 
            this.cFechas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(0, 0);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(259, 237);
            this.cFechas1.TabIndex = 0;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechas1.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // frmResumen_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1093, 613);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResumen_Proveedores";
            this.Text = "Resumen Proveedores";
            this.Load += new System.EventHandler(this.frmResumen_Proveedores_Load);
            this.Resize += new System.EventHandler(this.frmResumen_Proveedores_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Grilla2.SpeedGrilla grdEntradas;
        private Grilla2.SpeedGrilla grdSalidas;
        private Controles.cFechas cFechas1;
        private Grilla2.SpeedGrilla grdProv;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalEntradas;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalSalidas;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAjustes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDevoluciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSaldoAnt;
        private System.Windows.Forms.Label label1;
    }
}