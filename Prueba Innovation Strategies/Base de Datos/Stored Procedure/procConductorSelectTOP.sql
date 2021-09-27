USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procConductorSelectTOP]    Script Date: 9/27/2021 12:22:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procConductorSelectTOP]
(
	 @NumeroRegistros int
)

AS
BEGIN 

SELECT TOP(@NumeroRegistros)
	   [DNI]
      ,[Nombre]
      ,[Apellido]
      ,[Puntos]
FROM [dbo].[Conductor]

END