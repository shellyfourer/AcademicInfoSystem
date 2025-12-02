using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class User
    {
        public int UserId
        {
            get; set;
        }
        public  string FirstName { 
            get; set;
        }
        public  string LastName
        {
            get; set;
        }
        public  string Login
        {
            get; set;
        } 
        public  string Password
        {
            get; set;
        } 
        public  string Role //admin, teacher, student, make enum
        {
            get; set;
        }

    }
}

// A model is a C# representation of a database table.
// I use models to work with data as objects instead of raw SQL result rows.
// The program will access the database using raw SQL queries inside repository classes. (NO ORM)
// Repositories execute SQL commands, convert database results into model objects and return those objects for the forms to use.
// I only need to create models for the tables that the application will interact with.
// The User model is required for login and role-based dashboard navigation.
// CRUD operations for users will be implemented inside UserRepository:
//  - Create (Insert) - create new user
//  - Read (GetById, GetAll) - retrieve user(s)
//  - Update - modify existing user
//  - Delete - remove user





