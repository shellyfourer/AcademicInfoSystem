using AIS.Repositories;
using AIS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms.Admin.GroupActions
{
    public partial class EditDeleteSubject : Form
    {
        private readonly UserAdmin _admin;
        private readonly int _subjectId;
        private readonly SubjectRepository subjectRepo = new();
        private readonly UserRepository userRepo = new();
        private readonly StudentGroupRepository groupRepo = new();
        private readonly TeacherRepository teacherRepo = new();
        private readonly GroupSubjectRepository groupSubjectRepo = new();
        private readonly TeacherSubjectRepository teacherSubjectRepo = new();


        public EditDeleteSubject(int subjectId, UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
            _subjectId = subjectId;
            LoadSubjectData();
        }

        private void LoadSubjectData()
        {

            var subject = subjectRepo.GetSubjectById(_subjectId);
            if (subject == null)
            {
                MessageBox.Show("Subject not found.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            txtSubject.Text = subject.SubjectName;


            var teacherAssignment = teacherSubjectRepo
                .GetAllTeacherSubjects()
                .FirstOrDefault(ts => ts.SubjectId == _subjectId);

            int currentTeacherId = teacherAssignment?.TeacherId ?? -1;


            var teacherList = teacherRepo.GetAllTeachers()
                .Select(t =>
                {
                    var user = userRepo.GetUserById(t.UserId);
                    return new
                    {
                        FullName = $"{user.FirstName} {user.LastName}",
                        TeacherId = t.TeacherId
                    };
                })
                .ToList();

            cmbTeacher.DataSource = teacherList;
            cmbTeacher.DisplayMember = "FullName";
            cmbTeacher.ValueMember = "TeacherId";

            if (currentTeacherId != -1)
                cmbTeacher.SelectedValue = currentTeacherId;


            var groupAssignment = groupSubjectRepo
                .GetAllGroupSubjects()
                .FirstOrDefault(gs => gs.SubjectId == _subjectId);

            int currentGroupId = groupAssignment?.StudentGroupId ?? -1;

            var groupList = groupRepo.GetAllStudentGroups()
                .Select(g => new
                {
                    GroupName = g.StudentGroupName,
                    GroupId = g.StudentGroupId
                })
                .ToList();

            cmbGroup.DataSource = groupList;
            cmbGroup.DisplayMember = "GroupName";
            cmbGroup.ValueMember = "GroupId";

            if (currentGroupId != -1)
                cmbGroup.SelectedValue = currentGroupId;
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
        }


        private void btnDeleteSubject_Click_1(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this subject?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _admin.DeleteSubject(_subjectId);

                MessageBox.Show("Subject deleted successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            try
            {
                string newName = txtSubject.Text.Trim();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    MessageBox.Show("Subject name cannot be empty.");
                    return;
                }

                if (cmbTeacher.SelectedItem == null || cmbGroup.SelectedItem == null)
                {
                    MessageBox.Show("Please select a teacher and a group.");
                    return;
                }

                int teacherId = (int)cmbTeacher.SelectedValue;
                int groupId = (int)cmbGroup.SelectedValue;


                _admin.EditSubject(_subjectId, newName, teacherId, groupId);

                MessageBox.Show("Subject updated successfully.");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
