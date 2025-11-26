using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class Student
    {
        public required int StudentId { 
            get; set; 
        }
        public required int UserId { 
            get; set;
        }
        public required int StudentGroupId{ 
            get; set;
        }
    }
}

