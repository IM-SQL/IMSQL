CREATE TABLE [dbo].[LogQuery] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [query]             NVARCHAR (MAX) NOT NULL,
    [isStoredProcedure] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

