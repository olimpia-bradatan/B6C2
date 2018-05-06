
-- Populating donationCenter

INSERT INTO [dbo].[donationCenter]
VALUES ('Spitalul Clinic de Recuperare', '46-50, , Strada Viilor, , Cluj-Napoca, Cluj, 400066, Romania');

INSERT INTO [dbo].[donationCenter]
VALUES ('Spitalul de recuperare I', ' , , Strada Observatorului, , Cluj-Napoca, Cluj, 400000, Romania');

INSERT INTO [dbo].[donationCenter]
VALUES ('Spitalul Privat de Obstetrica Novogyn', ' , , Calea Turzii, , Cluj-Napoca, Cluj, 400000, Romania');

INSERT INTO [dbo].[donationCenter]
VALUES ('Clinica Gynia', ' , 60, Strada General Traian Mosoiu, , Cluj-Napoca, Cluj, 400132, Romania');

INSERT INTO [dbo].[donationCenter]
VALUES ('Unitatea de Primiri Urgente', ' , 3-5, Strada Clinicilor, , Cluj-Napoca, Cluj, 400006, Romania');

-- Populating bloodResource


INSERT INTO [dbo].[bloodResource]
VALUES (10,1,2);

INSERT INTO [dbo].[bloodResource]
VALUES (13,2,1);

INSERT INTO [dbo].[bloodResource]
VALUES (15,3,5);

INSERT INTO [dbo].[bloodResource]
VALUES (16,4,7);

INSERT INTO [dbo].[bloodResource]
VALUES (20,5,6);

INSERT INTO [dbo].[bloodResource]
VALUES (19,3,4);

-- Populating centerEmployee

INSERT INTO [dbo].[centerEmployee]
VALUES (1,'Darius','Bucsa','idariusbucsa@gmail.com');

INSERT INTO [dbo].[centerEmployee]
VALUES (1,'Ahmad','Bayan','noaa322@gmail.com');

INSERT INTO [dbo].[centerEmployee]
VALUES (2,'Paul','Costea','paulcostea@gmail.com');

INSERT INTO [dbo].[centerEmployee]
VALUES (5,'Ilie','Nastase','ilienastase@gmail.com');

INSERT INTO [dbo].[centerEmployee]
VALUES (4,'Pavel','Bartos','pavelbartos@gmail.com');

INSERT INTO [dbo].[centerEmployee]
VALUES (3,'Pavel','Bartos','pavelbartos@gmail.com');

--Populating Donor

INSERT INTO [dbo].[Donor]
VALUES ('1720101417710','Ciprian','Porumbescu','01-01-1972','Strada Alexandru Vaida Voievod, Cluj-Napoca, Romania', 'ciprianporumbescu@gmail.com', '0723888442', 1,1 );

INSERT INTO [dbo].[Donor]
VALUES ('1960908071970','Robert','Corman','08-09-1996','Strada Cernei, Cluj-Napoca, Romania', 'robert.corman89@gmail.com', '0758392231', 2,2 );

INSERT INTO [dbo].[Donor]
VALUES ('1810707123764','Tudor','Popescu','07-07-1981','Louis Pasteur, Cluj-Napoca, Romania', 'tudorelll@gmail.com', '0758344531', 3,3 );

INSERT INTO [dbo].[Donor]
VALUES ('2940910123517','Alexandra','Gitescu','10-09-1994','Strada Primaverii, Cluj-Napoca, Romania', 'alexandrita@gmail.com', '0732344531', 4,4 );

INSERT INTO [dbo].[Donor]
VALUES ('1970605303722','Marian-Valer','Bolintineanu','05-06-1997','Strada Venus, Cluj-Napoca, Romania', 'bolintineanuvaler@gmail.com', '0751530747', 5,5 );

--Populating Hospital

INSERT INTO [dbo].[Hospital]
VALUES ('Spitalul de Pediatrie 2', '3-5, Strada Crisan , Cluj-Napoca, Cluj, 400124, Romania')

INSERT INTO [dbo].[Hospital]
VALUES ('Spitalul Clinic de Boli Infectioase', '23, Strada Iuliu Moldovan , Cluj-Napoca, Cluj, 400000, Romania')

INSERT INTO [dbo].[Hospital]
VALUES ('Spitalul Universitar C.F. Cluj', '23, Strada Iuliu Moldovan , Cluj-Napoca, Cluj, 400000, Romania')

INSERT INTO [dbo].[Hospital]
VALUES ('Clinica Neurochirurgie Cluj', 'Strada Louis Pasteur, Cluj-Napoca, Cluj, 400000, Romania')

INSERT INTO [dbo].[Hospital]
VALUES ('Reteaua de sanatate REGINA MARIA', 'Strada Louis Pasteur, Cluj-Napoca, Cluj, 400000, Romania')

--Populating Medic

INSERT INTO [dbo].[Medic]
VALUES ('Nicolae', 'Ceascu', 2, 'nicoceaun@gmail.com')

INSERT INTO [dbo].[Medic]
VALUES ('Ovidiu', 'Vantu', 3, 'ovidiufurtuna@gmail.com')

INSERT INTO [dbo].[Medic]
VALUES ('Vladimir', 'Putin', 1, 'vladimirputin@gmail.com')

INSERT INTO [dbo].[Medic]
VALUES ('Paul', 'Crisan', 5, 'paulcrisan@gmail.com')

INSERT INTO [dbo].[Medic]
VALUES ('Grigore', 'Apostol', 4, 'grigorell@gmail.com')

--Populating Patient

INSERT INTO [dbo].[Patient]
VALUES ('Valer', 'Bogoteanu', 'AB', '-', 2)

INSERT INTO [dbo].[Patient]
VALUES ('Andrei', 'Moldovan', 'A', '+', 3)

INSERT INTO [dbo].[Patient]
VALUES ('Dan', 'Sabo', 'B', '+', 5)

INSERT INTO [dbo].[Patient]
VALUES ('Adrian', '	Pop', '0', '-', 4)

INSERT INTO [dbo].[Patient]
VALUES ('Rares', 'Neacsu', '0', '+', 1)

--Populating Transaction

INSERT INTO [dbo].[Transaction]
VALUES (500, 2, 2, 2, 2, 'Pregatire')

INSERT INTO [dbo].[Transaction]
VALUES (700, 3, 3, 3, 3, 'Calificare')

INSERT INTO [dbo].[Transaction]
VALUES (685, 4, 4, 4, 4, 'Prelevare')

INSERT INTO [dbo].[Transaction]
VALUES (549, 5, 5, 5, 5, 'Distribuire')
