CREATE TABLE [dbo].[Flights]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [StartTime] DATETIME NOT NULL, 
    [ReturnTime] DATETIME NOT NULL, 
    [Distance] INT NOT NULL
)
