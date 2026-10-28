namespace Programa1.Carga.Tesoreria
{
    partial class frmConvertirPdf
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
            this.cmdConvertir = new System.Windows.Forms.Button();
            this.cmdCargar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdConvertir
            // 
            this.cmdConvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdConvertir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdConvertir.Location = new System.Drawing.Point(1238, 683);
            this.cmdConvertir.Name = "cmdConvertir";
            this.cmdConvertir.Size = new System.Drawing.Size(75, 23);
            this.cmdConvertir.TabIndex = 0;
            this.cmdConvertir.Text = "Convertir";
            this.cmdConvertir.UseVisualStyleBackColor = true;
            this.cmdConvertir.Click += new System.EventHandler(this.cmdConvertir_Click);
            // 
            // cmdCargar
            // 
            this.cmdCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCargar.Location = new System.Drawing.Point(1157, 683);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(75, 23);
            this.cmdCargar.TabIndex = 0;
            this.cmdCargar.Text = "Cargar";
            this.cmdCargar.UseVisualStyleBackColor = true;
            // 
            // frmConvertirPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 718);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.cmdConvertir);
            this.Name = "frmConvertirPdf";
            this.Text = "Convertir Pdf";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConvertir;
        private System.Windows.Forms.Button cmdCargar;
    }
}