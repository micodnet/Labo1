CREATE TABLE [dbo].[Administrateur]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [login] NCHAR(10) NULL, 
    [Password] NVARCHAR(MAX) NULL
)
