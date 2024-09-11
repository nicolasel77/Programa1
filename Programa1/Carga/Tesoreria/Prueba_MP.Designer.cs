namespace Programa1.Carga.Tesoreria
{
    partial class Prueba_MP
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
            this.cmdCargar = new MaterialSkin.Controls.MaterialFlatButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdCargar
            // 
            this.cmdCargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCargar.AutoSize = true;
            this.cmdCargar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCargar.Depth = 0;
            this.cmdCargar.Location = new System.Drawing.Point(677, 399);
            this.cmdCargar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCargar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Primary = false;
            this.cmdCargar.Size = new System.Drawing.Size(110, 36);
            this.cmdCargar.TabIndex = 1;
            this.cmdCargar.Text = "Traer Ventas";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Click += new System.EventHandler(this.cmdCargar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(775, 378);
            this.textBox1.TabIndex = 2;
            // 
            // Prueba_MP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmdCargar);
            this.Name = "Prueba_MP";
            this.Text = "Prueba_MP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton cmdCargar;
        private System.Windows.Forms.TextBox textBox1;
    }
}