using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB
{
    class Faena
    {
        public Faena()
        {

        }

        public Faena(int id,
                     NBoletas nBoleta,
                     DateTime fecha,
                     Categorias categoria,
                     int nRomaneo,
                     int tropa,
                     Frigorificos frigorifico,
                     Productos producto,
                     float recupero,
                     float kilos)
        {
            Id = id;
            this.nBoleta = nBoleta;
            Fecha = fecha;
            Categoria = categoria;
            NRomaneo = nRomaneo;
            Tropa = tropa;
            Frigorifico = frigorifico;
            Producto = producto;
            Recupero = recupero;
            Kilos = kilos;
        }

        public int Id { get; set; }
        public NBoletas nBoleta { get; set; } = new NBoletas();
        public DateTime Fecha { get; set; }
        public Categorias Categoria { get; set; } = new Categorias();
        public int NRomaneo { get; set; }
        public int Tropa { get; set; }
        public Frigorificos Frigorifico { get; set; } = new Frigorificos();
        public Productos Producto { get; set; } = new Productos();
        public Single Recupero { get; set; }
        public Single Kilos { get; set; }

        public DataTable Datos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Faena WHERE NBoleta=" + nBoleta.NBoleta, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
    }
}
