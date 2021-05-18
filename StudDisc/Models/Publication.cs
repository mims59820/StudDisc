using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class Publication
    {

        private int id;
        private int idThematique;
        private int idUtilisateur;
        private string paragraphe;
        private DateTime date;

        public int Id { get => id; set => id = value; }
        public int IdThematique { get => idThematique; set => idThematique = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public string Paragraphe { get => paragraphe; set => paragraphe = value; }
        public DateTime Date { get => date; set => date = value; }

        public Publication(int idThematique, int idUtilisateur, string paragraphe, DateTime date)
        {
            IdThematique = idThematique;
            IdUtilisateur = idUtilisateur;
            Paragraphe = paragraphe;
            Date = date;
        }
        public Publication()
        {
           
        }


        public int Add()
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.add(this);
        }


        public int Update()
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.Update(this);
        }

        public int Delete()
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.Delete(this);
        }

        public List<Publication> All()
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.All();
        }

        public Publication GetOne(int id)
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.GetOne(id);
        }

        
        public static List<Publication> AllByTheme(int id)
        {
            PublicationDAO dao = new PublicationDAO();
            return dao.AllByTheme(id);
        }


    }
}
