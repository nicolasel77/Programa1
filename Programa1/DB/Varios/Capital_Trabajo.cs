using Programa1.Clases;
using System;
using System.Data;

namespace Programa1.DB.Varios
{
    public class Capital_Trabajo : c_Base
    {
        private string[,] opciones = new string[3, 2];
        private DateTime vSem;
        private double vActivos = 0;
        private double vPasivos = 0;

        public Capital_Trabajo()
        {
            Tabla = "CTrabajo";
            Vista = "CTrabajo";

            opciones[0, 0] = "{vFecha}";
            opciones[1, 0] = "{vFechaFin}";
            opciones[2, 0] = "{vFecha+7}";

        }

        public DateTime Semana
        {
            get { return vSem; }
            set
            {
                opciones[0, 1] = $"'{value:MM/dd/yy}'";
                opciones[1, 1] = $"'{value.AddDays(6):MM/dd/yy}'";
                opciones[2, 1] = $"'{value.AddDays(7):MM/dd/yy}'";
                vSem = value;
            }
        }

        private DataTable datos(int tipo)
        {
            DataTable dtDatos = new DataTable("Datos");
            dtDatos.Columns.Add("Descripcion", typeof(String));
            dtDatos.Columns.Add("Importe", typeof(Double));

            Datos_Genericos dg = new Datos_Genericos();

            //  1º Datos a procesar
            DataTable dt = new DataTable();

            dt = Datos_Vista((tipo > 1) ? "Tipo>1" : "Tipo=" + tipo, "*", "Tipo, Orden");
            if (tipo == 0) { vActivos = 0; }
            if (tipo == 1) { vPasivos = 0; }

            //  2º Reemplazar las opciones
            foreach (DataRow dr in dt.Rows)
            {
                string f = dr["SQL_Consulta"].ToString();
                f = f.Replace(opciones[0, 0], opciones[0, 1]);
                f = f.Replace(opciones[1, 0], opciones[1, 1]);
                f = f.Replace(opciones[2, 0], opciones[2, 1]);

                DataTable dtg = dg.Datos(f);

                if (dtg != null)
                {
                    if (dtg.Rows[0][0] != DBNull.Value)
                    {
                        if (Convert.ToDouble(dtg.Rows[0][0]) != 0)
                        {
                            //  3º Agregar a dtDatos 
                            DataRow nr = dtDatos.NewRow();
                            nr[0] = dr["Texto"];
                            nr[1] = Convert.ToDouble(dtg.Rows[0][0]) * Convert.ToDouble(dr["Multiplicador"]);

                            //Esta linea es para conservar en memoria los valores de capital actual para calcular el resultado mas tarde.
                            if (tipo == 0)
                            {
                                vActivos += Convert.ToDouble(nr[1]);
                            }
                            else
                            {
                                if (tipo == 1)
                                {
                                    vPasivos += Convert.ToDouble(nr[1]);
                                }
                            }

                            dtDatos.Rows.Add(nr);
                        }
                    }
                }
            }
            return dtDatos;
        }

        public DataTable Activos()
        {
            return datos(0);
        }
        public DataTable Pasivos()
        {
            return datos(1);
        }
        public DataTable Resultado()
        {
            DataTable dt = datos(2);

            double t = 0;

            foreach (DataRow dr in dt.Rows)
            {
                t += Convert.ToDouble(dr[1]);
            }

            DataRow dn = dt.NewRow();
            dn[0] = "Resultado";
            dn[1] = t;
            dt.Rows.Add(dn);

            opciones[0, 1] = $"'{Semana.AddDays(-7):MM/dd/yy}'";
            opciones[1, 1] = $"'{Semana.AddDays(-1):MM/dd/yy}'";
            opciones[2, 1] = $"'{Semana:MM/dd/yy}'";


            t = vActivos - vPasivos;

            datos(0);
            datos(1);
            //DataTable dtAnterior = datos(0);
            //dtAnterior = datos(1);

            dn = dt.NewRow();
            dn[0] = "Dif Capital Ant";
            dn[1] = t - (vActivos - vPasivos);
            dt.Rows.Add(dn);

            //Inversion Externa S
            //Inversion Externa E

            return dt;
        }
    }
}
