using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using StudDisc.Models;

namespace StudDisc.DAO
{
    class ThematiqueDAO
    {


        public int Add(Thematique theme)
        {
            string request = "insert into Thematique (titre, date, idUtilisateur) output inserted.idThematique values (@titre, @date, @idUtilisateur)";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", theme.Titre));
            command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@idUtilisateur", theme.IdUtilisateur));
            connection.Open();
            int id =(int) command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Update(Thematique theme)
        {
            string request = "update Thematique set idThematique=@id, titre=@titre, date=@date, idUtilisateur=@idutilisateur where idThematique=@idthematique";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", theme.Titre));
            command.Parameters.Add(new SqlParameter("@date", DateTime.Now));
            command.Parameters.Add(new SqlParameter("@idutilisateur", theme.IdUtilisateur));
            command.Parameters.Add(new SqlParameter("@idthematique", theme.Id));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Delete(Thematique theme)
        {
            string request = "delete Thematique  where idThematique=@idthematique";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idthematique", theme.Id));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }


        public List<Thematique> All()
        {
            List<Thematique> thematiques = new List<Thematique>();
            string request = "select idThematique, titre, date, idUtilisateur from Thematique";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thematique theme = new Thematique(reader.GetString(1), reader.GetDateTime(2),reader.GetInt32(3));
                theme.Id = reader.GetInt32(0);
                List<Publication> pubs = Publication.AllByTheme(theme.Id);
                theme.Publications = pubs;
                thematiques.Add(theme);
            }
            command.Dispose();
            connection.Close();
            return thematiques;
        }

        public Thematique GetOne(int idTheme)
        {
            Thematique theme = null;
            string request = "select idThematique, titre, date, idUtilisateur from Thematique where idThematique=@idTheme";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idTheme",idTheme));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 theme = new Thematique(reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                theme.Id = reader.GetInt32(0);
               
            }
            command.Dispose();
            connection.Close();
            return theme;
        }



        public List<Thematique> MyAll(int idUtilisateur)
        {
            List<Thematique> thematiques = new List<Thematique>();
            string request = "select idThematique, titre, date, idUtilisateur from Thematique where idUtilisateur=@idUtilisateur ";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idUtilisateur", idUtilisateur));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thematique theme = new Thematique(reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                theme.Id = reader.GetInt32(0);
                thematiques.Add(theme);
            }
            command.Dispose();
            connection.Close();
            return thematiques;
        }




        public List<Thematique> MyAllIntervention(int idUtilisateur)
        {
            List<Thematique> thematiques = new List<Thematique>();
            string request = "select Thematique.idThematique, Thematique.titre, Thematique.date, Thematique.idUtilisateur from Thematique inner join publication on Thematique.idThematique=Publication.idThematique where Publication.idUtilisateur=@idUtilisateur ";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idUtilisateur", idUtilisateur));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Thematique theme = new Thematique(reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
                theme.Id = reader.GetInt32(0);
                thematiques.Add(theme);
            }
            command.Dispose();
            connection.Close();
            return thematiques;
        }


        public int GetOneByTitre(string titre)
        {
            int numberLine=0;
            string request = "select idThematique, titre, date, idUtilisateur from Thematique where titre like @titre";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@titre", titre));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                numberLine++;
            }
            command.Dispose();
            connection.Close();
            return numberLine;
        }

    }
}
