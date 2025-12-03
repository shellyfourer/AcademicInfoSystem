using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;


namespace AIS.Repositories
{
    public class StudentGroupRepository: IStudentGroupRepository
    {
        public StudentGroup? GetStudentGroupById (int studentGroupId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM student_groups WHERE student_group_id = @studentGroupId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentGroupId", studentGroupId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var studentGroup = new StudentGroup
                {
                    StudentGroupId = reader.GetInt32("student_group_id"),
                    StudentGroupName = reader.GetString("student_group_name")
                };
                return studentGroup;
            }
            else
            {
                return null;
            }
        }
        public List<StudentGroup> GetAllStudentGroups()
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM student_groups";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            var studentGroups = new List<StudentGroup>();
            while (reader.Read())
            {
                var studentGroup = new StudentGroup
                {
                    StudentGroupId = reader.GetInt32("student_group_id"),
                    StudentGroupName = reader.GetString("student_group_name")
                };
                studentGroups.Add(studentGroup);
            }
            return studentGroups;
        }
        public void AddStudentGroup(StudentGroup studentGroup)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = "INSERT INTO student_groups (student_group_name) VALUES (@studentGroupName); SELECT LAST_INSERT_ID();";
            
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentGroupName", studentGroup.StudentGroupName);
            
            studentGroup.StudentGroupId = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void DeleteStudentGroup(int studentGroupId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "DELETE FROM student_groups WHERE student_group_id = @studentGroupId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentGroupId", studentGroupId);
            cmd.ExecuteNonQuery();
        }
        public void UpdateStudentGroup(StudentGroup studentGroup)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "UPDATE student_groups SET student_group_name = @studentGroupName WHERE student_group_id = @studentGroupId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentGroupName", studentGroup.StudentGroupName);
            cmd.Parameters.AddWithValue("@studentGroupId", studentGroup.StudentGroupId);
            cmd.ExecuteNonQuery();
        }
    }
}
