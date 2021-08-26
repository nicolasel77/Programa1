namespace Programa1.Carga
{
    partial class frmAjustes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjustes));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdAjustes = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cProvs = new Programa1.Controles.cProveedores();
            this.cFecha = new Programa1.Controles.cFechas();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 637);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1229, 28);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 23);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 23);
            this.lblTotal.Text = "Totales";
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
            this.splitContainer1.Panel1.Controls.Add(this.grdAjustes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1229, 637);
            this.splitContainer1.SplitterDistance = 715;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            // 
            // grdAjustes
            // 
            this.grdAjustes.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAjustes.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAjustes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAjustes.AutoResize = false;
            this.grdAjustes.bColor = System.Drawing.SystemColors.Window;
            this.grdAjustes.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAjustes.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAjustes.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAjustes.Col = 0;
            this.grdAjustes.Cols = 10;
            this.grdAjustes.DataMember = "";
            this.grdAjustes.DataSource = null;
            this.grdAjustes.EnableEdicion = true;
            this.grdAjustes.Encabezado = "";
            this.grdAjustes.fColor = System.Drawing.SystemColors.Control;
            this.grdAjustes.FixCols = 0;
            this.grdAjustes.FixRows = 0;
            this.grdAjustes.FuenteEncabezado = null;
            this.grdAjustes.FuentePieDePagina = null;
            this.grdAjustes.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAjustes.Location = new System.Drawing.Point(3, 3);
            this.grdAjustes.Name = "grdAjustes";
            this.grdAjustes.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAjustes.PintarFilaSel = true;
            this.grdAjustes.Redraw = true;
            this.grdAjustes.Row = 0;
            this.grdAjustes.Rows = 50;
            this.grdAjustes.Size = new System.Drawing.Size(709, 631);
            this.grdAjustes.TabIndex = 0;
            this.grdAjustes.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdAjustes_Editado_1);
            this.grdAjustes.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdAjustes_CambioFila);
            this.grdAjustes.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdAjustes_KeyUp);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cProvs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cFecha);
            this.splitContainer3.Size = new System.Drawing.Size(506, 637);
            this.splitContainer3.SplitterDistance = 247;
            this.splitContainer3.TabIndex = 0;
            // 
            // cProvs
            // 
            this.cProvs.BackColor = System.Drawing.Color.Gainsboro;
            this.cProvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProvs.Filtro_In = "";
            this.cProvs.Location = new System.Drawing.Point(0, 0);
            this.cProvs.Mostrar_Tipo = true;
            this.cProvs.Name = "cProvs";
            this.cProvs.Size = new System.Drawing.Size(247, 637);
            this.cProvs.TabIndex = 2;
            this.cProvs.Titulo = "Proveedores";
            this.cProvs.Valor_Actual = -1;
            // 
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(255, 637);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion_1);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(634, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 27);
            this.panel1.TabIndex = 9;
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
            this.cmdMostrar.Click += new System.EventHandler(this.cmdMostrar_Click_1);
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
            // frmAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 665);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmAjustes";
            this.Text = "Ajustes";
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
            this.panel1.ResumeLayout(false);
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdAjustes;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Controles.cFechas cFecha;
        private Controles.cProveedores cProvs;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
    }
}