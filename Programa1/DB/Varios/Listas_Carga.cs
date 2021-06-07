namespace Programa1.DB.Varios
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Listas_Carga : c_Base
    {
        private Productos prod = new Productos();
        /// <summary>
        /// Corresponde a la lista de Productos + Lista + Orden
        /// </summary>
        /// 
        public int Id { get; set; }
        public Listas_Carga()
        {
            Tabla = "Listas_Carga";
            Vista = "vw_Listas_Carga";
        }
        public Productos Producto
        {
            get { return prod; }
            set 
            {
                prod = value;
                //Buscar el orden                                
                Orden = Convert.ToInt32(Dato($"ID_Lista={Lista.ID} AND Producto={Producto.ID}", "Orden", "Orden")); 
            }
        }
        public int Orden { get; set; }
        public Nombre_Listas Lista { get; set; } = new Nombre_Listas();
        /// <summary>
        /// Devuelve la vista vw_Listas_Carga con el filtro de Lista.ID.
        /// </summary>
        /// <returns></returns>
        public DataTable Datos()
        {
            return Datos_Vista("ID_Lista=" + Lista.ID, "*", "Orden");
        }
        public DataTable Productos()
        {
            return Datos_Vista("ID_Lista=" + Lista.ID, "Producto, Nombre_Producto, ", " Orden");
        }

        /// <summary>
        /// Asigna el siguiente producto en la lista según el orden.
        /// Si no hay lista seleccionada devuelve el siguiente producto.
        /// </summary>
        /// <returns></returns>
        public int Producto_Siguiente()
        {
            if (Lista.ID != 0)
            {
                Producto.ID = Convert.ToInt32(Dato($"ID_Lista={Lista.ID} AND Orden>{Orden}", "Producto", "Orden"));
                
                if (Producto.Existe() == false)
                {
                    Producto.ID = Convert.ToInt32(Dato($"ID_Lista={Lista.ID} AND Orden>0", "Producto", "Orden"));
                    Producto.Existe();
                }                
                Orden = Convert.ToInt32(Dato($"ID_Lista={Lista.ID} AND Producto={Producto.ID}", "Orden", "Orden"));
            }
            else
            {
                Producto.Siguiente();                
            }            
            return Producto.ID;
        }

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Listas_Carga WHERE Id=" + Id, sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
    }
}
