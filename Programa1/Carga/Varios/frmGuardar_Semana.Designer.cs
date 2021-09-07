namespace Programa1.Carga.Varios
{

    partial class frmGuardar_Semana
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
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.chSemana = new MaterialSkin.Controls.MaterialCheckBox();
            this.chVentaPorProducto = new MaterialSkin.Controls.MaterialCheckBox();
            this.chBloquear = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSemanas
            // 
            this.lstSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstSemanas.FormattingEnabled = true;
            this.lstSemanas.ItemHeight = 20;
            this.lstSemanas.Location = new System.Drawing.Point(12, 12);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSemanas.Size = new System.Drawing.Size(237, 340);
            this.lstSemanas.TabIndex = 0;
            this.lstSemanas.DoubleClick += new System.EventHandler(this.lstSemanas_DoubleClick);
            // 
            // chSemana
            // 
            this.chSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chSemana.AutoSize = true;
            this.chSemana.Checked = true;
            this.chSemana.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSemana.Depth = 0;
            this.chSemana.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSemana.Location = new System.Drawing.Point(12, 362);
            this.chSemana.Margin = new System.Windows.Forms.Padding(0);
            this.chSemana.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSemana.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSemana.Name = "chSemana";
            this.chSemana.Ripple = true;
            this.chSemana.Size = new System.Drawing.Size(79, 30);
            this.chSemana.TabIndex = 2;
            this.chSemana.Text = "Guardar";
            this.chSemana.UseVisualStyleBackColor = true;
            // 
            // chVentaPorProducto
            // 
            this.chVentaPorProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chVentaPorProducto.AutoSize = true;
            this.chVentaPorProducto.Checked = true;
            this.chVentaPorProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chVentaPorProducto.Depth = 0;
            this.chVentaPorProducto.Font = new System.Drawing.Font("Roboto", 10F);
            this.chVentaPorProducto.Location = new System.Drawing.Point(91, 362);
            this.chVentaPorProducto.Margin = new System.Windows.Forms.Padding(0);
            this.chVentaPorProducto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chVentaPorProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.chVentaPorProducto.Name = "chVentaPorProducto";
            this.chVentaPorProducto.Ripple = true;
            this.chVentaPorProducto.Size = new System.Drawing.Size(66, 30);
            this.chVentaPorProducto.TabIndex = 2;
            this.chVentaPorProducto.Text = "Venta";
            this.chVentaPorProducto.UseVisualStyleBackColor = true;
            // 
            // chBloquear
            // 
            this.chBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chBloquear.AutoSize = true;
            this.chBloquear.Depth = 0;
            this.chBloquear.Font = new System.Drawing.Font("Roboto", 10F);
            this.chBloquear.Location = new System.Drawing.Point(157, 362);
            this.chBloquear.Margin = new System.Windows.Forms.Padding(0);
            this.chBloquear.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chBloquear.MouseState = MaterialSkin.MouseState.HOVER;
            this.chBloquear.Name = "chBloquear";
            this.chBloquear.Ripple = true;
            this.chBloquear.Size = new System.Drawing.Size(85, 30);
            this.chBloquear.TabIndex = 2;
            this.chBloquear.Text = "Bloquear";
            this.chBloquear.UseVisualStyleBackColor = true;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGuardar.Location = new System.Drawing.Point(16, 395);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(233, 43);
            this.cmdGuardar.TabIndex = 3;
            this.cmdGuardar.Text = "Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // frmGuardar_Semana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 450);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.chBloquear);
            this.Controls.Add(this.chVentaPorProducto);
            this.Controls.Add(this.chSemana);
            this.Controls.Add(this.lstSemanas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmGuardar_Semana";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar Semana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSemanas;
        private MaterialSkin.Controls.MaterialCheckBox chSemana;
        private MaterialSkin.Controls.MaterialCheckBox chVentaPorProducto;
        private MaterialSkin.Controls.MaterialCheckBox chBloquear;
        private System.Windows.Forms.Button cmdGuardar;
    }
}