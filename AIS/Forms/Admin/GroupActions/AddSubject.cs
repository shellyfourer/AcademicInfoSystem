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

           
            var teacherUsers = userRepo.GetAllUsers()
                                       .Where(u => u.Role == "teacher")
                                       .ToList();

            var teacherList = teacherUsers
                .Select(u =>
                {
                    var teacher = teacherRepo.GetAllTeachers()
                                             .First(t => t.UserId == u.UserId);

                    return new
                    {
                        FullName = $"{u.FirstName} {u.LastName}",
                        TeacherId = teacher.TeacherId
                    };
                })
                .ToList();

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
                _admin.AssignTeacherToSubject(subjectName, (int)cmbTeacher.SelectedValue);

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
