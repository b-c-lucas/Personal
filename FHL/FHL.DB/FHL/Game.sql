CREATE TABLE [FHL].[Game]
(
	[Id] INT NOT NULL CONSTRAINT [PK_Game] PRIMARY KEY,
	[SeasonId] INT NOT NULL,
	[GameNumber] TINYINT NOT NULL,
	[GameType] TINYINT NOT NULL,
	[Date] DATE NOT NULL,
	[HomeLineupId] INT NOT NULL,
	[AwayLineupId] INT NOT NULL, 
	
    CONSTRAINT [CK_Game_Season_GameNumber] UNIQUE ([SeasonId], [GameNumber]),

    CONSTRAINT [CK_Game_GameType] CHECK ([GameType] >= 1 AND [GameType] <= 5),
	
    CONSTRAINT [FK_Game_Season] FOREIGN KEY ([SeasonId]) REFERENCES [FHL].[Season]([Id]),
    CONSTRAINT [FK_Game_Lineup_Home] FOREIGN KEY ([HomeLineupId]) REFERENCES [FHL].[Lineup]([Id]),
    CONSTRAINT [FK_Game_Lineup_Away] FOREIGN KEY ([AwayLineupId]) REFERENCES [FHL].[Lineup]([Id])
)