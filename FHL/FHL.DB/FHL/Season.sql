﻿CREATE TABLE [FHL].[Season]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Season] PRIMARY KEY,
	
	[LeagueId] INT NOT NULL
		CONSTRAINT [FK_Season_League] FOREIGN KEY ([LeagueId]) REFERENCES [FHL].[League]([Id]),

	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL
)
