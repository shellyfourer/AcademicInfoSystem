using AIS.Models;
using AIS.Repositories;
using AIS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AIS.Forms.Teacher
{
    public partial class AssignGrades : Form
    {
        private int _studentId;
        private int _subjectId;
        private readonly UserTeacher _teacher;

        private readonly GradeRepository gradeRepo = new();
        private readonly StudentRepository studentRepo = new();

        private Grade _existingGrade; //null if no grade assigned

        public AssignGrades(int studentId, int subjectId, UserTeacher teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            _studentId = studentId;
            _subjectId = subjectId;
            LoadGradeData();
        }

        private void LoadGradeData()
        {
            // Get ALL grades and find the one matching student + subject
            var grade = gradeRepo
                .GetAllGrades()
                .FirstOrDefault(g => g.StudentId == _studentId && g.SubjectId == _subjectId);

            // Fill combo box
            cmbGrades.Items.Clear();
            cmbGrades.Items.Add("-");

            for (int i = 1; i <= 10; i++)
                cmbGrades.Items.Add(i.ToString());

            // Default selection
            if (grade == null)
            {
                cmbGrades.SelectedItem = "-"; // No grade exists
            }
            else
            {
                cmbGrades.SelectedItem = grade.GradeValue.ToString();
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateGrade_Click(object sender, EventArgs e)
        {
            string selected = cmbGrades.SelectedItem.ToString();

            
            var existing = gradeRepo
                .GetAllGrades()
                .FirstOrDefault(g => g.StudentId == _studentId && g.SubjectId == _subjectId);

            //dELETE grade
            if (selected == "-")
            {
                if (existing != null)
                    gradeRepo.DeleteGrade(existing.GradeId);

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            int newValue = int.Parse(selected);

            //add new grade
            if (existing == null)
            {
                gradeRepo.AddGrade(new Grade
                {
                    StudentId = _studentId,
                    SubjectId = _subjectId,
                    GradeValue = newValue,
                    DateCreated = DateTime.Now
                });
            }
            else
            {
                //update grade
                existing.GradeValue = newValue;
                existing.DateCreated = DateTime.Now;
                gradeRepo.UpdateGrade(existing);
            }

            MessageBox.Show("Grade updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbGrades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
