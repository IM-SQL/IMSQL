CREATE TABLE [dbo].[SFTPIntegrationSettings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] INT NOT NULL, 
    [Hostname] NVARCHAR(512) NOT NULL, 
    [Port] INT NOT NULL, 
    [UserName] NVARCHAR(200) NOT NULL, 
    [Password] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [FK_SFTPIntegrationSetting_ToClient] FOREIGN KEY ([ClientId]) REFERENCES [Client]([Id]) 
)
