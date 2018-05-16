CREATE TABLE [dbo].[AccessRule] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (500) NOT NULL,
    [Enabled] BIT NOT NULL DEFAULT 1, 
    [IsRole] BIT NOT NULL DEFAULT 0
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

