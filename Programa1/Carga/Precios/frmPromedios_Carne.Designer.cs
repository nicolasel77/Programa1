namespace Programa1.Carga.Precios
{

    partial class frmPromedios_Carne
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
            this.cmdGuardar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCargarPrecios = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grdProme = new Grilla2.SpeedGrilla();
            this.Csucs = new Programa1.Controles.cSucursales();
            this.Cfecha = new Programa1.Controles.cFechas();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.AutoSize = true;
            this.cmdGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdGuardar.Depth = 0;
            this.cmdGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdGuardar.Location = new System.Drawing.Point(0, 0);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Primary = false;
            this.cmdGuardar.Size = new System.Drawing.Size(131, 57);
            this.cmdGuardar.TabIndex = 2;
            this.cmdGuardar.Text = "Agregar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdGuardar);
            this.panel1.Location = new System.Drawing.Point(891, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 57);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmdCargarPrecios);
            this.panel2.Location = new System.Drawing.Point(760, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(131, 57);
            this.panel2.TabIndex = 4;
            // 
            // cmdCargarPrecios
            // 
            this.cmdCargarPrecios.AutoSize = true;
            this.cmdCargarPrecios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCargarPrecios.Depth = 0;
            this.cmdCargarPrecios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCargarPrecios.Location = new System.Drawing.Point(0, 0);
            this.cmdCargarPrecios.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCargarPrecios.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCargarPrecios.Name = "cmdCargarPrecios";
            this.cmdCargarPrecios.Primary = false;
            this.cmdCargarPrecios.Size = new System.Drawing.Size(131, 57);
            this.cmdCargarPrecios.TabIndex = 2;
            this.cmdCargarPrecios.Text = "Buscar Precios";
            this.cmdCargarPrecios.UseVisualStyleBackColor = true;
            this.cmdCargarPrecios.Click += new System.EventHandler(this.cmdCargarPrecios_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Csucs);
            this.panel3.Controls.Add(this.Cfecha);
            this.panel3.Location = new System.Drawing.Point(555, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(329, 438);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.txtNombre);
            this.panel4.Location = new System.Drawing.Point(890, 507);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 19);
            this.panel4.TabIndex = 6;
            this.panel4.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(0, 0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(131, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyUp);
            // 
            // grdProme
            // 
            this.grdProme.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProme.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProme.AutoResize = false;
            this.grdProme.bColor = System.Drawing.SystemColors.Window;
            this.grdProme.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProme.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProme.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProme.Col = 0;
            this.grdProme.Cols = 10;
            this.grdProme.DataMember = "";
            this.grdProme.DataSource = null;
            this.grdProme.EnableEdicion = true;
            this.grdProme.Encabezado = "";
            this.grdProme.fColor = System.Drawing.Color.Silver;
            this.grdProme.FixCols = 0;
            this.grdProme.FixRows = 0;
            this.grdProme.FuenteEncabezado = null;
            this.grdProme.FuentePieDePagina = null;
            this.grdProme.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProme.Location = new System.Drawing.Point(12, 12);
            this.grdProme.Name = "grdProme";
            this.grdProme.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProme.PintarFilaSel = true;
            this.grdProme.Redraw = true;
            this.grdProme.Row = 0;
            this.grdProme.Rows = 50;
            this.grdProme.Size = new System.Drawing.Size(1010, 514);
            this.grdProme.TabIndex = 0;
            this.grdProme.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdProme_Editado);
            this.grdProme.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdProme_CambioFila);
            this.grdProme.Click += new Grilla2.SpeedGrilla.ClickEventHandler(this.grdProme_Click);
            this.grdProme.CambioColumna += new Grilla2.SpeedGrilla.CambioColumnaEventHandler(this.grdProme_CambioColumna);
            // 
            // Csucs
            // 
            this.Csucs.BackColor = System.Drawing.Color.Gainsboro;
            this.Csucs.Filtro_In = "";
            this.Csucs.Location = new System.Drawing.Point(176, 0);
            this.Csucs.Mostrar_Botones = false;
            this.Csucs.Mostrar_Tipo = true;
            this.Csucs.Name = "Csucs";
            this.Csucs.selectionMode = System.Windows.Forms.SelectionMode.One;
            this.Csucs.Size = new System.Drawing.Size(201, 441);
            this.Csucs.TabIndex = 0;
            this.Csucs.Titulo = "Sucursales";
            this.Csucs.Valor_Actual = -1;
            this.Csucs.Cambio_Seleccion += new System.EventHandler(this.Csucs_Cambio_Seleccion);
            // 
            // Cfecha
            // 
            this.Cfecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.Cfecha.Location = new System.Drawing.Point(0, 0);
            this.Cfecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.Cfecha.Mostrar = 0;
            this.Cfecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.Cfecha.Name = "Cfecha";
            this.Cfecha.Size = new System.Drawing.Size(369, 438);
            this.Cfecha.TabIndex = 1;
            this.Cfecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.Cfecha.Cambio_Seleccion += new System.EventHandler(this.Cfecha_Cambio_Seleccion);
            // 
            // frmPromedios_Carne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 572);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.grdProme);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPromedios_Carne";
            this.Text = "Promedios_Carne";
            this.Load += new System.EventHandler(this.frmPromedios_Carne_Load);
            this.Click += new System.EventHandler(this.frmPromedios_Carne_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdProme;
        private MaterialSkin.Controls.MaterialFlatButton cmdGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton cmdCargarPrecios;
        private System.Windows.Forms.Panel panel3;
        private Controles.cSucursales Csucs;
        private Controles.cFechas Cfecha;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNombre;
    }
}