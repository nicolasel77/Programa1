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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKilos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalE = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rdSucE = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.rdProd = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdSucS = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdNada = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdFecha = new MaterialSkin.Controls.MaterialRadioButton();
            this.grdTraslados = new Grilla2.SpeedGrilla();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cSucSalida = new Programa1.Controles.cSucursales();
            this.cSucEntrada = new Programa1.Controles.cSucursales();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.chCantidades = new MaterialSkin.Controls.MaterialCheckBox();
            this.cFecha = new Programa1.Controles.cFechas();
            this.cProds = new Programa1.Controles.cProductos();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdHerramientas = new MaterialSkin.Controls.MaterialFlatButton();
            this.paCambio = new System.Windows.Forms.Panel();
            this.cmdCambio = new MaterialSkin.Controls.MaterialFlatButton();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdRepetir = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.chFecha = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSucs = new MaterialSkin.Controls.MaterialCheckBox();
            this.chSucE = new MaterialSkin.Controls.MaterialCheckBox();
            this.chProducto = new MaterialSkin.Controls.MaterialCheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.paCambio.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // lblTotalS
            // 
            this.lblTotalS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalS.Name = "lblTotalS";
            this.lblTotalS.Size = new System.Drawing.Size(109, 23);
            this.lblTotalS.Text = "Totales Salida";
            this.lblTotalS.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotalE
            // 
            this.lblTotalE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalE.Name = "lblTotalE";
            this.lblTotalE.Size = new System.Drawing.Size(122, 23);
            this.lblTotalE.Text = "Totales Entrada";
            this.lblTotalE.Click += new System.EventHandler(this.LblCant_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
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
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.rdSucE);
            this.panel5.Controls.Add(this.materialLabel2);
            this.panel5.Controls.Add(this.rdProd);
            this.panel5.Controls.Add(this.rdSucS);
            this.panel5.Controls.Add(this.rdNada);
            this.panel5.Controls.Add(this.rdFecha);
            this.panel5.Location = new System.Drawing.Point(600, 599);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 85);
            this.panel5.TabIndex = 7;
            this.panel5.Visible = false;
            // 
            // rdSucE
            // 
            this.rdSucE.AutoSize = true;
            this.rdSucE.Depth = 0;
            this.rdSucE.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSucE.Location = new System.Drawing.Point(73, 48);
            this.rdSucE.Margin = new System.Windows.Forms.Padding(0);
            this.rdSucE.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSucE.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSucE.Name = "rdSucE";
            this.rdSucE.Ripple = true;
            this.rdSucE.Size = new System.Drawing.Size(66, 30);
            this.rdSucE.TabIndex = 13;
            this.rdSucE.Text = "Suc_E";
            this.rdSucE.UseVisualStyleBackColor = true;
            this.rdSucE.CheckedChanged += new System.EventHandler(this.rdSucE_CheckedChanged);
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
            this.rdProd.Location = new System.Drawing.Point(139, 19);
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
            // rdSucS
            // 
            this.rdSucS.AutoSize = true;
            this.rdSucS.Depth = 0;
            this.rdSucS.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSucS.Location = new System.Drawing.Point(73, 19);
            this.rdSucS.Margin = new System.Windows.Forms.Padding(0);
            this.rdSucS.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSucS.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSucS.Name = "rdSucS";
            this.rdSucS.Ripple = true;
            this.rdSucS.Size = new System.Drawing.Size(67, 30);
            this.rdSucS.TabIndex = 9;
            this.rdSucS.Text = "Suc_S";
            this.rdSucS.UseVisualStyleBackColor = true;
            this.rdSucS.CheckedChanged += new System.EventHandler(this.rdSucS_CheckedChanged);
            // 
            // rdNada
            // 
            this.rdNada.AutoSize = true;
            this.rdNada.Depth = 0;
            this.rdNada.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdNada.Location = new System.Drawing.Point(7, 48);
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
            this.grdTraslados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdTraslados.FuenteEncabezado = null;
            this.grdTraslados.FuentePieDePagina = null;
            this.grdTraslados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTraslados.Location = new System.Drawing.Point(3, 3);
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
            this.grdTraslados.SeleccionCambio += new Grilla2.SpeedGrilla.SeleccionCambioEventHandler(this.grdTraslados_SeleccionCambio);
            this.grdTraslados.Click += new Grilla2.SpeedGrilla.ClickEventHandler(this.grdTraslados_Click);
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
            this.cSucSalida.Mostrar_Botones = true;
            this.cSucSalida.Mostrar_Tipo = true;
            this.cSucSalida.Name = "cSucSalida";
            this.cSucSalida.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
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
            this.cSucEntrada.Mostrar_Botones = true;
            this.cSucEntrada.Mostrar_Tipo = true;
            this.cSucEntrada.Name = "cSucEntrada";
            this.cSucEntrada.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
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
            this.splitContainer4.Panel1.Controls.Add(this.chCantidades);
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
            // chCantidades
            // 
            this.chCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chCantidades.AutoSize = true;
            this.chCantidades.Depth = 0;
            this.chCantidades.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCantidades.Location = new System.Drawing.Point(3, 255);
            this.chCantidades.Margin = new System.Windows.Forms.Padding(0);
            this.chCantidades.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCantidades.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCantidades.Name = "chCantidades";
            this.chCantidades.Ripple = true;
            this.chCantidades.Size = new System.Drawing.Size(99, 30);
            this.chCantidades.TabIndex = 9;
            this.chCantidades.Text = "Cantidades";
            this.chCantidades.UseVisualStyleBackColor = true;
            this.chCantidades.CheckedChanged += new System.EventHandler(this.chMenudencias_CheckedChanged);
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
            this.cFecha.Size = new System.Drawing.Size(212, 255);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // cProds
            // 
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(0, 0);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(297, 288);
            this.cProds.TabIndex = 1;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.CProds_Cambio_Seleccion);
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
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.paCambio);
            this.panel1.Controls.Add(this.paMostrar);
            this.panel1.Controls.Add(this.paLimpiar);
            this.panel1.Location = new System.Drawing.Point(549, 688);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 27);
            this.panel1.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cmdHerramientas);
            this.panel6.Location = new System.Drawing.Point(138, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 25);
            this.panel6.TabIndex = 8;
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
            // paCambio
            // 
            this.paCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paCambio.Controls.Add(this.cmdCambio);
            this.paCambio.Location = new System.Drawing.Point(265, 0);
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
            this.paMostrar.Location = new System.Drawing.Point(633, 0);
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
            this.paLimpiar.Location = new System.Drawing.Point(449, 0);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cmdRepetir);
            this.panel2.Location = new System.Drawing.Point(11, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 25);
            this.panel2.TabIndex = 9;
            // 
            // cmdRepetir
            // 
            this.cmdRepetir.AutoSize = true;
            this.cmdRepetir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRepetir.Depth = 0;
            this.cmdRepetir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdRepetir.Location = new System.Drawing.Point(0, 0);
            this.cmdRepetir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdRepetir.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRepetir.Name = "cmdRepetir";
            this.cmdRepetir.Primary = false;
            this.cmdRepetir.Size = new System.Drawing.Size(121, 25);
            this.cmdRepetir.TabIndex = 0;
            this.cmdRepetir.Text = "Repetir";
            this.cmdRepetir.UseVisualStyleBackColor = true;
            this.cmdRepetir.Click += new System.EventHandler(this.cmdRepetir_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chProducto);
            this.panel3.Controls.Add(this.chSucE);
            this.panel3.Controls.Add(this.chSucs);
            this.panel3.Controls.Add(this.chFecha);
            this.panel3.Controls.Add(this.materialLabel1);
            this.panel3.Location = new System.Drawing.Point(696, 533);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 151);
            this.panel3.TabIndex = 14;
            this.panel3.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(60, 19);
            this.materialLabel1.TabIndex = 12;
            this.materialLabel1.Text = "Repetir:";
            // 
            // chFecha
            // 
            this.chFecha.AutoSize = true;
            this.chFecha.Checked = true;
            this.chFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFecha.Depth = 0;
            this.chFecha.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFecha.Location = new System.Drawing.Point(7, 19);
            this.chFecha.Margin = new System.Windows.Forms.Padding(0);
            this.chFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFecha.Name = "chFecha";
            this.chFecha.Ripple = true;
            this.chFecha.Size = new System.Drawing.Size(67, 30);
            this.chFecha.TabIndex = 13;
            this.chFecha.Text = "Fecha";
            this.chFecha.UseVisualStyleBackColor = true;
            // 
            // chSucs
            // 
            this.chSucs.AutoSize = true;
            this.chSucs.Checked = true;
            this.chSucs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSucs.Depth = 0;
            this.chSucs.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSucs.Location = new System.Drawing.Point(7, 49);
            this.chSucs.Margin = new System.Windows.Forms.Padding(0);
            this.chSucs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSucs.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSucs.Name = "chSucs";
            this.chSucs.Ripple = true;
            this.chSucs.Size = new System.Drawing.Size(65, 30);
            this.chSucs.TabIndex = 14;
            this.chSucs.Text = "Suc S";
            this.chSucs.UseVisualStyleBackColor = true;
            // 
            // chSucE
            // 
            this.chSucE.AutoSize = true;
            this.chSucE.Checked = true;
            this.chSucE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSucE.Depth = 0;
            this.chSucE.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSucE.Location = new System.Drawing.Point(7, 79);
            this.chSucE.Margin = new System.Windows.Forms.Padding(0);
            this.chSucE.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSucE.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSucE.Name = "chSucE";
            this.chSucE.Ripple = true;
            this.chSucE.Size = new System.Drawing.Size(64, 30);
            this.chSucE.TabIndex = 15;
            this.chSucE.Text = "Suc E";
            this.chSucE.UseVisualStyleBackColor = true;
            // 
            // chProducto
            // 
            this.chProducto.AutoSize = true;
            this.chProducto.Checked = true;
            this.chProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chProducto.Depth = 0;
            this.chProducto.Font = new System.Drawing.Font("Roboto", 10F);
            this.chProducto.Location = new System.Drawing.Point(7, 109);
            this.chProducto.Margin = new System.Windows.Forms.Padding(0);
            this.chProducto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.chProducto.Name = "chProducto";
            this.chProducto.Ripple = true;
            this.chProducto.Size = new System.Drawing.Size(86, 30);
            this.chProducto.TabIndex = 16;
            this.chProducto.Text = "Producto";
            this.chProducto.UseVisualStyleBackColor = true;
            // 
            // frmTraslados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 715);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
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
            this.paCambio.ResumeLayout(false);
            this.paCambio.PerformLayout();
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdTraslados;
        private Controles.cProductos cProds;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cSucursales cSucEntrada;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalS;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ToolStripStatusLabel lblKilos;
        private Controles.cSucursales cSucSalida;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalE;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paCambio;
        private MaterialSkin.Controls.MaterialFlatButton cmdCambio;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private MaterialSkin.Controls.MaterialCheckBox chCantidades;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialFlatButton cmdHerramientas;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRadioButton rdProd;
        private MaterialSkin.Controls.MaterialRadioButton rdSucS;
        private MaterialSkin.Controls.MaterialRadioButton rdNada;
        private MaterialSkin.Controls.MaterialRadioButton rdFecha;
        private MaterialSkin.Controls.MaterialRadioButton rdSucE;
        private System.Windows.Forms.Panel panel3;
        private MaterialSkin.Controls.MaterialCheckBox chProducto;
        private MaterialSkin.Controls.MaterialCheckBox chSucE;
        private MaterialSkin.Controls.MaterialCheckBox chSucs;
        private MaterialSkin.Controls.MaterialCheckBox chFecha;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton cmdRepetir;
    }
}