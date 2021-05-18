
drop table utilisateur;
drop table PersonneThematique;
drop table Thematique;
drop table publication

CREATE TABLE [dbo].[Personne] (
    [idPersonne]        INT          IDENTITY (1, 1) NOT NULL,
    [nom]       VARCHAR (50) NOT NULL,
    [prenom]    VARCHAR (50) NOT NULL,
    [email] VARCHAR (50) NOT NULL,
    [mdp] VARCHAR (50) NOT NULL,
    [role] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idPersonne] ASC)
);

CREATE TABLE [dbo].[PersonneThematique] (
    [IdUT]       INT IDENTITY (1, 1) NOT NULL,
    [idUtilisateur] INT NOT NULL,
    [idThematique] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUT] ASC)
);

CREATE TABLE [dbo].[Thematique] (
    [idThematique]        INT          IDENTITY (1, 1) NOT NULL,
    [titre]       VARCHAR (50) NOT NULL,
    [date]    DATETIME NOT NULL,
    [idUtilisateur] int
    PRIMARY KEY CLUSTERED ([idThematique] ASC)
);


CREATE TABLE [dbo].[Publication] (
    [idPublication]        INT          IDENTITY (1, 1) NOT NULL,
    [date]    DATETIME NOT NULL,
    [corps] TEXT  NOT NULL,
    [idUtilisateur] int NOT NULL,
    [idThematique] int NOT NULL,
    PRIMARY KEY CLUSTERED ([idPublication] ASC)
);


