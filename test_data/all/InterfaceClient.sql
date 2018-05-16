CREATE TABLE [dbo].[InterfaceClient]
(
	[InterfaceId] INT NOT NULL , 
    [ClientId] INT NOT NULL, 
    PRIMARY KEY ([ClientId], [InterfaceId]), 
    CONSTRAINT [FK_InterfaceClient_ToInterface] FOREIGN KEY ([InterfaceId]) REFERENCES [Interface]([Id]), 
    CONSTRAINT [FK_InterfaceClient_ToClient] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id])
)
