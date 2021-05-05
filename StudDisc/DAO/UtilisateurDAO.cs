using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class UtilisateurDAO : Personne
    {

        public int Add(Utilisateur utilisateur)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into Personne (nom, prenom, email, mdp, role) output inserted.idPersonne values (@nom,@prenom,@email,@mdp,@role )";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", utilisateur.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", utilisateur.Prenom));
            command.Parameters.Add(new SqlParameter("@email", utilisateur.Email));
            command.Parameters.Add(new SqlParameter("@mdp", utilisateur.Mdp));
            command.Parameters.Add(new SqlParameter("@role", utilisateur.Role.ToString()));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Update(Utilisateur utilisateur)
        {
            string request = "Update Personne set nom = @nom, prenom=@prenom, email=@email, mdp=@mdp, role=@role where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", utilisateur.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", utilisateur.Prenom));
            command.Parameters.Add(new SqlParameter("@email", utilisateur.Email));
            command.Parameters.Add(new SqlParameter("@mdp", utilisateur.Mdp));
            command.Parameters.Add(new SqlParameter("@role", utilisateur.Role.ToString()));
            command.Parameters.Add(new SqlParameter("@id", utilisateur.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow;
        }

        public int Delete(Utilisateur utilisateur)
        {
            string request = "delete Personne  where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", utilisateur.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow;
        }


        public List<Utilisateur> All()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Utilisateur'";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Utilisateur utilisateur = new Utilisateur(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                utilisateur.Id = reader.GetInt32(0);
                utilisateurs.Add(utilisateur);
            }
            return utilisateurs;
        }


        public Utilisateur GetOne(int id)
        {
            Utilisateur utilisateur = null;
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Utilisateur' and personne.idPersonne=@id";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                utilisateur = new Utilisateur();
                utilisateur.Id = reader.GetInt32(0);
                utilisateur.Nom = reader.GetString(1);
                utilisateur.Prenom = reader.GetString(2);
                utilisateur.Mdp = reader.GetString(3);
            }
            return utilisateur;

        }
    }
}