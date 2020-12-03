USE Digitel
GO

CREATE PROC [dbo].[SP_EliminarMovInventrio]
(
@codigo nvarchar (50),
@fecha date,
@almacen nvarchar (150),
@dtRelacion dbo.InventarioTem READONLY
)
AS
	BEGIN	
		DELETE FROM Inventario
		WHERE EXISTS(SELECT I.Inv_CodArt, I.Inv_Fecha, I.Inv_Almacen 
		FROM @dtRelacion I, Articulos A, Almacenes AL
		WHERE  A.art_Id = I.Inv_CodArt 
		AND AL.alm_nombre = I.Inv_Almacen)
	END
GO
