using AIS.Models;
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
    public partial class CreateStudentAccount : Form
    {
        public CreateStudentAccount()
        {
            InitializeComponent();
            CreateStudentAccount_Load(this, EventArgs.Empty);
        }

        private void CreateStudentAccount_Load(object sender, EventArgs e)
        {
            var groupRepo = new StudentGroupRepository();

            var groups = groupRepo.GetAllStudentGroups();

            cmbStudentGroup.DataSource = groups
                .Select(g => new
                {
                    StudentGroupName = g.StudentGroupName,
                    StudentGroupId = g.StudentGroupId
                })
                .ToList();

            cmbStudentGroup.DisplayMember = "StudentGroupName";
            cmbStudentGroup.ValueMember = "StudentGroupId";
        }


        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentGroup_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCreateStudent_Click_1(object sender, EventArgs e)
        {
            try
            {
                var admin = new UserAdmin();

                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();

                int groupId = (int)cmbStudentGroup.SelectedValue;

                admin.CreateStudentAccount(firstName, lastName, groupId);

                MessageBox.Show("Student created successfully!");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void cmbStudentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}