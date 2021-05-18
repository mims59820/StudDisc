using StudDisc.Data;
using StudDisc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.DAO
{
    class PersonneThematiqueDAO
    {
        public int Add(PersonneThematique personneThematique)
        {
            SqlConnection connection = ConnectionDB.Connection;
            string request = " insert into PersonneThematique (idUtilisateur, idThematique) output inserted.idUT values (@idUtilisateur, @idThematique)";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@idUtilisateur", personneThematique.IdUtilisateur));
            command.Parameters.Add(new SqlParameter("@idThematique", personneThematique.IdThematique));
            
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return id;
        }

    }
}
