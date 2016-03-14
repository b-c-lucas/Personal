CREATE TABLE [FHL].[Lineup]
(
	[Id] INT NOT NULL  CONSTRAINT [PK_Lineup] PRIMARY KEY,
	[GameId] INT NOT NULL,
	[TeamId] INT NOT NULL, 
	[Score] TINYINT NULL,
	[Forward1Id] INT NULL,
	[Forward2Id] INT NULL,
	[Forward3Id] INT NULL,
	[Forward4Id] INT NULL,
	[Forward5Id] INT NULL,
	[Forward6Id] INT NULL,
	[Defenceman1Id] INT NULL,
	[Defenceman2Id] INT NULL,
	[Defenceman3Id] INT NULL,
	[Defenceman4Id] INT NULL,
	
	CONSTRAINT [FK_Lineup_Game] FOREIGN KEY ([GameId]) REFERENCES [FHL].[Game]([Id]),
	CONSTRAINT [FK_Lineup_Team] FOREIGN KEY ([TeamId]) REFERENCES [FHL].[Team]([Id]),

	CONSTRAINT [FK_Lineup_Player_F1] FOREIGN KEY ([Forward1Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_F2] FOREIGN KEY ([Forward2Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_F3] FOREIGN KEY ([Forward3Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_F4] FOREIGN KEY ([Forward4Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_F5] FOREIGN KEY ([Forward5Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_F6] FOREIGN KEY ([Forward6Id]) REFERENCES [FHL].[Player]([Id])
	,
	CONSTRAINT [FK_Lineup_Player_D1] FOREIGN KEY ([Defenceman1Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_D2] FOREIGN KEY ([Defenceman2Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_D3] FOREIGN KEY ([Defenceman3Id]) REFERENCES [FHL].[Player]([Id]),
	CONSTRAINT [FK_Lineup_Player_D4] FOREIGN KEY ([Defenceman4Id]) REFERENCES [FHL].[Player]([Id])
)
