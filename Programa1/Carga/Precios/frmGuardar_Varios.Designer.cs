namespace Programa1.Carga.Precios
{
    partial class frmGuardar_Varios
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
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.cmdGuardar = new Programa1.Controles.cBoton();
            this.cmdTodas = new System.Windows.Forms.Button();
            this.cmdNinguna = new System.Windows.Forms.Button();
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
            // mntFecha
            // 
            this.mntFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mntFecha.Location = new System.Drawing.Point(334, 12);
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 2;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.Location = new System.Drawing.Point(334, 601);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(192, 40);
            this.cmdGuardar.TabIndex = 1;
            this.cmdGuardar.Texto = "Guardar";
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdTodas
            // 
            this.cmdTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTodas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTodas.Location = new System.Drawing.Point(334, 186);
            this.cmdTodas.Name = "cmdTodas";
            this.cmdTodas.Size = new System.Drawing.Size(192, 23);
            this.cmdTodas.TabIndex = 3;
            this.cmdTodas.Text = "Todas";
            this.cmdTodas.UseVisualStyleBackColor = true;
            this.cmdTodas.Click += new System.EventHandler(this.cmdTodas_Click);
            // 
            // cmdNinguna
            // 
            this.cmdNinguna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNinguna.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNinguna.Location = new System.Drawing.Point(334, 215);
            this.cmdNinguna.Name = "cmdNinguna";
            this.cmdNinguna.Size = new System.Drawing.Size(192, 23);
            this.cmdNinguna.TabIndex = 3;
            this.cmdNinguna.Text = "Ninguna";
            this.cmdNinguna.UseVisualStyleBackColor = true;
            this.cmdNinguna.Click += new System.EventHandler(this.cmdNinguna_Click);
            // 
            // frmGuardar_Varios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 653);
            this.Controls.Add(this.cmdNinguna);
            this.Controls.Add(this.cmdTodas);
            this.Controls.Add(this.mntFecha);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.lstSucursales);
            this.Name = "frmGuardar_Varios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar Precios";
            this.ResumeLayout(false);

        }

        #endregion
        private Controles.cBoton cmdGuardar;
        public System.Windows.Forms.ListBox lstSucursales;
        public System.Windows.Forms.MonthCalendar mntFecha;
        private System.Windows.Forms.Button cmdTodas;
        private System.Windows.Forms.Button cmdNinguna;
    }
}