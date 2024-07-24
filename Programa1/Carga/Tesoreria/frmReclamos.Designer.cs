namespace Programa1.Carga.Tesoreria
{
    partial class frmReclamos
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
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.lstCasos = new System.Windows.Forms.ListBox();
            this.lblCasos = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chResueltos = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstEntidad = new System.Windows.Forms.ListBox();
            this.lblEntidad = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.lblResolucion = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cmdGuardar = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtDesarrollo = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmdCarpeta = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblDesarrollo = new MaterialSkin.Controls.MaterialLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbEntidades = new System.Windows.Forms.ComboBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.cmdNuevoCaso = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblDescripcion = new MaterialSkin.Controls.MaterialLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblArrastre = new MaterialSkin.Controls.MaterialLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialDivider1
            // 
            this.materialDivider1.AllowDrop = true;
            this.materialDivider1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(0, 0);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1000, 604);
            this.materialDivider1.TabIndex = 0;
            this.materialDivider1.Text = "materialDivider1";
            this.materialDivider1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDesarrollo_DragDrop);
            this.materialDivider1.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragEnter_1);
            this.materialDivider1.DragOver += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragOver);
            this.materialDivider1.DragLeave += new System.EventHandler(this.txtDescripcion_DragLeave);
            // 
            // lstCasos
            // 
            this.lstCasos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCasos.FormattingEnabled = true;
            this.lstCasos.Location = new System.Drawing.Point(3, 22);
            this.lstCasos.Name = "lstCasos";
            this.lstCasos.Size = new System.Drawing.Size(120, 329);
            this.lstCasos.TabIndex = 1;
            this.lstCasos.SelectedIndexChanged += new System.EventHandler(this.lstCasos_SelectedIndexChanged);
            // 
            // lblCasos
            // 
            this.lblCasos.AutoSize = true;
            this.lblCasos.Depth = 0;
            this.lblCasos.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCasos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCasos.Location = new System.Drawing.Point(0, 4);
            this.lblCasos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCasos.Name = "lblCasos";
            this.lblCasos.Size = new System.Drawing.Size(56, 19);
            this.lblCasos.TabIndex = 2;
            this.lblCasos.Text = "Casos:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lstCasos);
            this.panel1.Controls.Add(this.chResueltos);
            this.panel1.Controls.Add(this.lblCasos);
            this.panel1.Location = new System.Drawing.Point(1132, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 373);
            this.panel1.TabIndex = 3;
            // 
            // chResueltos
            // 
            this.chResueltos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chResueltos.AutoSize = true;
            this.chResueltos.Checked = true;
            this.chResueltos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chResueltos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chResueltos.Location = new System.Drawing.Point(3, 353);
            this.chResueltos.Name = "chResueltos";
            this.chResueltos.Size = new System.Drawing.Size(108, 17);
            this.chResueltos.TabIndex = 4;
            this.chResueltos.Text = "Ocultar Resueltos";
            this.chResueltos.UseVisualStyleBackColor = true;
            this.chResueltos.CheckedChanged += new System.EventHandler(this.chResueltos_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lstEntidad);
            this.panel2.Controls.Add(this.lblEntidad);
            this.panel2.Location = new System.Drawing.Point(1003, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 373);
            this.panel2.TabIndex = 4;
            // 
            // lstEntidad
            // 
            this.lstEntidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEntidad.FormattingEnabled = true;
            this.lstEntidad.Location = new System.Drawing.Point(3, 22);
            this.lstEntidad.Name = "lstEntidad";
            this.lstEntidad.Size = new System.Drawing.Size(121, 329);
            this.lstEntidad.TabIndex = 0;
            this.lstEntidad.SelectedIndexChanged += new System.EventHandler(this.lstEntidad_SelectedIndexChanged);
            this.lstEntidad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstEntidad_MouseUp);
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.Depth = 0;
            this.lblEntidad.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEntidad.Location = new System.Drawing.Point(0, 4);
            this.lblEntidad.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(63, 19);
            this.lblEntidad.TabIndex = 5;
            this.lblEntidad.Text = "Entidad:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.materialLabel5);
            this.panel3.Controls.Add(this.txtResolucion);
            this.panel3.Controls.Add(this.lblResolucion);
            this.panel3.Location = new System.Drawing.Point(0, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(990, 97);
            this.panel3.TabIndex = 5;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(5, 2);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(84, 19);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Resolución";
            // 
            // txtResolucion
            // 
            this.txtResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResolucion.Location = new System.Drawing.Point(3, 26);
            this.txtResolucion.Multiline = true;
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(984, 68);
            this.txtResolucion.TabIndex = 12;
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Depth = 0;
            this.lblResolucion.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblResolucion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblResolucion.Location = new System.Drawing.Point(12, 16);
            this.lblResolucion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(0, 19);
            this.lblResolucion.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.AllowDrop = true;
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.materialLabel4);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.txtDesarrollo);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.lblDesarrollo);
            this.panel4.Location = new System.Drawing.Point(0, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(990, 366);
            this.panel4.TabIndex = 6;
            this.panel4.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragEnter_1);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(5, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(79, 19);
            this.materialLabel4.TabIndex = 15;
            this.materialLabel4.Text = "Desarrollo";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.cmdGuardar);
            this.panel9.Location = new System.Drawing.Point(865, 315);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(122, 48);
            this.panel9.TabIndex = 9;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.AutoSize = true;
            this.cmdGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdGuardar.Depth = 0;
            this.cmdGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGuardar.Location = new System.Drawing.Point(0, 0);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Primary = false;
            this.cmdGuardar.Size = new System.Drawing.Size(122, 48);
            this.cmdGuardar.TabIndex = 7;
            this.cmdGuardar.Text = "Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // txtDesarrollo
            // 
            this.txtDesarrollo.AllowDrop = true;
            this.txtDesarrollo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesarrollo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesarrollo.Location = new System.Drawing.Point(3, 24);
            this.txtDesarrollo.Multiline = true;
            this.txtDesarrollo.Name = "txtDesarrollo";
            this.txtDesarrollo.Size = new System.Drawing.Size(984, 282);
            this.txtDesarrollo.TabIndex = 10;
            this.txtDesarrollo.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDesarrollo_DragDrop);
            this.txtDesarrollo.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragEnter_1);
            this.txtDesarrollo.DragOver += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragOver);
            this.txtDesarrollo.DragLeave += new System.EventHandler(this.txtDescripcion_DragLeave);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.cmdCarpeta);
            this.panel7.Location = new System.Drawing.Point(734, 315);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(122, 48);
            this.panel7.TabIndex = 9;
            // 
            // cmdCarpeta
            // 
            this.cmdCarpeta.AutoSize = true;
            this.cmdCarpeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCarpeta.Depth = 0;
            this.cmdCarpeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCarpeta.Location = new System.Drawing.Point(0, 0);
            this.cmdCarpeta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCarpeta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCarpeta.Name = "cmdCarpeta";
            this.cmdCarpeta.Primary = false;
            this.cmdCarpeta.Size = new System.Drawing.Size(122, 48);
            this.cmdCarpeta.TabIndex = 7;
            this.cmdCarpeta.Text = "Carpeta";
            this.cmdCarpeta.UseVisualStyleBackColor = true;
            this.cmdCarpeta.Click += new System.EventHandler(this.cmdCarpeta_Click);
            // 
            // lblDesarrollo
            // 
            this.lblDesarrollo.AutoSize = true;
            this.lblDesarrollo.Depth = 0;
            this.lblDesarrollo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDesarrollo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDesarrollo.Location = new System.Drawing.Point(11, 11);
            this.lblDesarrollo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDesarrollo.Name = "lblDesarrollo";
            this.lblDesarrollo.Size = new System.Drawing.Size(0, 19);
            this.lblDesarrollo.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.AllowDrop = true;
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.cbEntidades);
            this.panel5.Controls.Add(this.txtTitulo);
            this.panel5.Controls.Add(this.lblTitulo);
            this.panel5.Controls.Add(this.materialLabel2);
            this.panel5.Controls.Add(this.materialLabel1);
            this.panel5.Controls.Add(this.dtpFinal);
            this.panel5.Controls.Add(this.dtpInicio);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(990, 31);
            this.panel5.TabIndex = 6;
            // 
            // cbEntidades
            // 
            this.cbEntidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntidades.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEntidades.FormattingEnabled = true;
            this.cbEntidades.Location = new System.Drawing.Point(526, 6);
            this.cbEntidades.Name = "cbEntidades";
            this.cbEntidades.Size = new System.Drawing.Size(146, 21);
            this.cbEntidades.TabIndex = 13;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(3, 3);
            this.txtTitulo.Multiline = true;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(81, 25);
            this.txtTitulo.TabIndex = 12;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Location = new System.Drawing.Point(5, 8);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 19);
            this.lblTitulo.TabIndex = 6;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(838, 8);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(45, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Final:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(678, 8);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(50, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Inicio:";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(889, 8);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(98, 20);
            this.dtpFinal.TabIndex = 2;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(734, 6);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(98, 20);
            this.dtpInicio.TabIndex = 1;
            // 
            // cmdNuevoCaso
            // 
            this.cmdNuevoCaso.AutoSize = true;
            this.cmdNuevoCaso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdNuevoCaso.Depth = 0;
            this.cmdNuevoCaso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdNuevoCaso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdNuevoCaso.Location = new System.Drawing.Point(0, 0);
            this.cmdNuevoCaso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdNuevoCaso.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdNuevoCaso.Name = "cmdNuevoCaso";
            this.cmdNuevoCaso.Primary = false;
            this.cmdNuevoCaso.Size = new System.Drawing.Size(253, 66);
            this.cmdNuevoCaso.TabIndex = 7;
            this.cmdNuevoCaso.Text = "Nuevo caso";
            this.cmdNuevoCaso.UseVisualStyleBackColor = true;
            this.cmdNuevoCaso.Click += new System.EventHandler(this.cmdNuevoCaso_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.cmdNuevoCaso);
            this.panel6.Location = new System.Drawing.Point(1003, 526);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(253, 66);
            this.panel6.TabIndex = 8;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Depth = 0;
            this.lblDescripcion.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDescripcion.Location = new System.Drawing.Point(5, 3);
            this.lblDescripcion.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(0, 19);
            this.lblDescripcion.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.AllowDrop = true;
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.materialLabel3);
            this.panel8.Controls.Add(this.txtDescripcion);
            this.panel8.Controls.Add(this.lblDescripcion);
            this.panel8.Location = new System.Drawing.Point(0, 37);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(990, 92);
            this.panel8.TabIndex = 6;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(5, 1);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(89, 19);
            this.materialLabel3.TabIndex = 14;
            this.materialLabel3.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AllowDrop = true;
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(3, 25);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(984, 64);
            this.txtDescripcion.TabIndex = 11;
            this.txtDescripcion.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDesarrollo_DragDrop);
            this.txtDescripcion.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragEnter_1);
            this.txtDescripcion.DragOver += new System.Windows.Forms.DragEventHandler(this.txtDescripcion_DragOver);
            this.txtDescripcion.DragLeave += new System.EventHandler(this.txtDescripcion_DragLeave);
            // 
            // lblArrastre
            // 
            this.lblArrastre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArrastre.AutoSize = true;
            this.lblArrastre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblArrastre.Depth = 0;
            this.lblArrastre.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblArrastre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblArrastre.Location = new System.Drawing.Point(568, 295);
            this.lblArrastre.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblArrastre.Name = "lblArrastre";
            this.lblArrastre.Size = new System.Drawing.Size(182, 19);
            this.lblArrastre.TabIndex = 10;
            this.lblArrastre.Text = "Arrastre los archivos aquí";
            // 
            // frmReclamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 604);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.lblArrastre);
            this.Name = "frmReclamos";
            this.Text = "Reclamos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.ListBox lstCasos;
        private MaterialSkin.Controls.MaterialLabel lblCasos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chResueltos;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialLabel lblEntidad;
        private System.Windows.Forms.ListBox lstEntidad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialFlatButton cmdNuevoCaso;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialLabel lblResolucion;
        private System.Windows.Forms.Panel panel7;
        private MaterialSkin.Controls.MaterialFlatButton cmdCarpeta;
        private MaterialSkin.Controls.MaterialLabel lblDesarrollo;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private MaterialSkin.Controls.MaterialLabel lblDescripcion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private MaterialSkin.Controls.MaterialFlatButton cmdGuardar;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.TextBox txtDesarrollo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private MaterialSkin.Controls.MaterialLabel lblArrastre;
        private System.Windows.Forms.ComboBox cbEntidades;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}