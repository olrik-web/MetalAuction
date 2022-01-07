CREATE TABLE [dbo].[Køber] (
    [KøberId] INT           NOT NULL,
    [navn]    NVARCHAR (50) NULL,
    [tlf]     NVARCHAR (50) NULL,
    [email]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([KøberId] ASC)
);

CREATE TABLE [dbo].[Salgsudbud] (
    [SalgsudbudId] INT            NOT NULL,
    [metaltype]    VARCHAR (50)   NOT NULL,
    [mængde]       DECIMAL (7, 2) NOT NULL,
    [tidsfrist]    DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([SalgsudbudId] ASC)
);


CREATE TABLE [dbo].[Købstilbud] (
    [KøbstilbudId] INT            NOT NULL,
    [pris]         DECIMAL (7, 2) NOT NULL,
    [køberId]      INT            NOT NULL,
    [salgsudbudId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([KøbstilbudId] ASC),
    FOREIGN KEY ([køberId]) REFERENCES [dbo].[Køber] ([KøberId]),
    FOREIGN KEY ([salgsudbudId]) REFERENCES [dbo].[Salgsudbud] ([SalgsudbudId])
);


INSERT INTO [dbo].[Køber] ([KøberId], [navn], [tlf], [email]) VALUES (1, N'Sofus', N'12345678', N'sofus@mail.dk')
INSERT INTO [dbo].[Køber] ([KøberId], [navn], [tlf], [email]) VALUES (2, N'Sigurd', N'87654321', N'sigurd@mail.dk')
INSERT INTO [dbo].[Køber] ([KøberId], [navn], [tlf], [email]) VALUES (3, N'Mathias', N'12345679', N'mathias@mail.dk')
INSERT INTO [dbo].[Køber] ([KøberId], [navn], [tlf], [email]) VALUES (4, N'Marcus', N'12345678', N'marcus@mail.dk')

INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (1, N'Guld', CAST(10.00 AS Decimal(7, 2)), N'2021-06-01 20:00:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (3, N'Platin', CAST(5.00 AS Decimal(7, 2)), N'2021-06-01 22:00:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (5, N'Guld', CAST(1000.00 AS Decimal(7, 2)), N'2021-06-01 21:28:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (6, N'Guld', CAST(40.00 AS Decimal(7, 2)), N'2021-06-14 18:00:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (7, N'Sølv', CAST(50.00 AS Decimal(7, 2)), N'2021-06-14 19:00:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (8, N'Platin', CAST(60.00 AS Decimal(7, 2)), N'2021-06-14 17:00:00')
INSERT INTO [dbo].[Salgsudbud] ([SalgsudbudId], [metaltype], [mængde], [tidsfrist]) VALUES (9, N'Palladium', CAST(10.00 AS Decimal(7, 2)), N'2021-06-14 20:00:00')

INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (1, CAST(100.00 AS Decimal(7, 2)), 1, 1)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (2, CAST(40.00 AS Decimal(7, 2)), 2, 3)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (3, CAST(150.00 AS Decimal(7, 2)), 2, 1)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (4, CAST(120.00 AS Decimal(7, 2)), 1, 1)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (5, CAST(50.00 AS Decimal(7, 2)), 1, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (6, CAST(200.00 AS Decimal(7, 2)), 1, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (7, CAST(201.00 AS Decimal(7, 2)), 1, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (8, CAST(205.00 AS Decimal(7, 2)), 1, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (9, CAST(500.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (10, CAST(600.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (11, CAST(400.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (12, CAST(700.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (13, CAST(100.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (14, CAST(100.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (15, CAST(750.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (16, CAST(800.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (17, CAST(900.00 AS Decimal(7, 2)), 4, 6)
INSERT INTO [dbo].[Købstilbud] ([KøbstilbudId], [pris], [køberId], [salgsudbudId]) VALUES (18, CAST(150.00 AS Decimal(7, 2)), 4, 7)
