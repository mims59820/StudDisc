using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
        private TypeUtilisateur role;

        public Utilisateur(string nom, string prenom, string email, string mdp, TypeUtilisateur role)
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            Role = role;
        }

        public Utilisateur()
        {
        }

        public int Id { get => id;/* set => id = value;*/ }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        internal TypeUtilisateur Role { get => role; set => role = value; }
    }

    enum TypeUtilisateur
    {
        Administrateur,
        Utilisateur,
        Visiteur
    }

}
