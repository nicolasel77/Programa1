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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdActualizar_Franquicia = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nuDecimales = new System.Windows.Forms.NumericUpDown();
            this.chValoresCero = new MaterialSkin.Controls.MaterialCheckBox();
            this.lstTipos = new System.Windows.Forms.ListBox();
            this.lstFranquicia = new System.Windows.Forms.ListBox();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.cmdPorcentaje = new System.Windows.Forms.Button();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdGuardarFran = new Programa1.Controles.cBoton();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.Suc = new Programa1.Controles.cSucursales();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuDecimales)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.cmdPorcentaje);
            this.splitContainer1.Panel2.Controls.Add(this.cmdActualizar_Franquicia);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.nuDecimales);
            this.splitContainer1.Panel2.Controls.Add(this.chValoresCero);
            this.splitContainer1.Panel2.Controls.Add(this.lstTipos);
            this.splitContainer1.Panel2.Controls.Add(this.lstFranquicia);
            this.splitContainer1.Panel2.Controls.Add(this.lstFechas);
            this.splitContainer1.Panel2.Controls.Add(this.Suc);
            this.splitContainer1.Size = new System.Drawing.Size(1446, 684);
            this.splitContainer1.SplitterDistance = 476;
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
            this.panel1.Size = new System.Drawing.Size(470, 678);
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
            this.grd.Frozen = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.LimpiarEstilosAntesDeOrdenar = false;
            this.grd.Location = new System.Drawing.Point(3, 3);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = -2;
            this.grd.Rows = 0;
            this.grd.Size = new System.Drawing.Size(464, 672);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            this.grd.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grd_KeyPress);
            // 
            // cmdActualizar_Franquicia
            // 
            this.cmdActualizar_Franquicia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdActualizar_Franquicia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdActualizar_Franquicia.Location = new System.Drawing.Point(422, 434);
            this.cmdActualizar_Franquicia.Name = "cmdActualizar_Franquicia";
            this.cmdActualizar_Franquicia.Size = new System.Drawing.Size(192, 23);
            this.cmdActualizar_Franquicia.TabIndex = 15;
            this.cmdActualizar_Franquicia.Text = "Actualizar precios franquicia";
            this.cmdActualizar_Franquicia.UseVisualStyleBackColor = true;
            this.cmdActualizar_Franquicia.Click += new System.EventHandler(this.cmdActualizar_Franquicia_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.cmdBorrar);
            this.panel2.Controls.Add(this.cmdImprimir);
            this.panel2.Controls.Add(this.cmdGuardarFran);
            this.panel2.Controls.Add(this.cmdGuardar);
            this.panel2.Location = new System.Drawing.Point(223, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 243);
            this.panel2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(389, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha Franquicia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(516, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(274, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tipo";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(408, 628);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Decimales:";
            // 
            // nuDecimales
            // 
            this.nuDecimales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuDecimales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuDecimales.ForeColor = System.Drawing.Color.DimGray;
            this.nuDecimales.Location = new System.Drawing.Point(501, 629);
            this.nuDecimales.Name = "nuDecimales";
            this.nuDecimales.Size = new System.Drawing.Size(37, 22);
            this.nuDecimales.TabIndex = 11;
            this.nuDecimales.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nuDecimales.ValueChanged += new System.EventHandler(this.nuDecimales_ValueChanged);
            // 
            // chValoresCero
            // 
            this.chValoresCero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chValoresCero.AutoSize = true;
            this.chValoresCero.Depth = 0;
            this.chValoresCero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chValoresCero.Location = new System.Drawing.Point(408, 648);
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
            // lstTipos
            // 
            this.lstTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstTipos.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstTipos.FormattingEnabled = true;
            this.lstTipos.ItemHeight = 20;
            this.lstTipos.Location = new System.Drawing.Point(223, 28);
            this.lstTipos.Name = "lstTipos";
            this.lstTipos.Size = new System.Drawing.Size(155, 200);
            this.lstTipos.TabIndex = 2;
            this.lstTipos.SelectedIndexChanged += new System.EventHandler(this.lstTipos_SelectedIndexChanged);
            // 
            // lstFranquicia
            // 
            this.lstFranquicia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFranquicia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFranquicia.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstFranquicia.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstFranquicia.FormattingEnabled = true;
            this.lstFranquicia.ItemHeight = 20;
            this.lstFranquicia.Location = new System.Drawing.Point(392, 28);
            this.lstFranquicia.Name = "lstFranquicia";
            this.lstFranquicia.Size = new System.Drawing.Size(105, 400);
            this.lstFranquicia.TabIndex = 2;
            this.lstFranquicia.SelectedIndexChanged += new System.EventHandler(this.lstFranquicia_SelectedIndexChanged);
            // 
            // lstFechas
            // 
            this.lstFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstFechas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(509, 28);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(105, 400);
            this.lstFechas.TabIndex = 2;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // cmdPorcentaje
            // 
            this.cmdPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdPorcentaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdPorcentaje.Location = new System.Drawing.Point(223, 234);
            this.cmdPorcentaje.Name = "cmdPorcentaje";
            this.cmdPorcentaje.Size = new System.Drawing.Size(75, 23);
            this.cmdPorcentaje.TabIndex = 17;
            this.cmdPorcentaje.Text = "Calcular %";
            this.cmdPorcentaje.UseVisualStyleBackColor = true;
            this.cmdPorcentaje.Click += new System.EventHandler(this.cmdPorcentaje_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdBorrar.Location = new System.Drawing.Point(12, 148);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(154, 40);
            this.cmdBorrar.TabIndex = 3;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdImprimir.Location = new System.Drawing.Point(12, 194);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(154, 40);
            this.cmdImprimir.TabIndex = 3;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdGuardarFran
            // 
            this.cmdGuardarFran.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdGuardarFran.Location = new System.Drawing.Point(12, 59);
            this.cmdGuardarFran.Name = "cmdGuardarFran";
            this.cmdGuardarFran.Size = new System.Drawing.Size(154, 40);
            this.cmdGuardarFran.TabIndex = 3;
            this.cmdGuardarFran.Texto = "Guardar Fr";
            this.cmdGuardarFran.Click += new System.EventHandler(this.cmdGuardarFran_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdGuardar.Location = new System.Drawing.Point(12, 13);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(154, 40);
            this.cmdGuardar.TabIndex = 3;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
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
            this.Suc.Size = new System.Drawing.Size(215, 678);
            this.Suc.TabIndex = 1;
            this.Suc.Titulo = "Sucursales";
            this.Suc.Valor_Actual = -1;
            this.Suc.Cambio_Seleccion += new System.EventHandler(this.Suc_Cambio_Seleccion);
            // 
            // frmPreciosMen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 688);
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
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuDecimales)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nuDecimales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstFranquicia;
        private System.Windows.Forms.Panel panel2;
        private Controles.cBoton cmdGuardarFran;
        private System.Windows.Forms.Button cmdActualizar_Franquicia;
        private System.Windows.Forms.Button cmdPorcentaje;
    }
}