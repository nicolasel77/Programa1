namespace Programa1.Controles
{
    partial class cFechas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.tabDia = new System.Windows.Forms.TabPage();
            this.mntDias = new System.Windows.Forms.MonthCalendar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstMesAño = new System.Windows.Forms.ListBox();
            this.lstMes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstAños = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabDia.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabDia);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(366, 265);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstSemanas);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(358, 239);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sem";
            this.toolTip1.SetToolTip(this.tabPage1, "Semana");
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstSemanas
            // 
            this.lstSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSemanas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSemanas.FormattingEnabled = true;
            this.lstSemanas.ItemHeight = 16;
            this.lstSemanas.Location = new System.Drawing.Point(3, 3);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.Size = new System.Drawing.Size(352, 233);
            this.lstSemanas.TabIndex = 0;
            this.lstSemanas.SelectedIndexChanged += new System.EventHandler(this.LstSemanas_SelectedIndexChanged);
            // 
            // tabDia
            // 
            this.tabDia.Controls.Add(this.mntDias);
            this.tabDia.Location = new System.Drawing.Point(4, 4);
            this.tabDia.Name = "tabDia";
            this.tabDia.Size = new System.Drawing.Size(358, 239);
            this.tabDia.TabIndex = 4;
            this.tabDia.Text = "Día";
            this.tabDia.UseVisualStyleBackColor = true;
            // 
            // mntDias
            // 
            this.mntDias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mntDias.Location = new System.Drawing.Point(0, 0);
            this.mntDias.Name = "mntDias";
            this.mntDias.TabIndex = 0;
            this.mntDias.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MntDias_DateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstMesAño);
            this.tabPage2.Controls.Add(this.lstMes);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(358, 239);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mes";
            this.toolTip1.SetToolTip(this.tabPage2, "Mes");
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstMesAño
            // 
            this.lstMesAño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMesAño.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMesAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMesAño.FormattingEnabled = true;
            this.lstMesAño.ItemHeight = 16;
            this.lstMesAño.Items.AddRange(new object[] {
            "2019",
            "2018",
            "2017",
            "2016",
            "2015"});
            this.lstMesAño.Location = new System.Drawing.Point(63, 1);
            this.lstMesAño.Name = "lstMesAño";
            this.lstMesAño.Size = new System.Drawing.Size(47, 224);
            this.lstMesAño.TabIndex = 2;
            this.lstMesAño.SelectedIndexChanged += new System.EventHandler(this.LstMesAño_SelectedIndexChanged);
            // 
            // lstMes
            // 
            this.lstMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMes.FormattingEnabled = true;
            this.lstMes.ItemHeight = 16;
            this.lstMes.Items.AddRange(new object[] {
            "Ene",
            "Feb",
            "Mar",
            "Abr",
            "May",
            "Jun",
            "Jul",
            "Ago",
            "Set",
            "Oct",
            "Nov",
            "Dic"});
            this.lstMes.Location = new System.Drawing.Point(3, 3);
            this.lstMes.Name = "lstMes";
            this.lstMes.Size = new System.Drawing.Size(54, 224);
            this.lstMes.TabIndex = 1;
            this.lstMes.SelectedIndexChanged += new System.EventHandler(this.LstMes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(30, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 233);
            this.label3.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstAños);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(358, 239);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Año";
            this.toolTip1.SetToolTip(this.tabPage3, "Año");
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstAños
            // 
            this.lstAños.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAños.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstAños.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAños.FormattingEnabled = true;
            this.lstAños.ItemHeight = 20;
            this.lstAños.Items.AddRange(new object[] {
            "2019",
            "2018",
            "2017",
            "2016",
            "2015"});
            this.lstAños.Location = new System.Drawing.Point(0, 0);
            this.lstAños.Name = "lstAños";
            this.lstAños.Size = new System.Drawing.Size(91, 239);
            this.lstAños.TabIndex = 3;
            this.lstAños.SelectedIndexChanged += new System.EventHandler(this.LstAños_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.dtHasta);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.dtDesde);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(358, 239);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "DH";
            this.toolTip1.SetToolTip(this.tabPage4, "Desde - Hasta");
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta:";
            // 
            // dtHasta
            // 
            this.dtHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(6, 67);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(86, 22);
            this.dtHasta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // dtDesde
            // 
            this.dtDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(6, 21);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(86, 22);
            this.dtDesde.TabIndex = 0;
            this.dtDesde.ValueChanged += new System.EventHandler(this.DtDesde_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fecha";
            // 
            // cFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(0, 184);
            this.Name = "cFechas";
            this.Size = new System.Drawing.Size(369, 265);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabDia.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstSemanas;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox lstMesAño;
        private System.Windows.Forms.ListBox lstMes;
        private System.Windows.Forms.ListBox lstAños;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabDia;
        private System.Windows.Forms.MonthCalendar mntDias;
        private System.Windows.Forms.Label label4;
    }
}
