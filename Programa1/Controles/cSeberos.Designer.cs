namespace Programa1.Controles
{
    partial class cSeberos
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdInvertir = new System.Windows.Forms.Button();
            this.cmdNinguno = new System.Windows.Forms.Button();
            this.cmdTodos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cmdInvertir
            // 
            this.cmdInvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdInvertir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdInvertir.Location = new System.Drawing.Point(187, 295);
            this.cmdInvertir.Name = "cmdInvertir";
            this.cmdInvertir.Size = new System.Drawing.Size(37, 23);
            this.cmdInvertir.TabIndex = 14;
            this.cmdInvertir.Text = "I";
            this.toolTip1.SetToolTip(this.cmdInvertir, "Invierte la selección actual\r\n(Click derecho)");
            this.cmdInvertir.UseVisualStyleBackColor = true;
            // 
            // cmdNinguno
            // 
            this.cmdNinguno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNinguno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNinguno.Location = new System.Drawing.Point(142, 295);
            this.cmdNinguno.Name = "cmdNinguno";
            this.cmdNinguno.Size = new System.Drawing.Size(37, 23);
            this.cmdNinguno.TabIndex = 13;
            this.cmdNinguno.Text = "N";
            this.toolTip1.SetToolTip(this.cmdNinguno, "Borra la selección.\r\n(Click con rueda del mouse)");
            this.cmdNinguno.UseVisualStyleBackColor = true;
            // 
            // cmdTodos
            // 
            this.cmdTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTodos.Location = new System.Drawing.Point(97, 295);
            this.cmdTodos.Name = "cmdTodos";
            this.cmdTodos.Size = new System.Drawing.Size(37, 23);
            this.cmdTodos.TabIndex = 12;
            this.cmdTodos.Text = "T";
            this.toolTip1.SetToolTip(this.cmdTodos, "Selecciona Todos");
            this.cmdTodos.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblTitulo.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblTitulo.Location = new System.Drawing.Point(0, 1);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(64, 18);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Seberos";
            // 
            // lst
            // 
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(3, 22);
            this.lst.Name = "lst";
            this.lst.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst.Size = new System.Drawing.Size(221, 260);
            this.lst.TabIndex = 11;
            // 
            // cSeberos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cmdInvertir);
            this.Controls.Add(this.cmdNinguno);
            this.Controls.Add(this.cmdTodos);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lst);
            this.Name = "cSeberos";
            this.Size = new System.Drawing.Size(227, 326);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button cmdInvertir;
        private System.Windows.Forms.Button cmdNinguno;
        private System.Windows.Forms.Button cmdTodos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListBox lst;
    }
}
