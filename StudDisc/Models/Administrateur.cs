using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Administrateur : Utilisateur
    {
        public Administrateur(string nom, string prenom, string email, string mdp, TypeUtilisateur role) : base(nom, prenom, email, mdp, role)
        {

        }

        public Administrateur() : base()
        {

        }



    }
}
