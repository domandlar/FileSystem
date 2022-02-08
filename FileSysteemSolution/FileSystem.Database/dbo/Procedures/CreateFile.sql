CREATE PROCEDURE [dbo].[CreateFile]
	@fileName nvarchar(50),
	@folderId int = 1
AS
	DECLARE @fileId INT;

	INSERT INTO [File]
	(
		Name, 
		FolderId
	)
	VALUES
	(
		@fileName, 
		@folderId
	);

	SELECT @fileId = SCOPE_IDENTITY();

RETURN @fileId