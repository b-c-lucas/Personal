CREATE TABLE [FHL].[Season]
(
	[Id] INT NOT NULL CONSTRAINT [PK_Season] PRIMARY KEY,
	[LeagueId] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	
    CONSTRAINT [FK_Season_League] FOREIGN KEY ([LeagueId]) REFERENCES [FHL].[League]([Id])
)
