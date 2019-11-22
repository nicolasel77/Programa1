namespace Programa1.Controles
{
    partial class cTipoGastosSucursal
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
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.lstRubros = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdInvertir = new System.Windows.Forms.Button();
            this.cmdNinguno = new System.Windows.Forms.Button();
            this.cmdTodos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdId = new System.Windows.Forms.RadioButton();
            this.rdOrden = new System.Windows.Forms.RadioButton();
            this.cmdTodosTipos = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTipo
            // 
            this.lstTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.Location = new System.Drawing.Point(6, 21);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTipo.Size = new System.Drawing.Size(275, 572);
            this.lstTipo.TabIndex = 0;
            this.lstTipo.SelectedIndexChanged += new System.EventHandler(this.Lst_SelectedIndexChanged);
            this.lstTipo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lst_MouseUp);
            // 
            // lstRubros
            // 
            this.lstRubros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRubros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRubros.FormattingEnabled = true;
            this.lstRubros.Location = new System.Drawing.Point(3, 21);
            this.lstRubros.Name = "lstRubros";
            this.lstRubros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRubros.Size = new System.Drawing.Size(116, 247);
            this.lstRubros.TabIndex = 4;
            this.lstRubros.SelectedIndexChanged += new System.EventHandler(this.LstTipos_SelectedIndexChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.lstTipo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.cmdTodosTipos);
            this.splitContainer1.Panel2.Controls.Add(this.txtBuscar);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.lstGrupos);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.lstRubros);
            this.splitContainer1.Size = new System.Drawing.Size(410, 635);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 2;
            // 
            // cmdInvertir
            // 
            this.cmdInvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInvertir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdInvertir.Location = new System.Drawing.Point(244, 607);
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
            this.cmdNinguno.Location = new System.Drawing.Point(199, 607);
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
            this.cmdTodos.Location = new System.Drawing.Point(154, 607);
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
            this.lblTitulo.Size = new System.Drawing.Size(37, 18);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tipo";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.rdId);
            this.panel1.Controls.Add(this.rdOrden);
            this.panel1.Location = new System.Drawing.Point(3, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 68);
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
            this.cmdTodosTipos.Location = new System.Drawing.Point(88, 274);
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
            this.txtBuscar.Location = new System.Drawing.Point(6, 612);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(105, 13);
            this.txtBuscar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtBuscar, "Busca por Id y Nombre");
            this.txtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 594);
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
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rubros";
            // 
            // lstGrupos
            // 
            this.lstGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.Location = new System.Drawing.Point(3, 324);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstGrupos.Size = new System.Drawing.Size(116, 78);
            this.lstGrupos.TabIndex = 4;
            this.lstGrupos.SelectedIndexChanged += new System.EventHandler(this.LstTipos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(0, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupos";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(65, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 19);
            this.button1.TabIndex = 5;
            this.button1.Text = "N";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CmdTodosTipos_Click);
            // 
            // cTipoGastosSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.splitContainer1);
            this.Name = "cTipoGastosSucursal";
            this.Size = new System.Drawing.Size(416, 641);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lstTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstRubros;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdInvertir;
        private System.Windows.Forms.Button cmdNinguno;
        private System.Windows.Forms.Button cmdTodos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdTodosTipos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdOrden;
        private System.Windows.Forms.RadioButton rdId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstGrupos;
    }
}
