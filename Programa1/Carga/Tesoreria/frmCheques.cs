using Programa1.DB.Tesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmCheques : Form
    {
        public Cheques ch = new Cheques();
        public List<Cheques> cheques_seleccionados = new List<Cheques>();

        const byte Id = 0;
        const byte Numero = 1;
        const byte Banco = 2;
        const byte Nombre = 3;
        const byte Fecha_Entrada = 4;
        const byte Fecha_Acreditacion = 5;
        const byte Importe = 6;
        const byte Seleccionado = 9;

        /// <summary>
        /// Para avisar que hay nuevo
        /// </summary>
        public bool Nuevo_Cheque = false;

        public frmCheques()
        {
            InitializeComponent();
            grd.TeclasManejadas = new int[] { 13 };
        }

        public void Cargar(bool selec = false)
        {
            DataTable dt;
            if (selec == true)
            {
                dt = ch.Datos_Vista("Destino=''");
                dt.Columns.Add("Sel", typeof(bool));
            }
            else
            {
                dt = ch.Datos_Vista();
            }
            grd.MostrarDatos(dt, true, !selec);
            grd.set_ColW(Id, 0);
            grd.Columnas[Importe].Format = "N1";
            if (selec == false) { grd.ActivarCelda(grd.Rows - 1, Numero); } else { grd.ActivarCelda(1, Seleccionado); }
            double t = grd.SumarCol(Importe, false);
            if (selec == false) { lblTotal.Text = $"Total: {t:C1}"; } else { lblTotal.Text = "Total"; }

        }

        private void grd_Editado(short f, short c, object a)
        {
            int i = Convert.ToInt32(grd.get_Texto(f, Id));
            switch (c)
            {
                case Numero:
                    ch.Numero = Convert.ToInt32(a);
                    if (i == 0)
                    {
                        ch.Agregar();
                        Nuevo_Cheque = true;
                        grd.set_Texto(f, Id, ch.ID);
                    }
                    else
                    {
                        ch.Actualizar();
                    }
                    grd.set_Texto(f, Numero, a);

                    grd.ActivarCelda(f, Banco);

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
                        this.Hide();
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
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
            else
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int f = grd.Row;
                    int i = Convert.ToInt32(grd.get_Texto(f, Id));
                    if (i != 0)
                    {
                        ch.ID = i;
                        ch.Borrar();
                        grd.BorrarFila();
                        grd.ActivarCelda(f, Numero);
                    }
                }
            }

        }

        private void grd_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                this.Hide();
            }
        }
    }
}
