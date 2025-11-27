using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User? GetUserById(int userId)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            //we make the query string with a parameter
            string query = "SELECT * FROM users WHERE user_id = @userId";

            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);

            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@userId", userId);

            //we execute the command and read the data
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //we create a user object from the data 
                var user = new User
                {
                    UserId = reader.GetInt32("user_id"),
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    Login = reader.GetString("login"),
                    Password = reader.GetString("password"),
                    Role = reader.GetString("role")
                };
                //now we return the user or null if not found
                return user;
            }
            else
            {
                return null;
            }
        }
        public List<User> GetAllUsers() 
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            //we make the query string
            string query = "SELECT * FROM users";

            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);

            //we do not need to add parameters here
            //so we execute the command and read the data
            using var reader = cmd.ExecuteReader();
            var users = new List<User>();
            while (reader.Read())
            {
                //we create a user object from the data 
                var user = new User
                {
                    UserId = reader.GetInt32("user_id"),
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    Login = reader.GetString("login"),
                    Password = reader.GetString("password"),
                    Role = reader.GetString("role")
                };
                users.Add(user);
            }
            return users;
        }
        public void AddUser(User user) 
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            //we make the query string with parameters
            string query = "INSERT INTO users (first_name, last_name, role) " +
                           "VALUES (@firstName, @lastName, @role)";

            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@role", user.Role);
            //we execute the command
            cmd.ExecuteNonQuery();
        }
        public void DeleteUser(int userId)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with a parameter
            string query = "DELETE FROM users WHERE user_id = @userId";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@userId", userId);
            //we execute the command
            cmd.ExecuteNonQuery();
        }
        public void UpdateUser(User user)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with parameters
            string query = "UPDATE users SET first_name = @firstName, last_name = @lastName, role = @role " +
                           "WHERE user_id = @userId";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@firstName", user.FirstName);
            cmd.Parameters.AddWithValue("@lastName", user.LastName);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@userId", user.UserId);
            //we execute the command
            cmd.ExecuteNonQuery();
        }
    }
}
