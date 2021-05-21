using Programa1.DB.Tesoreria;
using System;
using System.Media;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmCheques : Form
    {
        public Cheques ch = new Cheques();

        const byte Id = 0;
        const byte Numero = 1;
        const byte Banco = 2;
        const byte Nombre = 3;
        const byte Fecha_Entrada = 4;
        const byte Fecha_Acreditacion = 5;
        const byte Importe = 6;

        /// <summary>
        /// Para avisar que hay nuevo
        /// </summary>
        public bool Nuevo_Cheque = false;

        public frmCheques()
        {
            InitializeComponent();            
        }

        public void Cargar()
        {
            grd.MostrarDatos(ch.Datos_Vista(), true, !Nuevo_Cheque);
            grd.set_ColW(Id, 0);
            grd.Columnas[Importe].Format = "N1";
            grd.ActivarCelda(grd.Rows - 1, Numero);
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
                        ch.Fecha_Acreditacion= Convert.ToDateTime(a);
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
            }
        }
    }
}
