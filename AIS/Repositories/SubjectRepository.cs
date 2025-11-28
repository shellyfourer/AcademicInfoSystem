using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;


namespace AIS.Repositories
{
    public class SubjectRepository: ISubjectRepository
    {
        public Subject? GetSubjectById (int subjectId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM subjects WHERE subject_id = @subjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var subject = new Subject
                {
                    SubjectId = reader.GetInt32("subject_id"),
                    SubjectName = reader.GetString("subject_name")
                };
                return subject;
            }
            else
            {
                return null;
            }
        }
        public List<Subject> GetAllSubjects()
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM subjects";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            var subjects = new List<Subject>();
            while (reader.Read())
            {
                var subject = new Subject
                {
                    SubjectId = reader.GetInt32("subject_id"),
                    SubjectName = reader.GetString("subject_name")
                };
                subjects.Add(subject);
            }
            return subjects;
        }
        public void AddSubject(Subject subject)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "INSERT INTO subjects (subject_name) VALUES (@subjectName)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectName", subject.SubjectName);
            cmd.ExecuteNonQuery();
        }
        public void DeleteSubject(int subjectId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "DELETE FROM subjects WHERE subject_id = @subjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            cmd.ExecuteNonQuery();
        }
        public void UpdateSubject(Subject subject)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "UPDATE subjects SET subject_name = @subjectName WHERE subject_id = @subjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectName", subject.SubjectName);
            cmd.Parameters.AddWithValue("@subjectId", subject.SubjectId);
            cmd.ExecuteNonQuery();
        }
    }
}
