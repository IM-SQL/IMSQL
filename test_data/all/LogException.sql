CREATE TABLE [dbo].[LogException] (
    [id]             INT             IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (512)  NOT NULL,
    [message]        NVARCHAR (512)  NULL,
    [stackTrace]     NVARCHAR (4000) NULL,
    [source]         NVARCHAR (256)  NULL,
    [innerException] INT             NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_LogException_ToLogException] FOREIGN KEY ([innerException]) REFERENCES [dbo].[LogException] ([id])
);



