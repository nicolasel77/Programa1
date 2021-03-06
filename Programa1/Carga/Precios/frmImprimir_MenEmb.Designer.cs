﻿namespace Programa1.Carga.Precios
{
    partial class frmImprimir_MenEmb
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
            this.lstSucursales = new System.Windows.Forms.ListBox();
            this.lstListas = new System.Windows.Forms.ListBox();
            this.chUltima = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdImprimir = new Programa1.Controles.cBoton();
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // lstSucursales
            // 
            this.lstSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSucursales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSucursales.FormattingEnabled = true;
            this.lstSucursales.ItemHeight = 16;
            this.lstSucursales.Location = new System.Drawing.Point(12, 12);
            this.lstSucursales.Name = "lstSucursales";
            this.lstSucursales.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstSucursales.Size = new System.Drawing.Size(310, 624);
            this.lstSucursales.TabIndex = 0;
            // 
            // lstListas
            // 
            this.lstListas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstListas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstListas.FormattingEnabled = true;
            this.lstListas.ItemHeight = 20;
            this.lstListas.Location = new System.Drawing.Point(334, 12);
            this.lstListas.Name = "lstListas";
            this.lstListas.Size = new System.Drawing.Size(192, 360);
            this.lstListas.TabIndex = 0;
            this.lstListas.SelectedIndexChanged += new System.EventHandler(this.lstListas_SelectedIndexChanged);
            // 
            // chUltima
            // 
            this.chUltima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chUltima.AutoSize = true;
            this.chUltima.Depth = 0;
            this.chUltima.Font = new System.Drawing.Font("Roboto", 10F);
            this.chUltima.Location = new System.Drawing.Point(334, 388);
            this.chUltima.Margin = new System.Windows.Forms.Padding(0);
            this.chUltima.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chUltima.MouseState = MaterialSkin.MouseState.HOVER;
            this.chUltima.Name = "chUltima";
            this.chUltima.Ripple = true;
            this.chUltima.Size = new System.Drawing.Size(99, 30);
            this.chUltima.TabIndex = 3;
            this.chUltima.Text = "Última lista";
            this.chUltima.UseVisualStyleBackColor = true;
            this.chUltima.CheckedChanged += new System.EventHandler(this.chUltima_CheckedChanged);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdImprimir.Location = new System.Drawing.Point(334, 601);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(192, 40);
            this.cmdImprimir.TabIndex = 1;
            this.cmdImprimir.Texto = "Imprimir";
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // mntFecha
            // 
            this.mntFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mntFecha.Location = new System.Drawing.Point(334, 427);
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 4;
            // 
            // frmImprimir_MenEmb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 653);
            this.Controls.Add(this.mntFecha);
            this.Controls.Add(this.chUltima);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.lstListas);
            this.Controls.Add(this.lstSucursales);
            this.Name = "frmImprimir_MenEmb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.frmImprimir_MenEmb_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstListas;
        private Controles.cBoton cmdImprimir;
        public System.Windows.Forms.ListBox lstSucursales;
        private MaterialSkin.Controls.MaterialCheckBox chUltima;
        private System.Windows.Forms.MonthCalendar mntFecha;
    }
}