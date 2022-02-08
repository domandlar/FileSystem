CREATE PROCEDURE [dbo].[GetFilesByName]
	@fileName nvarchar(50),
	@folderId int
AS

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

    SELECT      TOP 10
                Name
    FROM        [File]
    WHERE       FolderId IN
                (
                    SELECT  Id
                    FROM    CTE
                ) AND 
                Name LIKE CONCAT(@fileName, '%')
    ORDER BY    Name