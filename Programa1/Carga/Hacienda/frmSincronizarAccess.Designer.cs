
namespace Programa1.Carga.Hacienda
{
    partial class frmSincronizarAccess
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
            this.cmdBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSincronizar = new System.Windows.Forms.Button();
            this.nuCant = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mDesde = new System.Windows.Forms.MonthCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.mHasta = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flBuscar = new System.Windows.Forms.OpenFileDialog();
            this.lstActualizacion = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstBoletas = new System.Windows.Forms.ListBox();
            this.chCompra = new MaterialSkin.Controls.MaterialCheckBox();
            this.chFaena = new MaterialSkin.Controls.MaterialCheckBox();
            this.mdSincSalidas = new System.Windows.Forms.Button();
            this.chSaldo = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdSaldos = new System.Windows.Forms.Button();
            this.chBoleta = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdAdelante = new System.Windows.Forms.Button();
            this.txtBoleta = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdBase
            // 
            this.cmdBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmdBase.Location = new System.Drawing.Point(150, 12);
            this.cmdBase.Name = "cmdBase";
            this.cmdBase.Size = new System.Drawing.Size(285, 45);
            this.cmdBase.TabIndex = 0;
            this.cmdBase.Text = "Base de datos";
            this.cmdBase.UseVisualStyleBackColor = false;
            this.cmdBase.Click += new System.EventHandler(this.cmdBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base de datos:";
            // 
            // cmdSincronizar
            // 
            this.cmdSincronizar.BackColor = System.Drawing.Color.MistyRose;
            this.cmdSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSincronizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmdSincronizar.Location = new System.Drawing.Point(16, 409);
            this.cmdSincronizar.Name = "cmdSincronizar";
            this.cmdSincronizar.Size = new System.Drawing.Size(419, 45);
            this.cmdSincronizar.TabIndex = 0;
            this.cmdSincronizar.Text = "Sincronizar";
            this.cmdSincronizar.UseVisualStyleBackColor = false;
            this.cmdSincronizar.Click += new System.EventHandler(this.cmdSincronizar_Click);
            // 
            // nuCant
            // 
            this.nuCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nuCant.Location = new System.Drawing.Point(171, 73);
            this.nuCant.Name = "nuCant";
            this.nuCant.Size = new System.Drawing.Size(48, 26);
            this.nuCant.TabIndex = 2;
            this.nuCant.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad de Boletas";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(11, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(397, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salidas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(67, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Desde";
            // 
            // mDesde
            // 
            this.mDesde.Location = new System.Drawing.Point(11, 63);
            this.mDesde.Name = "mDesde";
            this.mDesde.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(272, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hasta";
            // 
            // mHasta
            // 
            this.mHasta.Location = new System.Drawing.Point(216, 63);
            this.mHasta.Name = "mHasta";
            this.mHasta.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.mHasta);
            this.panel1.Controls.Add(this.mDesde);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 237);
            this.panel1.TabIndex = 4;
            // 
            // flBuscar
            // 
            this.flBuscar.DefaultExt = "accdb";
            this.flBuscar.FileName = "openFileDialog1";
            // 
            // lstActualizacion
            // 
            this.lstActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstActualizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstActualizacion.FormattingEnabled = true;
            this.lstActualizacion.ItemHeight = 20;
            this.lstActualizacion.Location = new System.Drawing.Point(453, 12);
            this.lstActualizacion.Name = "lstActualizacion";
            this.lstActualizacion.Size = new System.Drawing.Size(413, 640);
            this.lstActualizacion.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(12, 457);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Boletas";
            // 
            // lstBoletas
            // 
            this.lstBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoletas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoletas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstBoletas.FormattingEnabled = true;
            this.lstBoletas.ItemHeight = 20;
            this.lstBoletas.Location = new System.Drawing.Point(16, 480);
            this.lstBoletas.Name = "lstBoletas";
            this.lstBoletas.Size = new System.Drawing.Size(123, 140);
            this.lstBoletas.TabIndex = 5;
            this.lstBoletas.DoubleClick += new System.EventHandler(this.lstBoletas_DoubleClick);
            this.lstBoletas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoletas_MouseUp);
            // 
            // chCompra
            // 
            this.chCompra.AutoSize = true;
            this.chCompra.Depth = 0;
            this.chCompra.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCompra.Location = new System.Drawing.Point(142, 515);
            this.chCompra.Margin = new System.Windows.Forms.Padding(0);
            this.chCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCompra.Name = "chCompra";
            this.chCompra.Ripple = true;
            this.chCompra.Size = new System.Drawing.Size(159, 30);
            this.chCompra.TabIndex = 6;
            this.chCompra.Text = "Compra y Agregados";
            this.chCompra.UseVisualStyleBackColor = true;
            // 
            // chFaena
            // 
            this.chFaena.AutoSize = true;
            this.chFaena.Depth = 0;
            this.chFaena.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFaena.Location = new System.Drawing.Point(142, 545);
            this.chFaena.Margin = new System.Windows.Forms.Padding(0);
            this.chFaena.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFaena.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFaena.Name = "chFaena";
            this.chFaena.Ripple = true;
            this.chFaena.Size = new System.Drawing.Size(67, 30);
            this.chFaena.TabIndex = 6;
            this.chFaena.Text = "Faena";
            this.chFaena.UseVisualStyleBackColor = true;
            // 
            // mdSincSalidas
            // 
            this.mdSincSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mdSincSalidas.Location = new System.Drawing.Point(16, 357);
            this.mdSincSalidas.Name = "mdSincSalidas";
            this.mdSincSalidas.Size = new System.Drawing.Size(419, 28);
            this.mdSincSalidas.TabIndex = 7;
            this.mdSincSalidas.Text = "Sincronizar Salidas";
            this.mdSincSalidas.UseVisualStyleBackColor = true;
            this.mdSincSalidas.Click += new System.EventHandler(this.mdSincSalidas_Click);
            // 
            // chSaldo
            // 
            this.chSaldo.AutoSize = true;
            this.chSaldo.Depth = 0;
            this.chSaldo.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSaldo.Location = new System.Drawing.Point(142, 575);
            this.chSaldo.Margin = new System.Windows.Forms.Padding(0);
            this.chSaldo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSaldo.Name = "chSaldo";
            this.chSaldo.Ripple = true;
            this.chSaldo.Size = new System.Drawing.Size(65, 30);
            this.chSaldo.TabIndex = 6;
            this.chSaldo.Text = "Saldo";
            this.chSaldo.UseVisualStyleBackColor = true;
            // 
            // cmdSaldos
            // 
            this.cmdSaldos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSaldos.Location = new System.Drawing.Point(145, 642);
            this.cmdSaldos.Name = "cmdSaldos";
            this.cmdSaldos.Size = new System.Drawing.Size(151, 28);
            this.cmdSaldos.TabIndex = 8;
            this.cmdSaldos.Text = "Saldo Hacia Adelante";
            this.cmdSaldos.UseVisualStyleBackColor = true;
            this.cmdSaldos.Click += new System.EventHandler(this.cmdSaldos_Click);
            // 
            // chBoleta
            // 
            this.chBoleta.AutoSize = true;
            this.chBoleta.Depth = 0;
            this.chBoleta.Font = new System.Drawing.Font("Roboto", 10F);
            this.chBoleta.Location = new System.Drawing.Point(142, 480);
            this.chBoleta.Margin = new System.Windows.Forms.Padding(0);
            this.chBoleta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chBoleta.MouseState = MaterialSkin.MouseState.HOVER;
            this.chBoleta.Name = "chBoleta";
            this.chBoleta.Ripple = true;
            this.chBoleta.Size = new System.Drawing.Size(69, 30);
            this.chBoleta.TabIndex = 6;
            this.chBoleta.Text = "Boleta";
            this.chBoleta.UseVisualStyleBackColor = true;
            // 
            // cmdAdelante
            // 
            this.cmdAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAdelante.Location = new System.Drawing.Point(145, 608);
            this.cmdAdelante.Name = "cmdAdelante";
            this.cmdAdelante.Size = new System.Drawing.Size(151, 28);
            this.cmdAdelante.TabIndex = 8;
            this.cmdAdelante.Text = "Hacia Adelante";
            this.cmdAdelante.UseVisualStyleBackColor = true;
            this.cmdAdelante.Click += new System.EventHandler(this.cmdAdelante_Click);
            // 
            // txtBoleta
            // 
            this.txtBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoleta.Location = new System.Drawing.Point(16, 642);
            this.txtBoleta.Name = "txtBoleta";
            this.txtBoleta.Size = new System.Drawing.Size(59, 13);
            this.txtBoleta.TabIndex = 10;
            this.txtBoleta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoleta_KeyPress);
            this.txtBoleta.Validated += new System.EventHandler(this.txtBoleta_Validated);
            // 
            // txtHasta
            // 
            this.txtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHasta.Location = new System.Drawing.Point(81, 642);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(58, 13);
            this.txtHasta.TabIndex = 11;
            // 
            // frmSincronizarAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 668);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.txtBoleta);
            this.Controls.Add(this.cmdAdelante);
            this.Controls.Add(this.cmdSaldos);
            this.Controls.Add(this.mdSincSalidas);
            this.Controls.Add(this.chSaldo);
            this.Controls.Add(this.chFaena);
            this.Controls.Add(this.chBoleta);
            this.Controls.Add(this.chCompra);
            this.Controls.Add(this.lstBoletas);
            this.Controls.Add(this.lstActualizacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nuCant);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSincronizar);
            this.Controls.Add(this.cmdBase);
            this.Name = "frmSincronizarAccess";
            this.Text = "Sincronizar Access";
            ((System.ComponentModel.ISupportInitialize)(this.nuCant)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSincronizar;
        private System.Windows.Forms.NumericUpDown nuCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar mDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MonthCalendar mHasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog flBuscar;
        private System.Windows.Forms.ListBox lstActualizacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstBoletas;
        private MaterialSkin.Controls.MaterialCheckBox chCompra;
        private MaterialSkin.Controls.MaterialCheckBox chFaena;
        private System.Windows.Forms.Button mdSincSalidas;
        private MaterialSkin.Controls.MaterialCheckBox chSaldo;
        private System.Windows.Forms.Button cmdSaldos;
        private MaterialSkin.Controls.MaterialCheckBox chBoleta;
        private System.Windows.Forms.Button cmdAdelante;
        private System.Windows.Forms.TextBox txtBoleta;
        private System.Windows.Forms.TextBox txtHasta;
    }
}