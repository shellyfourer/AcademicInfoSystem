using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Repositories;

namespace AIS.Services
{
    public class UserStudent : BaseUser
    {
        public int StudentId { get; private set; }
        public int StudentGroupId { get; private set; }
        public UserStudent(int userId, string firstName, string lastName, string role,
                           int studentId, int studentGroupId)
            : base(userId, firstName, lastName, role)
        {
            StudentId = studentId;
            StudentGroupId = studentGroupId;
        }

        public virtual List<Grade> ViewGrades()
        {
            var repo = new GradeRepository();
            return repo.GetAllGrades()
                       .Where(g => g.StudentId == StudentId)
                       .ToList();
        }
    }
}
