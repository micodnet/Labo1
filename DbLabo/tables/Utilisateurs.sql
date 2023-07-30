CREATE TABLE [dbo].[Utilisateurs]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [LastName] NCHAR(50) NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [Email] NCHAR(50) NOT NULL
)
