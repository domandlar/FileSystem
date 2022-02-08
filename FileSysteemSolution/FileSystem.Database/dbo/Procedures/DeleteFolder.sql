CREATE PROCEDURE [dbo].[DeleteFolder]
	@folderId int
AS
    DECLARE @foldersForDelete TABLE(
            Id INT
    )

    ;WITH CTE AS 
    (
        SELECT  Id
        FROM    Folder
        WHERE   Id = @folderId 

        UNION ALL

        SELECT      Folder.Id
        FROM        Folder
        INNER JOIN  CTE
            ON      CTE.Id = Folder.ParentId
    )

    INSERT INTO @foldersForDelete
    SELECT  Id
    FROM    CTE

    DELETE FROM [File]
    WHERE       [File].FolderId IN 
                (
                    SELECT  Id
                    FROM    @foldersForDelete
                )

    DELETE FROM Folder 
    WHERE       Folder.Id IN 
                (
                    SELECT  Id
                    FROM    @foldersForDelete
                )
RETURN 0
