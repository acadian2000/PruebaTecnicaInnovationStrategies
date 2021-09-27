USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procInfraccionesSelect]    Script Date: 9/27/2021 12:29:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procInfraccionesSelect]
AS
BEGIN 

SELECT [IdElector]
      ,[Identificador]
      ,[Descripcion]
      ,[PuntosaDescontar]
  FROM [dbo].[Infracciones]

END
