using AIS.Services;
using System;
using System.Windows.Forms;

namespace AIS.Forms
{
    public partial class AdminDashboard : Form
    {
        private readonly UserAdmin _admin;

        public AdminDashboard(UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private void btnStudentAccounts_Click(object sender, EventArgs e)
        {
            var form = new AdminStudentAccounts(_admin);
            form.Show();
            this.Hide();
        }

        private void btnTeacherAccounts_Click(object sender, EventArgs e)
        {
            var form = new AdminTeacherAccounts(_admin);
            form.Show();
            this.Hide();
        }

        private void btnStudentGroups_Click(object sender, EventArgs e)
        {
            var form = new AdminStudentGroups(_admin);
            form.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e) { }
        private void AdminDashboard_Load(object sender, EventArgs e) { }

    }
}
