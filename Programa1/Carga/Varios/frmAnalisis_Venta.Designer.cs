namespace Programa1.Carga.Varios
{
    partial class frmAnalisis_Venta
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cProds = new Programa1.Controles.cProductos();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.rdSucursales = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdProductos = new MaterialSkin.Controls.MaterialRadioButton();
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
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Controls.Add(this.lstSemanas);
            this.splitContainer1.Panel2.Controls.Add(this.rdSucursales);
            this.splitContainer1.Panel2.Controls.Add(this.rdProductos);
            this.splitContainer1.Size = new System.Drawing.Size(1372, 797);
            this.splitContainer1.SplitterDistance = 883;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
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
            this.grd.EnableEdicion = true;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.Color.Silver;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.Frozen = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.LimpiarEstilosAntesDeOrdenar = false;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(858, 773);
            this.grd.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(12, 45);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cProds);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cSucs);
            this.splitContainer2.Size = new System.Drawing.Size(340, 740);
            this.splitContainer2.SplitterDistance = 428;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 4;
            // 
            // cProds
            // 
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(0, 0);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(340, 428);
            this.cProds.TabIndex = 2;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.cProds_Cambio_Seleccion);
            // 
            // cSucs
            // 
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(0, 0);
            this.cSucs.Mostrar_Botones = true;
            this.cSucs.Mostrar_Tipo = true;
            this.cSucs.Name = "cSucs";
            this.cSucs.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucs.Size = new System.Drawing.Size(340, 304);
            this.cSucs.TabIndex = 3;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.cSucs_Cambio_Seleccion);
            // 
            // lstSemanas
            // 
            this.lstSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSemanas.FormattingEnabled = true;
            this.lstSemanas.ItemHeight = 20;
            this.lstSemanas.Items.AddRange(new object[] {
            "20/12/1977"});
            this.lstSemanas.Location = new System.Drawing.Point(358, 12);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.Size = new System.Drawing.Size(107, 760);
            this.lstSemanas.TabIndex = 1;
            this.lstSemanas.SelectedIndexChanged += new System.EventHandler(this.lstSemanas_SelectedIndexChanged);
            // 
            // rdSucursales
            // 
            this.rdSucursales.AutoSize = true;
            this.rdSucursales.Depth = 0;
            this.rdSucursales.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSucursales.Location = new System.Drawing.Point(149, 12);
            this.rdSucursales.Margin = new System.Windows.Forms.Padding(0);
            this.rdSucursales.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSucursales.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSucursales.Name = "rdSucursales";
            this.rdSucursales.Ripple = true;
            this.rdSucursales.Size = new System.Drawing.Size(122, 30);
            this.rdSucursales.TabIndex = 0;
            this.rdSucursales.Text = "Por Sucursales";
            this.rdSucursales.UseVisualStyleBackColor = true;
            // 
            // rdProductos
            // 
            this.rdProductos.AutoSize = true;
            this.rdProductos.Checked = true;
            this.rdProductos.Depth = 0;
            this.rdProductos.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdProductos.Location = new System.Drawing.Point(12, 12);
            this.rdProductos.Margin = new System.Windows.Forms.Padding(0);
            this.rdProductos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdProductos.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdProductos.Name = "rdProductos";
            this.rdProductos.Ripple = true;
            this.rdProductos.Size = new System.Drawing.Size(117, 30);
            this.rdProductos.TabIndex = 0;
            this.rdProductos.TabStop = true;
            this.rdProductos.Text = "Por Productos";
            this.rdProductos.UseVisualStyleBackColor = true;
            // 
            // frmAnalisis_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 797);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAnalisis_Venta";
            this.Text = "Analisis_Venta";
            this.Load += new System.EventHandler(this.Analisis_Venta_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
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
        private Grilla2.SpeedGrilla grd;
        private MaterialSkin.Controls.MaterialRadioButton rdSucursales;
        private MaterialSkin.Controls.MaterialRadioButton rdProductos;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cProductos cProds;
        private Controles.cSucursales cSucs;
        private System.Windows.Forms.ListBox lstSemanas;
    }
}