USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procVehiculoInsert]    Script Date: 9/27/2021 12:30:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procVehiculoInsert]
(
	@Matricula varchar(50),
    @Marca varchar(50),
    @Modelo varchar(50),
    @DNIConductorHabitual varchar(50)
	
)

AS
BEGIN 

DECLARE @RespuestaConductor nvarchar(100) 
DECLARE @RespuestaConductorCantidadVehiculo nvarchar(100) 
DECLARE @Confirmacion nvarchar(100) 
DECLARE @VehiculoMaximoConductor INT = NULL
DECLARE @ExisteUsuario varchar(50) = null

SELECT @VehiculoMaximoConductor = COUNT(DNIConductorHabitual) FROM Vehiculo(nolock)
WHERE DNIConductorHabitual = @DNIConductorHabitual

SET @ExisteUsuario = @DNIConductorHabitual


IF NOT EXISTS (SELECT Matricula FROM Vehiculo WHERE  Matricula = @Matricula)
BEGIN

IF EXISTS (SELECT DNI FROM Conductor WHERE  DNI = @ExisteUsuario)
BEGIN

IF(@VehiculoMaximoConductor < 10)
BEGIN

INSERT INTO [dbo].[Vehiculo]
           ([Matricula]
           ,[Marca]
           ,[Modelo]
           ,[DNIConductorHabitual])
     VALUES
           (@Matricula
           ,@Marca
           ,@Modelo
           ,@DNIConductorHabitual)

SET @Confirmacion = 'El Registro se Inserto de Exitosamente'
SELECT @Confirmacion AS Mensaje
RETURN 1

END ELSE BEGIN
SET @RespuestaConductorCantidadVehiculo = 'Este Conductor ya tiene 10 Vehiculos Asignados, NO se puede Asignar mas'
 RAISERROR(@RespuestaConductorCantidadVehiculo,11,1)
 RETURN 0
END;

END ELSE BEGIN
 SET @RespuestaConductor = 'El Conductor NO EXISTE !!!, Se debe Agregar al Conductor'
 RAISERROR(@RespuestaConductor,11,1)
 RETURN 0
END;


END ELSE BEGIN
 SET @RespuestaConductor = 'La Matricula del Vehiculo ya Existe !!!!, Validar Nuevamente'
 RAISERROR(@RespuestaConductor,11,1)
 RETURN 0
END;

END
