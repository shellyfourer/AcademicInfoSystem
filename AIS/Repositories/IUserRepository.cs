using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface IUserRepository   // abstraction
    {
        User? GetUserById(int userId);     // may return null
        List<User> GetAllUsers();      // returns list of all users
        void AddUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
    }
}

//This is the same as a pure virtual class in C++ that you later implement in a derived class (override the methods)

