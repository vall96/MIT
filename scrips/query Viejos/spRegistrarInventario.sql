USE [Digitel]
GO
/****** Object:  StoredProcedure [dbo].[Sp_RegistrarMovInventario]    Script Date: 25/09/2020 12:10:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Sp_RegistrarMovInventario]
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