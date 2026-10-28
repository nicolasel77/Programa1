namespace Programa1.Carga.Sucursales
{
    partial class frmValorFranquicia
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
            this.grd = new Grilla2.SpeedGrilla();
            this.grdImpuestos = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdGastos = new Grilla2.SpeedGrilla();
            this.label3 = new System.Windows.Forms.Label();
            this.grdCargasSociales = new Grilla2.SpeedGrilla();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.grd.Location = new System.Drawing.Point(12, 31);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(373, 693);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            // 
            // grdImpuestos
            // 
            this.grdImpuestos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdImpuestos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdImpuestos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdImpuestos.AutoResize = false;
            this.grdImpuestos.bColor = System.Drawing.SystemColors.Window;
            this.grdImpuestos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdImpuestos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdImpuestos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdImpuestos.Col = 0;
            this.grdImpuestos.Cols = 10;
            this.grdImpuestos.DataMember = "";
            this.grdImpuestos.DataSource = null;
            this.grdImpuestos.EnableEdicion = true;
            this.grdImpuestos.Encabezado = "";
            this.grdImpuestos.fColor = System.Drawing.Color.Silver;
            this.grdImpuestos.FixCols = 0;
            this.grdImpuestos.FixRows = 0;
            this.grdImpuestos.Frozen = 0;
            this.grdImpuestos.FuenteEncabezado = null;
            this.grdImpuestos.FuentePieDePagina = null;
            this.grdImpuestos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdImpuestos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdImpuestos.Location = new System.Drawing.Point(404, 31);
            this.grdImpuestos.Name = "grdImpuestos";
            this.grdImpuestos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdImpuestos.PintarFilaSel = true;
            this.grdImpuestos.Redraw = true;
            this.grdImpuestos.Row = 0;
            this.grdImpuestos.Rows = 50;
            this.grdImpuestos.Size = new System.Drawing.Size(373, 693);
            this.grdImpuestos.TabIndex = 0;
            this.grdImpuestos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdImpuestos_Editado);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Franquicia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(401, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Impuestos";
            // 
            // grdGastos
            // 
            this.grdGastos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdGastos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdGastos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdGastos.AutoResize = false;
            this.grdGastos.bColor = System.Drawing.SystemColors.Window;
            this.grdGastos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdGastos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdGastos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdGastos.Col = 0;
            this.grdGastos.Cols = 10;
            this.grdGastos.DataMember = "";
            this.grdGastos.DataSource = null;
            this.grdGastos.EnableEdicion = true;
            this.grdGastos.Encabezado = "";
            this.grdGastos.fColor = System.Drawing.Color.Silver;
            this.grdGastos.FixCols = 0;
            this.grdGastos.FixRows = 0;
            this.grdGastos.Frozen = 0;
            this.grdGastos.FuenteEncabezado = null;
            this.grdGastos.FuentePieDePagina = null;
            this.grdGastos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGastos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdGastos.Location = new System.Drawing.Point(796, 31);
            this.grdGastos.Name = "grdGastos";
            this.grdGastos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGastos.PintarFilaSel = true;
            this.grdGastos.Redraw = true;
            this.grdGastos.Row = 0;
            this.grdGastos.Rows = 50;
            this.grdGastos.Size = new System.Drawing.Size(373, 693);
            this.grdGastos.TabIndex = 0;
            this.grdGastos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdGastos_Editado);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(793, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gastos";
            // 
            // grdCargasSociales
            // 
            this.grdCargasSociales.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCargasSociales.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCargasSociales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdCargasSociales.AutoResize = false;
            this.grdCargasSociales.bColor = System.Drawing.SystemColors.Window;
            this.grdCargasSociales.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCargasSociales.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCargasSociales.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCargasSociales.Col = 0;
            this.grdCargasSociales.Cols = 10;
            this.grdCargasSociales.DataMember = "";
            this.grdCargasSociales.DataSource = null;
            this.grdCargasSociales.EnableEdicion = true;
            this.grdCargasSociales.Encabezado = "";
            this.grdCargasSociales.fColor = System.Drawing.Color.Silver;
            this.grdCargasSociales.FixCols = 0;
            this.grdCargasSociales.FixRows = 0;
            this.grdCargasSociales.Frozen = 0;
            this.grdCargasSociales.FuenteEncabezado = null;
            this.grdCargasSociales.FuentePieDePagina = null;
            this.grdCargasSociales.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCargasSociales.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCargasSociales.Location = new System.Drawing.Point(1186, 31);
            this.grdCargasSociales.Name = "grdCargasSociales";
            this.grdCargasSociales.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCargasSociales.PintarFilaSel = true;
            this.grdCargasSociales.Redraw = true;
            this.grdCargasSociales.Row = 0;
            this.grdCargasSociales.Rows = 50;
            this.grdCargasSociales.Size = new System.Drawing.Size(373, 693);
            this.grdCargasSociales.TabIndex = 0;
            this.grdCargasSociales.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdCargasSociales_Editado);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(1183, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cargas Sociales";
            // 
            // frmValorFranquicia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 736);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdCargasSociales);
            this.Controls.Add(this.grdGastos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdImpuestos);
            this.Controls.Add(this.grd);
            this.Name = "frmValorFranquicia";
            this.Text = "Valor Franquicia";
            this.Load += new System.EventHandler(this.frmValorFranquicia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grd;
        private Grilla2.SpeedGrilla grdImpuestos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Grilla2.SpeedGrilla grdGastos;
        private System.Windows.Forms.Label label3;
        private Grilla2.SpeedGrilla grdCargasSociales;
        private System.Windows.Forms.Label label4;
    }
}