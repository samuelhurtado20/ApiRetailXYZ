USE [RetailXYZ]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetOneSucursal]
(
	@Id		UNIQUEIDENTIFIER	
)
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Sucursal], [Ciudad],	[Provincia]
	FROM [dbo].[Sucursal]
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
CREATE OR ALTER procedure [dbo].[GetAllSucursal]
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Sucursal], [Ciudad],	[Provincia]
	FROM [dbo].[Sucursal]
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[InsertSucursal]
	(
		@Id				UNIQUEIDENTIFIER,
		@Sucursal 		varchar,
		@Ciudad			varchar,
		@Provincia		varchar
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[Sucursal]
			   (
				[Id], [Sucursal], [Ciudad],	[Provincia]
			   )
		 VALUES
			   ( 
				@Id,
				@Sucursal,
				@Ciudad,	
				@Provincia
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
CREATE OR ALTER PROCEDURE [dbo].[UpdateSucursal]
	(
		@Id				UNIQUEIDENTIFIER,
		@Sucursal 		varchar,
		@Ciudad			varchar,
		@Provincia		varchar
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		UPDATE	[dbo].[Sucursal]
		SET		
				[Id]			= @Id,
				[Sucursal]	= @Sucursal,
				[Ciudad]	= @Ciudad,
				[Provincia]		= @Provincia
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
CREATE OR ALTER PROCEDURE [dbo].[DeleteSucursal]
	(
		@Id					UNIQUEIDENTIFIER
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		DELETE 	[dbo].[Sucursal]
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