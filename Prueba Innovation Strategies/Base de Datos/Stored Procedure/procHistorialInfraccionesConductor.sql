USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procHistorialInfraccionesConductor]    Script Date: 9/27/2021 12:27:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procHistorialInfraccionesConductor]
(   
    @DNIConductorHabitual varchar(50) = null,
	 @Nombre varchar(50) = null,
	 @Apellido varchar(50) = null
)

AS
BEGIN 

IF(@DNIConductorHabitual IS NOT NULL OR @Nombre IS NOT NULL OR @Apellido IS NOT NULL)
BEGIN

SELECT        Conductor.DNI , Conductor.Nombre , Conductor.Apellido, RegistroInfraccionesVehiculares.Hora, RegistroInfraccionesVehiculares.Fecha, RegistroInfraccionesVehiculares.Vehiculo, 
                         Vehiculo.Marca, Vehiculo.Modelo, RegistroInfraccionesVehiculares.IdentificadorInfraccion AS 'Codigo de infraccion', Infracciones.Descripcion,RegistroInfraccionesVehiculares.PuntosConductorAntesInfraccion AS 'Puntos Conductor Antes de laInfraccion',
						 RegistroInfraccionesVehiculares.PuntosaDescontar AS 'Puntos a Descontar',RegistroInfraccionesVehiculares.PuntosConductorDespuesInfraccion AS 'Puntos Conductor Despues de la Infraccion' 
FROM            Conductor INNER JOIN
                         RegistroInfraccionesVehiculares ON Conductor.DNI = RegistroInfraccionesVehiculares.Conductor INNER JOIN
                         Vehiculo ON RegistroInfraccionesVehiculares.Vehiculo = Vehiculo.Matricula INNER JOIN
                         Infracciones ON RegistroInfraccionesVehiculares.IdentificadorInfraccion = Infracciones.Identificador
WHERE DNI = @DNIConductorHabitual OR Nombre LIKE '%' +@Nombre+'%' OR Apellido LIKE '%' +@Apellido+'%'
ORDER BY RegistroInfraccionesVehiculares.PuntosConductorAntesInfraccion DESC

END ELSE BEGIN

SELECT        Conductor.DNI , Conductor.Nombre , Conductor.Apellido, RegistroInfraccionesVehiculares.Hora, RegistroInfraccionesVehiculares.Fecha, RegistroInfraccionesVehiculares.Vehiculo, 
                         Vehiculo.Marca, Vehiculo.Modelo, RegistroInfraccionesVehiculares.IdentificadorInfraccion AS 'Codigo de infraccion', Infracciones.Descripcion,RegistroInfraccionesVehiculares.PuntosConductorAntesInfraccion AS 'Puntos Conductor Antes de laInfraccion',
						 RegistroInfraccionesVehiculares.PuntosaDescontar AS 'Puntos a Descontar',RegistroInfraccionesVehiculares.PuntosConductorDespuesInfraccion AS 'Puntos Conductor Despues de la Infraccion' 
FROM            Conductor INNER JOIN
                         RegistroInfraccionesVehiculares ON Conductor.DNI = RegistroInfraccionesVehiculares.Conductor INNER JOIN
                         Vehiculo ON RegistroInfraccionesVehiculares.Vehiculo = Vehiculo.Matricula INNER JOIN
                         Infracciones ON RegistroInfraccionesVehiculares.IdentificadorInfraccion = Infracciones.Identificador
ORDER BY RegistroInfraccionesVehiculares.PuntosConductorAntesInfraccion DESC

END;

END
