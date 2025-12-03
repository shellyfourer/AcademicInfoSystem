using AIS.Repositories;
using AIS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace AIS.Forms
{
    public partial class EditDeleteTeacher : Form
    {
        private readonly UserAdmin _admin;
        private readonly int _teacherId;
        private readonly TeacherRepository teacherRepo = new();
        private readonly UserRepository userRepo = new();

        public EditDeleteTeacher(int teacherId, UserAdmin admin)
        {
            InitializeComponent();
            _teacherId = teacherId;
            _admin = admin;
            LoadTeacherData();
        }

        private void LoadTeacherData()
        {
            var teacher = teacherRepo.GetTeacherById(_teacherId);
            if (teacher == null)
            {
                MessageBox.Show("Teacher not found.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            var user = userRepo.GetUserById(teacher.UserId);

            txtFirstName.Text = user?.FirstName;
            txtLastName.Text = user?.LastName;
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTeacher_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
               "Are you sure you want to delete this teacher?",
               "Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            _admin.DeleteTeacherAccount(_teacherId);
            MessageBox.Show("Teacher Deleted Successfully.");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEditTeacher_Click(object sender, EventArgs e)
        {
            _admin.EditTeacherAccount(
            txtFirstName.Text.Trim(),
            txtLastName.Text.Trim(),
            _teacherId
            );
            MessageBox.Show("Teacher Edited Successfully.");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditDeleteTeacher_Load(object sender, EventArgs e)
        {

        }
    }
}
