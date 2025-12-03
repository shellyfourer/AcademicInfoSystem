using AIS.Repositories;
using AIS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms.Student
{
    public partial class StudentDashboard : Form
    {
        private readonly UserStudent _student;

        public StudentDashboard(UserStudent student)
        {
            InitializeComponent();
            _student = student;
            LoadGrades();
        }

        private void LoadGrades()
        {
            var grades = _student.ViewGrades();           // Grades only for this student
            var subjects = _student.ViewSubjects();       // All subjects assigned to this student's group

            var teacherSubjectRepo = new TeacherSubjectRepository();
            var userRepo = new UserRepository();

            var display = subjects.Select(subject =>
            {
                // Try to find a grade for this subject (or null)
                var grade = grades.FirstOrDefault(g => g.SubjectId == subject.SubjectId);

                // Find teacher for this subject
                var teacher = teacherSubjectRepo
                                .GetTeachersBySubjectId(subject.SubjectId)
                                .Select(t => userRepo.GetUserById(t.UserId))
                                .FirstOrDefault();

                return new
                {
                    Subject = subject.SubjectName,
                    Teacher = teacher != null ? $"{teacher.FirstName} {teacher.LastName}" : "",
                    Grade = grade?.GradeValue ?? null,    //null if no grade
                    Date = grade != null ? grade.DateCreated.ToShortDateString() : ""
                };
            })
            .ToList();

            dataGridView1.DataSource = display;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
