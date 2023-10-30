
namespace Programa1.Carga
{
    partial class frmStock_Galpon
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
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdStock = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chProv = new MaterialSkin.Controls.MaterialCheckBox();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdImprimir = new MaterialSkin.Controls.MaterialFlatButton();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdCerdo = new Grilla2.SpeedGrilla();
            this.cProds = new Programa1.Controles.cProductos();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProvs = new Programa1.Controles.cProveedores();
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
            this.panel2.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilos});
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
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
            // grdStock
            // 
            this.grdStock.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdStock.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdStock.AutoResize = false;
            this.grdStock.bColor = System.Drawing.SystemColors.Window;
            this.grdStock.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdStock.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdStock.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdStock.Col = 0;
            this.grdStock.Cols = 10;
            this.grdStock.DataMember = "";
            this.grdStock.DataSource = null;
            this.grdStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdStock.EnableEdicion = false;
            this.grdStock.Encabezado = "";
            this.grdStock.fColor = System.Drawing.SystemColors.Control;
            this.grdStock.FixCols = 0;
            this.grdStock.FixRows = 0;
            this.grdStock.Frozen = 0;
            this.grdStock.FuenteEncabezado = null;
            this.grdStock.FuentePieDePagina = null;
            this.grdStock.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdStock.LimpiarEstilosAntesDeOrdenar = false;
            this.grdStock.Location = new System.Drawing.Point(0, 0);
            this.grdStock.Name = "grdStock";
            this.grdStock.PieDePagina = "\t\tPage {0} of {1}";
            this.grdStock.PintarFilaSel = true;
            this.grdStock.Redraw = true;
            this.grdStock.Row = 0;
            this.grdStock.Rows = 50;
            this.grdStock.Size = new System.Drawing.Size(825, 398);
            this.grdStock.TabIndex = 0;
            this.grdStock.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdStock_CambioFila);
            this.grdStock.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdStock_KeyPress);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chProv);
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
            // chProv
            // 
            this.chProv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chProv.AutoSize = true;
            this.chProv.Depth = 0;
            this.chProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chProv.Location = new System.Drawing.Point(3, 654);
            this.chProv.Margin = new System.Windows.Forms.Padding(0);
            this.chProv.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProv.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProv.Name = "chProv";
            this.chProv.Ripple = true;
            this.chProv.Size = new System.Drawing.Size(183, 30);
            this.chProv.TabIndex = 2;
            this.chProv.Text = "Separar por Proveedores";
            this.chProv.UseVisualStyleBackColor = true;
            this.chProv.CheckedChanged += new System.EventHandler(this.chProv_CheckedChanged_1);
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(839, 688);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 27);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmdImprimir);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 25);
            this.panel2.TabIndex = 6;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.AutoSize = true;
            this.cmdImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdImprimir.Depth = 0;
            this.cmdImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdImprimir.Location = new System.Drawing.Point(0, 0);
            this.cmdImprimir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdImprimir.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Primary = false;
            this.cmdImprimir.Size = new System.Drawing.Size(177, 25);
            this.cmdImprimir.TabIndex = 0;
            this.cmdImprimir.Text = "Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(340, 2);
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
            this.paLimpiar.Location = new System.Drawing.Point(156, 2);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.grdStock);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(825, 398);
            this.panel3.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer2.BackColor = System.Drawing.Color.Gray;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdCerdo);
            this.splitContainer2.Size = new System.Drawing.Size(825, 678);
            this.splitContainer2.SplitterDistance = 398;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 2;
            // 
            // grdCerdo
            // 
            this.grdCerdo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCerdo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCerdo.AutoResize = false;
            this.grdCerdo.bColor = System.Drawing.SystemColors.Window;
            this.grdCerdo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCerdo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCerdo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCerdo.Col = 0;
            this.grdCerdo.Cols = 10;
            this.grdCerdo.DataMember = "";
            this.grdCerdo.DataSource = null;
            this.grdCerdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCerdo.EnableEdicion = false;
            this.grdCerdo.Encabezado = "";
            this.grdCerdo.fColor = System.Drawing.SystemColors.Control;
            this.grdCerdo.FixCols = 0;
            this.grdCerdo.FixRows = 0;
            this.grdCerdo.Frozen = 0;
            this.grdCerdo.FuenteEncabezado = null;
            this.grdCerdo.FuentePieDePagina = null;
            this.grdCerdo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCerdo.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCerdo.Location = new System.Drawing.Point(0, 0);
            this.grdCerdo.Name = "grdCerdo";
            this.grdCerdo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCerdo.PintarFilaSel = true;
            this.grdCerdo.Redraw = true;
            this.grdCerdo.Row = 0;
            this.grdCerdo.Rows = 50;
            this.grdCerdo.Size = new System.Drawing.Size(825, 272);
            this.grdCerdo.TabIndex = 1;
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
            this.cProds.Size = new System.Drawing.Size(250, 648);
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
            this.cFecha.Location = new System.Drawing.Point(6, 381);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(254, 300);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion_1);
            // 
            // cProvs
            // 
            this.cProvs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProvs.BackColor = System.Drawing.Color.Gainsboro;
            this.cProvs.Filtro_In = "";
            this.cProvs.Location = new System.Drawing.Point(2, 3);
            this.cProvs.Mostrar_Tipo = false;
            this.cProvs.Name = "cProvs";
            this.cProvs.Size = new System.Drawing.Size(258, 372);
            this.cProvs.TabIndex = 2;
            this.cProvs.Titulo = "Proveedores";
            this.cProvs.Valor_Actual = -1;
            this.cProvs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // frmStock_Galpon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmStock_Galpon";
            this.Text = "Stock";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmStock_Galpon_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdStock;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cProveedores cProvs;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private Controles.cFechas cFecha;
        private MaterialSkin.Controls.MaterialCheckBox chProv;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton cmdImprimir;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel3;
        private Grilla2.SpeedGrilla grdCerdo;
    }
}