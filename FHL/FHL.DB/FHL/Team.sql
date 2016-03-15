CREATE TABLE [FHL].[Team]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Team] PRIMARY KEY,

	[ConferenceId] INT NOT NULL
		CONSTRAINT [FK_Team_Conference] FOREIGN KEY ([ConferenceId]) REFERENCES [FHL].[Conference]([Id]),
		
	[Name] NVARCHAR(100) NOT NULL,
	[Abbreviation] NCHAR(3) NOT NULL
)
