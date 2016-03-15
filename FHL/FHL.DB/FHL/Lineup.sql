CREATE TABLE [FHL].[Lineup]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Lineup] PRIMARY KEY,

	[TeamId] INT NOT NULL, 
		CONSTRAINT [FK_Lineup_Team] FOREIGN KEY ([TeamId]) REFERENCES [FHL].[Team]([Id]),

	[Forward1GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F1] FOREIGN KEY ([Forward1GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F1] CHECK 
			(
				[Forward1GamePlayedId] IS NULL 
				OR
				(
					[Forward1GamePlayedId] != [Forward2GamePlayedId] 
					AND [Forward1GamePlayedId] != [Forward3GamePlayedId] 
					AND [Forward1GamePlayedId] != [Forward4GamePlayedId]
					AND [Forward1GamePlayedId] != [Forward5GamePlayedId]
					AND [Forward1GamePlayedId] != [Forward6GamePlayedId]
				)
			),
	[Forward2GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F2] FOREIGN KEY ([Forward2GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F2] CHECK 
			(
				[Forward2GamePlayedId] IS NULL 
				OR
				(
					[Forward2GamePlayedId] != [Forward1GamePlayedId] 
					AND [Forward2GamePlayedId] != [Forward3GamePlayedId] 
					AND [Forward2GamePlayedId] != [Forward4GamePlayedId]
					AND [Forward2GamePlayedId] != [Forward5GamePlayedId]
					AND [Forward2GamePlayedId] != [Forward6GamePlayedId]
				)
			),
	[Forward3GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F3] FOREIGN KEY ([Forward3GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F3] CHECK 
			(
				[Forward3GamePlayedId] IS NULL 
				OR
				(
					[Forward3GamePlayedId] != [Forward1GamePlayedId] 
					AND [Forward3GamePlayedId] != [Forward2GamePlayedId] 
					AND [Forward3GamePlayedId] != [Forward4GamePlayedId]
					AND [Forward3GamePlayedId] != [Forward5GamePlayedId]
					AND [Forward3GamePlayedId] != [Forward6GamePlayedId]
				)
			),
	[Forward4GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F4] FOREIGN KEY ([Forward4GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F4] CHECK 
			(
				[Forward4GamePlayedId] IS NULL 
				OR
				(
					[Forward4GamePlayedId] != [Forward1GamePlayedId] 
					AND [Forward4GamePlayedId] != [Forward2GamePlayedId] 
					AND [Forward4GamePlayedId] != [Forward3GamePlayedId]
					AND [Forward4GamePlayedId] != [Forward5GamePlayedId]
					AND [Forward4GamePlayedId] != [Forward6GamePlayedId]
				)
			),
	[Forward5GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F5] FOREIGN KEY ([Forward5GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F5] CHECK 
			(
				[Forward5GamePlayedId] IS NULL 
				OR
				(
					[Forward5GamePlayedId] != [Forward1GamePlayedId] 
					AND [Forward5GamePlayedId] != [Forward2GamePlayedId] 
					AND [Forward5GamePlayedId] != [Forward3GamePlayedId]
					AND [Forward5GamePlayedId] != [Forward4GamePlayedId]
					AND [Forward5GamePlayedId] != [Forward6GamePlayedId]
				)
			),
	[Forward6GamePlayedId] INT NULL 
		CONSTRAINT [FK_Lineup_GamePlayed_F6] FOREIGN KEY ([Forward6GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_F6] CHECK 
			(
				[Forward6GamePlayedId] IS NULL 
				OR
				(
					[Forward6GamePlayedId] != [Forward1GamePlayedId] 
					AND [Forward6GamePlayedId] != [Forward2GamePlayedId] 
					AND [Forward6GamePlayedId] != [Forward3GamePlayedId]
					AND [Forward6GamePlayedId] != [Forward4GamePlayedId]
					AND [Forward6GamePlayedId] != [Forward5GamePlayedId]
				)
			),

	[Defenceman1GamePlayedId] INT NULL
		CONSTRAINT [FK_Lineup_GamePlayed_D1] FOREIGN KEY ([Defenceman1GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_D1] CHECK 
			(
				[Defenceman1GamePlayedId] IS NULL 
				OR
				(
					[Defenceman1GamePlayedId] != [Defenceman2GamePlayedId] 
					AND [Defenceman1GamePlayedId] != [Defenceman3GamePlayedId] 
					AND [Defenceman1GamePlayedId] != [Defenceman4GamePlayedId]
				)
			),
	[Defenceman2GamePlayedId] INT NULL
		CONSTRAINT [FK_Lineup_GamePlayed_D2] FOREIGN KEY ([Defenceman2GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_D2] CHECK 
			(
				[Defenceman2GamePlayedId] IS NULL 
				OR
				(
					[Defenceman2GamePlayedId] != [Defenceman1GamePlayedId] 
					AND [Defenceman2GamePlayedId] != [Defenceman3GamePlayedId] 
					AND [Defenceman2GamePlayedId] != [Defenceman4GamePlayedId]
				)
			),
	[Defenceman3GamePlayedId] INT NULL
		CONSTRAINT [FK_Lineup_GamePlayed_D3] FOREIGN KEY ([Defenceman3GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_D3] CHECK 
			(
				[Defenceman3GamePlayedId] IS NULL 
				OR
				(
					[Defenceman3GamePlayedId] != [Defenceman1GamePlayedId] 
					AND [Defenceman3GamePlayedId] != [Defenceman2GamePlayedId] 
					AND [Defenceman3GamePlayedId] != [Defenceman4GamePlayedId]
				)
			),
	[Defenceman4GamePlayedId] INT NULL
		CONSTRAINT [FK_Lineup_GamePlayed_D4] FOREIGN KEY ([Defenceman4GamePlayedId]) REFERENCES [FHL].[GamePlayed]([Id])
		CONSTRAINT [CK_Lineup_IdUniqueness_D4] CHECK 
			(
				[Defenceman4GamePlayedId] IS NULL 
				OR
				(
					[Defenceman4GamePlayedId] != [Defenceman1GamePlayedId] 
					AND [Defenceman4GamePlayedId] != [Defenceman2GamePlayedId] 
					AND [Defenceman4GamePlayedId] != [Defenceman3GamePlayedId]
				)
			),	

	[GoalieId] INT NULL,

	[Score] TINYINT NOT NULL DEFAULT 0
)