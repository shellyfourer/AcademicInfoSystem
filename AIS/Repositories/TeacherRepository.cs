using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    internal class TeacherRepository: ITeacherRepository
    {
        public Teacher? GetTeacherById(int teacherId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM teachers WHERE teacher_id = @teacherId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherId", teacherId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var teacher = new Teacher
                {
                    TeacherId = reader.GetInt32("teacher_id"),
                    UserId = reader.GetInt32("user_id")
                };
                return teacher;
            }
            else
            {
                return null;
}
        }
        public List<Teacher> GetAllTeachers()
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM teachers";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            var teachers = new List<Teacher>();
            while (reader.Read())
            {
                var teacher = new Teacher
                {
                    TeacherId = reader.GetInt32("teacher_id"),
                    UserId = reader.GetInt32("user_id")
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
        public void AddTeacher(Teacher teacher)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "INSERT INTO teachers (user_id) VALUES (@userId)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", teacher.UserId);
            cmd.ExecuteNonQuery();
        }
        public void DeleteTeacher(int teacherId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "DELETE FROM teachers WHERE teacher_id = @teacherId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherId", teacherId);
            cmd.ExecuteNonQuery();
        }
        public void UpdateTeacher(Teacher teacher)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "UPDATE teachers SET user_id = @userId WHERE teacher_id = @teacherId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", teacher.UserId);
            cmd.Parameters.AddWithValue("@teacherId", teacher.TeacherId);
            cmd.ExecuteNonQuery();
        }
    }
}
