namespace Programa1.Carga.Sucursales
{

    partial class frmImprimir_Ofertas
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
            this.lstSucs = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstListas = new System.Windows.Forms.ListBox();
            this.txtAgregar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.grdLista = new Grilla2.SpeedGrilla();
            this.cBoton1 = new Programa1.Controles.cBoton();
            this.cmdVistaPrevia = new Programa1.Controles.cBoton();
            this.cmdEditar = new Programa1.Controles.cBoton();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdAgregar = new Programa1.Controles.cBoton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSucs
            // 
            this.lstSucs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSucs.FormattingEnabled = true;
            this.lstSucs.Location = new System.Drawing.Point(0, 0);
            this.lstSucs.Name = "lstSucs";
            this.lstSucs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSucs.Size = new System.Drawing.Size(200, 646);
            this.lstSucs.TabIndex = 0;
            this.lstSucs.SelectedIndexChanged += new System.EventHandler(this.lstSucs_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstSucs);
            this.panel1.Location = new System.Drawing.Point(863, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 646);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lstListas);
            this.panel2.Location = new System.Drawing.Point(1069, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 265);
            this.panel2.TabIndex = 2;
            // 
            // lstListas
            // 
            this.lstListas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstListas.FormattingEnabled = true;
            this.lstListas.Location = new System.Drawing.Point(0, 0);
            this.lstListas.Name = "lstListas";
            this.lstListas.Size = new System.Drawing.Size(200, 265);
            this.lstListas.TabIndex = 0;
            this.lstListas.SelectedIndexChanged += new System.EventHandler(this.lstListas_SelectedIndexChanged);
            // 
            // txtAgregar
            // 
            this.txtAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAgregar.Depth = 0;
            this.txtAgregar.ForeColor = System.Drawing.Color.DimGray;
            this.txtAgregar.Hint = "Agregar";
            this.txtAgregar.Location = new System.Drawing.Point(1069, 283);
            this.txtAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.PasswordChar = '\0';
            this.txtAgregar.SelectedText = "";
            this.txtAgregar.SelectionLength = 0;
            this.txtAgregar.SelectionStart = 0;
            this.txtAgregar.Size = new System.Drawing.Size(200, 23);
            this.txtAgregar.TabIndex = 13;
            this.txtAgregar.UseSystemPasswordChar = false;
            // 
            // grdLista
            // 
            this.grdLista.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdLista.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLista.AutoResize = false;
            this.grdLista.bColor = System.Drawing.SystemColors.Window;
            this.grdLista.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdLista.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdLista.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdLista.Col = 0;
            this.grdLista.Cols = 10;
            this.grdLista.DataMember = "";
            this.grdLista.DataSource = null;
            this.grdLista.EnableEdicion = true;
            this.grdLista.Encabezado = "";
            this.grdLista.fColor = System.Drawing.Color.Silver;
            this.grdLista.FixCols = 0;
            this.grdLista.FixRows = 0;
            this.grdLista.FuenteEncabezado = null;
            this.grdLista.FuentePieDePagina = null;
            this.grdLista.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdLista.Location = new System.Drawing.Point(12, 12);
            this.grdLista.Name = "grdLista";
            this.grdLista.PieDePagina = "\t\tPage {0} of {1}";
            this.grdLista.PintarFilaSel = true;
            this.grdLista.Redraw = true;
            this.grdLista.Row = 0;
            this.grdLista.Rows = 15;
            this.grdLista.Size = new System.Drawing.Size(845, 646);
            this.grdLista.TabIndex = 1;
            this.grdLista.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdLista_Editado);
            this.grdLista.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdLista_CambioFila);
            this.grdLista.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdLista_KeyUp);
            // 
            // cBoton1
            // 
            this.cBoton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoton1.Location = new System.Drawing.Point(1069, 618);
            this.cBoton1.Name = "cBoton1";
            this.cBoton1.Size = new System.Drawing.Size(200, 40);
            this.cBoton1.TabIndex = 16;
            this.cBoton1.Texto = "Guardar";
            // 
            // cmdVistaPrevia
            // 
            this.cmdVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdVistaPrevia.Location = new System.Drawing.Point(1069, 526);
            this.cmdVistaPrevia.Name = "cmdVistaPrevia";
            this.cmdVistaPrevia.Size = new System.Drawing.Size(200, 40);
            this.cmdVistaPrevia.TabIndex = 15;
            this.cmdVistaPrevia.Texto = "Vista Previa";
            // 
            // cmdEditar
            // 
            this.cmdEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditar.Location = new System.Drawing.Point(1069, 572);
            this.cmdEditar.Name = "cmdEditar";
            this.cmdEditar.Size = new System.Drawing.Size(200, 40);
            this.cmdEditar.TabIndex = 14;
            this.cmdEditar.Texto = "Editar sucs";
            this.cmdEditar.Click += new System.EventHandler(this.cmdEditar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.Location = new System.Drawing.Point(1069, 358);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(200, 40);
            this.cmdBorrar.TabIndex = 11;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAgregar.Location = new System.Drawing.Point(1069, 312);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(200, 40);
            this.cmdAgregar.TabIndex = 12;
            this.cmdAgregar.Texto = "Agregar";
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // frmImprimir_Ofertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 670);
            this.Controls.Add(this.cBoton1);
            this.Controls.Add(this.cmdVistaPrevia);
            this.Controls.Add(this.cmdEditar);
            this.Controls.Add(this.grdLista);
            this.Controls.Add(this.txtAgregar);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmImprimir_Ofertas";
            this.Text = "Imprimir_Ofertas";
            this.Load += new System.EventHandler(this.frmImprimir_Ofertas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSucs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstListas;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAgregar;
        private Controles.cBoton cmdBorrar;
        private Controles.cBoton cmdAgregar;
        private Grilla2.SpeedGrilla grdLista;
        private Controles.cBoton cmdEditar;
        private Controles.cBoton cmdVistaPrevia;
        private Controles.cBoton cBoton1;
    }
}