CREATE TABLE [dbo].[Member]
(
	[Id_Member] INT IDENTITY,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(250) NOT NULL,
	[Firstname] NVARCHAR(50),
	[Lastname] NVARCHAR(50),
	[Pwd_Hash] CHAR(97) NOT NULL,

	CONSTRAINT PK_Member PRIMARY KEY([Id_Member]),
	CONSTRAINT UK_Member__Pseudo UNIQUE([Pseudo]),
	CONSTRAINT UK_Member__Email UNIQUE([Email])
)
