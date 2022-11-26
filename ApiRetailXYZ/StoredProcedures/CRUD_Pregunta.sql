USE [RetailXYZ]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetOnePregunta]
(
	@Id		UNIQUEIDENTIFIER	
)
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Numero], [Pregunta],	[Escala], [Categoria]
	FROM [dbo].[Pregunta]
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
CREATE OR ALTER procedure [dbo].[GetAllPregunta]
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Numero], [Pregunta],	[Escala], [Categoria]
	FROM [dbo].[Pregunta]
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[InsertPregunta]
	(
		@Id				UNIQUEIDENTIFIER,
		@Numero			int,
		@Pregunta		varchar,
		@Escala			varchar,
		@Categoria			int
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[Pregunta]
			   (
				[Id], [Numero], [Pregunta],	[Escala], [Categoria]
			   )
		 VALUES
			   ( 
				@Id,
				@Numero,
				@Pregunta,	
				@Escala,
				@Categoria
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
CREATE OR ALTER PROCEDURE [dbo].[UpdatePregunta]
	(
		@Id				UNIQUEIDENTIFIER,
		@Numero			int,
		@Pregunta		varchar,
		@Escala			varchar,
		@Categoria			int
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		UPDATE	[dbo].[Pregunta]
		SET		
				[Id]	= @Id,
				[Numero]	= @Numero,
				[Pregunta]	= @Pregunta,
				[Escala] = @Escala,
				[Categoria] = @Categoria
		WHERE	[Id]	=	@Id		 
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
CREATE OR ALTER PROCEDURE [dbo].[DeletePregunta]
	(
		@Id					UNIQUEIDENTIFIER
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		DELETE 	[dbo].[Pregunta]
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