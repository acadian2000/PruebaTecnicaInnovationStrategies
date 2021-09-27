USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procConductorUpdatePtosDescontados]    Script Date: 9/27/2021 12:26:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procConductorUpdatePtosDescontados]
(
	  @DNI varchar(50),
      @Puntos int
)

AS
BEGIN 

UPDATE [dbo].[Conductor]
   SET [Puntos] = @Puntos
 WHERE [DNI] = @DNI

END
