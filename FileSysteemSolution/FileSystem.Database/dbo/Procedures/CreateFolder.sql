CREATE PROCEDURE [dbo].[CreateFolder]
	@folderName nvarchar(50),
	@parentId int = 1
AS
	DECLARE @folderId INT;

	INSERT INTO Folder
	(
		Name, 
		ParentId
	)
	VALUES
	(
		@folderName, 
		@parentId
	);

	SELECT @folderId = SCOPE_IDENTITY();

RETURN @folderId
