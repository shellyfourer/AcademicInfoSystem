using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class Grade
    {
        public required int GradeId
        {
            get; set;
        }
        public required int StudentId
        {
            get; set;
        }
        public required int SubjectId
        {
            get; set;
        }
        public required int GradeValue
        {
            get; set;
        }
        public required DateTime DateCreated
        {
            get; set;
        }
    }
}