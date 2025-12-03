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
        public override string DescribeRole()
        {
            return "Student: Views subjects, grades and teachers.";
        }

        public virtual List<Grade> ViewGrades()
        {
            var repo = new GradeRepository();
            return repo.GetAllGrades()
                       .Where(g => g.StudentId == StudentId)
                       .ToList();
        }
        public virtual List<Subject> ViewSubjects()
        {
            var groupSubjectRepo = new GroupSubjectRepository();
            var subjectRepo = new SubjectRepository();

            // all subject IDs assigned to this student's group
            var subjectIds = groupSubjectRepo.GetSubjectsByGroupId(StudentGroupId);

            // load full Subject objects
            var subjects = subjectIds
                .Select(id => subjectRepo.GetSubjectById(id))
                .Where(s => s != null)
                .ToList();

            return subjects!;
        }
    }
}
