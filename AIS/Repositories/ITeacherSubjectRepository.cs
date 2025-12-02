using System;
using System.Collections.Generic;
using System.Text;
using AIS.Models;

namespace AIS.Repositories
{
    public interface ITeacherSubjectRepository
    {
        TeacherSubject? GetTeacherSubjectById(int teacherSubjectId);
        List<Teacher> GetTeachersBySubjectId(int subjectId);
        List<TeacherSubject> GetAllTeacherSubjects(); 
        void AddTeacherSubject(TeacherSubject teacherSubject);
        void DeleteTeacherSubject(int teacherSubjectId);
        void UpdateTeacherSubject(TeacherSubject teacherSubject);
    }
}
