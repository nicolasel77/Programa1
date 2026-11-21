-- =============================================================================
-- Cuentas de Programa1 con los datos que carga la sucursal (Sistema-Web)
-- Ejecutar completo en dbDatos.
--
-- Desde la FECHA DE CORTE, para las sucursales propias:
--   * Efectivo  = lo que carga la sucursal en Efectivos  (dbGastos.dbo.Efectivos)
--                 antes: caja de Tesoreria (vw_Entregas_Suc = CD_Entradas + Fecha_Entregas)
--   * Tarjetas  = lo que carga la sucursal en Entregas   (dbGastos.dbo.Entregas_Sucursales)
--                 antes: archivos de los procesadores    (dbGastos.dbo.Entradas_Tarjeta)
-- Antes de la fecha de corte no cambia nada, asi las semanas cerradas dan igual.
-- Las franquicias no cambian (cargan sus entregas en Entregas_Franquicia).
--
-- Cambia: f_Balance, f_Recaudacion, sp_ResumenSalidasSuc.
-- Crea:   f_FechaCorteSucursal, vw_Declarado_Efectivo, vw_Declarado_Tarjetas,
--         vw_Control_Declarado (sucursal contra caja y procesadores, por dia).
-- No cambia: f_GastoPrisma ni f_PagosFaltantesTarjeta (siguen con los archivos
-- de los procesadores, porque calculan comisiones y pagos reales).
--
-- FECHA DE CORTE: se guarda en Varios.dbo.Varios (Dato = 'fCorteSucursal',
-- Valor = 'aaaammdd'). Si no esta cargada se usa el lunes 30/11/2026.
-- Para volver atras sin tocar nada mas: poner Valor = '99991231'.
-- =============================================================================

-- 0. FECHA DE CORTE (cambiar '20261130' por '20261123' si se arranca antes)
DELETE FROM Varios.dbo.Varios WHERE Dato = 'fCorteSucursal'
INSERT INTO Varios.dbo.Varios (Dato, Valor) VALUES ('fCorteSucursal', '20261130')
GO

-- 1. FUNCION Y VISTAS NUEVAS
IF OBJECT_ID('dbo.f_FechaCorteSucursal') IS NOT NULL DROP FUNCTION dbo.f_FechaCorteSucursal
GO
CREATE FUNCTION dbo.f_FechaCorteSucursal()
RETURNS datetime
AS
BEGIN
	-- Desde esta fecha las cuentas de las propias toman efectivo y tarjetas de lo que carga la sucursal
	DECLARE @V varchar(50) = (SELECT TOP 1 CONVERT(varchar(50), Valor) FROM Varios.dbo.Varios WHERE Dato = 'fCorteSucursal')
	IF (@V IS NULL OR LEN(@V) <> 8 OR ISDATE(@V) = 0) RETURN CONVERT(datetime, '20261130', 112)
	RETURN CONVERT(datetime, @V, 112)
END
GO

IF OBJECT_ID('dbo.vw_Declarado_Efectivo') IS NOT NULL DROP VIEW dbo.vw_Declarado_Efectivo
GO
-- Efectivo que carga la sucursal en Sistema-Web (una fila por carga, fecha sin hora)
CREATE VIEW dbo.vw_Declarado_Efectivo
AS
SELECT	E.id AS Id, CAST(CAST(E.Fecha AS DATE) AS DATETIME) AS Fecha, E.ID_Sucursal AS Suc, S.Nombre, E.Importe, E.Cargado
FROM	dbGastos.dbo.Efectivos E
		LEFT JOIN dbo.Sucursales S ON S.Id = E.ID_Sucursal
GO

IF OBJECT_ID('dbo.vw_Declarado_Tarjetas') IS NOT NULL DROP VIEW dbo.vw_Declarado_Tarjetas
GO
-- Tarjetas / transferencias que carga la sucursal en Sistema-Web > Entregas (una fila por carga, fecha sin hora)
CREATE VIEW dbo.vw_Declarado_Tarjetas
AS
SELECT	E.Id, CAST(CAST(E.Fecha AS DATE) AS DATETIME) AS Fecha, E.Suc, E.Tipo AS Id_Tipo, ISNULL(T.Nombre, 'Tipo ' + CONVERT(varchar, E.Tipo)) AS Nombre, E.Importe
FROM	dbGastos.dbo.Entregas_Sucursales E
		LEFT JOIN dbGastos.dbo.Tipo_Cuentas T ON T.Id = E.Tipo
GO

IF OBJECT_ID('dbo.vw_Control_Declarado') IS NOT NULL DROP VIEW dbo.vw_Control_Declarado
GO
-- Control: lo que carga la sucursal contra lo que entra a caja (efectivo) y lo que
-- informan los procesadores (tarjetas), por sucursal propia, dia y concepto.
-- Id_Tipo 0 = Efectivo. Diferencia = Sucursal - Control (negativo = la sucursal cargo de menos).
CREATE VIEW dbo.vw_Control_Declarado
AS
SELECT	X.Fecha, X.Suc, S.Nombre, X.Id_Tipo,
		CASE WHEN X.Id_Tipo = 0 THEN 'Efectivo' ELSE ISNULL(T.Nombre, 'Tipo ' + CONVERT(varchar, X.Id_Tipo)) END AS Concepto,
		SUM(X.Sucursal) AS Sucursal, SUM(X.Control) AS Control, SUM(X.Sucursal) - SUM(X.Control) AS Diferencia
FROM	(
		SELECT Fecha, Suc, 0 AS Id_Tipo, Importe AS Sucursal, 0 AS Control FROM dbo.vw_Declarado_Efectivo
		UNION ALL
		SELECT CAST(CAST(Fecha AS DATE) AS DATETIME), Suc, 0, 0, Importe FROM dbo.vw_Entregas_Suc
		UNION ALL
		SELECT Fecha, Suc, Id_Tipo, Importe, 0 FROM dbo.vw_Declarado_Tarjetas
		UNION ALL
		SELECT CAST(CAST(Fecha AS DATE) AS DATETIME), Suc, Id_Tipo, 0, Importe FROM dbGastos.dbo.Entradas_Tarjeta
		) X
		INNER JOIN dbo.Sucursales S ON S.Id = X.Suc AND S.Propio = 1
		LEFT JOIN dbGastos.dbo.Tipo_Cuentas T ON T.Id = X.Id_Tipo
GROUP BY X.Fecha, X.Suc, S.Nombre, X.Id_Tipo, T.Nombre
GO

-- 2. CUENTAS
ALTER FUNCTION [dbo].[f_Balance]
(
	@Suc int, @F1 datetime, @F2 datetime
)
RETURNS float
AS
BEGIN
	DECLARE @T float, @Es_Sucursal bit
	-- Desde la fecha de corte, efectivo y tarjetas salen de lo que carga la sucursal en Sistema-Web
	DECLARE @FC datetime = dbo.f_FechaCorteSucursal()
	
	SET @Es_Sucursal = (SELECT Propio FROM Sucursales WHERE Id=@Suc)
	
	IF (@Es_Sucursal = 1)
		BEGIN
			--Stock Anterior
			SET @T = ISNULL((SELECT SUM(Total) FROM vw_Stock WHERE Fecha BETWEEN DATEADD(DAY, -7, @F1) AND DATEADD(DAY, -7, @F2) AND Id_Sucursales=@Suc), 0)
		END
	ELSE
		BEGIN
			--Saldo Anterior
			SET @T = ISNULL((SELECT Balance*-1 FROM Estadisticas_Sucursal WHERE Semana BETWEEN DATEADD(DAY, -7, @F1) AND DATEADD(DAY, -7, @F2) AND Id_Sucursales=@Suc), 0)
			--Entregas
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM vw_Entradas WHERE ID_TipoEntrada=5 AND Fecha BETWEEN @F1 AND @F2 AND ID_SubTipoEntrada=@Suc), 0)		
		END

	-- ENTRADA
		
	--Total de Entrada (Venta)
	SET @T = @T + ISNULL((SELECT SUM(Total_Venta) FROM vw_Ventas WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)	
	--Total de Carne
	SET @T = @T + ISNULL((SELECT SUM(Total_Salida) FROM vw_Hacienda_Salidas WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)
	--Medias Utilizadas
	SET @T = @T - ISNULL((SELECT SUM(Total_Salida) FROM vw_Hacienda_Salidas WHERE MU=1 AND Fecha=@F1 AND Id_Sucursales=@Suc), 0)
	SET @T = @T + ISNULL((SELECT SUM(Total_Salida) FROM vw_Hacienda_Salidas WHERE MU=1 AND Fecha=DATEADD(DAY,  1, @F2) AND Id_Sucursales=@Suc), 0)
	--Traslados Entrada
	SET @T = @T + ISNULL((SELECT SUM(Total_Entrada) FROM vw_Traslados WHERE Fecha BETWEEN @F1 AND @F2 AND Suc_Entrada=@Suc), 0)
	
	
	-- SALIDA

	--Devoluciones
	SET @T = @T - ISNULL((SELECT SUM(Total_Venta) FROM vw_Devoluciones WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)	
	--Reintegros
	SET @T = @T - ISNULL((SELECT SUM(Importe) FROM Reintegros WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)	
	--Traslados Salidas
	SET @T = @T - ISNULL((SELECT SUM(Total_Salida) FROM vw_Traslados WHERE Fecha BETWEEN @F1 AND @F2 AND Suc_Salida=@Suc), 0)

	IF (@Es_Sucursal = 1)
		BEGIN
			--Ofertas
			SET @T = @T - ISNULL((SELECT SUM(Reintegro) FROM vw_Ofertas WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)
			--A Picada
			SET @T = @T - ISNULL((SELECT SUM(Total_A-Total_S) FROM vw_APicada WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)
			--Gastos de Sucursal
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM Gastos_Sucursales WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)	
			--Entregas
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM vw_Entregas_Suc WHERE Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC AND Suc=@Suc), 0)
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM vw_Declarado_Efectivo WHERE Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC AND Suc=@Suc), 0)
			--Tarjetas
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM dbGastos.dbo.Entradas_Tarjeta WHERE Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC AND Suc=@Suc), 0)
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM vw_Declarado_Tarjetas WHERE Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC AND Suc=@Suc), 0)
			
			--Empleados
			SET @T = @T - ISNULL((SELECT SUM(Importe) FROM dbEmpleados.dbo.Retiros WHERE CAST(Semana AS DATE) BETWEEN @F1 AND DATEADD(HOUR, 20, @F2) AND Suc=@Suc AND Tipo NOT IN(6, 10) AND (Tipo_Descuento=0 OR Tipo_Descuento IS NULL)), 0)		
		
			--Señas
			--*********************
	
			--Stock
			SET @T = @T - ISNULL((SELECT SUM(Total) FROM vw_Stock WHERE Fecha BETWEEN @F1 AND @F2 AND Id_Sucursales=@Suc), 0)
		END
	
	RETURN @T * -1

END
GO

-- =============================================
-- Author:		No se
-- Create date: 27/08/21
-- =============================================
ALTER FUNCTION [dbo].[f_Recaudacion]
(
	@Suc int, @f1 date, @f2 date
)
RETURNS float
AS
BEGIN
	DECLARE @Entrada_CDGastos float, @Tarjetas float, @Reintegros float, @stAnt float, @Stock float, @Empleados float
	-- Desde la fecha de corte, efectivo y tarjetas de las sucursales propias salen de lo que carga la sucursal en Sistema-Web
	DECLARE @FC datetime = CASE WHEN (SELECT Propio FROM Sucursales WHERE Id=@Suc) = 1 THEN dbo.f_FechaCorteSucursal() ELSE '99991231' END
	
	SET @Stock = ISNULL((SELECT SUM(Kilos) FROM vw_Stock WHERE Fecha BETWEEN @f1 and @f2 AND Id_Sucursales=@Suc AND Id_Tipo=7), 0)
	
	SET @Reintegros = ISNULL((SELECT SUM(Importe) FROM vw_Reintegros WHERE Fecha BETWEEN @f1 and @f2 AND Id_Sucursales=@Suc AND Id_Tipo<>1), 0)
	SET @Entrada_CDGastos = ISNULL((SELECT SUM(Importe) FROM vw_Entregas_Suc WHERE Fecha BETWEEN @f1 and @f2 AND Fecha < @FC AND Suc=@Suc), 0)
		+ ISNULL((SELECT SUM(Importe) FROM vw_Declarado_Efectivo WHERE Fecha BETWEEN @f1 and @f2 AND Fecha >= @FC AND Suc=@Suc), 0)
	SET @Tarjetas = ISNULL((SELECT SUM(Importe) FROM vw_Tarjetas WHERE Fecha BETWEEN @f1 and @f2 AND Fecha < @FC AND Suc=@Suc), 0)
		+ ISNULL((SELECT SUM(Importe) FROM vw_Declarado_Tarjetas WHERE Fecha BETWEEN @f1 and @f2 AND Fecha >= @FC AND Suc=@Suc), 0)
	SET @Empleados = (SELECT dbo.f_TEmpleados(@Suc, @f1, @f2)) --ISNULL((SELECT SUM(Importe) FROM dbEmpleados.dbo.Retiros WHERE Semana BETWEEN @f1 and @f2 AND Suc=@Suc AND Tipo NOT IN(2, 6, 10)), 0)

	SET @stAnt = ISNULL((SELECT SUM(Kilos) FROM vw_Stock WHERE Fecha BETWEEN DATEADD(DAY, -7, @f1) and DATEADD(DAY, -1, @f1) AND Id_Sucursales=@Suc AND Id_Tipo=7), 0)	

	RETURN @Reintegros + @Stock + @Entrada_CDGastos + @Tarjetas + @Empleados - @stAnt 

END
GO

ALTER PROCEDURE [dbo].[sp_ResumenSalidasSuc]
	@Suc int, @F1 datetime, @F2 datetime, @Filtro int = 0
AS
BEGIN
	DELETE FROM t_ResumenSuc
	
	DECLARE @Propio bit = (SELECT Propio FROM Sucursales WHERE Id=@Suc)
	-- Desde la fecha de corte, efectivo y tarjetas de las propias salen de lo que carga la sucursal en Sistema-Web
	DECLARE @FC datetime = CASE WHEN @Propio = 1 THEN dbo.f_FechaCorteSucursal() ELSE '99991231' END
	
	IF (@Filtro = 8 OR @Filtro=0)
	BEGIN
	--GASTOS SUCURSAL
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, 'Gastos', Id_Sucursales, COUNT(Importe), 0, 0, SUM(Importe), 0,
		'SELECT Fecha, Id_Sucursales Suc, Nombre, Id_Tipo, Descripcion, Importe FROM vw_GastosSucursales WHERE ' + 
		' Id_Sucursales=' + CONVERT(VARCHAR, @Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1) + ''' ORDER BY Id'
		FROM Gastos_Sucursales WHERE Id_Sucursales=@Suc AND Fecha BETWEEN @F1 AND @F2
		GROUP BY Fecha, Id_Sucursales
	END

	IF (@Filtro = 4 OR @Filtro=0)
	BEGIN	
	--REINTEGROS
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, Descripcion, Id_Sucursales, 0, 0, 0, SUM(Importe), 1,
		'SELECT Fecha, Id_Sucursales Suc, Nombre, Id_Tipo, Descripcion, Importe FROM vw_Reintegros WHERE ' + 
		' Id_Sucursales=' + CONVERT(VARCHAR, @Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1) + ''' ORDER BY Id'
		FROM vw_Reintegros WHERE Id_Sucursales=@Suc AND Fecha BETWEEN @F1 AND @F2
		GROUP BY Fecha, Id_Sucursales, Descripcion
	END
	
	IF (@Filtro = 5 OR @Filtro=0)
	BEGIN	
	--OFERTAS
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, 'Of: ' + Descripcion, Id_Sucursales, 0, Kilos, Costo_Oferta, Reintegro, 2,
		'SELECT Fecha, ID_Sucursales Suc, Nombre, ID_Productos Prod, Descripcion, Costo_Original, Costo_Oferta, Kilos, Reintegro FROM vw_Ofertas WHERE Id=' + CONVERT(VARCHAR, Id)
		FROM vw_Ofertas WHERE Id_Sucursales=@Suc AND Fecha BETWEEN @F1 AND @F2
	END

	IF (@Filtro = 6 OR @Filtro=0)
	BEGIN
	--A PICADA
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, 'A Picada: ' + Desc_A, Id_Sucursales, 0, Kilos_A, Costo_A, Reintegro, 2,
		'SELECT Fecha, ID_Sucursales Suc, Nombre, ID_Productos_A Prod_A, Desc_A, Kilos_A, ID_Productos_S Prod_S, Desc_S, Kilos_S, Costo_A, Costo_S, Reintegro FROM vw_APicada WHERE Id=' + CONVERT(VARCHAR, Id)
		FROM vw_APicada WHERE Id_Sucursales=@Suc AND Fecha BETWEEN @F1 AND @F2
	END

	IF (@Filtro = 1 OR @Filtro=0)
	BEGIN
		IF (@Propio = 1)
		BEGIN
			--EFECTIVO
			INSERT INTO t_ResumenSuc (Fecha, Descripcion, Total, ID, SQL)
				SELECT Fecha, 'Efectivo', Importe, 3,
				'SELECT Fecha, Suc, Importe FROM vw_Entregas_Suc WHERE Suc=' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
				FROM vw_Entregas_Suc WHERE Suc=@Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC
			--EFECTIVO CARGADO POR LA SUCURSAL
			INSERT INTO t_ResumenSuc (Fecha, Descripcion, Total, ID, SQL)
				SELECT Fecha, 'Efectivo', SUM(Importe), 3,
				'SELECT Fecha, Suc, Nombre, Importe FROM vw_Declarado_Efectivo WHERE Suc=' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Id'
				FROM vw_Declarado_Efectivo WHERE Suc=@Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC
				GROUP BY Fecha, Suc
		END
		ELSE
		BEGIN
			--PAGOS CLIENTES
			INSERT INTO t_ResumenSuc (Fecha, Descripcion, Total, ID, SQL)
				SELECT Fecha, 'Pago', Importe, 3,
				'SELECT Fecha, ID_SubTipoEntrada, Importe FROM vw_Entradas WHERE ID_TipoEntrada=1 AND ID_SubTipoEntrada=' + CONVERT(VARCHAR, ID_SubTipoEntrada) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
				FROM CD_Entradas WHERE ID_TipoEntrada=5 AND ID_SubTipoEntrada=@Suc AND Fecha BETWEEN @F1 AND @F2
		END
	END

	IF (@Filtro = 2 OR @Filtro=0)
	BEGIN
	--TARJETAS
	INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, Nombre, SUM(dbGastos.dbo.vw_EntradasTarjeta.Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM dbGastos.dbo.vw_EntradasTarjeta WHERE Id_Tipo=' + CONVERT(VARCHAR, Id_Tipo) + ' AND Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
		FROM dbGastos.dbo.vw_EntradasTarjeta
		WHERE Id_Tipo NOT IN (12) AND Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC
		GROUP BY Fecha, Id_Tipo, Suc, Nombre
	INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, Nombre, SUM(Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM vw_Declarado_Tarjetas WHERE Id_Tipo=' + CONVERT(VARCHAR, Id_Tipo) + ' AND Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Id'
		FROM vw_Declarado_Tarjetas
		WHERE Id_Tipo NOT IN (12) AND Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC
		GROUP BY Fecha, Id_Tipo, Suc, Nombre
	END

	IF (@Filtro = 9 OR @Filtro=0)
	BEGIN
	--CUENTA DNI
	INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, 'Cuenta DNI', SUM(dbGastos.dbo.vw_EntradasTarjeta.Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM dbGastos.dbo.vw_EntradasTarjeta WHERE Id_Tipo = 12 AND Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
		FROM dbGastos.dbo.vw_EntradasTarjeta
		WHERE Id_Tipo = 12 AND Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC
		GROUP BY Fecha, Suc
	INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, 'Cuenta DNI', SUM(Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM vw_Declarado_Tarjetas WHERE Id_Tipo = 12 AND Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Id'
		FROM vw_Declarado_Tarjetas
		WHERE Id_Tipo = 12 AND Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC
		GROUP BY Fecha, Suc
	END


	IF (@Filtro = 10)
	BEGIN
	--TARJETAS 
		INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, Nombre, SUM(dbGastos.dbo.vw_EntradasTarjeta.Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM dbGastos.dbo.vw_EntradasTarjeta WHERE Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
		FROM dbGastos.dbo.vw_EntradasTarjeta
		WHERE Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha < @FC
		GROUP BY Fecha, Suc, Nombre
		INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		SELECT Fecha, Nombre, SUM(Importe), 4, 
		'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM vw_Declarado_Tarjetas WHERE Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Id'
		FROM vw_Declarado_Tarjetas
		WHERE Suc = @Suc AND Fecha BETWEEN @F1 AND @F2 AND Fecha >= @FC
		GROUP BY Fecha, Suc, Nombre

		--INSERT INTO t_ResumenSuc(Fecha, Descripcion, Total, ID, SQL)
		--SELECT Fecha, 'Cuenta DNI', SUM(dbGastos.dbo.vw_EntradasTarjeta.Importe), 4, 
		--'SELECT Suc, Fecha, ID_Tipo, Nombre, Importe FROM dbGastos.dbo.vw_EntradasTarjeta WHERE Id_Tipo = 12 AND Suc = ' + CONVERT(VARCHAR, Suc) + ' AND Fecha=''' + CONVERT(VARCHAR(8), Fecha, 1)  + ''' ORDER BY Fecha'
		--FROM dbGastos.dbo.vw_EntradasTarjeta
		--WHERE Id_Tipo = 12 AND Suc = @Suc AND Fecha BETWEEN @F1 AND @F2
		--GROUP BY Fecha, Suc
	END

	--SEÑAS
	
	--Medias Utilizadas
	
	IF (@Filtro = 3 OR @Filtro=0)
	BEGIN
     --TRASLADOS SALIDA
    INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, CAST(Descripcion AS VARCHAR(20)) + '.. A ' + CAST(Suc_Entrada AS VARCHAR(5)), Suc_Entrada, 0, Kilos, Costo_Salida, Total_Salida, 8,
		'SELECT Fecha, Suc_Salida, Nombre_Salida, Suc_Entrada, Nombre_Entrada, Id_Productos, Descripcion, Costo_Salida, Costo_Entrada, Kilos, Total_Salida, Total_Entrada
		FROM vw_Traslados WHERE Id=' + CONVERT(VARCHAR, Id) + '  ORDER BY Id'
		FROM vw_Traslados WHERE Suc_Salida=@Suc AND Fecha BETWEEN @F1 AND @F2
	END

	IF (@Filtro = 7 OR @Filtro=0)
	BEGIN

	--EMPLEADOS
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT SemanaDate,
		'Retiros Empleados',
		Suc,
		0, 0, 0,
		SUM(Importe)	
		, 9,
		'SELECT Semana, Empleado, Nombre, Tipo, Descripcion, Importe 
		 FROM dbEmpleados.dbo.vw_Retiros 
		 WHERE (Importe < -0.5 OR Importe > 0.5) 
		   AND Tipo NOT IN (2, 6, 10, 12, 13) 
		   AND CAST(Semana AS DATE) = ''' + CONVERT(VARCHAR(8), SemanaDate, 1) + ''' 						
		   AND Suc=' + CONVERT(VARCHAR, Suc) + ' 
		 ORDER BY Semana, Tipo'
		FROM (
    SELECT 
        CAST(Semana AS DATE) AS SemanaDate,
        Suc,
        Importe
    FROM dbEmpleados.dbo.Retiros
    WHERE 
        Suc = @Suc
        AND CAST(Semana AS DATE) BETWEEN @F1 AND DATEADD(hour, 15, @F2)
        AND Importe <> 0
        AND Tipo NOT IN (2, 6, 10, 12, 13)
        AND (Tipo_Descuento = 0 OR Tipo_Descuento IS NULL)
) t
GROUP BY SemanaDate, Suc
		--FROM dbEmpleados.dbo.Retiros WHERE Suc=@Suc AND CAST(Semana AS DATE) BETWEEN @F1 AND DATEADD(hour, 15, @F2) AND Importe<>0 AND Tipo NOT IN(2, 6, 10, 12, 13) AND (Tipo_Descuento=0 OR Tipo_Descuento IS NULL)
		--GROUP BY CAST(Semana AS DATE), Suc

	----PRESENTISMO
	--INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
	--SELECT Fecha_imputacion Semana, 'Presentismo Empleados', Suc, 0, 0, 0, SUM(Importe), 9,
	--	'SELECT Fecha_imputacion Fecha, Empleado, Nombre, Importe FROM dbEmpleados.dbo.vw_Presentismo WHERE Fecha_imputacion=''' + CONVERT(VARCHAR(8), @F1, 1)  + ''''		
	--	+ ' AND Suc=' + CONVERT(VARCHAR, Suc) + ' ORDER BY Empleado'
	--	FROM dbEmpleados.dbo.vw_Presentismo WHERE Suc=@Suc AND Fecha_imputacion BETWEEN @F1 AND @F2
	--	GROUP BY Fecha_imputacion, Suc
	END
	
	IF (@Filtro=0)
	BEGIN
	--STOCK
	INSERT INTO t_ResumenSuc (Fecha, Descripcion, ID_Proveedor, Cant, Kilos, Costo, Total, ID, SQL)
		SELECT Fecha, 'Stock', 0, COUNT(Kilos), SUM(Kilos), 0, SUM(Total), 10,
		'SELECT Fecha, Id_Sucursales Suc, Nombre, Id_Productos Prod, Descripcion, Costo, Kilos, Total
		FROM vw_Stock WHERE Id_Sucursales=' + CONVERT(VARCHAR, @Suc)
		 + ' AND Fecha BETWEEN ''' + CONVERT(VARCHAR(8), DATEADD(DAY, -6, @F2), 1) + ''' AND ''' + CONVERT(VARCHAR(8), @F2, 1) + '''  ORDER BY Id'
		FROM vw_Stock WHERE Id_Sucursales=@Suc AND Fecha BETWEEN DATEADD(DAY, -6, @F2) AND @F2
		GROUP BY Fecha
	END
	SELECT * FROM t_ResumenSuc ORDER BY Fecha, ID
END
GO



-- =============================================================================
-- 3. CONTROLES (opcional, solo lectura). Cambiar sucursal y lunes.
-- =============================================================================
-- Fecha de corte vigente:
--   SELECT dbo.f_FechaCorteSucursal() AS FechaCorte
--
-- Balance de una semana (antes del corte tiene que dar igual que antes de correr el script):
--   SELECT dbo.f_Balance(1, '20261116', '20261122') AS Balance
--
-- Diferencias de una semana, solo las que no cierran:
--   SELECT * FROM vw_Control_Declarado
--   WHERE Fecha BETWEEN '20261116' AND '20261122' AND ABS(Diferencia) > 1
--   ORDER BY Suc, Fecha, Id_Tipo
--
-- Tipos que cargan las sucursales en Entregas (revisar que no haya "Efectivo"
-- entre ellos, porque se sumaria dos veces con Efectivos):
--   SELECT DISTINCT Id_Tipo, Nombre FROM vw_Declarado_Tarjetas ORDER BY Id_Tipo
