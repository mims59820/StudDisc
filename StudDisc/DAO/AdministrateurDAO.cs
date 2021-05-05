using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class AdministrateurDAO
    {

        public int Add(Administrateur admin)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into Personne (nom, prenom, email, mdp, role) output inserted.idPersonne values (@nom,@prenom,@email,@mdp,@role )";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom",admin.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", admin.Prenom));
            command.Parameters.Add(new SqlParameter("@email", admin.Email));
            command.Parameters.Add(new SqlParameter("@mdp", admin.Mdp));
            command.Parameters.Add(new SqlParameter("@role", admin.Role.ToString()));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

        public  int Update(Administrateur admin)
        {
            string request = "Update Personne set nom = @nom, prenom=@prenom, email=@email, mdp=@mdp, role=@role where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", admin.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", admin.Prenom));
            command.Parameters.Add(new SqlParameter("@email", admin.Email));
            command.Parameters.Add(new SqlParameter("@mdp", admin.Mdp));
            command.Parameters.Add(new SqlParameter("@role", admin.Role.ToString()));
            command.Parameters.Add(new SqlParameter("@id", admin.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbRow ;
        }

        public int Delete(Administrateur admin)
        {
            string request = "delete Personne  where idPersonne=@id";
            SqlConnection connection = ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", admin.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();

            return nbRow;
        }





        public List<Administrateur> All()
        {
            List<Administrateur> administrateurs = new List<Administrateur>();
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Administrateur'";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Administrateur admin = new Administrateur(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                admin.Id = reader.GetInt32(0);
                administrateurs.Add(admin);
            }
            return administrateurs;
        }


        public Administrateur GetOne(int id)
        {
            Administrateur admin = null;
            string request = "Select idPersonne, nom, prenom, email, mdp, role from personne where personne.role='Administrateur' and personne.idPersonne=@id";
            SqlConnection connection = Data.ConnectionDB.Connection;
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                admin = new Administrateur();
                admin.Id = reader.GetInt32(0);
                admin.Nom = reader.GetString(1);
                admin.Prenom = reader.GetString(2);
                admin.Mdp = reader.GetString(3);
            }
            return admin;
        }


    }
}
