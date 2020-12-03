USE [Digitel]
GO

/****** Object:  Table [dbo].[ArticulosProveedores]    Script Date: 23/11/2020 13:07:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticulosProveedores](
	[artprov_ArtId] [nvarchar](50) NOT NULL,
	[artprov_Id] [int] NOT NULL,
	[artprov_Nom] [nvarchar](100) NOT NULL,
	[artprov_Fcompra] [nvarchar](100) NULL,
	[artprov_cost] [nvarchar](100) NULL,
	[artprov_cant] [nvarchar](100) NULL,

	CONSTRAINT PK_ArtProv PRIMARY KEY( artprov_ArtId, artprov_Id)
	)
GO


