USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procInfraccionesUpdate]    Script Date: 9/27/2021 12:30:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[procInfraccionesUpdate]
(
	@Identificador varchar(50),
    @Descripcion varchar(50),
    @PuntosaDesconta int
)

AS
BEGIN

DECLARE @ExisteIndentificador nvarchar(500)
DECLARE @RespuestaExisteDescripcion nvarchar(100) 
DECLARE @Confirmacion nvarchar(100) 
DECLARE @ExisteDescripcion nvarchar(500)
DECLARE @RespuestaInfraccion nvarchar(100) 

SET @ExisteIndentificador = @Identificador
SET @ExisteDescripcion = @Descripcion

IF EXISTS (SELECT Identificador FROM[dbo].[Infracciones] WHERE  Identificador = @ExisteIndentificador)
BEGIN

IF NOT EXISTS (SELECT Descripcion FROM[dbo].[Infracciones] WHERE  Descripcion = @ExisteDescripcion)
BEGIN


UPDATE [dbo].[Infracciones]
   SET [Descripcion] = @Descripcion
      ,[PuntosaDescontar] = @PuntosaDesconta
 WHERE [Identificador] = @Identificador

SET @Confirmacion = 'El Registro se Actualizo de Exitosamente'
SELECT @Confirmacion AS Mensaje
RETURN 1

END ELSE BEGIN

SET @RespuestaInfraccion = 'Ya Existe la Descripcion de la Infraccion'
 RAISERROR(@RespuestaInfraccion,11,1)
 RETURN 0

END;

END ELSE BEGIN

 SET @RespuestaExisteDescripcion = 'No Existe el Identificador Asociado a la Infraccion'
 RAISERROR(@RespuestaExisteDescripcion,11,1)
 RETURN 0

END; 

END
