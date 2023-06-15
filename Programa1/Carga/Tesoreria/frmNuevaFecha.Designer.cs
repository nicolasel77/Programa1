
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
            this.nuAño = new System.Windows.Forms.NumericUpDown();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.cmdCancelar = new Programa1.Controles.cBoton();
            ((System.ComponentModel.ISupportInitialize)(this.nuAño)).BeginInit();
            this.SuspendLayout();
            // 
            // mntFecha
            // 
            this.mntFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mntFecha.CalendarDimensions = new System.Drawing.Size(2, 1);
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
            this.materialLabel1.Location = new System.Drawing.Point(15, 9);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(183, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Seleccione la nueva fecha";
            // 
            // nuAño
            // 
            this.nuAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nuAño.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nuAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuAño.Location = new System.Drawing.Point(18, 219);
            this.nuAño.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nuAño.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.nuAño.Name = "nuAño";
            this.nuAño.Size = new System.Drawing.Size(78, 22);
            this.nuAño.TabIndex = 3;
            this.nuAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nuAño.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.nuAño.ValueChanged += new System.EventHandler(this.nuAño_ValueChanged);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(309, 210);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(86, 40);
            this.cmdAceptar.TabIndex = 2;
            this.cmdAceptar.Texto = "Aceptar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(415, 210);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(86, 40);
            this.cmdCancelar.TabIndex = 2;
            this.cmdCancelar.Texto = "Cancelar";
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // frmNuevaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 265);
            this.Controls.Add(this.nuAño);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.mntFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNuevaFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Fecha";
            ((System.ComponentModel.ISupportInitialize)(this.nuAño)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Controles.cBoton cmdCancelar;
        private Controles.cBoton cmdAceptar;
        public System.Windows.Forms.MonthCalendar mntFecha;
        private System.Windows.Forms.NumericUpDown nuAño;
    }
}