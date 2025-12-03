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
    public partial class CreateStudentGroup : Form
    {
        private readonly UserAdmin _admin;
        public CreateStudentGroup(UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
        }

        private void txtStudentGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                string groupName = txtStudentGroup.Text.Trim();

                if (string.IsNullOrWhiteSpace(groupName))
                {
                    MessageBox.Show("Group name cannot be empty.");
                    return;
                }

                _admin.CreateStudentGroup(groupName);

                MessageBox.Show("Group created successfully!");

                txtStudentGroup.Clear();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
 

