namespace Programa1.Controles
{

    partial class cHerramientas
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
            this.rdFecha = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdNada = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdSuc = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdProv = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdProd = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // rdFecha
            // 
            this.rdFecha.AutoSize = true;
            this.rdFecha.Depth = 0;
            this.rdFecha.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdFecha.Location = new System.Drawing.Point(7, 19);
            this.rdFecha.Margin = new System.Windows.Forms.Padding(0);
            this.rdFecha.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdFecha.Name = "rdFecha";
            this.rdFecha.Ripple = true;
            this.rdFecha.Size = new System.Drawing.Size(66, 30);
            this.rdFecha.TabIndex = 1;
            this.rdFecha.Text = "Fecha";
            this.rdFecha.UseVisualStyleBackColor = true;
            this.rdFecha.CheckedChanged += new System.EventHandler(this.rdFecha_CheckedChanged);
            // 
            // rdNada
            // 
            this.rdNada.AutoSize = true;
            this.rdNada.Depth = 0;
            this.rdNada.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdNada.Location = new System.Drawing.Point(184, 19);
            this.rdNada.Margin = new System.Windows.Forms.Padding(0);
            this.rdNada.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdNada.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdNada.Name = "rdNada";
            this.rdNada.Ripple = true;
            this.rdNada.Size = new System.Drawing.Size(61, 30);
            this.rdNada.TabIndex = 2;
            this.rdNada.Text = "Nada";
            this.rdNada.UseVisualStyleBackColor = true;
            this.rdNada.CheckedChanged += new System.EventHandler(this.rdNada_CheckedChanged);
            // 
            // rdSuc
            // 
            this.rdSuc.AutoSize = true;
            this.rdSuc.Depth = 0;
            this.rdSuc.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdSuc.Location = new System.Drawing.Point(99, 19);
            this.rdSuc.Margin = new System.Windows.Forms.Padding(0);
            this.rdSuc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdSuc.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdSuc.Name = "rdSuc";
            this.rdSuc.Ripple = true;
            this.rdSuc.Size = new System.Drawing.Size(83, 30);
            this.rdSuc.TabIndex = 3;
            this.rdSuc.Text = "Sucursal";
            this.rdSuc.UseVisualStyleBackColor = true;
            this.rdSuc.CheckedChanged += new System.EventHandler(this.rdSuc_CheckedChanged);
            // 
            // rdProv
            // 
            this.rdProv.AutoSize = true;
            this.rdProv.Depth = 0;
            this.rdProv.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdProv.Location = new System.Drawing.Point(7, 49);
            this.rdProv.Margin = new System.Windows.Forms.Padding(0);
            this.rdProv.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdProv.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdProv.Name = "rdProv";
            this.rdProv.Ripple = true;
            this.rdProv.Size = new System.Drawing.Size(92, 30);
            this.rdProv.TabIndex = 4;
            this.rdProv.Text = "Proveedor";
            this.rdProv.UseVisualStyleBackColor = true;
            this.rdProv.CheckedChanged += new System.EventHandler(this.rdProv_CheckedChanged);
            // 
            // rdProd
            // 
            this.rdProd.AutoSize = true;
            this.rdProd.Checked = true;
            this.rdProd.Depth = 0;
            this.rdProd.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdProd.Location = new System.Drawing.Point(99, 49);
            this.rdProd.Margin = new System.Windows.Forms.Padding(0);
            this.rdProd.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdProd.Name = "rdProd";
            this.rdProd.Ripple = true;
            this.rdProd.Size = new System.Drawing.Size(85, 30);
            this.rdProd.TabIndex = 5;
            this.rdProd.TabStop = true;
            this.rdProd.Text = "Producto";
            this.rdProd.UseVisualStyleBackColor = true;
            this.rdProd.CheckedChanged += new System.EventHandler(this.rdProd_CheckedChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(3, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(93, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Incrementar:";
            // 
            // cHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.rdProd);
            this.Controls.Add(this.rdProv);
            this.Controls.Add(this.rdSuc);
            this.Controls.Add(this.rdNada);
            this.Controls.Add(this.rdFecha);
            this.Name = "cHerramientas";
            this.Size = new System.Drawing.Size(289, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRadioButton rdFecha;
        private MaterialSkin.Controls.MaterialRadioButton rdNada;
        private MaterialSkin.Controls.MaterialRadioButton rdSuc;
        private MaterialSkin.Controls.MaterialRadioButton rdProv;
        private MaterialSkin.Controls.MaterialRadioButton rdProd;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
