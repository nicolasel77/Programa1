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
            this.tabSemana = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            this.tabDia = new System.Windows.Forms.TabPage();
            this.mntDias = new System.Windows.Forms.MonthCalendar();
            this.tabMes = new System.Windows.Forms.TabPage();
            this.lstMesAño = new System.Windows.Forms.ListBox();
            this.lstMes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabAño = new System.Windows.Forms.TabPage();
            this.lstAños = new System.Windows.Forms.ListBox();
            this.tabDH = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMostrarSolo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabSemana.SuspendLayout();
            this.tabDia.SuspendLayout();
            this.tabMes.SuspendLayout();
            this.tabAño.SuspendLayout();
            this.tabDH.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSemana);
            this.tabControl1.Controls.Add(this.tabDia);
            this.tabControl1.Controls.Add(this.tabMes);
            this.tabControl1.Controls.Add(this.tabAño);
            this.tabControl1.Controls.Add(this.tabDH);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(366, 265);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabSemana
            // 
            this.tabSemana.Controls.Add(this.label4);
            this.tabSemana.Controls.Add(this.lstSemanas);
            this.tabSemana.Location = new System.Drawing.Point(4, 4);
            this.tabSemana.Name = "tabSemana";
            this.tabSemana.Padding = new System.Windows.Forms.Padding(3);
            this.tabSemana.Size = new System.Drawing.Size(358, 239);
            this.tabSemana.TabIndex = 0;
            this.tabSemana.Text = "Sem";
            this.toolTip1.SetToolTip(this.tabSemana, "Semana");
            this.tabSemana.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fecha";
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
            // tabMes
            // 
            this.tabMes.Controls.Add(this.lstMesAño);
            this.tabMes.Controls.Add(this.lstMes);
            this.tabMes.Controls.Add(this.label3);
            this.tabMes.Location = new System.Drawing.Point(4, 4);
            this.tabMes.Name = "tabMes";
            this.tabMes.Padding = new System.Windows.Forms.Padding(3);
            this.tabMes.Size = new System.Drawing.Size(358, 239);
            this.tabMes.TabIndex = 1;
            this.tabMes.Text = "Mes";
            this.toolTip1.SetToolTip(this.tabMes, "Mes");
            this.tabMes.UseVisualStyleBackColor = true;
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
            // tabAño
            // 
            this.tabAño.Controls.Add(this.lstAños);
            this.tabAño.Location = new System.Drawing.Point(4, 4);
            this.tabAño.Name = "tabAño";
            this.tabAño.Size = new System.Drawing.Size(358, 239);
            this.tabAño.TabIndex = 2;
            this.tabAño.Text = "Año";
            this.toolTip1.SetToolTip(this.tabAño, "Año");
            this.tabAño.UseVisualStyleBackColor = true;
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
            // tabDH
            // 
            this.tabDH.Controls.Add(this.label2);
            this.tabDH.Controls.Add(this.dtHasta);
            this.tabDH.Controls.Add(this.label1);
            this.tabDH.Controls.Add(this.dtDesde);
            this.tabDH.Location = new System.Drawing.Point(4, 4);
            this.tabDH.Name = "tabDH";
            this.tabDH.Size = new System.Drawing.Size(358, 239);
            this.tabDH.TabIndex = 3;
            this.tabDH.Text = "DH";
            this.toolTip1.SetToolTip(this.tabDH, "Desde - Hasta");
            this.tabDH.UseVisualStyleBackColor = true;
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
            // lblMostrarSolo
            // 
            this.lblMostrarSolo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMostrarSolo.Location = new System.Drawing.Point(0, 243);
            this.lblMostrarSolo.Name = "lblMostrarSolo";
            this.lblMostrarSolo.Size = new System.Drawing.Size(369, 22);
            this.lblMostrarSolo.TabIndex = 2;
            this.lblMostrarSolo.Text = "Semana";
            this.lblMostrarSolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMostrarSolo.Visible = false;
            // 
            // cFechas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblMostrarSolo);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(0, 184);
            this.Name = "cFechas";
            this.Size = new System.Drawing.Size(369, 265);
            this.tabControl1.ResumeLayout(false);
            this.tabSemana.ResumeLayout(false);
            this.tabSemana.PerformLayout();
            this.tabDia.ResumeLayout(false);
            this.tabMes.ResumeLayout(false);
            this.tabAño.ResumeLayout(false);
            this.tabDH.ResumeLayout(false);
            this.tabDH.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSemana;
        private System.Windows.Forms.TabPage tabMes;
        private System.Windows.Forms.TabPage tabAño;
        private System.Windows.Forms.TabPage tabDH;
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
        private System.Windows.Forms.Label lblMostrarSolo;
        private System.Windows.Forms.Label label4;
    }
}
