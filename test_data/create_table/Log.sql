CREATE TABLE [dbo].[Log] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [level]        INT            NOT NULL,
    [timestamp]    DATETIME       NOT NULL,
    [message]      NVARCHAR (512) NOT NULL,
    [computerInfo] INT            NOT NULL,
    [entity]       INT            NULL,
    [exception]    INT            NULL,
    [query]        INT            NULL,
    [user]         INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Log_ToLogComputerInfo] FOREIGN KEY ([computerInfo]) REFERENCES [dbo].[LogComputerInfo] ([id]),
    CONSTRAINT [FK_Log_ToLogEntity] FOREIGN KEY ([entity]) REFERENCES [dbo].[LogEntity] ([id]),
    CONSTRAINT [FK_Log_ToLogException] FOREIGN KEY ([exception]) REFERENCES [dbo].[LogException] ([id]),
    CONSTRAINT [FK_Log_ToLogLevel] FOREIGN KEY ([level]) REFERENCES [dbo].[LogLevel] ([id]),
    CONSTRAINT [FK_Log_ToLogQuery] FOREIGN KEY ([query]) REFERENCES [dbo].[LogQuery] ([id]),
    CONSTRAINT [FK_Log_ToLogUser] FOREIGN KEY ([user]) REFERENCES [dbo].[LogUser] ([id])
);



