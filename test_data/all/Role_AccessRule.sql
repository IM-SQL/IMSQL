CREATE TABLE [dbo].[Role_AccessRule] (
    [RoleId]       INT NOT NULL,
    [AccessRuleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([AccessRuleId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_AccessRuleId_AccessRule] FOREIGN KEY ([AccessRuleId]) REFERENCES [dbo].[AccessRule] ([Id]),
    CONSTRAINT [FK_RoleId_AccessRule] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AccessRule] ([Id])
);

