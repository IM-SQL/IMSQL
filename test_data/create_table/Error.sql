CREATE TABLE [dbo].[Error]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Message] NVARCHAR(MAX) NOT NULL, 
    [PackageId] INT NOT NULL, 
    [StackTrace] NVARCHAR(MAX) NULL, 
    [ErrorTypeId] INT NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_Error_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_Error_ToErrorType] FOREIGN KEY ([ErrorTypeId]) REFERENCES [ErrorType]([Id])
)
