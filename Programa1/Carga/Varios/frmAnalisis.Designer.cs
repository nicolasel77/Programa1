namespace Programa1.Carga.Varios
{

    partial class frmAnalisis
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
            this.nuCant = new System.Windows.Forms.NumericUpDown();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.cFecha = new Programa1.Controles.cFechas();
            this.lblGastoEmpresa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.grd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblGastoEmpresa);
            this.splitContainer1.Panel2.Controls.Add(this.nuCant);
            this.splitContainer1.Panel2.Controls.Add(this.cSuc);
            this.splitContainer1.Panel2.Controls.Add(this.cFecha);
            this.splitContainer1.Size = new System.Drawing.Size(1316, 689);
            this.splitContainer1.SplitterDistance = 889;
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
            this.grd.Size = new System.Drawing.Size(846, 655);
            this.grd.TabIndex = 0;
            // 
            // nuCant
            // 
            this.nuCant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuCant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuCant.Location = new System.Drawing.Point(18, 655);
            this.nuCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuCant.Name = "nuCant";
            this.nuCant.Size = new System.Drawing.Size(73, 22);
            this.nuCant.TabIndex = 2;
            this.nuCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuCant.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(8, 8);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSuc.Size = new System.Drawing.Size(399, 431);
            this.cSuc.TabIndex = 1;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(8, 445);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(399, 204);
            this.cFecha.TabIndex = 0;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFechas1_Cambio_Seleccion);
            // 
            // lblGastoEmpresa
            // 
            this.lblGastoEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGastoEmpresa.AutoSize = true;
            this.lblGastoEmpresa.Location = new System.Drawing.Point(97, 659);
            this.lblGastoEmpresa.Name = "lblGastoEmpresa";
            this.lblGastoEmpresa.Size = new System.Drawing.Size(79, 13);
            this.lblGastoEmpresa.TabIndex = 3;
            this.lblGastoEmpresa.Text = "Gasto Empresa";
            this.lblGastoEmpresa.Click += new System.EventHandler(this.lblGastoEmpresa_Click);
            // 
            // frmAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 689);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAnalisis";
            this.Text = "Analisis";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grd;
        private Controles.cSucursales cSuc;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.NumericUpDown nuCant;
        private System.Windows.Forms.Label lblGastoEmpresa;
    }
}