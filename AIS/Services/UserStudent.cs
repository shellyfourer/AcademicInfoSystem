using AIS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Services
{
    public class UserStudent:BaseUser
    {

        public  int StudentId { get; set; }
        public  int StudentGroupId { get; set; }

        public void ViewGrades()
        {
            
        }
        public void ViewGroupSubjects() { }
    }
}
