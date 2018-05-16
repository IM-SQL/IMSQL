CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL UNIQUE, 
    [ExternalId] NVARCHAR(40) NOT NULL UNIQUE, 
    [InternalId] NVARCHAR(40) NOT NULL UNIQUE, 
    [Email] NVARCHAR(512) NULL, 
    [Enabled] BIT NOT NULL, 
    [IntegrationTypeId] INT NOT NULL, 
    CONSTRAINT [FK_Client_ToIntegrationType] FOREIGN KEY ([IntegrationTypeId]) REFERENCES [IntegrationType]([Id])
)
