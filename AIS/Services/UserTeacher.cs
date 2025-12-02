using System;
using System.Collections.Generic;
using System.Text;

namespace AIS.Services
{
    internal class UserTeacher:BaseUser
    {
        public required int TeacherId { get; set; }
        public required int SubjectId { get; set; }

        public void ViewStudentList() { }
        public void AssignGrades() { }
        public void EditGrades() { }
        public void ViewGrades() { }
    }
}
