﻿namespace Programa1.Carga
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.rdProd = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdSuc = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdNada = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdFecha = new MaterialSkin.Controls.MaterialRadioButton();
            this.grdVenta = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cSucursal = new Programa1.Controles.cSucursales();
            this.cProds = new Programa1.Controles.cProductos();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.chCamiones = new MaterialSkin.Controls.MaterialCheckBox();
            this.chCantidades = new MaterialSkin.Controls.MaterialCheckBox();
            this.lstCamiones = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProveedores = new Programa1.Controles.cProveedores();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdHerramientas = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmbListas = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdACompras = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdATraslados = new MaterialSkin.Controls.MaterialFlatButton();
            this.paCambio = new System.Windows.Forms.Panel();
            this.cmdCambio = new MaterialSkin.Controls.MaterialFlatButton();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.paCambio.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblKilos,
            this.lblTotalE,
            this.lblTotalS,
            this.lblDiferencia});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1526, 28);
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
            this.lblCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(73, 23);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblKilos
            // 
            this.lblKilos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKilos.Name = "lblKilos";
            this.lblKilos.Size = new System.Drawing.Size(42, 23);
            this.lblKilos.Text = "Kilos";
            this.lblKilos.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalE
            // 
            this.lblTotalE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalE.Name = "lblTotalE";
            this.lblTotalE.Size = new System.Drawing.Size(121, 23);
            this.lblTotalE.Text = "Totales Compra";
            this.lblTotalE.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(108, 23);
            this.lblTotalS.Text = "Totales Venta";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(81, 23);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1526, 640);
            this.splitContainer1.SplitterDistance = 931;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.grdVenta);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(931, 640);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.materialLabel2);
            this.panel5.Controls.Add(this.rdProd);
            this.panel5.Controls.Add(this.rdSuc);
            this.panel5.Controls.Add(this.rdNada);
            this.panel5.Controls.Add(this.rdFecha);
            this.panel5.Location = new System.Drawing.Point(703, 555);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(181, 85);
            this.panel5.TabIndex = 6;
            this.panel5.Visible = false;
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
            // rdProd
            // 
            this.rdProd.AutoSize = true;
            this.rdProd.Checked = true;
            this.rdProd.Depth = 0;
            this.rdProd.Font = new System.Drawing.Font("Roboto", 10F);
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
            // rdSuc
            // 
            this.rdSuc.AutoSize = true;
            this.rdSuc.Depth = 0;
            this.rdSuc.Font = new System.Drawing.Font("Roboto", 10F);
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
            // rdNada
            // 
            this.rdNada.AutoSize = true;
            this.rdNada.Depth = 0;
            this.rdNada.Font = new System.Drawing.Font("Roboto", 10F);
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
            // rdFecha
            // 
            this.rdFecha.AutoSize = true;
            this.rdFecha.Depth = 0;
            this.rdFecha.Font = new System.Drawing.Font("Roboto", 10F);
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
            // grdVenta
            // 
            this.grdVenta.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdVenta.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVenta.AutoResize = false;
            this.grdVenta.bColor = System.Drawing.SystemColors.Window;
            this.grdVenta.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdVenta.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdVenta.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdVenta.Col = 0;
            this.grdVenta.Cols = 10;
            this.grdVenta.DataMember = "";
            this.grdVenta.DataSource = null;
            this.grdVenta.EnableEdicion = true;
            this.grdVenta.Encabezado = "";
            this.grdVenta.fColor = System.Drawing.SystemColors.Control;
            this.grdVenta.FixCols = 0;
            this.grdVenta.FixRows = 0;
            this.grdVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdVenta.Frozen = 0;
            this.grdVenta.FuenteEncabezado = null;
            this.grdVenta.FuentePieDePagina = null;
            this.grdVenta.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdVenta.LimpiarEstilosAntesDeOrdenar = true;
            this.grdVenta.Location = new System.Drawing.Point(3, 3);
            this.grdVenta.Name = "grdVenta";
            this.grdVenta.PieDePagina = "\t\tPage {0} of {1}";
            this.grdVenta.PintarFilaSel = true;
            this.grdVenta.Redraw = true;
            this.grdVenta.Row = 0;
            this.grdVenta.Rows = 50;
            this.grdVenta.Size = new System.Drawing.Size(925, 631);
            this.grdVenta.TabIndex = 0;
            this.grdVenta.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdVenta_Editado);
            this.grdVenta.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdVenta_CambioFila);
            this.grdVenta.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdVenta_KeyUp);
            this.grdVenta.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdVenta_KeyPress);
            this.grdVenta.SeleccionCambio += new Grilla2.SpeedGrilla.SeleccionCambioEventHandler(this.grdVenta_SeleccionCambio);
            this.grdVenta.Click += new Grilla2.SpeedGrilla.ClickEventHandler(this.grdVenta_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(587, 640);
            this.splitContainer2.SplitterDistance = 325;
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
            this.splitContainer3.Panel1.Controls.Add(this.cSucursal);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cProds);
            this.splitContainer3.Size = new System.Drawing.Size(587, 325);
            this.splitContainer3.SplitterDistance = 287;
            this.splitContainer3.TabIndex = 0;
            // 
            // cSucursal
            // 
            this.cSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucursal.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucursal.Filtro_In = "";
            this.cSucursal.Location = new System.Drawing.Point(3, 3);
            this.cSucursal.Mostrar_Botones = true;
            this.cSucursal.Mostrar_Tipo = false;
            this.cSucursal.Name = "cSucursal";
            this.cSucursal.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucursal.Size = new System.Drawing.Size(284, 319);
            this.cSucursal.TabIndex = 3;
            this.cSucursal.Titulo = "Sucursales";
            this.cSucursal.Valor_Actual = -1;
            this.cSucursal.Cambio_Seleccion += new System.EventHandler(this.Csuc_Cambio_Seleccion);
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(2, 3);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(291, 319);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.chCamiones);
            this.splitContainer4.Panel1.Controls.Add(this.chCantidades);
            this.splitContainer4.Panel1.Controls.Add(this.lstCamiones);
            this.splitContainer4.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer4.Panel1.Controls.Add(this.cFecha);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cProveedores);
            this.splitContainer4.Size = new System.Drawing.Size(587, 311);
            this.splitContainer4.SplitterDistance = 253;
            this.splitContainer4.TabIndex = 4;
            // 
            // chCamiones
            // 
            this.chCamiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chCamiones.AutoSize = true;
            this.chCamiones.Depth = 0;
            this.chCamiones.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCamiones.Location = new System.Drawing.Point(140, 249);
            this.chCamiones.Margin = new System.Windows.Forms.Padding(0);
            this.chCamiones.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCamiones.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCamiones.Name = "chCamiones";
            this.chCamiones.Ripple = true;
            this.chCamiones.Size = new System.Drawing.Size(92, 30);
            this.chCamiones.TabIndex = 9;
            this.chCamiones.Text = "Camiones";
            this.chCamiones.UseVisualStyleBackColor = true;
            this.chCamiones.CheckedChanged += new System.EventHandler(this.chCamiones_CheckedChanged);
            // 
            // chCantidades
            // 
            this.chCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chCantidades.AutoSize = true;
            this.chCantidades.Depth = 0;
            this.chCantidades.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCantidades.Location = new System.Drawing.Point(140, 279);
            this.chCantidades.Margin = new System.Windows.Forms.Padding(0);
            this.chCantidades.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCantidades.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCantidades.Name = "chCantidades";
            this.chCantidades.Ripple = true;
            this.chCantidades.Size = new System.Drawing.Size(99, 30);
            this.chCantidades.TabIndex = 6;
            this.chCantidades.Text = "Cantidades";
            this.chCantidades.UseVisualStyleBackColor = true;
            this.chCantidades.CheckedChanged += new System.EventHandler(this.chMenudencias_CheckedChanged);
            // 
            // lstCamiones
            // 
            this.lstCamiones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCamiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCamiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstCamiones.FormattingEnabled = true;
            this.lstCamiones.ItemHeight = 18;
            this.lstCamiones.Location = new System.Drawing.Point(3, 255);
            this.lstCamiones.Name = "lstCamiones";
            this.lstCamiones.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCamiones.Size = new System.Drawing.Size(134, 54);
            this.lstCamiones.TabIndex = 5;
            this.lstCamiones.SelectedIndexChanged += new System.EventHandler(this.lstCamiones_SelectedIndexChanged);
            this.lstCamiones.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstCamiones_MouseUp);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 233);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(77, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Camiones";
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(3, 0);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(250, 230);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cProveedores
            // 
            this.cProveedores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProveedores.BackColor = System.Drawing.Color.Gainsboro;
            this.cProveedores.Filtro_In = "";
            this.cProveedores.Location = new System.Drawing.Point(0, 0);
            this.cProveedores.Mostrar_Tipo = false;
            this.cProveedores.Name = "cProveedores";
            this.cProveedores.Size = new System.Drawing.Size(327, 311);
            this.cProveedores.TabIndex = 2;
            this.cProveedores.Titulo = "Proveedores";
            this.cProveedores.Valor_Actual = -1;
            this.cProveedores.Cambio_Seleccion += new System.EventHandler(this.cProveedores_Cambio_Seleccion);
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
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.cmbListas);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.paCambio);
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(555, 642);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 27);
            this.panel1.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cmdHerramientas);
            this.panel6.Location = new System.Drawing.Point(221, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 25);
            this.panel6.TabIndex = 7;
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
            this.cmdHerramientas.Click += new System.EventHandler(this.cmdHerramientas_Click_1);
            // 
            // cmbListas
            // 
            this.cmbListas.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbListas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbListas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbListas.ForeColor = System.Drawing.Color.DimGray;
            this.cmbListas.FormattingEnabled = true;
            this.cmbListas.Location = new System.Drawing.Point(3, 3);
            this.cmbListas.Name = "cmbListas";
            this.cmbListas.Size = new System.Drawing.Size(153, 24);
            this.cmbListas.TabIndex = 6;
            this.cmbListas.Text = "Lista";
            this.cmbListas.SelectedIndexChanged += new System.EventHandler(this.cmbListas_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.cmdACompras);
            this.panel3.Location = new System.Drawing.Point(336, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(121, 25);
            this.panel3.TabIndex = 5;
            // 
            // cmdACompras
            // 
            this.cmdACompras.AutoSize = true;
            this.cmdACompras.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdACompras.Depth = 0;
            this.cmdACompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdACompras.Location = new System.Drawing.Point(0, 0);
            this.cmdACompras.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdACompras.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdACompras.Name = "cmdACompras";
            this.cmdACompras.Primary = false;
            this.cmdACompras.Size = new System.Drawing.Size(121, 25);
            this.cmdACompras.TabIndex = 0;
            this.cmdACompras.Text = "A Compras";
            this.cmdACompras.UseVisualStyleBackColor = true;
            this.cmdACompras.Click += new System.EventHandler(this.CmdACompras_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmdATraslados);
            this.panel2.Location = new System.Drawing.Point(463, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 25);
            this.panel2.TabIndex = 5;
            // 
            // cmdATraslados
            // 
            this.cmdATraslados.AutoSize = true;
            this.cmdATraslados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdATraslados.Depth = 0;
            this.cmdATraslados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdATraslados.Location = new System.Drawing.Point(0, 0);
            this.cmdATraslados.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdATraslados.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdATraslados.Name = "cmdATraslados";
            this.cmdATraslados.Primary = false;
            this.cmdATraslados.Size = new System.Drawing.Size(121, 25);
            this.cmdATraslados.TabIndex = 0;
            this.cmdATraslados.Text = "A Traslados";
            this.cmdATraslados.UseVisualStyleBackColor = true;
            this.cmdATraslados.Click += new System.EventHandler(this.CmdATraslados_Click);
            // 
            // paCambio
            // 
            this.paCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paCambio.Controls.Add(this.cmdCambio);
            this.paCambio.Location = new System.Drawing.Point(590, 2);
            this.paCambio.Name = "paCambio";
            this.paCambio.Size = new System.Drawing.Size(121, 25);
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
            this.cmdCambio.Size = new System.Drawing.Size(121, 25);
            this.cmdCambio.TabIndex = 0;
            this.cmdCambio.Text = "Cambio Masivo";
            this.cmdCambio.UseVisualStyleBackColor = true;
            this.cmdCambio.Click += new System.EventHandler(this.CmdCambioMasivo_Click);
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(844, 2);
            this.paMostrar.Name = "paMostrar";
            this.paMostrar.Size = new System.Drawing.Size(121, 25);
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
            this.cmdMostrar.Size = new System.Drawing.Size(121, 25);
            this.cmdMostrar.TabIndex = 0;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // paLimpiar
            // 
            this.paLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paLimpiar.Controls.Add(this.cmdLimpiar);
            this.paLimpiar.Location = new System.Drawing.Point(717, 1);
            this.paLimpiar.Name = "paLimpiar";
            this.paLimpiar.Size = new System.Drawing.Size(121, 25);
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
            this.cmdLimpiar.Size = new System.Drawing.Size(121, 25);
            this.cmdLimpiar.TabIndex = 0;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frmVentas";
            this.Text = "Venta";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmVenta_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.paCambio.ResumeLayout(false);
            this.paCambio.PerformLayout();
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cProveedores cProveedores;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private Controles.cSucursales cSucursal;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialFlatButton cmdACompras;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton cmdATraslados;
        private System.Windows.Forms.Panel paCambio;
        private MaterialSkin.Controls.MaterialFlatButton cmdCambio;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox lstCamiones;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.ComboBox cmbListas;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRadioButton rdProd;
        private MaterialSkin.Controls.MaterialRadioButton rdSuc;
        private MaterialSkin.Controls.MaterialRadioButton rdNada;
        private MaterialSkin.Controls.MaterialRadioButton rdFecha;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialFlatButton cmdHerramientas;
        private MaterialSkin.Controls.MaterialCheckBox chCantidades;
        private MaterialSkin.Controls.MaterialCheckBox chCamiones;
        private Grilla2.SpeedGrilla grdVenta;
    }
}