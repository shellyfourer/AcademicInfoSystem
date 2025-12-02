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
    public partial class AddSubject : Form
    {
        private int _groupId;

        public AddSubject(int groupId)
        {
            InitializeComponent();
            _groupId = groupId;
            AddSubject_Load(this, EventArgs.Empty);
        }


        private void AddSubject_Load(object sender, EventArgs e)
        {
            var userRepo = new UserRepository();
            var teacherRepo = new TeacherRepository();

            var teacherUsers = userRepo.GetAllUsers()
                                       .Where(u => u.Role == "teacher")
                                       .ToList();

            //attach teacherId to each row using anonymous object
            cmbTeacher.DataSource = teacherUsers.Select(u => new
            {
                FullName = u.FirstName + " " + u.LastName,
                UserId = u.UserId
            }).ToList();

            cmbTeacher.DisplayMember = "FullName";
            cmbTeacher.ValueMember = "UserId";
        }


        private void txtStudentGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateSubject_Click(object sender, EventArgs e)
        {
            try
            {
                var admin = new UserAdmin();

                string subjectName = txtSubject.Text.Trim();

                if (subjectName == "" || cmbTeacher.SelectedItem == null)
                {
                    MessageBox.Show("All fields must be filled.");
                    return;
                }

                int teacherUserId = (int)cmbTeacher.SelectedValue;



                admin.AssignSubjectToGroup(subjectName, _groupId);
                admin.AssignTeacherToSubject(subjectName, teacherUserId);

                MessageBox.Show("Subject assigned successfully!");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void txtTeacher_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
