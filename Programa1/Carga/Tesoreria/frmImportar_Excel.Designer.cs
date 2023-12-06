namespace Programa1.Carga.Tesoreria
{
    partial class frmImportar_Excel
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
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGuardar_Creditos = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblContador = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.grdSalida = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdCargar = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdDebitos = new Grilla2.SpeedGrilla();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdGuardar_Debitos = new System.Windows.Forms.Button();
            this.chCreditos = new MaterialSkin.Controls.MaterialCheckBox();
            this.chDebitos = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
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
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSeleccionar.Location = new System.Drawing.Point(12, 12);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(727, 28);
            this.cmdSeleccionar.TabIndex = 0;
            this.cmdSeleccionar.Text = "Seleccionar archivo";
            this.cmdSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
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
            this.grd.Col = -2;
            this.grd.Cols = 0;
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
            this.grd.Location = new System.Drawing.Point(0, 24);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(390, 493);
            this.grd.TabIndex = 1;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSalir.Location = new System.Drawing.Point(1084, 599);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(75, 23);
            this.cmdSalir.TabIndex = 2;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGuardar_Creditos
            // 
            this.cmdGuardar_Creditos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar_Creditos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar_Creditos.Location = new System.Drawing.Point(185, 491);
            this.cmdGuardar_Creditos.Name = "cmdGuardar_Creditos";
            this.cmdGuardar_Creditos.Size = new System.Drawing.Size(75, 23);
            this.cmdGuardar_Creditos.TabIndex = 3;
            this.cmdGuardar_Creditos.Text = "Guardar";
            this.cmdGuardar_Creditos.UseVisualStyleBackColor = true;
            this.cmdGuardar_Creditos.Click += new System.EventHandler(this.cmdGuardar_Creditos_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Molleda - Galicia",
            "Molleda - Provincia",
            "Alonso   - BBVA",
            "Meat - Provincia"});
            this.cmbTipo.Location = new System.Drawing.Point(745, 13);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(280, 28);
            this.cmbTipo.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1110, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblContador
            // 
            this.lblContador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(9, 609);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(0, 13);
            this.lblContador.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grd);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdSalida);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cmdGuardar_Creditos);
            this.splitContainer1.Size = new System.Drawing.Size(688, 517);
            this.splitContainer1.SplitterDistance = 393;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entrada";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdSalida
            // 
            this.grdSalida.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSalida.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSalida.AutoResize = false;
            this.grdSalida.bColor = System.Drawing.SystemColors.Window;
            this.grdSalida.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSalida.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSalida.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSalida.Col = -2;
            this.grdSalida.Cols = 0;
            this.grdSalida.DataMember = "";
            this.grdSalida.DataSource = null;
            this.grdSalida.EnableEdicion = true;
            this.grdSalida.Encabezado = "";
            this.grdSalida.fColor = System.Drawing.Color.Silver;
            this.grdSalida.FixCols = 0;
            this.grdSalida.FixRows = 0;
            this.grdSalida.Frozen = 0;
            this.grdSalida.FuenteEncabezado = null;
            this.grdSalida.FuentePieDePagina = null;
            this.grdSalida.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSalida.LimpiarEstilosAntesDeOrdenar = false;
            this.grdSalida.Location = new System.Drawing.Point(0, 24);
            this.grdSalida.Name = "grdSalida";
            this.grdSalida.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSalida.PintarFilaSel = true;
            this.grdSalida.Redraw = true;
            this.grdSalida.Row = 0;
            this.grdSalida.Rows = 50;
            this.grdSalida.Size = new System.Drawing.Size(260, 461);
            this.grdSalida.TabIndex = 0;
            this.grdSalida.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSalida_Editado);
            this.grdSalida.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdSalida_KeyUp);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Creditos";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdCargar
            // 
            this.cmdCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCargar.Location = new System.Drawing.Point(1031, 12);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(73, 28);
            this.cmdCargar.TabIndex = 5;
            this.cmdCargar.Text = "&Cargar";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Click += new System.EventHandler(this.cmdCargar_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer2.Location = new System.Drawing.Point(12, 76);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdDebitos);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.cmdGuardar_Debitos);
            this.splitContainer2.Size = new System.Drawing.Size(1147, 517);
            this.splitContainer2.SplitterDistance = 688;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 8;
            // 
            // grdDebitos
            // 
            this.grdDebitos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDebitos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDebitos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDebitos.AutoResize = false;
            this.grdDebitos.bColor = System.Drawing.SystemColors.Window;
            this.grdDebitos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDebitos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDebitos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDebitos.Col = -2;
            this.grdDebitos.Cols = 0;
            this.grdDebitos.DataMember = "";
            this.grdDebitos.DataSource = null;
            this.grdDebitos.EnableEdicion = true;
            this.grdDebitos.Encabezado = "";
            this.grdDebitos.fColor = System.Drawing.Color.Silver;
            this.grdDebitos.FixCols = 0;
            this.grdDebitos.FixRows = 0;
            this.grdDebitos.Frozen = 0;
            this.grdDebitos.FuenteEncabezado = null;
            this.grdDebitos.FuentePieDePagina = null;
            this.grdDebitos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDebitos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdDebitos.Location = new System.Drawing.Point(0, 24);
            this.grdDebitos.Name = "grdDebitos";
            this.grdDebitos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDebitos.PintarFilaSel = true;
            this.grdDebitos.Redraw = true;
            this.grdDebitos.Row = 0;
            this.grdDebitos.Rows = 50;
            this.grdDebitos.Size = new System.Drawing.Size(427, 461);
            this.grdDebitos.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(451, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Debitos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdGuardar_Debitos
            // 
            this.cmdGuardar_Debitos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar_Debitos.Enabled = false;
            this.cmdGuardar_Debitos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar_Debitos.Location = new System.Drawing.Point(352, 491);
            this.cmdGuardar_Debitos.Name = "cmdGuardar_Debitos";
            this.cmdGuardar_Debitos.Size = new System.Drawing.Size(75, 23);
            this.cmdGuardar_Debitos.TabIndex = 3;
            this.cmdGuardar_Debitos.Text = "Guardar";
            this.cmdGuardar_Debitos.UseVisualStyleBackColor = true;
            this.cmdGuardar_Debitos.Visible = false;
            this.cmdGuardar_Debitos.Click += new System.EventHandler(this.cmdGuardar_Debitos_Click);
            // 
            // chCreditos
            // 
            this.chCreditos.Checked = true;
            this.chCreditos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCreditos.Depth = 0;
            this.chCreditos.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCreditos.Location = new System.Drawing.Point(113, 43);
            this.chCreditos.Margin = new System.Windows.Forms.Padding(0);
            this.chCreditos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCreditos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCreditos.Name = "chCreditos";
            this.chCreditos.Ripple = true;
            this.chCreditos.Size = new System.Drawing.Size(104, 30);
            this.chCreditos.TabIndex = 9;
            this.chCreditos.Text = "Creditos";
            this.chCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chCreditos.UseVisualStyleBackColor = true;
            this.chCreditos.CheckedChanged += new System.EventHandler(this.chCreditos_CheckedChanged);
            // 
            // chDebitos
            // 
            this.chDebitos.Checked = true;
            this.chDebitos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDebitos.Depth = 0;
            this.chDebitos.Font = new System.Drawing.Font("Roboto", 10F);
            this.chDebitos.Location = new System.Drawing.Point(217, 43);
            this.chDebitos.Margin = new System.Windows.Forms.Padding(0);
            this.chDebitos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chDebitos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chDebitos.Name = "chDebitos";
            this.chDebitos.Ripple = true;
            this.chDebitos.Size = new System.Drawing.Size(104, 30);
            this.chDebitos.TabIndex = 9;
            this.chDebitos.Text = "Debitos";
            this.chDebitos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chDebitos.UseVisualStyleBackColor = true;
            this.chDebitos.CheckedChanged += new System.EventHandler(this.chDebitos_CheckedChanged);
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.Checked = true;
            this.materialCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(9, 43);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(104, 30);
            this.materialCheckBox1.TabIndex = 9;
            this.materialCheckBox1.Text = "Entrada";
            this.materialCheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            this.materialCheckBox1.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // frmImportar_Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 634);
            this.Controls.Add(this.chDebitos);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.chCreditos);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdSeleccionar);
            this.Name = "frmImportar_Excel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Excel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSeleccionar;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdGuardar_Creditos;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdCargar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdDebitos;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialCheckBox chCreditos;
        private MaterialSkin.Controls.MaterialCheckBox chDebitos;
        private System.Windows.Forms.Button cmdGuardar_Debitos;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}