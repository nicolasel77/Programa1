using Programa1.Carga.Varios;
using Programa1.DB.Tesoreria;
using Programa1.DB.Varios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmCheques : Form
    {
        public Cheques ch;
        public List<Cheques> cheques_seleccionados = new List<Cheques>();
        public Usuarios usuario;

        const byte Id = 0;
        const byte Numero = 1;
        const byte Importe = 2;
        const byte eCheq = 3;
        const byte Banco = 4;
        const byte Nombre = 5;
        const byte Fecha_Entrada = 6;
        const byte Fecha_Acreditacion = 7;
        const byte Origen = 8;
        const byte Destino = 9;
        const byte Caja = 10;
        const byte Seleccionado = 11;

        /// <summary>
        /// Para avisar que hay nuevo
        /// </summary>
        public bool Nuevo_Cheque = false;

        public frmCheques()
        {
            InitializeComponent();
            grd.TeclasManejadas = new int[] { 13, (int)Keys.F1 };

            ch = new Cheques();
            Cargar();
        }

        public void Cargar(bool selec = false)
        {
            DataTable dt;
            if (selec == true)
            {
                dt = ch.Datos_Vista("Destino=''");
                if (dt != null)
                {
                    dt.Columns.Add("Sel", typeof(bool));                    
                }
            }
            else
            {
                dt = ch.Datos_Vista("", "TOP 100 *", "Id", false);
            }

            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(Id, 0);
            grd.set_ColW(Origen, 200);
            grd.set_ColW(Destino, 200);
            grd.set_ColW(Caja, 0);
            grd.Columnas[Importe].Format = "N1";

            if (selec == false) { grd.ActivarCelda(grd.Rows - 1, Numero); } else { grd.ActivarCelda(1, Seleccionado); }
            double t = grd.SumarCol(Importe, false);
            if (selec == false) { lblTotal.Text = $"Total: {t:C1}"; } else { lblTotal.Text = "Total"; }
            
            grd.Ordenar(0);
            grd.AgregarFila();
            grd.ActivarCelda(grd.Rows - 1, 0);
        }

        private void grd_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grd.get_Texto(f, Id));
            ch.ID= i;
            switch (c)
            {
                case Numero:
                    ch.Numero = Convert.ToInt32(a);

                    if (i == 0)
                    {
                        if (ch.Existe("Numero", ch.Numero) == false)
                        {
                            ch.Agregar();
                            Nuevo_Cheque = true;
                            grd.set_Texto(f, Id, ch.ID);
                            grd.set_Texto(f, c, a);
                            grd.ActivarCelda(f, Importe);
                            grd.AgregarFila();
                        }
                        else
                        {
                            MessageBox.Show("El número ingresado ya existe");
                            grd.ErrorEnTxt();
                        }
                    }
                    else
                    {
                        ch.Actualizar();
                        grd.set_Texto(f, c, a);
                        grd.ActivarCelda(f, Importe);
                    }

                    break;

                case Importe:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        ch.Importe = Convert.ToDouble(a);
                        ch.Actualizar();

                        grd.set_Texto(f, c, a);
                        grd.ActivarCelda(f, eCheq);
                    }
                    break;

                case eCheq:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        ch.E_Cheq = Convert.ToBoolean(a);
                        ch.Actualizar();
                        grd.ActivarCelda(f, Banco);
                    }
                    break;
                case Banco:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        if (ch.Banco.Existe(Convert.ToInt32(a)) == true)
                        {
                            ch.Actualizar();
                            grd.set_Texto(f, c, a);
                            grd.set_Texto(f, Nombre, ch.Banco.Nombre);
                            grd.ActivarCelda(f, Fecha_Entrada);
                        }
                        else
                        {
                            SystemSounds.Beep.Play();
                            MessageBox.Show($"No se encontro el banco {a}");
                        }
                    }

                    break;
                case Fecha_Entrada:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        ch.Fecha_Entrada = Convert.ToDateTime(a);
                        ch.Actualizar();
                        grd.set_Texto(f, c, a);
                        grd.ActivarCelda(f, Fecha_Acreditacion);
                    }
                    break;
                case Fecha_Acreditacion:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        ch.Fecha_Acreditacion = Convert.ToDateTime(a);
                        ch.Actualizar("Fecha_Acreditacion", ch.Fecha_Acreditacion);
                        grd.set_Texto(f, c, a);
                        
                        grd.ActivarCelda(f, Origen);
                    }
                    break;
                case Origen:
                case Destino:
                    if (i == 0)
                    {
                        SystemSounds.Beep.Play();
                        grd.ActivarCelda(f, Numero);
                    }
                    else
                    {
                        MessageBox.Show("Origen y Destino no son editables. Use F1 para cargar los datos.");
                    }
                    break;

                
                case Seleccionado:
                    cheques_seleccionados.Clear();
                    double t = 0;
                    for (int n = 1; n <= grd.Rows - 1; n++)
                    {
                        if (Convert.ToBoolean(grd.get_Texto(n, Seleccionado)) == true)
                        {
                            t += Convert.ToDouble(grd.get_Texto(n, Importe));
                            Cheques cn = new Cheques();
                            cn.Buscar_Cheque(Convert.ToInt32(grd.get_Texto(n, Numero)));
                            cheques_seleccionados.Add(cn);
                        }
                    }
                    lblTotal.Text = $"Total: {t:C1}";

                    if (f == grd.Rows - 1)
                    {
                        grd.ActivarCelda(1, Seleccionado);
                    }
                    else
                    {
                        grd.ActivarCelda(f + 1, Seleccionado);
                    }
                    break;
            }
        }

        private void frmCheques_KeyUp(object sender, KeyEventArgs e)
        {
                        
            if (e.KeyCode == Keys.Delete)
            {
                int i = Convert.ToInt32(grd.get_Texto(grd.Row, Id));
                if (i != 0)
                {
                    if (ch.Numero > 0)
                    { 
                        ch.ID = i;
                        ch.Borrar();
                        ch.Ejecutar_Comando(" DELETE FROM CD_Entradas WHERE Cheque=" + ch.Numero);
                        ch.Ejecutar_Comando(" DELETE FROM CD_Gastos   WHERE Cheque=" + ch.Numero);
                        ch.Ejecutar_Comando($"DELETE FROM CD_Gastos   WHERE Descripcion = 'Cheque Nº {ch.Numero}'");
                        grd.BorrarFila();
                        grd.ActivarCelda(grd.Row, Numero);
                    }
                }
            }
            else
            {
                int f = grd.Row;
                
                if (e.KeyCode == Keys.F1)
                {
                    int i = Convert.ToInt32(grd.get_Texto(f, Id));
                    int c = grd.Col;
                    frmAyuda_Generico fr = new frmAyuda_Generico();
                    switch (c)
                    {
                        case Banco:
                            fr.Tabla = "Bancos";
                            fr.ShowDialog();
                            if (fr.ID_Seleccionado != 0)
                            {
                                ch.Banco.ID = fr.ID_Seleccionado;
                                ch.Actualizar();

                                grd.set_Texto(f, c, fr.ID_Seleccionado);
                                grd.set_Texto(f, c + 1, fr.Nombre_Seleccionado);

                                grd.ActivarCelda(f, Fecha_Entrada);
                            }

                            break;
                        case Origen:
                            fr.Filtro = $" Id IN(SELECT Caja FROM Cajas_Autorizadas WHERE Usuario={usuario.ID})";
                            fr.Tabla = "Cajas";
                            fr.ShowDialog();
                            if (fr.ID_Seleccionado != 0)
                            {
                                ch.ID_Caja = fr.ID_Seleccionado;                                
                                ch.Actualizar();

                                ///
                                //Cargar la ENTRADA
                                //
                                Entradas en = new Entradas();

                                en.caja.ID = 11;
                                en.Fecha = ch.Fecha_Entrada;                                                                
                                en.TE.Id_Tipo = 20; //Tipo 20 = Entrada Cheques
                                en.Id_SubTipoEntrada = ch.ID_Caja;
                                en.Descripcion = $"{fr.Nombre_Seleccionado}  - Cheque Nº {ch.Numero}";
                                en.Cheque = ch.Numero;
                                en.Importe = ch.Importe;

                                en.Agregar();

                                ///
                                //Cargar la TRANSFERENCIA
                                //
                                Gastos g = new Gastos();

                                g.Fecha = ch.Fecha_Entrada;
                                g.caja.ID = ch.ID_Caja;
                                g.TG.Id_Tipo = 100;
                                g.Id_SubTipoGastos = 11;
                                g.Desc_SubTipo = "Salida a Cheques";
                                g.Id_DetalleGastos = 1;
                                g.Descripcion = $"Cheque Nº {ch.Numero}";
                                g.Importe = ch.Importe;
                                g.Fecha_Autorizado = DateTime.Now;
                                
                                frmMain frParent = (frmMain)this.ParentForm;
                                g.Usuario.ID = frParent.usuario.ID;
                                
                                g.Agregar();                                                                
                                
                                grd.set_Texto(f, c, fr.Nombre_Seleccionado);
                                grd.ActivarCelda(f, Destino);
                            }
                            break;
                        case Destino:
                            fr.Campo_ID = "ID_Tipo";
                            fr.Tabla = "Tipos_Salidas";
                            fr.ShowDialog();

                            if (fr.ID_Seleccionado != 0)
                            {
                                Gastos g = new Gastos();
                                g.Fecha = ch.Fecha_Acreditacion;
                                g.caja.ID = 11;
                                g.TG.Id_Tipo = fr.ID_Seleccionado;
                                
                                frmAyuda_Gastos fayuda = new frmAyuda_Gastos();
                                Herramientas.Herramientas h = new Herramientas.Herramientas();

                                fayuda.Cargar_SubTiposGastos(g.TG.Id_Tipo);
                                fayuda.ShowDialog();

                                if (fayuda.Valor != "")
                                {
                                    g.Id_SubTipoGastos = h.Codigo_Seleccionado(fayuda.Valor);
                                    g.Desc_SubTipo = h.Nombre_Seleccionado(fayuda.Valor);

                                    fayuda.Cargar_Detalles(g.TG.Id_Tipo);
                                    fayuda.ShowDialog();

                                    if (fayuda.Valor != "")
                                    {
                                        g.Id_DetalleGastos = h.Codigo_Seleccionado(fayuda.Valor);
                                        g.Descripcion = h.Nombre_Seleccionado(fayuda.Valor);

                                        //Cargar el GASTO futuro
                                        //
                                        
                                        frmMain frParent = (frmMain)this.ParentForm;
                                        g.Usuario.ID = frParent.usuario.ID;
                                        g.Importe = ch.Importe;
                                        g.Fecha_Acreditacion = ch.Fecha_Acreditacion;
                                        g.Fecha_Autorizado = DateTime.Now;
                                        g.Cheque = ch.Numero;

                                        //g.BorrarPagosCheque(ch.Numero);

                                        g.Agregar();

                                        grd.set_Texto(f, c, fayuda.Valor);
                                    }
                                }                                
                                
                                grd.ActivarCelda(f + 1, Numero);
                            }
                            break;
                    }
                    Focus();
                    grd.Focus();
                }
            }

        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 27)
            {
                //this.Hide();
            }
        }

        private void grd_CambioFila(short Fila)
        {
            ch.Numero = Convert.ToInt32(grd.get_Texto(Fila, Numero));
            //ch.Buscar_Cheque();

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
