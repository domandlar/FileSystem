CREATE PROCEDURE [dbo].[DeleteFile]
	@fileId int
AS
	DELETE FROM [File]
	WHERE		Id = @fileId
RETURN 0
