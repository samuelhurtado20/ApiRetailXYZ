USE [RetailXYZ]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetOneRespuesta]
(
	@Id		UNIQUEIDENTIFIER	
)
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [EncuestaId], [PreguntaId],	[Respuesta]
	FROM [dbo].[Respuesta]
	WHERE	[Id] = @Id
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetAllRespuesta]
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [EncuestaId], [PreguntaId],	[Respuesta]
	FROM [dbo].[Respuesta]
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[InsertRespuesta]
	(
		@Id				UNIQUEIDENTIFIER,
		@EncuestaId			UNIQUEIDENTIFIER,
		@PreguntaId		UNIQUEIDENTIFIER,
		@Respuesta			varchar
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[Respuesta]
			   (
				[Id], [EncuestaId], [PreguntaId],	[Respuesta]
			   )
		 VALUES
			   ( 
				@Id,
				@EncuestaId,
				@PreguntaId,	
				@Respuesta
			   );
	IF @@ROWCOUNT = 0 
	BEGIN
		RAISERROR('HUBO UN ERROR AL PROCESAR LA TRANSACCION - Insert', 16, 1)
		RETURN 0
	END
	COMMIT TRAN
	Select  1
END TRY
BEGIN CATCH
	SET	@mensajeError = ERROR_MESSAGE() + ' (Procedure: ' + ERROR_PROCEDURE() + '; Linea no. ' + CONVERT(VARCHAR, ERROR_LINE()) + ')'
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION
	RAISERROR(@mensajeError, 16, 1)
END CATCH
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[UpdateRespuesta]
	(
		@Id				UNIQUEIDENTIFIER,
		@EncuestaId			UNIQUEIDENTIFIER,
		@PreguntaId		UNIQUEIDENTIFIER,
		@Respuesta			varchar
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		UPDATE	[dbo].[Respuesta]
		SET		
				[Id]			= @Id,
				[EncuestaId]	= @EncuestaId,
				[PreguntaId]	= @PreguntaId,
				[Respuesta]		= @Respuesta
		WHERE	[Id]			= @Id		 
	IF @@ROWCOUNT = 0 
	BEGIN
		RAISERROR('HUBO UN ERROR AL PROCESAR LA TRANSACCION - UPDATE', 16, 1)
		RETURN 0
	END
	COMMIT TRAN
	select  1;
END TRY
BEGIN CATCH
	SET	@mensajeError = ERROR_MESSAGE() + ' (Procedure: ' + ERROR_PROCEDURE() + '; Linea no. ' + CONVERT(VARCHAR, ERROR_LINE()) + ')'
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION
	RAISERROR(@mensajeError, 16, 1)
END CATCH
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[DeleteRespuesta]
	(
		@Id					UNIQUEIDENTIFIER
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		DELETE 	[dbo].[Respuesta]
		WHERE	[Id]	=	@Id 
	IF @@ROWCOUNT = 0 
	BEGIN
		RAISERROR('HUBO UN ERROR AL PROCESAR LA TRANSACCION - Delete', 16, 1)
		RETURN 0
	END
	COMMIT TRAN
	select  1;
END TRY
BEGIN CATCH
	SET	@mensajeError = ERROR_MESSAGE() + ' (Procedure: ' + ERROR_PROCEDURE() + '; Linea no. ' + CONVERT(VARCHAR, ERROR_LINE()) + ')'
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION
	RAISERROR(@mensajeError, 16, 1)
END CATCH
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------