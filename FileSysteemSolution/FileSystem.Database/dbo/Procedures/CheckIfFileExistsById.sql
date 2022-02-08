CREATE PROCEDURE [dbo].[CheckIfFileExistsById]
	@fileId int
AS
	DECLARE @fileExists BIT = 0

	SELECT	@fileExists = 1
	FROM	[File]
	WHERE	Id = @fileId 

RETURN @fileExists
 