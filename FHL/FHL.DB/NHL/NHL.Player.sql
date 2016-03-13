CREATE TABLE [NHL].[Player]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[TeamId] INT NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Position] CHAR(1) NOT NULL,
    [IsActive] BIT NOT NULL, 
    [PlayerLink] NVARCHAR(50) NULL, 

    CONSTRAINT [FK_Player_Team] FOREIGN KEY ([TeamId]) REFERENCES [NHL].[Team]([Id])
)