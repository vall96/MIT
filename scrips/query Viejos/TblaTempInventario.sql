USE [Digitel]
GO

/****** Object:  UserDefinedTableType [dbo].[InventarioTem]    Script Date: 25/09/2020 12:24:17 ******/
CREATE TYPE [dbo].[InventarioTem] AS TABLE(
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [date] NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL,
	[Inv_UnidadDescrip] [nvarchar](50) NULL
)
GO


