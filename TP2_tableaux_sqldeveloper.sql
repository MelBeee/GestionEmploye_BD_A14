drop table departements cascade constraints;
drop table employes cascade constraints; 

create table Departements
(
  CodeDep Char(4) primary key,
  NomDepartement varchar2(50)
);

create table Employes
(
  Empno number(6,0) primary key,
  Nom varchar2(30),
  Prenom varchar2(30),
  Salaire Number(8,2),
  Echelon Number(2,0),
  Adresse varchar2(60),
  CodeDep Char(4),
  constraint fkcodedep foreign key(CodeDep) REFERENCES Departements(CodeDep),
  constraint ckempno check (empno > 0),
  constraint cksalaire check (salaire >= 25000 and salaire <= 100000),
  constraint ckechelon check (echelon > 0)
);

INSERT INTO Departements VALUES('100', 'Ressources Humaines');
INSERT INTO Departements VALUES('200', 'Marketing');
INSERT INTO Departements VALUES('300', 'Informatique');
INSERT INTO Departements VALUES('400', 'Administation');
INSERT INTO Departements VALUES('500', 'Comptabilité');

/*
-- Departement 100
INSERT INTO Employes VALUES(10,'Bourssio',        'Xavios',   100000, 1,  '110 Dorion, St-Eustache',    '100');
INSERT INTO Employes VALUES(11,'Of CSharp',       'Queen',    100000, 2,  '120 Vaillant, Terrebonne',   '100');
-- Departement 200
INSERT INTO Employes VALUES(12,'Baccon',          'Fredéric', 45000,  5,  '130 Chatillon, Loraine',     '200');
INSERT INTO Employes VALUES(13,'LemaytoileDeMer', 'Patrick',  78000,  4,  '140 Souilly, St-Eustache',   '200');
-- Departement 300
INSERT INTO Employes VALUES(14,'LeMayor',         'Roux',     25000,  6,  '150 Dubreuil, Boisbriand',   '300');
INSERT INTO Employes VALUES(15,'KohPer',          'Shoun',    65000,  7,  '160 McGill, Montreal',       '300');
-- Departement 400
INSERT INTO Employes VALUES(16,'Deloin',          'Manuwel',  98000,  8,  '170 Pincourt, Mascouche',    '400');
INSERT INTO Employes VALUES(17,'Syvestio',        'Davyd',    25000,  9,  '180 Vaudry, Deux-Montagne',  '400');
-- Departement 500
INSERT INTO Employes VALUES(18,'Clémentine',      'Dominique',90000,  3,  '190 Beriot, Boisbriand',     '500');
INSERT INTO Employes VALUES(19,'Enfant',          'Alexiss',  50000,  10, '200 Delage, Mont-Tremblant', '500');
*/
//--- UPDATE EMPLOYES SET ADRESSE = 'BLABLA,   65RTU', ECHELON = 1, SALAIRE = 25000 WHERE EMPNO = 1;

SELECT * FROM EMPLOYES; 

commit;