namespace Programa1.Carga.Tesoreria
{

    partial class frmModificar_Tarjetas
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
            this.grdOrigen = new Grilla2.SpeedGrilla();
            this.grd_Destino = new Grilla2.SpeedGrilla();
            this.cmdAceptar = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lstLotes = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbSucO = new System.Windows.Forms.ComboBox();
            this.cmbSucD = new System.Windows.Forms.ComboBox();
            this.lstTipos_t = new System.Windows.Forms.ListBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.grdResumenDest = new Grilla2.SpeedGrilla();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cFecha = new Programa1.Controles.cFechas();
            this.panel5 = new System.Windows.Forms.Panel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grdResumenOri = new Grilla2.SpeedGrilla();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOrigen
            // 
            this.grdOrigen.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdOrigen.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdOrigen.AutoResize = false;
            this.grdOrigen.bColor = System.Drawing.SystemColors.Window;
            this.grdOrigen.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdOrigen.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdOrigen.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdOrigen.Col = 0;
            this.grdOrigen.Cols = 10;
            this.grdOrigen.DataMember = "";
            this.grdOrigen.DataSource = null;
            this.grdOrigen.EnableEdicion = true;
            this.grdOrigen.Encabezado = "";
            this.grdOrigen.fColor = System.Drawing.Color.Silver;
            this.grdOrigen.FixCols = 0;
            this.grdOrigen.FixRows = 0;
            this.grdOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOrigen.FuenteEncabezado = null;
            this.grdOrigen.FuentePieDePagina = null;
            this.grdOrigen.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdOrigen.Location = new System.Drawing.Point(12, 42);
            this.grdOrigen.Name = "grdOrigen";
            this.grdOrigen.PieDePagina = "\t\tPage {0} of {1}";
            this.grdOrigen.PintarFilaSel = true;
            this.grdOrigen.Redraw = true;
            this.grdOrigen.Row = 0;
            this.grdOrigen.Rows = 1;
            this.grdOrigen.Size = new System.Drawing.Size(599, 745);
            this.grdOrigen.TabIndex = 0;
            // 
            // grd_Destino
            // 
            this.grd_Destino.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd_Destino.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd_Destino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_Destino.AutoResize = false;
            this.grd_Destino.bColor = System.Drawing.SystemColors.Window;
            this.grd_Destino.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grd_Destino.bFColor = System.Drawing.SystemColors.WindowText;
            this.grd_Destino.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grd_Destino.Col = 0;
            this.grd_Destino.Cols = 10;
            this.grd_Destino.DataMember = "";
            this.grd_Destino.DataSource = null;
            this.grd_Destino.EnableEdicion = true;
            this.grd_Destino.Encabezado = "";
            this.grd_Destino.fColor = System.Drawing.Color.Silver;
            this.grd_Destino.FixCols = 0;
            this.grd_Destino.FixRows = 0;
            this.grd_Destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_Destino.FuenteEncabezado = null;
            this.grd_Destino.FuentePieDePagina = null;
            this.grd_Destino.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd_Destino.Location = new System.Drawing.Point(860, 42);
            this.grd_Destino.Name = "grd_Destino";
            this.grd_Destino.PieDePagina = "\t\tPage {0} of {1}";
            this.grd_Destino.PintarFilaSel = true;
            this.grd_Destino.Redraw = true;
            this.grd_Destino.Row = 0;
            this.grd_Destino.Rows = 1;
            this.grd_Destino.Size = new System.Drawing.Size(478, 745);
            this.grd_Destino.TabIndex = 1;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.AutoSize = true;
            this.cmdAceptar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Depth = 0;
            this.cmdAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdAceptar.Location = new System.Drawing.Point(0, 0);
            this.cmdAceptar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdAceptar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Primary = false;
            this.cmdAceptar.Size = new System.Drawing.Size(215, 32);
            this.cmdAceptar.TabIndex = 2;
            this.cmdAceptar.Text = "Cambiar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(844, -7);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 879);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // lstLotes
            // 
            this.lstLotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLotes.FormattingEnabled = true;
            this.lstLotes.ItemHeight = 18;
            this.lstLotes.Location = new System.Drawing.Point(0, 0);
            this.lstLotes.Name = "lstLotes";
            this.lstLotes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstLotes.Size = new System.Drawing.Size(111, 130);
            this.lstLotes.TabIndex = 6;
            this.lstLotes.SelectedIndexChanged += new System.EventHandler(this.lstLotes_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(617, 42);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(130, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Seleccionar Lotes";
            // 
            // cmbSucO
            // 
            this.cmbSucO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSucO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucO.FormattingEnabled = true;
            this.cmbSucO.Location = new System.Drawing.Point(12, 12);
            this.cmbSucO.Name = "cmbSucO";
            this.cmbSucO.Size = new System.Drawing.Size(599, 24);
            this.cmbSucO.TabIndex = 13;
            this.cmbSucO.SelectedIndexChanged += new System.EventHandler(this.cmbSucO_SelectedIndexChanged);
            // 
            // cmbSucD
            // 
            this.cmbSucD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbSucD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucD.FormattingEnabled = true;
            this.cmbSucD.Location = new System.Drawing.Point(860, 12);
            this.cmbSucD.Name = "cmbSucD";
            this.cmbSucD.Size = new System.Drawing.Size(478, 24);
            this.cmbSucD.TabIndex = 14;
            this.cmbSucD.SelectedIndexChanged += new System.EventHandler(this.cmbSucD_SelectedIndexChanged);
            // 
            // lstTipos_t
            // 
            this.lstTipos_t.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipos_t.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipos_t.FormattingEnabled = true;
            this.lstTipos_t.ItemHeight = 16;
            this.lstTipos_t.Location = new System.Drawing.Point(3, 21);
            this.lstTipos_t.Name = "lstTipos_t";
            this.lstTipos_t.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTipos_t.Size = new System.Drawing.Size(213, 128);
            this.lstTipos_t.TabIndex = 16;
            this.lstTipos_t.SelectedIndexChanged += new System.EventHandler(this.lstTipos_t_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, -1);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(56, 19);
            this.materialLabel1.TabIndex = 17;
            this.materialLabel1.Text = "Tarjeta";
            // 
            // grdResumenDest
            // 
            this.grdResumenDest.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResumenDest.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResumenDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResumenDest.AutoResize = false;
            this.grdResumenDest.bColor = System.Drawing.SystemColors.Window;
            this.grdResumenDest.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResumenDest.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResumenDest.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResumenDest.Col = 0;
            this.grdResumenDest.Cols = 10;
            this.grdResumenDest.DataMember = "";
            this.grdResumenDest.DataSource = null;
            this.grdResumenDest.EnableEdicion = true;
            this.grdResumenDest.Encabezado = "";
            this.grdResumenDest.fColor = System.Drawing.Color.Silver;
            this.grdResumenDest.FixCols = 0;
            this.grdResumenDest.FixRows = 0;
            this.grdResumenDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdResumenDest.FuenteEncabezado = null;
            this.grdResumenDest.FuentePieDePagina = null;
            this.grdResumenDest.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResumenDest.Location = new System.Drawing.Point(0, 22);
            this.grdResumenDest.Name = "grdResumenDest";
            this.grdResumenDest.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResumenDest.PintarFilaSel = true;
            this.grdResumenDest.Redraw = true;
            this.grdResumenDest.Row = 0;
            this.grdResumenDest.Rows = 1;
            this.grdResumenDest.Size = new System.Drawing.Size(217, 213);
            this.grdResumenDest.TabIndex = 19;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(705, 522);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(133, 19);
            this.materialLabel3.TabIndex = 23;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(6, 2);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(71, 19);
            this.materialLabel5.TabIndex = 25;
            this.materialLabel5.Text = "Resumen";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdAceptar);
            this.panel1.Location = new System.Drawing.Point(1344, 793);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 34);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.lstTipos_t);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Location = new System.Drawing.Point(618, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 153);
            this.panel2.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.grdResumenDest);
            this.panel4.Controls.Add(this.materialLabel5);
            this.panel4.Location = new System.Drawing.Point(1344, 552);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(217, 233);
            this.panel4.TabIndex = 29;
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(620, 358);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(223, 184);
            this.cFecha.TabIndex = 15;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.Controls.Add(this.lstLotes);
            this.panel5.Location = new System.Drawing.Point(617, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(111, 130);
            this.panel5.TabIndex = 30;
            // 
            // materialLabel6
            // 
            this.materialLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(705, 522);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(133, 19);
            this.materialLabel6.TabIndex = 23;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.Controls.Add(this.grdResumenOri);
            this.panel7.Controls.Add(this.materialLabel8);
            this.panel7.Location = new System.Drawing.Point(623, 552);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(215, 235);
            this.panel7.TabIndex = 28;
            // 
            // grdResumenOri
            // 
            this.grdResumenOri.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResumenOri.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResumenOri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResumenOri.AutoResize = false;
            this.grdResumenOri.bColor = System.Drawing.SystemColors.Window;
            this.grdResumenOri.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResumenOri.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResumenOri.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResumenOri.Col = 0;
            this.grdResumenOri.Cols = 10;
            this.grdResumenOri.DataMember = "";
            this.grdResumenOri.DataSource = null;
            this.grdResumenOri.EnableEdicion = true;
            this.grdResumenOri.Encabezado = "";
            this.grdResumenOri.fColor = System.Drawing.Color.Silver;
            this.grdResumenOri.FixCols = 0;
            this.grdResumenOri.FixRows = 0;
            this.grdResumenOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdResumenOri.FuenteEncabezado = null;
            this.grdResumenOri.FuentePieDePagina = null;
            this.grdResumenOri.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResumenOri.Location = new System.Drawing.Point(1, 26);
            this.grdResumenOri.Name = "grdResumenOri";
            this.grdResumenOri.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResumenOri.PintarFilaSel = true;
            this.grdResumenOri.Redraw = true;
            this.grdResumenOri.Row = 0;
            this.grdResumenOri.Rows = 1;
            this.grdResumenOri.Size = new System.Drawing.Size(212, 209);
            this.grdResumenOri.TabIndex = 18;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(3, 1);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(71, 19);
            this.materialLabel8.TabIndex = 24;
            this.materialLabel8.Text = "Resumen";
            // 
            // frmModificar_Tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 828);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.cFecha);
            this.Controls.Add(this.cmbSucD);
            this.Controls.Add(this.cmbSucO);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.grd_Destino);
            this.Controls.Add(this.grdOrigen);
            this.Name = "frmModificar_Tarjetas";
            this.Text = "Modificar Tarjetas";
            this.Load += new System.EventHandler(this.frmModificar_Tarjetas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdOrigen;
        private Grilla2.SpeedGrilla grd_Destino;
        private MaterialSkin.Controls.MaterialFlatButton cmdAceptar;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.ListBox lstLotes;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox cmbSucO;
        private System.Windows.Forms.ComboBox cmbSucD;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.ListBox lstTipos_t;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Grilla2.SpeedGrilla grdResumenDest;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.Panel panel7;
        private Grilla2.SpeedGrilla grdResumenOri;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
    }
}