﻿namespace Programa1.Carga.Hacienda
{

    partial class frmValores_Recupero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValores_Recupero));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.lstFechas = new System.Windows.Forms.ListBox();
            this.lstFrigorificos = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.cmdGuardar);
            this.splitContainer1.Panel2.Controls.Add(this.mntFecha);
            this.splitContainer1.Panel2.Controls.Add(this.lstFechas);
            this.splitContainer1.Panel2.Controls.Add(this.lstFrigorificos);
            this.splitContainer1.Size = new System.Drawing.Size(923, 584);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 0;
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
            this.grd.Col = -2;
            this.grd.Cols = 0;
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
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(428, 560);
            this.grd.TabIndex = 0;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            this.grd.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grd_KeyUp);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Location = new System.Drawing.Point(16, 478);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(192, 40);
            this.cmdGuardar.TabIndex = 2;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // mntFecha
            // 
            this.mntFecha.Location = new System.Drawing.Point(16, 304);
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.ShowToday = false;
            this.mntFecha.TabIndex = 1;
            // 
            // lstFechas
            // 
            this.lstFechas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFechas.FormattingEnabled = true;
            this.lstFechas.ItemHeight = 20;
            this.lstFechas.Location = new System.Drawing.Point(231, 12);
            this.lstFechas.Name = "lstFechas";
            this.lstFechas.Size = new System.Drawing.Size(129, 280);
            this.lstFechas.TabIndex = 0;
            this.lstFechas.SelectedIndexChanged += new System.EventHandler(this.lstFechas_SelectedIndexChanged);
            // 
            // lstFrigorificos
            // 
            this.lstFrigorificos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFrigorificos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFrigorificos.FormattingEnabled = true;
            this.lstFrigorificos.ItemHeight = 20;
            this.lstFrigorificos.Location = new System.Drawing.Point(16, 12);
            this.lstFrigorificos.Name = "lstFrigorificos";
            this.lstFrigorificos.Size = new System.Drawing.Size(209, 280);
            this.lstFrigorificos.TabIndex = 0;
            this.lstFrigorificos.SelectedIndexChanged += new System.EventHandler(this.lstFrigorificos_SelectedIndexChanged);
            // 
            // frmValores_Recupero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 584);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmValores_Recupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valores Recupero";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.ListBox lstFechas;
        private System.Windows.Forms.ListBox lstFrigorificos;
        private Controles.cBoton cmdGuardar;
        private System.Windows.Forms.MonthCalendar mntFecha;
    }
}