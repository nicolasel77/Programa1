namespace Programa1.Carga.Tesoreria
{
    partial class frmBuscarGasto
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
            this.components = new System.ComponentModel.Container();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdCopiar = new System.Windows.Forms.Button();
            this.cmdIr = new System.Windows.Forms.Button();
            this.cmdCien = new System.Windows.Forms.Button();
            this.cmdMil = new System.Windows.Forms.Button();
            this.cmdTodos = new System.Windows.Forms.Button();
            this.tiBuscar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(12, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(951, 15);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // grd
            // 
            this.grd.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grd.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd.AutoResize = false;
            this.grd.bColor = System.Drawing.SystemColors.Window;
            this.grd.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grd.bFColor = System.Drawing.SystemColors.WindowText;
            this.grd.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grd.Col = 0;
            this.grd.Cols = 10;
            this.grd.DataMember = "";
            this.grd.DataSource = null;
            this.grd.EnableEdicion = true;
            this.grd.Encabezado = "";
            this.grd.fColor = System.Drawing.Color.Silver;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.Frozen = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.LimpiarEstilosAntesDeOrdenar = false;
            this.grd.Location = new System.Drawing.Point(12, 33);
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(951, 481);
            this.grd.TabIndex = 1;
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCerrar.Location = new System.Drawing.Point(846, 527);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(117, 23);
            this.cmdCerrar.TabIndex = 4;
            this.cmdCerrar.Text = "Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdCopiar
            // 
            this.cmdCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCopiar.Location = new System.Drawing.Point(723, 527);
            this.cmdCopiar.Name = "cmdCopiar";
            this.cmdCopiar.Size = new System.Drawing.Size(117, 23);
            this.cmdCopiar.TabIndex = 3;
            this.cmdCopiar.Text = "Copiar";
            this.cmdCopiar.UseVisualStyleBackColor = true;
            this.cmdCopiar.Click += new System.EventHandler(this.cmdCopiar_Click);
            // 
            // cmdIr
            // 
            this.cmdIr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdIr.Location = new System.Drawing.Point(600, 527);
            this.cmdIr.Name = "cmdIr";
            this.cmdIr.Size = new System.Drawing.Size(117, 23);
            this.cmdIr.TabIndex = 2;
            this.cmdIr.Text = "Ir";
            this.cmdIr.UseVisualStyleBackColor = true;
            this.cmdIr.Click += new System.EventHandler(this.cmdIr_Click);
            // 
            // cmdCien
            // 
            this.cmdCien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCien.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCien.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCien.Location = new System.Drawing.Point(12, 527);
            this.cmdCien.Name = "cmdCien";
            this.cmdCien.Size = new System.Drawing.Size(49, 23);
            this.cmdCien.TabIndex = 5;
            this.cmdCien.Text = "100";
            this.cmdCien.UseVisualStyleBackColor = false;
            this.cmdCien.Click += new System.EventHandler(this.cmdCien_Click);
            // 
            // cmdMil
            // 
            this.cmdMil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdMil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdMil.Location = new System.Drawing.Point(67, 527);
            this.cmdMil.Name = "cmdMil";
            this.cmdMil.Size = new System.Drawing.Size(49, 23);
            this.cmdMil.TabIndex = 5;
            this.cmdMil.Text = "1000";
            this.cmdMil.UseVisualStyleBackColor = true;
            this.cmdMil.Click += new System.EventHandler(this.cmdMil_Click);
            // 
            // cmdTodos
            // 
            this.cmdTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdTodos.Location = new System.Drawing.Point(122, 527);
            this.cmdTodos.Name = "cmdTodos";
            this.cmdTodos.Size = new System.Drawing.Size(49, 23);
            this.cmdTodos.TabIndex = 5;
            this.cmdTodos.Text = "Todos";
            this.cmdTodos.UseVisualStyleBackColor = true;
            this.cmdTodos.Click += new System.EventHandler(this.cmdTodos_Click);
            // 
            // tiBuscar
            // 
            this.tiBuscar.Interval = 1000;
            this.tiBuscar.Tick += new System.EventHandler(this.tiBuscar_Tick);
            // 
            // frmBuscarGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 562);
            this.Controls.Add(this.cmdTodos);
            this.Controls.Add(this.cmdMil);
            this.Controls.Add(this.cmdCien);
            this.Controls.Add(this.cmdIr);
            this.Controls.Add(this.cmdCopiar);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.txtBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBuscarGasto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private Grilla2.SpeedGrilla grd;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdCopiar;
        private System.Windows.Forms.Button cmdIr;
        private System.Windows.Forms.Button cmdCien;
        private System.Windows.Forms.Button cmdMil;
        private System.Windows.Forms.Button cmdTodos;
        private System.Windows.Forms.Timer tiBuscar;
    }
}