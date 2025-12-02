using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        public TeacherSubject? GetTeacherSubjectById(int teacherSubjectId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM teacher_subjects WHERE teacher_subject_id = @teacherSubjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherSubjectId", teacherSubjectId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var teacherSubject = new TeacherSubject
                {
                    TeacherSubjectId = reader.GetInt32("teacher_subject_id"),
                    TeacherId = reader.GetInt32("teacher_id"),
                    SubjectId = reader.GetInt32("subject_id")
                };
                return teacherSubject;
            }
            else
            {
                return null;
            }
        }
        public List<Teacher> GetTeachersBySubjectId(int subjectId)
        {
            List<Teacher> teachers = new List<Teacher>();

            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            string query = @"SELECT teachers.teacher_id, teachers.user_id 
                     FROM teacher_subjects
                     JOIN teachers ON teacher_subjects.teacher_id = teachers.teacher_id
                     WHERE teacher_subjects.subject_id = @subjectId";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                teachers.Add(new Teacher
                {
                    TeacherId = reader.GetInt32("teacher_id"),
                    UserId = reader.GetInt32("user_id")
                });
            }

            return teachers;
        }
        public List<TeacherSubject> GetAllTeacherSubjects()
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "SELECT * FROM teacher_subjects";
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            var teacherSubjects = new List<TeacherSubject>();
            while (reader.Read())
            {
                var teacherSubject = new TeacherSubject
                {
                    TeacherSubjectId = reader.GetInt32("teacher_subject_id"),
                    TeacherId = reader.GetInt32("teacher_id"),
                    SubjectId = reader.GetInt32("subject_id")
                };
                teacherSubjects.Add(teacherSubject);
            }
            return teacherSubjects;
        }
        public void AddTeacherSubject(TeacherSubject teacherSubject)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "INSERT INTO teacher_subjects (teacher_id, subject_id) VALUES (@teacherId, @subjectId)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherId", teacherSubject.TeacherId);
            cmd.Parameters.AddWithValue("@subjectId", teacherSubject.SubjectId);
            cmd.ExecuteNonQuery();
        }
        public void DeleteTeacherSubject(int teacherSubjectId)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "DELETE FROM teacher_subjects WHERE teacher_subject_id = @teacherSubjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherSubjectId", teacherSubjectId);
            cmd.ExecuteNonQuery();
        }
        public void UpdateTeacherSubject(TeacherSubject teacherSubject)
        {
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            string query = "UPDATE teacher_subjects SET teacher_id = @teacherId, subject_id = @subjectId WHERE teacher_subject_id = @teacherSubjectId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@teacherId", teacherSubject.TeacherId);
            cmd.Parameters.AddWithValue("@subjectId", teacherSubject.SubjectId);
            cmd.Parameters.AddWithValue("@teacherSubjectId", teacherSubject.TeacherSubjectId);
            cmd.ExecuteNonQuery();
        }
    }
}
