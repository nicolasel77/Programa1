
namespace Programa1.Carga.Varios
{
    partial class frmCapitalDeTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapitalDeTrabajo));
            this.split1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblTotales = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grdActivos = new Grilla2.SpeedGrilla();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.grdPasivos = new Grilla2.SpeedGrilla();
            this.label1 = new System.Windows.Forms.Label();
            this.grdResultado = new Grilla2.SpeedGrilla();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSemanas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.split1)).BeginInit();
            this.split1.Panel1.SuspendLayout();
            this.split1.Panel2.SuspendLayout();
            this.split1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // split1
            // 
            this.split1.BackColor = System.Drawing.Color.Gainsboro;
            this.split1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split1.Location = new System.Drawing.Point(0, 0);
            this.split1.Name = "split1";
            // 
            // split1.Panel1
            // 
            this.split1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // split1.Panel2
            // 
            this.split1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.split1.Panel2.Controls.Add(this.lstSemanas);
            this.split1.Size = new System.Drawing.Size(1359, 727);
            this.split1.SplitterDistance = 1220;
            this.split1.SplitterWidth = 8;
            this.split1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblTotales);
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdResultado);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1220, 727);
            this.splitContainer2.SplitterDistance = 832;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblTotales
            // 
            this.lblTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotales.AutoSize = true;
            this.lblTotales.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblTotales.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblTotales.Location = new System.Drawing.Point(3, 700);
            this.lblTotales.Name = "lblTotales";
            this.lblTotales.Size = new System.Drawing.Size(41, 18);
            this.lblTotales.TabIndex = 1;
            this.lblTotales.Text = "Total";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.grdActivos);
            this.splitContainer3.Panel1.Controls.Add(this.lblEntradas);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.grdPasivos);
            this.splitContainer3.Panel2.Controls.Add(this.label1);
            this.splitContainer3.Size = new System.Drawing.Size(826, 694);
            this.splitContainer3.SplitterDistance = 435;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.TabIndex = 0;
            // 
            // grdActivos
            // 
            this.grdActivos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdActivos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdActivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdActivos.AutoResize = false;
            this.grdActivos.bColor = System.Drawing.SystemColors.Window;
            this.grdActivos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdActivos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdActivos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdActivos.Col = 0;
            this.grdActivos.Cols = 1;
            this.grdActivos.DataMember = "";
            this.grdActivos.DataSource = null;
            this.grdActivos.EnableEdicion = false;
            this.grdActivos.Encabezado = "";
            this.grdActivos.fColor = System.Drawing.SystemColors.Control;
            this.grdActivos.FixCols = 0;
            this.grdActivos.FixRows = 0;
            this.grdActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdActivos.FuenteEncabezado = null;
            this.grdActivos.FuentePieDePagina = null;
            this.grdActivos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdActivos.Location = new System.Drawing.Point(3, 21);
            this.grdActivos.MenuActivado = false;
            this.grdActivos.Name = "grdActivos";
            this.grdActivos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdActivos.PintarFilaSel = false;
            this.grdActivos.Redraw = true;
            this.grdActivos.Row = 0;
            this.grdActivos.Rows = 1;
            this.grdActivos.Size = new System.Drawing.Size(429, 670);
            this.grdActivos.TabIndex = 2;
            // 
            // lblEntradas
            // 
            this.lblEntradas.AutoSize = true;
            this.lblEntradas.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblEntradas.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.lblEntradas.Location = new System.Drawing.Point(3, 0);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(56, 18);
            this.lblEntradas.TabIndex = 1;
            this.lblEntradas.Text = "Activos";
            // 
            // grdPasivos
            // 
            this.grdPasivos.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdPasivos.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdPasivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPasivos.AutoResize = false;
            this.grdPasivos.bColor = System.Drawing.SystemColors.Window;
            this.grdPasivos.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdPasivos.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdPasivos.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdPasivos.Col = 0;
            this.grdPasivos.Cols = 10;
            this.grdPasivos.DataMember = "";
            this.grdPasivos.DataSource = null;
            this.grdPasivos.EnableEdicion = false;
            this.grdPasivos.Encabezado = "";
            this.grdPasivos.fColor = System.Drawing.SystemColors.Control;
            this.grdPasivos.FixCols = 0;
            this.grdPasivos.FixRows = 0;
            this.grdPasivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPasivos.FuenteEncabezado = null;
            this.grdPasivos.FuentePieDePagina = null;
            this.grdPasivos.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdPasivos.Location = new System.Drawing.Point(3, 21);
            this.grdPasivos.MenuActivado = false;
            this.grdPasivos.Name = "grdPasivos";
            this.grdPasivos.PieDePagina = "\t\tPage {0} of {1}";
            this.grdPasivos.PintarFilaSel = false;
            this.grdPasivos.Redraw = true;
            this.grdPasivos.Row = 0;
            this.grdPasivos.Rows = 50;
            this.grdPasivos.Size = new System.Drawing.Size(377, 670);
            this.grdPasivos.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label1.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasivos";
            // 
            // grdResultado
            // 
            this.grdResultado.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;
            this.grdResultado.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
            this.grdResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResultado.AutoResize = false;
            this.grdResultado.bColor = System.Drawing.SystemColors.Window;
            this.grdResultado.bColorSel = System.Drawing.SystemColors.Highlight;
            this.grdResultado.bFColor = System.Drawing.SystemColors.WindowText;
            this.grdResultado.bFColorSel = System.Drawing.SystemColors.HighlightText;
            this.grdResultado.Col = 0;
            this.grdResultado.Cols = 10;
            this.grdResultado.DataMember = "";
            this.grdResultado.DataSource = null;
            this.grdResultado.EnableEdicion = false;
            this.grdResultado.Encabezado = "";
            this.grdResultado.fColor = System.Drawing.SystemColors.Control;
            this.grdResultado.FixCols = 0;
            this.grdResultado.FixRows = 0;
            this.grdResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdResultado.FuenteEncabezado = null;
            this.grdResultado.FuentePieDePagina = null;
            this.grdResultado.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.grdResultado.Location = new System.Drawing.Point(3, 24);
            this.grdResultado.MenuActivado = false;
            this.grdResultado.Name = "grdResultado";
            this.grdResultado.PieDePagina = "\t\tPage {0} of {1}";
            this.grdResultado.PintarFilaSel = false;
            this.grdResultado.Redraw = true;
            this.grdResultado.Row = 0;
            this.grdResultado.Rows = 50;
            this.grdResultado.Size = new System.Drawing.Size(374, 670);
            this.grdResultado.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::Programa1.Properties.Settings.Default, "lblTitulos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label2.Font = global::Programa1.Properties.Settings.Default.lblTitulos;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Resultado";
            // 
            // lstSemanas
            // 
            this.lstSemanas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSemanas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSemanas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSemanas.FormattingEnabled = true;
            this.lstSemanas.ItemHeight = 20;
            this.lstSemanas.Items.AddRange(new object[] {
            "20/12/1977"});
            this.lstSemanas.Location = new System.Drawing.Point(12, 12);
            this.lstSemanas.Name = "lstSemanas";
            this.lstSemanas.Size = new System.Drawing.Size(107, 700);
            this.lstSemanas.TabIndex = 0;
            this.lstSemanas.SelectedIndexChanged += new System.EventHandler(this.lstSemanas_SelectedIndexChanged);
            // 
            // frmCapitalDeTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 727);
            this.Controls.Add(this.split1);
            this.Name = "frmCapitalDeTrabajo";
            this.Text = "Capital De Trabajo";
            this.split1.Panel1.ResumeLayout(false);
            this.split1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split1)).EndInit();
            this.split1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblTotales;
        private Grilla2.SpeedGrilla grdActivos;
        private System.Windows.Forms.Label lblEntradas;
        private Grilla2.SpeedGrilla grdPasivos;
        private System.Windows.Forms.Label label1;
        private Grilla2.SpeedGrilla grdResultado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSemanas;
    }
}