﻿CREATE TABLE [dbo].[GPIN]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentID] NVARCHAR(15) NOT NULL,
	[BusinessID] NVARCHAR(15) NOT NULL,
	[ODM_CODE] NVARCHAR(50) NOT NULL,
	[IMEI_CODE] NVARCHAR(45) NOT NULL,
	[MODEL] NVARCHAR(20) NOT NULL,
	[BUYER_COLOR] NVARCHAR(10) NOT NULL,
	[MSN_CODE] NVARCHAR(30) NOT NULL,
	[PRODUCTION_DATE] NVARCHAR(8) NOT NULL,
	[SW_VERSION] NVARCHAR(600) NOT NULL,
	[CREATED_BY] INT NULL,
	[CREATION_DATE] DATE NULL,
	[LAST_UPDATE_DATE] DATE NULL,
	[LAST_UPDATED_BY] INT NULL,
	[TRANSFER_ID] NVARCHAR(100) NULL,
	[TRANSFER_DATE] DATE NOT NULL,
	[INVOICE_ID] NVARCHAR(18) NOT NULL,
	[PALLET_ID] NVARCHAR(30) NOT NULL,
	[BOX_ID] NVARCHAR(30) NOT NULL,
	[TRANSFER_FLAG] NVARCHAR(1) NULL,
	[ATTRIBUTE1] NVARCHAR(20) NULL,
	[ATTRIBUTE2] NVARCHAR(20) NULL,
	[ATTRIBUTE3] NVARCHAR(30) NOT NULL,
	[ATTRIBUTE4] NVARCHAR(45) NOT NULL,
	[ATTRIBUTE5] NVARCHAR(50) NOT NULL,
	[ATTRIBUTE6] NVARCHAR(15) NOT NULL,
	[ATTRIBUTE7] NVARCHAR(20) NOT NULL,
	[ATTRIBUTE8] NVARCHAR(50) NOT NULL,
	[ATTRIBUTE9] DATE NOT NULL,
	[ATTRIBUTE10] NVARCHAR(15) NOT NULL,
	[ATTRIBUTE11] NVARCHAR(10) NOT NULL,
	[ATTRIBUTE12] NVARCHAR(30) NOT NULL,
	[ATTRIBUTE13] NVARCHAR(50) NULL,
	[ATTRIBUTE14] NVARCHAR(18) NULL,
	[ATTRIBUTE15] NVARCHAR(18) NULL,
	[ATTRIBUTE16] NVARCHAR(18) NULL,
	[ATTRIBUTE17] NVARCHAR(18) NULL,
	[ATTRIBUTE18] NVARCHAR(6) NULL,
	[ATTRIBUTE19] NVARCHAR(10) NULL,
	[ATTRIBUTE20] NVARCHAR(16) NULL,
	[ATTRIBUTE21] NVARCHAR(16) NULL,
	[ATTRIBUTE22] NVARCHAR(16) NULL,
	[ATTRIBUTE23] NVARCHAR(3) NULL,
	[ATTRIBUTE24] NVARCHAR(30) NULL,
	[ATTRIBUTE25] NVARCHAR(10) NULL,
	[ATTRIBUTE26] DATE NULL,
	[ATTRIBUTE27] NVARCHAR(20) NULL,
	[ATTRIBUTE28] NVARCHAR(20) NULL,
	[ATTRIBUTE29] NVARCHAR(20) NULL,
	[ATTRIBUTE30] NVARCHAR(12) NULL,
	[ATTRIBUTE31] NVARCHAR(30) NULL,
	[ATTRIBUTE32] NVARCHAR(30) NULL,
	[ATTRIBUTE33] NVARCHAR(30) NULL,
	[ATTRIBUTE34] NVARCHAR(30) NULL,
	[ATTRIBUTE35] NVARCHAR(30) NULL,
	[ATTRIBUTE36] NVARCHAR(30) NULL,
	[ATTRIBUTE37] NVARCHAR(30) NULL,
	[ATTRIBUTE38] NVARCHAR(30) NULL,
	[ATTRIBUTE39] NVARCHAR(30) NULL,
	[ATTRIBUTE40] NVARCHAR(30) NULL,
	[ATTRIBUTE41] NVARCHAR(30) NULL,
	[ATTRIBUTE42] NVARCHAR(30) NULL,
	[ATTRIBUTE43] NVARCHAR(30) NULL,
	[ATTRIBUTE44] NVARCHAR(30) NULL,
	[ATTRIBUTE45] NVARCHAR(30) NULL,
	[ATTRIBUTE46] NVARCHAR(30) NULL,
	[ATTRIBUTE47] NVARCHAR(60) NULL,
	[ATTRIBUTE48] NVARCHAR(100) NOT NULL,
	[ATTRIBUTE49] NVARCHAR(100) NULL,
	[ATTRIBUTE50] NVARCHAR(30) NULL,
	[ATTRIBUTE51] NVARCHAR(30) NULL,
	[ATTRIBUTE52] NVARCHAR(32) NULL,
	[ATTRIBUTE53] NVARCHAR(1536) NULL,
	[ATTRIBUTE54] NVARCHAR(30) NOT NULL,
	[ATTRIBUTE55] NVARCHAR(30) NOT NULL,
    [Timestamp] DATETIME NOT NULL DEFAULT getutcdate(), 
    [PackageId] INT NULL, 
    [Processed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_GPIN_ToPackage] FOREIGN KEY ([PackageId]) REFERENCES [Package]([Id])
)