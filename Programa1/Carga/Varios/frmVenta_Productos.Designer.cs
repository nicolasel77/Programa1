
namespace Programa1.Carga.Varios
{
    partial class frmVenta_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVenta_Productos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.nuSemanas = new System.Windows.Forms.NumericUpDown();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cProductos1 = new Programa1.Controles.cProductos();
            this.cSuc = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSemanas)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.nuSemanas);
            this.splitContainer1.Panel2.Controls.Add(this.lstSemanas);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1515, 726);
            this.splitContainer1.SplitterDistance = 1074;
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
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.MenuActivado = false;
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(1049, 702);
            this.grd.TabIndex = 0;
            // 
            // nuSemanas
            // 
            this.nuSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSemanas.Location = new System.Drawing.Point(385, 694);
            this.nuSemanas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuSemanas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuSemanas.Name = "nuSemanas";
            this.nuSemanas.Size = new System.Drawing.Size(41, 25);
            this.nuSemanas.TabIndex = 4;
            this.nuSemanas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
            this.lstSemanas.Location = new System.Drawing.Point(317, 6);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.Size = new System.Drawing.Size(109, 680);
            this.lstSemanas.TabIndex = 3;
            this.lstSemanas.SelectedIndexChanged += new System.EventHandler(this.lstSemanas_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cProductos1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cSuc);
            this.splitContainer2.Size = new System.Drawing.Size(308, 723);
            this.splitContainer2.SplitterDistance = 324;
            this.splitContainer2.TabIndex = 2;
            // 
            // cProductos1
            // 
            this.cProductos1.BackColor = System.Drawing.Color.Gainsboro;
            this.cProductos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProductos1.Filtrar_Ver = true;
            this.cProductos1.Filtro_In = "";
            this.cProductos1.Location = new System.Drawing.Point(0, 0);
            this.cProductos1.Mostrar_Tipo = true;
            this.cProductos1.Name = "cProductos1";
            this.cProductos1.Size = new System.Drawing.Size(308, 324);
            this.cProductos1.TabIndex = 0;
            this.cProductos1.Titulo = "Productos";
            this.cProductos1.Valor_Actual = -1;
            this.cProductos1.Cambio_Seleccion += new System.EventHandler(this.cProductos1_Cambio_Seleccion);
            // 
            // cSuc
            // 
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(0, 0);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.One;
            this.cSuc.Size = new System.Drawing.Size(308, 395);
            this.cSuc.TabIndex = 1;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.cSucursales1_Cambio_Seleccion);
            // 
            // frmVenta_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 726);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmVenta_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta Productos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuSemanas)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cProductos cProductos1;
        private Controles.cSucursales cSuc;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.ListBox lstSemanas;
        private System.Windows.Forms.NumericUpDown nuSemanas;
    }
}