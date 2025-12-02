using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class Grade
    {
        public  int GradeId
        {
            get; set;
        }
        public  int StudentId
        {
            get; set;
        }
        public  int SubjectId
        {
            get; set;
        }
        public  int GradeValue
        {
            get; set;
        }
        public  DateTime DateCreated
        {
            get; set;
        }
    }
}