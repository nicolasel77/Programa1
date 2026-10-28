namespace Programa1.Carga.TM
{
    partial class frmEditarTiposTM
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdGrupos = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.grdTipos = new Grilla2.SpeedGrilla();
            this.lblSTipo = new System.Windows.Forms.Label();
            this.grdSubTipos = new Grilla2.SpeedGrilla();
            this.label4 = new System.Windows.Forms.Label();
            this.grdDetalles = new Grilla2.SpeedGrilla();
            this.label5 = new System.Windows.Forms.Label();
            this.grdCajas = new Grilla2.SpeedGrilla();
            this.cmdBorrarCaja = new System.Windows.Forms.Button();
            this.cmdBorrarDetalle = new System.Windows.Forms.Button();
            this.cmdBorrarSubTipo = new System.Windows.Forms.Button();
            this.cmdBorrarTipo = new System.Windows.Forms.Button();
            this.cmdBorrarGrupo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupos";
            // 
            // grdGrupos
            // 
            this.grdGrupos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdGrupos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdGrupos.AutoResize = false;
            this.grdGrupos.bColor = System.Drawing.SystemColors.Window;
            this.grdGrupos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdGrupos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdGrupos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdGrupos.Col = 0;
            this.grdGrupos.Cols = 10;
            this.grdGrupos.DataMember = "";
            this.grdGrupos.DataSource = null;
            this.grdGrupos.EnableEdicion = true;
            this.grdGrupos.Encabezado = "";
            this.grdGrupos.fColor = System.Drawing.Color.Silver;
            this.grdGrupos.FixCols = 0;
            this.grdGrupos.FixRows = 0;
            this.grdGrupos.Frozen = 0;
            this.grdGrupos.FuenteEncabezado = null;
            this.grdGrupos.FuentePieDePagina = null;
            this.grdGrupos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdGrupos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdGrupos.Location = new System.Drawing.Point(12, 32);
            this.grdGrupos.Name = "grdGrupos";
            this.grdGrupos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdGrupos.PintarFilaSel = true;
            this.grdGrupos.Redraw = true;
            this.grdGrupos.Row = 0;
            this.grdGrupos.Rows = 50;
            this.grdGrupos.Size = new System.Drawing.Size(371, 661);
            this.grdGrupos.TabIndex = 1;
            this.grdGrupos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdGrupos_Editado);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(389, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipos";
            // 
            // grdTipos
            // 
            this.grdTipos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdTipos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdTipos.AutoResize = false;
            this.grdTipos.bColor = System.Drawing.SystemColors.Window;
            this.grdTipos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdTipos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdTipos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdTipos.Col = 0;
            this.grdTipos.Cols = 10;
            this.grdTipos.DataMember = "";
            this.grdTipos.DataSource = null;
            this.grdTipos.EnableEdicion = true;
            this.grdTipos.Encabezado = "";
            this.grdTipos.fColor = System.Drawing.Color.Silver;
            this.grdTipos.FixCols = 0;
            this.grdTipos.FixRows = 0;
            this.grdTipos.Frozen = 0;
            this.grdTipos.FuenteEncabezado = null;
            this.grdTipos.FuentePieDePagina = null;
            this.grdTipos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdTipos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdTipos.Location = new System.Drawing.Point(389, 32);
            this.grdTipos.Name = "grdTipos";
            this.grdTipos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdTipos.PintarFilaSel = true;
            this.grdTipos.Redraw = true;
            this.grdTipos.Row = 0;
            this.grdTipos.Rows = 50;
            this.grdTipos.Size = new System.Drawing.Size(371, 661);
            this.grdTipos.TabIndex = 1;
            this.grdTipos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdTipos_Editado);
            this.grdTipos.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.grdTipos_CambioFila);
            // 
            // lblSTipo
            // 
            this.lblSTipo.AutoSize = true;
            this.lblSTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTipo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSTipo.Location = new System.Drawing.Point(765, 9);
            this.lblSTipo.Name = "lblSTipo";
            this.lblSTipo.Size = new System.Drawing.Size(76, 20);
            this.lblSTipo.TabIndex = 0;
            this.lblSTipo.Text = "SubTipos";
            // 
            // grdSubTipos
            // 
            this.grdSubTipos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdSubTipos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdSubTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdSubTipos.AutoResize = false;
            this.grdSubTipos.bColor = System.Drawing.SystemColors.Window;
            this.grdSubTipos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdSubTipos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdSubTipos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdSubTipos.Col = 0;
            this.grdSubTipos.Cols = 10;
            this.grdSubTipos.DataMember = "";
            this.grdSubTipos.DataSource = null;
            this.grdSubTipos.EnableEdicion = true;
            this.grdSubTipos.Encabezado = "";
            this.grdSubTipos.fColor = System.Drawing.Color.Silver;
            this.grdSubTipos.FixCols = 0;
            this.grdSubTipos.FixRows = 0;
            this.grdSubTipos.Frozen = 0;
            this.grdSubTipos.FuenteEncabezado = null;
            this.grdSubTipos.FuentePieDePagina = null;
            this.grdSubTipos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdSubTipos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdSubTipos.Location = new System.Drawing.Point(765, 32);
            this.grdSubTipos.Name = "grdSubTipos";
            this.grdSubTipos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdSubTipos.PintarFilaSel = true;
            this.grdSubTipos.Redraw = true;
            this.grdSubTipos.Row = -2;
            this.grdSubTipos.Rows = 0;
            this.grdSubTipos.Size = new System.Drawing.Size(320, 661);
            this.grdSubTipos.TabIndex = 1;
            this.grdSubTipos.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdSubTipos_Editado);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(1090, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Detalles";
            // 
            // grdDetalles
            // 
            this.grdDetalles.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDetalles.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDetalles.AutoResize = false;
            this.grdDetalles.bColor = System.Drawing.SystemColors.Window;
            this.grdDetalles.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDetalles.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDetalles.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDetalles.Col = 0;
            this.grdDetalles.Cols = 10;
            this.grdDetalles.DataMember = "";
            this.grdDetalles.DataSource = null;
            this.grdDetalles.EnableEdicion = true;
            this.grdDetalles.Encabezado = "";
            this.grdDetalles.fColor = System.Drawing.Color.Silver;
            this.grdDetalles.FixCols = 0;
            this.grdDetalles.FixRows = 0;
            this.grdDetalles.Frozen = 0;
            this.grdDetalles.FuenteEncabezado = null;
            this.grdDetalles.FuentePieDePagina = null;
            this.grdDetalles.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDetalles.LimpiarEstilosAntesDeOrdenar = false;
            this.grdDetalles.Location = new System.Drawing.Point(1090, 32);
            this.grdDetalles.Name = "grdDetalles";
            this.grdDetalles.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDetalles.PintarFilaSel = true;
            this.grdDetalles.Redraw = true;
            this.grdDetalles.Row = -2;
            this.grdDetalles.Rows = 0;
            this.grdDetalles.Size = new System.Drawing.Size(316, 661);
            this.grdDetalles.TabIndex = 1;
            this.grdDetalles.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdDetalles_Editado);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(1412, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cajas";
            // 
            // grdCajas
            // 
            this.grdCajas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCajas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCajas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdCajas.AutoResize = false;
            this.grdCajas.bColor = System.Drawing.SystemColors.Window;
            this.grdCajas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCajas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCajas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCajas.Col = 0;
            this.grdCajas.Cols = 10;
            this.grdCajas.DataMember = "";
            this.grdCajas.DataSource = null;
            this.grdCajas.EnableEdicion = true;
            this.grdCajas.Encabezado = "";
            this.grdCajas.fColor = System.Drawing.Color.Silver;
            this.grdCajas.FixCols = 0;
            this.grdCajas.FixRows = 0;
            this.grdCajas.Frozen = 0;
            this.grdCajas.FuenteEncabezado = null;
            this.grdCajas.FuentePieDePagina = null;
            this.grdCajas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCajas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCajas.Location = new System.Drawing.Point(1412, 32);
            this.grdCajas.Name = "grdCajas";
            this.grdCajas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCajas.PintarFilaSel = true;
            this.grdCajas.Redraw = true;
            this.grdCajas.Row = -2;
            this.grdCajas.Rows = 0;
            this.grdCajas.Size = new System.Drawing.Size(337, 386);
            this.grdCajas.TabIndex = 1;
            this.grdCajas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdCajas_Editado);
            // 
            // cmdBorrarCaja
            // 
            this.cmdBorrarCaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrarCaja.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarCaja.Location = new System.Drawing.Point(1657, 424);
            this.cmdBorrarCaja.Name = "cmdBorrarCaja";
            this.cmdBorrarCaja.Size = new System.Drawing.Size(92, 28);
            this.cmdBorrarCaja.TabIndex = 2;
            this.cmdBorrarCaja.Text = "Borrar";
            this.cmdBorrarCaja.UseVisualStyleBackColor = false;
            this.cmdBorrarCaja.Click += new System.EventHandler(this.cmdBorrarCaja_Click);
            // 
            // cmdBorrarDetalle
            // 
            this.cmdBorrarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrarDetalle.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarDetalle.Location = new System.Drawing.Point(1314, 699);
            this.cmdBorrarDetalle.Name = "cmdBorrarDetalle";
            this.cmdBorrarDetalle.Size = new System.Drawing.Size(92, 28);
            this.cmdBorrarDetalle.TabIndex = 2;
            this.cmdBorrarDetalle.Text = "Borrar";
            this.cmdBorrarDetalle.UseVisualStyleBackColor = false;
            // 
            // cmdBorrarSubTipo
            // 
            this.cmdBorrarSubTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrarSubTipo.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrarSubTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarSubTipo.Location = new System.Drawing.Point(993, 699);
            this.cmdBorrarSubTipo.Name = "cmdBorrarSubTipo";
            this.cmdBorrarSubTipo.Size = new System.Drawing.Size(92, 28);
            this.cmdBorrarSubTipo.TabIndex = 2;
            this.cmdBorrarSubTipo.Text = "Borrar";
            this.cmdBorrarSubTipo.UseVisualStyleBackColor = false;
            this.cmdBorrarSubTipo.Visible = false;
            // 
            // cmdBorrarTipo
            // 
            this.cmdBorrarTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrarTipo.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrarTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarTipo.Location = new System.Drawing.Point(668, 699);
            this.cmdBorrarTipo.Name = "cmdBorrarTipo";
            this.cmdBorrarTipo.Size = new System.Drawing.Size(92, 28);
            this.cmdBorrarTipo.TabIndex = 2;
            this.cmdBorrarTipo.Text = "Borrar";
            this.cmdBorrarTipo.UseVisualStyleBackColor = false;
            this.cmdBorrarTipo.Visible = false;
            this.cmdBorrarTipo.Click += new System.EventHandler(this.cmdBorrarTipo_Click);
            // 
            // cmdBorrarGrupo
            // 
            this.cmdBorrarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdBorrarGrupo.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBorrarGrupo.Location = new System.Drawing.Point(291, 699);
            this.cmdBorrarGrupo.Name = "cmdBorrarGrupo";
            this.cmdBorrarGrupo.Size = new System.Drawing.Size(92, 28);
            this.cmdBorrarGrupo.TabIndex = 2;
            this.cmdBorrarGrupo.Text = "Borrar";
            this.cmdBorrarGrupo.UseVisualStyleBackColor = false;
            this.cmdBorrarGrupo.Visible = false;
            this.cmdBorrarGrupo.Click += new System.EventHandler(this.cmdBorrarGrupo_Click);
            // 
            // frmEditarTiposTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1770, 739);
            this.Controls.Add(this.cmdBorrarGrupo);
            this.Controls.Add(this.cmdBorrarTipo);
            this.Controls.Add(this.cmdBorrarSubTipo);
            this.Controls.Add(this.cmdBorrarDetalle);
            this.Controls.Add(this.cmdBorrarCaja);
            this.Controls.Add(this.grdCajas);
            this.Controls.Add(this.grdDetalles);
            this.Controls.Add(this.grdSubTipos);
            this.Controls.Add(this.grdTipos);
            this.Controls.Add(this.grdGrupos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEditarTiposTM";
            this.Text = "Editar Tipos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdGrupos;
        private System.Windows.Forms.Label label2;
        private Grilla2.SpeedGrilla grdTipos;
        private System.Windows.Forms.Label lblSTipo;
        private Grilla2.SpeedGrilla grdSubTipos;
        private System.Windows.Forms.Label label4;
        private Grilla2.SpeedGrilla grdDetalles;
        private System.Windows.Forms.Label label5;
        private Grilla2.SpeedGrilla grdCajas;
        private System.Windows.Forms.Button cmdBorrarCaja;
        private System.Windows.Forms.Button cmdBorrarDetalle;
        private System.Windows.Forms.Button cmdBorrarSubTipo;
        private System.Windows.Forms.Button cmdBorrarTipo;
        private System.Windows.Forms.Button cmdBorrarGrupo;
    }
}