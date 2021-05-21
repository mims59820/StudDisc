/*insert into Personne (nom, prenom, email, mdp,role) 
values ('toto','toto','toto@hotmail.fr','123','Visiteur' )
*/
--delete Personne  where idPersonne=1002 and role='visiteur'

select distinct Thematique.idThematique, Thematique.titre, Thematique.date, Thematique.idUtilisateur 
from Thematique inner join publication on Thematique.idThematique=Publication.idThematique 
where Publication.idUtilisateur=1