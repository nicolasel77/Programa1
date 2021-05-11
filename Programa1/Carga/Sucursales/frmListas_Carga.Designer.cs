
namespace Programa1.Carga.Sucursales
{
    partial class frmListas_Carga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListas_Carga));
            this.lstListas = new System.Windows.Forms.ListBox();
            this.grd = new Grilla2.SpeedGrilla();
            this.txtAgregar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdSalir = new Programa1.Controles.cBoton();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdAgregar = new Programa1.Controles.cBoton();
            this.SuspendLayout();
            // 
            // lstListas
            // 
            this.lstListas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstListas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lstListas.FormattingEnabled = true;
            this.lstListas.ItemHeight = 18;
            this.lstListas.Location = new System.Drawing.Point(535, 12);
            this.lstListas.Name = "lstListas";
            this.lstListas.Size = new System.Drawing.Size(187, 522);
            this.lstListas.TabIndex = 6;
            this.lstListas.SelectedIndexChanged += new System.EventHandler(this.lstListas_SelectedIndexChanged);
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
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(8, 12);
            this.grd.MenuActivado = false;
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(521, 703);
            this.grd.TabIndex = 8;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            // 
            // txtAgregar
            // 
            this.txtAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgregar.Depth = 0;
            this.txtAgregar.ForeColor = System.Drawing.Color.DimGray;
            this.txtAgregar.Hint = "Agregar";
            this.txtAgregar.Location = new System.Drawing.Point(535, 554);
            this.txtAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.PasswordChar = '\0';
            this.txtAgregar.SelectedText = "";
            this.txtAgregar.SelectionLength = 0;
            this.txtAgregar.SelectionStart = 0;
            this.txtAgregar.Size = new System.Drawing.Size(187, 23);
            this.txtAgregar.TabIndex = 9;
            this.txtAgregar.Text = "Agregar";
            this.txtAgregar.UseSystemPasswordChar = false;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.Location = new System.Drawing.Point(535, 675);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(187, 40);
            this.cmdSalir.TabIndex = 7;
            this.cmdSalir.Texto = "Salir";
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.Location = new System.Drawing.Point(535, 629);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(187, 40);
            this.cmdBorrar.TabIndex = 7;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgregar.Location = new System.Drawing.Point(535, 583);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(187, 40);
            this.cmdAgregar.TabIndex = 7;
            this.cmdAgregar.Texto = "Agregar";
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // frmListas_Carga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 727);
            this.Controls.Add(this.txtAgregar);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.lstListas);
            this.Name = "frmListas_Carga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listas de Carga";
            this.Load += new System.EventHandler(this.frmListas_Carga_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstListas;
        private Controles.cBoton cmdAgregar;
        private Grilla2.SpeedGrilla grd;
        private Controles.cBoton cmdBorrar;
        private Controles.cBoton cmdSalir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAgregar;
    }
}