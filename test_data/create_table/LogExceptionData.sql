CREATE TABLE [dbo].[LogExceptionData] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [exception] INT            NOT NULL,
    [key]       NVARCHAR (MAX) NOT NULL,
    [value]     NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_LogExceptionData_ToLogException] FOREIGN KEY ([exception]) REFERENCES [dbo].[LogException] ([id])
);

