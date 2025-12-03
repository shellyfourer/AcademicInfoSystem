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

            var grades = _student.ViewGrades();

            var subjectRepo = new SubjectRepository();
            var teacherSubjectRepo = new TeacherSubjectRepository();
            var userRepo = new UserRepository();

            var display = grades.Select(g => new
            {
                Subject = subjectRepo.GetSubjectById(g.SubjectId)?.SubjectName,

                Teacher = teacherSubjectRepo
                    .GetTeachersBySubjectId(g.SubjectId)
                    .Select(t =>
                    {
                        var teacherUser = userRepo.GetUserById(t.UserId);
                        return teacherUser.FirstName + " " + teacherUser.LastName;
                    })
                    .FirstOrDefault(),

                Grade = g.GradeValue,
                Date = g.DateCreated.ToShortDateString()
            }).ToList();

            dataGridView1.DataSource = display;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
