using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    internal class GradeRepository: IGradeRepository
    {
        public Grade? GetGradeById(int gradeId) 
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "SELECT grade_id, student_id, subject_id, grade_value, date_created FROM grades WHERE grade_id = @gradeId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@gradeId", gradeId);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Grade
                {
                    GradeId = reader.GetInt32("grade_id"),
                    StudentId = reader.GetInt32("student_id"),
                    SubjectId = reader.GetInt32("subject_id"),
                    GradeValue = reader.GetInt32("grade_value"),
                    DateCreated = reader.GetDateTime("date_created")
                };
            }
            return null;
        }
        public List<Grade> GetAllGrades() 
        {
            var grades = new List<Grade>();
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "SELECT grade_id, student_id, subject_id, grade_value, date_created FROM grades";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                grades.Add(new Grade
                {
                    GradeId = reader.GetInt32("grade_id"),
                    StudentId = reader.GetInt32("student_id"),
                    SubjectId = reader.GetInt32("subject_id"),
                    GradeValue = reader.GetInt32("grade_value"),
                    DateCreated = reader.GetDateTime("date_created")
                });
            }
            return grades;
        }
        public void AddGrade(Grade grade) 
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "INSERT INTO grades (student_id, subject_id, grade_value, date_created) VALUES (@studentId, @subjectId, @gradeValue, @dateCreated); SELECT LAST_INSERT_ID();";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentId", grade.StudentId);
            cmd.Parameters.AddWithValue("@subjectId", grade.SubjectId);
            cmd.Parameters.AddWithValue("@gradeValue", grade.GradeValue);
            cmd.Parameters.AddWithValue("@dateCreated", grade.DateCreated);

            grade.GradeId = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void DeleteGrade(int gradeId) 
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "DELETE FROM grades WHERE grade_id = @gradeId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@gradeId", gradeId);
            command.ExecuteNonQuery();
        }
        public void UpdateGrade(Grade grade) 
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "UPDATE grades SET student_id = @studentId, subject_id = @subjectId, grade_value = @gradeValue, date_created = @dateCreated WHERE grade_id = @gradeId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", grade.StudentId);
            command.Parameters.AddWithValue("@subjectId", grade.SubjectId);
            command.Parameters.AddWithValue("@gradeValue", grade.GradeValue);
            command.Parameters.AddWithValue("@dateCreated", grade.DateCreated);
            command.Parameters.AddWithValue("@gradeId", grade.GradeId);
            command.ExecuteNonQuery();
        }

    }
}
