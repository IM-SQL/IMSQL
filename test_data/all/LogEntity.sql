CREATE TABLE [dbo].[LogEntity] (
    [id]     INT            IDENTITY (1, 1) NOT NULL,
    [type]   NVARCHAR (512) NOT NULL,
    [entity] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

