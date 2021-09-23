
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flBuscar = new System.Windows.Forms.OpenFileDialog();
            this.lstActualizacion = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstBoletas = new System.Windows.Forms.ListBox();
            this.chCompra = new MaterialSkin.Controls.MaterialCheckBox();
            this.chFaena = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdSincSalidas = new System.Windows.Forms.Button();
            this.chSaldo = new MaterialSkin.Controls.MaterialCheckBox();
            this.chBoleta = new MaterialSkin.Controls.MaterialCheckBox();
            this.cmdAdelante = new System.Windows.Forms.Button();
            this.txtBoleta = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.cmdCostos_Salida = new System.Windows.Forms.Button();
            this.mDesde = new System.Windows.Forms.DateTimePicker();
            this.mHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lstSistema = new System.Windows.Forms.ListBox();
            this.lstFechasAcc = new System.Windows.Forms.ListBox();
            this.lstFechasSis = new System.Windows.Forms.ListBox();
            this.cmdListados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdBase
            // 
            this.cmdBase.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmdBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmdBase.Location = new System.Drawing.Point(127, 12);
            this.cmdBase.Name = "cmdBase";
            this.cmdBase.Size = new System.Drawing.Size(365, 32);
            this.cmdBase.TabIndex = 0;
            this.cmdBase.Text = "Base de datos";
            this.cmdBase.UseVisualStyleBackColor = false;
            this.cmdBase.Click += new System.EventHandler(this.cmdBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base de datos:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(23, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salidas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(314, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(314, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Hasta";
            // 
            // flBuscar
            // 
            this.flBuscar.DefaultExt = "accdb";
            this.flBuscar.FileName = "openFileDialog1";
            // 
            // lstActualizacion
            // 
            this.lstActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstActualizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstActualizacion.FormattingEnabled = true;
            this.lstActualizacion.ItemHeight = 20;
            this.lstActualizacion.Location = new System.Drawing.Point(498, 12);
            this.lstActualizacion.Name = "lstActualizacion";
            this.lstActualizacion.Size = new System.Drawing.Size(466, 620);
            this.lstActualizacion.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(19, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Boletas en access/sistema";
            // 
            // lstBoletas
            // 
            this.lstBoletas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoletas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBoletas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstBoletas.FormattingEnabled = true;
            this.lstBoletas.ItemHeight = 20;
            this.lstBoletas.Location = new System.Drawing.Point(23, 292);
            this.lstBoletas.Name = "lstBoletas";
            this.lstBoletas.Size = new System.Drawing.Size(130, 240);
            this.lstBoletas.TabIndex = 5;
            this.lstBoletas.DoubleClick += new System.EventHandler(this.lstBoletas_DoubleClick);
            this.lstBoletas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoletas_MouseUp);
            // 
            // chCompra
            // 
            this.chCompra.AutoSize = true;
            this.chCompra.Checked = true;
            this.chCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chCompra.Depth = 0;
            this.chCompra.Font = new System.Drawing.Font("Roboto", 10F);
            this.chCompra.Location = new System.Drawing.Point(315, 331);
            this.chCompra.Margin = new System.Windows.Forms.Padding(0);
            this.chCompra.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.chCompra.Name = "chCompra";
            this.chCompra.Ripple = true;
            this.chCompra.Size = new System.Drawing.Size(159, 30);
            this.chCompra.TabIndex = 7;
            this.chCompra.Text = "Compra y Agregados";
            this.chCompra.UseVisualStyleBackColor = true;
            // 
            // chFaena
            // 
            this.chFaena.AutoSize = true;
            this.chFaena.Checked = true;
            this.chFaena.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chFaena.Depth = 0;
            this.chFaena.Font = new System.Drawing.Font("Roboto", 10F);
            this.chFaena.Location = new System.Drawing.Point(315, 361);
            this.chFaena.Margin = new System.Windows.Forms.Padding(0);
            this.chFaena.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chFaena.MouseState = MaterialSkin.MouseState.HOVER;
            this.chFaena.Name = "chFaena";
            this.chFaena.Ripple = true;
            this.chFaena.Size = new System.Drawing.Size(67, 30);
            this.chFaena.TabIndex = 8;
            this.chFaena.Text = "Faena";
            this.chFaena.UseVisualStyleBackColor = true;
            // 
            // cmdSincSalidas
            // 
            this.cmdSincSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSincSalidas.Location = new System.Drawing.Point(318, 184);
            this.cmdSincSalidas.Name = "cmdSincSalidas";
            this.cmdSincSalidas.Size = new System.Drawing.Size(167, 28);
            this.cmdSincSalidas.TabIndex = 3;
            this.cmdSincSalidas.Text = "Sincronizar Salidas";
            this.cmdSincSalidas.UseVisualStyleBackColor = true;
            this.cmdSincSalidas.Click += new System.EventHandler(this.mdSincSalidas_Click);
            // 
            // chSaldo
            // 
            this.chSaldo.AutoSize = true;
            this.chSaldo.Checked = true;
            this.chSaldo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chSaldo.Depth = 0;
            this.chSaldo.Font = new System.Drawing.Font("Roboto", 10F);
            this.chSaldo.Location = new System.Drawing.Point(315, 391);
            this.chSaldo.Margin = new System.Windows.Forms.Padding(0);
            this.chSaldo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chSaldo.MouseState = MaterialSkin.MouseState.HOVER;
            this.chSaldo.Name = "chSaldo";
            this.chSaldo.Ripple = true;
            this.chSaldo.Size = new System.Drawing.Size(65, 30);
            this.chSaldo.TabIndex = 9;
            this.chSaldo.Text = "Saldo";
            this.chSaldo.UseVisualStyleBackColor = true;
            // 
            // chBoleta
            // 
            this.chBoleta.AutoSize = true;
            this.chBoleta.Checked = true;
            this.chBoleta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoleta.Depth = 0;
            this.chBoleta.Font = new System.Drawing.Font("Roboto", 10F);
            this.chBoleta.Location = new System.Drawing.Point(315, 296);
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
            this.cmdAdelante.Location = new System.Drawing.Point(318, 424);
            this.cmdAdelante.Name = "cmdAdelante";
            this.cmdAdelante.Size = new System.Drawing.Size(167, 28);
            this.cmdAdelante.TabIndex = 10;
            this.cmdAdelante.Text = "Hacia Adelante";
            this.cmdAdelante.UseVisualStyleBackColor = true;
            this.cmdAdelante.Click += new System.EventHandler(this.cmdAdelante_Click);
            // 
            // txtBoleta
            // 
            this.txtBoleta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoleta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoleta.Location = new System.Drawing.Point(83, 551);
            this.txtBoleta.Name = "txtBoleta";
            this.txtBoleta.Size = new System.Drawing.Size(124, 15);
            this.txtBoleta.TabIndex = 12;
            this.txtBoleta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoleta_KeyPress);
            this.txtBoleta.Validated += new System.EventHandler(this.txtBoleta_Validated);
            // 
            // txtHasta
            // 
            this.txtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Location = new System.Drawing.Point(83, 580);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(124, 15);
            this.txtHasta.TabIndex = 13;
            // 
            // cmdCostos_Salida
            // 
            this.cmdCostos_Salida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCostos_Salida.Location = new System.Drawing.Point(318, 218);
            this.cmdCostos_Salida.Name = "cmdCostos_Salida";
            this.cmdCostos_Salida.Size = new System.Drawing.Size(167, 28);
            this.cmdCostos_Salida.TabIndex = 4;
            this.cmdCostos_Salida.Text = "Sincronizar Costo Salida";
            this.cmdCostos_Salida.UseVisualStyleBackColor = true;
            this.cmdCostos_Salida.Click += new System.EventHandler(this.cmdCostos_Salida_Click);
            // 
            // mDesde
            // 
            this.mDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mDesde.Location = new System.Drawing.Point(383, 106);
            this.mDesde.Name = "mDesde";
            this.mDesde.Size = new System.Drawing.Size(97, 20);
            this.mDesde.TabIndex = 1;
            // 
            // mHasta
            // 
            this.mHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mHasta.Location = new System.Drawing.Point(383, 135);
            this.mHasta.Name = "mHasta";
            this.mHasta.Size = new System.Drawing.Size(97, 20);
            this.mHasta.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(19, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(19, 548);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Desde";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(23, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Desde - Hasta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstSistema
            // 
            this.lstSistema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSistema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstSistema.ForeColor = System.Drawing.Color.DimGray;
            this.lstSistema.FormattingEnabled = true;
            this.lstSistema.ItemHeight = 20;
            this.lstSistema.Location = new System.Drawing.Point(159, 292);
            this.lstSistema.Name = "lstSistema";
            this.lstSistema.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstSistema.Size = new System.Drawing.Size(130, 240);
            this.lstSistema.TabIndex = 5;
            this.lstSistema.DoubleClick += new System.EventHandler(this.lstBoletas_DoubleClick);
            this.lstSistema.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoletas_MouseUp);
            // 
            // lstFechasAcc
            // 
            this.lstFechasAcc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechasAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstFechasAcc.FormattingEnabled = true;
            this.lstFechasAcc.ItemHeight = 20;
            this.lstFechasAcc.Location = new System.Drawing.Point(23, 102);
            this.lstFechasAcc.Name = "lstFechasAcc";
            this.lstFechasAcc.Size = new System.Drawing.Size(89, 140);
            this.lstFechasAcc.TabIndex = 5;
            this.lstFechasAcc.SelectedIndexChanged += new System.EventHandler(this.lstFechasAcc_SelectedIndexChanged);
            this.lstFechasAcc.DoubleClick += new System.EventHandler(this.lstFechasAcc_DoubleClick);
            this.lstFechasAcc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoletas_MouseUp);
            // 
            // lstFechasSis
            // 
            this.lstFechasSis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFechasSis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstFechasSis.ForeColor = System.Drawing.Color.DimGray;
            this.lstFechasSis.FormattingEnabled = true;
            this.lstFechasSis.ItemHeight = 20;
            this.lstFechasSis.Location = new System.Drawing.Point(118, 102);
            this.lstFechasSis.Name = "lstFechasSis";
            this.lstFechasSis.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstFechasSis.Size = new System.Drawing.Size(89, 140);
            this.lstFechasSis.TabIndex = 5;
            this.lstFechasSis.DoubleClick += new System.EventHandler(this.lstBoletas_DoubleClick);
            this.lstFechasSis.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstBoletas_MouseUp);
            // 
            // cmdListados
            // 
            this.cmdListados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdListados.Location = new System.Drawing.Point(318, 604);
            this.cmdListados.Name = "cmdListados";
            this.cmdListados.Size = new System.Drawing.Size(167, 28);
            this.cmdListados.TabIndex = 10;
            this.cmdListados.Text = "Cargar Listados";
            this.cmdListados.UseVisualStyleBackColor = true;
            this.cmdListados.Click += new System.EventHandler(this.cmdListados_Click);
            // 
            // frmSincronizarAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(976, 644);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mHasta);
            this.Controls.Add(this.txtHasta);
            this.Controls.Add(this.mDesde);
            this.Controls.Add(this.txtBoleta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdListados);
            this.Controls.Add(this.cmdAdelante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdCostos_Salida);
            this.Controls.Add(this.chSaldo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSincSalidas);
            this.Controls.Add(this.chFaena);
            this.Controls.Add(this.chBoleta);
            this.Controls.Add(this.chCompra);
            this.Controls.Add(this.lstFechasSis);
            this.Controls.Add(this.lstSistema);
            this.Controls.Add(this.lstFechasAcc);
            this.Controls.Add(this.lstBoletas);
            this.Controls.Add(this.lstActualizacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdBase);
            this.Name = "frmSincronizarAccess";
            this.Text = "Sincronizar Access";
            this.Load += new System.EventHandler(this.frmSincronizarAccess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog flBuscar;
        private System.Windows.Forms.ListBox lstActualizacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstBoletas;
        private MaterialSkin.Controls.MaterialCheckBox chCompra;
        private MaterialSkin.Controls.MaterialCheckBox chFaena;
        private System.Windows.Forms.Button cmdSincSalidas;
        private MaterialSkin.Controls.MaterialCheckBox chSaldo;
        private MaterialSkin.Controls.MaterialCheckBox chBoleta;
        private System.Windows.Forms.Button cmdAdelante;
        private System.Windows.Forms.TextBox txtBoleta;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.Button cmdCostos_Salida;
        private System.Windows.Forms.DateTimePicker mDesde;
        private System.Windows.Forms.DateTimePicker mHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstSistema;
        private System.Windows.Forms.ListBox lstFechasAcc;
        private System.Windows.Forms.ListBox lstFechasSis;
        private System.Windows.Forms.Button cmdListados;
    }
}