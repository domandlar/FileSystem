CREATE PROCEDURE [dbo].[CheckIfFolderExistsById]
	@folderId int
AS
	DECLARE @folderExists BIT = 0

	SELECT	@folderExists = 1
	FROM	Folder
	WHERE	Id = @folderId 

RETURN @folderExists
