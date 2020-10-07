namespace Programa1.Carga.Precios
{
    partial class frmBorrar_Carne
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
            this.cmdBorrar = new Programa1.Controles.cBoton();
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
            this.lstListas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstListas.Size = new System.Drawing.Size(192, 580);
            this.lstListas.TabIndex = 0;
            this.lstListas.SelectedIndexChanged += new System.EventHandler(this.lstListas_SelectedIndexChanged);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBorrar.BackColor = System.Drawing.Color.LightSalmon;
            this.cmdBorrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmdBorrar.Location = new System.Drawing.Point(334, 601);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(192, 40);
            this.cmdBorrar.TabIndex = 1;
            this.cmdBorrar.Texto = "Borrar";
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // frmBorrar_Carne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 653);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.lstListas);
            this.Controls.Add(this.lstSucursales);
            this.Name = "frmBorrar_Carne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrar Listas";
            this.Load += new System.EventHandler(this.frmBorrar_Carne_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstListas;
        private Controles.cBoton cmdBorrar;
        public System.Windows.Forms.ListBox lstSucursales;
    }
}