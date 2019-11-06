namespace Programa1.Carga
{
    partial class frmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStock));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdStock = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cProds = new Programa1.Controles.cProductos();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 693);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grdStock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 693);
            this.splitContainer1.SplitterDistance = 867;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdStock
            // 
            this.grdStock.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdStock.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStock.AutoResize = false;
            this.grdStock.bColor = System.Drawing.SystemColors.Window;
            this.grdStock.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdStock.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdStock.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdStock.Col = 0;
            this.grdStock.Cols = 10;
            this.grdStock.DataMember = "";
            this.grdStock.DataSource = null;
            this.grdStock.EnableEdicion = true;
            this.grdStock.Encabezado = "";
            this.grdStock.fColor = System.Drawing.SystemColors.Control;
            this.grdStock.FixCols = 0;
            this.grdStock.FixRows = 0;
            this.grdStock.FuenteEncabezado = null;
            this.grdStock.FuentePieDePagina = null;
            this.grdStock.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdStock.Location = new System.Drawing.Point(12, 12);
            this.grdStock.MenuActivado = false;
            this.grdStock.Name = "grdStock";
            this.grdStock.PieDePagina = "\t\tPage {0} of {1}";
            this.grdStock.PintarFilaSel = true;
            this.grdStock.Redraw = true;
            this.grdStock.Row = 0;
            this.grdStock.Rows = 50;
            this.grdStock.Size = new System.Drawing.Size(852, 678);
            this.grdStock.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cFecha);
            this.splitContainer2.Panel2.Controls.Add(this.cmdMostrar);
            this.splitContainer2.Size = new System.Drawing.Size(487, 693);
            this.splitContainer2.SplitterDistance = 477;
            this.splitContainer2.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cProds);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cSucs);
            this.splitContainer3.Size = new System.Drawing.Size(487, 477);
            this.splitContainer3.SplitterDistance = 239;
            this.splitContainer3.TabIndex = 0;
            // 
            // cProds
            // 
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(0, 0);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(239, 477);
            this.cProds.TabIndex = 1;
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cSucs
            // 
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(0, 0);
            this.cSucs.Name = "cSucs";
            this.cSucs.Size = new System.Drawing.Size(244, 477);
            this.cSucs.TabIndex = 2;
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cFecha.Location = new System.Drawing.Point(3, 3);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(221, 206);
            this.cFecha.TabIndex = 3;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMostrar.Location = new System.Drawing.Point(382, 186);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(102, 23);
            this.cmdMostrar.TabIndex = 4;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Interval = 5000;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmStock";
            this.Text = "Stock";
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
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdStock;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cSucursales cSucs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}