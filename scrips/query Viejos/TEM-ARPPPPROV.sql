USE [Digitel]
GO

/****** Object:  UserDefinedTableType [dbo].[CedulaTareaTem]    Script Date: 23/11/2020 12:52:24 ******/
CREATE TYPE [dbo].[ArticuloProvTem] AS TABLE(
	[artprov_Id] int NOT NULL,
	[CedTarea_IdTarea] [nvarchar](50) NOT NULL
)
GO


