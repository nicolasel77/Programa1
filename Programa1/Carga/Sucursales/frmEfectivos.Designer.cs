namespace Programa1.Carga.Sucursales
{
    partial class frmEfectivos
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
            this.grdEfectivos = new Grilla2.SpeedGrilla();
            this.cSuc = new Programa1.Controles.cSucursales();
            this.cFecha = new Programa1.Controles.cFechas();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ttTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEfectivos
            // 
            this.grdEfectivos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdEfectivos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdEfectivos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdEfectivos.AutoResize = false;
            this.grdEfectivos.bColor = System.Drawing.SystemColors.Window;
            this.grdEfectivos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdEfectivos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdEfectivos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdEfectivos.Col = 0;
            this.grdEfectivos.Cols = 10;
            this.grdEfectivos.DataMember = "";
            this.grdEfectivos.DataSource = null;
            this.grdEfectivos.EnableEdicion = true;
            this.grdEfectivos.Encabezado = "";
            this.grdEfectivos.fColor = System.Drawing.Color.Silver;
            this.grdEfectivos.FixCols = 0;
            this.grdEfectivos.FixRows = 0;
            this.grdEfectivos.Frozen = 0;
            this.grdEfectivos.FuenteEncabezado = null;
            this.grdEfectivos.FuentePieDePagina = null;
            this.grdEfectivos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdEfectivos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdEfectivos.Location = new System.Drawing.Point(12, 12);
            this.grdEfectivos.Name = "grdEfectivos";
            this.grdEfectivos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdEfectivos.PintarFilaSel = true;
            this.grdEfectivos.Redraw = true;
            this.grdEfectivos.Row = 0;
            this.grdEfectivos.Rows = 50;
            this.grdEfectivos.Size = new System.Drawing.Size(722, 635);
            this.grdEfectivos.TabIndex = 0;
            // 
            // cSuc
            // 
            this.cSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cSuc.BackColor = System.Drawing.Color.Gainsboro;
            this.cSuc.Filtro_In = "";
            this.cSuc.Location = new System.Drawing.Point(740, 12);
            this.cSuc.Mostrar_Botones = true;
            this.cSuc.Mostrar_Tipo = true;
            this.cSuc.Name = "cSuc";
            this.cSuc.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSuc.Size = new System.Drawing.Size(350, 379);
            this.cSuc.TabIndex = 1;
            this.cSuc.Titulo = "Sucursales";
            this.cSuc.Valor_Actual = -1;
            this.cSuc.Cambio_Seleccion += new System.EventHandler(this.Cargar);
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(740, 397);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 184);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(350, 250);
            this.cFecha.TabIndex = 2;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.Cargar);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1198, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ttTotal
            // 
            this.ttTotal.Name = "ttTotal";
            this.ttTotal.Size = new System.Drawing.Size(32, 17);
            this.ttTotal.Text = "Total";
            // 
            // frmEfectivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 672);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cFecha);
            this.Controls.Add(this.cSuc);
            this.Controls.Add(this.grdEfectivos);
            this.Name = "frmEfectivos";
            this.Text = "Efectivos";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdEfectivos;
        private Controles.cSucursales cSuc;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ttTotal;
    }
}