USE [HeroesVsMonster]
GO

-- Race
SET IDENTITY_INSERT [Race] ON;
GO

INSERT INTO [Race] ([Id_Race], [Name], [Endurance_Modifier], [Strength_Modifier])
 VALUES (1, N'Humain', 1, 1),
		(2, N'Nain', 2, 0);
GO

SET IDENTITY_INSERT [Race] OFF;
GO

-- Hero
INSERT INTO [Hero] ([Name], [Endurance], [Strength], [Id_Race])
 VALUES (N'Dominique', 10, 16, 1),
		(N'Thierry', 18, 10, 2);
