namespace Programa1.Carga
{
    partial class frmCopiarVentaACompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopiarVentaACompra));
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.chAgrupar = new MaterialSkin.Controls.MaterialCheckBox();
            this.chBorrarOriginal = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
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
            this.grd.Size = new System.Drawing.Size(776, 391);
            this.grd.TabIndex = 0;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Location = new System.Drawing.Point(686, 415);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(102, 23);
            this.cmdCancelar.TabIndex = 5;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAceptar.Location = new System.Drawing.Point(551, 415);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(129, 23);
            this.cmdAceptar.TabIndex = 5;
            this.cmdAceptar.Text = "&Agregar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.CmdAceptar_Click);
            // 
            // chAgrupar
            // 
            this.chAgrupar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chAgrupar.AutoSize = true;
            this.chAgrupar.Checked = true;
            this.chAgrupar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAgrupar.Depth = 0;
            this.chAgrupar.Font = new System.Drawing.Font("Roboto", 10F);
            this.chAgrupar.Location = new System.Drawing.Point(9, 406);
            this.chAgrupar.Margin = new System.Windows.Forms.Padding(0);
            this.chAgrupar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chAgrupar.MouseState = MaterialSkin.MouseState.HOVER;
            this.chAgrupar.Name = "chAgrupar";
            this.chAgrupar.Ripple = true;
            this.chAgrupar.Size = new System.Drawing.Size(79, 30);
            this.chAgrupar.TabIndex = 6;
            this.chAgrupar.Text = "Agrupar";
            this.chAgrupar.UseVisualStyleBackColor = true;
            this.chAgrupar.CheckedChanged += new System.EventHandler(this.chAgrupar_CheckedChanged);
            // 
            // chBorrarOriginal
            // 
            this.chBorrarOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chBorrarOriginal.AutoSize = true;
            this.chBorrarOriginal.Depth = 0;
            this.chBorrarOriginal.Font = new System.Drawing.Font("Roboto", 10F);
            this.chBorrarOriginal.Location = new System.Drawing.Point(88, 406);
            this.chBorrarOriginal.Margin = new System.Windows.Forms.Padding(0);
            this.chBorrarOriginal.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chBorrarOriginal.MouseState = MaterialSkin.MouseState.HOVER;
            this.chBorrarOriginal.Name = "chBorrarOriginal";
            this.chBorrarOriginal.Ripple = true;
            this.chBorrarOriginal.Size = new System.Drawing.Size(119, 30);
            this.chBorrarOriginal.TabIndex = 7;
            this.chBorrarOriginal.Text = "Borrar Original";
            this.chBorrarOriginal.UseVisualStyleBackColor = true;
            this.chBorrarOriginal.CheckedChanged += new System.EventHandler(this.chBorrarOriginal_CheckedChanged);
            // 
            // frmCopiarVentaACompra
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chBorrarOriginal);
            this.Controls.Add(this.chAgrupar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.grd);
            this.Name = "frmCopiarVentaACompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copiar Ventas A Compras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdAceptar;
        public Grilla2.SpeedGrilla grd;
        private MaterialSkin.Controls.MaterialCheckBox chAgrupar;
        private MaterialSkin.Controls.MaterialCheckBox chBorrarOriginal;
    }
}