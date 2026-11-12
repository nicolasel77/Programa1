-- Formatos de los archivos de tarjetas (frmLeer_Tarjetas / frmFormatos_Tarjeta).
-- Correr una sola vez. Mientras la tabla no exista, el programa usa los formatos predeterminados
-- y el panel de formatos no puede guardar cambios.
--
-- Cada Col_* guarda el nombre del encabezado ("Importe", o varias alternativas "Importe|Monto bruto")
-- o una posición fija ("#12" = columna 12). Vacío = el archivo no trae ese dato.
-- Id_Tipo = 0 es el formato de los tipos que no tienen uno propio.

IF OBJECT_ID('dbGastos.dbo.Formatos_Tarjeta', 'U') IS NULL
BEGIN
    CREATE TABLE dbGastos.dbo.Formatos_Tarjeta
    (
        Id_Tipo               INT           NOT NULL CONSTRAINT PK_Formatos_Tarjeta PRIMARY KEY,
        Fila_Encabezado       INT           NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Fila DEFAULT (0),   -- 0 = buscarla sola
        Col_Fecha             NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Fecha DEFAULT (''),
        Col_Fecha_Filtro      NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_FFiltro DEFAULT (''),
        Col_Fecha_Pago        NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_FPago DEFAULT (''),
        Col_Sucursal          NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Suc DEFAULT (''),
        Col_Importe           NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Importe DEFAULT (''),
        Col_Lote              NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Lote DEFAULT (''),
        Col_Comprobante       NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Comp DEFAULT (''),
        Col_Tarjeta           NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Tarjeta DEFAULT (''),
        Col_Estado            NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_Estado DEFAULT (''),
        Estados_Validos       NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_EValidos DEFAULT (''),  -- separados por ;
        Estados_Dia_Siguiente NVARCHAR(200) NOT NULL CONSTRAINT DF_Formatos_Tarjeta_ESig DEFAULT (''),      -- separados por ;
        Suc_Despues_De        NVARCHAR(50)  NOT NULL CONSTRAINT DF_Formatos_Tarjeta_SucTexto DEFAULT (''),
        Comprobante_Largo     INT           NOT NULL CONSTRAINT DF_Formatos_Tarjeta_CompLargo DEFAULT (0),  -- + primeros N, - últimos N
        Lote_Fijo             INT           NOT NULL CONSTRAINT DF_Formatos_Tarjeta_LoteFijo DEFAULT (0),
        Tarjeta_Fijo          INT           NOT NULL CONSTRAINT DF_Formatos_Tarjeta_TarjFijo DEFAULT (0)
    );
END
