namespace Programa1.Carga.Precios
{
    partial class frmPreciosMen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreciosMen));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.lstTipos = new System.Windows.Forms.ListBox();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.Suc = new Programa1.Controles.cSucursales();
            this.chValoresCero = new MaterialSkin.Controls.MaterialCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chValoresCero);
            this.splitContainer1.Panel2.Controls.Add(this.cmdGuardar);
            this.splitContainer1.Panel2.Controls.Add(this.cmdImprimir);
            this.splitContainer1.Panel2.Controls.Add(this.cmdBorrar);
            this.splitContainer1.Panel2.Controls.Add(this.lstTipos);
            this.splitContainer1.Panel2.Controls.Add(this.lstFechas);
            this.splitContainer1.Panel2.Controls.Add(this.Suc);
            this.splitContainer1.Size = new System.Drawing.Size(1096, 673);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.grd);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 667);
            this.panel1.TabIndex = 1;
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
            this.grd.Location = new System.Drawing.Point(3, 3);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(406, 661);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdGuardar.Location = new System.Drawing.Point(349, 627);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(154, 40);
            this.cmdGuardar.TabIndex = 3;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdImprimir.Location = new System.Drawing.Point(349, 581);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(154, 40);
            this.cmdImprimir.TabIndex = 3;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrar.Location = new System.Drawing.Point(349, 535);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(154, 40);
            this.cmdBorrar.TabIndex = 3;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // lstTipos
            // 
            this.lstTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstTipos.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstTipos.FormattingEnabled = true;
            this.lstTipos.ItemHeight = 18;
            this.lstTipos.Location = new System.Drawing.Point(509, 3);
            this.lstTipos.Name = "lstTipos";
            this.lstTipos.Size = new System.Drawing.Size(155, 162);
            this.lstTipos.TabIndex = 2;
            this.lstTipos.SelectedIndexChanged += new System.EventHandler(this.lstTipos_SelectedIndexChanged);
            // 
            // lstFechas
            // 
            this.lstFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstFechas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 18;
            this.lstFechas.Location = new System.Drawing.Point(349, 3);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(154, 504);
            this.lstFechas.TabIndex = 2;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // Suc
            // 
            this.Suc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Suc.BackColor = System.Drawing.Color.Gainsboro;
            this.Suc.Filtro_In = "";
            this.Suc.Location = new System.Drawing.Point(2, 3);
            this.Suc.Mostrar_Botones = false;
            this.Suc.Mostrar_Tipo = false;
            this.Suc.Name = "Suc";
            this.Suc.selectionMode = System.Windows.Forms.SelectionMode.One;
            this.Suc.Size = new System.Drawing.Size(340, 667);
            this.Suc.TabIndex = 1;
            this.Suc.Titulo = "Sucursales";
            this.Suc.Valor_Actual = -1;
            this.Suc.Cambio_Seleccion += new System.EventHandler(this.Suc_Cambio_Seleccion);
            // 
            // chValoresCero
            // 
            this.chValoresCero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chValoresCero.AutoSize = true;
            this.chValoresCero.Depth = 0;
            this.chValoresCero.Font = new System.Drawing.Font("Roboto", 10F);
            this.chValoresCero.Location = new System.Drawing.Point(509, 636);
            this.chValoresCero.Margin = new System.Windows.Forms.Padding(0);
            this.chValoresCero.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chValoresCero.MouseState = MaterialSkin.MouseState.HOVER;
            this.chValoresCero.Name = "chValoresCero";
            this.chValoresCero.Ripple = true;
            this.chValoresCero.Size = new System.Drawing.Size(162, 30);
            this.chValoresCero.TabIndex = 5;
            this.chValoresCero.Text = "Guardar Valores Cero";
            this.chValoresCero.UseVisualStyleBackColor = true;
            // 
            // frmPreciosMen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 677);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPreciosMen";
            this.Text = "Precios Menudencias";
            this.Load += new System.EventHandler(this.FrmPreciosMen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grd;
        private Controles.cSucursales Suc;
        private System.Windows.Forms.ListBox lstFechas;
        private System.Windows.Forms.Panel panel1;
        private Controles.cBoton cmdGuardar;
        private Controles.cBoton cmdImprimir;
        private Controles.cBoton cmdBorrar;
        private System.Windows.Forms.ListBox lstTipos;
        private MaterialSkin.Controls.MaterialCheckBox chValoresCero;
    }
}