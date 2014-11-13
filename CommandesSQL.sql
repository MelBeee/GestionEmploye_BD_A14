/-- Commande pour afficher un employe dans le form ajouter (dans les bonnes textbox)
select empno, nom, prenom, salaire, echelon, adresse, codedep
from employes
where empno = 12;  /-- properties.settings.default.Empno au lieu du 12

/-- Commande pour supprimer un employe
delete from employes
where empno = 20;  /-- properties.settings.default.Empno au lieu de 20

/-- Commande pour afficher les departements et le nobmre d'employe dans chaque dans le datagridview de departement
select e.codedep, d.nomdepartement ,to_char(count(e.codedep))
from employes e 
inner join departements d on e.codedep = d.codedep 
group by e.codedep, d.nomdepartement 
order by e.codedep; 

/-- Commande pour ajouter des employ�s dans la BD (Remplacer els donn�es par les textbox.text)                          
insert into employes VALUES(20,'Alain','Patoche',30000,1,'210 Troll, Blainville','200');  

/-- Commande pour afficher tous les employ�s
select * from employes;

/-- Commande pour afficher tous les employ�s du d�partement choisi (remplacer 200 par combobox.text) 
select * from employes where codedep = 200;

/-- Commande pour afficher tous les employ�s avec le nom " " (remplacer En par textbox.text)
select * from employes where nom like 'En%';
