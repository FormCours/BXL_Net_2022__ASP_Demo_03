CREATE TABLE [dbo].[Hero]
(
	[Id_Hero] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Endurance] INT NOT NULL,
	[Strength] INT NOT NULL,
	[Id_Race] INT NOT NULL,
	[Id_Member] INT NOT NULL,

	CONSTRAINT PK_Hero 
		PRIMARY KEY([Id_Hero]),

	CONSTRAINT FK_Hero__Member
		FOREIGN KEY ([Id_Member])
		REFERENCES [Member]([Id_Member])
		ON UPDATE CASCADE
		ON DELETE CASCADE, -- Si le compte est delete, ses heros aussi !

	CONSTRAINT FK_Hero__Race 
		FOREIGN KEY ([Id_Race])
		REFERENCES [Race]([Id_Race])
		ON UPDATE CASCADE
		ON DELETE NO ACTION
)
