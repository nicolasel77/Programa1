
namespace Programa1.Carga.Tesoreria
{
    partial class frmPagos_Autorizados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagos_Autorizados));
            this.grdAutorizados = new Grilla2.SpeedGrilla();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lstFiltros = new System.Windows.Forms.ListBox();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdRefresh = new Programa1.Controles.cBoton();
            this.SuspendLayout();
            // 
            // grdAutorizados
            // 
            this.grdAutorizados.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAutorizados.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAutorizados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAutorizados.AutoResize = false;
            this.grdAutorizados.bColor = System.Drawing.SystemColors.Window;
            this.grdAutorizados.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAutorizados.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAutorizados.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAutorizados.Col = 0;
            this.grdAutorizados.Cols = 10;
            this.grdAutorizados.DataMember = "";
            this.grdAutorizados.DataSource = null;
            this.grdAutorizados.EnableEdicion = true;
            this.grdAutorizados.Encabezado = "";
            this.grdAutorizados.fColor = System.Drawing.SystemColors.Control;
            this.grdAutorizados.FixCols = 0;
            this.grdAutorizados.FixRows = 0;
            this.grdAutorizados.FuenteEncabezado = null;
            this.grdAutorizados.FuentePieDePagina = null;
            this.grdAutorizados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAutorizados.Location = new System.Drawing.Point(12, 31);
            this.grdAutorizados.Name = "grdAutorizados";
            this.grdAutorizados.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAutorizados.PintarFilaSel = false;
            this.grdAutorizados.Redraw = true;
            this.grdAutorizados.Row = 0;
            this.grdAutorizados.Rows = 1;
            this.grdAutorizados.Size = new System.Drawing.Size(1162, 459);
            this.grdAutorizados.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(134, 18);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Pagos Autorizados";
            // 
            // lstFiltros
            // 
            this.lstFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiltros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstFiltros.ForeColor = System.Drawing.Color.DimGray;
            this.lstFiltros.FormattingEnabled = true;
            this.lstFiltros.ItemHeight = 20;
            this.lstFiltros.Items.AddRange(new object[] {
            "0. Proveedores",
            "1. P1 Hacienda",
            "2. P2 Hacienda",
            "3. Empleados"});
            this.lstFiltros.Location = new System.Drawing.Point(1180, 31);
            this.lstFiltros.Name = "lstFiltros";
            this.lstFiltros.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFiltros.Size = new System.Drawing.Size(198, 260);
            this.lstFiltros.TabIndex = 4;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(1180, 464);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(198, 26);
            this.cmdImprimir.TabIndex = 2;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.Location = new System.Drawing.Point(1180, 297);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(198, 26);
            this.cmdRefresh.TabIndex = 2;
            this.cmdRefresh.Texto = "Actualizar";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // frmPagos_Autorizados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 502);
            this.Controls.Add(this.lstFiltros);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.grdAutorizados);
            this.Controls.Add(this.materialLabel1);
            this.Name = "frmPagos_Autorizados";
            this.Text = "Pagos Autorizados";
            this.Load += new System.EventHandler(this.frmPagos_Autorizados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdAutorizados;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Controles.cBoton cmdRefresh;
        private Controles.cBoton cmdImprimir;
        private System.Windows.Forms.ListBox lstFiltros;
    }
}