using AIS.Models;
using AIS.Repositories;
using AIS.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AIS.Forms
{
    public partial class CreateStudentAccount : Form
    {
        private readonly UserAdmin _admin;

        public CreateStudentAccount(UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
            LoadGroups();
        }

        private void LoadGroups()
        {
            var groupRepo = new StudentGroupRepository();

            var groups = groupRepo.GetAllStudentGroups()
                .Select(g => new
                {
                    StudentGroupName = g.StudentGroupName,
                    StudentGroupId = g.StudentGroupId
                })
                .ToList();

            cmbStudentGroup.DataSource = groups;
            cmbStudentGroup.DisplayMember = "StudentGroupName";
            cmbStudentGroup.ValueMember = "StudentGroupId";
        }

        private void btnCreateStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                int groupId = (int)cmbStudentGroup.SelectedValue;

                if (string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("All fields must be filled.");
                    return;
                }

                _admin.CreateStudentAccount(firstName, lastName, groupId);

                MessageBox.Show("Student created successfully!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e) { }
        private void txtLastName_TextChanged(object sender, EventArgs e) { }
        private void txtStudentGroup_TextChanged_1(object sender, EventArgs e) { }
        private void cmbStudentGroup_SelectedIndexChanged(object sender, EventArgs e) { }
        private void CreateStudentAccount_Load_1(object sender, EventArgs e) { }
    }
}
