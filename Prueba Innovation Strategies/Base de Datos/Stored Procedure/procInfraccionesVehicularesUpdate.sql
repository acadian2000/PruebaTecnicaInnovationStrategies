USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procInfraccionesVehicularesUpdate]    Script Date: 9/27/2021 12:30:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procInfraccionesVehicularesUpdate]
(
			@Hora nvarchar(50) = NULL,
            @Fecha nvarchar(50) = NULL,
            @Conductor varchar(50),
            @Vehiculo varchar(50),
			@IdentificadorInfraccion nvarchar(50),
            @PuntosConductorAntesInfraccion int = null,
			@PuntosaDescontar int = null,
			@PuntosConductorDespuesInfraccion int = null
)

AS
BEGIN 

DECLARE @PuntosConductorAntes INT = NULL, @PuntosInfraccion INT = NULL
DECLARE @RespuestaUsuario nvarchar(500)
DECLARE @RespuestaVehiculo nvarchar(500)
DECLARE @ExisteMatricula  nvarchar(500)
DECLARE @ExisteUsuario  nvarchar(500)
DECLARE @Confirmacion nvarchar(500)


SELECT @PuntosConductorAntes = Puntos  FROM Conductor WHERE DNI = @Conductor
SELECT @PuntosInfraccion = PuntosaDescontar FROM Infracciones WHERE Identificador = @IdentificadorInfraccion

SET @PuntosConductorAntesInfraccion = @PuntosConductorAntes
SET  @PuntosaDescontar =  @PuntosInfraccion
SET @PuntosConductorDespuesInfraccion = @PuntosConductorAntes - @PuntosInfraccion

SET @ExisteMatricula = @Vehiculo
SET @ExisteUsuario = @Conductor

IF  EXISTS (SELECT Matricula FROM Vehiculo WHERE  Matricula = @ExisteMatricula)
BEGIN

IF EXISTS (SELECT DNI FROM Conductor WHERE  DNI = @ExisteUsuario)
BEGIN

IF(@Hora IS NOT NULL AND @Fecha IS NOT NULL)  
BEGIN
	
	UPDATE [dbo].[RegistroInfraccionesVehiculares]
   SET [Hora] = CONVERT(varchar,@Hora,8)
      ,[Fecha] = CONVERT(varchar,@Fecha,8)
	  ,[IdentificadorInfraccion] = @IdentificadorInfraccion 
	  ,[PuntosConductorAntesInfraccion] = @PuntosConductorAntesInfraccion
	  ,[PuntosaDescontar] = @PuntosaDescontar
	  ,[PuntosConductorDespuesInfraccion] = @PuntosConductorDespuesInfraccion	 
	WHERE [Conductor] = @Conductor AND [Vehiculo] = @Vehiculo

 EXEC [dbo].[procConductorUpdatePtosDescontados]
				@Conductor
			   ,@PuntosConductorDespuesInfraccion

	
	SET @Confirmacion = 'El Registro se Actualizo de Exitosamente y Se Actualizan los Puntos a Descontar'
	SELECT @Confirmacion AS Mensaje
	RETURN 1

END;

END ELSE BEGIN
	 SET @RespuestaUsuario = 'No Existe el Conductor !!!!, Se Debe Agregar al Conductor y Verificar'
	 RAISERROR(@RespuestaUsuario,11,1)
	 RETURN 0
END

END ELSE BEGIN
	 SET @RespuestaVehiculo = 'El Vehiculo NO EXISTE !!!, Se debe Agregar al Vehiculo'
	 RAISERROR(@RespuestaVehiculo,11,1)
	 RETURN 0
END;

END
