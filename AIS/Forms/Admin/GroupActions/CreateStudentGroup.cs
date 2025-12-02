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
        public CreateStudentGroup()
        {
            InitializeComponent();
        }

        private void txtStudentGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                var userAdmin = new UserAdmin();
                userAdmin.CreateStudentGroup(
                    txtStudentGroup.Text.Trim()
                );

                MessageBox.Show("Group created successfully!");

              
                txtStudentGroup.Clear();
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

