USE [Digitel]
GO

/****** Object:  Table [dbo].[Inventario]    Script Date: 25/09/2020 12:14:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventario](
	[Inv_CodArt] [nvarchar](50) NOT NULL,
	[Inv_Fecha] [date] NOT NULL,
	[Inv_TipoMov] [nvarchar](50) NOT NULL,
	[Inv_Almacen] [nvarchar](150) NOT NULL,
	[Inv_Cantidad] [int] NOT NULL,
	[Inv_Unidad] [nvarchar](50) NOT NULL,
	[Inv_UnidadDescrip] [nvarchar](50) NULL,
	[Inv_Proceso] [nvarchar](200) NOT NULL

) ON [PRIMARY]

GO


