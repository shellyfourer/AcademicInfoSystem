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
    public partial class AdminStudentGroups : Form
    {
        private readonly UserAdmin _admin;
        private readonly StudentGroupRepository studentGroupRepo = new();

        public AdminStudentGroups(UserAdmin admin)
        {
            _admin = admin;
            InitializeComponent();
            LoadStudentGroups();
        }

        private void LoadStudentGroups()
        {
           
            var groups = studentGroupRepo.GetAllStudentGroups()
                .Select(g => new
                {
                    StudentGroupId = g.StudentGroupId,
                    StudentGroupName = g.StudentGroupName
                })
                .ToList();

            dataGridView1.DataSource = groups;
            dataGridView1.Columns["StudentGroupId"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ignore header clicks etc.
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            int studentgroupId = (int)row.Cells["StudentGroupId"].Value;

            // open form, passing the ID
            using (var form = new StudentGroupInformation(studentgroupId, _admin))
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
            using (var form = new CreateStudentGroup(_admin))
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
            var adminForm = new AdminDashboard(_admin);
            adminForm.Show();
            this.Close();
        }
    }
}
