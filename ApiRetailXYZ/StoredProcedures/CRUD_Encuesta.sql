USE [RetailXYZ ]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetOneEncuesta]
(
	@Id		UNIQUEIDENTIFIER	
)
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [SucursalId], [EncuestadoId],	[Fecha]
	FROM [dbo].[Encuesta]
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
CREATE OR ALTER procedure [dbo].[GetAllEncuesta]
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [SucursalId], [EncuestadoId]	
	FROM [dbo].[Encuesta]
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[InsertEncuesta]
	(
		@Id				UNIQUEIDENTIFIER,
		@SucursalId		UNIQUEIDENTIFIER,
		@EncuestadoId	UNIQUEIDENTIFIER,
		@Fecha			date
	)
AS

SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[Encuesta]
			   (
				[Id], [SucursalId], [EncuestadoId],	[Fecha]
			   )
		 VALUES
			   ( 
				@Id,
				@SucursalId,
				@EncuestadoId,	
				@Fecha
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
CREATE OR ALTER PROCEDURE [dbo].[UpdateEncuesta]
	(
		@Id				UNIQUEIDENTIFIER,
		@SucursalId		UNIQUEIDENTIFIER,
		@EncuestadoId	UNIQUEIDENTIFIER,
		@Fecha			date
	)
AS

SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		UPDATE	[dbo].[Encuesta]
		SET		
				[Id]	= @Id,
				[SucursalId]	= @SucursalId,
				[EncuestadoId]	= @EncuestadoId,
				[Fecha] = @Fecha
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
CREATE OR ALTER PROCEDURE [dbo].[DeleteEncuesta]
	(
		@Id					UNIQUEIDENTIFIER
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		DELETE 	[dbo].[Encuesta]
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