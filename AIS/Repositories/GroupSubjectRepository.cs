using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;
using AIS.Database;
using MySql.Data.MySqlClient;

namespace AIS.Repositories
{
    public class GroupSubjectRepository : IGroupSubjectRepository
    {
        public GroupSubject? GetGroupSubjectById(int groupSubjectId)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "SELECT group_subject_id, student_group_id, subject_id FROM group_subjects WHERE group_subject_id = @groupSubjectId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@groupSubjectId", groupSubjectId);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new GroupSubject
                {
                    GroupSubjectId = reader.GetInt32("group_subject_id"),
                    StudentGroupId = reader.GetInt32("student_group_id"),
                    SubjectId = reader.GetInt32("subject_id")
                };
            }
            return null;
        }
        public List<GroupSubject> GetAllGroupSubjects()
        {
            var groupSubjects = new List<GroupSubject>();
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "SELECT group_subject_id, student_group_id, subject_id FROM group_subjects";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                groupSubjects.Add(new GroupSubject
                {
                    GroupSubjectId = reader.GetInt32("group_subject_id"),
                    StudentGroupId = reader.GetInt32("student_group_id"),
                    SubjectId = reader.GetInt32("subject_id")
                });
            }
            return groupSubjects;
        }
        public void AddGroupSubject(GroupSubject groupSubject)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "INSERT INTO group_subjects (student_group_id, subject_id) VALUES (@studentGroupId, @subjectId)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentGroupId", groupSubject.StudentGroupId);
            command.Parameters.AddWithValue("@subjectId", groupSubject.SubjectId);
            command.ExecuteNonQuery();
        }
        public void DeleteGroupSubject(int groupSubjectId)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "DELETE FROM group_subjects WHERE group_subject_id = @groupSubjectId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@groupSubjectId", groupSubjectId);
            command.ExecuteNonQuery();
        }
        public void UpdateGroupSubject(GroupSubject groupSubject)
        {
            using var connection = DatabaseConnection.GetConnection();
            connection.Open();
            string query = "UPDATE group_subjects SET student_group_id = @studentGroupId, subject_id = @subjectId WHERE group_subject_id = @groupSubjectId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentGroupId", groupSubject.StudentGroupId);
            command.Parameters.AddWithValue("@subjectId", groupSubject.SubjectId);
            command.Parameters.AddWithValue("@groupSubjectId", groupSubject.GroupSubjectId);
            command.ExecuteNonQuery();
        }
    }
}
