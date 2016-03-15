CREATE TABLE [NHL].[Player]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT [PK_Player] PRIMARY KEY, 
	[TeamId] INT NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Position] CHAR(1) NOT NULL,
    [IsActive] BIT NOT NULL, 
    [PlayerLink] NVARCHAR(100) NULL, 

    CONSTRAINT [FK_Player_Team] FOREIGN KEY ([TeamId]) REFERENCES [NHL].[Team]([Id])
)