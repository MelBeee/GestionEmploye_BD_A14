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
INSERT INTO Employes VALUES();
INSERT INTO Employes VALUES();
/-- Departement 200
INSERT INTO Employes VALUES();
INSERT INTO Employes VALUES();
/-- Departement 300
INSERT INTO Employes VALUES();
INSERT INTO Employes VALUES();
/-- Departement 400
INSERT INTO Employes VALUES();
INSERT INTO Employes VALUES();
/-- Departement 500
INSERT INTO Employes VALUES();
INSERT INTO Employes VALUES();