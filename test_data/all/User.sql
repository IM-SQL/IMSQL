CREATE TABLE [dbo].[User] 
(
    [Id]          INT            NOT NULL IDENTITY,
    [DisplayName] NVARCHAR (300) NOT NULL,
    [Email]       NVARCHAR (500) NOT NULL,
    [CreatedDate] DATETIME       NOT NULL,
    [LastLogin]   DATETIME       NULL,
    [Enabled]     BIT            NOT NULL DEFAULT 0, 
    [Description] NVARCHAR(300)  NOT NULL DEFAULT ' ', 
    [Name]	      NVARCHAR (300) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

