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
CodeDep Char(4),
constraint fkcodedep foreign key(CodeDep) REFERENCES Departements(CodeDep)
);

INSERT INTO Departements VALUES('100', 'Ressources Humaines');
INSERT INTO Departements VALUES('200', 'Marketing');
INSERT INTO Departements VALUES('300', 'Informatique');
INSERT INTO Departements VALUES('400', 'Administation');
INSERT INTO Departements VALUES('500', 'Comptabilité');

/-- Departement 100
INSERT INTO Employes VALUES(10,'Bourssio','Xavios',100000,1,'100');
INSERT INTO Employes VALUES(11,'The Butcher','Mélios',70000,2,'100');
/-- Departement 200
INSERT INTO Employes VALUES(12,'Baccon','Fredéric',45000,5,'200');
INSERT INTO Employes VALUES(13,'Hibou','Paul',78000,4,'200');
/-- Departement 300
INSERT INTO Employes VALUES(14,'LeMayor','Roux', 25000,6,'300');
INSERT INTO Employes VALUES(15,'KohPer','Shoun',65000,7,'300');
/-- Departement 400
INSERT INTO Employes VALUES(16,'Deloin','Manuwel',98000,8,'400');
INSERT INTO Employes VALUES(17,'Syvestio','Davyd', 25000,9,'400');
/-- Departement 500
INSERT INTO Employes VALUES(18,'Clémentine','Dominique',100000,3,'500');
INSERT INTO Employes VALUES(19,'Enfant','Alexiss',50000,10,'500');