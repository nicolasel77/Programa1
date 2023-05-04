namespace Programa1.Carga.Tesoreria
{
    partial class frmImportar_Entregas
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
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.cmdImportar = new Programa1.Controles.cBoton();
            this.cTodos = new Programa1.Controles.cBoton();
            this.SuspendLayout();
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
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
            this.grd.Size = new System.Drawing.Size(413, 709);
            this.grd.TabIndex = 0;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(289, 727);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(136, 31);
            this.cmdAceptar.TabIndex = 1;
            this.cmdAceptar.Texto = "Cerrar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdImportar
            // 
            this.cmdImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImportar.Location = new System.Drawing.Point(12, 727);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(136, 31);
            this.cmdImportar.TabIndex = 1;
            this.cmdImportar.Texto = "Importar";
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // cTodos
            // 
            this.cTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cTodos.Location = new System.Drawing.Point(147, 727);
            this.cTodos.Name = "cTodos";
            this.cTodos.Size = new System.Drawing.Size(136, 31);
            this.cTodos.TabIndex = 1;
            this.cTodos.Texto = "Importar Todo";
            this.cTodos.Click += new System.EventHandler(this.cTodos_Click);
            // 
            // frmImportar_Entregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 770);
            this.Controls.Add(this.cTodos);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.grd);
            this.Name = "frmImportar_Entregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar_Entregas";
            this.ResumeLayout(false);

        }

        #endregion

        private Grilla2.SpeedGrilla grd;
        private Controles.cBoton cmdAceptar;
        private Controles.cBoton cmdImportar;
        private Controles.cBoton cTodos;
    }
}