using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Team4
/// </summary>
namespace TravelExperts
{
    public static class TravelExpertsDB
    {
        // Connectng to database and returns connection
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TravelExperts.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
