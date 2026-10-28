namespace Programa1.Carga.Tesoreria
{
    using Herramientas;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmTarjetas : Form
    {
        public Tarjetas tarjetas = new Tarjetas();
        public Tipos_Tarjeta t_tarjetas = new Tipos_Tarjeta();
        public Cuentas cuentas = new Cuentas();
        public frmTarjetas()
        {
            InitializeComponent();
        }

        private void frmTarjetas_Load(object sender, EventArgs e)
        {
            Herramientas h = new Herramientas();
            h.Llenar_List(lstTipos, t_tarjetas.Datos());
            h.Llenar_List(lstCuentas, cuentas.Datos_Genericos("SELECT Titular FROM dbGastos.dbo.vw_SucCuentas GROUP BY Titular ORDER BY Titular"));
            //Esto es para que la primera vez que se filtre no tire filas vacias
            chTipo.Checked = true;

            grdTarjetas.TeclasManejadas = new int[] { 46 };
        }

        private void Cargar()
        {
            grdTarjetas.MostrarDatos(tarjetas.Datos_Resumen(), true, true);
            if (grdTarjetas.Rows > 0)
            {
                int c_imp = grdTarjetas.get_ColIndex("Importe");
                if (c_imp > 0)
                {
                    if (grdTarjetas.Cols > 0) { grdTarjetas.Columnas[c_imp].Style.Format = "N2"; }
                                        
                    lblTotal.Text = grdTarjetas.SumarCol(grdTarjetas.get_ColIndex("Importe"),false).ToString("C1");
                    grdTarjetas.AutosizeAll();
                }
            }
        }
        private void cargarfiltros()
        {
            Herramientas h = new Herramientas();
            tarjetas.Fecha = cFecha.Cadena();
            tarjetas.sucs = cSuc.Cadena("Suc");
            tarjetas.Tipos = h.Codigos_Seleccionados(lstTipos);
            tarjetas.Agrupar = Convert.ToBoolean(chAgrupar.CheckState);
            tarjetas.aSucs = Convert.ToBoolean(chSuc.CheckState);
            tarjetas.aFecha = Convert.ToBoolean(chFecha.CheckState);
            tarjetas.aTipo = Convert.ToBoolean(chTipo.CheckState);
            tarjetas.aAcreditados = Convert.ToBoolean(chAcreditados.CheckState);
            tarjetas.OrdenxSuc = rdOrdenPorSuc.Checked;
            Cargar();
        }

        private void chAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            if (chAgrupar.Checked == false)
            {
                chFecha.Enabled = false;
                chSuc.Enabled = false;
                chTipo.Enabled = false;
            }
            else
            {
                chFecha.Enabled = true;
                chSuc.Enabled = true;
                chTipo.Enabled = true;
            }
            cargarfiltros();
        }

        private void chSuc_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chFecha_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chTipo_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void cSuc_Cambio_Seleccion(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void lstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void chAcreditados_CheckedChanged(object sender, EventArgs e)
        {
            cargarfiltros();
        }

        private void rdOrdenPorSuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOrdenPorSuc.Checked == true) { rdOrdenxFecha.Checked = false; }
            cargarfiltros();
        }

        private void lstTipos_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) { lstTipos.SelectedIndex = -1; }
        }

        private void rdOrdenxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOrdenxFecha.Checked == true) { rdOrdenPorSuc.Checked = false; }
        }

        private void grdTarjetas_Load(object sender, EventArgs e)
        {
            grdTarjetas.BorrarFila();
        }

        private void lstCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCuentas.SelectedIndex == -1)
            {
                string n = "";
                DataTable dt = cuentas.Datos_Genericos($"SELECT Suc FROM dbGastos.dbo.Suc_Cuentas GROUP BY Suc ORDER BY Suc");
                foreach (DataRow dr in dt.Rows)
                {
                    n = $"{n}, {dr[0]}";
                }
                cSuc.Filtro_In = n.Substring(2);
            }
            else
            {
                string n = "";
                DataTable dt = cuentas.Datos_Genericos($"SELECT Suc FROM dbGastos.dbo.Suc_Cuentas WHERE Titular LIKE '{lstCuentas.Text}' GROUP BY Suc ORDER BY Suc");
                foreach (DataRow dr in dt.Rows)
                {
                    n = $"{n}, {dr[0]}";
                }
                cSuc.Filtro_In = n.Substring(2);
            }
        }

        private void cmdAjustes_Click(object sender, EventArgs e)
        {
            if (cFecha.fecha_Actual > DateTime.Now.AddDays(-21))
            {
                tarjetas.Ejecutar_Comando($"DELETE FROM dbgastos.dbo.Entradas_Tarjeta WHERE suc = 0 AND {cFecha.Cadena()}");
                Cargar();
            }
            else
            { MessageBox.Show("No se pueden borrar registros tan viejos!", "No permitido", MessageBoxButtons.OK); }
        }

        private void grdTarjetas_Editado(short f, short c, object a)
        {
            if (f == grdTarjetas.Rows - 1)
            {
                switch (c)
                {
                    case 0:
                        // Fecha
                        grdTarjetas.set_Texto(f, c, a);
                        grdTarjetas.ActivarCelda(f, 1);
                        break;
                    case 1:
                        // Suc
                        object n = tarjetas.Dato_Generico("Sucursales", "ID=" + Convert.ToInt16(a), "Nombre");
                        if (n != null)
                        {
                            grdTarjetas.set_Texto(f, c, a);
                            grdTarjetas.set_Texto(f, c + 1, n);

                            grdTarjetas.ActivarCelda(f, 3);
                        }
                        else
                        {
                            grdTarjetas.ErrorEnTxt();
                        }
                        break;
                    case 3:
                        // Tipo Tarjeta
                        object t = tarjetas.Dato_Generico("dbGastos.dbo.Tipo_Cuentas", "ID=" + Convert.ToInt16(a), "Nombre");
                        if (t != null)
                        {
                            grdTarjetas.set_Texto(f, c, a);
                            grdTarjetas.set_Texto(f, c + 1, t);
                            grdTarjetas.ActivarCelda(f, 5);
                        }
                        else
                        {
                            grdTarjetas.ErrorEnTxt();
                        }
                        break;
                    case 5:
                        // Importe

                        // Verificar que se haya ingresado la fecha, sucursal y tipo de tarjeta
                        if (Convert.ToDateTime(grdTarjetas.get_Texto(f, 0)).Year > 2000 && Convert.ToInt16( grdTarjetas.get_Texto(f, 1)) != 0 && Convert.ToInt16(grdTarjetas.get_Texto(f, 3)) != 0)
                        {
                            grdTarjetas.set_Texto(f, c, a);

                            // Insertar en la base de datos
                            tarjetas.Ejecutar_Comando($"INSERT INTO dbgastos.dbo.Entradas_Tarjeta (Fecha, Suc, Id_Tipo, Importe, Lote, Tarjeta, Comprobante) " +
                                $"VALUES ('{Convert.ToDateTime(grdTarjetas.get_Texto(f, 0)):MM/dd/yyy}', {Convert.ToInt16(grdTarjetas.get_Texto(f, 1))}, " +
                                $"{Convert.ToInt16(grdTarjetas.get_Texto(f, 3))}, {Convert.ToDecimal(a).ToString().Replace(",",".")}, 0, 0, 0)");
                            // Agregar una nueva fila
                            grdTarjetas.AgregarFila();
                            grdTarjetas.ActivarCelda(f + 1, 0);
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar Fecha, Sucursal y Tipo de Tarjeta antes del Importe.", "Faltan datos", MessageBoxButtons.OK);                            
                        }

                        break;
                }
            }
        }

        private void grdTarjetas_KeyUp(object sender, short e)
        {
            if(e == 46)
            {
                // Eliminar fila
                if (grdTarjetas.Rows > 0 && grdTarjetas.Row > -1 && grdTarjetas.Row < grdTarjetas.Rows - 1)
                {
                    // Obtener los datos de la fila seleccionada
                    DateTime fecha = Convert.ToDateTime(grdTarjetas.get_Texto(grdTarjetas.Row, 0));
                    int suc = Convert.ToInt16(grdTarjetas.get_Texto(grdTarjetas.Row, 1));
                    int tipo = Convert.ToInt16(grdTarjetas.get_Texto(grdTarjetas.Row, 3));
                    decimal importe = Convert.ToDecimal(grdTarjetas.get_Texto(grdTarjetas.Row, 5));
                    // Eliminar de la base de datos
                    tarjetas.Ejecutar_Comando($"DELETE TOP(1) FROM dbgastos.dbo.Entradas_Tarjeta WHERE Fecha = '{fecha:MM/dd/yyy}' AND Suc = {suc} " +
                        $"AND Id_Tipo = {tipo} AND Importe = {importe.ToString().Replace(",", ".")}");
                    // Recargar los datos
                    grdTarjetas.BorrarFila();
                }
            }
        }
    }
}