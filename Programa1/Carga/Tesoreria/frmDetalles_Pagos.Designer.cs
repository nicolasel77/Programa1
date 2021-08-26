namespace Programa1.Carga.Tesoreria
{

    partial class frmDetalles_Pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalles_Pagos));
            this.grdDetalles = new Grilla2.SpeedGrilla();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            this.cFecha = new Programa1.Controles.cFechas();
            this.chFcarga = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cFechaCarga = new Programa1.Controles.cFechas();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdDetalles
            // 
            this.grdDetalles.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalles.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetalles.AutoResize = false;
            this.grdDetalles.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalles.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalles.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalles.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalles.Col = 0;
            this.grdDetalles.Cols = 1;
            this.grdDetalles.DataMember = "";
            this.grdDetalles.DataSource = null;
            this.grdDetalles.EnableEdicion = false;
            this.grdDetalles.Encabezado = "";
            this.grdDetalles.fColor = System.Drawing.SystemColors.Control;
            this.grdDetalles.FixCols = 0;
            this.grdDetalles.FixRows = 0;
            this.grdDetalles.FuenteEncabezado = null;
            this.grdDetalles.FuentePieDePagina = null;
            this.grdDetalles.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalles.Location = new System.Drawing.Point(12, 12);
            this.grdDetalles.Name = "grdDetalles";
            this.grdDetalles.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalles.PintarFilaSel = true;
            this.grdDetalles.Redraw = true;
            this.grdDetalles.Row = 0;
            this.grdDetalles.Rows = 1;
            this.grdDetalles.Size = new System.Drawing.Size(688, 568);
            this.grdDetalles.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdMostrar);
            this.panel1.Location = new System.Drawing.Point(703, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 37);
            this.panel1.TabIndex = 12;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.AutoSize = true;
            this.cmdMostrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMostrar.Depth = 0;
            this.cmdMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMostrar.Location = new System.Drawing.Point(0, 0);
            this.cmdMostrar.Margin = new System.Windows.Forms.Padding(0);
            this.cmdMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Primary = false;
            this.cmdMostrar.Size = new System.Drawing.Size(256, 37);
            this.cmdMostrar.TabIndex = 11;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.cmdMostrar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(3, 4);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(48, 19);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Total:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chFecha);
            this.panel3.Controls.Add(this.cFecha);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 284);
            this.panel3.TabIndex = 15;
            // 
            // chFecha
            // 
            this.chFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chFecha.AutoSize = true;
            this.chFecha.Checked = true;
            this.chFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFecha.Depth = 0;
            this.chFecha.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFecha.Location = new System.Drawing.Point(0, 0);
            this.chFecha.Margin = new System.Windows.Forms.Padding(0);
            this.chFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFecha.Name = "chFecha";
            this.chFecha.Ripple = true;
            this.chFecha.Size = new System.Drawing.Size(67, 30);
            this.chFecha.TabIndex = 2;
            this.chFecha.Text = "Fecha";
            this.chFecha.UseVisualStyleBackColor = true;
            this.chFecha.CheckedChanged += new System.EventHandler(this.chFecha_CheckedChanged);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 32);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(188, 249);
            this.cFecha.TabIndex = 1;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // chFcarga
            // 
            this.chFcarga.AutoSize = true;
            this.chFcarga.Checked = true;
            this.chFcarga.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFcarga.Depth = 0;
            this.chFcarga.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFcarga.Location = new System.Drawing.Point(-4, -6);
            this.chFcarga.Margin = new System.Windows.Forms.Padding(0);
            this.chFcarga.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFcarga.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFcarga.Name = "chFcarga";
            this.chFcarga.Ripple = true;
            this.chFcarga.Size = new System.Drawing.Size(105, 30);
            this.chFcarga.TabIndex = 3;
            this.chFcarga.Text = "Fecha carga";
            this.chFcarga.UseVisualStyleBackColor = true;
            this.chFcarga.CheckedChanged += new System.EventHandler(this.chFcarga_CheckedChanged_1);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.chFcarga);
            this.panel4.Controls.Add(this.cFechaCarga);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(184, 274);
            this.panel4.TabIndex = 16;
            // 
            // cFechaCarga
            // 
            this.cFechaCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFechaCarga.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFechaCarga.Location = new System.Drawing.Point(-1, 24);
            this.cFechaCarga.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFechaCarga.Mostrar = 0;
            this.cFechaCarga.Name = "cFechaCarga";
            this.cFechaCarga.Size = new System.Drawing.Size(188, 247);
            this.cFechaCarga.TabIndex = 0;
            this.cFechaCarga.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFechaCarga.Cambio_Seleccion += new System.EventHandler(this.cFechaCarga_Cambio_Seleccion);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(960, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(190, 568);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 17;
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(706, 12);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = false;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSuc.Size = new System.Drawing.Size(253, 508);
            this.cSuc.TabIndex = 3;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.cSuc_Cambio_Seleccion);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Location = new System.Drawing.Point(706, 519);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 24);
            this.panel2.TabIndex = 18;
            // 
            // frmDetalles_Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 590);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdDetalles);
            this.Controls.Add(this.cSuc);
            this.Name = "frmDetalles_Pagos";
            this.Text = "frmDetalles_Pagos";
            this.Load += new System.EventHandler(this.frmDetalles_Pagos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.cFechas cFechaCarga;
        private Controles.cFechas cFecha;
        private Grilla2.SpeedGrilla grdDetalles;
        private Controles.cSucursales cSuc;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialCheckBox chFcarga;
        private MaterialSkin.Controls.MaterialCheckBox chFecha;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
    }
}