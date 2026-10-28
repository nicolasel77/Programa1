namespace Programa1.Carga.TM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmChequesTM : Form
    {
        clsTM gastosTM = new clsTM();

        public frmChequesTM()
        {
            InitializeComponent();
            Cargar_Listados();
            Cargar_Cheques();

            // Capturar la tecla Del en el grid
            grd.TeclasManejadas = new int[] { 46 };
        }

        private void Cargar_Listados()
        {
            // Cargar los listados necesarios para los combos
            List<clsTM._Bancos> bancos = gastosTM.Bancos();
            foreach (clsTM._Bancos banco in bancos)
            {
                lstBancos.Items.Add(banco.ToString());
            }
            List<clsTM._Cajas> cajas = gastosTM.Cajas();
            foreach (clsTM._Cajas caja in cajas)
            {
                lstCajas.Items.Add(caja.ToString());
            }

        }

        private void Cargar_Cheques()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            int banco = 0, caja = 0, numero = 0;
            string fecha;

            if (lstBancos.SelectedIndex > -1)
            {
                banco = h.Codigo_Seleccionado(lstBancos.Text);
            }
            if (lstCajas.SelectedIndex > -1)
            {
                caja = h.Codigo_Seleccionado(lstCajas.Text);
            }
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                numero = Convert.ToInt32(txtNumero.Text);
            }
            if (rdFechaEntrada.Checked)
            {
                fecha = cfecha.Cadena("Fecha_Entrada");
            }
            else
            {
                fecha = cfecha.Cadena("Fecha_Acreditacion");
            }


            DataTable dt = gastosTM.Cheques(banco, caja, fecha, numero);
            grd.MostrarDatos(dt, true, true);
            grd.set_ColW("ID", 0);
        }

        private void lstBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Cheques();
        }

        private void lstCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Cheques();
        }

        private void rdFechaEntrada_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_Cheques();
        }

        private void cfecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Cheques();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            Cargar_Cheques();
        }

        private void grd_Editado(short f, short c, object a)
        {
            clsTM._Cheques cheque = new clsTM._Cheques();
            cheque.ID = Convert.ToInt32(grd.get_Texto(f, "ID"));
            cheque.ID_Banco = Convert.ToInt32(grd.get_Texto(f, "ID_Banco"));
            cheque.Numero = Convert.ToInt64(grd.get_Texto(f, "Numero"));
            cheque.Fecha_Entrada = Convert.ToDateTime(grd.get_Texto(f, "Fecha_Entrada"));
            cheque.Fecha_Acreditacion = Convert.ToDateTime(grd.get_Texto(f, "Fecha_Acreditacion"));
            cheque.ID_Caja = Convert.ToInt32(grd.get_Texto(f, "ID_Caja"));
            cheque.Importe = Convert.ToDecimal(grd.get_Texto(f, "Importe"));
            cheque.eCheq = Convert.ToBoolean(grd.get_Texto(f, "eCheq"));

            grd.set_Texto(f, c, a);
            if (c == grd.get_ColIndex("Numero"))
            {
                cheque.Numero = Convert.ToInt64(a);
            }
            if (c == grd.get_ColIndex("ID_Banco"))
            {
                string nombre = gastosTM.Nombre_Banco(Convert.ToInt32(a));
                if (nombre != "")
                {
                    cheque.ID_Banco = Convert.ToInt32(a);
                    grd.set_Texto(f, "Nombre", nombre);
                    c++;
                }
                else
                {
                    grd.ErrorEnTxt();
                    return;
                }
            }
            if (c == grd.get_ColIndex("ID_Caja"))
            {
                string nombre = gastosTM.Nombre_Caja(Convert.ToInt32(a));
                if (nombre != "")
                {
                    cheque.ID_Caja = Convert.ToInt32(a);
                    grd.set_Texto(f, "Nombre_Caja", nombre);
                    c++;
                }
                else
                {
                    grd.ErrorEnTxt();
                    return;
                }
            }
            if (c == grd.get_ColIndex("eCheq"))
            {
                cheque.eCheq = Convert.ToBoolean(a);

            }
            if (c == grd.get_ColIndex("Fecha_Entrada"))
            {
                cheque.Fecha_Entrada = Convert.ToDateTime(a);
            }
            if (c == grd.get_ColIndex("Fecha_Acreditacion"))
            {
                cheque.Fecha_Acreditacion = Convert.ToDateTime(a);
            }
            if (c == grd.get_ColIndex("Importe"))
            {
                cheque.Importe = Convert.ToDecimal(a);
                gastosTM.Actualizar_Cheque(cheque);
                if (f == grd.Rows - 1)
                {
                    cheque.ID = gastosTM.Ultimo_ID("Cheques");
                    grd.set_Texto(f, "ID", cheque.ID);
                    grd.AgregarFila();
                    grd.ActivarCelda(f + 1, grd.get_ColIndex("Numero"));
                    return;
                }
                grd.ActivarCelda(f + 1, grd.get_ColIndex("Numero"));
                return;
            }

            grd.ActivarCelda(f, c + 1);
        }

        private void grd_KeyUp(object sender, short e)
        {
            // Borrado
            if(e == 46)
            {
                int f = grd.Row;
                int id = Convert.ToInt32(grd.get_Texto(f, "ID"));
                if (id > 0)
                {
                    // Primero chequear que no haya un gasto con el cheque
                    DateTime fecha = gastosTM.Salida_Cheque(id);
                    if (fecha.Year > 1900)
                    {
                        MessageBox.Show($"No se puede borrar el cheque porque ya está asociado a un gasto el día {fecha:dd/MM/yyy}.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    gastosTM.Borrar_Cheque(id);
                    grd.BorrarFila(f);
                }
            }

        }
    }
}
