namespace Programa1.Carga
{
    partial class frmSeleccionarFecha
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.lblFechaSeleccionada = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // monthCalendar1
            this.monthCalendar1.Location = new System.Drawing.Point(12, 12);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);

            // lblFechaSeleccionada
            this.lblFechaSeleccionada.AutoSize = true;
            this.lblFechaSeleccionada.Location = new System.Drawing.Point(12, 180);
            this.lblFechaSeleccionada.Name = "lblFechaSeleccionada";
            this.lblFechaSeleccionada.Size = new System.Drawing.Size(150, 13);
            this.lblFechaSeleccionada.TabIndex = 1;
            this.lblFechaSeleccionada.Text = $"Fecha seleccionada: ";

            // cmdActualizar
            this.cmdActualizar.Location = new System.Drawing.Point(60, 210);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(75, 23);
            this.cmdActualizar.TabIndex = 2;
            this.cmdActualizar.Text = "Actualizar";
            this.cmdActualizar.UseVisualStyleBackColor = true;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);

            // cmdCancelar
            this.cmdCancelar.Location = new System.Drawing.Point(141, 210);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelar.TabIndex = 3;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);

            // frmSeleccionarFecha
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 245);
            this.Controls.Add(this.cmdActualizar);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.lblFechaSeleccionada);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionarFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Fecha";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button cmdActualizar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Label lblFechaSeleccionada;
    }
}