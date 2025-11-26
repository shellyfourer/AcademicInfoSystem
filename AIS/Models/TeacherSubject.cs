using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class TeacherSubject
    {
        public required int TeacherSubjectId { 
            get; set; 
        }
        public required int TeacherId { 
            get; set;
        }
        public required int SubjectId { 
            get; set;
        }
    }
}


