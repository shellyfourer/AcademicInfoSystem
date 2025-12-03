using MySql.Data.MySqlClient; 
using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Database
{
    internal static class DatabaseConnection
    {
        private static string connectionString = //adress and login data to the database
            "Server=localhost;Database=ais;Uid=root;Pwd=YOUR-PASSWORD;";

        public static MySqlConnection GetConnection() //returns fresh database connection
        {
            return new MySqlConnection(connectionString);
        }
    }
}
