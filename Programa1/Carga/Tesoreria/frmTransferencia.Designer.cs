
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
            this.lstDesde = new System.Windows.Forms.ListBox();
            this.lstHacia = new System.Windows.Forms.ListBox();
            this.cmdAcpetar = new Programa1.Controles.cBoton();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lstARendir = new System.Windows.Forms.ListBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
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
            this.materialLabel2.Location = new System.Drawing.Point(243, 7);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(48, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Hacia";
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
            this.lstDesde.Size = new System.Drawing.Size(162, 360);
            this.lstDesde.TabIndex = 0;
            // 
            // lstHacia
            // 
            this.lstHacia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstHacia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHacia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstHacia.FormattingEnabled = true;
            this.lstHacia.ItemHeight = 20;
            this.lstHacia.Location = new System.Drawing.Point(195, 29);
            this.lstHacia.Name = "lstHacia";
            this.lstHacia.Size = new System.Drawing.Size(162, 360);
            this.lstHacia.TabIndex = 1;
            this.lstHacia.SelectedIndexChanged += new System.EventHandler(this.lstHacia_SelectedIndexChanged);
            // 
            // cmdAcpetar
            // 
            this.cmdAcpetar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAcpetar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmdAcpetar.Location = new System.Drawing.Point(378, 411);
            this.cmdAcpetar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmdAcpetar.Name = "cmdAcpetar";
            this.cmdAcpetar.Size = new System.Drawing.Size(76, 27);
            this.cmdAcpetar.TabIndex = 3;
            this.cmdAcpetar.Texto = "Aceptar";
            this.cmdAcpetar.Click += new System.EventHandler(this.cmdAcpetar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(464, 411);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(76, 27);
            this.cmdCancelar.TabIndex = 4;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // txtImporte
            // 
            this.txtImporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtImporte.Location = new System.Drawing.Point(12, 422);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(345, 16);
            this.txtImporte.TabIndex = 5;
            this.txtImporte.TextChanged += new System.EventHandler(this.txtImporte_TextChanged);
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // lstARendir
            // 
            this.lstARendir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstARendir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstARendir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstARendir.Enabled = false;
            this.lstARendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstARendir.FormattingEnabled = true;
            this.lstARendir.ItemHeight = 20;
            this.lstARendir.Location = new System.Drawing.Point(378, 29);
            this.lstARendir.Name = "lstARendir";
            this.lstARendir.Size = new System.Drawing.Size(162, 360);
            this.lstARendir.TabIndex = 6;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(426, 7);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(65, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "A Rendir";
            // 
            // frmTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 450);
            this.Controls.Add(this.lstARendir);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAcpetar);
            this.Controls.Add(this.lstHacia);
            this.Controls.Add(this.lstDesde);
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
        private Controles.cBoton cmdAcpetar;
        private Controles.cBoton cmdCancelar;
        public System.Windows.Forms.ListBox lstDesde;
        public System.Windows.Forms.ListBox lstHacia;
        public System.Windows.Forms.TextBox txtImporte;
        public System.Windows.Forms.ListBox lstARendir;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}