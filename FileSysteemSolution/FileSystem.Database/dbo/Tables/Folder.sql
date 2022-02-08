CREATE TABLE [dbo].[Folder]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [ParentId] INT NULL, 
    CONSTRAINT [FK_Folder_Folder] FOREIGN KEY ([ParentId]) REFERENCES [Folder]([Id])
)
