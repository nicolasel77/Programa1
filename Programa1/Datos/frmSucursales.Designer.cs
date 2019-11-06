namespace Programa1.Datos
{
    partial class frmSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSucursales));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.grdTipo = new Grilla2.SpeedGrilla();
            this.grdSucursales = new Grilla2.SpeedGrilla();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdPartidos = new Grilla2.SpeedGrilla();
            this.label4 = new System.Windows.Forms.Label();
            this.grdLocalidades = new Grilla2.SpeedGrilla();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipos de Sucursal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(401, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sucursales";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1158, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
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
            this.grdTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grdTipo.Location = new System.Drawing.Point(6, 21);
            this.grdTipo.MenuActivado = false;
            this.grdTipo.Name = "grdTipo";
            this.grdTipo.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipo.PintarFilaSel = true;
            this.grdTipo.Redraw = true;
            this.grdTipo.Row = 0;
            this.grdTipo.Rows = 50;
            this.grdTipo.Size = new System.Drawing.Size(389, 169);
            this.grdTipo.TabIndex = 0;
            this.grdTipo.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdTipo_Editado);
            this.grdTipo.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdTipo_CambioFila);
            this.grdTipo.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdTipo_KeyUp);
            this.grdTipo.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdTipo_KeyPress);
            // 
            // grdSucursales
            // 
            this.grdSucursales.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSucursales.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSucursales.AutoResize = false;
            this.grdSucursales.bColor = System.Drawing.SystemColors.Window;
            this.grdSucursales.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSucursales.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSucursales.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSucursales.Col = 0;
            this.grdSucursales.Cols = 10;
            this.grdSucursales.DataMember = "";
            this.grdSucursales.DataSource = null;
            this.grdSucursales.EnableEdicion = true;
            this.grdSucursales.Encabezado = "";
            this.grdSucursales.fColor = System.Drawing.SystemColors.Control;
            this.grdSucursales.FixCols = 0;
            this.grdSucursales.FixRows = 0;
            this.grdSucursales.FuenteEncabezado = null;
            this.grdSucursales.FuentePieDePagina = null;
            this.grdSucursales.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSucursales.Location = new System.Drawing.Point(404, 30);
            this.grdSucursales.MenuActivado = false;
            this.grdSucursales.Name = "grdSucursales";
            this.grdSucursales.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSucursales.PintarFilaSel = true;
            this.grdSucursales.Redraw = true;
            this.grdSucursales.Row = 0;
            this.grdSucursales.Rows = 50;
            this.grdSucursales.Size = new System.Drawing.Size(742, 640);
            this.grdSucursales.TabIndex = 3;
            this.grdSucursales.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdSucursales_Editado);
            this.grdSucursales.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdSucursales_CambioFila);
            this.grdSucursales.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdSucursales_KeyUp);
            this.grdSucursales.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.GrdSucursales_KeyPress);
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
            this.txtBuscar.Location = new System.Drawing.Point(450, 671);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(296, 20);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 9);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdTipo);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(398, 682);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 7;
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
            this.splitContainer2.Panel1.Controls.Add(this.grdPartidos);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdLocalidades);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Size = new System.Drawing.Size(398, 481);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // grdPartidos
            // 
            this.grdPartidos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdPartidos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdPartidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPartidos.AutoResize = false;
            this.grdPartidos.bColor = System.Drawing.SystemColors.Window;
            this.grdPartidos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdPartidos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdPartidos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdPartidos.Col = 0;
            this.grdPartidos.Cols = 10;
            this.grdPartidos.DataMember = "";
            this.grdPartidos.DataSource = null;
            this.grdPartidos.EnableEdicion = true;
            this.grdPartidos.Encabezado = "";
            this.grdPartidos.fColor = System.Drawing.SystemColors.Control;
            this.grdPartidos.FixCols = 0;
            this.grdPartidos.FixRows = 0;
            this.grdPartidos.FuenteEncabezado = null;
            this.grdPartidos.FuentePieDePagina = null;
            this.grdPartidos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdPartidos.Location = new System.Drawing.Point(6, 21);
            this.grdPartidos.MenuActivado = false;
            this.grdPartidos.Name = "grdPartidos";
            this.grdPartidos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdPartidos.PintarFilaSel = true;
            this.grdPartidos.Redraw = true;
            this.grdPartidos.Row = 0;
            this.grdPartidos.Rows = 50;
            this.grdPartidos.Size = new System.Drawing.Size(389, 178);
            this.grdPartidos.TabIndex = 1;
            this.grdPartidos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdPartidos_Editado);
            this.grdPartidos.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdPartidos_CambioFila);
            this.grdPartidos.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdPartidos_KeyUp);
            this.grdPartidos.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdPartidos_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label4.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Partidos";
            // 
            // grdLocalidades
            // 
            this.grdLocalidades.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdLocalidades.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdLocalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLocalidades.AutoResize = false;
            this.grdLocalidades.bColor = System.Drawing.SystemColors.Window;
            this.grdLocalidades.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdLocalidades.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdLocalidades.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdLocalidades.Col = 0;
            this.grdLocalidades.Cols = 10;
            this.grdLocalidades.DataMember = "";
            this.grdLocalidades.DataSource = null;
            this.grdLocalidades.EnableEdicion = true;
            this.grdLocalidades.Encabezado = "";
            this.grdLocalidades.fColor = System.Drawing.SystemColors.Control;
            this.grdLocalidades.FixCols = 0;
            this.grdLocalidades.FixRows = 0;
            this.grdLocalidades.FuenteEncabezado = null;
            this.grdLocalidades.FuentePieDePagina = null;
            this.grdLocalidades.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdLocalidades.Location = new System.Drawing.Point(6, 21);
            this.grdLocalidades.MenuActivado = false;
            this.grdLocalidades.Name = "grdLocalidades";
            this.grdLocalidades.PieDePagina = "\t\tPage {0} of {1}";
            this.grdLocalidades.PintarFilaSel = true;
            this.grdLocalidades.Redraw = true;
            this.grdLocalidades.Row = 0;
            this.grdLocalidades.Rows = 50;
            this.grdLocalidades.Size = new System.Drawing.Size(389, 239);
            this.grdLocalidades.TabIndex = 2;
            this.grdLocalidades.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdLocalidades_Editado);
            this.grdLocalidades.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdLocalidades_CambioFila);
            this.grdLocalidades.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdLocalidades_KeyUp);
            this.grdLocalidades.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grdLocalidades_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label5.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Localidades";
            // 
            // frmSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 716);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdSucursales);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Name = "frmSucursales";
            this.Text = "Sucursales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSucursales_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private System.Windows.Forms.Timer tiMensaje;
        private Grilla2.SpeedGrilla grdTipo;
        private Grilla2.SpeedGrilla grdSucursales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Grilla2.SpeedGrilla grdPartidos;
        private System.Windows.Forms.Label label4;
        private Grilla2.SpeedGrilla grdLocalidades;
        private System.Windows.Forms.Label label5;
    }
}