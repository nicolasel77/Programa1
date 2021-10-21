namespace Programa1.Carga.Sucursales
{

    partial class frmEditar_Suc_Ofertas
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
            this.grdLugar_Imp = new Grilla2.SpeedGrilla();
            this.SuspendLayout();
            // 
            // grdLugar_Imp
            // 
            this.grdLugar_Imp.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdLugar_Imp.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdLugar_Imp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLugar_Imp.AutoResize = false;
            this.grdLugar_Imp.bColor = System.Drawing.SystemColors.Window;
            this.grdLugar_Imp.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdLugar_Imp.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdLugar_Imp.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdLugar_Imp.Col = 0;
            this.grdLugar_Imp.Cols = 10;
            this.grdLugar_Imp.DataMember = "";
            this.grdLugar_Imp.DataSource = null;
            this.grdLugar_Imp.EnableEdicion = true;
            this.grdLugar_Imp.Encabezado = "";
            this.grdLugar_Imp.fColor = System.Drawing.Color.Silver;
            this.grdLugar_Imp.FixCols = 0;
            this.grdLugar_Imp.FixRows = 0;
            this.grdLugar_Imp.FuenteEncabezado = null;
            this.grdLugar_Imp.FuentePieDePagina = null;
            this.grdLugar_Imp.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdLugar_Imp.Location = new System.Drawing.Point(12, 12);
            this.grdLugar_Imp.Name = "grdLugar_Imp";
            this.grdLugar_Imp.PieDePagina = "\t\tPage {0} of {1}";
            this.grdLugar_Imp.PintarFilaSel = true;
            this.grdLugar_Imp.Redraw = true;
            this.grdLugar_Imp.Row = 0;
            this.grdLugar_Imp.Rows = 50;
            this.grdLugar_Imp.Size = new System.Drawing.Size(168, 262);
            this.grdLugar_Imp.TabIndex = 0;
            this.grdLugar_Imp.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdLugar_Imp_Editado);
            this.grdLugar_Imp.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdLugar_Imp_CambioFila);
            // 
            // frmEditar_Suc_Ofertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 286);
            this.Controls.Add(this.grdLugar_Imp);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditar_Suc_Ofertas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Lugares de Impresión";
            this.Load += new System.EventHandler(this.frmEditar_Suc_Ofertas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEditar_Suc_Ofertas_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdLugar_Imp;
    }
}