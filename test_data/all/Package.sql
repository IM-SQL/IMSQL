CREATE TABLE [dbo].[Package]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 	
    [ClientId] INT NOT NULL, 
    [InterfaceId] INT NOT NULL, 
    [ProcessBeganTime] DATETIME NULL, 
    [FilePath] NVARCHAR(260) NULL, 
    [FileCreatedTime] DATETIME NULL, 
    [FileSentTime] DATETIME NULL, 
    [RecordCount] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Package_ToInterface] FOREIGN KEY ([InterfaceId]) REFERENCES [Interface]([Id]), 
    CONSTRAINT [FK_Package_ToClient] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
