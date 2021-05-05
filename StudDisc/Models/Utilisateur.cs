using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Utilisateur : Personne
    {
        public Utilisateur(string nom, string prenom, string email, string mdp)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            Role = TypeUtilisateur.Utilisateur;
        }

        public Utilisateur() 
        {
            Role = TypeUtilisateur.Utilisateur;
        }


       public override bool Add()
        {
            UtilisateurDAO dao = new UtilisateurDAO();
            return dao.Add(this) > 0;
        }

        public override bool Update()
        {
            UtilisateurDAO dao = new UtilisateurDAO();
            return dao.Update(this) > 0;
        }

        public override bool Delete()
        {
            UtilisateurDAO dao = new UtilisateurDAO();
            return dao.Delete(this) > 0;
        }



        public List<Utilisateur> All()
        {
            UtilisateurDAO dao = new UtilisateurDAO();
            return dao.All();
        }


        public Utilisateur GetOne(int id)
        {
            UtilisateurDAO dao = new UtilisateurDAO();
            return dao.GetOne(id);
        }



    }
}
