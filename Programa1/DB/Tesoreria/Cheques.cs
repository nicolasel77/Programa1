namespace Programa1.DB.Tesoreria
{
    using Programa1.Carga.Tesoreria;
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Cheques : c_Base
    {
        public Cheques()
        {
            Tabla = "Cheques";
            Vista = "vw_Cheques";
            
            Campo_Nombre = "Numero";
            ID_Automatico = true;
        }

        public List<Cheques> cheques_seleccionados = new List<Cheques>();

        public Bancos Banco { get; set; } = new Bancos();
        public int Numero { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public DateTime Fecha_Acreditacion { get; set; }
        public double Importe { get; set; }
        public bool E_Cheq { get; set; }
        public int ID_Caja { get; set; }

        #region " Editar Datos "
        public void Cargar_Nuevo()
        {
            frmCheques fr = new frmCheques();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Nuevo_Cheque == true)
            {
                ID = fr.ch.ID;
                Banco = fr.ch.Banco;
                Numero = fr.ch.Numero;
                Fecha_Entrada = fr.ch.Fecha_Entrada;
                Fecha_Acreditacion = fr.ch.Fecha_Acreditacion;
                Importe = fr.ch.Importe;
                E_Cheq = fr.ch.E_Cheq;
                ID_Caja = fr.ch.ID_Caja;
            }
            else
            {
                ID = 0;
                Banco.ID = 0;
                Numero = 0;
                Fecha_Entrada = new DateTime(1900, 1, 1);
                Fecha_Acreditacion = new DateTime(1900, 1, 1);
                Importe = 0;
                E_Cheq = false;
                ID_Caja = 0;
            }
        }

        public void Seleccionar_Cheques()
        {
            frmCheques fr = new frmCheques();            
            fr.Cargar(true);
            fr.ShowDialog();
            cheques_seleccionados = fr.cheques_seleccionados;
        }

        public void Buscar_Cheque(int n = 0)
        {
            if (n == 0) { n = Numero; }
            DataTable dt = Datos_Vista("Numero=" + n);
            if (dt.Rows.Count ==0)
            {
                ID = 0;
                Banco.ID = 0;
                Numero = 0;
                Fecha_Entrada = new DateTime(1900, 1, 1);
                Fecha_Acreditacion = new DateTime(1900, 1, 1);
                Importe = 0;
                E_Cheq = false;
                ID_Caja = 0;
            }
            else
            {
                ID = Convert.ToInt32( dt.Rows[0]["ID"]);
                ID_Caja = Convert.ToInt32(dt.Rows[0]["ID_Caja"]);
                Banco.ID = Convert.ToInt32(dt.Rows[0]["ID_Banco"]);
                Numero = Convert.ToInt32(dt.Rows[0]["Numero"]);
                Fecha_Entrada = Convert.ToDateTime(dt.Rows[0]["Fecha_Entrada"]);
                Fecha_Acreditacion = Convert.ToDateTime(dt.Rows[0]["Fecha_Acreditacion"]);
                Importe = Convert.ToInt32(dt.Rows[0]["Importe"]);
                E_Cheq = Convert.ToBoolean(dt.Rows[0]["eCheq"]);
            }
        }

        public new void Agregar()
        {
            Agregar_NoID("Numero", Numero);
            ID = Max_ID();
            Actualizar();            
        }
        public new void Actualizar()
        {
            Actualizar("Numero", Numero);
            Actualizar("ID_Banco", Banco.ID);
            Actualizar("Fecha_Entrada", Fecha_Entrada);
            Actualizar("Fecha_Acreditacion", Fecha_Acreditacion);
            Actualizar("Importe", Importe);
            Actualizar("eCheq", E_Cheq);
            Actualizar("ID_Caja", ID_Caja);
        }

        #endregion

        
    }
}
