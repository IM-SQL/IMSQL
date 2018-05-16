CREATE TABLE [dbo].[Resending]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NOT NULL, 
    CONSTRAINT [FK_Resending_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_Resending_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
