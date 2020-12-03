USE [Digitel]
GO
/*BORRAR LAS TABLAS DE *ARTICULOS* *INVENTARIO* *InventarioTem* *Inventario_Procesos* *Inventario_TipoMov*/
/*En el query se Insertan los datos corrrespondiendes a cada tabla ademas de los procedimientos de almacenado de cada uno*/

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
/****** Object:  Table [dbo].[Atributos]    Script Date: 15/10/2020 12:16:39 ******/

CREATE TABLE [dbo].[Inventario](
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [nvarchar](50) NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
) ON [PRIMARY]

GO

CREATE TYPE [dbo].[InventarioTem] AS TABLE(
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [nvarchar](50) NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL
)
GO
/****** Object:  Table [dbo].[Inventario_Procesos]    Script Date: 15/10/2020 12:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Inventario_TipoMov]    Script Date: 15/10/2020 12:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Maquinas]    Script Date: 15/10/2020 12:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED001', N'Prueba1', N'10', N'SDF5DS5FS', N'cg', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD4020', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED002', N'Articulos Produccion', N'10', N'XSNWQP012SD', N'tn', N'0', N'0', N'C001', N'S1C', N'Contruido en galpon 00236', N'DSFSD402012', N'CED')
GO
INSERT [dbo].[Articulos] ([art_Id], [art_Nom], [art_Garantia], [art_Modelo], [art_Unidad], [art_UnidadFriltro], [art_Medida], [art_Catg], [art_SubCatg], [art_Procedencia], [art_serial], [art_Tipo]) VALUES (N'CED01289', N'hoka', N'2', N'fcgbdf', N'0', N'dag', N'100', N'C001', N'S4C', N'Contruido en galpon 00236', N'fdgdfg', N'CED')
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


INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'25/09/2020', N'COM', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'25/09/2020', N'COM', N'almacen 203-Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Agua Limpia', N'25/09/2020', N'COM', N'almacen 204-Digitel', 15, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'28/09/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Aceite Ligero', N'28/09/2020', N'VENT', N'almacen 204-Digitel', 2, N'kg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'28/09/2020', N'VENT', N'Almacen de Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Articulos Produccion', N'28/09/2020', N'PROD', N'Almacenes CFG. Digitel', 0, N'tn', N'SAL')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'10/08/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'ENT')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Tarjetas Madre', N'09/05/1996', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'tn', N'AJUS')
GO
INSERT [dbo].[Inventario] ([Inv_CodArt], [Inv_Fecha], [Inv_TipoMov], [Inv_Almacen], [Inv_Cantidad], [Inv_Unidad], [Inv_Proceso]) VALUES (N'Prueba1', N'07/10/2020', N'COM', N'Centro de distribución "La garita". Empresa Digitel', 0, N'cg', N'AJUS')
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

ALTER PROC [dbo].[Sp_ListarInvTipoMov]
AS
	BEGIN
		SELECT*FROM Inventario_TipoMov
	END
GO
ALTER PROC [dbo].[Sp_ListarInvtProcesos]
AS
	BEGIN
		SELECT*FROM Inventario_Procesos
	END
GO
ALTER PROC [dbo].[sp_RegistarArticulos]
(
@id NVARCHAR(100),
@nombre NVARCHAR(100),
@garantia NVARCHAR(100),
@modelo NVARCHAR(100),
@unidad NVARCHAR(100),
@unidadFiltro NVARCHAR(100),
@medida NVARCHAR(100),
@categoria NVARCHAR(100),
@subcategoria NVARCHAR(100),
@procedencia NVARCHAR(100),
@serial NVARCHAR(100),
@codigo NVARCHAR(50)

)
AS
	BEGIN
		INSERT Articulos
		VALUES (@id,@nombre,@garantia,@modelo,
		@unidad,@unidadFiltro,@medida,@categoria,@subcategoria,
		@procedencia,@serial,@codigo)
		
	END
GO

ALTER PROC [dbo].[Sp_RegistrarMovInventario]
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