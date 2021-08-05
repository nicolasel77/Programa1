
namespace Programa1.Carga.Hacienda
{
    partial class frmPagar_Agregados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagar_Agregados));
            this.lblConsignatario = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.grd = new Grilla2.SpeedGrilla();
            this.cmdSalir = new Programa1.Controles.cBoton();
            this.cmdAceptar = new Programa1.Controles.cBoton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConsignatario
            // 
            this.lblConsignatario.AutoSize = true;
            this.lblConsignatario.Depth = 0;
            this.lblConsignatario.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblConsignatario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConsignatario.Location = new System.Drawing.Point(12, 9);
            this.lblConsignatario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblConsignatario.Name = "lblConsignatario";
            this.lblConsignatario.Size = new System.Drawing.Size(103, 19);
            this.lblConsignatario.TabIndex = 0;
            this.lblConsignatario.Text = "Consignatario";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(997, 2);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
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
            this.grd.fColor = System.Drawing.SystemColors.Control;
            this.grd.FixCols = 0;
            this.grd.FixRows = 0;
            this.grd.FuenteEncabezado = null;
            this.grd.FuentePieDePagina = null;
            this.grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grd.Location = new System.Drawing.Point(12, 33);
            this.grd.MenuActivado = false;
            this.grd.Name = "grd";
            this.grd.PieDePagina = "\t\tPage {0} of {1}";
            this.grd.PintarFilaSel = true;
            this.grd.Redraw = true;
            this.grd.Row = 0;
            this.grd.Rows = 50;
            this.grd.Size = new System.Drawing.Size(998, 447);
            this.grd.TabIndex = 2;
            this.grd.Editado += new Grilla2.SpeedGrilla.EditadoEventHandler(this.grd_Editado);
            this.grd.KeyPress += new Grilla2.SpeedGrilla.KeyPressEventHandler(this.grd_KeyPress);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSalir.Location = new System.Drawing.Point(799, 486);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(220, 40);
            this.cmdSalir.TabIndex = 3;
            this.cmdSalir.Texto = "Salir";
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(573, 486);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(220, 40);
            this.cmdAceptar.TabIndex = 3;
            this.cmdAceptar.Texto = "Guardar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tecla + copia el valor actual.";
            // 
            // frmPagar_Agregados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 538);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblConsignatario);
            this.KeyPreview = true;
            this.Name = "frmPagar_Agregados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Agregados";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmPagar_Agregados_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblConsignatario;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grd;
        private Controles.cBoton cmdSalir;
        private Controles.cBoton cmdAceptar;
        private System.Windows.Forms.Label label2;
    }
}