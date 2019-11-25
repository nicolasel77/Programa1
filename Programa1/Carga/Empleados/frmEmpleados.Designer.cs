namespace Programa1.Carga.Empleados
{
    partial class frmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleados));
            this.grdEmpleados = new Grilla2.SpeedGrilla();
            this.chMostrarBajas = new MaterialSkin.Controls.MaterialCheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cSuc = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEmpleados
            // 
            this.grdEmpleados.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEmpleados.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEmpleados.AutoResize = false;
            this.grdEmpleados.bColor = System.Drawing.SystemColors.Window;
            this.grdEmpleados.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEmpleados.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEmpleados.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEmpleados.Col = 0;
            this.grdEmpleados.Cols = 10;
            this.grdEmpleados.DataMember = "";
            this.grdEmpleados.DataSource = null;
            this.grdEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEmpleados.EnableEdicion = true;
            this.grdEmpleados.Encabezado = "";
            this.grdEmpleados.fColor = System.Drawing.SystemColors.Control;
            this.grdEmpleados.FixCols = 0;
            this.grdEmpleados.FixRows = 0;
            this.grdEmpleados.FuenteEncabezado = null;
            this.grdEmpleados.FuentePieDePagina = null;
            this.grdEmpleados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEmpleados.Location = new System.Drawing.Point(0, 0);
            this.grdEmpleados.MenuActivado = false;
            this.grdEmpleados.Name = "grdEmpleados";
            this.grdEmpleados.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEmpleados.PintarFilaSel = true;
            this.grdEmpleados.Redraw = true;
            this.grdEmpleados.Row = 0;
            this.grdEmpleados.Rows = 50;
            this.grdEmpleados.Size = new System.Drawing.Size(1020, 712);
            this.grdEmpleados.TabIndex = 0;
            // 
            // chMostrarBajas
            // 
            this.chMostrarBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chMostrarBajas.AutoSize = true;
            this.chMostrarBajas.Depth = 0;
            this.chMostrarBajas.Font = new System.Drawing.Font("Roboto", 10F);
            this.chMostrarBajas.Location = new System.Drawing.Point(0, 682);
            this.chMostrarBajas.Margin = new System.Windows.Forms.Padding(0);
            this.chMostrarBajas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chMostrarBajas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chMostrarBajas.Name = "chMostrarBajas";
            this.chMostrarBajas.Ripple = true;
            this.chMostrarBajas.Size = new System.Drawing.Size(116, 30);
            this.chMostrarBajas.TabIndex = 2;
            this.chMostrarBajas.Text = "Mostrar Bajas";
            this.chMostrarBajas.UseVisualStyleBackColor = true;
            this.chMostrarBajas.CheckedChanged += new System.EventHandler(this.ChMostrarBajas_CheckedChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.grdEmpleados);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cSuc);
            this.splitContainer1.Panel2.Controls.Add(this.chMostrarBajas);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 712);
            this.splitContainer1.SplitterDistance = 1020;
            this.splitContainer1.TabIndex = 3;
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(0, 0);
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.Size = new System.Drawing.Size(235, 534);
            this.cSuc.TabIndex = 3;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.CSuc_Cambio_Seleccion);
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 736);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpleados";
            this.Text = "Empleados";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdEmpleados;
        private MaterialSkin.Controls.MaterialCheckBox chMostrarBajas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.cSucursales cSuc;
    }
}