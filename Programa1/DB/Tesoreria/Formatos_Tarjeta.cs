namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Describe cómo leer el archivo (Excel o CSV) de un tipo de tarjeta: qué columna tiene cada dato
    /// y qué filas se toman.
    ///
    /// Cada columna se indica de una de dos maneras:
    ///   - Por nombre de encabezado: "Importe". Admite alternativas separadas por |, ej: "Importe|Monto bruto".
    ///     Es la forma recomendada: sigue funcionando aunque agreguen o muevan columnas.
    ///   - Por posición: "#12" es la columna número 12 (la L). Deja de servir si cambian el orden.
    /// Vacío significa que el archivo no trae ese dato.
    /// </summary>
    public class Formato_Tarjeta
    {
        /// <summary>Tipo de tarjeta (dbGastos.dbo.Tipo_Cuentas). 0 = formato para los tipos sin formato propio.</summary>
        public int Id_Tipo;

        /// <summary>Fila de los títulos. 0 = buscarla automáticamente.</summary>
        public int Fila_Encabezado;

        public string Col_Fecha = "";
        /// <summary>Opcional: fecha que se compara contra el rango desde-hasta, si no es la misma que se guarda.</summary>
        public string Col_Fecha_Filtro = "";
        /// <summary>Opcional: si no hay o viene vacía se usa la fecha.</summary>
        public string Col_Fecha_Pago = "";
        public string Col_Sucursal = "";
        public string Col_Importe = "";
        public string Col_Lote = "";
        public string Col_Comprobante = "";
        public string Col_Tarjeta = "";
        public string Col_Estado = "";

        /// <summary>Estados que se importan, separados por punto y coma. Vacío = todos.</summary>
        public string Estados_Validos = "";
        /// <summary>Estados para los que la fecha de pago es el día siguiente, separados por punto y coma.</summary>
        public string Estados_Dia_Siguiente = "";

        /// <summary>
        /// Vacío: la columna de sucursal trae el número de cuenta/establecimiento y se busca en Suc_Cuentas.
        /// Con texto (ej: "SUC"): el número de sucursal es el que aparece después de ese texto.
        /// </summary>
        public string Suc_Despues_De = "";

        /// <summary>0 = comprobante completo, positivo = primeros N caracteres, negativo = últimos N.</summary>
        public int Comprobante_Largo;

        /// <summary>Valor de lote cuando no hay columna o viene vacía.</summary>
        public int Lote_Fijo;
        /// <summary>Valor de tarjeta cuando no hay columna o viene vacía.</summary>
        public int Tarjeta_Fijo;

        public Formato_Tarjeta Clonar()
        {
            return (Formato_Tarjeta)MemberwiseClone();
        }

        /// <summary>
        /// Formatos que trae el programa. Se usan mientras no haya uno guardado para el tipo.
        /// Los tipos 12, 13, 15 y 16 buscan las columnas por nombre de encabezado; el 9 y el resto
        /// siguen por posición, como estaban fijos en el código, hasta que se los configure.
        /// </summary>
        public static List<Formato_Tarjeta> Predeterminados()
        {
            return new List<Formato_Tarjeta>
            {
                // Fiserv, tarjetas tradicionales: vale para todos los tipos sin formato propio
                new Formato_Tarjeta { Id_Tipo = 0, Fila_Encabezado = 1, Col_Fecha = "#1", Col_Fecha_Pago = "#3", Col_Sucursal = "#5",
                    Col_Tarjeta = "#6", Col_Importe = "#8", Col_Lote = "#14" },
                // QR Fiserv
                new Formato_Tarjeta { Id_Tipo = 9, Fila_Encabezado = 1, Col_Fecha = "#1", Col_Sucursal = "#2", Col_Importe = "#3",
                    Col_Comprobante = "#4", Comprobante_Largo = 17, Col_Estado = "#7", Estados_Validos = "Aprobada",
                    Lote_Fijo = 1, Tarjeta_Fijo = 1 },
                // Fiserv Cuenta DNI
                new Formato_Tarjeta { Id_Tipo = 12, Col_Comprobante = "Nro. Transacción", Comprobante_Largo = -8, Col_Fecha = "Fecha",
                    Col_Estado = "Cód. Respuesta", Estados_Validos = "Aprobado", Col_Importe = "Monto total",
                    Col_Sucursal = "Terminal al Sello", Col_Lote = "Lote", Lote_Fijo = 0, Tarjeta_Fijo = 1 },
                // Nave (Banco Galicia): se filtra por fecha de operación y se guarda la de acreditación.
                // Los movimientos "Por acreditar" se pagan al día siguiente.
                new Formato_Tarjeta { Id_Tipo = 13, Col_Fecha_Filtro = "Fecha de operación", Col_Fecha = "Fecha de acreditación",
                    Col_Sucursal = "Local", Suc_Despues_De = "SUC", Col_Importe = "Monto bruto", Col_Estado = "Estado", Estados_Dia_Siguiente = "Por acreditar",
                    Lote_Fijo = 1, Tarjeta_Fijo = 1 },
                // Payway transferencia
                new Formato_Tarjeta { Id_Tipo = 15, Col_Fecha = "Fecha Aprobado", Col_Estado = "Estado actual", Estados_Validos = "ACREDITADO",
                    Col_Sucursal = "Nro terminal", Col_Importe = "Monto bruto" },
                // Payway débito
                new Formato_Tarjeta { Id_Tipo = 16, Col_Fecha = "Fecha Aprobado", Col_Estado = "Estado actual", Estados_Validos = "ACREDITADO",
                    Col_Sucursal = "Nro terminal", Col_Importe = "Monto bruto" },
            };
        }

        /// <summary>
        /// Elige el formato de un tipo: el guardado para el tipo, si no el que traía el programa para el tipo,
        /// si no el guardado como predeterminado (0) y por último el predeterminado del programa.
        /// </summary>
        public static Formato_Tarjeta Elegir(List<Formato_Tarjeta> guardados, int tipo)
        {
            List<Formato_Tarjeta> fijos = Predeterminados();
            Formato_Tarjeta f = Buscar_En(guardados, tipo);
            if (f == null) { f = Buscar_En(fijos, tipo); }
            if (f == null) { f = Buscar_En(guardados, 0); }
            if (f == null) { f = Buscar_En(fijos, 0); }

            f = f.Clonar();
            f.Id_Tipo = tipo;
            return f;
        }

        private static Formato_Tarjeta Buscar_En(List<Formato_Tarjeta> lista, int tipo)
        {
            if (lista == null) { return null; }
            foreach (Formato_Tarjeta f in lista)
            {
                if (f.Id_Tipo == tipo) { return f; }
            }
            return null;
        }
    }

    /// <summary>
    /// Formatos guardados en dbGastos.dbo.Formatos_Tarjeta (ver Formatos_Tarjeta.sql).
    /// Si la tabla todavía no existe, el programa sigue funcionando con los formatos predeterminados.
    /// </summary>
    public class Formatos_Tarjeta : c_Base
    {
        private static readonly string[] Textos =
        {
            "Col_Fecha", "Col_Fecha_Filtro", "Col_Fecha_Pago", "Col_Sucursal", "Col_Importe", "Col_Lote", "Col_Comprobante",
            "Col_Tarjeta", "Col_Estado", "Estados_Validos", "Estados_Dia_Siguiente", "Suc_Despues_De"
        };

        public Formatos_Tarjeta()
        {
            Tabla = "dbGastos.dbo.Formatos_Tarjeta";
            Vista = "dbGastos.dbo.Formatos_Tarjeta";
            Campo_ID = "Id_Tipo";
        }

        /// <summary>Mensaje del último error de base de datos, o vacío.</summary>
        public string Ultimo_Error = "";

        /// <summary>Devuelve los formatos guardados. Lista vacía si no hay ninguno o si falta la tabla.</summary>
        public List<Formato_Tarjeta> Guardados()
        {
            var lista = new List<Formato_Tarjeta>();
            Ultimo_Error = "";
            try
            {
                var dt = new DataTable();
                using (var cnn = new SqlConnection(cadCN))
                using (var da = new SqlDataAdapter($"SELECT * FROM {Tabla}", cnn))
                {
                    da.Fill(dt);
                }

                foreach (DataRow dr in dt.Rows)
                {
                    var f = new Formato_Tarjeta();
                    f.Id_Tipo = Entero(dr, "Id_Tipo");
                    f.Fila_Encabezado = Entero(dr, "Fila_Encabezado");
                    f.Col_Fecha = Texto(dr, "Col_Fecha");
                    f.Col_Fecha_Filtro = Texto(dr, "Col_Fecha_Filtro");
                    f.Col_Fecha_Pago = Texto(dr, "Col_Fecha_Pago");
                    f.Col_Sucursal = Texto(dr, "Col_Sucursal");
                    f.Col_Importe = Texto(dr, "Col_Importe");
                    f.Col_Lote = Texto(dr, "Col_Lote");
                    f.Col_Comprobante = Texto(dr, "Col_Comprobante");
                    f.Col_Tarjeta = Texto(dr, "Col_Tarjeta");
                    f.Col_Estado = Texto(dr, "Col_Estado");
                    f.Estados_Validos = Texto(dr, "Estados_Validos");
                    f.Estados_Dia_Siguiente = Texto(dr, "Estados_Dia_Siguiente");
                    f.Suc_Despues_De = Texto(dr, "Suc_Despues_De");
                    f.Comprobante_Largo = Entero(dr, "Comprobante_Largo");
                    f.Lote_Fijo = Entero(dr, "Lote_Fijo");
                    f.Tarjeta_Fijo = Entero(dr, "Tarjeta_Fijo");
                    lista.Add(f);
                }
            }
            catch (Exception e)
            {
                Ultimo_Error = e.Message;
            }
            return lista;
        }

        /// <summary>Formato a usar para el tipo (guardado o predeterminado).</summary>
        public Formato_Tarjeta Buscar(int tipo)
        {
            return Formato_Tarjeta.Elegir(Guardados(), tipo);
        }

        public bool Guardar(Formato_Tarjeta f)
        {
            Ultimo_Error = "";
            string sets = "Fila_Encabezado=@Fila_Encabezado, Comprobante_Largo=@Comprobante_Largo, Lote_Fijo=@Lote_Fijo, Tarjeta_Fijo=@Tarjeta_Fijo";
            string campos = "Id_Tipo, Fila_Encabezado, Comprobante_Largo, Lote_Fijo, Tarjeta_Fijo";
            string valores = "@Id_Tipo, @Fila_Encabezado, @Comprobante_Largo, @Lote_Fijo, @Tarjeta_Fijo";
            foreach (string t in Textos)
            {
                sets += $", {t}=@{t}";
                campos += $", {t}";
                valores += $", @{t}";
            }

            try
            {
                using (var cnn = new SqlConnection(cadCN))
                using (var cmd = new SqlCommand(
                    $"UPDATE {Tabla} SET {sets} WHERE Id_Tipo=@Id_Tipo; " +
                    $"IF @@ROWCOUNT = 0 INSERT INTO {Tabla} ({campos}) VALUES ({valores});", cnn))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", f.Id_Tipo);
                    cmd.Parameters.AddWithValue("@Fila_Encabezado", f.Fila_Encabezado);
                    cmd.Parameters.AddWithValue("@Comprobante_Largo", f.Comprobante_Largo);
                    cmd.Parameters.AddWithValue("@Lote_Fijo", f.Lote_Fijo);
                    cmd.Parameters.AddWithValue("@Tarjeta_Fijo", f.Tarjeta_Fijo);
                    cmd.Parameters.AddWithValue("@Col_Fecha", f.Col_Fecha ?? "");
                    cmd.Parameters.AddWithValue("@Col_Fecha_Filtro", f.Col_Fecha_Filtro ?? "");
                    cmd.Parameters.AddWithValue("@Col_Fecha_Pago", f.Col_Fecha_Pago ?? "");
                    cmd.Parameters.AddWithValue("@Col_Sucursal", f.Col_Sucursal ?? "");
                    cmd.Parameters.AddWithValue("@Col_Importe", f.Col_Importe ?? "");
                    cmd.Parameters.AddWithValue("@Col_Lote", f.Col_Lote ?? "");
                    cmd.Parameters.AddWithValue("@Col_Comprobante", f.Col_Comprobante ?? "");
                    cmd.Parameters.AddWithValue("@Col_Tarjeta", f.Col_Tarjeta ?? "");
                    cmd.Parameters.AddWithValue("@Col_Estado", f.Col_Estado ?? "");
                    cmd.Parameters.AddWithValue("@Estados_Validos", f.Estados_Validos ?? "");
                    cmd.Parameters.AddWithValue("@Estados_Dia_Siguiente", f.Estados_Dia_Siguiente ?? "");
                    cmd.Parameters.AddWithValue("@Suc_Despues_De", f.Suc_Despues_De ?? "");

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Ultimo_Error = e.Message;
                return false;
            }
        }

        /// <summary>Borra el formato guardado del tipo, que vuelve a usar el predeterminado.</summary>
        public bool Quitar(int tipo)
        {
            Ultimo_Error = "";
            try
            {
                using (var cnn = new SqlConnection(cadCN))
                using (var cmd = new SqlCommand($"DELETE FROM {Tabla} WHERE Id_Tipo=@Id_Tipo", cnn))
                {
                    cmd.Parameters.AddWithValue("@Id_Tipo", tipo);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Ultimo_Error = e.Message;
                return false;
            }
        }

        private static string Texto(DataRow dr, string campo)
        {
            if (!dr.Table.Columns.Contains(campo) || dr[campo] == DBNull.Value) { return ""; }
            return dr[campo].ToString().Trim();
        }

        private static int Entero(DataRow dr, string campo)
        {
            if (!dr.Table.Columns.Contains(campo) || dr[campo] == DBNull.Value) { return 0; }
            return Convert.ToInt32(dr[campo]);
        }
    }
}
