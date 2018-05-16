CREATE TABLE [dbo].[AppSettings]
(
    [Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Value] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IsOptional] BIT NOT NULL DEFAULT 0
)
