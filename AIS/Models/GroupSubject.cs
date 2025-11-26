using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Models
{
    public class GroupSubject
    {
        public required int GroupSubjectId { 
            get; set; 
        }
        public required int StudentGroupId{ 
            get; set;
        }
        public required int SubjectId { 
            get; set;
        }

    }
}
