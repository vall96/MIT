USE Digitel
GO
--Borrar las tablas de articulos, inventario, invetario-procesos,inventario-tipomovimiento, SP_RegistarMovInventario,  tablatemporal-inventario
CREATE TABLE [dbo].[Articulos](
	[art_Id] [nvarchar](50) NOT NULL,
	[art_Nom] [nvarchar](100) NULL,
	[art_Garantia] [nvarchar](100) NULL,
	[art_Modelo] [nvarchar](100) NULL,
	[art_Unidad] [nvarchar](100) NULL,
	[art_UnidadFriltro] [nvarchar](100) NULL,
	[art_Medida] [nvarchar](100) NULL,
	[art_Catg] [nvarchar](100) NULL,
	[art_SubCatg] [nvarchar](100) NULL,
	[art_Procedencia] [nvarchar](100) NULL,
	[art_serial] [nvarchar](100) NULL,
	[art_Tipo] [nvarchar](20) NULL,
 CONSTRAINT [PK__Articulo__C4794368498B17F8] PRIMARY KEY CLUSTERED 
(
	[art_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Inventario](
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [date] NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	--[Inv_UnidadDescrip] [nvarchar](50) NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO

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

CREATE TABLE [dbo].[Inventario_Procesos](
	[Proc_Codigo] [nvarchar](50) PRIMARY KEY NOT NULL,
	[Proc_Descrip] [nvarchar](50) NOT NULL,
)
GO

CREATE TABLE [dbo].[Inventario_TipoMov](
	[TipoMov_Codigo] [nvarchar](50) PRIMARY KEY NOT NULL,
	[TipoMov_Descrip] [nvarchar](50) NOT NULL
)
GO

ALTER PROC [dbo].[sp_ListarArticulos]
AS
	BEGIN
		SELECT*FROM Articulos
	END 
GO

ALTER PROC [dbo].[Sp_ListarInvtProcesos]
AS
	BEGIN
		SELECT*FROM Inventario_Procesos
	END
GO

ALTER PROC [dbo].[Sp_ListarInvTipoMov]
AS
	BEGIN
		SELECT*FROM Inventario_TipoMov
	END
GO

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

INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'ENT', N'Entrada')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'SAL', N'Salida')
GO
INSERT [dbo].[Inventario_Procesos] ([Proc_Codigo], [Proc_Descrip]) VALUES (N'AJUS', N'Ajuste')
GO

INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'COM', N'Compra')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'PROD', N'Producción')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'TRAS', N'Traslado')
GO
INSERT [dbo].[Inventario_TipoMov] ([TipoMov_Codigo], [TipoMov_Descrip]) VALUES (N'VENT', N'Venta')
GO

INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED001', N'Prueba1', N'10', N'SDF5DS5FS', N'cg', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD4020', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED002', N'Articulos Produccion', N'10', N'XSNWQP012SD', N'tn', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD402012', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTA00', N'Aceite Ligero', N'30', N'Aceite Ligero 001', N'kg', N'0', N'2', N'C002', N'MZ005', N'Importado', N'A00-001', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTAG', N'Agua Limpia', N'30', N'Agua Purificada', N'cg', N'0', N'15', N'L1', N'SA01', N'Extranjero', N'No Aplica', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTB001', N'Baja Blanca especial 25', N'30', N'Traje de laboratorio 25', N'tn', N'0', N'0', N'UT001', N'UL002', N'Contruido en galpon 00236', N'XD-14141-KJ', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTC001', N'Cuero', N'30', N'Cuero Fino', N'kg', N'0', N'15', N'C002', N'MZ001', N'Importado', N'C001-INT', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTGA001', N'Guantes de Asbesto', N'30', N'Guantes de Asbesto Balncos', N'cg', N'0', N'0', N'UT001', N'UL001', N'Contruido en galpon 00236', N'00221001214-SAA3', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTH003', N'Hilo Negro', N'30', N'Hilo Negro Satinado', N'tn', N'0', N'0', N'C002', N'MZ006', N'Nacional', N'H003', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTR001', N'Router', N'13', N'FSEAF', N'kg', N'0', N'0', N'C1', N'S2A', N'Importado', N'16546954', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'INTS00', N'Suela ExtraFuerte', N'30', N'Suela ExtraFuerte N*15', N'cg', N'0', N'30', N'C002', N'MZ002', N'Importado', N'S00-EF012', N'INT')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'VEN002', N'Tarjetas Madre', N'10', N'Asus', N'tn', N'0', N'0', N'C001', N'SC3', N'Contruido en galpon 00236', N'A68SD-KA2MD', N'VEN')
GO

INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-09-25' AS Date), N'ENT', N'Almacen de Empresa Digitel', 0, N'cg', N'COM')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-09-25' AS Date), N'ENT', N'almacen 203-Digitel', 0, N'cg',  N'COM')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Agua Limpia', CAST(N'2020-09-25' AS Date), N'SAL', N'almacen 204-Digitel', 15, N'cg', N'COM')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-09-28' AS Date), N'SAL', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'COM')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Aceite Ligero', CAST(N'2020-09-28' AS Date), N'ENT', N'almacen 204-Digitel', 2, N'kg',  N'VENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', CAST(N'2020-09-28' AS Date), N'ENT', N'Almacen de Empresa Digitel', 0, N'cg',  N'VENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', CAST(N'2020-09-28' AS Date), N'SAL', N'Almacenes CFG. Digitel', 0, N'tn', N'PROD')
GO

