CREATE TABLE [dbo].[File]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FolderId] INT NOT NULL, 
    CONSTRAINT [FK_File_Folder] FOREIGN KEY ([FolderId]) REFERENCES [Folder]([Id])
)
