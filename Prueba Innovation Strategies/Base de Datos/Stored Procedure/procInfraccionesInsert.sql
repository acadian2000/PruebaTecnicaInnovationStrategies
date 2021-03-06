USE [InnovationStrategiesDGT]
GO
/****** Object:  StoredProcedure [dbo].[procInfraccionesInsert]    Script Date: 9/27/2021 12:28:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[procInfraccionesInsert]
(
	@Identificador varchar(50),
    @Descripcion varchar(50),
    @PuntosaDesconta int
)

AS
BEGIN 

DECLARE @ExisteIndentificador nvarchar(500)
DECLARE @ExisteDescripcion nvarchar(500)
DECLARE @Confirmacion nvarchar(100) 
DECLARE @RespuestaInfraccion nvarchar(100) 
DECLARE @RespuestaExisteDescripcion nvarchar(100) 
SET @ExisteIndentificador = @Identificador
SET @ExisteDescripcion = @Descripcion


IF NOT EXISTS (SELECT Identificador FROM[dbo].[Infracciones] WHERE  Identificador = @ExisteIndentificador)
BEGIN

IF NOT EXISTS (SELECT Descripcion FROM[dbo].[Infracciones] WHERE  Descripcion = @ExisteDescripcion)
BEGIN

INSERT INTO [dbo].[Infracciones]
           ([Identificador]
           ,[Descripcion]
           ,[PuntosaDescontar])
     VALUES
           (@Identificador,
			@Descripcion,
			@PuntosaDesconta )

SET @Confirmacion = 'El Registro se Inserto de Exitosamente'
SELECT @Confirmacion AS Mensaje
RETURN 1

END ELSE BEGIN

SET @RespuestaInfraccion = 'Ya Existe la Descripcion de la Infraccion'
 RAISERROR(@RespuestaInfraccion,11,1)
 RETURN 0

END;

END ELSE BEGIN

SET @RespuestaExisteDescripcion = 'Ya Existe el Identificador de la Infraccion'
 RAISERROR(@RespuestaExisteDescripcion,11,1)
 RETURN 0

END;

END
