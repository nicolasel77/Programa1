
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.nuDivisor = new System.Windows.Forms.NumericUpDown();
            this.chBajas = new MaterialSkin.Controls.MaterialCheckBox();
            this.rdNinguno = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdVacaciones = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAguinaldo = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdAdelanto = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdResto = new MaterialSkin.Controls.MaterialRadioButton();
            this.lstSucs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grd = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuDivisor)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtImporte);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.nuDivisor);
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
            this.splitContainer1.Size = new System.Drawing.Size(845, 749);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(53, 715);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(156, 19);
            this.txtDescripcion.TabIndex = 4;
            // 
            // nuDivisor
            // 
            this.nuDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuDivisor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuDivisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuDivisor.Location = new System.Drawing.Point(185, 562);
            this.nuDivisor.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nuDivisor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuDivisor.Name = "nuDivisor";
            this.nuDivisor.Size = new System.Drawing.Size(38, 22);
            this.nuDivisor.TabIndex = 3;
            this.nuDivisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nuDivisor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nuDivisor.ValueChanged += new System.EventHandler(this.nuDivisor_ValueChanged);
            // 
            // chBajas
            // 
            this.chBajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chBajas.AutoSize = true;
            this.chBajas.Checked = true;
            this.chBajas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBajas.Depth = 0;
            this.chBajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chBajas.Location = new System.Drawing.Point(14, 660);
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
            this.rdNinguno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdNinguno.AutoSize = true;
            this.rdNinguno.Depth = 0;
            this.rdNinguno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdNinguno.Location = new System.Drawing.Point(14, 617);
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
            this.rdVacaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdVacaciones.AutoSize = true;
            this.rdVacaciones.Depth = 0;
            this.rdVacaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdVacaciones.Location = new System.Drawing.Point(14, 587);
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
            this.rdAguinaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdAguinaldo.AutoSize = true;
            this.rdAguinaldo.Depth = 0;
            this.rdAguinaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdAguinaldo.Location = new System.Drawing.Point(14, 557);
            this.rdAguinaldo.Margin = new System.Windows.Forms.Padding(0);
            this.rdAguinaldo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdAguinaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdAguinaldo.Name = "rdAguinaldo";
            this.rdAguinaldo.Ripple = true;
            this.rdAguinaldo.Size = new System.Drawing.Size(168, 30);
            this.rdAguinaldo.TabIndex = 1;
            this.rdAguinaldo.TabStop = true;
            this.rdAguinaldo.Text = "Aguinaldo   Dividir por:";
            this.rdAguinaldo.UseVisualStyleBackColor = true;
            this.rdAguinaldo.CheckedChanged += new System.EventHandler(this.rdAguinaldo_CheckedChanged);
            // 
            // rdAdelanto
            // 
            this.rdAdelanto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdAdelanto.AutoSize = true;
            this.rdAdelanto.Depth = 0;
            this.rdAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdAdelanto.Location = new System.Drawing.Point(14, 527);
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
            this.rdResto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdResto.AutoSize = true;
            this.rdResto.Depth = 0;
            this.rdResto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdResto.Location = new System.Drawing.Point(14, 497);
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
            this.lstSucs.Size = new System.Drawing.Size(353, 460);
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
            this.grd.Frozen = 0;
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
            this.grd.Size = new System.Drawing.Size(446, 676);
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
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(14, 715);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(33, 19);
            this.txtCodigo.TabIndex = 4;
            this.txtCodigo.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 697);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cod";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 697);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Descripcion";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 697);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Importe";
            // 
            // txtImporte
            // 
            this.txtImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.Location = new System.Drawing.Point(218, 715);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(147, 19);
            this.txtImporte.TabIndex = 6;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(286, 715);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(166, 22);
            this.cmdCancelar.TabIndex = 1;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(114, 715);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(166, 22);
            this.cmdAceptar.TabIndex = 1;
            this.cmdAceptar.Texto = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // frmCargar_Sueldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 749);
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
            ((System.ComponentModel.ISupportInitialize)(this.nuDivisor)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nuDivisor;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImporte;
    }
}