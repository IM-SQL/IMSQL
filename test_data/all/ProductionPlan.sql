CREATE TABLE [dbo].[ProductionPlan]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [Confirmed] BIT NULL DEFAULT 0, 
    [ClientId] INT NOT NULL, 
    CONSTRAINT [FK_ProductionPlan_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_ProductionPlan_ToClient] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
