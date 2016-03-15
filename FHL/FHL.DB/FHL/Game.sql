CREATE TABLE [FHL].[Game]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Game] PRIMARY KEY,
	
	[SeasonId] INT NOT NULL
		CONSTRAINT [FK_Game_Season] FOREIGN KEY ([SeasonId]) REFERENCES [FHL].[Season]([Id]),

	[GameNumber] TINYINT NOT NULL,
	[GameType] TINYINT NOT NULL
		CONSTRAINT [CK_Game_GameType] CHECK ([GameType] >= 1 AND [GameType] <= 5),
	[StartDateTime] DATETIME NOT NULL,

	[HomeLineupId] INT NOT NULL
		CONSTRAINT [FK_Game_Lineup_Home] FOREIGN KEY ([HomeLineupId]) REFERENCES [FHL].[Lineup]([Id]),
	[AwayLineupId] INT NOT NULL
		CONSTRAINT [FK_Game_Lineup_Away] FOREIGN KEY ([AwayLineupId]) REFERENCES [FHL].[Lineup]([Id]),
	
    CONSTRAINT [CK_Game_Season_GameNumber] UNIQUE ([SeasonId], [GameNumber])
)