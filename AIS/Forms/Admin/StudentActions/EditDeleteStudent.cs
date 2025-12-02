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
    public partial class EditDeleteStudent : Form
    {
        private readonly int _studentId;
        private readonly StudentRepository studentRepo = new();
        private readonly UserRepository userRepo = new();
        private readonly StudentGroupRepository groupRepo = new();

        public EditDeleteStudent(int studentId)
        {
            InitializeComponent();
            _studentId = studentId;
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            var student = studentRepo.GetStudentById(_studentId);
            if (student == null)
            {
                MessageBox.Show("Student not found.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            var user = userRepo.GetUserById(student.UserId);
            var currentGroup = groupRepo.GetStudentGroupById(student.StudentGroupId);

            txtFirstName.Text = user?.FirstName;
            txtLastName.Text = user?.LastName;

            var groups = groupRepo.GetAllStudentGroups()
                .Select(g => new
                {
                    StudentGroupName = g.StudentGroupName,
                    StudentGroupId = g.StudentGroupId
                })
                .ToList();

            cmbGroup.DataSource = groups;
            cmbGroup.DisplayMember = "StudentGroupName";
            cmbGroup.ValueMember = "StudentGroupId";

            cmbGroup.SelectedValue = currentGroup?.StudentGroupId;
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            var admin = new UserAdmin();
            admin.DeleteStudentAccount(_studentId);

            MessageBox.Show("Student Deleted Successfully.");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var admin = new UserAdmin();

                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                int groupId = (int)cmbGroup.SelectedValue; // <- IMPORTANT FIX

                admin.EditStudentAccount(firstName, lastName, groupId, _studentId);

                MessageBox.Show("Student updated successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
