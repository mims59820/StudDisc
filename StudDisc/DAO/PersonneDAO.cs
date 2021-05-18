using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class PersonneDAO
    {
        public int Add(Personne personne)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into Personne (nom, prenom, email, mdp, role) output inserted.idPersonne values (@nom,@prenom,@email,@mdp,@role )";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", personne.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", personne.Prenom));
            command.Parameters.Add(new SqlParameter("@email", personne.Email));
            command.Parameters.Add(new SqlParameter("@mdp", personne.Mdp));
            command.Parameters.Add(new SqlParameter("@role", personne.Role.ToString()));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Update(Personne personne)
        {
            string request = "Update Personne set nom = @nom, prenom=@prenom, email=@email, mdp=@mdp, role=@role where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", personne.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", personne.Prenom));
            command.Parameters.Add(new SqlParameter("@email", personne.Email));
            command.Parameters.Add(new SqlParameter("@mdp", personne.Mdp));
            command.Parameters.Add(new SqlParameter("@role", personne.Role));
            command.Parameters.Add(new SqlParameter("@id", personne.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbRow;
        }

        public int Delete(Personne personne)
        {
            string request = "delete Personne  where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", personne.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow;
        }




        public List<Personne> All()
        {
            List<Personne> personnes = new List<Personne>();
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne ";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Personne personne = new Personne(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                personne.Id = reader.GetInt32(0);
                personnes.Add(personne);
            }
            return personnes;
        }


        public List<Personne> AllVisiteur()
        {
            List<Personne> personnes = new List<Personne>();
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Visiteur'";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Personne personne = new Personne(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                personne.Id = reader.GetInt32(0);
                personnes.Add(personne);
            }
            return personnes;
        }


        public Personne GetOne(int id)
        {
            Personne personne = null;
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where idPersonne=@id";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                personne = new Personne(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                
            }
            command.Dispose();
            connection.Close();
            return personne;
        }

        public Personne Connexion(string email, string mdp)
        {
            Personne personne = null;
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.email=@email and personne.mdp=@mdp";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@mdp", mdp));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                personne = new Personne();
                personne.Id = reader.GetInt32(0);
                personne.Nom = reader.GetString(1);
                personne.Prenom = reader.GetString(2);
                personne.Mdp = reader.GetString(3);
            }
            return personne;
        }

    }
}
