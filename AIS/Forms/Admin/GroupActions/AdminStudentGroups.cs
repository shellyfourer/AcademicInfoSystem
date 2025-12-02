using AIS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms
{
    public partial class AdminStudentGroups : Form
    {
        StudentGroupRepository studentGroupRepo = new StudentGroupRepository();

        public AdminStudentGroups()
        {
            InitializeComponent();
            LoadStudentGroups();
        }

        private void LoadStudentGroups()
        {
            var studentgroups = studentGroupRepo.GetAllStudentGroups();

            var display = studentgroups.Select(s => new
            {
                StudentGroupId = s.StudentGroupId,
                StudentGroup = studentGroupRepo.GetStudentGroupById(s.StudentGroupId)?.StudentGroupName,

            }).ToList();

            dataGridView1.DataSource = display;
            dataGridView1.Columns["StudentGroupId"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ignore header clicks etc.
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            int studentgroupId = (int)row.Cells["StudentGroupId"].Value;

            // open form, passing the ID
            using (var form = new StudentGroupInformation(studentgroupId))
            {
                var result = form.ShowDialog();

                // refresh table after returning
                if (result == DialogResult.OK)
                {
                    LoadStudentGroups();
                }
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            using (var form = new CreateStudentGroup())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadStudentGroups();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var adminForm = new AdminDashboard();
            adminForm.Show();
            this.Close();
        }
    }
}
