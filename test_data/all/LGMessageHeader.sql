CREATE TABLE [dbo].[LGMessageHeader]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [InterfaceId] NVARCHAR(50) NULL, 
    [SenderId] NVARCHAR(50) NULL, 
    [ReceiverId] NVARCHAR(50) NULL, 
    [DocumentType] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_LGMessageHeader_ToInterface] FOREIGN KEY ([Id]) REFERENCES [Interface]([Id])
)
