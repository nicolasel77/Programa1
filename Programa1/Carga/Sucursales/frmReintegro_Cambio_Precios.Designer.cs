﻿namespace Programa1.Carga.Sucursales
{
    partial class frmReintegro_Cambio_Precios
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.mFecha = new System.Windows.Forms.MonthCalendar();
            this.nuSemanas = new System.Windows.Forms.NumericUpDown();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.Sucursales = new Programa1.Controles.cSucursales();
            this.Productos = new Programa1.Controles.cProductos();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuSemanas)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.grd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.nuSemanas);
            this.splitContainer1.Panel2.Controls.Add(this.cmdAceptar);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel2.Controls.Add(this.Sucursales);
            this.splitContainer1.Panel2.Controls.Add(this.Productos);
            this.splitContainer1.Panel2.Controls.Add(this.mFecha);
            this.splitContainer1.Size = new System.Drawing.Size(1379, 732);
            this.splitContainer1.SplitterDistance = 830;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
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
            this.grd.Size = new System.Drawing.Size(805, 717);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcion.Location = new System.Drawing.Point(9, 662);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(520, 19);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.Text = "Reintegros por cambio de precios";
            // 
            // mFecha
            // 
            this.mFecha.Location = new System.Drawing.Point(9, 40);
            this.mFecha.Name = "mFecha";
            this.mFecha.TabIndex = 0;
            this.mFecha.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mFecha_DateChanged);
            // 
            // nuSemanas
            // 
            this.nuSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuSemanas.ForeColor = System.Drawing.Color.DimGray;
            this.nuSemanas.Location = new System.Drawing.Point(162, 631);
            this.nuSemanas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuSemanas.Name = "nuSemanas";
            this.nuSemanas.Size = new System.Drawing.Size(37, 22);
            this.nuSemanas.TabIndex = 7;
            this.nuSemanas.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nuSemanas.ValueChanged += new System.EventHandler(this.nuSemanas_ValueChanged);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.cmdAceptar.Location = new System.Drawing.Point(9, 687);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(520, 40);
            this.cmdAceptar.TabIndex = 5;
            this.cmdAceptar.Texto = "Guardar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // Sucursales
            // 
            this.Sucursales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Sucursales.BackColor = System.Drawing.Color.Gainsboro;
            this.Sucursales.Filtro_In = "";
            this.Sucursales.Location = new System.Drawing.Point(9, 205);
            this.Sucursales.Mostrar_Botones = false;
            this.Sucursales.Mostrar_Tipo = false;
            this.Sucursales.Name = "Sucursales";
            this.Sucursales.selectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Sucursales.Size = new System.Drawing.Size(248, 420);
            this.Sucursales.TabIndex = 3;
            this.Sucursales.Titulo = "Sucursales";
            this.Sucursales.Valor_Actual = -1;
            // 
            // Productos
            // 
            this.Productos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Productos.BackColor = System.Drawing.Color.Gainsboro;
            this.Productos.Filtrar_Ver = true;
            this.Productos.Filtro_In = "";
            this.Productos.Location = new System.Drawing.Point(269, 12);
            this.Productos.Mostrar_Tipo = true;
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(260, 641);
            this.Productos.TabIndex = 2;
            this.Productos.Titulo = "Productos";
            this.Productos.Valor_Actual = -1;
            this.Productos.Cambio_Seleccion += new System.EventHandler(this.Productos_Cambio_Seleccion);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(5, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Semanas promedio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha";
            // 
            // frmReintegro_Cambio_Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 732);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmReintegro_Cambio_Precios";
            this.Text = "Reintegro_Cambio_Precios";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuSemanas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grd;
        private Controles.cBoton cmdAceptar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private Controles.cSucursales Sucursales;
        private Controles.cProductos Productos;
        private System.Windows.Forms.MonthCalendar mFecha;
        private System.Windows.Forms.NumericUpDown nuSemanas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}