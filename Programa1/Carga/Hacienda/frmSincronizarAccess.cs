﻿using Programa1.Clases;
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
        Datos_Genericos datos = new Datos_Genericos();
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
                    cmdBase.Text = "No se encontro el archivo.";
                    cmdBase.Text = "F:\\Proyectos\\Sistemas\\dbStock.accdb";
                }
            }
            else
            {
                cmdBase.Text = "";
            }
            Cargar_Boletas();

            mDesde.SetDate(DateTime.Today.AddDays(-10));
        }

        private void Cargar_Boletas()
        {
            NBoletas nb = new NBoletas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            lstBoletas.Items.Clear();
            h.Llenar_List(lstBoletas, nb.Datos_Vista("", "TOP 100 NBoleta", "NBoleta DESC"));
        }

        private void cmdSincronizar_Click(object sender, System.EventArgs e)
        {
            if (cmdBase.Text.Length > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                DB.Hacienda hacienda = new DB.Hacienda();

                c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
                clsAccess.Base_Access = cmdBase.Text;

                //  ****************************
                //  1º NBoletas
                //  ****************************
                int n = 1;
                DataTable dtBoletas = clsAccess.Datos_Vista("", $"TOP {nuCant.Value} *", "NBoleta DESC");
                foreach (DataRow drBoleta in dtBoletas.Rows)
                {
                    int nb = Convert.ToInt32(drBoleta["NBoleta"]);
                    hacienda.Cargar(nb);

                    if (hacienda.nBoletas.ID == 0)
                    {
                        lstActualizacion.Items.Add($"{n}. Agr {nb}");

                        hacienda.nBoletas.Agregar_NoID("NBoleta", nb);

                        n++;
                    }

                    if (hacienda.nBoletas.Reparto != Convert.ToInt32(drBoleta["Reparto"]))
                    {
                        hacienda.nBoletas.Actualizar("Reparto", Convert.ToInt32(drBoleta["Reparto"]));
                        lstActualizacion.Items.Add($"{n}. Act Repaprto {nb}");
                    }
                    if (hacienda.nBoletas.Directo != !Convert.ToBoolean(drBoleta["Mercado"]))
                    {
                        hacienda.nBoletas.Actualizar("Directo", !Convert.ToBoolean(drBoleta["Mercado"]));
                        lstActualizacion.Items.Add($"{n}. Act Directo {nb}");
                    }

                    bool YaEstaLaCompra = false;
                    if (hacienda.nBoletas.Costo != Convert.ToSingle(drBoleta["Costo"]))
                    {
                        hacienda.nBoletas.Actualizar("Costo", Convert.ToSingle(drBoleta["Costo"]));

                        //  ****************************
                        //  2º Compras Y Agregados
                        //  ****************************
                        Cargar_CompraYAgregados(nb);
                        hacienda.compra.Actualizar_Saldo();
                        YaEstaLaCompra = true;

                        lstActualizacion.Items.Add($"{n}. Act costo {nb}");
                        lstActualizacion.Items.Add($"{n}. Act compra {nb}");

                    }

                    if (hacienda.nBoletas.Costo_Faena != Convert.ToSingle(drBoleta["Costo_Faena"]))
                    {
                        hacienda.nBoletas.Actualizar("Costo_Faena", Convert.ToSingle(drBoleta["Costo_Faena"]));
                        lstActualizacion.Items.Add($"{n}. Act c faena {nb}");

                        if (YaEstaLaCompra == false)
                        {
                            //  ****************************
                            //  2º Compras Y Agregados
                            //  ****************************
                            Cargar_CompraYAgregados(nb);
                            hacienda.compra.Actualizar_Saldo();
                        }

                        //  ****************************
                        //  3º Faena
                        //  ****************************
                        Cargar_Faena(nb);
                    }
                    clsAccess.Vista = "vw_Faena";
                    double aids = clsAccess.Dato_Sumado("NBoleta=" + nb, "ID_Faena");
                    double sids = hacienda.Faena.Dato_Sumado("NBoleta=" + nb, "ID");
                    if (aids != sids) { Cargar_Faena(nb); lstActualizacion.Items.Add($"{n}. Act faena {nb}"); }

                }
                //  ****************************
                //  4º Salidas 
                //  ***************************
                Cargar_Salida();

                this.Cursor = Cursors.Default;
            }
        }
        private void Cargar_CompraYAgregados(int nb)
        {
            DB.Hacienda hacienda = new DB.Hacienda();
            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Base_Access = cmdBase.Text;
            clsAccess.Vista = "vw_Compras";

            DataTable acCompras = clsAccess.Datos_Vista("NBoleta=" + nb, "*", "ID_Compra");

            object matricula = clsAccess.Dato_Generico("NBoletas", "NBoleta=" + nb, "Matricula");

            hacienda.compra.Borrar("NBoleta=" + nb);
            hacienda.compra.Matricula.Cargar_Por_Nombre(matricula.ToString());

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
            }
            //  ****************************
            //  3º Agregados
            //  ****************************

            clsAccess.Vista = "vw_Agregados";
            clsAccess.Campo_ID = "ID_Agregados";

            acCompras = clsAccess.Datos_Vista("NBoleta=" + nb, "*");
                        
            hacienda.Agregados.Borrar("NBoleta=" + nb);
            hacienda.Agregados.Matricula.Cargar_Por_Nombre(matricula.ToString());

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
                hacienda.Agregados.Actualizar("Plazo", Convert.ToInt16(drAccess["Plazo"]));
                hacienda.Agregados.Actualizar("Matricula", hacienda.compra.Matricula.ID);
            }
        }

        private void Cargar_Faena(int nb)
        {
            DB.Hacienda hacienda = new DB.Hacienda();
            c_Base_Access clsAccess = new c_Base_Access("NBoletas", "NBoletas");
            clsAccess.Base_Access = cmdBase.Text;

            hacienda.Faena.nBoleta.ID = nb;
            hacienda.Faena.Borrar_Faena();
            hacienda.Cargar(nb);

            clsAccess.Vista = "vw_Faena";
            DataTable acFaena = clsAccess.Datos_Vista("NBoleta=" + nb, "ID_Faena, NBoleta, Fecha, ID_Categorias, NRomaneo, Tropa, ID_Productos, ID_Frigorifico, 0.0 AS Recupero, Kilos", "ID_Faena");

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
        }

        private void Cargar_Salida()
        {
            Hacienda_Salidas salidas_sistema = new Hacienda_Salidas("Hacienda_Salidas", "vw_Hacienda_Salidas");

            c_Base_Access clsAccess = new c_Base_Access("Salidas", "vw_Salidas");
            clsAccess.Campo_ID = "ID_Salidas";
            clsAccess.Base_Access = cmdBase.Text;

            DataTable dtFechas = clsAccess.Datos_Vista($"Fecha BETWEEN #{mDesde.SelectionStart:MM/dd/yy}# AND #{mHasta.SelectionStart:MM/dd/yy}#", "Fecha, ID_Sucursales AS Suc, SUM(ID_Salidas+ID_Sucursales) AS IDs", "Fecha DESC", "Fecha, ID_Sucursales");

            if (dtFechas != null)
            {
                foreach (DataRow drF in dtFechas.Rows)
                {
                    DataTable dtSistema = salidas_sistema.Datos_Vista($"Fecha='{Convert.ToDateTime(drF["Fecha"]):MM/dd/yy}'", "Fecha, ID_Sucursales Suc, SUM(ID_Salidas+ID_Sucursales) AS IDs", "Fecha DESC", "Fecha, ID_Sucursales");
                    if (dtSistema != null)
                    {
                        if (dtSistema.Rows[0]["IDs"] != drF["IDs"])
                        {
                            lstActualizacion.Items.Add($"Salida: {Convert.ToDateTime(drF["Fecha"]):dd/MM} Suc {drF["Suc"]}");

                        }
                    }
                    else
                    {
                        salidas_sistema.Borrar($"Fecha='{Convert.ToDateTime(drF["Fecha"]):MM/dd/yy}' AND ID_Sucursales={drF["Suc"]}");

                        DataTable dtSalidas = clsAccess.Datos_Vista($"Fecha=#{Convert.ToDateTime(drF["Fecha"]):MM/dd/yy}# AND ID_Sucursales={drF["Suc"]}","ID_Salidas, Fecha, ID_Sucursales, ID_Faena, Media");
                        foreach(DataRow drS in dtSalidas.Rows)
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
            }
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
                int nb = Convert.ToInt32(lstBoletas.Text);
                if (chCompra.Checked == true) { Cargar_CompraYAgregados(nb); }
                if (chFaena.Checked == true) { Cargar_Faena(nb); }
                if (chSaldo.Checked == true)
                {
                    DB.Hacienda hacienda = new DB.Hacienda();

                    DataTable dt = hacienda.compra.Datos_Vista("NBoleta=" + nb);
                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        hacienda.compra.Ejecutar_Comando($"EXEC sp_ActualizarSaldosConsignatario {dr["ID_Consignatarios"]}, {nb}");
                    }
                }
            }
            this.Cursor = Cursors.Default;

        }

        private void mdSincSalidas_Click(object sender, EventArgs e)
        {
            Cargar_Salida();
        }

        private void cmdSaldos_Click(object sender, EventArgs e)
        {
            if (chSaldo.Checked == true)
            {
                if (lstBoletas.SelectedIndex > -1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    DB.Hacienda hacienda = new DB.Hacienda();

                    int nb = Convert.ToInt32(lstBoletas.Text);

                    DataTable dt = hacienda.compra.Datos_Vista("NBoleta>=" + nb, "ID_Consignatarios, Nombre, NBoleta", "NBoleta", "NBoleta, ID_Consignatarios, Nombre");
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmdSaldos.Text = $"{dr["Nombre"]} NBoleta {dr["NBoleta"]}";
                        Application.DoEvents();
                        hacienda.compra.Ejecutar_Comando($"EXEC sp_ActualizarSaldosConsignatario {dr["ID_Consignatarios"]}, {dr["NBoleta"]}");

                    }
                    this.Cursor = Cursors.Default; 
                }
            }
        }

        private void lstBoletas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Cargar_Boletas();
            }
        }
    }
}
