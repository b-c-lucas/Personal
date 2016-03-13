CREATE TABLE [NHL].[Player]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Position] NCHAR(3) NOT NULL, 
    [TeamAbbreviation] NCHAR(3) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [PlayerLink] NVARCHAR(50) NULL
)