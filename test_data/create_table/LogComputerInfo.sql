CREATE TABLE [dbo].[LogComputerInfo] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [userName]           NVARCHAR (50)  NOT NULL,
    [userDomainName]     NVARCHAR (50)  NOT NULL,
    [machineName]        NVARCHAR (50)  NOT NULL,
    [osVersion]          NVARCHAR (256) NOT NULL,
    [environmentVersion] NVARCHAR (128) NOT NULL,
    [ipAddress]          NVARCHAR (50)  NOT NULL,
    [macAddress]         NVARCHAR (50)  NOT NULL,
    [hash]               BIGINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_LogComputerInfo_hash]
    ON [dbo].[LogComputerInfo]([hash] ASC);

