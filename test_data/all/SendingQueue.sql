CREATE TABLE [dbo].[SendingQueue]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NOT NULL, 
    [EvaluationTime] DATETIME NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 0, 
    [Manual] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_SendingQueue_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id])
)
