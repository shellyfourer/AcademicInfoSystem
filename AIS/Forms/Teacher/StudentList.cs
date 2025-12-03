using AIS.Repositories;
using AIS.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AIS.Forms.Teacher
{
    public partial class StudentList : Form
    {
        private readonly UserTeacher _teacher;
        private readonly StudentRepository studentRepo = new();
        private readonly UserRepository userRepo = new ();
        private readonly GradeRepository gradeRepo = new ();
        private readonly GroupSubjectRepository groupSubjectRepo = new();
        private readonly SubjectRepository subjectRepo = new();

        private int _subjectId;
        
        public StudentList(int subjectId, UserTeacher teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            _subjectId = subjectId; 
            LoadStudentList();
        }

        public void LoadStudentList()
        {
            var grades = gradeRepo.GetAllGrades();
            var students = studentRepo.GetAllStudents();
            var users = userRepo.GetAllUsers();

            var groupIds = groupSubjectRepo
                .GetGroupsBySubjectId(_subjectId);   

            var studentsInSubject = students
                .Where(s => groupIds.Contains(s.StudentGroupId))
                .ToList();

            var display =
                from s in studentsInSubject
                join u in users on s.UserId equals u.UserId
                join g in grades
                      .Where(gr => gr.SubjectId == _subjectId)
                      on s.StudentId equals g.StudentId into sg
                from grade in sg.DefaultIfEmpty()
                select new
                {
                    StudentId = s.StudentId,
                    Name = u.FirstName,
                    LastName = u.LastName,
                    Grade = grade?.GradeValue ?? (int?)null,
                    Date = grade?.DateCreated
                };

            dataGridView1.DataSource = display.ToList();

            if (dataGridView1.Columns.Contains("StudentId"))
                dataGridView1.Columns["StudentId"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ignore header clicks etc.
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            int studentId = (int)row.Cells["StudentId"].Value;
            // open form, passing the ID
            using (var form = new AssignGrades(studentId, _subjectId, _teacher))
            {
                var result = form.ShowDialog();
                // refresh table after returning
                if (result == DialogResult.OK)
                {
                    LoadStudentList();
                }
            }
        }
    }
}
