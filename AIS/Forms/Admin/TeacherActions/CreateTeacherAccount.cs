using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIS.Services;

namespace AIS.Forms
{
    public partial class CreateTeacherAccount : Form
    {
        public CreateTeacherAccount()
        {
            InitializeComponent();
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var UserAdmin = new UserAdmin();
                UserAdmin.CreateTeacherAccount(
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim()
                );
                MessageBox.Show("Teacher created successfully!");
                txtFirstName.Clear();
                txtLastName.Clear();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
