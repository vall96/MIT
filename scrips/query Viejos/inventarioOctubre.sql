USE [Digitel]
GO

/****** Object:  UserDefinedTableType [dbo].[InventarioTem]    Script Date: 30/10/2020 14:48:07 ******/
CREATE TYPE [dbo].[InventarioTem] AS TABLE(
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [date] NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
)
GO

CREATE TABLE [dbo].[Inventario](
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [date] NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Inventario_Procesos](
	[Proc_Codigo] [nvarchar](50) NOT NULL,
	[Proc_Descrip] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Proc_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Inventario_TipoMov](
	[TipoMov_Codigo] [nvarchar](50) NOT NULL,
	[TipoMov_Descrip] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TipoMov_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-01-10' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 11, N'cg', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', CAST(N'2020-07-10' AS Date), N'PROD', N'Almacen Zulia 1500- Digitel', 0, N'tn', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-05-10' AS Date), N'COM', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-25-09' AS Date), N'COM', N'almacen 203-Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Agua Limpia', CAST(N'2020-09-09' AS Date), N'COM', N'almacen 204-Digitel', 15, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-09-02' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Aceite Ligero', CAST(N'2020-25-08' AS Date), N'VENT', N'almacen 204-Digitel', 2, N'kg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-19-07' AS Date), N'VENT', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', CAST(N'2020-30-28' AS Date), N'PROD', N'Almacenes CFG. Digitel', 0, N'tn', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-05-09' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Tarjetas Madre', CAST(N'1996-05-09' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'tn', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2019-10-07' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Tarjetas Madre', CAST(N'2020-12-10' AS Date), N'PROD', N'Centro de distribución "La garita". Empresa Digitel', 0, N'tn', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-15-10' AS Date), N'COM', N'Centro de distribución "La garita". Empresa Digitel', 100, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', CAST(N'2020-12-10' AS Date), N'TRAS', N'almacen 203-Digitel', 800, N'tn', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-10-01' AS Date), N'COM', N'Almacenes CFG. Digitel', 133, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', CAST(N'2020-10-02' AS Date), N'PROD', N'Almacen Zulia 1500- Digitel', 555, N'tn', N'SAL')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'AJUS', N'Ajuste')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'ENT', N'Entrada')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'SAL', N'Salida')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'COM', N'Compra')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'PROD', N'Producción')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'TRAS', N'Traslado')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'VENT', N'Venta')
GO
---------------------------------------------------------------------------------------------------------------------------------------------

CREATE PROC [dbo].[SP_FiltrarFechas]
@fechainicial date,
@fechaFinal date
AS
--	SELECT*FROM Inventario WHERE Inv_Fecha BETWEEN convert(date,@fechaini,103)   AND convert(date,@fechaFinal,103)

SELECT *
FROM Inventario 
WHERE Inv_Fecha >= @fechainicial 
AND Inv_Fecha <= @fechaFinal
GO

CREATE PROC [dbo].[SP_FiltrarTipoMov]
(
@CodTipoMov NVARCHAR(50) 

)
AS
		BEGIN
			SELECT*FROM Inventario WHERE @CodTipoMov = Inv_TipoMov
		END
	

GO
-------------------------------------------------------------------------------------------------------------------------------------------------------

/****** Object:  StoredProcedure [dbo].[SP_ListarInventario]    Script Date: 30/10/2020 14:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_ListarInventario]
AS
	BEGIN
		SELECT*FROM Inventario
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarInvTipoMov]    Script Date: 30/10/2020 14:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarInvTipoMov]
AS
	BEGIN
		SELECT*FROM Inventario_TipoMov
	END

GO
/****** Object:  StoredProcedure [dbo].[Sp_ListarInvtProcesos]    Script Date: 30/10/2020 14:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Sp_ListarInvtProcesos]
AS
	BEGIN
		SELECT*FROM Inventario_Procesos
	END

GO
/****** Object:  StoredProcedure [dbo].[sp_listarMaquina]    Script Date: 30/10/2020 14:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------********************************------------------------------*******************************--------------------

CREATE PROC [dbo].[Sp_RegistrarMovInventario]
(
@dtRelacion [dbo].[InventarioTem] READONLY

)
AS
	BEGIN
		INSERT INTO Inventario
		(
		[Inv_CodArt],
		[Inv_Fecha],
		[Inv_TipoMov],
		[Inv_Almacen],
		[Inv_Cantidad],
		[Inv_Unidad],
--		[Inv_UnidadDescrip],
		[Inv_Proceso]
		
		)
		SELECT 
		[Inv_CodArt],
		[Inv_Fecha],
		[Inv_TipoMov],
		[Inv_Almacen],
		[Inv_Cantidad],
		[Inv_Unidad],
	   -- [Inv_UnidadDescrip],
		[Inv_Proceso]
		
		FROM
		@dtRelacion

		

	END

GO
------------------------------------------------------------///////////////////////////////////////////////////////////////////////////////////////////////
