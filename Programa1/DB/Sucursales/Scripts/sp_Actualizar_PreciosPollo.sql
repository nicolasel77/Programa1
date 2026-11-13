-- =====================================================================
-- dbDatos.dbo.sp_Actualizar_PreciosPollo
--
-- Recalcula los precios de franquicia del pollo y sus cortes de UNA semana
-- (lunes a domingo) para todas las sucursales, siguiendo "precios pollo.xlsx":
--
--   1. Costo pollo (300) = promedio de compra de la semana en la sucursal
--      (Ventas: SUM(Kilos * Costo_Compra) / SUM(Kilos)).
--   2. Precios de lista al domingo de esa semana (Precios_Sucursales).
--   3. % = (Venta pollo - Costo pollo) / Costo pollo.
--   4. Costo del resto = Venta / (1 + %).
--   5. Guarda los precios en Precios_Franquicia con fecha del lunes y
--      actualiza Costo_Franquicia de Stock y Costo_SalidaFR / Costo_EntradaFR
--      de Traslados de esa semana.
--
-- Uso:
--   EXEC dbo.sp_Actualizar_PreciosPollo;                    -- semana pasada, solo muestra (no graba)
--   EXEC dbo.sp_Actualizar_PreciosPollo @Simular = 0;       -- semana pasada, graba
--   EXEC dbo.sp_Actualizar_PreciosPollo '2026-11-05', 0;    -- semana que contiene esa fecha, graba
--
-- Las sucursales sin compra de pollo en la semana o sin precio de lista
-- del pollo no se tocan (salen en el resultado con Estado distinto de 'OK').
-- =====================================================================
USE dbDatos;
GO

IF OBJECT_ID('dbo.sp_Actualizar_PreciosPollo', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Actualizar_PreciosPollo;
GO

CREATE PROCEDURE dbo.sp_Actualizar_PreciosPollo
    @Fecha   date = NULL,   -- cualquier día de la semana a procesar; NULL = semana pasada
    @Simular bit  = 1       -- 1 = solo devuelve el cálculo, 0 = graba
AS
BEGIN
    SET NOCOUNT ON;

    IF @Fecha IS NULL SET @Fecha = DATEADD(DAY, -7, CAST(GETDATE() AS date));

    -- Lunes y domingo de la semana (01/01/1900 fue lunes; no depende de DATEFIRST)
    DECLARE @Lunes   date = DATEADD(DAY, -(DATEDIFF(DAY, '19000101', @Fecha) % 7), @Fecha);
    DECLARE @Domingo date = DATEADD(DAY, 6, @Lunes);

    -- Productos de la planilla. El 300 (Pollo) es la base del cálculo.
    DECLARE @Prod TABLE (Id_Productos int PRIMARY KEY);
    INSERT INTO @Prod VALUES (300), (310), (311), (314), (315), (316), (317);

    -- 1. Promedio de compra del pollo por sucursal en la semana
    DECLARE @Base TABLE (
        Id_Sucursales int PRIMARY KEY,
        Kilos         float,
        Costo         float,
        Venta         float,
        Porc          float,
        Estado        varchar(40));

    INSERT INTO @Base (Id_Sucursales, Kilos, Costo)
    SELECT S.Id,
           C.Kilos,
           CASE WHEN C.Kilos > 0 THEN C.Total / C.Kilos END
    FROM Sucursales S
    LEFT JOIN (SELECT Id_Sucursales,
                      SUM(Kilos) AS Kilos,
                      SUM(Kilos * Costo_Compra) AS Total
               FROM Ventas
               WHERE Id_Productos = 300
                 AND Fecha BETWEEN @Lunes AND @Domingo
               GROUP BY Id_Sucursales) C ON C.Id_Sucursales = S.Id
    WHERE S.Ver = 1;

    -- 2. Precio de lista del pollo al domingo
    UPDATE B SET Venta = (SELECT TOP 1 P.Precio FROM Precios_Sucursales P
                          WHERE P.Id_Sucursales = B.Id_Sucursales
                            AND P.Id_Productos = 300
                            AND P.Fecha <= @Domingo
                          ORDER BY P.Fecha DESC)
    FROM @Base B;

    -- 3. Diferencia (%)
    UPDATE @Base SET
        Estado = CASE WHEN ISNULL(Kilos, 0) <= 0 OR ISNULL(Costo, 0) <= 0 THEN 'Sin compra de pollo'
                      WHEN ISNULL(Venta, 0) <= 0 THEN 'Sin precio de lista'
                      ELSE 'OK' END;
    UPDATE @Base SET Porc = (Venta - Costo) / Costo WHERE Estado = 'OK';

    -- 4. Precios de franquicia de todos los productos
    DECLARE @Nuevos TABLE (
        Id_Sucursales int,
        Id_Productos  int,
        Venta         float,
        Precio        float,
        PRIMARY KEY (Id_Sucursales, Id_Productos));

    INSERT INTO @Nuevos (Id_Sucursales, Id_Productos, Venta, Precio)
    SELECT B.Id_Sucursales, X.Id_Productos, V.Precio,
           CASE WHEN X.Id_Productos = 300 THEN B.Costo
                ELSE V.Precio / (1 + B.Porc) END
    FROM @Base B
    CROSS JOIN @Prod X
    CROSS APPLY (SELECT TOP 1 P.Precio FROM Precios_Sucursales P
                 WHERE P.Id_Sucursales = B.Id_Sucursales
                   AND P.Id_Productos = X.Id_Productos
                   AND P.Fecha <= @Domingo
                 ORDER BY P.Fecha DESC) V
    WHERE B.Estado = 'OK' AND ISNULL(V.Precio, 0) > 0;

    UPDATE @Nuevos SET Precio = ROUND(Precio, 2);

    IF @Simular = 0
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;

            -- 5a. Precios_Franquicia: se reemplazan los de esa semana por uno con fecha del lunes
            DELETE PF FROM Precios_Franquicia PF
            INNER JOIN @Nuevos N ON N.Id_Sucursales = PF.Id_Sucursales AND N.Id_Productos = PF.Id_Productos
            WHERE PF.Fecha BETWEEN @Lunes AND @Domingo;

            INSERT INTO Precios_Franquicia (Fecha, Id_Sucursales, Id_Productos, Precio)
            SELECT @Lunes, Id_Sucursales, Id_Productos, Precio FROM @Nuevos;

            -- 5b. Stock
            UPDATE S SET Costo_Franquicia = N.Precio
            FROM Stock S
            INNER JOIN @Nuevos N ON N.Id_Sucursales = S.Id_Sucursales AND N.Id_Productos = S.Id_Productos
            WHERE S.Fecha BETWEEN @Lunes AND @Domingo;

            -- 5c. Traslados (salida y entrada con el precio de cada sucursal)
            UPDATE T SET Costo_SalidaFR = N.Precio
            FROM Traslados T
            INNER JOIN @Nuevos N ON N.Id_Sucursales = T.Suc_Salida AND N.Id_Productos = T.Id_Productos
            WHERE T.Fecha BETWEEN @Lunes AND @Domingo;

            UPDATE T SET Costo_EntradaFR = N.Precio
            FROM Traslados T
            INNER JOIN @Nuevos N ON N.Id_Sucursales = T.Suc_Entrada AND N.Id_Productos = T.Id_Productos
            WHERE T.Fecha BETWEEN @Lunes AND @Domingo;

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
            THROW;
        END CATCH
    END

    -- Resultado 1: resumen por sucursal
    SELECT @Lunes AS Lunes, @Domingo AS Domingo,
           B.Id_Sucursales, S.Nombre, B.Kilos, B.Costo, B.Venta,
           ROUND(B.Porc * 100, 2) AS Porcentaje, B.Estado,
           CASE WHEN @Simular = 1 THEN 'Simulado' ELSE 'Grabado' END AS Modo
    FROM @Base B
    INNER JOIN Sucursales S ON S.Id = B.Id_Sucursales
    ORDER BY B.Id_Sucursales;

    -- Resultado 2: precios calculados
    SELECT N.Id_Sucursales, N.Id_Productos, P.Nombre, N.Venta, N.Precio
    FROM @Nuevos N
    LEFT JOIN Productos P ON P.Id = N.Id_Productos
    ORDER BY N.Id_Sucursales, N.Id_Productos;
END
GO

-- ---------------------------------------------------------------------
-- Opcional: si el servidor tiene SQL Server Agent (no viene en Express),
-- se puede programar para los lunes, por ejemplo a las 6:00:
--
--   Paso del job (base dbDatos):  EXEC dbo.sp_Actualizar_PreciosPollo @Simular = 0;
--   Programación: semanal, lunes, 06:00.
-- ---------------------------------------------------------------------
