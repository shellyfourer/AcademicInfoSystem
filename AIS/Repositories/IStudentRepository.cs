using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface IStudentRepository   
    {
        Student? GetStudentById(int studentId);     
        List<Student> GetAllStudents();      
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
    }
}


