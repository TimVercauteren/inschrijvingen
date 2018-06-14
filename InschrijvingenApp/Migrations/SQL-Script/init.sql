IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [adressen] (
    [Id] int NOT NULL IDENTITY,
    [Bus] nvarchar(max) NULL,
    [Gemeente] nvarchar(max) NULL,
    [Huisnummer] nvarchar(max) NULL,
    [Postcode] nvarchar(max) NULL,
    [Straat] nvarchar(max) NULL,
    CONSTRAINT [PK_adressen] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Authentication] (
    [Id] int NOT NULL IDENTITY,
    [Password] nvarchar(max) NULL,
    [User] nvarchar(max) NULL,
    CONSTRAINT [PK_Authentication] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [medisch] (
    [Id] int NOT NULL IDENTITY,
    [AanpakKind] nvarchar(max) NULL,
    [Allergieen] nvarchar(max) NULL,
    [AndereAandoeningen] nvarchar(max) NULL,
    [Astma] bit NOT NULL,
    [BelemmeringenSport] nvarchar(max) NULL,
    [Epilepsie] bit NOT NULL,
    [FotosAllowed] bit NOT NULL,
    [Geneesmiddelen] bit NOT NULL,
    [GeneesmiddelenLijst] nvarchar(max) NULL,
    [Hartkwaal] bit NOT NULL,
    [Huidaandoening] bit NOT NULL,
    [HuisArtsNaam] nvarchar(max) NULL,
    [HuisArtsTelefoon] nvarchar(max) NULL,
    [KanSporten] bit NOT NULL,
    [KanZwemmen] bit NOT NULL,
    [PijnStillersAllowed] bit NOT NULL,
    [Suikerziekte] bit NOT NULL,
    [VaccinatieKindEnGezin] bit NOT NULL,
    [ZiekteIngreep] nvarchar(max) NULL,
    CONSTRAINT [PK_medisch] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [personen] (
    [Id] int NOT NULL IDENTITY,
    [Naam] nvarchar(max) NULL,
    [Voornaam] nvarchar(max) NULL,
    CONSTRAINT [PK_personen] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [kinderen] (
    [Id] int NOT NULL IDENTITY,
    [AfhaalPersoon] nvarchar(max) NULL,
    [BroersZussen] nvarchar(max) NULL,
    [GeboorteDatum] datetime2 NOT NULL,
    [PersoonId] int NULL,
    [ZelfNaarHuis] bit NOT NULL,
    CONSTRAINT [PK_kinderen] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_kinderen_personen_PersoonId] FOREIGN KEY ([PersoonId]) REFERENCES [personen] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [ouders] (
    [Id] int NOT NULL IDENTITY,
    [AdresId] int NULL,
    [Email1] nvarchar(max) NULL,
    [Email2] nvarchar(max) NULL,
    [NoodTelefoon] nvarchar(max) NULL,
    [Ouder1Id] int NULL,
    [Ouder2Id] int NULL,
    [Telefoon1] nvarchar(max) NULL,
    [Telefoon2] nvarchar(max) NULL,
    CONSTRAINT [PK_ouders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ouders_adressen_AdresId] FOREIGN KEY ([AdresId]) REFERENCES [adressen] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ouders_personen_Ouder1Id] FOREIGN KEY ([Ouder1Id]) REFERENCES [personen] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ouders_personen_Ouder2Id] FOREIGN KEY ([Ouder2Id]) REFERENCES [personen] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [inschrijving] (
    [Id] int NOT NULL IDENTITY,
    [KindId] int NOT NULL,
    [MedischId] int NOT NULL,
    [OudersId] int NOT NULL,
    [OverigeInfo] nvarchar(max) NULL,
    CONSTRAINT [PK_inschrijving] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_inschrijving_kinderen_KindId] FOREIGN KEY ([KindId]) REFERENCES [kinderen] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_inschrijving_medisch_MedischId] FOREIGN KEY ([MedischId]) REFERENCES [medisch] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_inschrijving_ouders_OudersId] FOREIGN KEY ([OudersId]) REFERENCES [ouders] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_inschrijving_KindId] ON [inschrijving] ([KindId]);

GO

CREATE INDEX [IX_inschrijving_MedischId] ON [inschrijving] ([MedischId]);

GO

CREATE INDEX [IX_inschrijving_OudersId] ON [inschrijving] ([OudersId]);

GO

CREATE INDEX [IX_kinderen_PersoonId] ON [kinderen] ([PersoonId]);

GO

CREATE INDEX [IX_ouders_AdresId] ON [ouders] ([AdresId]);

GO

CREATE INDEX [IX_ouders_Ouder1Id] ON [ouders] ([Ouder1Id]);

GO

CREATE INDEX [IX_ouders_Ouder2Id] ON [ouders] ([Ouder2Id]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180614120952_init', N'2.0.3-rtm-10026');

GO