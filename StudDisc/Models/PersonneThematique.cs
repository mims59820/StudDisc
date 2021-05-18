using StudDisc.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudDisc.Models
{
    class PersonneThematique
    {

        private int idUT;
        private int idUtilisateur;
        private int idThematique;

        public int IdUT { get => idUT; set => idUT = value; }
        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public int IdThematique { get => idThematique; set => idThematique = value; }

        public PersonneThematique(int idUT, int idUtilisateur, int idThematique)
        {
            IdUT = idUT;
            IdUtilisateur = idUtilisateur;
            IdThematique = idThematique;
        }



        public PersonneThematique( int idUtilisateur, int idThematique)
        {
         
            IdUtilisateur = idUtilisateur;
            IdThematique = idThematique;
        }



        public PersonneThematique()
        {
           
        }


        public bool add()
        {
            PersonneThematiqueDAO dao = new PersonneThematiqueDAO();
            return dao.Add(this) > 0;
        }

    }
}
