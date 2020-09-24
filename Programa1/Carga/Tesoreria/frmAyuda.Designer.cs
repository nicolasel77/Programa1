namespace Programa1.Carga.Tesoreria
{
    partial class frmAyuda
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
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lst = new System.Windows.Forms.ListBox();
            this.cmdCerrar = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Hint = "Buscar";
            this.txtBuscar.Location = new System.Drawing.Point(12, 12);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(427, 23);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.UseSystemPasswordChar = false;
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.ForeColor = System.Drawing.Color.DimGray;
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 16;
            this.lst.Location = new System.Drawing.Point(12, 41);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(427, 256);
            this.lst.TabIndex = 1;
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Depth = 0;
            this.cmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCerrar.Location = new System.Drawing.Point(0, 0);
            this.cmdCerrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCerrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Primary = false;
            this.cmdCerrar.Size = new System.Drawing.Size(141, 36);
            this.cmdCerrar.TabIndex = 0;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdCerrar);
            this.panel1.Location = new System.Drawing.Point(298, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 36);
            this.panel1.TabIndex = 3;
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCerrar;
            this.ClientSize = new System.Drawing.Size(451, 351);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.txtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAyuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.ListBox lst;
        private MaterialSkin.Controls.MaterialFlatButton cmdCerrar;
        private System.Windows.Forms.Panel panel1;
    }
}