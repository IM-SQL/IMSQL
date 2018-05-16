CREATE TABLE [dbo].[GISET001](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [nvarchar](40) NOT NULL,
	[Model] [nvarchar](40) NOT NULL,
	[GIDate] [nvarchar](8) NOT NULL,
	[GIPlan] [decimal](15, 3) NOT NULL,
	[GIQty] [decimal](15, 3) NOT NULL,
	[DATE_1] [date] NULL,
	[DATE_2] [date] NULL,
	[ETC_1] [nvarchar](50) NOT NULL,
	[ETC_2] [nvarchar](50) NULL,
	[ETC_3] [nvarchar](100) NULL,
	[ETC_4] [nvarchar](100) NULL,
	[QTY_1] [decimal](15, 3) NULL,
	[QTY_2] [decimal](15, 3) NULL,
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NULL, 
    [Processed] BIT NOT NULL DEFAULT 0,
    [interface] INT NULL, 
    CONSTRAINT [FK_GISET001_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id]), 
    CONSTRAINT [FK_GISET001_ToClient] FOREIGN KEY ([AccountID]) REFERENCES [Client]([ExternalId]),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE INDEX [IX_GISET001_PackageId] ON [dbo].[GISET001] ([PackageId])

GO

CREATE INDEX [IX_GISET001_AccountIdProcessed] ON [dbo].[GISET001] ([AccountID],[Processed])
