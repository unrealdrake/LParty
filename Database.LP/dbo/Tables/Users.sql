﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NVARCHAR(25) NOT NULL, 
    [LastName] NVARCHAR(30) NOT NULL
)
