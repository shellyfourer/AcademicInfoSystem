using AIS.Models;
using AIS.Repositories;
using AIS.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AIS.Forms
{
    public partial class AdminStudentAccounts : Form
    {
        private readonly UserAdmin _admin;
        private readonly StudentRepository studentRepo = new StudentRepository();
        private readonly UserRepository userRepo = new UserRepository();
        private readonly StudentGroupRepository groupRepo = new StudentGroupRepository();

        public AdminStudentAccounts(UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
            LoadStudents();
            
        }

        private void LoadStudents()
        {
            var students = studentRepo.GetAllStudents();

            var display = students.Select(s => new
            {
                StudentId = s.StudentId,
                FirstName = userRepo.GetUserById(s.UserId)?.FirstName,
                LastName = userRepo.GetUserById(s.UserId)?.LastName,
                Group = groupRepo.GetStudentGroupById(s.StudentGroupId)?.StudentGroupName
            }).ToList();

            dataGridView1.DataSource = display;
            dataGridView1.Columns["StudentId"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ignore header clicks etc.
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            //we stored StudentId in the anonymous type
            int studentId = (int)row.Cells["StudentId"].Value;

            //open edit/delete form, passing the ID
            using (var form = new EditDeleteStudent(studentId, _admin))
            {
                var result = form.ShowDialog();

                //if the form reports "OK", refresh the table
                if (result == DialogResult.OK)
                {
                    LoadStudents();
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var form = new CreateStudentAccount(_admin))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadStudents();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var dashboard = new AdminDashboard(_admin);
            dashboard.Show();
            this.Close();
        }

        private void AdminStudentAccounts_Load(object sender, EventArgs e)
        {

        }
    }
}
