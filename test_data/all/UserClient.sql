CREATE TABLE [dbo].[UserClient]
(
	[UserId] INT NOT NULL , 
    [ClientId] INT NOT NULL, 
    PRIMARY KEY ([ClientId], [UserId])
)
