-- Carga de Datos

USE [InnovationStrategiesDGT]
GO

INSERT INTO [dbo].[Conductor]
           ([DNI]
           ,[Nombre]
           ,[Apellido]
           ,[Puntos])
     VALUES
           ('20555123'
           ,'Pablo'
           ,'Perez'
           ,2000),

		    ('19222101'
           ,'Santiago'
           ,'Medina'
           ,1800),

		    ('19000111'
           ,'Sebastian'
           ,'Gutierrez'
           ,2000),

		    ('18989222'
           ,'Pedro'
           ,'Garces'
           ,1800),

		    ('18666333'
           ,'Mariano'
           ,'Cruz'
           ,2000),

		    ('17444222'
           ,'Lisandro'
           ,'Blanco'
           ,1800),

		    ('16233000'
           ,'Carlos'
           ,'Estrada'
           ,2000),

		    ('15414999'
           ,'Freddy'
           ,'Castro'
           ,1800),

		    ('15030777'
           ,'Andres'
           ,'Ortiz'
           ,2000),

		    ('14999232'
           ,'Gonzalo'
           ,'Escobar'
           ,1800)
GO


-- ********************************** Vehiculos ********************************************

	
USE [InnovationStrategiesDGT]
GO

INSERT INTO [dbo].[Vehiculo]
           ([Matricula]
           ,[Marca]
           ,[Modelo]
           ,[DNIConductorHabitual])
     VALUES
           ('xcz-999'
           ,'Mazda'
           ,'6'
           ,'20555123'),

		   ('abt-032'
           ,'Mazda'
           ,'CX-3'
           ,'19222101'),

		   ('wqa-010'
           ,'Mazda'
           ,'5'
           ,'19000111'),

		   ('lop-666'
           ,'Nissan'
           ,'GT-R'
           ,'18989222'),

		   ('xxr-165'
           ,'Nissan'
           ,'Pixo'
           ,'18666333'),

		   ('pty-888'
           ,'Volvo'
           ,'V90'
           ,'17444222'),

		   ('nhg-005'
           ,'Fiat'
           ,'Spider124'
           ,'16233000'),

		   ('tuk-770'
           ,'Fiat'
           ,'Scudo'
           ,'15414999'),

		   ('plm-411'
           ,'Jeep'
           ,'Gladiator'
           ,'15030777'),

		   ('atn-589'
           ,'Jeep'
           ,'Cherokee'
           ,'14999232'),

		   ('vbt-331'
           ,'Ferrari'
           ,'FF'
           ,'18989222'),

		   ('aty-333'
           ,'Ferrari'
           ,'SF90'
           ,'14999232')
GO


--******************************** Infracciones ********************************************************

USE [InnovationStrategiesDGT]
GO

INSERT INTO [dbo].[Infracciones]
           ([Identificador]
           ,[Descripcion]
           ,[PuntosaDescontar])
     VALUES
           ('1'
           ,'Exceso de Horas de Conduccion'
           ,30),

		   ('2'
           ,'Falta de Mantenimiento del Vehiculo'
           ,25),

		   ('3'
           ,'Exceso de Velocidad'
           ,25),

		   ('4'
           ,'No Uso del Cinturon de Seguridad'
           ,20),

		   ('5'
           ,'Adelantamientos Durante la Conduccion'
           ,15),

		   ('6'
           ,'Transitar Sin los Dispositivos Luminosos Requeridos'
           ,10),

		   ('7'
           ,'No Respetar las Señales de Transito'
           ,25),

		   ('8'
           ,'Conducir un Vehiculo con la Licencia de Conduccion Vencida'
           ,30),

		   ('9'
           ,'Estacionar un Vehiculo en Sitios Prohibidos'
           ,30)
GO

			
--************************* RegistrosInfraccionesVehiculares

USE [InnovationStrategiesDGT]
GO

DECLARE @hora Datetime
DECLARE @DiaMesAno Datetime

 SET @hora = GETDATE()
 SET @DiaMesAno = GETDATE()

INSERT INTO [dbo].[RegistroInfraccionesVehiculares]
           ([Hora]
           ,[Fecha]
           ,[Conductor]
           ,[Vehiculo]
           ,[PuntosDescontados])
     VALUES
           ((SELECT CONVERT(varchar,@hora,8))
           ,(SELECT CONVERT(varchar,@DiaMesAno,103))
           ,'18989222'
           ,'vbt-331'
           ,30)
GO