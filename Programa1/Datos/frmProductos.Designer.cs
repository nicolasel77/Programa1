namespace Programa1.Datos
{
    partial class frmProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.grdTipo = new Grilla2.SpeedGrilla();
            this.grdProductos = new Grilla2.SpeedGrilla();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipos de Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(401, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Productos";
            // 
            // tiMensaje
            // 
            this.tiMensaje.Interval = 5000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // grdTipo
            // 
            this.grdTipo.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTipo.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTipo.AutoResize = false;
            this.grdTipo.bColor = System.Drawing.SystemColors.Window;
            this.grdTipo.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTipo.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTipo.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTipo.Col = 0;
            this.grdTipo.Cols = 10;
            this.grdTipo.DataMember = "";
            this.grdTipo.DataSource = null;
            this.grdTipo.EnableEdicion = true;
            this.grdTipo.Encabezado = "";
            this.grdTipo.fColor = System.Drawing.SystemColors.Control;
            this.grdTipo.FixCols = 0;
            this.grdTipo.FixRows = 0;
            this.grdTipo.FuenteEncabezado = null;
            this.grdTipo.FuentePieDePagina = null;
            this.grdTipo.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipo.Location = new System.Drawing.Point(12, 30);
            this.grdTipo.MenuActivado = false;
            this.grdTipo.Name = "grdTipo";
            this.grdTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipo.PintarFilaSel = true;
            this.grdTipo.Redraw = true;
            this.grdTipo.Row = 0;
            this.grdTipo.Rows = 50;
            this.grdTipo.Size = new System.Drawing.Size(370, 661);
            this.grdTipo.TabIndex = 0;
            this.grdTipo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdTipo_Editado);
            this.grdTipo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdTipo_CambioFila);
            this.grdTipo.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdTipo_KeyUp);
            this.grdTipo.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdTipo_KeyPress);
            // 
            // grdProductos
            // 
            this.grdProductos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdProductos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProductos.AutoResize = false;
            this.grdProductos.bColor = System.Drawing.SystemColors.Window;
            this.grdProductos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdProductos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdProductos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdProductos.Col = 0;
            this.grdProductos.Cols = 10;
            this.grdProductos.DataMember = "";
            this.grdProductos.DataSource = null;
            this.grdProductos.EnableEdicion = true;
            this.grdProductos.Encabezado = "";
            this.grdProductos.fColor = System.Drawing.SystemColors.Control;
            this.grdProductos.FixCols = 0;
            this.grdProductos.FixRows = 0;
            this.grdProductos.FuenteEncabezado = null;
            this.grdProductos.FuentePieDePagina = null;
            this.grdProductos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdProductos.Location = new System.Drawing.Point(404, 30);
            this.grdProductos.MenuActivado = false;
            this.grdProductos.Name = "grdProductos";
            this.grdProductos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdProductos.PintarFilaSel = true;
            this.grdProductos.Redraw = true;
            this.grdProductos.Row = 0;
            this.grdProductos.Rows = 50;
            this.grdProductos.Size = new System.Drawing.Size(933, 642);
            this.grdProductos.TabIndex = 1;
            this.grdProductos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdProductos_Editado);
            this.grdProductos.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdProductos_CambioFila);
            this.grdProductos.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdProductos_KeyUp);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 678);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Location = new System.Drawing.Point(450, 678);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(296, 13);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(752, 678);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(585, 16);
            this.lblMensaje.TabIndex = 6;
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 703);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdProductos);
            this.Controls.Add(this.grdTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProductos";
            this.Text = "Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tiMensaje;
        private Grilla2.SpeedGrilla grdTipo;
        private Grilla2.SpeedGrilla grdProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblMensaje;
    }
}