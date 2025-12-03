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
        private readonly UserAdmin _admin;
        public CreateTeacherAccount(UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("All fields must be filled.");
                    return;
                }

                _admin.CreateTeacherAccount(firstName, lastName);

                MessageBox.Show("Teacher created successfully!");

                txtFirstName.Clear();
                txtLastName.Clear();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CreateTeacherAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
