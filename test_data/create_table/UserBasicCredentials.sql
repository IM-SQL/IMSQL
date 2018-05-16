CREATE TABLE [dbo].[UserBasicCredentials] 
(
    [Id] NVARCHAR(255) NOT NULL, 
    [Password] NVARCHAR(512) NULL, 
    [UserId] INT NOT NULL,
	[Salt] nvarchar(512) NULL,
    CONSTRAINT [PK_UserBasicCredentials] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Credentials] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);