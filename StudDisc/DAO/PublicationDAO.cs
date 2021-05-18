using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class PublicationDAO
    {


        public int add(Publication publication)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into Publication (date, corps, idUtilisateur, idThematique) output inserted.idPublication values (@date, @corps, @idUtilisateur, @idThematique )";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@date", publication.Date));
            command.Parameters.Add(new SqlParameter("@corps", publication.Paragraphe));
            command.Parameters.Add(new SqlParameter("@idUtilisateur", publication.IdUtilisateur));
            command.Parameters.Add(new SqlParameter("@idThematique", publication.IdThematique));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }



        public int Update(Publication publication)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = "update Publication set date=@date, corps=@corps, idUtilisateur=@idUtilisateur, idThematique=@idThematique where idPublication=@id ";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@date", publication.Date));
            command.Parameters.Add(new SqlParameter("@corps", publication.Paragraphe));
            command.Parameters.Add(new SqlParameter("@idUtilisateur", publication.IdUtilisateur));
            command.Parameters.Add(new SqlParameter("@idThematique", publication.IdThematique));
            command.Parameters.Add(new SqlParameter("@id", publication.Id));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Delete(Publication publication)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = "delete Publication where idPublication=@id ";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", publication.Id));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public List<Publication> All()
        {
            List<Publication> publications = new List<Publication>();
            SqlConnection connection = ConnectionDB.Connection;
            string request = "select idPublication, date, corps , idUtilisateur, idThematique from Publication";
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Publication pub = new Publication(reader.GetInt32(4), reader.GetInt32(3), reader.GetString(2), reader.GetDateTime(1));
                pub.Id = reader.GetInt32(0);
                publications.Add(pub);
            }
            command.Dispose();
            connection.Close();
            return publications;
        }

           
        public Publication GetOne(int id)
        {
            Publication pub = null;
            SqlConnection connection = ConnectionDB.Connection;
            string request = "select idPublication, date, corps , idUtilisateur, idThematique from Publication where idPublication=@id";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                pub = new Publication(reader.GetInt32(4), reader.GetInt32(3), reader.GetString(2), reader.GetDateTime(1));
                pub.Id = reader.GetInt32(0);
            }
            command.Dispose();
            connection.Close();
            return pub;
        }


        public List<Publication> AllByTheme(int idtheme)
        {
            List<Publication> publications = new List<Publication>();
            SqlConnection connection = ConnectionDB.Connection;
            string request = "select idPublication, date, corps , idUtilisateur, idThematique from Publication where idThematique=@id";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", idtheme));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Publication pub = new Publication(reader.GetInt32(4), reader.GetInt32(3), reader.GetString(2), reader.GetDateTime(1));
                pub.Id = reader.GetInt32(0);
                publications.Add(pub);
            }
            command.Dispose();
            connection.Close();
            return publications;
        }



    }
}
