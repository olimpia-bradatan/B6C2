
CREATE TABLE [dbo].[Hospital] (
    [idHospital] INT           NOT NULL,
    [name]       VARCHAR (100) NOT NULL,
    [address]    VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([idHospital] ASC)
);


CREATE TABLE [dbo].[Blood] (
    [idBlood] INT         IDENTITY (1, 1) NOT NULL,
    [group]   VARCHAR (3) NOT NULL,
    [RH]      VARCHAR (1) NOT NULL,
    PRIMARY KEY CLUSTERED ([idBlood] ASC)
);

INSERT INTO [dbo].[Blood]
VALUES ('0', '+');
INSERT INTO Blood
VALUES ('0', '-');
INSERT INTO Blood
VALUES ('A', '+');
INSERT INTO Blood
VALUES ('A', '-');
INSERT INTO Blood
VALUES ('B', '+');
INSERT INTO Blood
VALUES ('B', '-');
INSERT INTO Blood
VALUES ('AB', '+');
INSERT INTO Blood
VALUES ('AB', '-');




CREATE TABLE [dbo].[donationCenter] (
    [idCenter] INT           IDENTITY (1, 1) NOT NULL,
    [name]     VARCHAR (100) NOT NULL,
    [address]  VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([idCenter] ASC)
);

CREATE TABLE [dbo].[Donor] (
    [idDonor]     INT          IDENTITY (1, 1) NOT NULL,
    [firstName]   VARCHAR (50) NOT NULL,
    [lastName]    VARCHAR (50) NOT NULL,
    [birthDate]   DATE         NOT NULL,
    [address]    VARCHAR (50) NOT NULL,
    [email]       VARCHAR (50) NOT NULL,
    [phoneNumber] VARCHAR (10) NOT NULL,
    [idBlood]     INT          NULL,
    [idCenter]    INT          NULL,
    PRIMARY KEY CLUSTERED ([idDonor] ASC),
    FOREIGN KEY ([idCenter]) REFERENCES [dbo].[donationCenter] ([idCenter]),
	FOREIGN KEY ([idBlood]) REFERENCES [dbo].[Blood] ([idBlood])
);






CREATE TABLE [dbo].[bloodResource] (
    [quantity] INT NOT NULL,
    [idCenter] INT NOT NULL,
    [idBlood]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idCenter] ASC, [idBlood] ASC),
    FOREIGN KEY ([idCenter]) REFERENCES [dbo].[donationCenter] ([idCenter]),
    FOREIGN KEY ([idBlood]) REFERENCES [dbo].[Blood] ([idBlood])
);




CREATE TABLE [dbo].[centerEmployee] (
    [idEmployee] INT IDENTITY (1, 1) NOT NULL,
    [idCenter]   INT NULL,
	[firstName] varchar(20) NULL,
	[lastName] varchar(20) NULL,
	[email] varchar(30) NOT NULL,
    PRIMARY KEY CLUSTERED ([idEmployee] ASC),
    FOREIGN KEY ([idCenter]) REFERENCES [dbo].[donationCenter] ([idCenter])
);





CREATE TABLE [dbo].[Medic] (
    [idMedic]    INT          NOT NULL,
    [firstName]  VARCHAR (50) NOT NULL,
    [lastName]   VARCHAR (50) NOT NULL,
    [idHospital] INT          NULL,
    PRIMARY KEY CLUSTERED ([idMedic] ASC),
    FOREIGN KEY ([idHospital]) REFERENCES [dbo].[Hospital] ([idHospital])
);



CREATE TABLE [dbo].[Patient] (
    [idPatient] INT          NOT NULL,
    [firstName] VARCHAR (50) NOT NULL,
    [lastName]  VARCHAR (50) NOT NULL,
    [group]     VARCHAR (3)  NOT NULL,
    [RH]        VARCHAR (1)  NOT NULL,
    [idMedic]   INT          NULL,
    PRIMARY KEY CLUSTERED ([idPatient] ASC),
    FOREIGN KEY ([idMedic]) REFERENCES [dbo].[Medic] ([idMedic])
);



CREATE TABLE [dbo].[Transaction] (
    [quantity]   INT           NOT NULL,
    [idCenter]   INT           NOT NULL,
    [idBlood]    INT           NOT NULL,
    [idHospital] INT           NOT NULL,
    [status]     VARCHAR (250) NOT NULL,
    FOREIGN KEY ([idCenter]) REFERENCES [dbo].[donationCenter] ([idCenter]),
    FOREIGN KEY ([idBlood]) REFERENCES [dbo].[Blood] ([idBlood]),
    FOREIGN KEY ([idHospital]) REFERENCES [dbo].[Hospital] ([idHospital])
);



CREATE TABLE [dbo].[AspNetRole] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRole]([Name] ASC);

CREATE TABLE [dbo].[AspNetUser] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [idRole]               NVARCHAR (128) NULL,
    [firstName]            NVARCHAR (100) NOT NULL,
    [lastName]             NVARCHAR (100) NOT NULL,
    [birthDay]             DATETIME       NOT NULL,
    [cardNumber]           NVARCHAR (20)  NOT NULL,
    [cnp]                  NVARCHAR (13)  NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([idRole]) REFERENCES [dbo].[AspNetRole] ([Id])
);











CREATE TABLE [dbo].[AspNetUserClaim] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUser] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserClaim]([UserId] ASC);


CREATE TABLE [dbo].[AspNetUserLogin] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUser] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserLogin]([UserId] ASC);



CREATE TABLE [dbo].[AspNetUserRole] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRole] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUser] ([Id]) ON DELETE CASCADE
);







GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[AspNetUserRole]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[AspNetUserRole]([RoleId] ASC);




GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUser]([UserName] ASC);

