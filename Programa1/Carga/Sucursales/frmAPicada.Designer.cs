namespace Programa1.Carga
{
    partial class frmAPicada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAPicada));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilosA = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilosS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalA = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblReintegro = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdAPicada = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cProdA = new Programa1.Controles.cProductos();
            this.cProdS = new Programa1.Controles.cProductos();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.paCambio = new System.Windows.Forms.Panel();
            this.cmdCambio = new MaterialSkin.Controls.MaterialFlatButton();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.paCambio.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilosA,
            this.lblKilosS,
            this.lblTotalA,
            this.lblTotalS,
            this.lblReintegro});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1080, 28);
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
            // lblKilosA
            // 
            this.lblKilosA.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilosA.Name = "lblKilosA";
            this.lblKilosA.Size = new System.Drawing.Size(36, 23);
            this.lblKilosA.Text = "Kilos";
            this.lblKilosA.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilosS
            // 
            this.lblKilosS.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilosS.Name = "lblKilosS";
            this.lblKilosS.Size = new System.Drawing.Size(36, 23);
            this.lblKilosS.Text = "Kilos";
            this.lblKilosS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalA
            // 
            this.lblTotalA.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalA.Name = "lblTotalA";
            this.lblTotalA.Size = new System.Drawing.Size(49, 23);
            this.lblTotalA.Text = "Totales";
            this.lblTotalA.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(49, 23);
            this.lblTotalS.Text = "Totales";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblReintegro
            // 
            this.lblReintegro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReintegro.Name = "lblReintegro";
            this.lblReintegro.Size = new System.Drawing.Size(65, 23);
            this.lblReintegro.Text = "Reintegro";
            this.lblReintegro.Click += new System.EventHandler(this.LblCant_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.grdAPicada);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1080, 687);
            this.splitContainer1.SplitterDistance = 658;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdAPicada
            // 
            this.grdAPicada.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAPicada.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAPicada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAPicada.AutoResize = false;
            this.grdAPicada.bColor = System.Drawing.SystemColors.Window;
            this.grdAPicada.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAPicada.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAPicada.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAPicada.Col = 0;
            this.grdAPicada.Cols = 10;
            this.grdAPicada.DataMember = "";
            this.grdAPicada.DataSource = null;
            this.grdAPicada.EnableEdicion = true;
            this.grdAPicada.Encabezado = "";
            this.grdAPicada.fColor = System.Drawing.SystemColors.Control;
            this.grdAPicada.FixCols = 0;
            this.grdAPicada.FixRows = 0;
            this.grdAPicada.FuenteEncabezado = null;
            this.grdAPicada.FuentePieDePagina = null;
            this.grdAPicada.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAPicada.Location = new System.Drawing.Point(3, 3);
            this.grdAPicada.MenuActivado = false;
            this.grdAPicada.Name = "grdAPicada";
            this.grdAPicada.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAPicada.PintarFilaSel = true;
            this.grdAPicada.Redraw = true;
            this.grdAPicada.Row = 0;
            this.grdAPicada.Rows = 50;
            this.grdAPicada.Size = new System.Drawing.Size(652, 681);
            this.grdAPicada.TabIndex = 0;
            this.grdAPicada.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdAPicada_Editado);
            this.grdAPicada.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdAPicada_CambioFila);
            this.grdAPicada.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdAPicada_KeyUp);
            this.grdAPicada.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdAPicada_KeyPress);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(414, 687);
            this.splitContainer3.SplitterDistance = 202;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cProdA);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cProdS);
            this.splitContainer2.Size = new System.Drawing.Size(202, 687);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 2;
            // 
            // cProdA
            // 
            this.cProdA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProdA.BackColor = System.Drawing.Color.Gainsboro;
            this.cProdA.Filtrar_Ver = true;
            this.cProdA.Filtro_In = "";
            this.cProdA.Location = new System.Drawing.Point(3, 3);
            this.cProdA.Mostrar_Tipo = true;
            this.cProdA.Name = "cProdA";
            this.cProdA.Size = new System.Drawing.Size(196, 321);
            this.cProdA.TabIndex = 1;
            this.cProdA.Titulo = "Productos A Picada";
            this.cProdA.Valor_Actual = -1;
            this.cProdA.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cProdS
            // 
            this.cProdS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProdS.BackColor = System.Drawing.Color.Gainsboro;
            this.cProdS.Filtrar_Ver = true;
            this.cProdS.Filtro_In = "";
            this.cProdS.Location = new System.Drawing.Point(3, -1);
            this.cProdS.Mostrar_Tipo = true;
            this.cProdS.Name = "cProdS";
            this.cProdS.Size = new System.Drawing.Size(196, 354);
            this.cProdS.TabIndex = 1;
            this.cProdS.Titulo = "Productos Salida";
            this.cProdS.Valor_Actual = -1;
            this.cProdS.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(202, 184);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cSucs
            // 
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(0, 0);
            this.cSucs.Mostrar_Tipo = true;
            this.cSucs.Name = "cSucs";
            this.cSucs.Size = new System.Drawing.Size(202, 528);
            this.cSucs.TabIndex = 2;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.paCambio);
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(485, 687);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 27);
            this.panel1.TabIndex = 7;
            // 
            // paCambio
            // 
            this.paCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paCambio.Controls.Add(this.cmdCambio);
            this.paCambio.Location = new System.Drawing.Point(44, 2);
            this.paCambio.Name = "paCambio";
            this.paCambio.Size = new System.Drawing.Size(177, 25);
            this.paCambio.TabIndex = 5;
            // 
            // cmdCambio
            // 
            this.cmdCambio.AutoSize = true;
            this.cmdCambio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCambio.Depth = 0;
            this.cmdCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCambio.Location = new System.Drawing.Point(0, 0);
            this.cmdCambio.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCambio.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCambio.Name = "cmdCambio";
            this.cmdCambio.Primary = false;
            this.cmdCambio.Size = new System.Drawing.Size(177, 25);
            this.cmdCambio.TabIndex = 0;
            this.cmdCambio.Text = "Cambio Masivo";
            this.cmdCambio.UseVisualStyleBackColor = true;
            this.cmdCambio.Click += new System.EventHandler(this.CmdCambioMasivo_Click);
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(412, 2);
            this.paMostrar.Name = "paMostrar";
            this.paMostrar.Size = new System.Drawing.Size(177, 25);
            this.paMostrar.TabIndex = 5;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.AutoSize = true;
            this.cmdMostrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMostrar.Depth = 0;
            this.cmdMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMostrar.Location = new System.Drawing.Point(0, 0);
            this.cmdMostrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Primary = false;
            this.cmdMostrar.Size = new System.Drawing.Size(177, 25);
            this.cmdMostrar.TabIndex = 0;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // paLimpiar
            // 
            this.paLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paLimpiar.Controls.Add(this.cmdLimpiar);
            this.paLimpiar.Location = new System.Drawing.Point(228, 2);
            this.paLimpiar.Name = "paLimpiar";
            this.paLimpiar.Size = new System.Drawing.Size(177, 25);
            this.paLimpiar.TabIndex = 5;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.AutoSize = true;
            this.cmdLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdLimpiar.Depth = 0;
            this.cmdLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdLimpiar.Location = new System.Drawing.Point(0, 0);
            this.cmdLimpiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Primary = false;
            this.cmdLimpiar.Size = new System.Drawing.Size(177, 25);
            this.cmdLimpiar.TabIndex = 0;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.cSucs);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cFecha);
            this.splitContainer4.Size = new System.Drawing.Size(202, 684);
            this.splitContainer4.SplitterDistance = 528;
            this.splitContainer4.SplitterWidth = 8;
            this.splitContainer4.TabIndex = 4;
            // 
            // frmAPicada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmAPicada";
            this.Text = "APicada";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAPicada_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.paCambio.ResumeLayout(false);
            this.paCambio.PerformLayout();
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdAPicada;
        private Controles.cProductos cProdA;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cSucursales cSucs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalA;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilosA;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controles.cProductos cProdS;
        private System.Windows.Forms.ToolStripStatusLabel lblKilosS;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblReintegro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paCambio;
        private MaterialSkin.Controls.MaterialFlatButton cmdCambio;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}