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
            this.speedGrilla1 = new Grilla2.SpeedGrilla();
            this.cFechas1 = new Programa1.Controles.cFechas();
            this.cSucursales1 = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.speedGrilla1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cSucursales1);
            this.splitContainer1.Panel2.Controls.Add(this.cFechas1);
            this.splitContainer1.Size = new System.Drawing.Size(1316, 689);
            this.splitContainer1.SplitterDistance = 920;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // speedGrilla1
            // 
            this.speedGrilla1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.speedGrilla1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.speedGrilla1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedGrilla1.AutoResize = false;
            this.speedGrilla1.bColor = System.Drawing.SystemColors.Window;
            this.speedGrilla1.bColorSel = System.Drawing.SystemColors.Highlight;
            this.speedGrilla1.bFColor = System.Drawing.SystemColors.WindowText;
            this.speedGrilla1.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.speedGrilla1.Col = 0;
            this.speedGrilla1.Cols = 10;
            this.speedGrilla1.DataMember = "";
            this.speedGrilla1.DataSource = null;
            this.speedGrilla1.EnableEdicion = true;
            this.speedGrilla1.Encabezado = "";
            this.speedGrilla1.fColor = System.Drawing.Color.Silver;
            this.speedGrilla1.FixCols = 0;
            this.speedGrilla1.FixRows = 0;
            this.speedGrilla1.FuenteEncabezado = null;
            this.speedGrilla1.FuentePieDePagina = null;
            this.speedGrilla1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.speedGrilla1.Location = new System.Drawing.Point(12, 12);
            this.speedGrilla1.Name = "speedGrilla1";
            this.speedGrilla1.PieDePagina = "\t\tPage {0} of {1}";
            this.speedGrilla1.PintarFilaSel = true;
            this.speedGrilla1.Redraw = true;
            this.speedGrilla1.Row = 0;
            this.speedGrilla1.Rows = 50;
            this.speedGrilla1.Size = new System.Drawing.Size(905, 665);
            this.speedGrilla1.TabIndex = 0;
            // 
            // cFechas1
            // 
            this.cFechas1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cFechas1.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechas1.Location = new System.Drawing.Point(8, 493);
            this.cFechas1.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechas1.Mostrar = 0;
            this.cFechas1.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFechas1.Name = "cFechas1";
            this.cFechas1.Size = new System.Drawing.Size(369, 184);
            this.cFechas1.TabIndex = 0;
            this.cFechas1.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // cSucursales1
            // 
            this.cSucursales1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucursales1.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucursales1.Filtro_In = "";
            this.cSucursales1.Location = new System.Drawing.Point(8, 8);
            this.cSucursales1.Mostrar_Botones = true;
            this.cSucursales1.Mostrar_Tipo = false;
            this.cSucursales1.Name = "cSucursales1";
            this.cSucursales1.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucursales1.Size = new System.Drawing.Size(368, 482);
            this.cSucursales1.TabIndex = 1;
            this.cSucursales1.Titulo = "Sucursales";
            this.cSucursales1.Valor_Actual = -1;
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla speedGrilla1;
        private Controles.cSucursales cSucursales1;
        private Controles.cFechas cFechas1;
    }
}