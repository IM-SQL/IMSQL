CREATE TABLE [dbo].[LogUser] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [name]               NVARCHAR (50) NOT NULL,
    [authenticationType] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

