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
            this.mtcFecha = new System.Windows.Forms.MonthCalendar();
            this.cmbTipofecha = new System.Windows.Forms.ComboBox();
            this.txtTitulos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmbTitulos = new System.Windows.Forms.ComboBox();
            this.grdLista = new Grilla2.SpeedGrilla();
            this.txtCopias = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.cmdVistaPrevia = new Programa1.Controles.cBoton();
            this.cmdEditar = new Programa1.Controles.cBoton();
            this.cmdBorrar = new Programa1.Controles.cBoton();
            this.cmdAgregar = new Programa1.Controles.cBoton();
            this.lblVariasHojas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSucs
            // 
            this.lstSucs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSucs.FormattingEnabled = true;
            this.lstSucs.Location = new System.Drawing.Point(0, 0);
            this.lstSucs.Name = "lstSucs";
            this.lstSucs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSucs.Size = new System.Drawing.Size(175, 508);
            this.lstSucs.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstSucs);
            this.panel1.Location = new System.Drawing.Point(879, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 508);
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
            this.txtAgregar.Text = "Agregar";
            this.txtAgregar.UseSystemPasswordChar = false;
            this.txtAgregar.Click += new System.EventHandler(this.txtAgregar_Click);
            this.txtAgregar.Enter += new System.EventHandler(this.txtAgregar_Enter);
            this.txtAgregar.Leave += new System.EventHandler(this.txtAgregar_Leave);
            // 
            // mtcFecha
            // 
            this.mtcFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mtcFecha.Location = new System.Drawing.Point(1, 0);
            this.mtcFecha.Name = "mtcFecha";
            this.mtcFecha.TabIndex = 17;
            // 
            // cmbTipofecha
            // 
            this.cmbTipofecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipofecha.FormattingEnabled = true;
            this.cmbTipofecha.Items.AddRange(new object[] {
            "(Día)",
            "SEMANA DEL"});
            this.cmbTipofecha.Location = new System.Drawing.Point(1069, 419);
            this.cmbTipofecha.Name = "cmbTipofecha";
            this.cmbTipofecha.Size = new System.Drawing.Size(200, 21);
            this.cmbTipofecha.TabIndex = 18;
            // 
            // txtTitulos
            // 
            this.txtTitulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulos.Depth = 0;
            this.txtTitulos.ForeColor = System.Drawing.Color.DimGray;
            this.txtTitulos.Hint = "Agregar titulos";
            this.txtTitulos.Location = new System.Drawing.Point(1069, 487);
            this.txtTitulos.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTitulos.Name = "txtTitulos";
            this.txtTitulos.PasswordChar = '\0';
            this.txtTitulos.SelectedText = "";
            this.txtTitulos.SelectionLength = 0;
            this.txtTitulos.SelectionStart = 0;
            this.txtTitulos.Size = new System.Drawing.Size(200, 23);
            this.txtTitulos.TabIndex = 19;
            this.txtTitulos.Text = "Agregar titulos";
            this.txtTitulos.UseSystemPasswordChar = false;
            this.txtTitulos.Enter += new System.EventHandler(this.txtTitulos_Enter);
            this.txtTitulos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTitulos_KeyUp);
            this.txtTitulos.Leave += new System.EventHandler(this.txtTitulos_Leave);
            // 
            // cmbTitulos
            // 
            this.cmbTitulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTitulos.FormattingEnabled = true;
            this.cmbTitulos.Location = new System.Drawing.Point(1069, 460);
            this.cmbTitulos.Name = "cmbTitulos";
            this.cmbTitulos.Size = new System.Drawing.Size(200, 21);
            this.cmbTitulos.TabIndex = 21;
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
            this.grdLista.Size = new System.Drawing.Size(855, 646);
            this.grdLista.TabIndex = 1;
            this.grdLista.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdLista_Editado);
            this.grdLista.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdLista_CambioFila);
            this.grdLista.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdLista_KeyUp);
            // 
            // txtCopias
            // 
            this.txtCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopias.Depth = 0;
            this.txtCopias.ForeColor = System.Drawing.Color.DimGray;
            this.txtCopias.Hint = "Agregar titulos";
            this.txtCopias.Location = new System.Drawing.Point(1069, 516);
            this.txtCopias.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCopias.Name = "txtCopias";
            this.txtCopias.PasswordChar = '\0';
            this.txtCopias.SelectedText = "";
            this.txtCopias.SelectionLength = 0;
            this.txtCopias.SelectionStart = 0;
            this.txtCopias.Size = new System.Drawing.Size(200, 23);
            this.txtCopias.TabIndex = 22;
            this.txtCopias.Text = "Copias";
            this.txtCopias.UseSystemPasswordChar = false;
            this.txtCopias.Enter += new System.EventHandler(this.cmbCopias_Enter);
            this.txtCopias.Leave += new System.EventHandler(this.cmbCopias_Leave);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(1069, 618);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(200, 40);
            this.cmdImprimir.TabIndex = 25;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.Location = new System.Drawing.Point(879, 618);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(200, 40);
            this.cmdGuardar.TabIndex = 16;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdVistaPrevia
            // 
            this.cmdVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdVistaPrevia.Location = new System.Drawing.Point(879, 526);
            this.cmdVistaPrevia.Name = "cmdVistaPrevia";
            this.cmdVistaPrevia.Size = new System.Drawing.Size(200, 40);
            this.cmdVistaPrevia.TabIndex = 15;
            this.cmdVistaPrevia.Texto = "Vista Previa";
            this.cmdVistaPrevia.Click += new System.EventHandler(this.cmdVistaPrevia_Click);
            // 
            // cmdEditar
            // 
            this.cmdEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEditar.Location = new System.Drawing.Point(879, 572);
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
            // lblVariasHojas
            // 
            this.lblVariasHojas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVariasHojas.AutoSize = true;
            this.lblVariasHojas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariasHojas.ForeColor = System.Drawing.Color.Red;
            this.lblVariasHojas.Location = new System.Drawing.Point(1066, 596);
            this.lblVariasHojas.Name = "lblVariasHojas";
            this.lblVariasHojas.Size = new System.Drawing.Size(177, 16);
            this.lblVariasHojas.TabIndex = 26;
            this.lblVariasHojas.Text = "Se imprimirá en varias hojas";
            this.lblVariasHojas.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1066, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "Titulos";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1066, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Formato de fecha";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.mtcFecha);
            this.panel3.Location = new System.Drawing.Point(1069, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 162);
            this.panel3.TabIndex = 29;
            // 
            // frmImprimir_Ofertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 670);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmbTitulos);
            this.Controls.Add(this.cmbTipofecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVariasHojas);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.txtCopias);
            this.Controls.Add(this.txtTitulos);
            this.Controls.Add(this.cmdGuardar);
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
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Controles.cBoton cmdGuardar;
        private System.Windows.Forms.MonthCalendar mtcFecha;
        private System.Windows.Forms.ComboBox cmbTipofecha;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtTitulos;
        private System.Windows.Forms.ComboBox cmbTitulos;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCopias;
        private Controles.cBoton cmdImprimir;
        private System.Windows.Forms.Label lblVariasHojas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
    }
}