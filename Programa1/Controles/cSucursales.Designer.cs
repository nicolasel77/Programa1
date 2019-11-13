namespace Programa1.Controles
{
    partial class cSucursales
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
            this.lst = new System.Windows.Forms.ListBox();
            this.lstTipos = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdInvertir = new System.Windows.Forms.Button();
            this.cmdNinguno = new System.Windows.Forms.Button();
            this.cmdTodos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chVer = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.rdTodas = new System.Windows.Forms.RadioButton();
            this.rdClientes = new System.Windows.Forms.RadioButton();
            this.rdSucs = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdId = new System.Windows.Forms.RadioButton();
            this.rdOrden = new System.Windows.Forms.RadioButton();
            this.cmdTodosTipos = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(6, 21);
            this.lst.Name = "lst";
            this.lst.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst.Size = new System.Drawing.Size(225, 455);
            this.lst.TabIndex = 0;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.Lst_SelectedIndexChanged);
            this.lst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lst_MouseUp);
            // 
            // lstTipos
            // 
            this.lstTipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipos.FormattingEnabled = true;
            this.lstTipos.Location = new System.Drawing.Point(3, 21);
            this.lstTipos.Name = "lstTipos";
            this.lstTipos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTipos.Size = new System.Drawing.Size(85, 156);
            this.lstTipos.TabIndex = 4;
            this.lstTipos.SelectedIndexChanged += new System.EventHandler(this.LstTipos_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.cmdInvertir);
            this.splitContainer1.Panel1.Controls.Add(this.cmdNinguno);
            this.splitContainer1.Panel1.Controls.Add(this.cmdTodos);
            this.splitContainer1.Panel1.Controls.Add(this.lblTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.lst);
            this.splitContainer1.Panel1.Controls.Add(this.chVer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdTodosTipos);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscar);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lstTipos);
            this.splitContainer1.Size = new System.Drawing.Size(337, 512);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 2;
            // 
            // cmdInvertir
            // 
            this.cmdInvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInvertir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdInvertir.Location = new System.Drawing.Point(194, 484);
            this.cmdInvertir.Name = "cmdInvertir";
            this.cmdInvertir.Size = new System.Drawing.Size(37, 23);
            this.cmdInvertir.TabIndex = 3;
            this.cmdInvertir.Text = "I";
            this.toolTip1.SetToolTip(this.cmdInvertir, "Invierte la selección actual\r\n(Click derecho)");
            this.cmdInvertir.UseVisualStyleBackColor = true;
            this.cmdInvertir.Click += new System.EventHandler(this.CmdInvertir_Click);
            // 
            // cmdNinguno
            // 
            this.cmdNinguno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNinguno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNinguno.Location = new System.Drawing.Point(149, 484);
            this.cmdNinguno.Name = "cmdNinguno";
            this.cmdNinguno.Size = new System.Drawing.Size(37, 23);
            this.cmdNinguno.TabIndex = 2;
            this.cmdNinguno.Text = "N";
            this.toolTip1.SetToolTip(this.cmdNinguno, "Borra la selección.");
            this.cmdNinguno.UseVisualStyleBackColor = true;
            this.cmdNinguno.Click += new System.EventHandler(this.CmdNinguno_Click);
            // 
            // cmdTodos
            // 
            this.cmdTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTodos.Location = new System.Drawing.Point(104, 484);
            this.cmdTodos.Name = "cmdTodos";
            this.cmdTodos.Size = new System.Drawing.Size(37, 23);
            this.cmdTodos.TabIndex = 1;
            this.cmdTodos.Text = "T";
            this.toolTip1.SetToolTip(this.cmdTodos, "Selecciona Todos\r\n(Click con rueda del mouse)");
            this.cmdTodos.UseVisualStyleBackColor = true;
            this.cmdTodos.Click += new System.EventHandler(this.CmdTodos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblTitulo.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(82, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sucursales";
            // 
            // chVer
            // 
            this.chVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chVer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chVer.ForeColor = System.Drawing.Color.DimGray;
            this.chVer.Location = new System.Drawing.Point(6, 486);
            this.chVer.Name = "chVer";
            this.chVer.Size = new System.Drawing.Size(71, 23);
            this.chVer.TabIndex = 8;
            this.chVer.Text = "Ocultos";
            this.toolTip1.SetToolTip(this.chVer, "Oculta/muestra según filtro Ver");
            this.chVer.UseVisualStyleBackColor = true;
            this.chVer.CheckedChanged += new System.EventHandler(this.ChVer_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rdTodas);
            this.panel2.Controls.Add(this.rdClientes);
            this.panel2.Controls.Add(this.rdSucs);
            this.panel2.Location = new System.Drawing.Point(3, 291);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 92);
            this.panel2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ver:";
            // 
            // rdTodas
            // 
            this.rdTodas.AutoSize = true;
            this.rdTodas.ForeColor = System.Drawing.Color.DimGray;
            this.rdTodas.Location = new System.Drawing.Point(4, 16);
            this.rdTodas.Name = "rdTodas";
            this.rdTodas.Size = new System.Drawing.Size(55, 17);
            this.rdTodas.TabIndex = 7;
            this.rdTodas.Text = "Todas";
            this.rdTodas.UseVisualStyleBackColor = true;
            this.rdTodas.CheckedChanged += new System.EventHandler(this.RdSucs_CheckedChanged);
            // 
            // rdClientes
            // 
            this.rdClientes.AutoSize = true;
            this.rdClientes.ForeColor = System.Drawing.Color.DimGray;
            this.rdClientes.Location = new System.Drawing.Point(4, 62);
            this.rdClientes.Name = "rdClientes";
            this.rdClientes.Size = new System.Drawing.Size(62, 17);
            this.rdClientes.TabIndex = 7;
            this.rdClientes.Text = "Clientes";
            this.rdClientes.UseVisualStyleBackColor = true;
            this.rdClientes.CheckedChanged += new System.EventHandler(this.RdSucs_CheckedChanged);
            // 
            // rdSucs
            // 
            this.rdSucs.AutoSize = true;
            this.rdSucs.Checked = true;
            this.rdSucs.ForeColor = System.Drawing.Color.DimGray;
            this.rdSucs.Location = new System.Drawing.Point(4, 39);
            this.rdSucs.Name = "rdSucs";
            this.rdSucs.Size = new System.Drawing.Size(77, 17);
            this.rdSucs.TabIndex = 7;
            this.rdSucs.TabStop = true;
            this.rdSucs.Text = "Sucursales";
            this.rdSucs.UseVisualStyleBackColor = true;
            this.rdSucs.CheckedChanged += new System.EventHandler(this.RdSucs_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rdId);
            this.panel1.Controls.Add(this.rdOrden);
            this.panel1.Location = new System.Drawing.Point(3, 400);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 68);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Orden:";
            // 
            // rdId
            // 
            this.rdId.AutoSize = true;
            this.rdId.Checked = true;
            this.rdId.ForeColor = System.Drawing.Color.DimGray;
            this.rdId.Location = new System.Drawing.Point(4, 16);
            this.rdId.Name = "rdId";
            this.rdId.Size = new System.Drawing.Size(34, 17);
            this.rdId.TabIndex = 7;
            this.rdId.TabStop = true;
            this.rdId.Text = "Id";
            this.rdId.UseVisualStyleBackColor = true;
            this.rdId.CheckedChanged += new System.EventHandler(this.RdId_CheckedChanged);
            // 
            // rdOrden
            // 
            this.rdOrden.AutoSize = true;
            this.rdOrden.ForeColor = System.Drawing.Color.DimGray;
            this.rdOrden.Location = new System.Drawing.Point(4, 39);
            this.rdOrden.Name = "rdOrden";
            this.rdOrden.Size = new System.Drawing.Size(62, 17);
            this.rdOrden.TabIndex = 7;
            this.rdOrden.Text = "Nombre";
            this.rdOrden.UseVisualStyleBackColor = true;
            // 
            // cmdTodosTipos
            // 
            this.cmdTodosTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTodosTipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTodosTipos.Location = new System.Drawing.Point(57, 183);
            this.cmdTodosTipos.Name = "cmdTodosTipos";
            this.cmdTodosTipos.Size = new System.Drawing.Size(31, 19);
            this.cmdTodosTipos.TabIndex = 5;
            this.cmdTodosTipos.Text = "N";
            this.toolTip1.SetToolTip(this.cmdTodosTipos, "Borra selección");
            this.cmdTodosTipos.UseVisualStyleBackColor = true;
            this.cmdTodosTipos.Click += new System.EventHandler(this.CmdTodosTipos_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Location = new System.Drawing.Point(6, 489);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(82, 13);
            this.txtBuscar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtBuscar, "Busca por Id y Nombre");
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Buscar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo";
            // 
            // cSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.splitContainer1);
            this.Name = "cSucursales";
            this.Size = new System.Drawing.Size(343, 518);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstTipos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdInvertir;
        private System.Windows.Forms.Button cmdNinguno;
        private System.Windows.Forms.Button cmdTodos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdTodosTipos;
        private System.Windows.Forms.CheckBox chVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdOrden;
        private System.Windows.Forms.RadioButton rdId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdTodas;
        private System.Windows.Forms.RadioButton rdClientes;
        private System.Windows.Forms.RadioButton rdSucs;
        private System.Windows.Forms.Panel panel1;
    }
}
