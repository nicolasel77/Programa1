﻿namespace Programa1.Carga
{
    partial class frmReintegros
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCant = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdReintegros = new Grilla2.SpeedGrilla();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cSucs = new Programa1.Controles.cSucursales();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.cFecha = new Programa1.Controles.cFechas();
            this.tiMensaje = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.paMostrar = new System.Windows.Forms.Panel();
            this.cmdMostrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.paLimpiar = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new MaterialSkin.Controls.MaterialFlatButton();
            this.chNegativo = new MaterialSkin.Controls.MaterialCheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.paMostrar.SuspendLayout();
            this.paLimpiar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMensaje,
            this.lblCant,
            this.lblTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1332, 32);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMensaje
            // 
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 27);
            // 
            // lblCant
            // 
            this.lblCant.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(60, 27);
            this.lblCant.Text = "Cantidad";
            this.lblCant.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 27);
            this.lblTotal.Text = "Totales";
            this.lblTotal.Click += new System.EventHandler(this.LblCant_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grdReintegros);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1332, 631);
            this.splitContainer1.SplitterDistance = 812;
            this.splitContainer1.SplitterWidth = 9;
            this.splitContainer1.TabIndex = 1;
            // 
            // grdReintegros
            // 
            this.grdReintegros.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdReintegros.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdReintegros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReintegros.AutoResize = false;
            this.grdReintegros.bColor = System.Drawing.SystemColors.Window;
            this.grdReintegros.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdReintegros.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdReintegros.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdReintegros.Col = 0;
            this.grdReintegros.Cols = 10;
            this.grdReintegros.DataMember = "";
            this.grdReintegros.DataSource = null;
            this.grdReintegros.EnableEdicion = true;
            this.grdReintegros.Encabezado = "";
            this.grdReintegros.fColor = System.Drawing.SystemColors.Control;
            this.grdReintegros.FixCols = 0;
            this.grdReintegros.FixRows = 0;
            this.grdReintegros.Frozen = 0;
            this.grdReintegros.FuenteEncabezado = null;
            this.grdReintegros.FuentePieDePagina = null;
            this.grdReintegros.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdReintegros.LimpiarEstilosAntesDeOrdenar = true;
            this.grdReintegros.Location = new System.Drawing.Point(3, 7);
            this.grdReintegros.Name = "grdReintegros";
            this.grdReintegros.PieDePagina = "\t\tPage {0} of {1}";
            this.grdReintegros.PintarFilaSel = true;
            this.grdReintegros.Redraw = true;
            this.grdReintegros.Row = 0;
            this.grdReintegros.Rows = 50;
            this.grdReintegros.Size = new System.Drawing.Size(805, 620);
            this.grdReintegros.TabIndex = 0;
            this.grdReintegros.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.GrdReintegros_Editado);
            this.grdReintegros.CambioFila += new Grilla2.SpeedGrilla.CambioFilaEventHandler(this.GrdReintegros_CambioFila);
            this.grdReintegros.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.GrdReintegros_KeyUp);
            this.grdReintegros.SeleccionCambio += new Grilla2.SpeedGrilla.SeleccionCambioEventHandler(this.grdReintegros_SeleccionCambio);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cSucs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Panel2.Controls.Add(this.cFecha);
            this.splitContainer3.Size = new System.Drawing.Size(511, 631);
            this.splitContainer3.SplitterDistance = 288;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // cSucs
            // 
            this.cSucs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSucs.BackColor = System.Drawing.Color.Gainsboro;
            this.cSucs.Filtro_In = "";
            this.cSucs.Location = new System.Drawing.Point(3, 3);
            this.cSucs.Mostrar_Botones = true;
            this.cSucs.Mostrar_Tipo = true;
            this.cSucs.Name = "cSucs";
            this.cSucs.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.cSucs.Size = new System.Drawing.Size(281, 623);
            this.cSucs.TabIndex = 2;
            this.cSucs.Titulo = "Sucursales";
            this.cSucs.Valor_Actual = -1;
            this.cSucs.Cambio_Seleccion += new System.EventHandler(this.CSucs_Cambio_Seleccion);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 344);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lstTipo);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(202, 337);
            this.panel2.TabIndex = 5;
            // 
            // lstTipo
            // 
            this.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipo.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lstTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTipo.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.ItemHeight = 18;
            this.lstTipo.Location = new System.Drawing.Point(0, 0);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTipo.Size = new System.Drawing.Size(202, 337);
            this.lstTipo.TabIndex = 4;
            // 
            // cFecha
            // 
            this.cFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cFecha.Fecha_Maxima = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.cFecha.Location = new System.Drawing.Point(3, 354);
            this.cFecha.MinimumSize = new System.Drawing.Size(0, 212);
            this.cFecha.Mostrar = 0;
            this.cFecha.Mostrar_Solo = Programa1.Controles.cFechas.e_MostrarSolo.Todos;
            this.cFecha.Name = "cFecha";
            this.cFecha.Size = new System.Drawing.Size(209, 272);
            this.cFecha.TabIndex = 3;
            this.cFecha.Ultima_Fecha = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.cFecha.Cambio_Seleccion += new System.EventHandler(this.CFecha_Cambio_Seleccion);
            // 
            // tiMensaje
            // 
            this.tiMensaje.Enabled = true;
            this.tiMensaje.Interval = 8000;
            this.tiMensaje.Tick += new System.EventHandler(this.TiMensaje_Tick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chNegativo);
            this.panel3.Controls.Add(this.paMostrar);
            this.panel3.Controls.Add(this.paLimpiar);
            this.panel3.Location = new System.Drawing.Point(641, 632);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(691, 31);
            this.panel3.TabIndex = 8;
            // 
            // paMostrar
            // 
            this.paMostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paMostrar.Controls.Add(this.cmdMostrar);
            this.paMostrar.Location = new System.Drawing.Point(481, 2);
            this.paMostrar.Name = "paMostrar";
            this.paMostrar.Size = new System.Drawing.Size(206, 29);
            this.paMostrar.TabIndex = 5;
            // 
            // cmdMostrar
            // 
            this.cmdMostrar.AutoSize = true;
            this.cmdMostrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdMostrar.Depth = 0;
            this.cmdMostrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdMostrar.Location = new System.Drawing.Point(0, 0);
            this.cmdMostrar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdMostrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdMostrar.Name = "cmdMostrar";
            this.cmdMostrar.Primary = false;
            this.cmdMostrar.Size = new System.Drawing.Size(206, 29);
            this.cmdMostrar.TabIndex = 0;
            this.cmdMostrar.Text = "Mostrar";
            this.cmdMostrar.UseVisualStyleBackColor = true;
            this.cmdMostrar.Click += new System.EventHandler(this.CmdMostrar_Click);
            // 
            // paLimpiar
            // 
            this.paLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.paLimpiar.Controls.Add(this.cmdLimpiar);
            this.paLimpiar.Location = new System.Drawing.Point(266, 2);
            this.paLimpiar.Name = "paLimpiar";
            this.paLimpiar.Size = new System.Drawing.Size(206, 29);
            this.paLimpiar.TabIndex = 5;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.AutoSize = true;
            this.cmdLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdLimpiar.Depth = 0;
            this.cmdLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdLimpiar.Location = new System.Drawing.Point(0, 0);
            this.cmdLimpiar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.cmdLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Primary = false;
            this.cmdLimpiar.Size = new System.Drawing.Size(206, 29);
            this.cmdLimpiar.TabIndex = 0;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = true;
            this.cmdLimpiar.Click += new System.EventHandler(this.CmdLimpiar_Click);
            // 
            // chNegativo
            // 
            this.chNegativo.AutoSize = true;
            this.chNegativo.Depth = 0;
            this.chNegativo.Font = new System.Drawing.Font("Roboto", 10F);
            this.chNegativo.Location = new System.Drawing.Point(115, 3);
            this.chNegativo.Margin = new System.Windows.Forms.Padding(0);
            this.chNegativo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chNegativo.MouseState = MaterialSkin.MouseState.HOVER;
            this.chNegativo.Name = "chNegativo";
            this.chNegativo.Ripple = true;
            this.chNegativo.Size = new System.Drawing.Size(146, 30);
            this.chNegativo.TabIndex = 6;
            this.chNegativo.Text = "Cargar en negativo";
            this.chNegativo.UseVisualStyleBackColor = true;
            // 
            // frmReintegros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 663);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmReintegros";
            this.Text = "Reintegros";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmReintegros_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.paMostrar.ResumeLayout(false);
            this.paMostrar.PerformLayout();
            this.paLimpiar.ResumeLayout(false);
            this.paLimpiar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grdReintegros;
        private System.Windows.Forms.Timer tiMensaje;
        private System.Windows.Forms.ToolStripStatusLabel lblMensaje;
        private Controles.cSucursales cSucs;
        private Controles.cFechas cFecha;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblCant;
        private System.Windows.Forms.ListBox lstTipo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel paMostrar;
        private MaterialSkin.Controls.MaterialFlatButton cmdMostrar;
        private System.Windows.Forms.Panel paLimpiar;
        private MaterialSkin.Controls.MaterialFlatButton cmdLimpiar;
        private MaterialSkin.Controls.MaterialCheckBox chNegativo;
    }
}