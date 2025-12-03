using AIS.Forms.Admin.GroupActions;
using AIS.Repositories;
using AIS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms.Teacher
{
    public partial class TeacherDashboard : Form
    {
        private readonly UserTeacher _teacher;
        private readonly TeacherSubjectRepository teacherSubjectRepo = new();
        private readonly SubjectRepository subjectRepo = new();



        public TeacherDashboard(UserTeacher teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            LoadSubjects();
        }

            private void LoadSubjects()
        {
            var teacherSubjectAssignments = teacherSubjectRepo
                .GetAllTeacherSubjects()
                .Where(ts => ts.TeacherId == _teacher.TeacherId)
                .ToList();

            var display = teacherSubjectAssignments.Select(ts => new
            {
                Subject = subjectRepo.GetSubjectById(ts.SubjectId)?.SubjectName,
                SubjectId = ts.SubjectId
            }).ToList();


            dataGridView1.DataSource = display;

            if (dataGridView1.Columns.Contains("SubjectId"))
                dataGridView1.Columns["SubjectId"].Visible = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            //we stored SubjectId in the anonymous type
            int subjectId = (int)row.Cells["SubjectId"].Value;

            //open student list form, passing the subject ID
            using (var form = new StudentList(subjectId, _teacher))
            {
                var result = form.ShowDialog();
            }

        }
    }
}
