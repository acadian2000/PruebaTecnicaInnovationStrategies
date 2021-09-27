USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procConductorInsert]    Script Date: 9/27/2021 12:19:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[procConductorInsert]
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

IF NOT EXISTS (SELECT 1 FROM Conductor WHERE  DNI = @ExisteUsuario)
BEGIN

INSERT INTO [dbo].[Conductor]
           ([DNI]
           ,[Nombre]
           ,[Apellido]
           ,[Puntos])
     VALUES
           (@DNI
           ,@Nombre
           ,@Apellido
           ,@Puntos)


SET @Confirmacion = 'El Registro se Guardo  Exitosamente !!!!'
SELECT @Confirmacion AS Mensaje
RETURN 1

END ELSE BEGIN
 
SET @RespuestaInfraccion = 'El Conductor YA EXISTE !!!, Verificar el DNI Ingresado o en su defecto adicionar otro'
 RAISERROR(@RespuestaInfraccion,11,1)
 RETURN 0

END

END
