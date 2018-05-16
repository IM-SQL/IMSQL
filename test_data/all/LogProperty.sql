CREATE TABLE [dbo].[LogProperty] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [log]   INT            NOT NULL,
    [name]  NVARCHAR (256) NOT NULL,
    [value] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_LogProperty_ToLog] FOREIGN KEY ([log]) REFERENCES [dbo].[Log] ([id])
);


GO

CREATE NONCLUSTERED INDEX [IX_LogProperty_LogName] ON [dbo].[LogProperty] ([log],[name]) INCLUDE ([value])
