﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SKU] NVARCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL
)
