using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Visiteur : Personne
    {
       
        public Visiteur(string nom, string prenom, string email, string mdp, TypeUtilisateur role) 
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            Role = TypeUtilisateur.Visiteur;
        }
        public Visiteur() 
        {
            Role = TypeUtilisateur.Visiteur;
        }

        public Visiteur(string nom, string prenom, string email, string mdp) : base(nom, prenom, email, mdp)
        {
        }

        public override bool Add()
        {
            VisiteurDAO dao = new VisiteurDAO();
            return dao.Add(this)>0;
        }

        public override bool Update()
        {
            VisiteurDAO dao = new VisiteurDAO();
            return dao.Update(this) > 0;
        }

        public override bool Delete()
        {
            VisiteurDAO dao = new VisiteurDAO();
            return dao.Delete(this) > 0;
        }


        public List<Visiteur> All()
        {
            VisiteurDAO dao = new VisiteurDAO();
            return dao.All();
        }


        public Visiteur GetOne(int id)
        {
            VisiteurDAO dao = new VisiteurDAO();
            return dao.GetOne(id);
        }

    }
}
