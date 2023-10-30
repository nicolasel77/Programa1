namespace Programa1.Carga.Tesoreria
{

    partial class frmTarjetas
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
            this.grdTarjetas = new Grilla2.SpeedGrilla();
            this.lstTipos = new System.Windows.Forms.ListBox();
            this.chAgrupar = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSuc = new MaterialSkin.Controls.MaterialCheckBox();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            this.chTipo = new MaterialSkin.Controls.MaterialCheckBox();
            this.chAcreditados = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.rdOrdenPorSuc = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdOrdenxFecha = new MaterialSkin.Controls.MaterialRadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstCuentas = new System.Windows.Forms.ListBox();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.panel2.SuspendLayout();
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
            // grdTarjetas
            // 
            this.grdTarjetas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTarjetas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTarjetas.AutoResize = false;
            this.grdTarjetas.bColor = System.Drawing.SystemColors.Window;
            this.grdTarjetas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTarjetas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTarjetas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTarjetas.Col = 0;
            this.grdTarjetas.Cols = 1;
            this.grdTarjetas.DataMember = "";
            this.grdTarjetas.DataSource = null;
            this.grdTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTarjetas.EnableEdicion = false;
            this.grdTarjetas.Encabezado = "";
            this.grdTarjetas.fColor = System.Drawing.SystemColors.Control;
            this.grdTarjetas.FixCols = 0;
            this.grdTarjetas.FixRows = 0;
            this.grdTarjetas.Frozen = 0;
            this.grdTarjetas.FuenteEncabezado = null;
            this.grdTarjetas.FuentePieDePagina = null;
            this.grdTarjetas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTarjetas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdTarjetas.Location = new System.Drawing.Point(0, 0);
            this.grdTarjetas.Name = "grdTarjetas";
            this.grdTarjetas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTarjetas.PintarFilaSel = true;
            this.grdTarjetas.Redraw = true;
            this.grdTarjetas.Row = 0;
            this.grdTarjetas.Rows = 1;
            this.grdTarjetas.Size = new System.Drawing.Size(884, 715);
            this.grdTarjetas.TabIndex = 0;
            this.grdTarjetas.Load += new System.EventHandler(this.grdTarjetas_Load);
            // 
            // lstTipos
            // 
            this.lstTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipos.FormattingEnabled = true;
            this.lstTipos.ItemHeight = 18;
            this.lstTipos.Location = new System.Drawing.Point(3, 154);
            this.lstTipos.Name = "lstTipos";
            this.lstTipos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTipos.Size = new System.Drawing.Size(165, 180);
            this.lstTipos.TabIndex = 2;
            this.lstTipos.SelectedIndexChanged += new System.EventHandler(this.lstTipos_SelectedIndexChanged);
            this.lstTipos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstTipos_MouseUp);
            // 
            // chAgrupar
            // 
            this.chAgrupar.AutoSize = true;
            this.chAgrupar.Checked = true;
            this.chAgrupar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAgrupar.Depth = 0;
            this.chAgrupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chAgrupar.Location = new System.Drawing.Point(3, 3);
            this.chAgrupar.Margin = new System.Windows.Forms.Padding(0);
            this.chAgrupar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chAgrupar.MouseState = MaterialSkin.MouseState.HOVER;
            this.chAgrupar.Name = "chAgrupar";
            this.chAgrupar.Ripple = true;
            this.chAgrupar.Size = new System.Drawing.Size(79, 30);
            this.chAgrupar.TabIndex = 3;
            this.chAgrupar.Text = "Agrupar";
            this.chAgrupar.UseVisualStyleBackColor = true;
            this.chAgrupar.CheckedChanged += new System.EventHandler(this.chAgrupar_CheckedChanged);
            // 
            // chSuc
            // 
            this.chSuc.AutoSize = true;
            this.chSuc.Checked = true;
            this.chSuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSuc.Depth = 0;
            this.chSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chSuc.Location = new System.Drawing.Point(3, 33);
            this.chSuc.Margin = new System.Windows.Forms.Padding(0);
            this.chSuc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSuc.Name = "chSuc";
            this.chSuc.Ripple = true;
            this.chSuc.Size = new System.Drawing.Size(53, 30);
            this.chSuc.TabIndex = 4;
            this.chSuc.Text = "Suc";
            this.chSuc.UseVisualStyleBackColor = true;
            this.chSuc.CheckedChanged += new System.EventHandler(this.chSuc_CheckedChanged);
            // 
            // chFecha
            // 
            this.chFecha.AutoSize = true;
            this.chFecha.Checked = true;
            this.chFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFecha.Depth = 0;
            this.chFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chFecha.Location = new System.Drawing.Point(3, 63);
            this.chFecha.Margin = new System.Windows.Forms.Padding(0);
            this.chFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFecha.Name = "chFecha";
            this.chFecha.Ripple = true;
            this.chFecha.Size = new System.Drawing.Size(67, 30);
            this.chFecha.TabIndex = 5;
            this.chFecha.Text = "Fecha";
            this.chFecha.UseVisualStyleBackColor = true;
            this.chFecha.CheckedChanged += new System.EventHandler(this.chFecha_CheckedChanged);
            // 
            // chTipo
            // 
            this.chTipo.AutoSize = true;
            this.chTipo.Depth = 0;
            this.chTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chTipo.Location = new System.Drawing.Point(3, 93);
            this.chTipo.Margin = new System.Windows.Forms.Padding(0);
            this.chTipo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chTipo.MouseState = MaterialSkin.MouseState.HOVER;
            this.chTipo.Name = "chTipo";
            this.chTipo.Ripple = true;
            this.chTipo.Size = new System.Drawing.Size(57, 30);
            this.chTipo.TabIndex = 6;
            this.chTipo.Text = "Tipo";
            this.chTipo.UseVisualStyleBackColor = true;
            this.chTipo.CheckedChanged += new System.EventHandler(this.chTipo_CheckedChanged);
            // 
            // chAcreditados
            // 
            this.chAcreditados.AutoSize = true;
            this.chAcreditados.Depth = 0;
            this.chAcreditados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chAcreditados.Location = new System.Drawing.Point(3, 121);
            this.chAcreditados.Margin = new System.Windows.Forms.Padding(0);
            this.chAcreditados.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chAcreditados.MouseState = MaterialSkin.MouseState.HOVER;
            this.chAcreditados.Name = "chAcreditados";
            this.chAcreditados.Ripple = true;
            this.chAcreditados.Size = new System.Drawing.Size(134, 30);
            this.chAcreditados.TabIndex = 7;
            this.chAcreditados.Text = "Solo acreditados";
            this.chAcreditados.UseVisualStyleBackColor = true;
            this.chAcreditados.CheckedChanged += new System.EventHandler(this.chAcreditados_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(3, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 2);
            this.panel3.TabIndex = 9;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 2);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 18);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(57, 2);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(24, 18);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "$0";
            // 
            // rdOrdenPorSuc
            // 
            this.rdOrdenPorSuc.AutoSize = true;
            this.rdOrdenPorSuc.Depth = 0;
            this.rdOrdenPorSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdOrdenPorSuc.Location = new System.Drawing.Point(3, 371);
            this.rdOrdenPorSuc.Margin = new System.Windows.Forms.Padding(0);
            this.rdOrdenPorSuc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdOrdenPorSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdOrdenPorSuc.Name = "rdOrdenPorSuc";
            this.rdOrdenPorSuc.Ripple = true;
            this.rdOrdenPorSuc.Size = new System.Drawing.Size(127, 30);
            this.rdOrdenPorSuc.TabIndex = 12;
            this.rdOrdenPorSuc.TabStop = true;
            this.rdOrdenPorSuc.Text = "Ordenar por suc";
            this.rdOrdenPorSuc.UseVisualStyleBackColor = true;
            this.rdOrdenPorSuc.CheckedChanged += new System.EventHandler(this.rdOrdenPorSuc_CheckedChanged);
            // 
            // rdOrdenxFecha
            // 
            this.rdOrdenxFecha.AutoSize = true;
            this.rdOrdenxFecha.Checked = true;
            this.rdOrdenxFecha.Depth = 0;
            this.rdOrdenxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdOrdenxFecha.Location = new System.Drawing.Point(3, 341);
            this.rdOrdenxFecha.Margin = new System.Windows.Forms.Padding(0);
            this.rdOrdenxFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdOrdenxFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdOrdenxFecha.Name = "rdOrdenxFecha";
            this.rdOrdenxFecha.Ripple = true;
            this.rdOrdenxFecha.Size = new System.Drawing.Size(143, 30);
            this.rdOrdenxFecha.TabIndex = 13;
            this.rdOrdenxFecha.TabStop = true;
            this.rdOrdenxFecha.Text = "Ordenar por Fecha";
            this.rdOrdenxFecha.UseVisualStyleBackColor = true;
            this.rdOrdenxFecha.CheckedChanged += new System.EventHandler(this.rdOrdenxFecha_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Location = new System.Drawing.Point(12, 733);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 24);
            this.panel2.TabIndex = 19;
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
            this.splitContainer1.Panel1.Controls.Add(this.grdTarjetas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1378, 715);
            this.splitContainer1.SplitterDistance = 884;
            this.splitContainer1.TabIndex = 20;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chAgrupar);
            this.splitContainer2.Panel1.Controls.Add(this.lstCuentas);
            this.splitContainer2.Panel1.Controls.Add(this.lstTipos);
            this.splitContainer2.Panel1.Controls.Add(this.rdOrdenxFecha);
            this.splitContainer2.Panel1.Controls.Add(this.chSuc);
            this.splitContainer2.Panel1.Controls.Add(this.rdOrdenPorSuc);
            this.splitContainer2.Panel1.Controls.Add(this.chFecha);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.chTipo);
            this.splitContainer2.Panel1.Controls.Add(this.cFecha);
            this.splitContainer2.Panel1.Controls.Add(this.chAcreditados);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cSuc);
            this.splitContainer2.Size = new System.Drawing.Size(490, 715);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstCuentas
            // 
            this.lstCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCuentas.FormattingEnabled = true;
            this.lstCuentas.ItemHeight = 18;
            this.lstCuentas.Location = new System.Drawing.Point(3, 404);
            this.lstCuentas.Name = "lstCuentas";
            this.lstCuentas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCuentas.Size = new System.Drawing.Size(165, 108);
            this.lstCuentas.TabIndex = 2;
            this.lstCuentas.SelectedIndexChanged += new System.EventHandler(this.lstCuentas_SelectedIndexChanged);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(3, 523);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(160, 189);
            this.cFecha.TabIndex = 8;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // cSuc
            // 
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(0, 0);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSuc.Size = new System.Drawing.Size(320, 715);
            this.cSuc.TabIndex = 1;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.cSuc_Cambio_Seleccion);
            // 
            // frmTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 761);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "frmTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjetas";
            this.Load += new System.EventHandler(this.frmTarjetas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grdTarjetas;
        private Controles.cSucursales cSuc;
        private System.Windows.Forms.ListBox lstTipos;
        private MaterialSkin.Controls.MaterialCheckBox chAgrupar;
        private MaterialSkin.Controls.MaterialCheckBox chSuc;
        private MaterialSkin.Controls.MaterialCheckBox chFecha;
        private MaterialSkin.Controls.MaterialCheckBox chTipo;
        private MaterialSkin.Controls.MaterialCheckBox chAcreditados;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private MaterialSkin.Controls.MaterialRadioButton rdOrdenPorSuc;
        private MaterialSkin.Controls.MaterialRadioButton rdOrdenxFecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lstCuentas;
    }
}