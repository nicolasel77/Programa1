namespace Programa1.Controles
{
    partial class cBoton
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmd = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // cmd
            // 
            this.cmd.AutoSize = true;
            this.cmd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmd.Depth = 0;
            this.cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmd.Location = new System.Drawing.Point(0, 0);
            this.cmd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmd.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmd.Name = "cmd";
            this.cmd.Primary = false;
            this.cmd.Size = new System.Drawing.Size(220, 40);
            this.cmd.TabIndex = 0;
            this.cmd.Text = "Botonazo";
            this.cmd.UseVisualStyleBackColor = true;
            this.cmd.Click += new System.EventHandler(this.cmd_Click);
            // 
            // cBoton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmd);
            this.Name = "cBoton";
            this.Size = new System.Drawing.Size(220, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MaterialSkin.Controls.MaterialFlatButton cmd;
    }
}
