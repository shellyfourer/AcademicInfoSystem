using AIS.Forms.Admin.GroupActions;
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
    public partial class StudentGroupInformation : Form
    {
        private int _groupId;
        private readonly UserAdmin _admin;
        private GroupSubjectRepository _groupSubjectRepo = new();
        private SubjectRepository _subjectRepo = new();
        private TeacherSubjectRepository _teacherSubjectRepo = new();
        private UserRepository _userRepo = new();

        public StudentGroupInformation(int groupId, UserAdmin admin)
        {
            InitializeComponent();
            _admin = admin;
            _groupId = groupId;
            LoadGroupSubjects();
        }

        private void LoadGroupSubjects()
        {
            var subjectIds = _groupSubjectRepo.GetSubjectsByGroupId(_groupId);

            var display = subjectIds.Select(id => new
            {
                SubjectId = id,
                Subject = _subjectRepo.GetSubjectById(id)?.SubjectName,

                Teachers = string.Join(", ",
                    _teacherSubjectRepo.GetTeachersBySubjectId(id)
                        .Select(t =>
                            _userRepo.GetUserById(t.UserId)?.FirstName + " " +
                            _userRepo.GetUserById(t.UserId)?.LastName
                        )
                )
            }).ToList();

            dataGridView1.DataSource = display;

           
            if (dataGridView1.Columns.Contains("SubjectId"))
                dataGridView1.Columns["SubjectId"].Visible = false;
        }


        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
               "Are you sure you want to delete this group?",
               "Confirm Delete",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            
            _admin.DeleteStudentGroup(_groupId);

            MessageBox.Show("Group Deleted Successfully.");
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
            //ignore header clicks etc.
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            //we stored SubjectId in the anonymous type
            int subjectId = (int)row.Cells["SubjectId"].Value;

            //open edit/delete form, passing the ID
            using (var form = new EditDeleteSubject(subjectId, _admin))
            {
                var result = form.ShowDialog();

                //if the form reports "OK", refresh the table
                if (result == DialogResult.OK)
                {
                    LoadGroupSubjects();
                }
            }
        }
       

        private void btnAddSubjet_Click(object sender, EventArgs e)
        {
            using (var form = new AddSubject(_groupId, _admin))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadGroupSubjects();
                }
            }
        }
    }
}
