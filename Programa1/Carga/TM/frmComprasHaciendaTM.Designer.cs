namespace Programa1.Carga.TM
{
    partial class frmComprasHaciendaTM
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
            this.grdFacturas = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstConsignatarios = new System.Windows.Forms.ListBox();
            this.cmdNueva = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.lblTDetalle = new System.Windows.Forms.Label();
            this.grdDetalle = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.grdAgregados = new Grilla2.SpeedGrilla();
            this.lblTAgregados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdPagos = new Grilla2.SpeedGrilla();
            this.lblTPagos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFacturas
            // 
            this.grdFacturas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdFacturas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFacturas.AutoResize = false;
            this.grdFacturas.bColor = System.Drawing.SystemColors.Window;
            this.grdFacturas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdFacturas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdFacturas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdFacturas.Col = -2;
            this.grdFacturas.Cols = 0;
            this.grdFacturas.DataMember = "";
            this.grdFacturas.DataSource = null;
            this.grdFacturas.EnableEdicion = true;
            this.grdFacturas.Encabezado = "";
            this.grdFacturas.fColor = System.Drawing.Color.Silver;
            this.grdFacturas.FixCols = 0;
            this.grdFacturas.FixRows = 0;
            this.grdFacturas.Frozen = 0;
            this.grdFacturas.FuenteEncabezado = null;
            this.grdFacturas.FuentePieDePagina = null;
            this.grdFacturas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdFacturas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdFacturas.Location = new System.Drawing.Point(224, 26);
            this.grdFacturas.Name = "grdFacturas";
            this.grdFacturas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdFacturas.PintarFilaSel = true;
            this.grdFacturas.Redraw = true;
            this.grdFacturas.Row = 0;
            this.grdFacturas.Rows = 50;
            this.grdFacturas.Size = new System.Drawing.Size(743, 661);
            this.grdFacturas.TabIndex = 1;
            this.grdFacturas.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdFacturas_CambioFila);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Silver;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.txtBuscar);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.lstConsignatarios);
            this.splitContainer3.Panel1.Controls.Add(this.cmdNueva);
            this.splitContainer3.Panel1.Controls.Add(this.cmdBorrar);
            this.splitContainer3.Panel1.Controls.Add(this.cmdActualizar);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.grdFacturas);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1526, 734);
            this.splitContainer3.SplitterDistance = 970;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 1;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(12, 42);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(195, 19);
            this.txtBuscar.TabIndex = 8;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Consignatarios";
            // 
            // lstConsignatarios
            // 
            this.lstConsignatarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstConsignatarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstConsignatarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstConsignatarios.FormattingEnabled = true;
            this.lstConsignatarios.ItemHeight = 16;
            this.lstConsignatarios.Location = new System.Drawing.Point(12, 74);
            this.lstConsignatarios.Name = "lstConsignatarios";
            this.lstConsignatarios.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstConsignatarios.Size = new System.Drawing.Size(195, 640);
            this.lstConsignatarios.TabIndex = 6;
            this.lstConsignatarios.SelectedIndexChanged += new System.EventHandler(this.lstConsignatarios_SelectedIndexChanged);
            // 
            // cmdNueva
            // 
            this.cmdNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNueva.BackColor = System.Drawing.Color.MediumTurquoise;
            this.cmdNueva.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNueva.Location = new System.Drawing.Point(688, 693);
            this.cmdNueva.Name = "cmdNueva";
            this.cmdNueva.Size = new System.Drawing.Size(89, 27);
            this.cmdNueva.TabIndex = 3;
            this.cmdNueva.Text = "Nueva";
            this.cmdNueva.UseVisualStyleBackColor = false;
            this.cmdNueva.Click += new System.EventHandler(this.cmdNueva_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrar.Location = new System.Drawing.Point(783, 693);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(89, 27);
            this.cmdBorrar.TabIndex = 4;
            this.cmdBorrar.Text = "Borrar";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdActualizar.Location = new System.Drawing.Point(878, 693);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(89, 27);
            this.cmdActualizar.TabIndex = 5;
            this.cmdActualizar.Text = "Actualizar";
            this.cmdActualizar.UseVisualStyleBackColor = true;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(970, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facturas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Silver;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel1.Controls.Add(this.lblTDetalle);
            this.splitContainer4.Panel1.Controls.Add(this.grdDetalle);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer4.Size = new System.Drawing.Size(550, 734);
            this.splitContainer4.SplitterDistance = 152;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // lblTDetalle
            // 
            this.lblTDetalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDetalle.Location = new System.Drawing.Point(0, 129);
            this.lblTDetalle.Name = "lblTDetalle";
            this.lblTDetalle.Size = new System.Drawing.Size(550, 23);
            this.lblTDetalle.TabIndex = 6;
            this.lblTDetalle.Text = "Totales";
            this.lblTDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdDetalle
            // 
            this.grdDetalle.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalle.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetalle.AutoResize = false;
            this.grdDetalle.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalle.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalle.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalle.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalle.Col = -2;
            this.grdDetalle.Cols = 0;
            this.grdDetalle.DataMember = "";
            this.grdDetalle.DataSource = null;
            this.grdDetalle.EnableEdicion = true;
            this.grdDetalle.Encabezado = "";
            this.grdDetalle.fColor = System.Drawing.Color.Silver;
            this.grdDetalle.FixCols = 0;
            this.grdDetalle.FixRows = 0;
            this.grdDetalle.Frozen = 0;
            this.grdDetalle.FuenteEncabezado = null;
            this.grdDetalle.FuentePieDePagina = null;
            this.grdDetalle.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalle.LimpiarEstilosAntesDeOrdenar = false;
            this.grdDetalle.Location = new System.Drawing.Point(4, 26);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalle.PintarFilaSel = true;
            this.grdDetalle.Redraw = true;
            this.grdDetalle.Row = 0;
            this.grdDetalle.Rows = 50;
            this.grdDetalle.Size = new System.Drawing.Size(543, 100);
            this.grdDetalle.TabIndex = 5;
            this.grdDetalle.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdDetalle_Editado);
            this.grdDetalle.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdDetalle_KeyUp);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Detalle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.grdAgregados);
            this.splitContainer1.Panel1.Controls.Add(this.lblTAgregados);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.grdPagos);
            this.splitContainer1.Panel2.Controls.Add(this.lblTPagos);
            this.splitContainer1.Size = new System.Drawing.Size(550, 576);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(550, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Agregados";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdAgregados
            // 
            this.grdAgregados.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdAgregados.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdAgregados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAgregados.AutoResize = false;
            this.grdAgregados.bColor = System.Drawing.SystemColors.Window;
            this.grdAgregados.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdAgregados.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdAgregados.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdAgregados.Col = -2;
            this.grdAgregados.Cols = 0;
            this.grdAgregados.DataMember = "";
            this.grdAgregados.DataSource = null;
            this.grdAgregados.EnableEdicion = true;
            this.grdAgregados.Encabezado = "";
            this.grdAgregados.fColor = System.Drawing.Color.Silver;
            this.grdAgregados.FixCols = 0;
            this.grdAgregados.FixRows = 0;
            this.grdAgregados.Frozen = 0;
            this.grdAgregados.FuenteEncabezado = null;
            this.grdAgregados.FuentePieDePagina = null;
            this.grdAgregados.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdAgregados.LimpiarEstilosAntesDeOrdenar = false;
            this.grdAgregados.Location = new System.Drawing.Point(4, 26);
            this.grdAgregados.Name = "grdAgregados";
            this.grdAgregados.PieDePagina = "\t\tPage {0} of {1}";
            this.grdAgregados.PintarFilaSel = true;
            this.grdAgregados.Redraw = true;
            this.grdAgregados.Row = 0;
            this.grdAgregados.Rows = 50;
            this.grdAgregados.Size = new System.Drawing.Size(543, 236);
            this.grdAgregados.TabIndex = 8;
            this.grdAgregados.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdAgregados_Editado);
            this.grdAgregados.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdAgregados_KeyUp);
            // 
            // lblTAgregados
            // 
            this.lblTAgregados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTAgregados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAgregados.Location = new System.Drawing.Point(0, 265);
            this.lblTAgregados.Name = "lblTAgregados";
            this.lblTAgregados.Size = new System.Drawing.Size(550, 23);
            this.lblTAgregados.TabIndex = 7;
            this.lblTAgregados.Text = "Totales";
            this.lblTAgregados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(550, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pagos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPagos
            // 
            this.grdPagos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdPagos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPagos.AutoResize = false;
            this.grdPagos.bColor = System.Drawing.SystemColors.Window;
            this.grdPagos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdPagos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdPagos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdPagos.Col = -2;
            this.grdPagos.Cols = 0;
            this.grdPagos.DataMember = "";
            this.grdPagos.DataSource = null;
            this.grdPagos.EnableEdicion = true;
            this.grdPagos.Encabezado = "";
            this.grdPagos.fColor = System.Drawing.Color.Silver;
            this.grdPagos.FixCols = 0;
            this.grdPagos.FixRows = 0;
            this.grdPagos.Frozen = 0;
            this.grdPagos.FuenteEncabezado = null;
            this.grdPagos.FuentePieDePagina = null;
            this.grdPagos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdPagos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdPagos.Location = new System.Drawing.Point(3, 26);
            this.grdPagos.Name = "grdPagos";
            this.grdPagos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdPagos.PintarFilaSel = true;
            this.grdPagos.Redraw = true;
            this.grdPagos.Row = 0;
            this.grdPagos.Rows = 50;
            this.grdPagos.Size = new System.Drawing.Size(544, 226);
            this.grdPagos.TabIndex = 10;
            // 
            // lblTPagos
            // 
            this.lblTPagos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPagos.Location = new System.Drawing.Point(0, 259);
            this.lblTPagos.Name = "lblTPagos";
            this.lblTPagos.Size = new System.Drawing.Size(550, 23);
            this.lblTPagos.TabIndex = 9;
            this.lblTPagos.Text = "Totales";
            this.lblTPagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmComprasHaciendaTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 734);
            this.Controls.Add(this.splitContainer3);
            this.Name = "frmComprasHaciendaTM";
            this.Text = "Compras";
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Grilla2.SpeedGrilla grdFacturas;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button cmdNueva;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTDetalle;
        private Grilla2.SpeedGrilla grdDetalle;
        private System.Windows.Forms.Label label2;
        private Grilla2.SpeedGrilla grdAgregados;
        private System.Windows.Forms.Label lblTAgregados;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Grilla2.SpeedGrilla grdPagos;
        private System.Windows.Forms.Label lblTPagos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstConsignatarios;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}