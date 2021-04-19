
namespace Programa1.Carga.Tesoreria
{
    partial class frmNARendir
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
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.lst = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(56, 284);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(99, 40);
            this.cmdAceptar.TabIndex = 0;
            this.cmdAceptar.Texto = "Aceptar";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(161, 280);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(99, 40);
            this.cmdCancelar.TabIndex = 1;
            this.cmdCancelar.Texto = "Cancelar";
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 24;
            this.lst.Location = new System.Drawing.Point(12, 12);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(248, 264);
            this.lst.TabIndex = 2;
            // 
            // frmNARendir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 332);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNARendir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar";
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.cBoton cmdAceptar;
        private Controles.cBoton cmdCancelar;
        private System.Windows.Forms.ListBox lst;
    }
}