
namespace Programa1.Carga.Tesoreria
{
    partial class frmCargar_Sueldos
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
            this.chBajas = new MaterialSkin.Controls.MaterialCheckBox();
            this.rdNinguno = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdVacaciones = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAguinaldo = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAdelanto = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdResto = new MaterialSkin.Controls.MaterialRadioButton();
            this.lstSucs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.grd = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.chBajas);
            this.splitContainer1.Panel1.Controls.Add(this.rdNinguno);
            this.splitContainer1.Panel1.Controls.Add(this.rdVacaciones);
            this.splitContainer1.Panel1.Controls.Add(this.rdAguinaldo);
            this.splitContainer1.Panel1.Controls.Add(this.rdAdelanto);
            this.splitContainer1.Panel1.Controls.Add(this.rdResto);
            this.splitContainer1.Panel1.Controls.Add(this.lstSucs);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.cmdCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAceptar);
            this.splitContainer1.Panel2.Controls.Add(this.grd);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(845, 697);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 0;
            // 
            // chBajas
            // 
            this.chBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chBajas.AutoSize = true;
            this.chBajas.Checked = true;
            this.chBajas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBajas.Depth = 0;
            this.chBajas.Font = new System.Drawing.Font("Roboto", 10F);
            this.chBajas.Location = new System.Drawing.Point(14, 655);
            this.chBajas.Margin = new System.Windows.Forms.Padding(0);
            this.chBajas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chBajas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chBajas.Name = "chBajas";
            this.chBajas.Ripple = true;
            this.chBajas.Size = new System.Drawing.Size(112, 30);
            this.chBajas.TabIndex = 2;
            this.chBajas.Text = "Ocultar Bajas";
            this.chBajas.UseVisualStyleBackColor = true;
            this.chBajas.CheckedChanged += new System.EventHandler(this.chBajas_CheckedChanged);
            // 
            // rdNinguno
            // 
            this.rdNinguno.AutoSize = true;
            this.rdNinguno.Depth = 0;
            this.rdNinguno.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdNinguno.Location = new System.Drawing.Point(14, 567);
            this.rdNinguno.Margin = new System.Windows.Forms.Padding(0);
            this.rdNinguno.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdNinguno.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdNinguno.Name = "rdNinguno";
            this.rdNinguno.Ripple = true;
            this.rdNinguno.Size = new System.Drawing.Size(81, 30);
            this.rdNinguno.TabIndex = 1;
            this.rdNinguno.TabStop = true;
            this.rdNinguno.Text = "Ninguno";
            this.rdNinguno.UseVisualStyleBackColor = true;
            this.rdNinguno.CheckedChanged += new System.EventHandler(this.rdNinguno_CheckedChanged);
            // 
            // rdVacaciones
            // 
            this.rdVacaciones.AutoSize = true;
            this.rdVacaciones.Depth = 0;
            this.rdVacaciones.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdVacaciones.Location = new System.Drawing.Point(14, 537);
            this.rdVacaciones.Margin = new System.Windows.Forms.Padding(0);
            this.rdVacaciones.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdVacaciones.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdVacaciones.Name = "rdVacaciones";
            this.rdVacaciones.Ripple = true;
            this.rdVacaciones.Size = new System.Drawing.Size(100, 30);
            this.rdVacaciones.TabIndex = 1;
            this.rdVacaciones.TabStop = true;
            this.rdVacaciones.Text = "Vacaciones";
            this.rdVacaciones.UseVisualStyleBackColor = true;
            this.rdVacaciones.CheckedChanged += new System.EventHandler(this.rdVacaciones_CheckedChanged);
            // 
            // rdAguinaldo
            // 
            this.rdAguinaldo.AutoSize = true;
            this.rdAguinaldo.Depth = 0;
            this.rdAguinaldo.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAguinaldo.Location = new System.Drawing.Point(14, 507);
            this.rdAguinaldo.Margin = new System.Windows.Forms.Padding(0);
            this.rdAguinaldo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAguinaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAguinaldo.Name = "rdAguinaldo";
            this.rdAguinaldo.Ripple = true;
            this.rdAguinaldo.Size = new System.Drawing.Size(91, 30);
            this.rdAguinaldo.TabIndex = 1;
            this.rdAguinaldo.TabStop = true;
            this.rdAguinaldo.Text = "Aguinaldo";
            this.rdAguinaldo.UseVisualStyleBackColor = true;
            this.rdAguinaldo.CheckedChanged += new System.EventHandler(this.rdAguinaldo_CheckedChanged);
            // 
            // rdAdelanto
            // 
            this.rdAdelanto.AutoSize = true;
            this.rdAdelanto.Depth = 0;
            this.rdAdelanto.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdAdelanto.Location = new System.Drawing.Point(14, 477);
            this.rdAdelanto.Margin = new System.Windows.Forms.Padding(0);
            this.rdAdelanto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAdelanto.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAdelanto.Name = "rdAdelanto";
            this.rdAdelanto.Ripple = true;
            this.rdAdelanto.Size = new System.Drawing.Size(84, 30);
            this.rdAdelanto.TabIndex = 1;
            this.rdAdelanto.TabStop = true;
            this.rdAdelanto.Text = "Adelanto";
            this.rdAdelanto.UseVisualStyleBackColor = true;
            this.rdAdelanto.CheckedChanged += new System.EventHandler(this.rdAdelanto_CheckedChanged);
            // 
            // rdResto
            // 
            this.rdResto.AutoSize = true;
            this.rdResto.Depth = 0;
            this.rdResto.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdResto.Location = new System.Drawing.Point(14, 447);
            this.rdResto.Margin = new System.Windows.Forms.Padding(0);
            this.rdResto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdResto.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdResto.Name = "rdResto";
            this.rdResto.Ripple = true;
            this.rdResto.Size = new System.Drawing.Size(113, 30);
            this.rdResto.TabIndex = 1;
            this.rdResto.TabStop = true;
            this.rdResto.Text = "Resto de Mes";
            this.rdResto.UseVisualStyleBackColor = true;
            this.rdResto.CheckedChanged += new System.EventHandler(this.rdResto_CheckedChanged);
            // 
            // lstSucs
            // 
            this.lstSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSucs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSucs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstSucs.FormattingEnabled = true;
            this.lstSucs.ItemHeight = 20;
            this.lstSucs.Location = new System.Drawing.Point(12, 34);
            this.lstSucs.Name = "lstSucs";
            this.lstSucs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSucs.Size = new System.Drawing.Size(358, 400);
            this.lstSucs.TabIndex = 0;
            this.lstSucs.SelectedIndexChanged += new System.EventHandler(this.lstSucs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sucursal";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(283, 663);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(166, 22);
            this.cmdCancelar.TabIndex = 1;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(111, 663);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(166, 22);
            this.cmdAceptar.TabIndex = 1;
            this.cmdAceptar.Texto = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
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
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(6, 34);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(443, 623);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empeados";
            // 
            // frmCargar_Sueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 697);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCargar_Sueldos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar_Sueldos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstSucs;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRadioButton rdNinguno;
        private MaterialSkin.Controls.MaterialRadioButton rdAdelanto;
        private MaterialSkin.Controls.MaterialRadioButton rdResto;
        private Controles.cBoton cmdCancelar;
        private Controles.cBoton cmdAceptar;
        private MaterialSkin.Controls.MaterialRadioButton rdVacaciones;
        private MaterialSkin.Controls.MaterialRadioButton rdAguinaldo;
        private MaterialSkin.Controls.MaterialCheckBox chBajas;
    }
}