CREATE TABLE [dbo].[logsSamsung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logDate] [datetime] NULL,
	[transactionDate] [date] NULL,
	[interface] [varchar](20) NULL,
	[description] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]