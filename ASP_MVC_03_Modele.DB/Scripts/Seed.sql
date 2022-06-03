USE [HeroesVsMonster]
GO

-- Member 
SET IDENTITY_INSERT [Member] ON;
GO

INSERT INTO [Member] ([Id_Member], [Pseudo], [Email], [Pwd_Hash])
 VALUES (1, 'Zaza', 'z.vanderquack@bxl.be', '$argon2id$v=19$m=65536,t=3,p=1$MrIh8vx8466qP4AhXxMV0Q$TuLLgqJ3IJRLmtaPX4VV1vEFAFiUm34VwP+eTFXYn98'); -- Test1234=
 
SET IDENTITY_INSERT [Member] OFF;
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
INSERT INTO [Hero] ([Name], [Endurance], [Strength], [Id_Race], [Id_Member])
 VALUES (N'Dominique', 10, 16, 1, 1),
		(N'Thierry', 18, 10, 2, 1);

-- Lieu (Biome)
INSERT INTO [Biome] ([Name], [Description], [Difficulty_Level], [Image_Uri])
 VALUES (N'Durotar', N'Durotar, terre baptisée ainsi en l''honneur du défunt père de Thrall, Durotan, se situe sur la côte orientale de Kalimdor. La région est limitrophe d''Azshara, au nord, et des Tarides du Nord, à l''ouest.', 1, NULL),
		(N'Reflet-de-Lune', N'Reflet-de-Lune est le refuge des Druides du monde entier. Ici, Taurens, Trolls et Elfes de la Nuit se réunissent pacifiquement pour montrer leur révérence à la Nature.', 2, NULL);