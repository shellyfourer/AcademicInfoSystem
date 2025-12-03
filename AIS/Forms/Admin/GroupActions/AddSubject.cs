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
        private readonly UserAdmin _admin;

        public AddSubject(int groupId, UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
            _groupId = groupId;
            AddSubject_Load(this, EventArgs.Empty);
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            var userRepo = new UserRepository();
            var teacherRepo = new TeacherRepository();

            var teachers = teacherRepo.GetAllTeachers();

            var teacherList = teachers.Select(t =>
            {
                var user = userRepo.GetUserById(t.UserId);
                return new
                {
                    FullName = $"{user.FirstName} {user.LastName}",
                    TeacherId = t.TeacherId
                };
            }).ToList();

            cmbTeacher.DataSource = teacherList;
            cmbTeacher.DisplayMember = "FullName";
            cmbTeacher.ValueMember = "TeacherId";
        }

        private void btnCreateSubject_Click(object sender, EventArgs e)
        {
            try
            {
                string subjectName = txtSubject.Text.Trim();

                if (string.IsNullOrWhiteSpace(subjectName) || cmbTeacher.SelectedItem == null)
                {
                    MessageBox.Show("All fields must be filled.");
                    return;
                }

                int teacherId = (int)cmbTeacher.SelectedValue;

                // Assign subject to group
                _admin.AssignSubjectToGroup(subjectName, _groupId);

                // Assign teacher to subject
                _admin.AssignTeacherToSubject(subjectName, teacherId);

                MessageBox.Show("Subject assigned successfully!");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void txtTeacher_TextChanged(object sender, EventArgs e){ }
        private void txtStudentGroup_TextChanged(object sender, EventArgs e) { }
        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
