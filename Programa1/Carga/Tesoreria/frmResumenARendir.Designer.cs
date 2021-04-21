
namespace Programa1.Carga.Tesoreria
{
    partial class frmResumenARendir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumenARendir));
            this.grdSalidas = new Grilla2.SpeedGrilla();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstARendir = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdGastos = new Grilla2.SpeedGrilla();
            this.lblEntradas = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTEntradas = new MaterialSkin.Controls.MaterialLabel();
            this.lblTGastos = new MaterialSkin.Controls.MaterialLabel();
            this.lblSaldo = new MaterialSkin.Controls.MaterialLabel();
            this.cFecha = new Programa1.Controles.cFechas();
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
            this.grdSalidas.Col = -2;
            this.grdSalidas.Cols = 0;
            this.grdSalidas.DataMember = "";
            this.grdSalidas.DataSource = null;
            this.grdSalidas.EnableEdicion = false;
            this.grdSalidas.Encabezado = "";
            this.grdSalidas.fColor = System.Drawing.SystemColors.Control;
            this.grdSalidas.FixCols = 0;
            this.grdSalidas.FixRows = 0;
            this.grdSalidas.FuenteEncabezado = null;
            this.grdSalidas.FuentePieDePagina = null;
            this.grdSalidas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalidas.Location = new System.Drawing.Point(3, 23);
            this.grdSalidas.MenuActivado = false;
            this.grdSalidas.Name = "grdSalidas";
            this.grdSalidas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalidas.PintarFilaSel = true;
            this.grdSalidas.Redraw = true;
            this.grdSalidas.Row = 0;
            this.grdSalidas.Rows = 50;
            this.grdSalidas.Size = new System.Drawing.Size(171, 479);
            this.grdSalidas.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblSaldo);
            this.splitContainer1.Panel2.Controls.Add(this.lstARendir);
            this.splitContainer1.Panel2.Controls.Add(this.cFecha);
            this.splitContainer1.Size = new System.Drawing.Size(1135, 530);
            this.splitContainer1.SplitterDistance = 869;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // lstARendir
            // 
            this.lstARendir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstARendir.BackColor = System.Drawing.Color.White;
            this.lstARendir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstARendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstARendir.FormattingEnabled = true;
            this.lstARendir.ItemHeight = 20;
            this.lstARendir.Location = new System.Drawing.Point(3, 240);
            this.lstARendir.Name = "lstARendir";
            this.lstARendir.Size = new System.Drawing.Size(252, 240);
            this.lstARendir.TabIndex = 7;
            this.lstARendir.SelectedIndexChanged += new System.EventHandler(this.lstARendir_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblTEntradas);
            this.splitContainer2.Panel1.Controls.Add(this.lblEntradas);
            this.splitContainer2.Panel1.Controls.Add(this.grdSalidas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblTGastos);
            this.splitContainer2.Panel2.Controls.Add(this.materialLabel1);
            this.splitContainer2.Panel2.Controls.Add(this.grdGastos);
            this.splitContainer2.Size = new System.Drawing.Size(869, 530);
            this.splitContainer2.SplitterDistance = 177;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
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
            this.grdGastos.Col = -2;
            this.grdGastos.Cols = 0;
            this.grdGastos.DataMember = "";
            this.grdGastos.DataSource = null;
            this.grdGastos.EnableEdicion = false;
            this.grdGastos.Encabezado = "";
            this.grdGastos.fColor = System.Drawing.SystemColors.Control;
            this.grdGastos.FixCols = 0;
            this.grdGastos.FixRows = 0;
            this.grdGastos.FuenteEncabezado = null;
            this.grdGastos.FuentePieDePagina = null;
            this.grdGastos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGastos.Location = new System.Drawing.Point(3, 21);
            this.grdGastos.MenuActivado = false;
            this.grdGastos.Name = "grdGastos";
            this.grdGastos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGastos.PintarFilaSel = true;
            this.grdGastos.Redraw = true;
            this.grdGastos.Row = 0;
            this.grdGastos.Rows = 50;
            this.grdGastos.Size = new System.Drawing.Size(678, 481);
            this.grdGastos.TabIndex = 2;
            // 
            // lblEntradas
            // 
            this.lblEntradas.BackColor = System.Drawing.SystemColors.Control;
            this.lblEntradas.Depth = 0;
            this.lblEntradas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEntradas.Location = new System.Drawing.Point(0, 0);
            this.lblEntradas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(177, 20);
            this.lblEntradas.TabIndex = 2;
            this.lblEntradas.Text = "Entradas";
            this.lblEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(0, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(684, 20);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Gastos";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTEntradas
            // 
            this.lblTEntradas.Depth = 0;
            this.lblTEntradas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTEntradas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTEntradas.Location = new System.Drawing.Point(0, 505);
            this.lblTEntradas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTEntradas.Name = "lblTEntradas";
            this.lblTEntradas.Size = new System.Drawing.Size(177, 25);
            this.lblTEntradas.TabIndex = 3;
            this.lblTEntradas.Text = "Total:";
            this.lblTEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTGastos
            // 
            this.lblTGastos.Depth = 0;
            this.lblTGastos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTGastos.Location = new System.Drawing.Point(0, 505);
            this.lblTGastos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTGastos.Name = "lblTGastos";
            this.lblTGastos.Size = new System.Drawing.Size(684, 25);
            this.lblTGastos.TabIndex = 4;
            this.lblTGastos.Text = "Total:";
            this.lblTGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Depth = 0;
            this.lblSaldo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSaldo.Location = new System.Drawing.Point(0, 505);
            this.lblSaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(258, 25);
            this.lblSaldo.TabIndex = 8;
            this.lblSaldo.Text = "Saldo";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 3;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(258, 203);
            this.cFecha.TabIndex = 0;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // frmResumenARendir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 547);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmResumenARendir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A Rendir";
            this.Load += new System.EventHandler(this.frm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.cFechas cFecha;
        private Grilla2.SpeedGrilla grdSalidas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ListBox lstARendir;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdGastos;
        private MaterialSkin.Controls.MaterialLabel lblEntradas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblTEntradas;
        private MaterialSkin.Controls.MaterialLabel lblTGastos;
        private MaterialSkin.Controls.MaterialLabel lblSaldo;
    }
}