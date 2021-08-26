﻿namespace Programa1.Carga
{
    partial class frmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStock));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdStock = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.paCambio = new System.Windows.Forms.Panel();
            this.cmdCambio = new MaterialSkin.Controls.MaterialFlatButton();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdHerramientas = new MaterialSkin.Controls.MaterialFlatButton();
            this.cProds = new Programa1.Controles.cProductos();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.cFecha = new Programa1.Controles.cFechas();
            this.rdFecha = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdNada = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdSuc = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdProd = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel5 = new System.Windows.Forms.Panel();
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
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 723);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1283, 32);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 27);
            // 
            // lblCant
            // 
            this.lblCant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(60, 27);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilos
            // 
            this.lblKilos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(36, 27);
            this.lblKilos.Text = "Kilos";
            this.lblKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 27);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            this.splitContainer1.Panel1.Controls.Add(this.grdStock);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1283, 723);
            this.splitContainer1.SplitterDistance = 781;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdStock
            // 
            this.grdStock.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdStock.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStock.AutoResize = false;
            this.grdStock.bColor = System.Drawing.SystemColors.Window;
            this.grdStock.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdStock.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdStock.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdStock.Col = 0;
            this.grdStock.Cols = 10;
            this.grdStock.DataMember = "";
            this.grdStock.DataSource = null;
            this.grdStock.EnableEdicion = true;
            this.grdStock.Encabezado = "";
            this.grdStock.fColor = System.Drawing.SystemColors.Control;
            this.grdStock.FixCols = 0;
            this.grdStock.FixRows = 0;
            this.grdStock.FuenteEncabezado = null;
            this.grdStock.FuentePieDePagina = null;
            this.grdStock.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdStock.Location = new System.Drawing.Point(3, 3);
            this.grdStock.Name = "grdStock";
            this.grdStock.PieDePagina = "\t\tPage {0} of {1}";
            this.grdStock.PintarFilaSel = true;
            this.grdStock.Redraw = true;
            this.grdStock.Row = 0;
            this.grdStock.Rows = 50;
            this.grdStock.Size = new System.Drawing.Size(664, 623);
            this.grdStock.TabIndex = 0;
            this.grdStock.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdStock_Editado);
            this.grdStock.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdStock_CambioFila);
            this.grdStock.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdStock_KeyUp);
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
            this.splitContainer3.Panel1.Controls.Add(this.cProds);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3.Size = new System.Drawing.Size(493, 723);
            this.splitContainer3.SplitterDistance = 239;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
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
            this.cProds.Size = new System.Drawing.Size(202, 620);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cSucs);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cFecha);
            this.splitContainer2.Size = new System.Drawing.Size(207, 626);
            this.splitContainer2.SplitterDistance = 389;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 4;
            // 
            // cSucs
            // 
            this.cSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(-1, 3);
            this.cSucs.Mostrar_Botones = true;
            this.cSucs.Mostrar_Tipo = true;
            this.cSucs.Name = "cSucs";
            this.cSucs.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucs.Size = new System.Drawing.Size(205, 383);
            this.cSucs.TabIndex = 2;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(207, 229);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
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
            this.panel1.Location = new System.Drawing.Point(508, 627);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 27);
            this.panel1.TabIndex = 8;
            // 
            // paCambio
            // 
            this.paCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paCambio.Controls.Add(this.cmdCambio);
            this.paCambio.Location = new System.Drawing.Point(44, 2);
            this.paCambio.Name = "paCambio";
            this.paCambio.Size = new System.Drawing.Size(206, 29);
            this.paCambio.TabIndex = 5;
            // 
            // cmdCambio
            // 
            this.cmdCambio.AutoSize = true;
            this.cmdCambio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCambio.Depth = 0;
            this.cmdCambio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCambio.Location = new System.Drawing.Point(0, 0);
            this.cmdCambio.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdCambio.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCambio.Name = "cmdCambio";
            this.cmdCambio.Primary = false;
            this.cmdCambio.Size = new System.Drawing.Size(206, 29);
            this.cmdCambio.TabIndex = 0;
            this.cmdCambio.Text = "Cambio Masivo";
            this.cmdCambio.UseVisualStyleBackColor = true;
            this.cmdCambio.Click += new System.EventHandler(this.CmdCambioMasivo_Click);
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(481, 2);
            this.paMostrar.Name = "paMostrar";
            this.paMostrar.Size = new System.Drawing.Size(206, 29);
            this.paMostrar.TabIndex = 5;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.AutoSize = true;
            this.cmdMostrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMostrar.Depth = 0;
            this.cmdMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMostrar.Location = new System.Drawing.Point(0, 0);
            this.cmdMostrar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Primary = false;
            this.cmdMostrar.Size = new System.Drawing.Size(206, 29);
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
            this.paLimpiar.Size = new System.Drawing.Size(206, 29);
            this.paLimpiar.TabIndex = 5;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.AutoSize = true;
            this.cmdLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdLimpiar.Depth = 0;
            this.cmdLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdLimpiar.Location = new System.Drawing.Point(0, 0);
            this.cmdLimpiar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Primary = false;
            this.cmdLimpiar.Size = new System.Drawing.Size(206, 29);
            this.cmdLimpiar.TabIndex = 0;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cmdHerramientas);
            this.panel6.Location = new System.Drawing.Point(430, 629);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 25);
            this.panel6.TabIndex = 13;
            // 
            // cmdHerramientas
            // 
            this.cmdHerramientas.AutoSize = true;
            this.cmdHerramientas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdHerramientas.Depth = 0;
            this.cmdHerramientas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdHerramientas.Location = new System.Drawing.Point(0, 0);
            this.cmdHerramientas.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdHerramientas.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdHerramientas.Name = "cmdHerramientas";
            this.cmdHerramientas.Primary = false;
            this.cmdHerramientas.Size = new System.Drawing.Size(121, 25);
            this.cmdHerramientas.TabIndex = 0;
            this.cmdHerramientas.Text = "Herramientas";
            this.cmdHerramientas.UseVisualStyleBackColor = true;
            this.cmdHerramientas.Click += new System.EventHandler(this.cmdHerramientas_Click);
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
            this.cProds.Size = new System.Drawing.Size(202, 592);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // cSucs
            // 
            this.cSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(-1, 3);
            this.cSucs.Mostrar_Botones = true;
            this.cSucs.Mostrar_Tipo = false;
            this.cSucs.Name = "cSucs";
            this.cSucs.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucs.Size = new System.Drawing.Size(205, 348);
            this.cSucs.TabIndex = 2;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(0, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(207, 219);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // rdFecha
            // 
            this.rdFecha.AutoSize = true;
            this.rdFecha.Depth = 0;
            this.rdFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdFecha.Location = new System.Drawing.Point(7, 19);
            this.rdFecha.Margin = new System.Windows.Forms.Padding(0);
            this.rdFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdFecha.Name = "rdFecha";
            this.rdFecha.Ripple = true;
            this.rdFecha.Size = new System.Drawing.Size(66, 30);
            this.rdFecha.TabIndex = 7;
            this.rdFecha.Text = "Fecha";
            this.rdFecha.UseVisualStyleBackColor = true;
            this.rdFecha.CheckedChanged += new System.EventHandler(this.rdFecha_CheckedChanged);
            // 
            // rdNada
            // 
            this.rdNada.AutoSize = true;
            this.rdNada.Depth = 0;
            this.rdNada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdNada.Location = new System.Drawing.Point(7, 49);
            this.rdNada.Margin = new System.Windows.Forms.Padding(0);
            this.rdNada.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdNada.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdNada.Name = "rdNada";
            this.rdNada.Ripple = true;
            this.rdNada.Size = new System.Drawing.Size(61, 30);
            this.rdNada.TabIndex = 8;
            this.rdNada.Text = "Nada";
            this.rdNada.UseVisualStyleBackColor = true;
            this.rdNada.CheckedChanged += new System.EventHandler(this.rdNada_CheckedChanged);
            // 
            // rdSuc
            // 
            this.rdSuc.AutoSize = true;
            this.rdSuc.Depth = 0;
            this.rdSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdSuc.Location = new System.Drawing.Point(73, 19);
            this.rdSuc.Margin = new System.Windows.Forms.Padding(0);
            this.rdSuc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSuc.Name = "rdSuc";
            this.rdSuc.Ripple = true;
            this.rdSuc.Size = new System.Drawing.Size(83, 30);
            this.rdSuc.TabIndex = 9;
            this.rdSuc.Text = "Sucursal";
            this.rdSuc.UseVisualStyleBackColor = true;
            this.rdSuc.CheckedChanged += new System.EventHandler(this.rdSuc_CheckedChanged);
            // 
            // rdProd
            // 
            this.rdProd.AutoSize = true;
            this.rdProd.Checked = true;
            this.rdProd.Depth = 0;
            this.rdProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rdProd.Location = new System.Drawing.Point(73, 49);
            this.rdProd.Margin = new System.Windows.Forms.Padding(0);
            this.rdProd.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdProd.Name = "rdProd";
            this.rdProd.Ripple = true;
            this.rdProd.Size = new System.Drawing.Size(85, 30);
            this.rdProd.TabIndex = 11;
            this.rdProd.TabStop = true;
            this.rdProd.Text = "Producto";
            this.rdProd.UseVisualStyleBackColor = true;
            this.rdProd.CheckedChanged += new System.EventHandler(this.rdProd_CheckedChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(3, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(93, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Incrementar:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.materialLabel2);
            this.panel5.Controls.Add(this.rdProd);
            this.panel5.Controls.Add(this.rdSuc);
            this.panel5.Controls.Add(this.rdNada);
            this.panel5.Controls.Add(this.rdFecha);
            this.panel5.Location = new System.Drawing.Point(439, 541);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(181, 85);
            this.panel5.TabIndex = 7;
            this.panel5.Visible = false;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 654);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmStock";
            this.Text = "Stock";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmStock_KeyUp);
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
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdStock;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cSucursales cSucs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paCambio;
        private MaterialSkin.Controls.MaterialFlatButton cmdCambio;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialFlatButton cmdHerramientas;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRadioButton rdProd;
        private MaterialSkin.Controls.MaterialRadioButton rdSuc;
        private MaterialSkin.Controls.MaterialRadioButton rdNada;
        private MaterialSkin.Controls.MaterialRadioButton rdFecha;
    }
}