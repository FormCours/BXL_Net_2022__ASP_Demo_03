CREATE TABLE [dbo].[Biome]
(
	[Id_Biome] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[Difficulty_Level] INT NOT NULL,
	[Image_Uri] NVARCHAR(250) NULL,

	CONSTRAINT PK_Biome PRIMARY KEY ([Id_Biome]),
	CONSTRAINT UK_Biome__Name UNIQUE([Name])
)