CREATE TABLE [FHL].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Date] DATE NOT NULL,
	[HomeLineupId] INT NOT NULL,
	[AwayLineupId] INT NOT NULL,

    CONSTRAINT [FK_Game_Lineup_Home] FOREIGN KEY ([HomeLineupId]) REFERENCES [FHL].[Lineup]([Id]),
    CONSTRAINT [FK_Game_Lineup_Away] FOREIGN KEY ([AwayLineupId]) REFERENCES [FHL].[Lineup]([Id])
)
