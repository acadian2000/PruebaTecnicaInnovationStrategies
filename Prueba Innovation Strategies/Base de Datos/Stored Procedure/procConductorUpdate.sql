USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procConductorUpdate]    Script Date: 9/27/2021 12:25:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procConductorUpdate]
(
	  @DNI varchar(50),
	  @Nombre varchar(50),
	  @Apellido varchar(50),
      @Puntos int
)

AS
BEGIN 

DECLARE @RespuestaInfraccion nvarchar(100) 
DECLARE @Confirmacion nvarchar(100) 
DECLARE @ExisteUsuario varchar(50) = null

SET @ExisteUsuario = @DNI

IF EXISTS (SELECT 1 FROM Conductor WHERE  DNI = @ExisteUsuario)
BEGIN

UPDATE [dbo].[Conductor]
   SET [Nombre] = @Nombre
      ,[Apellido] = @Apellido
      ,[Puntos] = @Puntos
 WHERE [DNI] = @DNI

SET @Confirmacion = 'El Registro se Actualizo Exitosamente !!!!'
SELECT @Confirmacion AS Mensaje
RETURN 1

END ELSE BEGIN
 
SET @RespuestaInfraccion = 'El Conductor NO EXISTE !!!, Verificar el DNI Ingresado o Proceder a Registrarlo'
 RAISERROR(@RespuestaInfraccion,11,1)
 RETURN 0
END


END
