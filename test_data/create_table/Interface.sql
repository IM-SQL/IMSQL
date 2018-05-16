CREATE TABLE [dbo].[Interface]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NULL, 
    [FileNameTemplate] NVARCHAR(260) NOT NULL, 
    [ExecutionTime] TIME NOT NULL, 
    [ExecutionDayId] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Interface_ToWeekday] FOREIGN KEY ([ExecutionDayId]) REFERENCES [Weekday]([Id]) 
)
