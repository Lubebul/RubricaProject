FRONTEND 

1 eseguire npm install nella cartella RubricaFE per installare i pacchetti
2 eseguire il comando "ng serve" per eseguire l'app




BACKEND

1 Modificare AppSetting.json per configurare DB con la connectionstring

2 esegui "dotnet ef database update" per applicare le migrazioni e generare il DB popolato con le città

3 se si vuole qualche contatto a DB ecco una lista query per popolare alcuni contatti di Mock


INSERT INTO [Rubrica].[dbo].[Contacts]
    ([Id], [Name], [Surname], [Gender], [Email], [PhoneNumber], [City], [BirthDate])
VALUES
('A3B2D9F7-1C6F-4E35-B2C9-1A1A23A11234', 'Luca', 'Verdi', 0, 'luca.verdi@email.com', '3331111111', 'Milano', '1985-07-21');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('B2A1C3D4-7E29-4B03-A5D7-9B2FEEBB2233', 'Anna', 'Russo', 1, 'anna.russo@email.com', '3332222222', 'Roma', '1992-03-10');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('C7D6E5F4-8A55-46C3-ABCD-11D9AA888888', 'Marco', 'Bianchi', 0, 'marco.bianchi@email.com', '3333333333', 'Torino', '1988-12-05');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('D4E3F2A1-1298-43B0-90AA-1234567890AB', 'Giulia', 'Ferrari', 1, 'giulia.ferrari@email.com', '3334444444', 'Firenze', '1995-09-15');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('E9F8A7B6-4567-4E32-9BA9-00AA00BB11CC', 'Davide', 'Romano', 0, 'davide.romano@email.com', '3335555555', 'Genova', '1983-11-30');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('F1E2D3C4-5678-4F98-AABB-CCDD11223344', 'Chiara', 'Gallo', 1, 'chiara.gallo@email.com', '3336666666', 'Napoli', '1991-01-25');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('AABBCCDD-9988-4455-A123-BBCDDEEFF001', 'Alessandro', 'Costa', 0, 'alessandro.costa@email.com', '3337777777', 'Barcellona', '1987-04-18');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('11223344-5566-7788-9900-AABBCCDDEEFF', 'Francesca', 'Martini', 1, 'francesca.martini@email.com', '3338888888', 'Lisbona', '1994-06-03');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('99887766-5544-3322-1100-FFEEDDCCBBAA', 'Matteo', 'Conti', 0, 'matteo.conti@email.com', '3339999999', 'Vienna', '1980-02-12');

INSERT INTO [Rubrica].[dbo].[Contacts]
VALUES
('22334455-6677-8899-AABB-CCDDEEFFAABB', 'Elisa', 'De Luca', 1, 'elisa.deluca@email.com', '3330000000', 'Amsterdam', '1996-08-27');
