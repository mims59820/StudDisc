using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StudDisc.Data
{
    class ConnectionDB
    {
        private static string connection = @"Data Source=(localDB)\StudDisc;Integrated Security=True";

        public static SqlConnection Connection { get=> new SqlConnection(connection); }

       

    }
}
