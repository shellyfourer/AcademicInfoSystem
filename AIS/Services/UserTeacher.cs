using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Repositories;

namespace AIS.Services
{
    public class UserTeacher : BaseUser
    {
        public int TeacherId { get; private set; }
        public UserTeacher(int userId, string firstName, string lastName, string role, int teacherId)
            : base(userId, firstName, lastName, role)
        {
            TeacherId = teacherId;
        }
        public override string DescribeRole()
        {
            return "Teacher: Views subjects taught and manages student grades.";
        }
        public virtual void AddGrade(int studentId, int subjectId, int grade)
        {
            var gradeRepo = new GradeRepository();
            var newGrade = new Grade
            {
                StudentId = studentId,
                SubjectId = subjectId,
                GradeValue = grade,
                DateCreated = DateTime.Now
            };
            gradeRepo.AddGrade(newGrade);

        }
        public virtual void EditGrade(int gradeId, int newValue) 
        { 
            var gradeRepo = new GradeRepository();
            var grade = gradeRepo.GetGradeById(gradeId);
            if (grade != null)
            {
                grade.GradeValue = newValue;
                grade.DateCreated = DateTime.Now;
                gradeRepo.UpdateGrade(grade);
            }
        }
        public virtual void DeleteGrade(int gradeId) 
        {
        var gradeRepo = new GradeRepository();
            gradeRepo.DeleteGrade(gradeId);
        }
    }
}
