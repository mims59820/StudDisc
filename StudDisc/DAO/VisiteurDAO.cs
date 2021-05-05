using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class VisiteurDAO
    {


        public int Add(Visiteur visiteur)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into Personne (nom, prenom, email, mdp, role) output inserted.idPersonne values (@nom,@prenom,@email,@mdp,@role )";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", visiteur.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", visiteur.Prenom));
            command.Parameters.Add(new SqlParameter("@email", visiteur.Email));
            command.Parameters.Add(new SqlParameter("@mdp", visiteur.Mdp));
            command.Parameters.Add(new SqlParameter("@role", visiteur.Role.ToString()));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public int Update(Visiteur visiteur)
        {
            string request = "Update Personne set nom = @nom, prenom=@prenom, email=@email, mdp=@mdp, role=@role where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", visiteur.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", visiteur.Prenom));
            command.Parameters.Add(new SqlParameter("@email", visiteur.Email));
            command.Parameters.Add(new SqlParameter("@mdp", visiteur.Mdp));
            command.Parameters.Add(new SqlParameter("@role", visiteur.Role.ToString()));
            command.Parameters.Add(new SqlParameter("@id", visiteur.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow;
        }

        public int Delete(Visiteur visiteur)
        {
            string request = "delete Personne  where idPersonne=@id and role=@role";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", visiteur.Id));
            command.Parameters.Add(new SqlParameter("@role", visiteur.Role.ToString()));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow;
        }

        public List<Visiteur> All()
        {
            List<Visiteur> visiteurs = new List<Visiteur>();
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Visiteur'";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Visiteur visiteur = new Visiteur( reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                visiteur.Id = reader.GetInt32(0);
                visiteurs.Add(visiteur);
            }
            return visiteurs;
        }


        public Visiteur GetOne(int id)
        {
            Visiteur visiteur = null;
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Visiteur' and personne.idPersonne=@id";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                visiteur = new Visiteur();
                visiteur.Id = reader.GetInt32(0);
                visiteur.Nom = reader.GetString(1);
                visiteur.Prenom = reader.GetString(2);
                visiteur.Mdp = reader.GetString(3);
            }
            return visiteur;
        }

    }
}
