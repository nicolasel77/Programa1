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
            this.Csucs = new Programa1.Controles.cSucursales();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grdProme = new Grilla2.SpeedGrilla();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmdGuardar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Csucs
            // 
            this.Csucs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Csucs.BackColor = System.Drawing.Color.Gainsboro;
            this.Csucs.Filtro_In = "";
            this.Csucs.Location = new System.Drawing.Point(836, 12);
            this.Csucs.Mostrar_Botones = false;
            this.Csucs.Mostrar_Tipo = false;
            this.Csucs.Name = "Csucs";
            this.Csucs.selectionMode = System.Windows.Forms.SelectionMode.One;
            this.Csucs.Size = new System.Drawing.Size(367, 439);
            this.Csucs.TabIndex = 0;
            this.Csucs.Titulo = "Sucursales";
            this.Csucs.Valor_Actual = -1;
            this.Csucs.Cambio_Seleccion += new System.EventHandler(this.Csucs_Cambio_Seleccion);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.lstFechas);
            this.panel5.Location = new System.Drawing.Point(718, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(112, 548);
            this.panel5.TabIndex = 2;
            // 
            // lstFechas
            // 
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(0, 0);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(112, 548);
            this.lstFechas.TabIndex = 2;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(0, 0);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(183, 20);
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
            this.grdProme.Size = new System.Drawing.Size(700, 548);
            this.grdProme.TabIndex = 0;
            this.grdProme.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdProme_Editado);
            this.grdProme.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdProme_CambioFila);
            this.grdProme.Click += new Grilla2.SpeedGrilla.ClickEventHandler(this.grdProme_Click);
            this.grdProme.CambioColumna += new Grilla2.SpeedGrilla.CambioColumnaEventHandler(this.grdProme_CambioColumna);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(832, 454);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(204, 38);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Ingrese un nombre para \r\nguardar la lista";
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
            this.cmdGuardar.Size = new System.Drawing.Size(200, 39);
            this.cmdGuardar.TabIndex = 7;
            this.cmdGuardar.Text = "Agregar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdGuardar);
            this.panel1.Location = new System.Drawing.Point(836, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 39);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Location = new System.Drawing.Point(839, 495);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 20);
            this.panel2.TabIndex = 8;
            // 
            // frmPromedios_Carne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.Csucs);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.grdProme);
            this.Name = "frmPromedios_Carne";
            this.Text = "Promedios_Carne";
            this.Load += new System.EventHandler(this.frmPromedios_Carne_Load);
            this.Click += new System.EventHandler(this.frmPromedios_Carne_Click);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdProme;
        private Controles.cSucursales Csucs;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lstFechas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton cmdGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}