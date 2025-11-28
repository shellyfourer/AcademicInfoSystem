using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface ITeacherRepository
    {
        Teacher? GetTeacherById(int teacherId); 
        List<Teacher> GetAllTeachers(); 
        void AddTeacher(Teacher teacher);
        void DeleteTeacher(int teacherId);
        void UpdateTeacher(Teacher teacher);
    }
}
