USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procVehiculoSelect]    Script Date: 9/27/2021 12:31:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procVehiculoSelect]

AS
BEGIN 

SELECT [Matricula]
      ,[Marca]
      ,[Modelo]
      ,[DNIConductorHabitual]
FROM [dbo].[Vehiculo]

END
