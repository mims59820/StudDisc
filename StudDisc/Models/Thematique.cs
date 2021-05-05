using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Thematique
    {
        private int id;
        private string titre;
        private DateTime date;
        private int idUtilisateur;
        private List<Personne> utilisateurs;
        private List<Publication> publications;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        internal List<Personne> Utilisateurs { get => utilisateurs; set => utilisateurs = value; }
        internal List<Publication> Publications { get => publications; set => publications = value; }

        public Thematique(string titre, DateTime date, int idUtilisateur, List<Personne> utilisateurs, List<Publication> publications)
        {
            Titre = titre;
            Date = date;
            IdUtilisateur = idUtilisateur;
            Utilisateurs = utilisateurs;
            Publications = publications;
        }

        public Thematique(string titre, DateTime date, int idUtilisateurs)
        {
            Titre = titre;
            Date = date;
            IdUtilisateur = idUtilisateur;
        }


        public bool Add()
        {
            ThematiqueDAO dao = new ThematiqueDAO();
            return dao.Add(this) > 0;
        }

        public bool Update()
        {
            ThematiqueDAO dao = new ThematiqueDAO();
            return dao.Update(this) > 0;
        }

        public bool Delete()
        {
            ThematiqueDAO dao = new ThematiqueDAO();
            return dao.Delete(this) > 0;
        }


        public List<Thematique> All()
        {
            ThematiqueDAO dao = new ThematiqueDAO();
            return dao.All();
        }

        public Thematique GetOne(int id)
        {
            ThematiqueDAO dao = new ThematiqueDAO();
            return dao.GetOne(id);
        }
    }
}
