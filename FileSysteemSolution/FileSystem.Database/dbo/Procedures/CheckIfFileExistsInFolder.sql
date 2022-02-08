CREATE PROCEDURE [dbo].[CheckIfFileExistsInFolder]
	@fileName nvarchar(50),
	@folderId int
AS
	DECLARE @fileExists BIT = 0

	SELECT	@fileExists = 1
	FROM	[File]
	WHERE	FolderId = @folderId AND
			Name = @fileName

RETURN @fileExists