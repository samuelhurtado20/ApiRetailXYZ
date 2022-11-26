USE [RetailXYZ]
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER procedure [dbo].[GetOneEncuestado]
(
	@Id		UNIQUEIDENTIFIER	
)
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Cedula], [NombreApellido],	[Sexo], [Edad]
	FROM [dbo].[Encuestado]
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
CREATE OR ALTER procedure [dbo].[GetAllEncuestado]
AS
SET NOCOUNT ON
Begin
	SELECT [Id], [Cedula], [NombreApellido],	[Sexo], [Edad]	
	FROM [dbo].[Encuestado]
End
GO
------------------------------------------------------------------------
------------------------------------------------------------------------
------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[InsertEncuestado]
	(
		@Id				UNIQUEIDENTIFIER,
		@Cedula			int,
		@NombreApellido	varchar,
		@Sexo			varchar,
		@Edad			int
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)

BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[Encuestado]
			   (
				[Id], [Cedula], [NombreApellido], [Sexo], [Edad]
			   )
		 VALUES
			   ( 
				@Id,
				@Cedula,
				@NombreApellido,	
				@Sexo,
				@Edad
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
CREATE OR ALTER PROCEDURE [dbo].[UpdateEncuestado]
	(
		@Id				UNIQUEIDENTIFIER,
		@Cedula			int,
		@NombreApellido	varchar,
		@Sexo			varchar,
		@Edad			int
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		UPDATE	[dbo].[Encuestado]
		SET		
				[Id]	= @Id,
				[Cedula]	= @Cedula,
				[NombreApellido]	= @NombreApellido,
				[Sexo] = @Sexo,
				[Edad] = @Edad
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
CREATE OR ALTER PROCEDURE [dbo].[DeleteEncuestado]
	(
		@Id					UNIQUEIDENTIFIER
	)
AS
SET NOCOUNT ON
DECLARE @mensajeError				VARCHAR(1000)
BEGIN TRY
	BEGIN TRAN
		DELETE 	[dbo].[Encuestado]
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