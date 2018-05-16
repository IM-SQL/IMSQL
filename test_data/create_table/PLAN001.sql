﻿CREATE TABLE [dbo].[PLAN001]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PlanWeek] NVARCHAR(6) NOT NULL,
    [AccountID] NVARCHAR(40) NOT NULL, 
	[Model] NVARCHAR(40) NOT NULL,
	[Type] NVARCHAR(10) NOT NULL,
	[Week01] NVARCHAR(6) NULL,
	[Week02] NVARCHAR(6) NULL,
	[Week03] NVARCHAR(6) NULL,
	[Week04] NVARCHAR(6) NULL,
	[Week05] NVARCHAR(6) NULL,
	[Week06] NVARCHAR(6) NULL,
	[Week07] NVARCHAR(6) NULL,
	[Week08] NVARCHAR(6) NULL,
	[Week09] NVARCHAR(6) NULL,
	[Week10] NVARCHAR(6) NULL,
	[Week11] NVARCHAR(6) NULL,
	[Week12] NVARCHAR(6) NULL,
	[Week13] NVARCHAR(6) NULL,
	[Week14] NVARCHAR(6) NULL,
	[Week15] NVARCHAR(6) NULL,
	[Week16] NVARCHAR(6) NULL,
	[Week17] NVARCHAR(6) NULL,
	[Week18] NVARCHAR(6) NULL,
	[Week19] NVARCHAR(6) NULL,
	[Week20] NVARCHAR(6) NULL,
	[Week21] NVARCHAR(6) NULL,
	[Week22] NVARCHAR(6) NULL,
	[Week23] NVARCHAR(6) NULL,
    [DATE_1] DATE NULL, 
    [DATE_2] DATE NULL, 
    [ETC_1] NVARCHAR(50) NULL, 
    [ETC_2] NVARCHAR(50) NULL, 
    [ETC_3] NVARCHAR(100) NULL, 
    [ETC_4] NVARCHAR(100) NULL, 
    [QTY_1] DECIMAL(15, 3) NULL, 
    [QTY_2] DECIMAL(15, 3) NULL, 
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NULL, 
    [Processed] BIT NOT NULL DEFAULT 0, 
    [ProductionPlanId] INT NOT NULL, 
    CONSTRAINT [FK_PLAN001_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_PLAN001_ToClient] FOREIGN KEY ([AccountID]) REFERENCES [Client]([ExternalId]), 
    CONSTRAINT [FK_PLAN001_ToProductionPlan] FOREIGN KEY ([ProductionPlanId]) REFERENCES [ProductionPlan]([Id]) 
)

GO

CREATE INDEX [IX_PLAN001_PackageId] ON [dbo].[PLAN001] ([PackageId])

GO

CREATE INDEX [IX_PLAN001_AccountIdProcessed] ON [dbo].[PLAN001] ([AccountID],[Processed])

