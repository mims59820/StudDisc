using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Administrateur : Personne
    {
        
        public Administrateur(string nom, string prenom, string email, string mdp) 
        {
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Mdp = mdp;
            Role = TypeUtilisateur.Administrateur;
        }

        public Administrateur() 
        {
            Role = TypeUtilisateur.Administrateur;
        }

        public override  bool Add()
        {
            AdministrateurDAO dao= new AdministrateurDAO();
            return dao.Add(this)>0;
        }

        public override bool Update()
        {
            AdministrateurDAO dao = new AdministrateurDAO();
            return dao.Update(this) > 0;
        }

        public override bool Delete()
        {
            AdministrateurDAO dao = new AdministrateurDAO();
            return dao.Delete(this) > 0;
        }


        public  List<Administrateur> All()
        {
            AdministrateurDAO dao = new AdministrateurDAO();
            return dao.All();
        }


        public Administrateur GetOne(int id)
        {
            AdministrateurDAO dao = new AdministrateurDAO();
            return dao.GetOne(id);
        }



    }
}
