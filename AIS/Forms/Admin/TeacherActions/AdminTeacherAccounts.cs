using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AIS.Repositories;
using AIS.Models;
using AIS.Services;

namespace AIS.Forms
{
    public partial class AdminTeacherAccounts : Form
    {
        TeacherRepository teacherRepo = new TeacherRepository();
        UserRepository userRepo = new UserRepository();

        public AdminTeacherAccounts()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            var teachers = teacherRepo.GetAllTeachers();

            var display = teachers.Select(s => new
            {
                TeacherId = s.TeacherId,
                FirstName = userRepo.GetUserById(s.UserId)?.FirstName,
                LastName = userRepo.GetUserById(s.UserId)?.LastName,
            }).ToList();

            dataGridView1.DataSource = display;
            dataGridView1.Columns["TeacherId"].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ignore header clicks etc.
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            //we stored StudentId in the anonymous type
            int teacherId = (int)row.Cells["TeacherId"].Value;

            //open edit/delete form, passing the ID
            using (var form = new EditDeleteTeacher(teacherId))
            {
                var result = form.ShowDialog();

                //if the form reports "OK", refresh the table
                if (result == DialogResult.OK)
                {
                    LoadTeachers();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var dashboard = new AdminDashboard();
            dashboard.Show();
            this.Close();
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            using (var form = new CreateTeacherAccount())
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadTeachers();
                }
            }
        }
    }
    }


