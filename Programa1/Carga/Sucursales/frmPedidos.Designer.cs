namespace Programa1.Carga.Sucursales
{
    partial class frmPedidos
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
            this.grd = new Grilla2.SpeedGrilla();
            this.chAgruparProductos = new MaterialSkin.Controls.MaterialCheckBox();
            this.chColumnas = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdMostrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cProds = new Programa1.Controles.cProductos();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.cFecha = new Programa1.Controles.cFechas();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoResize = false;
            this.grd.bColor = System.Drawing.SystemColors.Window;
            this.grd.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grd.bFColor = System.Drawing.SystemColors.WindowText;
            this.grd.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grd.Col = 0;
            this.grd.Cols = 10;
            this.grd.DataMember = "";
            this.grd.DataSource = null;
            this.grd.EnableEdicion = true;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.Color.Silver;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.Frozen = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.LimpiarEstilosAntesDeOrdenar = false;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(782, 739);
            this.grd.TabIndex = 0;
            // 
            // chAgruparProductos
            // 
            this.chAgruparProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chAgruparProductos.AutoSize = true;
            this.chAgruparProductos.Depth = 0;
            this.chAgruparProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chAgruparProductos.Location = new System.Drawing.Point(1087, 483);
            this.chAgruparProductos.Margin = new System.Windows.Forms.Padding(0);
            this.chAgruparProductos.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chAgruparProductos.MouseState = MaterialSkin.MouseState.HOVER;
            this.chAgruparProductos.Name = "chAgruparProductos";
            this.chAgruparProductos.Ripple = true;
            this.chAgruparProductos.Size = new System.Drawing.Size(146, 30);
            this.chAgruparProductos.TabIndex = 4;
            this.chAgruparProductos.Text = "Agrupar Productos";
            this.chAgruparProductos.UseVisualStyleBackColor = true;
            this.chAgruparProductos.CheckedChanged += new System.EventHandler(this.chAgruparProductos_CheckedChanged);
            // 
            // chColumnas
            // 
            this.chColumnas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chColumnas.AutoSize = true;
            this.chColumnas.Checked = true;
            this.chColumnas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chColumnas.Depth = 0;
            this.chColumnas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chColumnas.Location = new System.Drawing.Point(1087, 513);
            this.chColumnas.Margin = new System.Windows.Forms.Padding(0);
            this.chColumnas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chColumnas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chColumnas.Name = "chColumnas";
            this.chColumnas.Ripple = true;
            this.chColumnas.Size = new System.Drawing.Size(180, 30);
            this.chColumnas.TabIndex = 4;
            this.chColumnas.Text = "Sucursales en columnas";
            this.chColumnas.UseVisualStyleBackColor = true;
            this.chColumnas.CheckedChanged += new System.EventHandler(this.chAgruparProductos_CheckedChanged);
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMostrar.Location = new System.Drawing.Point(1205, 715);
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Size = new System.Drawing.Size(138, 36);
            this.cmdMostrar.TabIndex = 5;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.cmdMostrar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1205, 673);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cProds
            // 
            this.cProds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cProds.BackColor = System.Drawing.Color.Gainsboro;
            this.cProds.Filtrar_Ver = true;
            this.cProds.Filtro_In = "";
            this.cProds.Location = new System.Drawing.Point(1087, 12);
            this.cProds.Mostrar_Tipo = true;
            this.cProds.Name = "cProds";
            this.cProds.Size = new System.Drawing.Size(256, 465);
            this.cProds.TabIndex = 3;
            this.cProds.Titulo = "Productos";
            this.cProds.Valor_Actual = -1;
            this.cProds.Cambio_Seleccion += new System.EventHandler(this.cProds_Cambio_Seleccion);
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(800, 12);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = true;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSuc.Size = new System.Drawing.Size(281, 465);
            this.cSuc.TabIndex = 2;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.cSuc_Cambio_Seleccion);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(800, 483);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 1;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(281, 268);
            this.cFecha.TabIndex = 1;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.cFecha_Cambio_Seleccion);
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 763);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdMostrar);
            this.Controls.Add(this.chColumnas);
            this.Controls.Add(this.chAgruparProductos);
            this.Controls.Add(this.cProds);
            this.Controls.Add(this.cSuc);
            this.Controls.Add(this.cFecha);
            this.Controls.Add(this.grd);
            this.Name = "frmPedidos";
            this.Text = "Pedidos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grd;
        private Controles.cFechas cFecha;
        private Controles.cSucursales cSuc;
        private Controles.cProductos cProds;
        private MaterialSkin.Controls.MaterialCheckBox chAgruparProductos;
        private MaterialSkin.Controls.MaterialCheckBox chColumnas;
        private System.Windows.Forms.Button cmdMostrar;
        private System.Windows.Forms.Button button1;
    }
}