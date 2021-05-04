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
        private List<Utilisateur> utilisateurs;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        internal List<Utilisateur> Utilisateurs { get => utilisateurs; set => utilisateurs = value; }

        public Thematique(string titre, DateTime date, int idUtilisateur, List<Utilisateur> utilisateurs)
        {
            Titre = titre;
            Date = date;
            IdUtilisateur = idUtilisateur;
            Utilisateurs = utilisateurs;
        }

        public Thematique(string titre, DateTime date, int idUtilisateurs)
        {
            Titre = titre;
            Date = date;
            IdUtilisateur = idUtilisateur;
        }

        public Thematique()
        {
        }

    }
}
