USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procInfraccionesSelectxFiltrado]    Script Date: 9/27/2021 12:29:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procInfraccionesSelectxFiltrado]
(
	@Identificador varchar(50) = NULL,
    @Descripcion varchar(50) = NULL,
    @PuntosaDesconta int = NULL
)

AS
BEGIN 

SELECT [IdElector]
      ,[Identificador]
      ,[Descripcion]
      ,[PuntosaDescontar]
FROM [dbo].[Infracciones]
WHERE [Identificador] = @Identificador OR [Descripcion] = @Descripcion OR [PuntosaDescontar] = @PuntosaDesconta
ORDER BY [IdElector] DESC

END
