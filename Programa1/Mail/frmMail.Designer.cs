namespace Programa1.Mail
{
    partial class frmMail
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
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tiMail = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdActualizar.Location = new System.Drawing.Point(713, 415);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(75, 23);
            this.cmdActualizar.TabIndex = 0;
            this.cmdActualizar.Text = "Actualizar";
            this.cmdActualizar.UseVisualStyleBackColor = true;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 403);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // tiMail
            // 
            this.tiMail.Enabled = true;
            this.tiMail.Interval = 60000;
            this.tiMail.Tick += new System.EventHandler(this.tiMail_Tick);
            // 
            // frmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdActualizar);
            this.Name = "frmMail";
            this.Text = "Mail";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdActualizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tiMail;
    }
}