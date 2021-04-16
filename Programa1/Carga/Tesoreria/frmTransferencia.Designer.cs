
namespace Programa1.Carga.Tesoreria
{
    partial class frmTransferencia
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtImporte = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lstDesde = new System.Windows.Forms.ListBox();
            this.lstHacia = new System.Windows.Forms.ListBox();
            this.cmdAcpetar = new Programa1.Controles.cBoton();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(57, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(51, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Desde";
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(243, 9);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(48, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Hacia";
            // 
            // txtImporte
            // 
            this.txtImporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporte.Depth = 0;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtImporte.ForeColor = System.Drawing.Color.White;
            this.txtImporte.Hint = "Importe";
            this.txtImporte.Location = new System.Drawing.Point(16, 415);
            this.txtImporte.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.PasswordChar = '\0';
            this.txtImporte.SelectedText = "";
            this.txtImporte.SelectionLength = 0;
            this.txtImporte.SelectionStart = 0;
            this.txtImporte.Size = new System.Drawing.Size(158, 23);
            this.txtImporte.TabIndex = 2;
            this.txtImporte.Text = "Importe";
            this.txtImporte.UseSystemPasswordChar = false;
            this.txtImporte.Enter += new System.EventHandler(this.txtImporte_Enter);
            // 
            // lstDesde
            // 
            this.lstDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstDesde.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstDesde.FormattingEnabled = true;
            this.lstDesde.ItemHeight = 20;
            this.lstDesde.Location = new System.Drawing.Point(12, 31);
            this.lstDesde.Name = "lstDesde";
            this.lstDesde.Size = new System.Drawing.Size(162, 380);
            this.lstDesde.TabIndex = 0;
            // 
            // lstHacia
            // 
            this.lstHacia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHacia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHacia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstHacia.FormattingEnabled = true;
            this.lstHacia.ItemHeight = 20;
            this.lstHacia.Location = new System.Drawing.Point(195, 29);
            this.lstHacia.Name = "lstHacia";
            this.lstHacia.Size = new System.Drawing.Size(162, 380);
            this.lstHacia.TabIndex = 1;
            // 
            // cmdAcpetar
            // 
            this.cmdAcpetar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAcpetar.Location = new System.Drawing.Point(195, 422);
            this.cmdAcpetar.Name = "cmdAcpetar";
            this.cmdAcpetar.Size = new System.Drawing.Size(76, 16);
            this.cmdAcpetar.TabIndex = 3;
            this.cmdAcpetar.Texto = "Aceptar";
            this.cmdAcpetar.Click += new System.EventHandler(this.cmdAcpetar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(281, 422);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(76, 16);
            this.cmdCancelar.TabIndex = 4;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 450);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAcpetar);
            this.Controls.Add(this.lstHacia);
            this.Controls.Add(this.lstDesde);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Name = "frmTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia";
            this.Load += new System.EventHandler(this.frmTransferencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtImporte;
        private System.Windows.Forms.ListBox lstDesde;
        private System.Windows.Forms.ListBox lstHacia;
        private Controles.cBoton cmdAcpetar;
        private Controles.cBoton cmdCancelar;
    }
}