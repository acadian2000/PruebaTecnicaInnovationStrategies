USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procConductorSelectxDNI]    Script Date: 9/27/2021 12:23:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procConductorSelectxDNI]
(
	 @DNI varchar(50)
)

AS
BEGIN 

SELECT [DNI]
      ,[Nombre]
      ,[Apellido]
      ,[Puntos]
FROM [dbo].[Conductor]
WHERE [DNI] = @DNI

END
