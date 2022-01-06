using Programa1.Clases;
using Programa1.DB;
using Programa1.DB.Varios;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Programa1.Carga.Hacienda
{
    public partial class frmSincronizarAccess : Form
    {
        readonly Datos_Genericos datos = new Datos_Genericos();
        public frmSincronizarAccess()
        {
            InitializeComponent();

            datos.Vista = "Configuraciones";
            string s = (string)datos.Dato("Dato LIKE 'dbStock.accdb'", "Valor", "");
            if (s != "")
            {
                string pathh = $"{s}\\dbStock.accdb";
                if (File.Exists(pathh) == true)
                {
                    cmdBase.Text = pathh;
                }
                else
                {
                    cmdBase.Text = @"D:\GDrive\dbStock.accdb";
                }
            }
            else
            {
                cmdBase.Text = "";
            }
            Cargar_Listados();

            string f = datos.Dato_Generico("SELECT MAX(Fecha) FROM Hacienda_Salidas").ToString();
            DateTime d = DateTime.Today;

            if (DateTime.TryParse(f, out d) == true)
            {
                mDesde.Value = d;
            }
            mHasta.Value = d.AddDays(5);
        }

        private void Cargar_Listados()
        {
            Cargar_ListadoSalidas();
            Cargar_ListadosBoletas();
            lstActualizacion.Items.Clear();
        }

        private void Cargar_ListadosBoletas()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            lstBoletas.Items.Clear();

            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Campo_ID = "NBoleta";
            clsAccess.Base_Access = cmdBase.Text;

            DataTable dt = clsAccess.Datos_Vista("", "TOP 100 NBoleta, (SELECT COUNT(Fecha) FROM Faena WHERE Faena.NBoleta=NBoletas.NBoleta) AS Medias", "NBoleta DESC");
            lstBoletas.Items.Clear();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lstBoletas.Items.Add($"{dr[0]}  {(Convert.ToInt32(dr[1]) == 0 ? "0 medias" : "")}");
                }
            }
            dt = datos.Datos_Genericos("SELECT TOP 100 NBoleta, ISNULL((SELECT COUNT(*) FROM Faena WHERE Faena.NBoleta=NBoletas.NBoleta), 0) AS Medias FROM NBoletas ORDER BY NBoleta DESC");
            lstSistema.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstSistema.Items.Add($"{dr[0]}  {(Convert.ToInt32(dr[1]) == 0 ? "0 medias" : "")}");
            }
        }

        private void Cargar_ListadoSalidas()
        {
            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Base_Access = cmdBase.Text;

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            clsAccess.Vista = "Salidas";
            h.Llenar_List(lstFechasAcc, clsAccess.Datos_Vista("", "TOP 50 Fecha", "Fecha DESC", "Fecha"), "dd/MM/yy");
            h.Llenar_List(lstFechasSis, datos.Datos_Genericos("SELECT TOP 100 Fecha FROM Hacienda_Salidas GROUP BY Fecha ORDER BY Fecha DESC"), "dd/MM/yy");
        }

        private void cmdSincronizar_Click(object sender, System.EventArgs e)
        {
            //if (cmdBase.Text.Length > 0)
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    DB.Hacienda hacienda = new DB.Hacienda();

            //    c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            //    clsAccess.Base_Access = cmdBase.Text;

            //    //  ****************************
            //    //  1º NBoletas
            //    //  ****************************
            //    int n = 1;
            //    DataTable dtBoletas = clsAccess.Datos_Vista("", $"TOP {nuCant.Value} *", "NBoleta DESC");
            //    foreach (DataRow drBoleta in dtBoletas.Rows)
            //    {
            //        int nb = Convert.ToInt32(drBoleta["NBoleta"]);
            //        hacienda.Cargar(nb);

            //        if (hacienda.nBoletas.ID == 0)
            //        {
            //            lstActualizacion.Items.Add($"{n}. Agr {nb}");

            //            hacienda.nBoletas.Agregar_NoID("NBoleta", nb);

            //            n++;
            //        }

            //        if (hacienda.nBoletas.Reparto != Convert.ToInt32(drBoleta["Reparto"]))
            //        {
            //            hacienda.nBoletas.Actualizar("Reparto", Convert.ToInt32(drBoleta["Reparto"]));
            //            lstActualizacion.Items.Add($"{n}. Act Repaprto {nb}");
            //        }
            //        if (hacienda.nBoletas.Directo != !Convert.ToBoolean(drBoleta["Mercado"]))
            //        {
            //            hacienda.nBoletas.Actualizar("Directo", !Convert.ToBoolean(drBoleta["Mercado"]));
            //            lstActualizacion.Items.Add($"{n}. Act Directo {nb}");
            //        }

            //        bool YaEstaLaCompra = false;
            //        if (hacienda.nBoletas.Costo != Convert.ToSingle(drBoleta["Costo"]))
            //        {
            //            hacienda.nBoletas.Actualizar("Costo", Convert.ToSingle(drBoleta["Costo"]));

            //            //  ****************************
            //            //  2º Compras Y Agregados
            //            //  ****************************
            //            Cargar_CompraYAgregados(nb);
            //            hacienda.compra.Actualizar_Saldo();
            //            YaEstaLaCompra = true;

            //            lstActualizacion.Items.Add($"{n}. Act costo {nb}");
            //            lstActualizacion.Items.Add($"{n}. Act compra {nb}");

            //        }

            //        if (hacienda.nBoletas.Costo_Faena != Convert.ToSingle(drBoleta["Costo_Faena"]))
            //        {
            //            hacienda.nBoletas.Actualizar("Costo_Faena", Convert.ToSingle(drBoleta["Costo_Faena"]));
            //            lstActualizacion.Items.Add($"{n}. Act c faena {nb}");

            //            if (YaEstaLaCompra == false)
            //            {
            //                //  ****************************
            //                //  2º Compras Y Agregados
            //                //  ****************************
            //                Cargar_CompraYAgregados(nb);
            //                hacienda.compra.Actualizar_Saldo();
            //            }

            //            //  ****************************
            //            //  3º Faena
            //            //  ****************************
            //            Cargar_Faena(nb);
            //        }
            //        clsAccess.Vista = "vw_Faena";
            //        double aids = clsAccess.Dato_Sumado("NBoleta=" + nb, "ID_Faena");
            //        double sids = hacienda.Faena.Dato_Sumado("NBoleta=" + nb, "ID");
            //        if (aids != sids) { Cargar_Faena(nb); lstActualizacion.Items.Add($"{n}. Act faena {nb}"); }

            //    }
            //    //  ****************************
            //    //  4º Salidas 
            //    //  ***************************
            //    Cargar_Salida();

            //    this.Cursor = Cursors.Default;
            //}
        }

        private void Cargar_Boleta(int nb)
        {
            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Campo_ID = "NBoleta";
            clsAccess.Base_Access = cmdBase.Text;

            DataTable dtBoleta_Access = clsAccess.Datos_Vista("NBoleta=" + nb);

            DB.Hacienda.Hacienda hacienda = new DB.Hacienda.Hacienda();
            hacienda.nBoletas.ID = nb;
            hacienda.nBoletas.Borrar();

            if (dtBoleta_Access != null)
            {
                hacienda.nBoletas.ID = nb;

                DateTime fecha; double kilosCompra; double kilosFaena;

                kilosCompra = clsAccess.Dato_Sumado("Compra", "NBoleta=" + nb, "Kilos");
                kilosFaena = clsAccess.Dato_Sumado("Faena", "NBoleta=" + nb, "Kilos");
                hacienda.nBoletas.Kilos_Compra = kilosCompra;
                hacienda.nBoletas.Kilos_Faena = kilosFaena;

                hacienda.nBoletas.Reparto = Convert.ToInt32(dtBoleta_Access.Rows[0]["Reparto"]);
                hacienda.nBoletas.Directo = !Convert.ToBoolean(dtBoleta_Access.Rows[0]["Mercado"]);

                object s = clsAccess.Dato_Generico("Compra", "NBoleta=" + nb, "Fecha_Compra");
                if (s != null)
                {
                    DateTime.TryParse(s.ToString(), out fecha);

                    hacienda.nBoletas.Fecha = fecha;
                }


                hacienda.nBoletas.Agregar();

                hacienda.nBoletas.Cargar();
                hacienda.Calcular_Costo();
                hacienda.nBoletas.Actualizar("Costo", hacienda.nBoletas.Costo);
                hacienda.nBoletas.Actualizar_CostoFaena();
                hacienda.nBoletas.Actualizar_CostoFinal(hacienda.nBoletas.ID);
                hacienda.nBoletas.Actualizar("Costo_Faena", hacienda.nBoletas.Costo_Faena);
                hacienda.nBoletas.Actualizar("Costo_Final", hacienda.nBoletas.Costo_Final);
            }

        }

        private void Cargar_CompraYAgregados(int nb)
        {
            DB.Hacienda.Hacienda hacienda = new DB.Hacienda.Hacienda();
            c_Base_Access clsAccess = new c_Base_Access("vw_Compras", "vw_Compras");

            clsAccess.Base_Access = cmdBase.Text;

            DataTable acCompras = clsAccess.Datos_Vista("NBoleta=" + nb, "*", "ID_Compra");

            object matricula = clsAccess.Dato_Generico("NBoletas", "NBoleta=" + nb, "Matricula");

            if (matricula == null) { matricula = ""; }

            hacienda.compra.Borrar("NBoleta=" + nb);
            hacienda.compra.Matricula.Cargar_Por_Nombre(matricula.ToString());

            lstActualizacion.Items.Add($"Actualizando Compras {nb}");

            foreach (DataRow drAccess in acCompras.Rows)
            {
                hacienda.compra.ID = Convert.ToInt32(drAccess["ID_Compra"]);
                if (hacienda.compra.Existe() == false)
                {
                    hacienda.compra.Agregar_NoID("ID_CompraFrigo", Convert.ToInt32(drAccess["ID_Compra"]));
                }

                hacienda.compra.Actualizar("NBoleta", nb);
                hacienda.compra.Actualizar("Fecha", Convert.ToDateTime(drAccess["Fecha_Compra"]));
                hacienda.compra.Actualizar("Id_Consignatarios", hacienda.compra.Consignatario.Traducir_Consignatario(Convert.ToInt32(drAccess["Id_Consignatario"])));
                hacienda.compra.Actualizar("Id_Productos", Convert.ToInt32(drAccess["Id_Producto"]));
                hacienda.compra.Actualizar("Cabezas", Convert.ToInt16(drAccess["Cabezas"]));
                hacienda.compra.Actualizar("Kilos", Convert.ToDouble(drAccess["Kilos"]));
                hacienda.compra.Actualizar("Costo", Convert.ToDouble(drAccess["Costo"]));
                hacienda.compra.Actualizar("Costo2", Convert.ToDouble(drAccess["Costo2"]));
                hacienda.compra.Actualizar("IVA", Convert.ToDouble(drAccess["IVA"]));
                hacienda.compra.Actualizar("Plazo", Convert.ToInt16(drAccess["Plazo"]));
                hacienda.compra.Actualizar("Percepcion", Convert.ToDouble(drAccess["Percepcion"]));
                hacienda.compra.Actualizar("Matricula", hacienda.compra.Matricula.ID);


                double t = 0;
                if (Convert.ToDouble(drAccess["Kilos"]) != 0) { t = ((Convert.ToDouble(drAccess["Costo2"]) * Convert.ToDouble(drAccess["Kilos"])) + Convert.ToDouble(drAccess["IVA"]) + Convert.ToDouble(drAccess["Percepcion"])) / Convert.ToDouble(drAccess["Kilos"]); }
                hacienda.compra.Calcular_Saldo();

                object estado = hacienda.compra.Dato_Generico("dbStock.dbo.DCompra", "ID_Compra=" + hacienda.compra.ID, "Corroborar");
                hacienda.compra.Actualizar("Estado", estado);


                hacienda.nBoletas.ID = nb;
                hacienda.nBoletas.Cargar();
                hacienda.Calcular_Costo();
                hacienda.nBoletas.Actualizar("Costo", hacienda.nBoletas.Costo);
                hacienda.nBoletas.Actualizar_CostoFaena();
                hacienda.nBoletas.Actualizar_CostoFinal(hacienda.nBoletas.ID);
                hacienda.nBoletas.Actualizar("Costo_Faena", hacienda.nBoletas.Costo_Faena);
                hacienda.nBoletas.Actualizar("Costo_Final", hacienda.nBoletas.Costo_Final);
            }
            //  ****************************
            //  3º Agregados
            //  ****************************

            clsAccess.Vista = "vw_Agregados";
            clsAccess.Campo_ID = "ID_Agregados";

            acCompras = clsAccess.Datos_Vista("NBoleta=" + nb, "*");

            hacienda.Agregados.Borrar("NBoleta=" + nb);

            lstActualizacion.Items.Add($"Actualizando Agregados {nb}");

            foreach (DataRow drAccess in acCompras.Rows)
            {
                hacienda.Agregados.ID = Convert.ToInt32(drAccess["ID_Agregados"]);
                if (hacienda.Agregados.Existe() == false)
                {
                    hacienda.Agregados.Agregar_NoID("ID_Agregados_Frigo", Convert.ToInt32(drAccess["ID_Agregados"]));
                }

                hacienda.Agregados.Actualizar("NBoleta", nb);
                hacienda.Agregados.Actualizar("Fecha", Convert.ToDateTime(drAccess["Fecha"]));
                hacienda.Agregados.Actualizar("Id_Consignatarios", hacienda.compra.Consignatario.Traducir_Consignatario(Convert.ToInt32(drAccess["Id_Consignatario"])));
                hacienda.Agregados.Actualizar("Id_TipoAgregados", Convert.ToInt32(drAccess["Id_TipoAgregados"]));
                hacienda.Agregados.Actualizar("Importe", Convert.ToDouble(drAccess["Importe"]));
                hacienda.Agregados.Actualizar("Saldo", Convert.ToDouble(drAccess["Importe"]) * -1);
                hacienda.Agregados.Actualizar("Plazo", Convert.ToInt16(drAccess["Plazo"]));
                hacienda.Agregados.Actualizar("Matricula", hacienda.compra.Matricula.ID);

                object estado = hacienda.Agregados.Dato_Generico("dbStock.dbo.AgrCompra", "ID_Agregados=" + hacienda.Agregados.ID, "Corroborar");
                hacienda.Agregados.Actualizar("Estado", estado);
                hacienda.compra.Calcular_Saldo();
            }
            hacienda.nBoletas.ID = nb;
            hacienda.nBoletas.Cargar();
            hacienda.Calcular_Costo();
            hacienda.nBoletas.Actualizar("Costo", hacienda.nBoletas.Costo);
            hacienda.nBoletas.Actualizar_CostoFaena();
            hacienda.nBoletas.Actualizar_CostoFinal(hacienda.nBoletas.ID);
            hacienda.nBoletas.Actualizar("Costo_Faena", hacienda.nBoletas.Costo_Faena);
            hacienda.nBoletas.Actualizar("Costo_Final", hacienda.nBoletas.Costo_Final);
        }

        private void Cargar_Faena(int nb)
        {
            DB.Hacienda.Hacienda hacienda = new DB.Hacienda.Hacienda();
            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Base_Access = cmdBase.Text;

            hacienda.Faena.nBoleta.ID = nb;
            hacienda.Faena.Borrar_Faena();
            hacienda.Cargar(nb);

            clsAccess.Vista = "vw_Faena";
            DataTable acFaena = clsAccess.Datos_Vista("NBoleta=" + nb, "ID_Faena, NBoleta, Fecha, ID_Categorias, NRomaneo, Tropa, ID_Productos, ID_Frigorifico, 0.0 AS Recupero, Kilos", "ID_Faena");

            lstActualizacion.Items.Add($"Actualizando Faena {nb}");

            foreach (DataRow dr in acFaena.Rows)
            {
                hacienda.Faena.Agregar_NoID("ID", Convert.ToInt32(dr["ID_Faena"]));
                hacienda.Faena.ID = Convert.ToInt32(dr["ID_Faena"]);
                hacienda.Faena.Actualizar("NBoleta", nb);
                hacienda.Faena.Actualizar("Fecha", Convert.ToDateTime(dr["Fecha"]));
                hacienda.Faena.Actualizar("ID_Categorias", Convert.ToInt32(dr["ID_Categorias"]));
                hacienda.Faena.Actualizar("NRomaneo", Convert.ToInt32(dr["NRomaneo"]));
                hacienda.Faena.Actualizar("Tropa", Convert.ToInt32(dr["Tropa"]));
                hacienda.Faena.Actualizar("ID_Productos", Convert.ToInt32(dr["ID_Productos"]));
                hacienda.Faena.Actualizar("ID_Frigorificos", Convert.ToInt32(dr["ID_Frigorifico"]));
                hacienda.Faena.Actualizar("Kilos", Convert.ToSingle(dr["Kilos"]));

                //  Cargar el Recupero
                Recupero recu = new Recupero();

                hacienda.Faena.Actualizar("Recupero", recu.Buscar(Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["ID_Productos"]), Convert.ToInt32(dr["ID_Frigorifico"]), hacienda.nBoletas.Directo));
            }

            hacienda.nBoletas.Actualizar_CostoFinal(nb);
        }

        private void Cargar_Salida()
        {
            Hacienda_Salidas salidas_sistema = new Hacienda_Salidas("Hacienda_Salidas", "vw_Hacienda_Salidas");
            salidas_sistema.Borrar($"Fecha BETWEEN '{mDesde.Value:MM/dd/yy}' AND '{mHasta.Value:MM/dd/yy}'");

            c_Base_Access clsAccess = new c_Base_Access("Salidas", "vw_Salidas");
            clsAccess.Campo_ID = "ID_Salidas";
            clsAccess.Base_Access = cmdBase.Text;

            DataTable dtFechas = clsAccess.Datos_Vista($"Fecha BETWEEN #{mDesde.Value:MM/dd/yy}# AND #{mHasta.Value:MM/dd/yy}#", "Fecha", "Fecha", "Fecha");

            if (dtFechas != null)
            {
                foreach (DataRow drF in dtFechas.Rows)
                {
                    lstActualizacion.Items.Insert(0, $"Salida: {Convert.ToDateTime(drF["Fecha"]):dd/MM}");
                    Application.DoEvents();
                    DataTable dtSalidas = clsAccess.Datos_Vista($"Fecha=#{Convert.ToDateTime(drF["Fecha"]):MM/dd/yy}#", "ID_Salidas, Fecha, ID_Sucursales, ID_Faena, Media");

                    foreach (DataRow drS in dtSalidas.Rows)
                    {
                        salidas_sistema.ID = Convert.ToInt32(drS["ID_Salidas"]);
                        salidas_sistema.Fecha = Convert.ToDateTime(drS["Fecha"]);
                        salidas_sistema.Sucursal.ID = Convert.ToInt32(drS["ID_Sucursales"]);
                        salidas_sistema.Faena.ID = Convert.ToInt32(drS["ID_Faena"]);
                        salidas_sistema.Faena.Cargar_Registro();
                        salidas_sistema.Media = Convert.ToInt32(drS["Media"]);
                        salidas_sistema.Cargar_CostoSalida();
                        salidas_sistema.Agregar();
                    }
                }
            }
            Cargar_ListadoSalidas();
        }

        private void cmdBase_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.DefaultExt = "accdb";
            f.Filter = "Access (*.accdb)|*.accdb";
            f.ShowDialog();
            cmdBase.Text = f.FileName;
        }

        private void lstBoletas_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (lstBoletas.SelectedIndex > -1)
            {
                Cargar(Convert.ToInt32(lstBoletas.Text));
            }
            this.Cursor = Cursors.Default;

        }

        private void Cargar(int nb)
        {
            if (chBoleta.Checked == true) { Cargar_Boleta(nb); }
            if (chCompra.Checked == true) { Cargar_CompraYAgregados(nb); }
            if (chFaena.Checked == true) { Cargar_Faena(nb); }
            if (chSaldo.Checked == true)
            {
                DB.Hacienda.Hacienda hacienda = new DB.Hacienda.Hacienda();

                DataTable dt = hacienda.compra.Consignatarios_En_Boleta(nb);

                foreach (DataRow dr in dt.Rows)
                {
                    hacienda.compra.Ejecutar_Comando($"EXEC sp_ActualizarSaldoBoleta {dr["ID_Consignatarios"]}, {nb}");
                    lstActualizacion.Items.Add($"Actualizando saldo NB {nb} Consig {dr["ID_Consignatarios"]}");

                }
            }
            Cargar_ListadosBoletas();
        }

        private void mdSincSalidas_Click(object sender, EventArgs e)
        {
            Cargar_Salida();
        }



        private void lstBoletas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Cargar_Listados();
            }
        }

        private void cmdAdelante_Click(object sender, EventArgs e)
        {
            if (lstBoletas.SelectedIndex > -1)
            {
                this.Cursor = Cursors.WaitCursor;

                DB.Hacienda.Hacienda hacienda = new DB.Hacienda.Hacienda();

                for (int i = lstBoletas.SelectedIndex; i >= 0; i--)
                {
                    int nb = Convert.ToInt32(lstBoletas.Items[i]);
                    cmdAdelante.Text = nb.ToString();
                    Application.DoEvents();

                    if (chBoleta.Checked == true) { Cargar_Boleta(nb); }
                    if (chCompra.Checked == true) { Cargar_CompraYAgregados(nb); }
                    if (chFaena.Checked == true) { Cargar_Faena(nb); }
                    if (chSaldo.Checked == true)
                    {

                        DataTable dt = hacienda.compra.Datos_Vista("NBoleta=" + nb);

                        foreach (DataRow dr in dt.Rows)
                        {
                            hacienda.compra.Ejecutar_Comando($"EXEC sp_ActualizarSaldoBoleta {dr["ID_Consignatarios"]}, {nb}");
                            lstActualizacion.Items.Add($"Actualizando saldo NB {nb} Consig {dr["ID_Consignatarios"]}");
                        }
                    }
                }
                cmdAdelante.Text = "Listo!";
                this.Cursor = Cursors.Default;
            }
        }

        private void txtBoleta_Validated(object sender, EventArgs e)
        {

        }

        private void txtBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((short)e.KeyChar == 13)
            {
                txtHasta.Focus();
            }
        }

        private void cmdCostos_Salida_Click(object sender, EventArgs e)
        {
            Hacienda_Salidas hs = new Hacienda_Salidas();
            DateTime f1 = mDesde.Value;
            DateTime f2 = mHasta.Value;
            lstActualizacion.Items.Insert(0, $"Salidas desde {f1:d} - hasta {f2:d}");
            Application.DoEvents();
            hs.Actualizar_Costos(f1, f2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBoleta.TextLength != 0)
            {
                if (txtHasta.Text == "")
                {
                    Cargar(Convert.ToInt32(txtBoleta.Text));
                }
                else
                {
                    for (int i = Convert.ToInt32(txtBoleta.Text); i <= Convert.ToInt32(txtHasta.Text); i++)
                    {
                        lstActualizacion.Items.Insert(0, $"Actualizando {i}");
                        Application.DoEvents();
                        Cargar(i);
                    }
                }
            }
        }

        private void frmSincronizarAccess_Load(object sender, EventArgs e)
        {

        }

        private void lstFechasAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            mDesde.Value = DateTime.Parse(lstFechasAcc.Text);
        }

        private void lstFechasAcc_DoubleClick(object sender, EventArgs e)
        {
            mDesde.Value = DateTime.Parse(lstFechasAcc.Text);
            mHasta.Value = mDesde.Value;
            cmdSincSalidas.PerformClick();
            Cargar_ListadoSalidas();
        }

        private void cmdListados_Click(object sender, EventArgs e)
        {
            Cargar_Listados();
        }

        private void chSaldo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                chBoleta.Checked = false;
                chCompra.Checked = false;
                chFaena.Checked = false;
            }
        }
    }
}

