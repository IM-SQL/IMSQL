CREATE TABLE [dbo].[LogQueryParameters] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [name]  NVARCHAR (128) NOT NULL,
    [value] NVARCHAR (MAX) NOT NULL,
    [type]  NVARCHAR (512) NOT NULL,
    [query] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_LogQueryParameters_ToLogQuery] FOREIGN KEY ([query]) REFERENCES [dbo].[LogQuery] ([id])
);

