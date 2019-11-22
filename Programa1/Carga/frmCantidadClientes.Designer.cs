namespace Programa1.Carga
{
    partial class frmCantidad_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCantidad_Clientes));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdCantidad_Clientes = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.cmdCambioMasivo = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
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
            this.lblKilos,
            this.lblTotal});
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
            // lblKilos
            // 
            this.lblKilos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(36, 23);
            this.lblKilos.Text = "Kilos";
            this.lblKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 23);
            this.lblTotal.Text = "Totales";
            this.lblTotal.Click += new System.EventHandler(this.LblCant_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.grdCantidad_Clientes);
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
            // grdCantidad_Clientes
            // 
            this.grdCantidad_Clientes.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCantidad_Clientes.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCantidad_Clientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCantidad_Clientes.AutoResize = false;
            this.grdCantidad_Clientes.bColor = System.Drawing.SystemColors.Window;
            this.grdCantidad_Clientes.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCantidad_Clientes.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCantidad_Clientes.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCantidad_Clientes.Col = 0;
            this.grdCantidad_Clientes.Cols = 10;
            this.grdCantidad_Clientes.DataMember = "";
            this.grdCantidad_Clientes.DataSource = null;
            this.grdCantidad_Clientes.EnableEdicion = true;
            this.grdCantidad_Clientes.Encabezado = "";
            this.grdCantidad_Clientes.fColor = System.Drawing.SystemColors.Control;
            this.grdCantidad_Clientes.FixCols = 0;
            this.grdCantidad_Clientes.FixRows = 0;
            this.grdCantidad_Clientes.FuenteEncabezado = null;
            this.grdCantidad_Clientes.FuentePieDePagina = null;
            this.grdCantidad_Clientes.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCantidad_Clientes.Location = new System.Drawing.Point(3, 3);
            this.grdCantidad_Clientes.MenuActivado = false;
            this.grdCantidad_Clientes.Name = "grdCantidad_Clientes";
            this.grdCantidad_Clientes.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCantidad_Clientes.PintarFilaSel = true;
            this.grdCantidad_Clientes.Redraw = true;
            this.grdCantidad_Clientes.Row = 0;
            this.grdCantidad_Clientes.Rows = 50;
            this.grdCantidad_Clientes.Size = new System.Drawing.Size(825, 681);
            this.grdCantidad_Clientes.TabIndex = 0;
            this.grdCantidad_Clientes.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdCantidad_Clientes_Editado);
            this.grdCantidad_Clientes.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdCantidad_Clientes_CambioFila);
            this.grdCantidad_Clientes.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdCantidad_Clientes_KeyUp);
            this.grdCantidad_Clientes.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdCantidad_Clientes_KeyPress);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cSucs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cFecha);
            this.splitContainer3.Size = new System.Drawing.Size(523, 687);
            this.splitContainer3.SplitterDistance = 256;
            this.splitContainer3.TabIndex = 0;
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Location = new System.Drawing.Point(3, 500);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(249, 184);
            this.cFecha.TabIndex = 3;
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cSucs
            // 
            this.cSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(3, 3);
            this.cSucs.Mostrar_Tipo = false;
            this.cSucs.Name = "cSucs";
            this.cSucs.Size = new System.Drawing.Size(250, 681);
            this.cSucs.TabIndex = 2;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // cmdCambioMasivo
            // 
            this.cmdCambioMasivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCambioMasivo.Location = new System.Drawing.Point(1041, 689);
            this.cmdCambioMasivo.Name = "cmdCambioMasivo";
            this.cmdCambioMasivo.Size = new System.Drawing.Size(102, 23);
            this.cmdCambioMasivo.TabIndex = 4;
            this.cmdCambioMasivo.Text = "Cambio Masivo";
            this.cmdCambioMasivo.UseVisualStyleBackColor = true;
            this.cmdCambioMasivo.Click += new System.EventHandler(this.CmdCambioMasivo_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLimpiar.Location = new System.Drawing.Point(1149, 689);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(102, 23);
            this.cmdLimpiar.TabIndex = 4;
            this.cmdLimpiar.Text = "Limpiar Grilla";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
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
            // frmCantidad_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.cmdCambioMasivo);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmCantidad_Clientes";
            this.Text = "Cantidad_Clientes";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCantidad_Clientes_KeyUp);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdCantidad_Clientes;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cSucursales cSucs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.Button cmdCambioMasivo;
    }
}