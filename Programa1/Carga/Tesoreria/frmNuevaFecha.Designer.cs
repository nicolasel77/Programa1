
namespace Programa1.Carga.Tesoreria
{
    partial class frmNuevaFecha
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
            this.mntFecha = new System.Windows.Forms.MonthCalendar();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.SuspendLayout();
            // 
            // mntFecha
            // 
            this.mntFecha.Location = new System.Drawing.Point(18, 36);
            this.mntFecha.MaxSelectionCount = 1;
            this.mntFecha.Name = "mntFecha";
            this.mntFecha.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(8, 8);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(183, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Seleccione la nueva fecha";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(124, 210);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(86, 40);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Location = new System.Drawing.Point(18, 210);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(86, 40);
            this.cmdAceptar.TabIndex = 2;
            this.cmdAceptar.Texto = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // frmNuevaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 265);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.mntFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNuevaFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Fecha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Controles.cBoton cmdCancelar;
        private Controles.cBoton cmdAceptar;
        public System.Windows.Forms.MonthCalendar mntFecha;
    }
}