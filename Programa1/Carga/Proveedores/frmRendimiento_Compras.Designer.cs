namespace Programa1.Carga
{
    partial class frmRendimiento_Compras
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilosC = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilosV = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalC = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalV = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdRendimiento_Compras = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lstCamiones = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.chOcultar = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.cProds = new Programa1.Controles.cProductos();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProvs = new Programa1.Controles.cProveedores();
            this.chKCompra = new MaterialSkin.Controls.MaterialCheckBox();
            this.chTVenta = new MaterialSkin.Controls.MaterialCheckBox();
            this.chTCompra = new MaterialSkin.Controls.MaterialCheckBox();
            this.chKVenta = new MaterialSkin.Controls.MaterialCheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilosC,
            this.lblKilosV,
            this.lblTotalC,
            this.lblTotalV});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 28);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 23);
            // 
            // lblCant
            // 
            this.lblCant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(60, 23);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilosC
            // 
            this.lblKilosC.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilosC.Name = "lblKilosC";
            this.lblKilosC.Size = new System.Drawing.Size(36, 23);
            this.lblKilosC.Text = "Kilos";
            this.lblKilosC.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilosV
            // 
            this.lblKilosV.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilosV.Name = "lblKilosV";
            this.lblKilosV.Size = new System.Drawing.Size(36, 23);
            this.lblKilosV.Text = "Kilos";
            this.lblKilosV.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalC
            // 
            this.lblTotalC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalC.Name = "lblTotalC";
            this.lblTotalC.Size = new System.Drawing.Size(49, 23);
            this.lblTotalC.Text = "Totales";
            this.lblTotalC.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalV
            // 
            this.lblTotalV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalV.Name = "lblTotalV";
            this.lblTotalV.Size = new System.Drawing.Size(49, 23);
            this.lblTotalV.Text = "Totales";
            this.lblTotalV.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grdRendimiento_Compras);
            this.splitContainer1.Panel1.Controls.Add(this.chKVenta);
            this.splitContainer1.Panel1.Controls.Add(this.chTCompra);
            this.splitContainer1.Panel1.Controls.Add(this.chTVenta);
            this.splitContainer1.Panel1.Controls.Add(this.chKCompra);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 687);
            this.splitContainer1.SplitterDistance = 831;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdRendimiento_Compras
            // 
            this.grdRendimiento_Compras.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdRendimiento_Compras.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdRendimiento_Compras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRendimiento_Compras.AutoResize = false;
            this.grdRendimiento_Compras.bColor = System.Drawing.SystemColors.Window;
            this.grdRendimiento_Compras.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdRendimiento_Compras.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdRendimiento_Compras.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdRendimiento_Compras.Col = 0;
            this.grdRendimiento_Compras.Cols = 10;
            this.grdRendimiento_Compras.DataMember = "";
            this.grdRendimiento_Compras.DataSource = null;
            this.grdRendimiento_Compras.EnableEdicion = false;
            this.grdRendimiento_Compras.Encabezado = "";
            this.grdRendimiento_Compras.fColor = System.Drawing.SystemColors.Control;
            this.grdRendimiento_Compras.FixCols = 0;
            this.grdRendimiento_Compras.FixRows = 0;
            this.grdRendimiento_Compras.Frozen = 0;
            this.grdRendimiento_Compras.FuenteEncabezado = null;
            this.grdRendimiento_Compras.FuentePieDePagina = null;
            this.grdRendimiento_Compras.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdRendimiento_Compras.Location = new System.Drawing.Point(3, 3);
            this.grdRendimiento_Compras.Name = "grdRendimiento_Compras";
            this.grdRendimiento_Compras.PieDePagina = "\t\tPage {0} of {1}";
            this.grdRendimiento_Compras.PintarFilaSel = false;
            this.grdRendimiento_Compras.Redraw = true;
            this.grdRendimiento_Compras.Row = 0;
            this.grdRendimiento_Compras.Rows = 50;
            this.grdRendimiento_Compras.Size = new System.Drawing.Size(825, 648);
            this.grdRendimiento_Compras.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lstCamiones);
            this.splitContainer3.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.chOcultar);
            this.splitContainer3.Panel1.Controls.Add(this.cProds);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cFecha);
            this.splitContainer3.Panel2.Controls.Add(this.cProvs);
            this.splitContainer3.Size = new System.Drawing.Size(523, 687);
            this.splitContainer3.SplitterDistance = 256;
            this.splitContainer3.TabIndex = 0;
            // 
            // lstCamiones
            // 
            this.lstCamiones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCamiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCamiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstCamiones.FormattingEnabled = true;
            this.lstCamiones.ItemHeight = 18;
            this.lstCamiones.Location = new System.Drawing.Point(3, 579);
            this.lstCamiones.Name = "lstCamiones";
            this.lstCamiones.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCamiones.Size = new System.Drawing.Size(250, 72);
            this.lstCamiones.TabIndex = 7;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 558);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(76, 18);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Camiones";
            // 
            // chOcultar
            // 
            this.chOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chOcultar.AutoSize = true;
            this.chOcultar.Checked = true;
            this.chOcultar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chOcultar.Depth = 0;
            this.chOcultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chOcultar.Location = new System.Drawing.Point(3, 654);
            this.chOcultar.Margin = new System.Windows.Forms.Padding(0);
            this.chOcultar.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chOcultar.MouseState = MaterialSkin.MouseState.HOVER;
            this.chOcultar.Name = "chOcultar";
            this.chOcultar.Ripple = true;
            this.chOcultar.Size = new System.Drawing.Size(151, 30);
            this.chOcultar.TabIndex = 2;
            this.chOcultar.Text = "Ocultar diferencia 0";
            this.chOcultar.UseVisualStyleBackColor = true;
            this.chOcultar.CheckedChanged += new System.EventHandler(this.ChOcultar_CheckedChanged);
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMostrar.Location = new System.Drawing.Point(1257, 689);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(102, 23);
            this.cmdMostrar.TabIndex = 4;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(3, 3);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(253, 534);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(3, 475);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(257, 209);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cProvs
            // 
            this.cProvs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProvs.BackColor = System.Drawing.Color.Gainsboro;
            this.cProvs.Filtro_In = "";
            this.cProvs.Location = new System.Drawing.Point(2, 3);
            this.cProvs.Mostrar_Tipo = true;
            this.cProvs.Name = "cProvs";
            this.cProvs.Size = new System.Drawing.Size(258, 466);
            this.cProvs.TabIndex = 2;
            this.cProvs.Titulo = "Proveedores";
            this.cProvs.Valor_Actual = -1;
            this.cProvs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // chKCompra
            // 
            this.chKCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chKCompra.AutoSize = true;
            this.chKCompra.Checked = true;
            this.chKCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chKCompra.Depth = 0;
            this.chKCompra.Font = new System.Drawing.Font("Roboto", 10F);
            this.chKCompra.Location = new System.Drawing.Point(3, 654);
            this.chKCompra.Margin = new System.Windows.Forms.Padding(0);
            this.chKCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chKCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.chKCompra.Name = "chKCompra";
            this.chKCompra.Ripple = true;
            this.chKCompra.Size = new System.Drawing.Size(87, 30);
            this.chKCompra.TabIndex = 1;
            this.chKCompra.Text = "KCompra";
            this.chKCompra.UseVisualStyleBackColor = true;
            this.chKCompra.CheckedChanged += new System.EventHandler(this.chKCompra_CheckedChanged);
            // 
            // chTVenta
            // 
            this.chTVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chTVenta.AutoSize = true;
            this.chTVenta.Checked = true;
            this.chTVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chTVenta.Depth = 0;
            this.chTVenta.Font = new System.Drawing.Font("Roboto", 10F);
            this.chTVenta.Location = new System.Drawing.Point(263, 654);
            this.chTVenta.Margin = new System.Windows.Forms.Padding(0);
            this.chTVenta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chTVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.chTVenta.Name = "chTVenta";
            this.chTVenta.Ripple = true;
            this.chTVenta.Size = new System.Drawing.Size(74, 30);
            this.chTVenta.TabIndex = 1;
            this.chTVenta.Text = "TVenta";
            this.chTVenta.UseVisualStyleBackColor = true;
            this.chTVenta.CheckedChanged += new System.EventHandler(this.chTVenta_CheckedChanged);
            // 
            // chTCompra
            // 
            this.chTCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chTCompra.AutoSize = true;
            this.chTCompra.Checked = true;
            this.chTCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chTCompra.Depth = 0;
            this.chTCompra.Font = new System.Drawing.Font("Roboto", 10F);
            this.chTCompra.Location = new System.Drawing.Point(172, 654);
            this.chTCompra.Margin = new System.Windows.Forms.Padding(0);
            this.chTCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chTCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.chTCompra.Name = "chTCompra";
            this.chTCompra.Ripple = true;
            this.chTCompra.Size = new System.Drawing.Size(87, 30);
            this.chTCompra.TabIndex = 1;
            this.chTCompra.Text = "TCompra";
            this.chTCompra.UseVisualStyleBackColor = true;
            this.chTCompra.CheckedChanged += new System.EventHandler(this.chTCompra_CheckedChanged);
            // 
            // chKVenta
            // 
            this.chKVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chKVenta.AutoSize = true;
            this.chKVenta.Checked = true;
            this.chKVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chKVenta.Depth = 0;
            this.chKVenta.Font = new System.Drawing.Font("Roboto", 10F);
            this.chKVenta.Location = new System.Drawing.Point(94, 654);
            this.chKVenta.Margin = new System.Windows.Forms.Padding(0);
            this.chKVenta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chKVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.chKVenta.Name = "chKVenta";
            this.chKVenta.Ripple = true;
            this.chKVenta.Size = new System.Drawing.Size(74, 30);
            this.chKVenta.TabIndex = 1;
            this.chKVenta.Text = "KVenta";
            this.chKVenta.UseVisualStyleBackColor = true;
            this.chKVenta.CheckedChanged += new System.EventHandler(this.chKVenta_CheckedChanged);
            // 
            // frmRendimiento_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmRendimiento_Compras";
            this.Text = "Rendimiento_Compras";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRendimiento_Compras_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdRendimiento_Compras;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cProveedores cProvs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalC;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilosC;
        private System.Windows.Forms.ToolStripStatusLabel lblKilosV;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalV;
        private MaterialSkin.Controls.MaterialCheckBox chOcultar;
        private System.Windows.Forms.ListBox lstCamiones;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCheckBox chKCompra;
        private MaterialSkin.Controls.MaterialCheckBox chKVenta;
        private MaterialSkin.Controls.MaterialCheckBox chTCompra;
        private MaterialSkin.Controls.MaterialCheckBox chTVenta;
    }
}