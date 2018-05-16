CREATE TABLE [dbo].[ErrorType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
	[EmailSubject] NVARCHAR(77) NOT NULL,
    [EmailBody] NVARCHAR(MAX) NOT NULL, 
    [Warning] BIT NOT NULL
)
