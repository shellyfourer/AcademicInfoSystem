using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Student? GetStudentById(int studentId)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with a parameter
            string query = "SELECT * FROM students WHERE student_id = @studentId";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@studentId", studentId);
            //we execute the command and read the data
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //we create a student object from the data 
                var student = new Student
                {
                    StudentId = reader.GetInt32("student_id"),
                    UserId = reader.GetInt32("user_id"),
                    StudentGroupId = reader.GetInt32("student_group_id")
                };
                //now we return the student or null if not found
                return student;
            }
            else
            {
                return null;
            }
        }
        public List<Student> GetAllStudents()
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string
            string query = "SELECT * FROM students";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //we execute the command and read the data
            using var reader = cmd.ExecuteReader();
            var students = new List<Student>();
            while (reader.Read())
            {
                //we create a student object from the data 
                var student = new Student
                {
                    StudentId = reader.GetInt32("student_id"),
                    UserId = reader.GetInt32("user_id"),
                    StudentGroupId = reader.GetInt32("student_group_id")
                };
                students.Add(student);
            }
            return students;
        }
        public void AddStudent(Student student)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with parameters
            string query = "INSERT INTO students (user_id, student_group_id) VALUES (@userId, @studentGroupId); SELECT LAST_INSERT_ID();";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@userId", student.UserId);
            cmd.Parameters.AddWithValue("@studentGroupId", student.StudentGroupId);
            //we execute the command
            student.StudentId = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void DeleteStudent(int studentId)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with a parameter
            string query = "DELETE FROM students WHERE student_id = @studentId";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@studentId", studentId);
            //we execute the command
            cmd.ExecuteNonQuery();
        }
        public void UpdateStudent(Student student)
        {
            //we open a fresh connection
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            //we make the query string with parameters
            string query = "UPDATE students SET user_id = @userId, student_group_id = @studentGroupId WHERE student_id = @studentId";
            //now we make a mysql command that will automatically dispose itself by "using"
            using var cmd = new MySqlCommand(query, conn);
            //now we add parameters to avoid sql injection
            cmd.Parameters.AddWithValue("@userId", student.UserId);
            cmd.Parameters.AddWithValue("@studentGroupId", student.StudentGroupId);
            cmd.Parameters.AddWithValue("@studentId", student.StudentId);
            //we execute the command
            cmd.ExecuteNonQuery();
        }
    }
}