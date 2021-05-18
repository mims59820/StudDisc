using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace StudDisc.Models
{
    class Personne : Window
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
        private TypeUtilisateur role;

        public Personne(string nom, string prenom, string email, string mdp)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            Role = TypeUtilisateur.Visiteur;
        }

        public Personne(int id, string nom, string prenom, string email, string mdp, string role)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            switch (role)
            {
                case "Visiteur":
                    Role = TypeUtilisateur.Visiteur;
                    break;
                case "Administrateur":
                    Role = TypeUtilisateur.Administrateur;
                    break;
                case "Utilisateur":
                    Role = TypeUtilisateur.Utilisateur;
                    break;
                 default:
                    Role = TypeUtilisateur.Visiteur;
                    break;
            }
        }

        public Personne()
        {
            Role = TypeUtilisateur.Visiteur;
        }

       

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        internal TypeUtilisateur Role { get => role; set => role = value; }




        public virtual bool Add()
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.Add(this)>0;
        }


        public virtual bool Update()
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.Update(this) > 0;
        }

        public virtual bool Delete()
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.Delete(this) > 0;
        }


        public List<Personne> All()
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.All();
        }

        public List<Personne> AllVisiteur()
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.AllVisiteur();
        }


        public static Personne GetOne(int id)
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.GetOne(id);
        }


        public Personne Connexion(string email, string mdp)
        {
            PersonneDAO dao = new PersonneDAO();
            return dao.Connexion(email, mdp);
        }



    }

    enum TypeUtilisateur
    {
        Administrateur,
        Utilisateur,
        Visiteur
    }

}
