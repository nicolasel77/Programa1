﻿namespace Programa1.Carga.Tesoreria
{

    partial class frmLeer_Tarjetas
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
            this.cmdRuta = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmdCarpeta = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmdGuardar = new MaterialSkin.Controls.MaterialFlatButton();
            this.chAuto = new System.Windows.Forms.CheckBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.dtMaxima = new System.Windows.Forms.DateTimePicker();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.cmdEscribir = new MaterialSkin.Controls.MaterialFlatButton();
            this.cmdCargar_archivo = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tiAuto = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.grdCuentas = new Grilla2.SpeedGrilla();
            this.grdDatos = new Grilla2.SpeedGrilla();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmdRecargar = new MaterialSkin.Controls.MaterialFlatButton();
            this.pbLeer = new System.Windows.Forms.ProgressBar();
            this.lblpb = new System.Windows.Forms.Label();
            this.chclover = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRuta
            // 
            this.cmdRuta.AutoSize = true;
            this.cmdRuta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRuta.BackColor = System.Drawing.SystemColors.Control;
            this.cmdRuta.Depth = 0;
            this.cmdRuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdRuta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRuta.Location = new System.Drawing.Point(0, 0);
            this.cmdRuta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRuta.Name = "cmdRuta";
            this.cmdRuta.Primary = false;
            this.cmdRuta.Size = new System.Drawing.Size(405, 25);
            this.cmdRuta.TabIndex = 2;
            this.cmdRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRuta.UseVisualStyleBackColor = false;
            // 
            // cmdCarpeta
            // 
            this.cmdCarpeta.AutoSize = true;
            this.cmdCarpeta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCarpeta.Depth = 0;
            this.cmdCarpeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarpeta.Location = new System.Drawing.Point(0, 0);
            this.cmdCarpeta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCarpeta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCarpeta.Name = "cmdCarpeta";
            this.cmdCarpeta.Primary = false;
            this.cmdCarpeta.Size = new System.Drawing.Size(215, 25);
            this.cmdCarpeta.TabIndex = 3;
            this.cmdCarpeta.Text = "Carpeta";
            this.cmdCarpeta.UseVisualStyleBackColor = true;
            this.cmdCarpeta.Click += new System.EventHandler(this.cmdCarpeta_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.AutoSize = true;
            this.cmdGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdGuardar.Depth = 0;
            this.cmdGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdGuardar.Location = new System.Drawing.Point(0, 0);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Primary = false;
            this.cmdGuardar.Size = new System.Drawing.Size(90, 25);
            this.cmdGuardar.TabIndex = 4;
            this.cmdGuardar.Text = "Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // chAuto
            // 
            this.chAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAuto.AutoSize = true;
            this.chAuto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chAuto.Location = new System.Drawing.Point(1370, 12);
            this.chAuto.Name = "chAuto";
            this.chAuto.Size = new System.Drawing.Size(46, 17);
            this.chAuto.TabIndex = 11;
            this.chAuto.Text = "Auto";
            this.chAuto.UseVisualStyleBackColor = true;
            this.chAuto.CheckedChanged += new System.EventHandler(this.chAuto_CheckedChanged);
            // 
            // lblSucursal
            // 
            this.lblSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(688, 53);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(0, 16);
            this.lblSucursal.TabIndex = 8;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(685, 393);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(46, 13);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Cuentas";
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(688, 100);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(28, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Tipo";
            // 
            // lstTipo
            // 
            this.lstTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTipo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.ItemHeight = 20;
            this.lstTipo.Location = new System.Drawing.Point(691, 116);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.Size = new System.Drawing.Size(166, 160);
            this.lstTipo.TabIndex = 7;
            this.lstTipo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstTipo_MouseUp);
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(908, 317);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(120, 13);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "Fecha máxima de carga";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(786, 317);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(119, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Fecha mínima de carga";
            // 
            // dtMaxima
            // 
            this.dtMaxima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMaxima.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMaxima.Location = new System.Drawing.Point(911, 336);
            this.dtMaxima.Name = "dtMaxima";
            this.dtMaxima.Size = new System.Drawing.Size(116, 20);
            this.dtMaxima.TabIndex = 12;
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(789, 336);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(116, 20);
            this.dtFecha.TabIndex = 13;
            // 
            // cmdEscribir
            // 
            this.cmdEscribir.AutoSize = true;
            this.cmdEscribir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdEscribir.Depth = 0;
            this.cmdEscribir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdEscribir.Location = new System.Drawing.Point(0, 0);
            this.cmdEscribir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdEscribir.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdEscribir.Name = "cmdEscribir";
            this.cmdEscribir.Primary = false;
            this.cmdEscribir.Size = new System.Drawing.Size(76, 26);
            this.cmdEscribir.TabIndex = 16;
            this.cmdEscribir.Text = "Leer";
            this.cmdEscribir.UseVisualStyleBackColor = true;
            this.cmdEscribir.Click += new System.EventHandler(this.cmdEscribir_Click);
            // 
            // cmdCargar_archivo
            // 
            this.cmdCargar_archivo.AutoSize = true;
            this.cmdCargar_archivo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdCargar_archivo.Depth = 0;
            this.cmdCargar_archivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdCargar_archivo.Location = new System.Drawing.Point(0, 0);
            this.cmdCargar_archivo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdCargar_archivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdCargar_archivo.Name = "cmdCargar_archivo";
            this.cmdCargar_archivo.Primary = false;
            this.cmdCargar_archivo.Size = new System.Drawing.Size(130, 36);
            this.cmdCargar_archivo.TabIndex = 17;
            this.cmdCargar_archivo.Text = "Cargar archivo";
            this.cmdCargar_archivo.UseVisualStyleBackColor = true;
            this.cmdCargar_archivo.Click += new System.EventHandler(this.cmdCargar_archivo_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdGuardar);
            this.panel1.Location = new System.Drawing.Point(688, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 27);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdCarpeta);
            this.panel2.Location = new System.Drawing.Point(688, 363);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 27);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cmdCargar_archivo);
            this.panel3.Location = new System.Drawing.Point(690, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(132, 38);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cmdEscribir);
            this.panel4.Location = new System.Drawing.Point(689, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 28);
            this.panel4.TabIndex = 21;
            // 
            // tiAuto
            // 
            this.tiAuto.Interval = 5000;
            this.tiAuto.Tick += new System.EventHandler(this.tiAuto_Tick);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmdRuta);
            this.panel5.Location = new System.Drawing.Point(911, 363);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(407, 27);
            this.panel5.TabIndex = 22;
            // 
            // lblArchivo
            // 
            this.lblArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(838, 16);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 13);
            this.lblArchivo.TabIndex = 23;
            // 
            // grdCuentas
            // 
            this.grdCuentas.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdCuentas.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCuentas.AutoResize = false;
            this.grdCuentas.bColor = System.Drawing.SystemColors.Window;
            this.grdCuentas.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdCuentas.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdCuentas.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdCuentas.Col = 0;
            this.grdCuentas.Cols = 10;
            this.grdCuentas.DataMember = "";
            this.grdCuentas.DataSource = null;
            this.grdCuentas.EnableEdicion = true;
            this.grdCuentas.Encabezado = "";
            this.grdCuentas.fColor = System.Drawing.Color.Silver;
            this.grdCuentas.FixCols = 0;
            this.grdCuentas.FixRows = 0;
            this.grdCuentas.Frozen = 0;
            this.grdCuentas.FuenteEncabezado = null;
            this.grdCuentas.FuentePieDePagina = null;
            this.grdCuentas.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdCuentas.LimpiarEstilosAntesDeOrdenar = false;
            this.grdCuentas.Location = new System.Drawing.Point(688, 410);
            this.grdCuentas.Name = "grdCuentas";
            this.grdCuentas.PieDePagina = "\t\tPage {0} of {1}";
            this.grdCuentas.PintarFilaSel = true;
            this.grdCuentas.Redraw = true;
            this.grdCuentas.Row = 0;
            this.grdCuentas.Rows = 50;
            this.grdCuentas.Size = new System.Drawing.Size(728, 221);
            this.grdCuentas.TabIndex = 1;
            this.grdCuentas.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grdCuentas_Editado);
            this.grdCuentas.KeyUp += new Grilla2.SpeedGrilla.KeyUpEventHandler(this.grdCuentas_KeyUp);
            // 
            // grdDatos
            // 
            this.grdDatos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdDatos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatos.AutoResize = false;
            this.grdDatos.bColor = System.Drawing.SystemColors.Window;
            this.grdDatos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdDatos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdDatos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdDatos.Col = 0;
            this.grdDatos.Cols = 1;
            this.grdDatos.DataMember = "";
            this.grdDatos.DataSource = null;
            this.grdDatos.EnableEdicion = true;
            this.grdDatos.Encabezado = "";
            this.grdDatos.fColor = System.Drawing.Color.Silver;
            this.grdDatos.FixCols = 0;
            this.grdDatos.FixRows = 0;
            this.grdDatos.Frozen = 0;
            this.grdDatos.FuenteEncabezado = null;
            this.grdDatos.FuentePieDePagina = null;
            this.grdDatos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdDatos.LimpiarEstilosAntesDeOrdenar = false;
            this.grdDatos.Location = new System.Drawing.Point(12, 12);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdDatos.PintarFilaSel = true;
            this.grdDatos.Redraw = true;
            this.grdDatos.Row = 0;
            this.grdDatos.Rows = 1;
            this.grdDatos.Size = new System.Drawing.Size(670, 619);
            this.grdDatos.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(688, 279);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 16);
            this.lblTotal.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cmdRecargar);
            this.panel6.Location = new System.Drawing.Point(1324, 363);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(92, 27);
            this.panel6.TabIndex = 19;
            // 
            // cmdRecargar
            // 
            this.cmdRecargar.AutoSize = true;
            this.cmdRecargar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cmdRecargar.Depth = 0;
            this.cmdRecargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmdRecargar.Location = new System.Drawing.Point(0, 0);
            this.cmdRecargar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmdRecargar.MouseState = MaterialSkin.MouseState.HOVER;
            this.cmdRecargar.Name = "cmdRecargar";
            this.cmdRecargar.Primary = false;
            this.cmdRecargar.Size = new System.Drawing.Size(90, 25);
            this.cmdRecargar.TabIndex = 4;
            this.cmdRecargar.Text = "Recargar";
            this.cmdRecargar.UseVisualStyleBackColor = true;
            this.cmdRecargar.Click += new System.EventHandler(this.cmdRecargar_Click);
            // 
            // pbLeer
            // 
            this.pbLeer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLeer.Location = new System.Drawing.Point(1037, 333);
            this.pbLeer.Name = "pbLeer";
            this.pbLeer.Size = new System.Drawing.Size(275, 23);
            this.pbLeer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLeer.TabIndex = 25;
            this.pbLeer.Visible = false;
            // 
            // lblpb
            // 
            this.lblpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpb.AutoSize = true;
            this.lblpb.Location = new System.Drawing.Point(1034, 317);
            this.lblpb.Name = "lblpb";
            this.lblpb.Size = new System.Drawing.Size(52, 13);
            this.lblpb.TabIndex = 26;
            this.lblpb.Text = "Progreso:";
            this.lblpb.Visible = false;
            // 
            // chclover
            // 
            this.chclover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chclover.AutoSize = true;
            this.chclover.Depth = 0;
            this.chclover.Font = new System.Drawing.Font("Roboto", 10F);
            this.chclover.Location = new System.Drawing.Point(1324, 329);
            this.chclover.Margin = new System.Windows.Forms.Padding(0);
            this.chclover.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chclover.MouseState = MaterialSkin.MouseState.HOVER;
            this.chclover.Name = "chclover";
            this.chclover.Ripple = true;
            this.chclover.Size = new System.Drawing.Size(69, 30);
            this.chclover.TabIndex = 27;
            this.chclover.Text = "Clover";
            this.chclover.UseVisualStyleBackColor = true;
            // 
            // frmLeer_Tarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 643);
            this.Controls.Add(this.chclover);
            this.Controls.Add(this.lblpb);
            this.Controls.Add(this.pbLeer);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtMaxima);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chAuto);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lstTipo);
            this.Controls.Add(this.grdCuentas);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.panel3);
            this.Name = "frmLeer_Tarjetas";
            this.Text = "Leer_Tarjetas";
            this.Load += new System.EventHandler(this.frmLeer_Tarjetas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grilla2.SpeedGrilla grdDatos;
        private Grilla2.SpeedGrilla grdCuentas;
        private MaterialSkin.Controls.MaterialFlatButton cmdRuta;
        private MaterialSkin.Controls.MaterialFlatButton cmdCarpeta;
        private MaterialSkin.Controls.MaterialFlatButton cmdGuardar;
        internal System.Windows.Forms.CheckBox chAuto;
        internal System.Windows.Forms.Label lblSucursal;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstTipo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DateTimePicker dtMaxima;
        internal System.Windows.Forms.DateTimePicker dtFecha;
        private MaterialSkin.Controls.MaterialFlatButton cmdEscribir;
        private MaterialSkin.Controls.MaterialFlatButton cmdCargar_archivo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Timer tiAuto;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label lblArchivo;
        internal System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel6;
        private MaterialSkin.Controls.MaterialFlatButton cmdRecargar;
        private System.Windows.Forms.ProgressBar pbLeer;
        internal System.Windows.Forms.Label lblpb;
        private MaterialSkin.Controls.MaterialCheckBox chclover;
    }
}