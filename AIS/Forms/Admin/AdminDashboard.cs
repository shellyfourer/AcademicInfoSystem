using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnStudentAccounts_Click(object sender, EventArgs e)
        {
            if (btnStudentAccounts.Enabled)
            {
                AdminStudentAccounts studentAccountsForm = new AdminStudentAccounts();
                studentAccountsForm.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnTeacherAccounts_Click(object sender, EventArgs e)
        {
            AdminTeacherAccounts teacherAccountsForm = new AdminTeacherAccounts();
            teacherAccountsForm.Show();
            this.Hide();
        }

        private void btnStudentGroups_Click(object sender, EventArgs e)
        {
            var newForm = new AdminStudentGroups();
            newForm.Show();
            this.Hide();
        }
    }
}
