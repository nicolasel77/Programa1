namespace Programa1.Carga.Precios
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmPromedios_Carne : Form
    {
        Promedios_Carne promedios = new Promedios_Carne();

        public frmPromedios_Carne()
        {
            InitializeComponent();
        }

        private void frmPromedios_Carne_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            grdProme.MostrarDatos(promedios.datosunidos(), true);
            grdProme.AgregarCol();
            grdProme.MostrarDatos_acostado(promedios.Datos_prom());
            Formato_Grilla();

            lstFechas.Items.Clear();
            DataTable dt = promedios.Fechas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstFechas, dt, "dd/MM/yyy");

        grdProme.set_Texto(grdProme.Rows - 1, 7, grdProme.SumarCol(7, true, 2).ToString("$#,##0.00"));

            if (grdProme.Cols > 9)
            {
                dt = promedios.Nombres_list();
                int j = 0;
                for (int i = 10; i <= grdProme.Cols - 1; i++)
                {
                    grdProme.set_Texto(0, i, dt.Rows[j][0]);
                    j = j + 1;
                }
            }
        }

        private void Formato_Grilla()
        {
            grdProme.set_Texto(1, 4, 100);
            for (int i = 2; i <= grdProme.Cols - 1; i++)
            {
                grdProme.set_ColW(i, 50);
            }

            grdProme.Columnas[2].Format = "N3";
            grdProme.Columnas[4].Format = "N3";
            grdProme.Columnas[5].Format = "C2";
            grdProme.Columnas[6].Format = "C2";
            grdProme.Columnas[7].Format = "C2";

            grdProme.Columnas[8].Format = "N3";

            for (int i = 10; i < grdProme.Cols; i++)
            {
                grdProme.Columnas[i].Format = "N3";
            }
            grdProme.AutosizeAll();
            grdProme.set_ColW(0, 0);
            grdProme.set_ColW(2, 60);
            grdProme.set_ColW(4, 60);
            grdProme.set_ColW(6, 100);
            grdProme.set_ColW(7, 85);
            grdProme.set_ColW(8, 65);
            grdProme.set_Texto(0, 7, "Promedio");
            grdProme.set_Texto(0, 8, "Sistema");
        }

        private void grdProme_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 2:
                    if (Convert.ToInt32(f) > 1)
                    {
                        if (Convert.ToDouble(grdProme.get_Texto(1, c)) > 0)
                        {
                            grdProme.set_Texto(f, c, a);
                            grdProme.set_Texto(f, c + 1, (Convert.ToDouble(a) * 100 / Convert.ToDouble(grdProme.get_Texto(1, c))).ToString("0.00 '%'"));
                            grdProme.set_Texto(f, c + 2, Convert.ToDouble(grdProme.get_Texto(f, c)) * 100 / Convert.ToDouble(grdProme.get_Texto(1, c)));
                            grdProme.set_Texto(f, c + 4, Math.Round(Convert.ToDouble(grdProme.get_Texto(f, c + 3)),3) * Math.Round(Convert.ToDouble(grdProme.get_Texto(f, c + 2)),3));

                            grdProme.set_Texto(grdProme.Rows - 1, c, 0);
                            grdProme.set_Texto(grdProme.Rows - 1, c, grdProme.SumarCol(2, true, 2));
                            grdProme.set_Texto(grdProme.Rows - 1, 4, 0);
                            grdProme.set_Texto(grdProme.Rows - 1, 4, grdProme.SumarCol(4, true, 2));
                            grdProme.set_Texto(grdProme.Rows - 1, 6, 0);
                            grdProme.set_Texto(grdProme.Rows - 1, 6, grdProme.SumarCol(6, true, 2));
                        }
                    }
                    if (Convert.ToInt32(f) == 1)
                    {
                        grdProme.set_Texto(f, c, a);

                        for (int i = 2; i <= grdProme.Rows - 2; i++)
                        {
                            grdProme.set_Texto(i, c + 1, (Convert.ToDouble(grdProme.get_Texto(i, c)) * 100 / Convert.ToDouble(grdProme.get_Texto(1, c))).ToString("0.00 '%'"));
                            grdProme.set_Texto(i, c + 2, Convert.ToDouble(grdProme.get_Texto(i, c)) * 100 / Convert.ToDouble(a));
                            grdProme.set_Texto(i, c + 4, Math.Round(Convert.ToDouble(grdProme.get_Texto(i, c + 3)),3) * Math.Round(Convert.ToDouble(grdProme.get_Texto(i, c + 2)),3));
                            grdProme.set_Texto(i, 7, (Convert.ToDouble(grdProme.get_Texto(i, 5)) * Convert.ToDouble(grdProme.get_Texto(i, 8))).ToString("$#,##0.00"));
                        }
                        grdProme.set_Texto(grdProme.Rows - 1, 4, 0);
                        grdProme.set_Texto(grdProme.Rows - 1, 4, grdProme.SumarCol(4, true, 2));
                        grdProme.set_Texto(grdProme.Rows - 1, 6, 0);
                        grdProme.set_Texto(grdProme.Rows - 1, 6, grdProme.SumarCol(6, true, 2));
                    }
                    break;
                case 5:
                    grdProme.set_Texto(f, c, a);
                    grdProme.set_Texto(f, 6, Convert.ToDouble(a) * Convert.ToDouble(grdProme.get_Texto(f, c - 1)));

                    grdProme.set_Texto(f, 7, Convert.ToDouble(grdProme.get_Texto(f, 8)) * Convert.ToDouble(a));

                    grdProme.set_Texto(grdProme.Rows - 1, 6, 0);
                    grdProme.set_Texto(grdProme.Rows - 1, 6, grdProme.SumarCol(6, true, 2));
                    grdProme.set_Texto(grdProme.Rows - 1, 7, 0);
                    grdProme.set_Texto(grdProme.Rows - 1, 7, grdProme.SumarCol(7, true, 2).ToString("$#,##0.00"));
                    break;
                case 8:
                    grdProme.set_Texto(f, c, a);
                    grdProme.set_Texto(f, c - 1, (Convert.ToDouble(a) * Convert.ToDouble(grdProme.get_Texto(f, 5))).ToString("$#,##0.00"));
                    grdProme.set_Texto(grdProme.Rows - 1, 7, 0);
                    grdProme.set_Texto(grdProme.Rows - 1, 7, grdProme.SumarCol(7, true, 2).ToString("$#,##0.00"));
                    break;
            }
            grdProme.ActivarCelda(f + 1, c);
        }

        private void grdProme_CambioColumna(int col)
        {
            if ((col == 2 | col == 5 | col == 8) & grdProme.Row <= grdProme.Rows - 2)
            { grdProme.EnableEdicion = true; }
            else
            { grdProme.EnableEdicion = false; }
        }

        private void cmdGuardar_Click_1(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            txtNombre.Focus();

            if (txtNombre.Text.Length > 0)
            {
                promedios.Agregar_List(txtNombre.Text);
                int id_lista = promedios.nvo_idlista();
                for (int i = 1; i < grdProme.Rows - 1; i++)
                {
                    promedios.Producto.ID = Convert.ToInt32(grdProme.get_Texto(i, 0));
                    promedios.Kilos = Convert.ToDouble(grdProme.get_Texto(i, 2));
                    promedios.Agregar_Prom(id_lista);
                }
                grdProme.BorrarFila(grdProme.Rows - 1);
                grdProme.AgregarFila();

                grdProme.set_Texto(1, 4, 100);
                grdProme.Cols = 9;

                //DataTable dt = promedios.Datos_Totales();

                for (int i = 1; i <= grdProme.Rows - 2; i++)
                {
                    grdProme.set_Texto(i, 2, 0);
                    grdProme.set_Texto(i, 3, (0).ToString("0.00 '%'"));
                    grdProme.set_Texto(i, 4, 0);
                    grdProme.set_Texto(i, 6, 0);
                    //grdProme.set_Texto(i, 8, dt.Rows[i - 1][2]);
                    //grdProme.set_Texto(i, 7, (Convert.ToDouble(grdProme.get_Texto(i, 5)) * Convert.ToDouble(grdProme.get_Texto(i, 8))).ToString("$#,##0.00"));
                }
                //grdProme.set_Texto(grdProme.Rows - 1, 7, grdProme.SumarCol(7, true, 2).ToString("$#,##0.00"));

                grdProme.AgregarCol();
                grdProme.MostrarDatos_acostado(promedios.Datos_prom());
                Formato_Grilla();
                DataTable dt;
                if (grdProme.Cols > 9)
                {
                    dt = promedios.Nombres_list();
                    int j = 0;
                    for (int i = 10; i <= grdProme.Cols - 1; i++)
                    {
                        grdProme.set_Texto(0, i, dt.Rows[j][0]);
                        j = j + 1;
                    }
                }

                txtNombre.Text = "";
            }
        }

        private void cmdCargarPrecios_Click(object sender, EventArgs e)
        {
            //panel3.Visible = true;
        }

        private void grdProme_Click()
        {
            //panel3.Visible = false;
            //panel4.Visible = false;
        }

        private void Csucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            if (lstFechas.SelectedIndex > 0)
            { cargar_Precios(); }
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Csucs.Valor_Actual > 0)
            { cargar_Precios(); }
        }

        private void cargar_Precios()

        {
            DataTable dt = promedios.lista_precios(Csucs.Cadena("Id_Sucursales"), Convert.ToDateTime(lstFechas.SelectedItem));
            double precio;
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                precio = Convert.ToDouble(dt.Rows[i - 1][1]);
                grdProme.set_Texto(i, 5, precio);
                if (i > 1)
                {
                    grdProme.set_Texto(i, 6, Convert.ToDouble(grdProme.get_Texto(i, 4)) * precio);
                }
                grdProme.set_Texto(i, 7, Convert.ToDouble(grdProme.get_Texto(i, 8)) * precio);
            }
            grdProme.set_Texto(grdProme.Rows - 1, 6, 0);
            grdProme.set_Texto(grdProme.Rows - 1, 6, grdProme.SumarCol(6, true, 2));
            grdProme.set_Texto(grdProme.Rows - 1, 7, 0);
            grdProme.set_Texto(grdProme.Rows - 1, 7, grdProme.SumarCol(7, true, 2).ToString("$#,##0.00"));
        }

        private void frmPromedios_Carne_Click(object sender, EventArgs e)
        {
            //panel3.Visible = false;
        }

        private void grdProme_CambioFila(short Fila)
        {
            if (Fila <= grdProme.Rows - 2 & (grdProme.Col == 2 | grdProme.Col == 5 | grdProme.Col == 8))
            { grdProme.EnableEdicion = true; }
            else
            { grdProme.EnableEdicion = false; }
        }

        private void txtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Guardar();
            }
        }
    }
}