namespace Programa1.Carga
{
    partial class frmTraslados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraslados));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdTraslados = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cSucSalida = new Programa1.Controles.cSucursales();
            this.cSucEntrada = new Programa1.Controles.cSucursales();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProds = new Programa1.Controles.cProductos();
            this.cmdCambioMasivo = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.lblKilos,
            this.lblTotalS,
            this.lblTotalE,
            this.lblDiferencia});
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
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(88, 23);
            this.lblTotalS.Text = "Totales Salida";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalE
            // 
            this.lblTotalE.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalE.Name = "lblTotalE";
            this.lblTotalE.Size = new System.Drawing.Size(98, 23);
            this.lblTotalE.Text = "Totales Entrada";
            this.lblTotalE.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(66, 23);
            this.lblDiferencia.Text = "Diferencia";
            this.lblDiferencia.Click += new System.EventHandler(this.LblCant_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.grdTraslados);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 687);
            this.splitContainer1.SplitterDistance = 831;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdTraslados
            // 
            this.grdTraslados.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTraslados.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTraslados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTraslados.AutoResize = false;
            this.grdTraslados.bColor = System.Drawing.SystemColors.Window;
            this.grdTraslados.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTraslados.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTraslados.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTraslados.Col = 0;
            this.grdTraslados.Cols = 10;
            this.grdTraslados.DataMember = "";
            this.grdTraslados.DataSource = null;
            this.grdTraslados.EnableEdicion = true;
            this.grdTraslados.Encabezado = "";
            this.grdTraslados.fColor = System.Drawing.SystemColors.Control;
            this.grdTraslados.FixCols = 0;
            this.grdTraslados.FixRows = 0;
            this.grdTraslados.FuenteEncabezado = null;
            this.grdTraslados.FuentePieDePagina = null;
            this.grdTraslados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTraslados.Location = new System.Drawing.Point(3, 3);
            this.grdTraslados.MenuActivado = false;
            this.grdTraslados.Name = "grdTraslados";
            this.grdTraslados.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTraslados.PintarFilaSel = true;
            this.grdTraslados.Redraw = true;
            this.grdTraslados.Row = 0;
            this.grdTraslados.Rows = 50;
            this.grdTraslados.Size = new System.Drawing.Size(828, 684);
            this.grdTraslados.TabIndex = 0;
            this.grdTraslados.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdTraslados_Editado);
            this.grdTraslados.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdTraslados_CambioFila);
            this.grdTraslados.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdTraslados_KeyUp);
            this.grdTraslados.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdTraslados_KeyPress);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(523, 687);
            this.splitContainer2.SplitterDistance = 395;
            this.splitContainer2.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cSucSalida);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cSucEntrada);
            this.splitContainer3.Size = new System.Drawing.Size(523, 395);
            this.splitContainer3.SplitterDistance = 256;
            this.splitContainer3.TabIndex = 0;
            // 
            // cSucSalida
            // 
            this.cSucSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucSalida.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucSalida.Filtro_In = "";
            this.cSucSalida.Location = new System.Drawing.Point(3, 3);
            this.cSucSalida.Mostrar_Tipo = true;
            this.cSucSalida.Name = "cSucSalida";
            this.cSucSalida.Size = new System.Drawing.Size(253, 392);
            this.cSucSalida.TabIndex = 3;
            this.cSucSalida.Titulo = "Sucursales Salida";
            this.cSucSalida.Valor_Actual = -1;
            this.cSucSalida.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // cSucEntrada
            // 
            this.cSucEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucEntrada.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucEntrada.Filtro_In = "";
            this.cSucEntrada.Location = new System.Drawing.Point(0, 3);
            this.cSucEntrada.Mostrar_Tipo = true;
            this.cSucEntrada.Name = "cSucEntrada";
            this.cSucEntrada.Size = new System.Drawing.Size(260, 392);
            this.cSucEntrada.TabIndex = 2;
            this.cSucEntrada.Titulo = "Sucursales Entrada";
            this.cSucEntrada.Valor_Actual = -1;
            this.cSucEntrada.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.cFecha);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cProds);
            this.splitContainer4.Size = new System.Drawing.Size(523, 288);
            this.splitContainer4.SplitterDistance = 218;
            this.splitContainer4.SplitterWidth = 8;
            this.splitContainer4.TabIndex = 4;
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Location = new System.Drawing.Point(3, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(212, 288);
            this.cFecha.TabIndex = 3;
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(3, 0);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(287, 288);
            this.cProds.TabIndex = 1;
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cmdCambioMasivo
            // 
            this.cmdCambioMasivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCambioMasivo.Location = new System.Drawing.Point(1047, 689);
            this.cmdCambioMasivo.Name = "cmdCambioMasivo";
            this.cmdCambioMasivo.Size = new System.Drawing.Size(100, 23);
            this.cmdCambioMasivo.TabIndex = 4;
            this.cmdCambioMasivo.Text = "Cambio Masivo";
            this.cmdCambioMasivo.UseVisualStyleBackColor = true;
            this.cmdCambioMasivo.Click += new System.EventHandler(this.CmdCambioMasivo_Click);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLimpiar.Location = new System.Drawing.Point(1153, 689);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(100, 23);
            this.cmdLimpiar.TabIndex = 4;
            this.cmdLimpiar.Text = "Limpiar Grilla";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMostrar.Location = new System.Drawing.Point(1259, 689);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(100, 23);
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
            // frmTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.cmdCambioMasivo);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmTraslados";
            this.Text = "Traslados";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTraslados_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdTraslados;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Button cmdMostrar;
        private Controles.cSucursales cSucEntrada;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.Button cmdCambioMasivo;
        private Controles.cSucursales cSucSalida;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}