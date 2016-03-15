CREATE TABLE [FHL].[Conference]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Conference] PRIMARY KEY,
		
	[LeagueId] INT NOT NULL
		CONSTRAINT [FK_Conference_League] FOREIGN KEY ([LeagueId]) REFERENCES [FHL].[League]([Id]),

	[Name] NVARCHAR(100) NOT NULL,

	CONSTRAINT [CK_Conference_League_Name] UNIQUE ([LeagueId], [Name])
)
