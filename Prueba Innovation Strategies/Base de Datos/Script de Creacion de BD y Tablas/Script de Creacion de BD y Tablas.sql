CREATE DATABASE InnovationStrategiesDGT;

USE InnovationStrategiesDGT
GO

CREATE TABLE Conductor (
 IdConductor int  IDENTITY(1,1) NOT NULL,
 DNI varchar(50),
 Nombre varchar(50),
 Apellido varchar(50),
 Puntos int

 CONSTRAINT [PK_DNI] PRIMARY KEY CLUSTERED
 (
   [DNI] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
)ON [PRIMARY]
GO


CREATE TABLE Vehiculo (
 IdEVehiculo int  IDENTITY(1,1) NOT NULL,
 Matricula varchar(50),
 Marca varchar(50),
 Modelo varchar(50),
 DNIConductorHabitual varchar(50)

 CONSTRAINT [PK_Elector] PRIMARY KEY CLUSTERED
 (
   [Matricula] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
)ON [PRIMARY]
GO


CREATE TABLE Infracciones (
 IdElector int  IDENTITY(1,1) NOT NULL,
 Identificador nvarchar(100),
 Descripcion nvarchar(100),
 PuntosaDescontar int

 CONSTRAINT [PK_Identificador] PRIMARY KEY CLUSTERED
 (
   [Identificador] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
)ON [PRIMARY]
GO


CREATE TABLE RegistroInfraccionesVehiculares (
 IdRegistroInfraccionesVehiculares int  IDENTITY(1,1) NOT NULL,
 Hora nvarchar(50),
 Fecha nvarchar(50),
 Conductor varchar(50),
 Vehiculo varchar(50),
 IdentificadorInfraccion nvarchar(50),
 PuntosConductorAntesInfraccion int,
 PuntosaDescontar int,
 PuntosConductorDespuesInfraccion int
)
GO
