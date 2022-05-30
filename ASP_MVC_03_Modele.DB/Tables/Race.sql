CREATE TABLE [dbo].[Race]
(
	[Id_Race] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Endurance_Modifier] INT NOT NULL DEFAULT 0,
	[Strength_Modifier] INT NOT NULL DEFAULT 0,

	CONSTRAINT PK_Race PRIMARY KEY ([Id_Race]),
	CONSTRAINT UK_Race__Name UNIQUE ([Name])
)
