using AIS.Forms;
using AIS.Forms.Teacher;
using AIS.Forms.Student;
using AIS.Models;
using AIS.Repositories;
using AIS.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AIS
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository userRepo = new UserRepository();
        private readonly TeacherRepository teacherRepo = new TeacherRepository();
        private readonly StudentRepository studentRepo = new StudentRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var user = userRepo.GetAllUsers()
                               .FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                lblError.Text = "Invalid login or password!";
                return;
            }

            lblError.Text = "";
            MessageBox.Show($"Welcome, {user.FirstName}!");


            //ADMIN LOGIN
            if (user.Role == "admin")
            {
                var admin = new UserAdmin(
                    user.UserId,
                    user.FirstName,
                    user.LastName,
                    user.Role
                );

                MessageBox.Show(admin.DescribeRole());
                new AdminDashboard(admin).Show();
                this.Hide();
                return;
            }

            //TEACHER LOGIN
            if (user.Role == "teacher")
            {
                var teacher = teacherRepo.GetAllTeachers()
                                         .FirstOrDefault(t => t.UserId == user.UserId);

                if (teacher == null)
                {
                    MessageBox.Show("Teacher record missing in database.");
                    return;
                }

                var teacherUser = new UserTeacher(
                    user.UserId,
                    user.FirstName,
                    user.LastName,
                    user.Role,
                    teacher.TeacherId
                );

                MessageBox.Show(teacherUser.DescribeRole());
                new TeacherDashboard(teacherUser).Show();
                this.Hide();
                return;
            }

            //STUDENT LOGIN
            if (user.Role == "student")
            {
                var student = studentRepo.GetAllStudents()
                                         .FirstOrDefault(s => s.UserId == user.UserId);

                if (student == null)
                {
                    MessageBox.Show("Student record missing in database.");
                    return;
                }

                var studentUser = new UserStudent(
                    user.UserId,
                    user.FirstName,
                    user.LastName,
                    user.Role,
                    student.StudentId,
                    student.StudentGroupId
                );
                MessageBox.Show(studentUser.DescribeRole());
                new StudentDashboard(studentUser).Show();
                this.Hide();
            }
        }
    }
}
