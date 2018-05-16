CREATE TABLE [dbo].[User_AccessRule] (
    [UserId]       INT NOT NULL,
    [AccessRuleId] INT NOT NULL,
    CONSTRAINT [PK_Role_AccessRule] PRIMARY KEY CLUSTERED ([UserId] ASC, [AccessRuleId] ASC),
    CONSTRAINT [FK_UserAccessRuleId_AccessRule] FOREIGN KEY ([AccessRuleId]) REFERENCES [dbo].[AccessRule] ([Id]),
    CONSTRAINT [FK_UserId_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

