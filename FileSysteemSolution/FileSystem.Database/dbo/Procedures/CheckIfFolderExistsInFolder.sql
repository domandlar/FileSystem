CREATE PROCEDURE [dbo].[CheckIfFolderExistsInFolder]
	@folderName nvarchar(50),
	@parentId int
AS
	DECLARE @folderExists BIT = 0

	SELECT	@folderExists = 1
	FROM	Folder
	WHERE	ParentId = @parentId AND
			Name = @folderName

RETURN @folderExists
