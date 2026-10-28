namespace Programa1.Carga.TM
{
    partial class frmChequesTM
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
            this.label1 = new System.Windows.Forms.Label();
            this.lstBancos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstCajas = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdFechaEntrada = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdFechaAcreditacion = new MaterialSkin.Controls.MaterialRadioButton();
            this.cfecha = new Programa1.Controles.cFechas();
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
            this.grd.fColor = System.Drawing.Color.Silver;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.Frozen = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.LimpiarEstilosAntesDeOrdenar = false;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(1191, 805);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            this.grd.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grd_KeyUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1209, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bancos";
            // 
            // lstBancos
            // 
            this.lstBancos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBancos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBancos.FormattingEnabled = true;
            this.lstBancos.ItemHeight = 16;
            this.lstBancos.Location = new System.Drawing.Point(1212, 31);
            this.lstBancos.Name = "lstBancos";
            this.lstBancos.Size = new System.Drawing.Size(220, 176);
            this.lstBancos.TabIndex = 2;
            this.lstBancos.SelectedIndexChanged += new System.EventHandler(this.lstBancos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1209, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cajas";
            // 
            // lstCajas
            // 
            this.lstCajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCajas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCajas.FormattingEnabled = true;
            this.lstCajas.ItemHeight = 16;
            this.lstCajas.Location = new System.Drawing.Point(1212, 234);
            this.lstCajas.Name = "lstCajas";
            this.lstCajas.Size = new System.Drawing.Size(220, 208);
            this.lstCajas.TabIndex = 2;
            this.lstCajas.SelectedIndexChanged += new System.EventHandler(this.lstCuentas_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1209, 784);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(1212, 803);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(220, 15);
            this.txtNumero.TabIndex = 4;
            this.txtNumero.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1209, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fecha";
            // 
            // rdFechaEntrada
            // 
            this.rdFechaEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdFechaEntrada.AutoSize = true;
            this.rdFechaEntrada.Checked = true;
            this.rdFechaEntrada.Depth = 0;
            this.rdFechaEntrada.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdFechaEntrada.Location = new System.Drawing.Point(1206, 472);
            this.rdFechaEntrada.Margin = new System.Windows.Forms.Padding(0);
            this.rdFechaEntrada.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdFechaEntrada.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdFechaEntrada.Name = "rdFechaEntrada";
            this.rdFechaEntrada.Ripple = true;
            this.rdFechaEntrada.Size = new System.Drawing.Size(76, 30);
            this.rdFechaEntrada.TabIndex = 5;
            this.rdFechaEntrada.TabStop = true;
            this.rdFechaEntrada.Text = "entrada";
            this.rdFechaEntrada.UseVisualStyleBackColor = true;
            this.rdFechaEntrada.CheckedChanged += new System.EventHandler(this.rdFechaEntrada_CheckedChanged);
            // 
            // rdFechaAcreditacion
            // 
            this.rdFechaAcreditacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdFechaAcreditacion.AutoSize = true;
            this.rdFechaAcreditacion.Depth = 0;
            this.rdFechaAcreditacion.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdFechaAcreditacion.Location = new System.Drawing.Point(1295, 472);
            this.rdFechaAcreditacion.Margin = new System.Windows.Forms.Padding(0);
            this.rdFechaAcreditacion.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdFechaAcreditacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdFechaAcreditacion.Name = "rdFechaAcreditacion";
            this.rdFechaAcreditacion.Ripple = true;
            this.rdFechaAcreditacion.Size = new System.Drawing.Size(105, 30);
            this.rdFechaAcreditacion.TabIndex = 5;
            this.rdFechaAcreditacion.Text = "acreditación";
            this.rdFechaAcreditacion.UseVisualStyleBackColor = true;
            // 
            // cfecha
            // 
            this.cfecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cfecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cfecha.Location = new System.Drawing.Point(1212, 505);
            this.cfecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cfecha.Mostrar = 0;
            this.cfecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cfecha.Name = "cfecha";
            this.cfecha.Size = new System.Drawing.Size(223, 276);
            this.cfecha.TabIndex = 3;
            this.cfecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cfecha.Cambio_Seleccion += new System.EventHandler(this.cfecha_Cambio_Seleccion);
            // 
            // frmChequesTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 829);
            this.Controls.Add(this.rdFechaAcreditacion);
            this.Controls.Add(this.rdFechaEntrada);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.cfecha);
            this.Controls.Add(this.lstCajas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBancos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grd);
            this.Name = "frmChequesTM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cheques";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBancos;
        private Controles.cFechas cfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstCajas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialRadioButton rdFechaEntrada;
        private MaterialSkin.Controls.MaterialRadioButton rdFechaAcreditacion;
    }
}