USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procVehiculoSelectFiltrado]    Script Date: 9/27/2021 12:31:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procVehiculoSelectFiltrado]
(
	@Matricula varchar(50) = null,
    @Marca varchar(50) = null,
    @Modelo varchar(50) = null,
    @DNIConductorHabitual varchar(50)
)

AS
BEGIN 

SELECT [Matricula]
      ,[Marca]
      ,[Modelo]
      ,[DNIConductorHabitual]
FROM [dbo].[Vehiculo]
WHERE [Matricula] = @Matricula OR [Marca] = @Marca OR [Modelo] = @Modelo OR [DNIConductorHabitual] = @DNIConductorHabitual

END
