using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Services
{
    public class BaseUser

    {
        public int UserId { get; private set; }
        public string Role { get; private set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        //constructor to initialize base user properties due to encapsulation
        public BaseUser(int userId, string firstName, string lastName, string role)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }


    }
}
