namespace Programa1.Carga.Hacienda
{
    partial class frmGuardarReparto
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
            this.mHasta = new System.Windows.Forms.DateTimePicker();
            this.mDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdSincSalidas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mHasta
            // 
            this.mHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mHasta.Location = new System.Drawing.Point(81, 38);
            this.mHasta.Name = "mHasta";
            this.mHasta.Size = new System.Drawing.Size(97, 20);
            this.mHasta.TabIndex = 7;
            // 
            // mDesde
            // 
            this.mDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mDesde.Location = new System.Drawing.Point(81, 9);
            this.mDesde.Name = "mDesde";
            this.mDesde.Size = new System.Drawing.Size(97, 20);
            this.mDesde.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(12, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Desde";
            // 
            // cmdSincSalidas
            // 
            this.cmdSincSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSincSalidas.Location = new System.Drawing.Point(16, 80);
            this.cmdSincSalidas.Name = "cmdSincSalidas";
            this.cmdSincSalidas.Size = new System.Drawing.Size(167, 28);
            this.cmdSincSalidas.TabIndex = 8;
            this.cmdSincSalidas.Text = "Sincronizar Salidas";
            this.cmdSincSalidas.UseVisualStyleBackColor = true;
            this.cmdSincSalidas.Click += new System.EventHandler(this.cmdSincSalidas_Click);
            // 
            // frmGuardarReparto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 121);
            this.Controls.Add(this.mHasta);
            this.Controls.Add(this.mDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdSincSalidas);
            this.Name = "frmGuardarReparto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar Reparto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker mHasta;
        private System.Windows.Forms.DateTimePicker mDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdSincSalidas;
    }
}