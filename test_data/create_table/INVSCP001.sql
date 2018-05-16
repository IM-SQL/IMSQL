﻿CREATE TABLE [dbo].[INVSCP001]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [AccountID] NVARCHAR(40) NOT NULL, 
	[Item] NVARCHAR(40) NOT NULL,
	[SCPWEEK] NVARCHAR(10) NOT NULL,
	[Type] NVARCHAR(5) NOT NULL,
	[ScpQty] DECIMAL(15,3) NOT NULL,
	[Unit] NVARCHAR(50) NOT NULL,
	[Reason] NVARCHAR(200) NULL,
    [DATE_1] DATE NULL, 
    [DATE_2] DATE NULL, 
    [ETC_1] NVARCHAR(50) NULL, 
    [ETC_2] NVARCHAR(50) NOT NULL, 
    [ETC_3] NVARCHAR(100) NULL, 
    [ETC_4] NVARCHAR(100) NULL, 
    [QTY_1] DECIMAL(15, 3) NOT NULL, 
    [QTY_2] DECIMAL(15, 3) NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NULL, 
    [Processed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_INVSCP001_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_INVSCP001_ToClient] FOREIGN KEY ([AccountID]) REFERENCES [Client]([ExternalId]) 
)

GO

CREATE INDEX [IX_INVSCP001_PackageId] ON [dbo].[INVSCP001] ([PackageId])

GO

CREATE INDEX [IX_INVSCP001_AccountIdProcessed] ON [dbo].[INVSCP001] ([AccountID],[Processed])

